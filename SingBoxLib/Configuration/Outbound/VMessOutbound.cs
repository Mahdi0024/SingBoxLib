namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a VLess outbound.
/// </summary>
public sealed class VMessOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VMessOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public VMessOutbound(string? tag = null)
    {
        Type = "vmess";
        Tag = tag;
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonPropertyName("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonPropertyName("server_port")]
    public required int ServerPort { get; set; }

    /// <summary>
    /// The VMess user id.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// See <see cref="VMessSecurity"/>.
    /// </summary>
    [JsonPropertyName("security")]
    public string? Security { get; set; }

    /// <summary>
    /// 0:	Use AEAD protocol.
    /// 1:	Use legacy protocol.
    /// >1: Unused, same as 1.
    /// </summary>
    [JsonPropertyName("alter_id")]
    public int? AlterId { get; set; }

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
    /// UDP packet encoding.
    /// packetaddr or xudp.
    /// Leave empty to disable.
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
/// <summary>
/// Constants representing VMess security methods.
/// </summary>
public static class VMessSecurity
{
    /// <summary>
    /// Auto encryption selector.
    /// </summary>
    public static readonly string Auto = "auto";

    /// <summary>
    /// No encryption.
    /// </summary>
    public static readonly string None = "none";

    /// <summary>
    /// Zero encryption.
    /// </summary>
    public static readonly string Zero = "zero";

    /// <summary>
    /// AES-128-GCM encryption.
    /// </summary>
    public static readonly string Aes128Gcm = "aes-128-gcm";

    /// <summary>
    /// ChaCha20-Poly1305 encryption.
    /// </summary>
    public static readonly string Chacha20Poly1305 = "chacha20-poly1305";

    /// <summary>
    /// AES-128-CTR encryption (legacy).
    /// </summary>
    public static readonly string Aes128Ctr = "aes-128-ctr";
}