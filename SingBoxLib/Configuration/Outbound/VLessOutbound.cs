namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a VLess outbound.
/// </summary>
public sealed class VLessOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VLessOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public VLessOutbound(string? tag = null)
    {
        Type = "vless";
        Tag = tag ?? "vless-out";
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
    /// The VMess user id.
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    /// <summary>
    /// VLESS Sub-protocol.
    /// Available values: xtls-rprx-vision.
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public OutboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// UDP packet encoding, xudp is used by default.
    /// One of: packetaddr or xudp.
    /// </summary>
    [JsonPropertyName("packet_encoding")]
    public string? PacketEncoding { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonPropertyName("transport")]
    public TransportConfig? Transport { get; set; }

    /// <summary>
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/multiplex#outbound">Multiplex</see> for details.
    /// </summary>
    [JsonPropertyName("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}