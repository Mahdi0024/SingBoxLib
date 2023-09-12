using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Inbound.Shared;

namespace SingBoxLib.Configuration.Inbound;

public sealed class ShadowsocksInbound : InboundConfig
{
    public ShadowsocksInbound()
    {
        Type = "shadowsocks";
        Tag = "shadowsocks-in";
    }

    [JsonProperty("method")]
    public string? Method { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("users")]
    public List<ProxyUserInbound>? Users { get; set; }
}