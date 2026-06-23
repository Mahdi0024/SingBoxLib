namespace SingBoxLib.Configuration.Inbound.Shared;

/// <summary>
/// Represents Reality inbound configuration.
/// </summary>
public sealed class InboundRealityConfig
{
    /// <summary>
    /// Gets or sets whether Reality is enabled.
    /// </summary>
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the handshake configuration.
    /// </summary>
    [JsonProperty("handshake")]
    public HandshakeConfig? Handshake { get; set; }

    /// <summary>
    /// Gets or sets the private key.
    /// </summary>
    [JsonProperty("private_key")]
    public string? PrivateKey { get; set; }

    /// <summary>
    /// Gets or sets the list of short IDs.
    /// </summary>
    [JsonProperty("short_id")]
    public List<string>? ShortId { get; set; }

    /// <summary>
    /// Gets or sets the maximum allowed time difference.
    /// </summary>
    [JsonProperty("max_time_difference")]
    public string? MaxTimeDifference { get; set; }
}
