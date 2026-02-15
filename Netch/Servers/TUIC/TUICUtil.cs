using Netch.Enums;
using Netch.Interfaces;
using Netch.Models;
using Netch.Services;

namespace Netch.Servers;

public class TUICUtil : ServerUtilBase, IServerUtil
{
    public ushort Priority { get; } = 8;

    public string TypeName { get; } = EConfigType.TUIC.ToString();

    public string FullName { get; } = EConfigType.TUIC.ToString();

    public string ShortName { get; } = "TU";

    public string[] UriScheme { get; } = { Constants.ProtocolTypes[EConfigType.TUIC] };

    public Type ServerType { get; } = typeof(TUICServer);

    public void Edit(Server s)
    {
        new TUICForm((TUICServer)s).ShowDialog();
    }

    public void Create()
    {
        new TUICForm().ShowDialog();
    }

    public string GetShareLink(Server s)
    {

        var item = (TUICServer)s;

        if (item == null)
        {
            return null;
        }

        var remark = string.Empty;
        if (item.Remarks.IsNotEmpty())
        {
            remark = "#" + Utils.Utils.UrlEncode(item.Remarks);
        }

        var dicQuery = new Dictionary<string, string>();
        ToUriQueryLite(item, ref dicQuery);

        dicQuery.Add("congestion_control", item.HeaderType);

        return ToUri(EConfigType.TUIC, item.Address, item.Port, $"{item.Username ?? ""}:{item.Password}", dicQuery, remark);
    }

    public IServerController GetController()
    {
        return new SingboxController();
    }

    public IEnumerable<Server> ParseUri(string str)
    {
        var parsedUrl = Utils.Utils.TryUri(str);
        TUICServer item = new();

        var url = Utils.Utils.TryUri(str);
        if (url == null)
        {
            return null;
        }

        item.Address = url.IdnHost;
        item.Port = url.Port;
        item.Remarks = url.GetComponents(UriComponents.Fragment, UriFormat.Unescaped);
        var rawUserInfo = Utils.Utils.UrlDecode(url.UserInfo);
        var userInfoParts = rawUserInfo.Split(new[] { ':' }, 2);
        if (userInfoParts.Length == 2)
        {
            item.Username = userInfoParts.First();
            item.Password = userInfoParts.Last();
        }

        var query = Utils.Utils.ParseQueryString(url.Query);
        ResolveUriQuery(query, ref item);
        item.HeaderType = GetQueryValue(query, "congestion_control");

        return [item];
    }

    public bool CheckServer(Server s)
    {
        return true;
    }
}