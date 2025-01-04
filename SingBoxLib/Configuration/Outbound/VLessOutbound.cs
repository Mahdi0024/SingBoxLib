using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a VLess outbound.
/// </summary>
public sealed class VLessOutbound : OutboundWithDialFields
{
    public VLessOutbound(string? tag = null)
    {
        Type = "vless";
        Tag = tag ?? "vless-out";
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
    /// The VMess user id.
    /// </summary>
    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    /// <summary>
    /// VLESS Sub-protocol.
    /// Available values: xtls-rprx-vision.
    /// </summary>
    [JsonProperty("flow")]
    public string? Flow { get; set; }

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
    /// UDP packet encoding, xudp is used by default.
    /// One of: packetaddr or xudp.
    /// </summary>
    [JsonProperty("packet_encoding")]
    public string? PacketEncoding { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonConverter(typeof(TransportConfigJsonConverter))]
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }

    /// <summary>
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/multiplex#outbound">Multiplex</see> for details.
    /// </summary>
    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}