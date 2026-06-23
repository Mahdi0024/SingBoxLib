namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Naive inbound server.
/// </summary>
public sealed class NaiveInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NaiveInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public NaiveInbound(string? tag = null)
    {
        Type = "naive";
        Tag = tag;
    }

    /// <summary>
    /// Supports 'tcp' and 'udp'.
    /// If not specified, defaults to both protocols.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// List of users allowed to connect via this proxy. 
    /// </summary>
    [JsonPropertyName("users")]
    public List<ProxyUser>? Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }
}
