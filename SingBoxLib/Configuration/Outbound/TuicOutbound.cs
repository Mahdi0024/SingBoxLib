using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a TUIC outbound.
/// </summary>
public sealed class TuicOutbound : OutboundWithDialFields
{
    public TuicOutbound(string? tag = null)
    {
        Type = "tuic";
        Tag = tag ?? "tuic-out";
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
    public required int ServerPort { get; set; }

    /// <summary>
    /// TUIC user uuid.
    /// </summary>
    [JsonProperty("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// The Trojan password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// QUIC congestion control algorithm.
    /// One of: cubic, new_reno, bbr
    /// cubic is used by default.
    /// </summary>
    [JsonProperty("congestion_control")]
    public string? CongestionControl { get; set; }

    /// <summary>
    /// UDP packet relay mode.
    /// native: native UDP characteristics.
    /// quic: lossless UDP relay using QUIC streams, additional overhead is introduced.
    /// native is used by default.
    /// Conflict with <see cref="UdpOverStream"/>.
    /// </summary>
    [JsonProperty("udp_relay_mode")]
    public string? UdpRelayMode { get; set; }

    /// <summary>
    /// This is the TUIC port of the UDP over TCP protocol, designed to provide a QUIC stream based UDP relay mode that TUIC does not provide. Since it is an add-on protocol, you will need to use sing-box or another program compatible with the protocol as a server.
    /// This mode has no positive effect in a proper UDP proxy scenario and should only be applied to relay streaming UDP traffic (basically QUIC streams).
    /// Conflict with <see cref="UdpRelayMode"/>.
    /// </summary>
    [JsonProperty("udp_over_stream")]
    public bool? UdpOverStream { get; set; }

    [JsonProperty("zero_rtt_handshake")]
    public bool? ZeroRttHandshake { get; set; }

    [JsonProperty("heartbeat")]
    public string? Heartbeat { get; set; }

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
}