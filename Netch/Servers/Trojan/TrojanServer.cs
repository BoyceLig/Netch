using Netch.Models;

namespace Netch.Servers;

public class TrojanServer : Server
{
    public override string Type { get; } = "Trojan";

    public override string MaskedData()
    {
        return "";
    }

    /// <summary>
    ///     密码
    /// </summary>
    public string Password { get; set; } = string.Empty;

    public string Flow { get; set; } = VLESSGlobal.Flow[0];

    public TransportConfig Transport { get; set; } = new();
}