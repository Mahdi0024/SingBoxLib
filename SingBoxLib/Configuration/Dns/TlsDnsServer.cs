namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a DNS over TLS (DoT) server configuration.
/// </summary>
public sealed class TlsDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TlsDnsServer"/> class.
    /// </summary>
    public TlsDnsServer()
    {
        Type = "tls";
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
