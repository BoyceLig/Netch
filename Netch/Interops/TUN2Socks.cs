using Microsoft.Win32;
using System.Diagnostics;
using System.Text;

namespace Netch.Interops
{
    public static class TUN2Socks
    {
        private static Process? _process;

        private const string ProfilesKeyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles";
        private const string UnmanagedKeyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged";

        public static bool Init(string interfaceName, string proxyHost, int proxyPort, string? username = null, string? password = null)
        {
            Log.Verbose("[tun2socks] init");
            if (_process != null && !_process.HasExited)
            {
                Log.Warning("[tun2socks] Process already running");
                return false;
            }

            try
            {
                var args = BuildArgs(interfaceName, proxyHost, proxyPort, username, password);
                Log.Verbose($"[tun2socks] Args: {args}");
                var processPath = Path.Combine(Global.NetchDir, Constants.TUN2SocksFile);
                Log.Verbose($"[tun2socks] Path: {processPath}");

                _process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = processPath,
                        Arguments = args,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        StandardOutputEncoding = Encoding.UTF8,
                        StandardErrorEncoding = Encoding.UTF8
                    },
                    EnableRaisingEvents = true
                };

                _process.Exited += (_, _) =>
                {
                    Log.Warning("[tun2socks]已退出");
                    // 这里可以触发清理路由 / DNS
                };



                if (_process.Start())
                {
                    Log.Verbose("[tun2socks] Process started successfully.");
                }
                else
                {
                    Log.Error("[tun2socks] Process failed to start.");
                }

                Global.Job.AddProcess(_process);


                // 可选：异步读取输出
                _ = Task.Run(async () => ReadOutputAsync(_process));

                return true;
            }
            catch (Exception e)
            {
                Log.Error(e, $"[tun2socks] Failed to start v3 process");
                return false;
            }

        }

        private const int CTRL_C_EVENT = 0;

        /// <summary>
        /// 杀掉 tun2socks 进程
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> FreeAsync()
        {
            bool isSuccess;
            try
            {
                if (_process != null && !_process.HasExited)
                {
                    _process.Close();                    
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "[tun2socks] FreeAsync failed");
                isSuccess = false;
            }
            finally
            {
                // 释放进程资源
                _process?.Dispose();
                _process = null;
                isSuccess = true;
            }
            return isSuccess;
        }      

        private static string BuildArgs(string interfaceName, string host, int port, string? username, string? password)
        {
            var sb = new StringBuilder();
            sb.Append($"-device tun://{interfaceName}?guid={{20214AD5-1D95-4CC1-9233-D850D2C9CF9C}} ");
            // SOCKS5
            sb.Append("-proxy socks5://");
            if (!string.IsNullOrEmpty(username))
            {
                sb.Append($"{username}:{password}@");
            }
            sb.Append($"{host}:{port} ");

            sb.Append("-mtu 1500 ");

            sb.Append("-loglevel debug ");

            return sb.ToString();
        }

        private static async Task ReadOutputAsync(Process p)
        {
            string logPath = Path.Combine(Global.NetchDir, "logging", "tun2socks.log");
            await using var _logFileStream = new FileStream(logPath, FileMode.Create, FileAccess.Write, FileShare.Read, 4096, true);
            await using var _logStreamWriter = new StreamWriter(_logFileStream, Encoding.UTF8) { AutoFlush = true };

            Task ReadStreamAsync(StreamReader reader, Action<string> logAction)
            {
                var prefix = "tun2socks";
                return Task.Run(async () =>
                {
                    string? line;
                    try
                    {
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            await _logStreamWriter.WriteLineAsync($"[{prefix}] {line}");
                            //logAction?.Invoke($"[{prefix}] {line}");
                        }
                    }
                    catch (Exception ex)
                    {
                        await _logStreamWriter.WriteLineAsync($"[{prefix}] Stream read exception: {ex}");
                        Log.Error(ex.ToString());
                    }
                });
            }
            var stdoutTask = ReadStreamAsync(p.StandardOutput, Log.Verbose);
            var stderrTask = ReadStreamAsync(p.StandardError, Log.Verbose);

            await Task.WhenAll(stdoutTask, stderrTask);

            await _logStreamWriter.WriteLineAsync("[tun2socks] Process exited.");

            await _logStreamWriter.DisposeAsync();
            await _logFileStream.DisposeAsync();
        }

        #region 注册表操作
        private static string? CheckTunGUID(string interfaceName)
        {
            using (var profilesKey = Registry.LocalMachine.OpenSubKey(ProfilesKeyPath, false))
            {
                if (profilesKey == null)
                {
                    Log.Error("注册表路径不存在。");
                    return null;
                }

                var profileGuids = profilesKey.GetSubKeyNames();

                foreach (var guid in profileGuids)
                {
                    using (var profileKey = profilesKey.OpenSubKey(guid, false))
                    {
                        if (profileKey == null) continue;
                        // 读取配置名称
                        var profileName = profileKey.GetValue("ProfileName") as string;
                        if (profileName == interfaceName)
                        {
                            Log.Verbose($"GUID 为{guid}");
                            return guid;
                        }
                    }
                }
            }
            Log.Verbose("没有 GUID");
            return null;
        }
        private static int CleanRegeditNetworkProfiles(string path)
        {
            int cleanedCount = 0;
            try
            {
                Log.Verbose($"正在扫描注册表路径: {path}");
                using (var profilesKey = Registry.LocalMachine.OpenSubKey(path, true))
                {
                    if (profilesKey == null)
                    {
                        Log.Error("注册表路径不存在，可能系统版本不支持。");
                        return 0;
                    }

                    // 获取所有配置的GUID（子键名称）
                    string[] profileGuids = profilesKey.GetSubKeyNames();
                    Log.Verbose($"找到 {profileGuids.Length} 个网络配置");

                    foreach (string guid in profileGuids)
                    {
                        using (var profileKey = profilesKey.OpenSubKey(guid, false))
                        {
                            if (profileKey == null) continue;

                            // 读取配置名称
                            var profileName = profileKey.GetValue("Description") as string;

                            if (string.IsNullOrEmpty(profileName) || profileName.Contains("Netch"))
                            {
                                try
                                {
                                    // 关闭当前键，以便删除
                                    profileKey.Close();

                                    // 删除该配置
                                    profilesKey.DeleteSubKeyTree(guid);
                                    cleanedCount++;

                                    Log.Verbose($"已删除网络配置: {profileName ?? "未知"} ({guid})");
                                }
                                catch (Exception ex)
                                {
                                    Log.Error($"删除配置 {guid} 失败: {ex.Message}");
                                }
                            }
                        }
                    }
                }

                Log.Verbose($"清理完成，共删除 {cleanedCount} 个网络配置。");
                return cleanedCount;
            }
            catch (Exception ex)
            {
                Log.Error($"清理网络配置时发生错误: {ex.Message}");
                return cleanedCount;
            }
        }
        #endregion
    }
}