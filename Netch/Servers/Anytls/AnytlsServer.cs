using Netch.Enums;

namespace Netch.Servers;

public class AnytlsServer : VMessServer
{
    public override EConfigType ConfigType { get; } = EConfigType.Anytls;
}