namespace SingBoxLib.Configuration;

/// <summary>
/// Represents the root configuration of a sing-box instance.
/// </summary>
public sealed class SingBoxConfig
{
    /// <summary>
    /// Configuration for the logging service.
    /// </summary>
    [JsonProperty("log")]
    public LogConfig? Log { get; set; }

    /// <summary>
    /// Configuration for the DNS resolution service.
    /// </summary>
    [JsonProperty("dns")]
    public DnsConfig? Dns { get; set; }

    /// <summary>
    /// Configuration for the built-in NTP client.
    /// </summary>
    [JsonProperty("ntp")]
    public NtpConfig? Ntp { get; set; }

    /// <summary>
    /// List of endpoint configurations.
    /// </summary>
    [JsonProperty("endpoints")]
    public List<EndpointConfig>? Endpoints { get; set; }

    /// <summary>
    /// List of inbound connection configurations.
    /// </summary>
    [JsonProperty("inbounds")]
    public List<InboundConfig>? Inbounds { get; set; }

    /// <summary>
    /// List of outbound connection configurations.
    /// </summary>
    [JsonProperty("outbounds")]
    public List<OutboundConfig>? Outbounds { get; set; }

    /// <summary>
    /// Configuration for routing rules.
    /// </summary>
    [JsonProperty("route")]
    public RouteConfig? Route { get; set; }

    /// <summary>
    /// List of top-level HTTP client configurations.
    /// </summary>
    [JsonProperty("http_clients")]
    public List<object>? HttpClients { get; set; }

    /// <summary>
    /// List of top-level certificate provider configurations.
    /// </summary>
    [JsonProperty("certificate_providers")]
    public List<object>? CertificateProviders { get; set; }

    /// <summary>
    /// Configuration for experimental features.
    /// </summary>
    [JsonProperty("experimental")]
    public ExperimentalConfig? Experimental { get; set; }

    private static JsonSerializerSettings _serializerSettings = new() { NullValueHandling = NullValueHandling.Ignore };

    /// <summary>
    /// Serializes this configuration to a JSON string.
    /// </summary>
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, _serializerSettings);
    }
}