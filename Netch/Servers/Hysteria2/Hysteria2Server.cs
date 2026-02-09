using Netch.Models;

namespace Netch.Servers;

public class Hysteria2Server : Server
{
    public override string Type { get; } = "Hysteria2";

    public override string MaskedData()
    {
        return "";
    }

    /// <summary>
    /// 密码
    /// </summary>
    public string Auth { get; set; } = string.Empty;

    /// <summary>
    /// 混淆类型,目前只支持 salamander
    /// </summary>
    public string Obfs { get; set; } = Hysteria2Globe.Obfs[0];

    /// <summary>
    /// 混合密码
    /// </summary>
    public string ObfsPassword { get; set; } = string.Empty;

    /// <summary>
    /// 跳跃端口范围
    /// </summary>
    public string PortHoppingRange { get; set; } = string.Empty;
}

public class Hysteria2Globe
{
    public static readonly List<string> Obfs = new()
    {
        "salamander",
    };
}
