using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class VLessInbound : InboundConfig
{
    public VLessInbound(string? tag = null)
    {
        Type = "vless";
        Tag = tag ?? "vless-in";
    }

    [JsonProperty("users")]
    public List<VLessUser>? Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonConverter(typeof(TransportConfigJsonConverter))]
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }

    /// <summary>
    /// Multiplexing configuration for managing multiple streams over a single connection.
    /// </summary>
    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}

public class VLessUser
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    /// <summary>
    /// VLESS Sub-protocol.
    /// Available values: "xtls-rprx-vision"
    /// </summary>
    [JsonProperty("flow")]
    public string? Flow { get; set; }
}