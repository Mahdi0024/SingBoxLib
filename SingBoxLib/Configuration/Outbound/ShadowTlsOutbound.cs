using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a ShadowTls outbound.
/// </summary>
public sealed class ShadowTlsOutbound : OutboundWithDialFields
{
    public ShadowTlsOutbound(string? tag = null)
    {
        Type = "shadowtls";
        Tag = tag ?? "shadowtls-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// ShadowTLS protocol version.
    /// 1 is used by default.
    /// </summary>
    [JsonProperty("version")]
    public int? Version { get; set; }

    /// <summary>
    /// ShadowTLS password.
    /// Only available in the ShadowTLS protocol 2.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}