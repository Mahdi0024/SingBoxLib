namespace SingBoxLib.Configuration.Outbound.Shared;

/// <summary>
/// Represents Reality outbound configuration.
/// </summary>
public sealed class OutboundRealityConfig
{
    /// <summary>
    /// Gets or sets whether Reality is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the public key.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string? PublicKey { get; set; }

    /// <summary>
    /// Gets or sets the short ID.
    /// </summary>
    [JsonPropertyName("short_id")]
    public string? ShortId { get; set; }
}