namespace Netch.Servers;

public class VLESSServer : VMessServer
{
    public override string Type { get; } = "VLESS";

    /// <summary>
    ///     加密方式
    /// </summary>
    public override string EncryptMethod { get; set; } = "none";

    /// <summary>
    /// 流控 Flow
    /// </summary>
    public string Flow { get; set; } = VLESSGlobal.Flow[0];
}

public class VLESSGlobal
{
    /// <summary>
    /// VLESS 流控（Flow）
    /// </summary>
    public static readonly List<string> Flow = new()
    {
        "",
        "xtls-rprx-direct",
        "xtls-rprx-vision",
        "xtls-rprx-vision-udp443",
    };
}