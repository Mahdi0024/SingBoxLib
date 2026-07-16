namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the CCM (Claude Code Multiplexer) service configuration.
/// </summary>
public sealed class CcmServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CcmServiceConfig"/> class.
    /// </summary>
    public CcmServiceConfig()
    {
        Type = "ccm";
    }

    /// <summary>
    /// Path to the Claude Code OAuth credentials file.
    /// </summary>
    [JsonPropertyName("credential_path")]
    public string? CredentialPath { get; set; }

    /// <summary>
    /// Path to the file for storing aggregated API usage statistics.
    /// </summary>
    [JsonPropertyName("usages_path")]
    public string? UsagesPath { get; set; }

    /// <summary>
    /// List of authorized users.
    /// </summary>
    [JsonPropertyName("users")]
    public List<CcmUser>? Users { get; set; }

    /// <summary>
    /// Custom HTTP headers to send to the Claude API.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }
}
