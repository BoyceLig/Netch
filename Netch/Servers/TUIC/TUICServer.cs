using Netch.Enums;

namespace Netch.Servers;

public class TUICServer : VMessServer
{
    public override EConfigType ConfigType { get; } = EConfigType.TUIC;
}