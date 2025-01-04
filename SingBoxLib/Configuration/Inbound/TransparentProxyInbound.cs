using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class TransparentProxyInbound : InboundConfig
{
    public TransparentProxyInbound(string? tag = null)
    {
        Type = "tproxy";
        Tag = tag ?? "tproxy-in";
    }
    /// <summary>
    /// Listen network, can be <b>tcp</b> or <b>udp</b>.
    /// Both if empty.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }
}