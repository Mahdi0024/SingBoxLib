using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Outbound;

public sealed class TuicOutbound : OutboundWithDialFields
{
    public TuicOutbound()
    {
        Type = "tuic";
        Tag = "tuic-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("congestion_control")]
    public string? CongestionControl { get; set; }

    [JsonProperty("udp_relay_mode")]
    public string? UdpRelayMode { get; set; }

    [JsonProperty("udp_over_stream")]
    public bool? UdpOverStream { get; set; }

    [JsonProperty("zero_rtt_handshake")]
    public bool? ZeroRttHandshake { get; set; }

    [JsonProperty("heartbeat")]
    public string? Heartbeat { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }
}