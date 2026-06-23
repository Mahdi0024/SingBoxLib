namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Trojan outbound.
/// </summary>
public sealed class TrojanOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrojanOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public TrojanOutbound(string? tag = null)
    {
        Type = "trojan";
        Tag = tag ?? "trojan-out";
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
    public required int Port { get; set; }

    /// <summary>
    /// The Trojan password.
    /// </summary>
    [JsonPropertyName("password")]
    public required string Password { get; set; }

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
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/multiplex#outbound">Multiplex</see> for details.
    /// </summary>
    [JsonPropertyName("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonPropertyName("transport")]
    public TransportConfig? Transport { get; set; }
}