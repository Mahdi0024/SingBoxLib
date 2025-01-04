using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class VMessInbound : InboundConfig
{
    public VMessInbound(string? tag = null)
    {
        Type = "vmess";
        Tag = tag ?? "vmess-out";
    }
    /// <summary>
    /// VMess users.
    /// </summary>
    [JsonProperty("users")]
    public required List<VMessUser>? Users { get; set; }

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
}

public class VMessUser
{
    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// Legacy protocol support (VMess MD5 Authentication) is provided for compatibility purposes only, use of alterId > 1 is not recommended.
    /// </summary>
    [JsonProperty("alterId")]
    public int AlterId { get; set; }
}