namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the SSM API service configuration.
/// </summary>
public sealed class SsmApiServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SsmApiServiceConfig"/> class.
    /// </summary>
    public SsmApiServiceConfig()
    {
        Type = "ssm-api";
    }

    /// <summary>
    /// A mapping from HTTP endpoints to Shadowsocks Inbound tags.
    /// </summary>
    [JsonPropertyName("servers")]
    public Dictionary<string, string>? Servers { get; set; }

    /// <summary>
    /// Traffic and user state cache file path.
    /// </summary>
    [JsonPropertyName("cache_path")]
    public string? CachePath { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }
}
