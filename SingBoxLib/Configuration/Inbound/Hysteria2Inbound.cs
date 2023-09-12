using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

public sealed class Hysteria2Inbound : InboundConfig
{
    public Hysteria2Inbound()
    {
        Type = "hysteria2";
        Tag = "hysteria2-in";
    }

    [JsonProperty("up_mbps")]
    public int? UpMbps { get; set; }

    [JsonProperty("down_mbps")]
    public int? DownMbps { get; set; }

    [JsonProperty("obfs")]
    public Hysteria2Obfs? Obfs { get; set; }

    [JsonProperty("users")]
    public List<ProxyUserInbound>? Users { get; set; }

    [JsonProperty("ignore_client_bandwidth")]
    public bool? IgnoreClientBandwidth { get; set; }

    [JsonProperty("masquerade")]
    public string? Masquerade { get; set; }

    [JsonProperty("tls")]
    public Dictionary<string, string>? Tls { get; set; }
}