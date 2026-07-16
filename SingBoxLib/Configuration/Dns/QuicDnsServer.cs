namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a DNS over QUIC server configuration.
/// </summary>
public sealed class QuicDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QuicDnsServer"/> class.
    /// </summary>
    public QuicDnsServer()
    {
        Type = "quic";
    }

    /// <summary>
    /// The address of the DNS server.
    /// </summary>
    [JsonPropertyName("server")]
    public string? Server { get; set; }

    /// <summary>
    /// The port of the DNS server.
    /// </summary>
    [JsonPropertyName("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}
