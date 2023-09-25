using SingBoxLib.Configuration.Dns.Abstract;

namespace SingBoxLib.Configuration.Dns;

public sealed class DnsLogicalRule : DnsRuleBase
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("mode")]
    public string? Mode { get; set; }

    [JsonProperty("rules")]
    public List<DnsRuleBase>? Rules { get; set; }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("disable_cache")]
    public bool? DisableCache { get; set; }

    [JsonProperty("rewrite_ttl")]
    public int? RewriteTtl { get; set; }
}