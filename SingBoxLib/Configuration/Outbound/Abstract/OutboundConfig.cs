namespace SingBoxLib.Configuration.Outbound.Abstract;

public abstract class OutboundConfig
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("tag")]
    public string? Tag { get; set; }
}