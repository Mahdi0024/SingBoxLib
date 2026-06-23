namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Socks outbound.
/// </summary>
public sealed class SocksOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SocksOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public SocksOutbound(string? tag = null)
    {
        Type = "socks";
        Tag = tag ?? "socks-out";
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
    /// The SOCKS version, one of 4 4a 5.
    /// SOCKS5 used by default.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// SOCKS username.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// SOCKS5 password.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// UDP over TCP configuration.
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/udp-over-tcp/">UDP Over TCP</see> for details.
    /// Conflict with multiplex.
    /// </summary>
    [JsonPropertyName("udp_over_tcp")]
    public bool? UdpOverTcp { get; set; }
}