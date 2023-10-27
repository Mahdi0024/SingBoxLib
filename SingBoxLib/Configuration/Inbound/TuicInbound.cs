using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

public sealed class TuicInbound : InboundConfig
{
    public TuicInbound()
    {
        Type = "tuic";
        Tag = "tuic-in";
    }

    [JsonProperty("users")]
    public List<TuicUser>? Users { get; set; }

    [JsonProperty("congestion_control")]
    public string? CongestionControl { get; set; }

    [JsonProperty("auth_timeout")]
    public string? AuthTimeout { get; set; }

    [JsonProperty("zero_rtt_handshake")]
    public bool? ZeroRttHandshake { get; set; }

    [JsonProperty("heartbeat")]
    public string? Heartbeat { get; set; }

    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }
}

public class TuicUser
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }
}