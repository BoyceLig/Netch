using Netch.Enums;
using Netch.Interfaces;
using Netch.Models;

namespace Netch.Servers;

public class HttpUtil : IServerUtil
{
    public ushort Priority { get; } = 1;

    public string TypeName { get; } = EConfigType.HTTP.ToString();

    public string FullName { get; } = EConfigType.HTTP.ToString();

    public string ShortName { get; } = "HT";

    public string[] UriScheme { get; } = { Constants.ProtocolTypes[EConfigType.HTTP] };

    public Type ServerType { get; } = typeof(HttpServer);

    public void Edit(Server s)
    {
        new HttpForm((HttpServer)s).ShowDialog();
    }

    public void Create()
    {
        new HttpForm().ShowDialog();
    }

    public string GetShareLink(Server s)
    {
        return string.Empty;
    }

    public IServerController GetController()
    {
        return new SocksController();
    }

    public IEnumerable<Server> ParseUri(string text)
    {
        return null;
    }

    public bool CheckServer(Server s)
    {
        return true;
    }
}