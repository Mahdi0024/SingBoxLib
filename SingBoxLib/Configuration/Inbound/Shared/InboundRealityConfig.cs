namespace SingBoxLib.Configuration.Inbound.Shared;

public class InboundRealityConfig
{
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("handshake")]
    public HandshakeConfig? Handshake { get; set; }

    [JsonProperty("private_key")]
    public string? PrivateKey { get; set; }

    [JsonProperty("short_id")]
    public List<string>? ShortId { get; set; }

    [JsonProperty("max_time_difference")]
    public string? MaxTimeDifference { get; set; }
}
