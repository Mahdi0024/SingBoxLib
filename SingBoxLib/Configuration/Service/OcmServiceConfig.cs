namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the OCM (OpenAI Codex Multiplexer) service configuration.
/// </summary>
public sealed class OcmServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OcmServiceConfig"/> class.
    /// </summary>
    public OcmServiceConfig()
    {
        Type = "ocm";
    }

    /// <summary>
    /// Path to the OpenAI OAuth credentials file.
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
    public List<OcmUser>? Users { get; set; }

    /// <summary>
    /// Custom HTTP headers to send to the OpenAI API.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }
}
