using System.Text.Json.Serialization;

namespace SingBoxLib.Runtime.Api.Clash.Models;

/// <summary>
/// Represents Clash configuration info.
/// </summary>
public class ConfigInfo
{
    /// <summary>
    /// Gets or sets the HTTP/mixed proxy port.
    /// </summary>
    [JsonPropertyName("port")]
    public int Port { get; set; }

    /// <summary>
    /// Gets or sets the SOCKS proxy port.
    /// </summary>
    [JsonPropertyName("socks-port")]
    public int SocksPort { get; set; }

    /// <summary>
    /// Gets or sets the redirect port.
    /// </summary>
    [JsonPropertyName("redir-port")]
    public int RedirPort { get; set; }

    /// <summary>
    /// Gets or sets the TPROXY port.
    /// </summary>
    [JsonPropertyName("tproxy-port")]
    public int TproxyPort { get; set; }

    /// <summary>
    /// Gets or sets the mixed port.
    /// </summary>
    [JsonPropertyName("mixed-port")]
    public int MixedPort { get; set; }

    /// <summary>
    /// Gets or sets whether LAN access is allowed.
    /// </summary>
    [JsonPropertyName("allow-lan")]
    public bool AllowLan { get; set; }

    /// <summary>
    /// Gets or sets the bind address.
    /// </summary>
    [JsonPropertyName("bind-address")]
    public string? BindAddress { get; set; }

    /// <summary>
    /// Gets or sets the routing mode.
    /// </summary>
    [JsonPropertyName("mode")]
    public string? Mode { get; set; }

    /// <summary>
    /// Gets or sets the log level.
    /// </summary>
    [JsonPropertyName("log-level")]
    public string? LogLevel { get; set; }

    /// <summary>
    /// Gets or sets whether IPv6 is enabled.
    /// </summary>
    [JsonPropertyName("ipv6")]
    public bool Ipv6 { get; set; }

    /// <summary>
    /// Gets or sets the TUN settings.
    /// </summary>
    [JsonPropertyName("tun")]
    public string? Tun { get; set; }
}
