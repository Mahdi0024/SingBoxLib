using SingboxLib.Configuration.Dns;
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

    [JsonProperty("action")]
    public DnsAction? Action { get; set; }

    [JsonProperty("server")]
    public string? Server { get; set; }
}