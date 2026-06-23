namespace SingBoxLib.Configuration.Outbound.Shared;

/// <summary>
/// Represents Encrypted Client Hello (ECH) outbound configuration.
/// </summary>
public sealed class OutboundEchConfig
{
    /// <summary>
    /// Gets or sets whether ECH is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the ECH configuration string.
    /// </summary>
    [JsonPropertyName("config")]
    public string? Config { get; set; }
}