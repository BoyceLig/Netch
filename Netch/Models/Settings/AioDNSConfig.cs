namespace Netch.Models;

public class AioDNSConfig
{
    public string ChinaDNS { get; set; } = $"tcp://{Constants.DefaultCNPrimaryDNS}:53";

    public string OtherDNS { get; set; } = $"tcp://{Constants.DefaultPrimaryDNS}:53";
}