using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Tuic inbound server.
/// </summary>
public sealed class TuicInbound : InboundConfig
{
    public TuicInbound(string? tag = null)
    {
        Type = "tuic";
        Tag = tag ?? "tuic-in";
    }

    /// <summary>
    /// A list of TUIC users associated with this connection.
    /// Each user has a unique identifier and credentials.
    /// </summary>
    [JsonProperty("users")]
    public List<TuicUser>? Users { get; set; }

    /// <summary>
    /// QUIC congestion control algorithm to use. 
    /// Supported algorithms: <b>cubic</b>, <b>new_reno</b>, <b>bbr</b>.
    /// Defaults to 'cubic' if empty.
    /// </summary>
    [JsonProperty("congestion_control")]
    public string? CongestionControl { get; set; }

    /// <summary>
    /// Specifies how long the server waits for client authentication commands.
    /// Default is 3 ("3s") seconds.
    /// </summary>
    [JsonProperty("auth_timeout")]
    public string? AuthTimeout { get; set; }

    /// <summary>
    /// Enable 0-RTT QUIC connection handshake on the client side.
    /// This is not impacting much on the performance, as the protocol is fully multiplexed.
    /// <b>Disabling this is highly recommended</b>, as it is vulnerable to replay attacks. <b>See <see href="https://blog.cloudflare.com/even-faster-connection-establishment-with-quic-0-rtt-resumption/#attack-of-the-clones">Attack of the clones</see></b>.
    /// </summary>
    [JsonProperty("zero_rtt_handshake")]
    public bool? ZeroRttHandshake { get; set; }

    /// <summary>
    /// Interval for sending heartbeat packets for keeping the connection alive.
    /// Default is 10 seconds ("10s").
    /// </summary>
    [JsonProperty("heartbeat")]
    public string? Heartbeat { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }
}

public class TuicUser
{
    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }
}
