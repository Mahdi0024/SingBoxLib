namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a DNS over HTTP/3 server configuration.
/// </summary>
public sealed class H3DnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="H3DnsServer"/> class.
    /// </summary>
    public H3DnsServer()
    {
        Type = "h3";
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
    /// The path of the DNS server.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Additional headers to be sent to the DNS server.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}
