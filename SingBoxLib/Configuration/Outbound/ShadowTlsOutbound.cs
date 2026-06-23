namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a ShadowTls outbound.
/// </summary>
public sealed class ShadowTlsOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ShadowTlsOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public ShadowTlsOutbound(string? tag = null)
    {
        Type = "shadowtls";
        Tag = tag;
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonPropertyName("server")]
    public string? Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonPropertyName("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// ShadowTLS protocol version.
    /// 1 is used by default.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// ShadowTLS password.
    /// Only available in the ShadowTLS protocol 2.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}