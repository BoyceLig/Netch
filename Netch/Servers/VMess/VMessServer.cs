using Netch.Models;

namespace Netch.Servers;

public class VMessServer : Server
{
    public override string Type { get; } = "VMess";

    public override string MaskedData()
    {
        var maskedData = $"{EncryptMethod} + {Transport.TransferProtocol} + {PacketEncoding} + {Transport.FakeType}";
        switch (Transport.TransferProtocol)
        {
            case "tcp":
            case "ws":
                maskedData += $" + {tlsConfig.TLSSecureType}";
                break;
            case "quic":
                maskedData += $" + {Transport.Host}";
                break;
            case "grpc":
                break;
            case "kcp":
                break;
        }

        return maskedData;
    }
    public TransportConfig Transport { get; set; } = new();

    /// <summary>
    ///     用户 ID
    /// </summary>
    public string UserID { get; set; } = string.Empty;

    /// <summary>
    ///     额外 ID
    /// </summary>
    public int AlterID { get; set; }

    /// <summary>
    ///     加密方式
    /// </summary>
    public virtual string EncryptMethod { get; set; } = VMessGlobal.EncryptMethods[0];

    /// <summary>
    ///     包传输格式
    /// </summary>
    public virtual string PacketEncoding { get; set; } = VMessGlobal.PacketEncodings[2];

    /// <summary>
    ///     Mux 多路复用
    /// </summary>
    public bool? UseMux { get; set; }
}


public class VMessGlobal
{
    public static readonly List<string> UseMux = new()
    {
        "",
        "true",
        "false",
    };
    public static readonly List<string> EncryptMethods = new()
    {
        "auto",
        "none",
        "aes-128-gcm",
        "chacha20-poly1305",
        "zero"
    };

    public static readonly List<string> PacketEncodings = new()
    {
        "none",
        "packet", // requires v2fly/v2ray-core v5.0.2+ or SagerNet/v2ray-core
        "xudp" // requires XTLS/Xray-core or SagerNet/v2ray-core
    };
}