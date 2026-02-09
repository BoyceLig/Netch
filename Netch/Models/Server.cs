using Netch.Servers;
using Netch.Utils;
using System;
using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace Netch.Models;

public abstract class Server : ICloneable
{
    /// <summary>
    ///     延迟
    /// </summary>
    [JsonIgnore]
    public int Delay { get; private set; } = -1;

    /// <summary>
    ///     组
    /// </summary>
    public string Group { get; set; } = Constants.DefaultGroup;

    /// <summary>
    ///     地址
    /// </summary>
    public string Hostname { get; set; } = string.Empty;

    /// <summary>
    ///     端口
    /// </summary>
    public ushort Port { get; set; }

    /// <summary>
    ///     倍率
    /// </summary>
    public double Rate { get; } = 1.0;

    /// <summary>
    ///     备注
    /// </summary>
    public string Remark { get; set; } = "";

    /// <summary>
    ///     代理类型
    /// </summary>
    [JsonPropertyOrder(int.MinValue)]
    public abstract string Type { get; }

    public TLSConfig tlsConfig { get; set; } = new();

    public object Clone()
    {
        return MemberwiseClone();
    }

    /// <summary>
    ///     获取备注
    /// </summary>
    /// <returns>备注</returns>
    public override string ToString()
    {
        var remark = string.IsNullOrWhiteSpace(Remark) ? $"{Hostname}:{Port}" : Remark;

        var shortName = ServerHelper.GetUtilByTypeName(Type).ShortName;

        return $"[{shortName}][{Group}] {remark}";
    }

    public abstract string MaskedData();

    /// <summary>
    ///     测试延迟
    /// </summary>
    /// <returns>延迟</returns>
    public async Task<int> PingAsync()
    {
        try
        {
            var destination = await DnsUtils.LookupAsync(Hostname);
            if (destination == null)
                return Delay = -2;

            var list = new Task<int>[3];
            for (var i = 0; i < 3; i++)
            {
                Task<int> PingCoreAsync()
                {
                    try
                    {
                        return Global.Settings.ServerTCPing ? Utils.Utils.TCPingAsync(destination, Port) : Utils.Utils.ICMPingAsync(destination);
                    }
                    catch (Exception)
                    {
                        return Task.FromResult(-4);
                    }
                }

                list[i] = PingCoreAsync();
            }

            var resTask = await Task.WhenAny(list[0], list[1], list[2]);

            return Delay = await resTask;
        }
        catch (Exception)
        {
            return Delay = -4;
        }
    }
}

public class TLSConfig
{
    /// <summary>
    ///     TLS 底层传输安全
    /// </summary>
    public string TLSSecureType { get; set; } = TLSGlobe.TLSSecure[0];

    /// <summary>
    /// sni
    /// </summary>
    public string? ServerName { get; set; } = string.Empty;

    public string Fingerprint { get; set; } = TLSGlobe.Fingerprint[0];
    public string UserAgent
    {
        get => TLSGlobe.UserAgent(Fingerprint);
    }

    #region TLSSecureType=tls 所需参数
    public string Alpn { get; set; } = TLSGlobe.Alpn[0];
    public bool? allowInsecure { get; set; }
    public string? EchConfigList { get; set; }
    public string? EchForceQuery { get; set; } = TLSGlobe.EchForceQuery[0];
    public string? XHttpObject { get; set; }
    public string? PinSHA256 { get; set; }
    #endregion

    #region TLSSecureType=reality 所需参数

    public string? PublicKey { get; set; }
    public string? ShortId { get; set; }
    public string? SpiderX { get; set; }
    public string? Mldsa65Verify { get; set; }
    #endregion
}
public class TLSGlobe
{
    /// <summary>
    ///     TLS 安全类型
    /// </summary>
    public static readonly List<string> TLSSecure = new()
    {
        "none",
        "tls",
        "xtls",
        "reality"
    };

    public static readonly List<string> Fingerprint = new()
    {
        "",
        "chrome",
        "firefox",
        "safari",
        "ios",
        "android",
        "edge",
        "360",
        "qq",
        "random",
        "randomized",
    };
    public static string UserAgent(string fingerprint)
    {
        return fingerprint switch
        {
            "" => "", // 返回空字符串
            "chrome" => "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36",
            "firefox" => "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/120.0",
            "safari" => "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.0 Safari/605.1.15",
            "ios" => "Mozilla/5.0 (iPhone; CPU iPhone OS 17_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.0 Mobile/15E148 Safari/604.1",
            "android" => "Mozilla/5.0 (Linux; Android 14; SM-G991B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Mobile Safari/537.36",
            "edge" => "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 Edg/120.0.0.0",
            "360" => "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.198 Safari/537.36",
            "qq" => "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.198 Safari/537.36 QQBrowser/11.4.5116.400",
            "random" or "randomized" => GetRandomUserAgent(),
            _ => "" // 默认返回空字符串，或可抛出异常
        };
    }
    public static string GetRandomUserAgent()
    {
        Random _random = new();
        //剔除空和随机字符
        var availableFps = Fingerprint.Where(fp => !string.IsNullOrEmpty(fp) && fp != "random" && fp != "randomized").ToList();

        var randomFp = availableFps[_random.Next(availableFps.Count)];
        return UserAgent(randomFp);
    }

    public static readonly List<string> Alpn = new()
    {
        "",
        "h3",
        "h2",
        "http/1.1",
        "h3,h2",
        "h2,http/1.1",
        "h3,h2,http/1.1",
    };
    public static readonly List<string> EchForceQuery = new()
    {
        "",
        "none",
        "half",
        "full",
    };
}

public class TransportConfig
{
    /// <summary>
    ///     传输协议
    /// </summary>
    public string TransferProtocol { get; set; } = TransportGlobal.TransferProtocols[0];

    /// <summary>
    ///     伪装类型
    /// </summary>
    public string FakeType { get; set; } = TransportGlobal.FakeTypes[0];

    /// <summary>
    ///     伪装域名
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    ///     传输路径
    /// </summary>
    public string? Path { get; set; }

    public string? XHttpObject { get; set; }

}

public class TransportGlobal
{
    /// <summary>
    ///     V2Ray 传输协议
    /// </summary>
    public static readonly List<string> TransferProtocols = new()
    {
        "tcp",
        "kcp",
        "ws",
        "httpupgrade",
        "xhttp",
        "h2",
        "quic",
        "grpc",
        "hysteria"
    };

    /// <summary>
    ///     V2Ray 伪装类型
    /// </summary>
    public static readonly List<string> FakeTypes = new()
    {
        "none",
        "http",
        "srtp",
        "utp",
        "wechat-video",
        "dtls",
        "wireguard",
        "dns",
        "auto",
        "packet-up",
        "stream-up",
        "stream-one",
        "gun",
        "multi"
    };
}


public static class ServerExtension
{
    public static async Task<string> AutoResolveHostnameAsync(this Server server, AddressFamily inet = AddressFamily.Unspecified)
    {
        // ! MainController cached
        return (await DnsUtils.LookupAsync(server.Hostname, inet))!.ToString();
    }

    public static bool IsInGroup(this Server server)
    {
        return server.Group is not Constants.DefaultGroup;
    }
}