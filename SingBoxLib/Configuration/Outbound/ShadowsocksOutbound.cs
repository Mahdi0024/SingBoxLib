namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Shadowsocks outbound.
/// </summary>
public sealed class ShadowsocksOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ShadowsocksOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public ShadowsocksOutbound(string? tag = null)
    {
        Type = "shadowsocks";
        Tag = tag ?? "ss-out";
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
    public required int ServerPort { get; set; }

    /// <summary>
    /// Encryption method. See <see cref="ShadowsocksEncryptions"/>.
    /// </summary>
    [JsonPropertyName("method")]
    public required string Encryption { get; set; }

    /// <summary>
    /// The shadowsocks password.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Shadowsocks SIP003 plugin, implemented in internal.
    /// Only obfs-local and v2ray-plugin are supported.
    /// </summary>
    [JsonPropertyName("plugin")]
    public string? Plugin { get; set; }

    /// <summary>
    /// Shadowsocks SIP003 plugin options.
    /// </summary>
    [JsonPropertyName("plugin_opts")]
    public string? PluginOptions { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// UDP over TCP configuration.
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/udp-over-tcp/">UDP Over TCP</see> for details.
    /// Conflict with <see cref="Multiplex"/>.
    /// </summary>
    [JsonPropertyName("udp_over_tcp")]
    public bool? UdpOverTcp { get; set; }

    /// <summary>
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/multiplex#outbound">Multiplex</see> for details.
    /// </summary>
    [JsonPropertyName("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}