using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Trojan outbound.
/// </summary>
public sealed class TrojanOutbound : OutboundWithDialFields
{
    public TrojanOutbound(string? tag = null)
    {
        Type = "trojan";
        Tag = tag ?? "trojan-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonProperty("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonProperty("server_port")]
    public required int Port { get; set; }

    /// <summary>
    /// The Trojan password.
    /// </summary>
    [JsonProperty("password")]
    public required string Password { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/multiplex#outbound">Multiplex</see> for details.
    /// </summary>
    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }
}