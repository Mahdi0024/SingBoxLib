using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

public sealed class NaiveInbound : InboundConfig
{
    public NaiveInbound()
    {
        Type = "naive";
        Tag = "naive-in";
    }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("users")]
    public List<ProxyUser>? Users { get; set; }

    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }
}