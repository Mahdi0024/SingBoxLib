namespace SingBoxLib.Runtime.Api.Clash.Models;

public class ProxyInfo
{
    [JsonPropertyName("all")]
    public List<string>? All { get; set; }

    [JsonPropertyName("now")]
    public string? Now { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("history")]
    public IEnumerable<UrlTestInfo>? TestHistory { get; set; }
}

public class UrlTestInfo
{
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("delay")]
    public int Delay { get; set; }
}