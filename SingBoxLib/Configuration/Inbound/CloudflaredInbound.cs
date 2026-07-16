using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Runs an embedded Cloudflare Tunnel client and routes traffic.
/// </summary>
public sealed class CloudflaredInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudflaredInbound"/> class.
    /// </summary>
    public CloudflaredInbound()
    {
        Type = "cloudflared";
    }

    /// <summary>
    /// Base64-encoded tunnel token from the Cloudflare Zero Trust dashboard.
    /// </summary>
    [JsonPropertyName("token")]
    public required string Token { get; set; }

    /// <summary>
    /// Number of high-availability connections to the Cloudflare edge.
    /// </summary>
    [JsonPropertyName("ha_connections")]
    public int? HaConnections { get; set; }

    /// <summary>
    /// Transport protocol for edge connections.
    /// </summary>
    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }

    /// <summary>
    /// Enable post-quantum key exchange on the control connection.
    /// </summary>
    [JsonPropertyName("post_quantum")]
    public bool? PostQuantum { get; set; }

    /// <summary>
    /// IP version used when connecting to the Cloudflare edge.
    /// </summary>
    [JsonPropertyName("edge_ip_version")]
    public int? EdgeIpVersion { get; set; }

    /// <summary>
    /// Datagram protocol version used for UDP proxying over QUIC.
    /// </summary>
    [JsonPropertyName("datagram_version")]
    public string? DatagramVersion { get; set; }

    /// <summary>
    /// Graceful shutdown window for in-flight edge connections.
    /// </summary>
    [JsonPropertyName("grace_period")]
    public string? GracePeriod { get; set; }

    /// <summary>
    /// Cloudflare edge region selector.
    /// </summary>
    [JsonPropertyName("region")]
    public string? Region { get; set; }

    /// <summary>
    /// Dial Fields used when the tunnel client dials the control plane.
    /// </summary>
    [JsonPropertyName("control_dialer")]
    public DialFieldsConfig? ControlDialer { get; set; }

    /// <summary>
    /// Dial Fields used when the tunnel client dials the edge data plane.
    /// </summary>
    [JsonPropertyName("tunnel_dialer")]
    public DialFieldsConfig? TunnelDialer { get; set; }
}