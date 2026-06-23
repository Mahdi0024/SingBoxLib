namespace SingBoxLib.Configuration.Inbound.Shared;

/// <summary>
/// Represents Encrypted Client Hello (ECH) inbound configuration.
/// </summary>
public sealed class InboundEchConfig
{
    /// <summary>
    /// Gets or sets whether ECH is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the list of ECH keys.
    /// </summary>
    [JsonPropertyName("key")]
    public List<string>? Key { get; set; }

    /// <summary>
    /// Gets or sets the path to the ECH key.
    /// </summary>
    [JsonPropertyName("key_path")]
    public string? KeyPath { get; set; }
}
