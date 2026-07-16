namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the sing-box API service configuration.
/// </summary>
public sealed class ApiServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiServiceConfig"/> class.
    /// </summary>
    public ApiServiceConfig()
    {
        Type = "api";
    }

    /// <summary>
    /// Secret for the API.
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// CORS allowed origins.
    /// </summary>
    [JsonPropertyName("access_control_allow_origin")]
    public List<string>? AccessControlAllowOrigin { get; set; }

    /// <summary>
    /// Allow private network access to the API.
    /// </summary>
    [JsonPropertyName("access_control_allow_private_network")]
    public bool? AccessControlAllowPrivateNetwork { get; set; }

    /// <summary>
    /// Web dashboard configuration. Can be bool, string or object.
    /// </summary>
    [JsonPropertyName("dashboard")]
    public object? Dashboard { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }
}
