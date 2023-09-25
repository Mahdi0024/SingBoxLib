using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

public sealed class SocksInbound : InboundConfig
{
    public SocksInbound()
    {
        Type = "socks";
        Tag = "socks-in";
    }

    [JsonProperty("users")]
    public List<ProxyUser>? Users { get; set; }
}