namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the Hysteria Realm service configuration.
/// </summary>
public sealed class HysteriaRealmServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HysteriaRealmServiceConfig"/> class.
    /// </summary>
    public HysteriaRealmServiceConfig()
    {
        Type = "hysteria-realm";
    }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// Authorized users.
    /// </summary>
    [JsonPropertyName("users")]
    public List<HysteriaRealmUser>? Users { get; set; }
}
