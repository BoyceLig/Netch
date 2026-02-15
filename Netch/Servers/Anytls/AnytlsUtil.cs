using Netch.Enums;
using Netch.Interfaces;
using Netch.Models;
using Netch.Services;
using Netch.Utils;

namespace Netch.Servers;

public class AnytlsUtil : ServerUtilBase, IServerUtil
{
    public ushort Priority { get; } = 7;

    public string TypeName { get; } = EConfigType.Anytls.ToString();

    public string FullName { get; } = EConfigType.Anytls.ToString();

    public string ShortName { get; } = "AT";

    public string[] UriScheme { get; } = { Constants.ProtocolTypes[EConfigType.Anytls] };

    public Type ServerType { get; } = typeof(AnytlsServer);

    public void Edit(Server s)
    {
        new AnytlsForm((AnytlsServer)s).ShowDialog();
    }

    public void Create()
    {
        new AnytlsForm().ShowDialog();
    }

    public string GetShareLink(Server s)
    {

        var item = (AnytlsServer)s;

        if (item == null)
        {
            return null;
        }
        var remark = string.Empty;
        if (item.Remarks.IsNotEmpty())
        {
            remark = "#" + Utils.Utils.UrlEncode(item.Remarks);
        }
        var pw = item.Password;
        var dicQuery = new Dictionary<string, string>();
        ToUriQuery(item, Constants.None, ref dicQuery);

        return ToUri(EConfigType.Anytls, item.Address, item.Port, pw, dicQuery, remark);
    }

    public IServerController GetController()
    {
        return new SingboxController();
    }

    public IEnumerable<Server> ParseUri(string str)
    {
        var parsedUrl = Utils.Utils.TryUri(str);
        if (parsedUrl == null)
        {
            return null;
        }

        AnytlsServer item = new()
        {
            Remarks = parsedUrl.GetComponents(UriComponents.Fragment, UriFormat.Unescaped),
            Address = parsedUrl.IdnHost,
            Port = parsedUrl.Port,
        };
        var rawUserInfo = Utils.Utils.UrlDecode(parsedUrl.UserInfo);
        item.Password = rawUserInfo;

        var query = Utils.Utils.ParseQueryString(parsedUrl.Query);
        ResolveUriQuery(query, ref item);
        if (item.StreamSecurity.IsNullOrEmpty())
        {
            item.StreamSecurity = Constants.StreamSecurity;
        }
        return [item];
    }

    public bool CheckServer(Server s)
    {
        return true;
    }
}