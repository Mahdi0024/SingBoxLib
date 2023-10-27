namespace SingboxLib.Configuration.Outbound.Shared;

public sealed class OutboundRealityConfig
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("public_key")]
    public string? PublicKey { get; set; }

    [JsonProperty("short_id")]
    public string? ShortId { get; set; }
}