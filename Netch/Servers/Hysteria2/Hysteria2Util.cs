using Netch.Interfaces;
using Netch.Models;
using Netch.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Web;

namespace Netch.Servers;
//https://v2.hysteria.network/zh/docs/developers/URI-Scheme/
public class Hysteria2Util : IServerUtil
{
    public ushort Priority { get; } = 3;

    public string TypeName { get; } = "Hysteria2";

    public string FullName { get; } = "Hysteria2";

    public string ShortName { get; } = "HY2";

    public string[] UriScheme { get; } = { "hysteria2" };

    public Type ServerType { get; } = typeof(Hysteria2Server);

    public void Edit(Server s)
    {
        new Hysteria2Form((Hysteria2Server)s).ShowDialog();
    }

    public void Create()
    {
        new Hysteria2Form().ShowDialog();
    }

    //hysteria2://letmein@example.com:123,5000-6000/?insecure=1&obfs=salamander&obfs-password=gawrgura&pinSHA256=deadbeef&sni=real.example.com
    //hysteria2://[auth@]hostname[:port]/?[key=value]&[key=value]...
    public string GetShareLink(Server s)
    {

        var server = (Hysteria2Server)s;
        var parameter = new Dictionary<string, string>();
        var portHoppingRange = server.PortHoppingRange;

        parameter.Add("insecure", server.tlsConfig.allowInsecure.GetValueOrDefault() ? "1" : "0");
        parameter.Add("obfs", server.Obfs);
        if (!string.IsNullOrEmpty(server.ObfsPassword))
        {
            parameter.Add("obfs-password", server.ObfsPassword);
        }
        if (!string.IsNullOrEmpty(server.tlsConfig.PinSHA256))
        {
            parameter.Add("pinSHA256", server.tlsConfig.PinSHA256);
        }
        if (!string.IsNullOrEmpty(server.tlsConfig.ServerName))
        {
            parameter.Add("sni", server.tlsConfig.ServerName);
        }

        return $"hysteria2://{server.Auth}@{server.Hostname}:{server.Port}{(string.IsNullOrEmpty(server.PortHoppingRange) ? string.Empty : "," + server.PortHoppingRange)}/?" +
            $"{string.Join("&", parameter.Select(s => $"{s.Key}={s.Value}"))}" +
            $"{(!server.Remark.IsNullOrWhiteSpace() ? $"#{Uri.EscapeDataString(server.Remark)}" : string.Empty)}";
    }

    public IServerController GetController()
    {
        return new V2rayController();
    }

    public IEnumerable<Server> ParseUri(string text)
    {
        var server = new Hysteria2Server();

        if (text.Contains("#"))
        {
            server.Remark = Uri.UnescapeDataString(text.Split('#')[1]);
            text = text.Split('#')[0];
        }

        if (text.Contains("?"))
        {
            var parameter = HttpUtility.ParseQueryString(text.Split('?')[1]);
            text = text.Substring(0, text.IndexOf("?", StringComparison.Ordinal));
            server.tlsConfig.TLSSecureType = TLSGlobe.TLSSecure[1];
            server.tlsConfig.allowInsecure = parameter.Get("insecure") == "1" ? true : false;
            server.Obfs = parameter.Get("obfs") ?? Hysteria2Globe.Obfs[0];
            server.ObfsPassword = parameter.Get("obfs-password") ?? string.Empty;
            server.tlsConfig.PinSHA256 = parameter.Get("pinSHA256");
            server.tlsConfig.ServerName = parameter.Get("sni");
            server.PortHoppingRange = parameter.Get("mport") ?? string.Empty;
        }

        var finder = new Regex(@$"^hysteria2://(?<guid>.+?)@(?<server>.+):(?<port>\d+)");
        var match = finder.Match(text.Split('?')[0]);
        if (!match.Success)
            throw new FormatException();

        server.Auth = match.Groups["guid"].Value;
        server.Hostname = match.Groups["server"].Value;
        server.Port = ushort.Parse(match.Groups["port"].Value);

        return new[] { server };

    }

    public bool CheckServer(Server s)
    {
        return true;
    }
}