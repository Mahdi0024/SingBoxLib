namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a VMess inbound configuration.
/// </summary>
public sealed class VMessInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VMessInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public VMessInbound(string? tag = null)
    {
        Type = "vmess";
        Tag = tag;
    }
    /// <summary>
    /// VMess users.
    /// </summary>
    [JsonPropertyName("users")]
    public required List<VMessUser>? Users { get; set; }

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
}

/// <summary>
/// Represents a user for the VMess protocol.
/// </summary>
public sealed class VMessUser
{
    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the UUID.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// Legacy protocol support (VMess MD5 Authentication) is provided for compatibility purposes only, use of alterId > 1 is not recommended.
    /// </summary>
    [JsonPropertyName("alterId")]
    public int AlterId { get; set; }
}