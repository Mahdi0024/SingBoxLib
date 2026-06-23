namespace SingBoxLib.Configuration;

/// <summary>
/// Represents the root configuration of a sing-box instance.
/// </summary>
public sealed class SingBoxConfig
{
    /// <summary>
    /// Configuration for the logging service.
    /// </summary>
    [JsonPropertyName("log")]
    public LogConfig? Log { get; set; }

    /// <summary>
    /// Configuration for the DNS resolution service.
    /// </summary>
    [JsonPropertyName("dns")]
    public DnsConfig? Dns { get; set; }

    /// <summary>
    /// Configuration for the built-in NTP client.
    /// </summary>
    [JsonPropertyName("ntp")]
    public NtpConfig? Ntp { get; set; }

    /// <summary>
    /// List of endpoint configurations.
    /// </summary>
    [JsonPropertyName("endpoints")]
    public List<EndpointConfig>? Endpoints { get; set; }

    /// <summary>
    /// List of inbound connection configurations.
    /// </summary>
    [JsonPropertyName("inbounds")]
    public List<InboundConfig>? Inbounds { get; set; }

    /// <summary>
    /// List of outbound connection configurations.
    /// </summary>
    [JsonPropertyName("outbounds")]
    public List<OutboundConfig>? Outbounds { get; set; }

    /// <summary>
    /// Configuration for routing rules.
    /// </summary>
    [JsonPropertyName("route")]
    public RouteConfig? Route { get; set; }

    /// <summary>
    /// List of top-level HTTP client configurations.
    /// </summary>
    [JsonPropertyName("http_clients")]
    public List<object>? HttpClients { get; set; }

    /// <summary>
    /// List of top-level certificate provider configurations.
    /// </summary>
    [JsonPropertyName("certificate_providers")]
    public List<object>? CertificateProviders { get; set; }

    /// <summary>
    /// Configuration for experimental features.
    /// </summary>
    [JsonPropertyName("experimental")]
    public ExperimentalConfig? Experimental { get; set; }

    /// <summary>
    /// Serializes this configuration to a JSON string.
    /// </summary>
    public string ToJson()
    {
        return JsonSerializer.Serialize(this, SingBoxJsonContext.Default.SingBoxConfig);
    }
}