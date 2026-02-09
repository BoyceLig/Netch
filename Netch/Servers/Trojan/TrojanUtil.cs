using System.Text.RegularExpressions;
using System.Web;
using Netch.Interfaces;
using Netch.Models;
using Netch.Utils;

namespace Netch.Servers;

public class TrojanUtil : IServerUtil
{
    public ushort Priority { get; } = 3;

    public string TypeName { get; } = "Trojan";

    public string FullName { get; } = "Trojan";

    public string ShortName { get; } = "TR";

    public string[] UriScheme { get; } = { "trojan" };

    public Type ServerType { get; } = typeof(TrojanServer);

    public void Edit(Server s)
    {
        new TrojanForm((TrojanServer)s).ShowDialog();
    }

    public void Create()
    {
        new TrojanForm().ShowDialog();
    }

    public string GetShareLink(Server s)
    {
        var server = (TrojanServer)s;
        return $"trojan://{HttpUtility.UrlEncode(server.Password)}@{server.Hostname}:{server.Port}?sni={server.Transport.Host}#{server.Remark}";
    }

    public IServerController GetController()
    {
        return new TrojanController();
    }

    public IEnumerable<Server> ParseUri(string text)
    {
        var data = new TrojanServer();
        var url = new Uri(text);
        data.Password = url.UserInfo;
        data.Hostname = url.Host;
        data.Port = (ushort)url.Port;
        data.Remark = HttpUtility.UrlDecode(url.Fragment.TrimStart('#'));

        if (text.Contains("?"))
        {
            var parameter = HttpUtility.ParseQueryString(url.Query);


            var peer = HttpUtility.UrlDecode(parameter.Get("peer"));

            if (!peer.IsNullOrWhiteSpace())
            {
                data.Transport.Host = peer;
            }
            var sni = HttpUtility.UrlDecode(parameter.Get("sni"));
            if (!sni.IsNullOrWhiteSpace())
            {
                data.tlsConfig.ServerName = sni;
                data.tlsConfig.TLSSecureType = TLSGlobe.TLSSecure[1];
            }
            var allowInsecure = parameter.Get("allowInsecure");
            data.tlsConfig.allowInsecure = allowInsecure switch
            {
                "0" => false,
                "1" => true,
                _ => null
            };

        }
        return new[] { data };
    }

    public bool CheckServer(Server s)
    {
        return true;
    }
}