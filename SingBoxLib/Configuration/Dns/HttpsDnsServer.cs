namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a DNS over HTTPS (DoH) server configuration.
/// </summary>
public sealed class HttpsDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpsDnsServer"/> class.
    /// </summary>
    public HttpsDnsServer()
    {
        Type = "https";
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
