namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a TCP DNS server configuration.
/// </summary>
public sealed class TcpDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TcpDnsServer"/> class.
    /// </summary>
    public TcpDnsServer()
    {
        Type = "tcp";
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
}
