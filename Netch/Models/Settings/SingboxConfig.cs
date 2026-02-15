namespace Netch.Models;

public class SingboxConfig
{
    public Mux4SboxItem Mux4SboxItem { get; set; } = new();
}

[Serializable]
public class Mux4SboxItem
{
    public string Protocol { get; set; } = Constants.SingboxMuxs.First();
    public int MaxConnections { get; set; } = 8;
    public bool? Padding { get; set; }
}