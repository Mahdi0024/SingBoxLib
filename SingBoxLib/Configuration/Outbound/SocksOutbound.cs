using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Socks outbound.
/// </summary>
public sealed class SocksOutbound : OutboundWithDialFields
{
    public SocksOutbound(string? tag = null)
    {
        Type = "socks";
        Tag = tag ?? "socks-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// The SOCKS version, one of 4 4a 5.
    /// SOCKS5 used by default.
    /// </summary>
    [JsonProperty("version")]
    public string? Version { get; set; }

    /// <summary>
    /// SOCKS username.
    /// </summary>
    [JsonProperty("username")]
    public string? Username { get; set; }

    /// <summary>
    /// SOCKS5 password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }

    /// <summary>
    /// UDP over TCP configuration.
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/udp-over-tcp/">UDP Over TCP</see> for details.
    /// Conflict with <see cref="Multiplex"/>.
    /// </summary>
    [JsonProperty("udp_over_tcp")]
    public bool? UdpOverTcp { get; set; }
}