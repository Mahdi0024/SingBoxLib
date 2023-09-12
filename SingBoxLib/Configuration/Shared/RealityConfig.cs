namespace SingBoxLib.Configuration.Shared;

public sealed class RealityConfig
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("public_key")]
    public string? PublicKey { get; set; }

    [JsonProperty("short_id")]
    public string? ShortId { get; set; }
}