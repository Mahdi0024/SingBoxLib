using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Naive inbound server.
/// </summary>
public sealed class NaiveInbound : InboundConfig
{
    public NaiveInbound(string? tag = null)
    {
        Type = "naive";
        Tag = tag ?? "naive-in";
    }

    /// <summary>
    /// Supports 'tcp' and 'udp'.
    /// If not specified, defaults to both protocols.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }

    /// <summary>
    /// List of users allowed to connect via this proxy. 
    /// </summary>
    [JsonProperty("users")]
    public List<ProxyUser>? Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }
}
