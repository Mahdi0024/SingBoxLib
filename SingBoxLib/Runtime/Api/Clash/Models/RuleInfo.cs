namespace SingBoxLib.Runtime.Api.Clash.Models;

public class RuleInfo
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("payload")]
    public string Payload { get; set; } = null!;

    [JsonPropertyName("proxy")]
    public string Proxy { get; set; } = null!;
}