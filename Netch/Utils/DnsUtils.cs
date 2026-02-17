using DnsClientX;
using Microsoft.VisualStudio.Threading;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace Netch.Utils;

public static class DnsUtils
{
    private static readonly AsyncSemaphore Lock = new(1);

    /// <summary>
    ///     缓存
    /// </summary>
    private static readonly Hashtable Cache = new();
    private static readonly Hashtable Cache6 = new();

    public static async Task<IPAddress?> LookupAsync(string hostname, AddressFamily inet = AddressFamily.Unspecified, int timeout = 3000, string? dns = null)
    {
        using var _ = await Lock.EnterAsync();
        if (IPAddress.TryParse(hostname, out var ip))
        {
            // AddressFamily 过滤
            if (inet == AddressFamily.Unspecified || ip.AddressFamily == inet)
                return ip;
        }

        try
        {
            var cacheResult = inet switch
            {
                AddressFamily.Unspecified => (IPAddress?)(Cache[hostname] ?? Cache6[hostname]),
                AddressFamily.InterNetwork => (IPAddress?)Cache[hostname],
                AddressFamily.InterNetworkV6 => (IPAddress?)Cache6[hostname],
                _ => throw new ArgumentOutOfRangeException()
            };

            if (cacheResult != null)
                return cacheResult;

            return await LookupNoCacheAsync(hostname, inet, timeout, Global.Settings.OutboundDNS_Enabled ? NormalizeDnsUri(dns) : null);
        }
        catch (Exception e)
        {
            Log.Verbose(e, "Lookup hostname {Hostname} failed", hostname);
            return null;
        }
    }

    private static async Task<IPAddress?> LookupNoCacheAsync(string hostname, AddressFamily inet = AddressFamily.Unspecified, int timeout = 3000, Uri dnsUri = null)
    {
        IPAddress[] addresses;
        var type = inet == AddressFamily.InterNetworkV6
            ? DnsRecordType.AAAA
            : DnsRecordType.A;
        if (dnsUri == null)
        {
            // 使用系统配置的 DNS 服务器（示例，需根据实际情况调整）
            var response = await ClientX.QueryDns(hostname, type, DnsEndpoint.System);
            addresses = response.Answers.Select(a => IPAddress.Parse(a.Data)).ToArray();
            //addresses = await Dns.GetHostAddressesAsync(hostname);
        }
        else
        {
            var scheme = dnsUri.Scheme;
            using var client = scheme.ToLowerInvariant() switch
            {
                // 🔹 DNS over TLS
                "tls" => new ClientXBuilder().WithBaseUri(dnsUri, DnsRequestFormat.DnsOverTLS).WithTimeout(timeout).Build(),

                // 🔹 DNS over HTTPS
                "https" => new ClientXBuilder()
                    .WithBaseUri(dnsUri, DnsRequestFormat.DnsOverHttps).WithTimeout(timeout).Build(),

                // 🔹 普通 UDP
                _ => new ClientXBuilder()
                    .WithBaseUri(dnsUri, DnsRequestFormat.DnsOverUDP).WithTimeout(timeout).Build()
            };
            var response = await client.Resolve(hostname, type);
            addresses = response?.Answers?
            .Where(a => IPAddress.TryParse(a.Data?.ToString(), out _))
            .Select(a => IPAddress.Parse(a.Data.ToString()))
            .ToArray()
            ?? Array.Empty<IPAddress>();

        }

        var result = addresses.FirstOrDefault(i => inet == AddressFamily.Unspecified || i.AddressFamily == inet);

        if (result == null) return null;

        switch (result.AddressFamily)
        {
            case AddressFamily.InterNetwork:
                Cache.Add(hostname, result);
                break;
            case AddressFamily.InterNetworkV6:
                Cache6.Add(hostname, result);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return result;
    }

    public static void ClearCache()
    {
        Cache.Clear();
        Cache6.Clear();
    }

    public static string AppendPort(string host, ushort port = 53)
    {
        if (!host.Contains(':'))
            return host + $":{port}";

        return host;
    }

    /// <summary>
    /// 缓存当前拆分好的DNS数据，避免重复拆分（如用户输入的DNS地址没有变化，则直接使用缓存数据，提升性能）
    /// </summary>
    private static (string dnsAddress, IPAddress ip, int port, string scheme) _dnsInfo = (string.Empty, null, 53, string.Empty);

    /// <summary>
    /// 纯IPAddress+字符串操作拆分IP:端口（支持带/不带协议前缀，如tls://112.74.48.57:10853）
    /// </summary>
    /// <param name="address">待拆分地址（如tls://112.74.48.57:10853 或 112.74.48.57:10853）</param>
    /// <returns>ip:拆分好的ipAddress，port：拆分好的端口号，isTlsScheme：是否是tls开头</returns>
    public static (IPAddress ip, int port, string scheme) SplitIpPort(string address)
    {
        (IPAddress, int, string) nul = (null, 0, null);
        if (string.IsNullOrWhiteSpace(address))
        {
            Log.Error("Outbound DNS address is empty");
            return nul;
        }

        address = address.Trim();
        if (_dnsInfo.dnsAddress == address)
        {
            Log.Verbose($"使用缓存DNS数据IP:{_dnsInfo.ip.ToString()},Port：{_dnsInfo.port},Scheme is {_dnsInfo.scheme}");
            return (_dnsInfo.ip, _dnsInfo.port, _dnsInfo.scheme);
        }
        var orginAddress = address;

        if (!address.Contains("://"))
        {
            address = "udp://" + address; // 临时添加协议前缀，简化后续处理
        }



        var url = new Uri(address);
        //if (url == null) return nul;

        int port = url.Scheme switch
        {
            "tls" => 853,    // DoT 默认端口
            "https" => 443,  // DoH 默认端口
            "udp" or "dns" => 53, // 普通 DNS 默认端口
            _ => 53
        };

        var scheme = url.Scheme;
        var host = url.Host;
        port = url.Port == -1 ? port : url.Port;


        Log.Verbose($"当前解析 Outbound DNS 的IP：{host},port：{port},Scheme is {scheme}");
        if (!IPAddress.TryParse(host, out var ip))
        {
            return nul;
        }

        _dnsInfo = (orginAddress, ip, port, scheme);
        return (ip, port, scheme);
    }

    private static Uri NormalizeDnsUri(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            Log.Error("Outbound DNS address is empty");
            return null;
        }

        address = address.Trim();

        if (!address.Contains("://"))
        {
            address = "udp://" + address; // 直接的IP，作为udp协议
        }

        if (!Uri.TryCreate(address, UriKind.Absolute, out var uri))
            throw new ArgumentException($"Invalid DNS address: {address}");

        var builder = new UriBuilder(uri);

        if (builder.Scheme == "https")
        {
            if (string.IsNullOrEmpty(builder.Path) || builder.Path == "/")
            {
                builder.Path = "/dns-query";
            }
        }

        if (uri.Port == -1)
        {
            builder.Port = builder.Scheme.ToLowerInvariant() switch
            {
                "tls" => 853,    // DoT 默认端口
                "https" => 443,  // DoH 默认端口
                _ => 53, // 普通 DNS 默认端口

            };
        }
        return uri;
    }
}