using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Netch.Interfaces;
using Netch.Models;
using Netch.Utils;

namespace Netch.Servers;

public class VMessUtil : IServerUtil
{
    public ushort Priority { get; } = 3;

    public string TypeName { get; } = "VMess";

    public string FullName { get; } = "VMess";

    public string ShortName { get; } = "V2";

    public string[] UriScheme { get; } = { "vmess" };

    public Type ServerType { get; } = typeof(VMessServer);

    public void Edit(Server s)
    {
        new VMessForm((VMessServer)s).ShowDialog();
    }

    public void Create()
    {
        new VMessForm().ShowDialog();
    }

    public string GetShareLink(Server s)
    {
        if (Global.Settings.V2RayConfig.V2rayNShareLink)
        {
            var server = (VMessServer)s;

            var vmessJson = JsonSerializer.Serialize(new V2rayNJObject
            {
                v = 2,
                ps = server.Remark,
                add = server.Hostname,
                port = server.Port,
                scy = server.EncryptMethod,
                id = server.UserID,
                aid = server.AlterID,
                net = server.Transport.TransferProtocol,
                type = server.Transport.FakeType,
                host = server.Transport.Host ?? "",
                path = server.Transport.Path ?? "",
                tls = server.tlsConfig.TLSSecureType,
                sni = server.tlsConfig.ServerName ?? ""
            },
                new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

            return "vmess://" + ShareLink.URLSafeBase64Encode(vmessJson);
        }

        return V2rayUtils.GetVShareLink(s);
    }

    public IServerController GetController()
    {
        return new V2rayController();
    }

    public IEnumerable<Server> ParseUri(string text)
    {
        var data = new VMessServer();

        string s;
        try
        {
            s = ShareLink.URLSafeBase64Decode(text.Substring(8));
        }
        catch
        {
            return V2rayUtils.ParseVUri(text);
        }

        V2rayNJObject vmessJS = JsonSerializer.Deserialize<V2rayNJObject>(s,
            new JsonSerializerOptions { NumberHandling = JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString })!;

        data.Remark = vmessJS.ps;
        data.Hostname = vmessJS.add;
        data.EncryptMethod = vmessJS.scy;
        data.Port = vmessJS.port;
        data.UserID = vmessJS.id;
        data.AlterID = vmessJS.aid;
        data.Transport.TransferProtocol = vmessJS.net;
        data.Transport.FakeType = vmessJS.type;
        data.tlsConfig.ServerName = vmessJS.sni;

        data.Transport.Host = vmessJS.host;
        data.Transport.Path = vmessJS.path;

        data.tlsConfig.TLSSecureType = vmessJS.tls;

        return new[] { data };
    }

    public bool CheckServer(Server s)
    {
        return true;
    }
}