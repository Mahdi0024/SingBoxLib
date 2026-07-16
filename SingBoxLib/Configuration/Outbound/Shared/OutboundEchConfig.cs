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

    /// <summary>
    /// The path to ECH configuration, in PEM format.
    /// </summary>
    [JsonPropertyName("config_path")]
    public string? ConfigPath { get; set; }

    /// <summary>
    /// Overrides the domain name used for ECH HTTPS record queries.
    /// </summary>
    [JsonPropertyName("query_server_name")]
    public string? QueryServerName { get; set; }
}