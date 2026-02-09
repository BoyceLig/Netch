using Netch.Models;
using Netch.Utils;
using System.Text.RegularExpressions;
using System.Web;

namespace Netch.Servers;

public static class V2rayUtils
{
    public static IEnumerable<Server> ParseVUri(string text)
    {
        var scheme = ShareLink.GetUriScheme(text).ToLower();
        var server = scheme switch { "vmess" => new VMessServer(), "vless" => new VLESSServer(), _ => throw new ArgumentOutOfRangeException() };
        if (text.Contains("#"))
        {
            server.Remark = Uri.UnescapeDataString(text.Split('#')[1]);
            text = text.Split('#')[0];
        }

        if (text.Contains("?"))
        {
            var parameter = HttpUtility.ParseQueryString(text.Split('?')[1]);
            text = text.Substring(0, text.IndexOf("?", StringComparison.Ordinal));
            server.Transport.TransferProtocol = parameter.Get("type") ?? "tcp";
            server.PacketEncoding = parameter.Get("packetEncoding") ?? "xudp";
            server.EncryptMethod = parameter.Get("encryption") ?? scheme switch { "vless" => "none", _ => "auto" };

            if (server is VLESSServer vlessServer)
            {
                vlessServer.Flow = parameter.Get("flow") ?? "";
            }

            switch (server.Transport.TransferProtocol)
            {
                case "tcp":
                    break;
                case "kcp":
                    server.Transport.FakeType = parameter.Get("headerType") ?? "none";
                    server.Transport.Path = Uri.UnescapeDataString(parameter.Get("seed") ?? "");
                    break;
                case "ws":
                    server.Transport.Path = Uri.UnescapeDataString(parameter.Get("path") ?? "/");
                    server.Transport.Host = Uri.UnescapeDataString(parameter.Get("host") ?? "");
                    break;
                case "h2":
                case "xhttp":
                    server.Transport.Path = Uri.UnescapeDataString(parameter.Get("path") ?? "/");
                    server.Transport.Host = Uri.UnescapeDataString(parameter.Get("host") ?? "");
                    break;
                case "quic":
                    server.Transport.Host = parameter.Get("quicSecurity") ?? "none";
                    server.Transport.Path = parameter.Get("key") ?? "";
                    server.Transport.FakeType = parameter.Get("headerType") ?? "none";
                    break;
                case "grpc":
                    server.Transport.FakeType = parameter.Get("mode") ?? "gun";
                    server.Transport.Path = parameter.Get("serviceName") ?? "";
                    break;
            }

            server.tlsConfig.TLSSecureType = parameter.Get("security") ?? "none";
            if (server.tlsConfig.TLSSecureType != "none")
            {
                server.tlsConfig.ServerName = parameter.Get("sni") ?? "";
                server.tlsConfig.Alpn = parameter.Get("alpn") ?? "";
                server.tlsConfig.EchConfigList = parameter.Get("ech") ?? "";
                server.tlsConfig.XHttpObject = parameter.Get("xhttpobject") ?? "";
                server.tlsConfig.Fingerprint = parameter.Get("fp") ?? "";
                server.tlsConfig.PublicKey = parameter.Get("pbk") ?? "";
                server.tlsConfig.ShortId = parameter.Get("sid") ?? "";
                server.tlsConfig.SpiderX = parameter.Get("spx") ?? "";
                server.tlsConfig.Mldsa65Verify = parameter.Get("pqv") ?? "";
            }
        }

        var finder = new Regex(@$"^{scheme}://(?<guid>.+?)@(?<server>.+):(?<port>\d+)");
        var match = finder.Match(text.Split('?')[0]);
        if (!match.Success)
            throw new FormatException();

        server.UserID = match.Groups["guid"].Value;
        server.Hostname = match.Groups["server"].Value;
        server.Port = ushort.Parse(match.Groups["port"].Value);

        return new[] { server };
    }

    public static string GetVShareLink(Server s, string scheme = "vmess")
    {
        // https://github.com/XTLS/Xray-core/issues/91
        var server = (VMessServer)s;
        var parameter = new Dictionary<string, string>();
        // protocol-specific fields
        parameter.Add("type", server.Transport.TransferProtocol);
        parameter.Add("encryption", server.EncryptMethod);
        parameter.Add("packetEncoding", server.PacketEncoding);

        // transport-specific fields
        switch (server.Transport.TransferProtocol)
        {
            case "tcp":
                break;
            case "kcp":
                if (server.Transport.FakeType != "none")
                    parameter.Add("headerType", server.Transport.FakeType);

                if (!server.Transport.Path.IsNullOrWhiteSpace())
                    parameter.Add("seed", Uri.EscapeDataString(server.Transport.Path!));

                break;
            case "ws":
            case "httpupgrade":
            case "h2":
            case "xhttp":
                parameter.Add("path", Uri.EscapeDataString(server.Transport.Path.ValueOrDefault() ?? "/"));
                if (!server.Transport.Host.IsNullOrWhiteSpace())
                    parameter.Add("host", Uri.EscapeDataString(server.Transport.Host!));

                break;
            case "quic":
                if (server.Transport.Host is not (null or "none"))
                {
                    parameter.Add("quicSecurity", server.Transport.Host);
                    parameter.Add("key", server.Transport.Path!);
                }

                if (server.Transport.FakeType != "none")
                    parameter.Add("headerType", server.Transport.FakeType);

                break;
            case "grpc":
                if (!string.IsNullOrEmpty(server.Transport.Path))
                    parameter.Add("serviceName", server.Transport.Path);

                if (server.Transport.FakeType is "gun" or "multi")
                    parameter.Add("mode", server.Transport.FakeType);

                break;
        }

        if (server.tlsConfig.TLSSecureType != "none")
        {
            parameter.Add("security", server.tlsConfig.TLSSecureType);

            if (!server.Transport.Host.IsNullOrWhiteSpace())
                parameter.Add("sni", server.Transport.Host!);

            if (server.tlsConfig.TLSSecureType == "xtls")
            {
                parameter.Add("flow", "xtls-rprx-direct");
            }
            if (server.tlsConfig.allowInsecure != null)
            {
                parameter.Add("allowInsecure", server.tlsConfig.allowInsecure.ToString()!);
            }
            if (!string.IsNullOrEmpty(server.tlsConfig.Fingerprint))
            {
                parameter.Add("fp", server.tlsConfig.Fingerprint);
            }
            if (!string.IsNullOrEmpty(server.tlsConfig.Alpn))
            {
                parameter.Add("alpn", server.tlsConfig.Alpn);
            }
            if (!string.IsNullOrEmpty(server.tlsConfig.EchConfigList))
            {
                parameter.Add("ech", server.tlsConfig.EchConfigList);
            }
            
            //realitySettings
            if (!string.IsNullOrEmpty(server.tlsConfig.PublicKey))
            {
                parameter.Add("pbk", server.tlsConfig.PublicKey);
            }
            if (!string.IsNullOrEmpty(server.tlsConfig.ShortId))
            {
                parameter.Add("sid", server.tlsConfig.ShortId);
            }
            if (!string.IsNullOrEmpty(server.tlsConfig.SpiderX))
            {
                parameter.Add("spx", server.tlsConfig.SpiderX);
            }
            if (!string.IsNullOrEmpty(server.tlsConfig.Mldsa65Verify))
            {
                parameter.Add("pqv", server.tlsConfig.Mldsa65Verify);
            }
        }

        return
            $"{scheme}://{server.UserID}@{server.Hostname}:{server.Port}?{string.Join("&", parameter.Select(p => $"{p.Key}={p.Value}"))}{(!server.Remark.IsNullOrWhiteSpace() ? $"#{Uri.EscapeDataString(server.Remark)}" : "")}";
    }
}