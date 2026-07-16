namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a UDP DNS server configuration.
/// </summary>
public sealed class UdpDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UdpDnsServer"/> class.
    /// </summary>
    public UdpDnsServer()
    {
        Type = "udp";
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
