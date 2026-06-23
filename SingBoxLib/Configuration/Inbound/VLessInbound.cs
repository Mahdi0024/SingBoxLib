namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a VLESS inbound configuration.
/// </summary>
public sealed class VLessInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VLessInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public VLessInbound(string? tag = null)
    {
        Type = "vless";
        Tag = tag;
    }

    /// <summary>
    /// Gets or sets the list of users allowed to connect.
    /// </summary>
    [JsonPropertyName("users")]
    public List<VLessUser>? Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonPropertyName("transport")]
    public TransportConfig? Transport { get; set; }

    /// <summary>
    /// Multiplexing configuration for managing multiple streams over a single connection.
    /// </summary>
    [JsonPropertyName("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}

/// <summary>
/// Represents a user for the VLESS protocol.
/// </summary>
public sealed class VLessUser
{
    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the UUID.
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    /// <summary>
    /// VLESS Sub-protocol.
    /// Available values: "xtls-rprx-vision"
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }
}