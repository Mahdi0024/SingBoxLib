namespace SingBoxLib.Runtime.Api.Clash.Models;

public class ProxyDelayInfo
{
    [JsonPropertyName("delay")]
    public int Delay { get; set; }

    public bool Success { get; set; }
}