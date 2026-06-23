namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Tuic inbound server.
/// </summary>
public sealed class TuicInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TuicInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public TuicInbound(string? tag = null)
    {
        Type = "tuic";
        Tag = tag ?? "tuic-in";
    }

    /// <summary>
    /// A list of TUIC users associated with this connection.
    /// Each user has a unique identifier and credentials.
    /// </summary>
    [JsonPropertyName("users")]
    public List<TuicUser>? Users { get; set; }

    /// <summary>
    /// QUIC congestion control algorithm to use. 
    /// Supported algorithms: <b>cubic</b>, <b>new_reno</b>, <b>bbr</b>.
    /// Defaults to 'cubic' if empty.
    /// </summary>
    [JsonPropertyName("congestion_control")]
    public string? CongestionControl { get; set; }

    /// <summary>
    /// Specifies how long the server waits for client authentication commands.
    /// Default is 3 ("3s") seconds.
    /// </summary>
    [JsonPropertyName("auth_timeout")]
    public string? AuthTimeout { get; set; }

    /// <summary>
    /// Enable 0-RTT QUIC connection handshake on the client side.
    /// This is not impacting much on the performance, as the protocol is fully multiplexed.
    /// <b>Disabling this is highly recommended</b>, as it is vulnerable to replay attacks. <b>See <see href="https://blog.cloudflare.com/even-faster-connection-establishment-with-quic-0-rtt-resumption/#attack-of-the-clones">Attack of the clones</see></b>.
    /// </summary>
    [JsonPropertyName("zero_rtt_handshake")]
    public bool? ZeroRttHandshake { get; set; }

    /// <summary>
    /// Interval for sending heartbeat packets for keeping the connection alive.
    /// Default is 10 seconds ("10s").
    /// </summary>
    [JsonPropertyName("heartbeat")]
    public string? Heartbeat { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }
}

/// <summary>
/// Represents a user configuration for Tuic.
/// </summary>
public sealed class TuicUser
{
    /// <summary>
    /// Gets or sets the UUID.
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}
