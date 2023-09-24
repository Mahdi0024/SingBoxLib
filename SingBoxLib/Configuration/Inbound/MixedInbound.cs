using SingBoxLib.Configuration.Inbound;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;
public sealed class MixedInbound : InboundConfig
{
    public MixedInbound()
    {
        Type = "mixed";
        Tag = "mixed-in";
    }

    [JsonProperty("users")]
    public List<ProxyUser>? Users { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }

    [JsonProperty("set_system_proxy")]
    public bool? SetSystemProxy { get; set; }
}