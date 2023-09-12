using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class TransparentProxyInbound : InboundConfig
{
    public TransparentProxyInbound()
    {
        Type = "tproxy";
        Tag = "tproxy-in";
    }

    [JsonProperty("network")]
    public string? Network { get; set; }
}