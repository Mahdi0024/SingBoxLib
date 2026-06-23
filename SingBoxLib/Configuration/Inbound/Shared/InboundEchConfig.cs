namespace SingBoxLib.Configuration.Inbound.Shared;

/// <summary>
/// Represents Encrypted Client Hello (ECH) inbound configuration.
/// </summary>
public sealed class InboundEchConfig
{
    /// <summary>
    /// Gets or sets whether ECH is enabled.
    /// </summary>
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the list of ECH keys.
    /// </summary>
    [JsonProperty("key")]
    public List<string>? Key { get; set; }

    /// <summary>
    /// Gets or sets the path to the ECH key.
    /// </summary>
    [JsonProperty("key_path")]
    public string? KeyPath { get; set; }
}
