namespace SingBoxLib.Runtime.Api.Clash.Models;

public class RuleInfo
{
    [JsonProperty("type")]
    public string Type { get; set; } = null!;

    [JsonProperty("payload")]
    public string Payload { get; set; } = null!;

    [JsonProperty("proxy")]
    public string Proxy { get; set; } = null!;
}