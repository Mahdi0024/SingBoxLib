namespace SingBoxLib.Runtime.Api.Clash.Models;

public class ProxyInfo
{
    [JsonProperty("all")]
    public List<string>? All { get; set; }

    [JsonProperty("now")]
    public string? Now { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; } = null!;

    [JsonProperty("history")]
    public IEnumerable<UrlTestInfo>? TestHistory { get; set; }
}

public class UrlTestInfo
{
    [JsonProperty("time")]
    public DateTime Time { get; set; }

    [JsonProperty("delay")]
    public int Delay { get; set; }
}