using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Inbound.Shared;

namespace SingBoxLib.Configuration.Inbound;

public sealed class TrojanInbound : InboundConfig
{
    public TrojanInbound()
    {
        Type = "trojan";
        Tag = "trojan-in";
    }

    [JsonProperty("users")]
    public List<ProxyUserInbound>? Users { get; set; }

    [JsonProperty("tls")]
    public Dictionary<string, string>? Tls { get; set; }

    [JsonProperty("fallback")]
    public TrojanFallback? Fallback { get; set; }

    [JsonProperty("fallback_for_alpn")]
    public Dictionary<string, TrojanFallback>? FallbackForAlpn { get; set; }

    [JsonProperty("transport")]
    public Dictionary<string, string>? Transport { get; set; }
}

public sealed class TrojanFallback
{
    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }
}