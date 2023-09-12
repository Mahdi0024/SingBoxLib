using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class UrlTestOutbound : OutboundConfig
{
    public UrlTestOutbound()
    {
        Type = "urltest";
        Tag = "auto";
    }

    [JsonProperty("outbounds")]
    public List<string>? Outbounds { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("interval")]
    public string? Interval { get; set; }

    [JsonProperty("tolerance")]
    public int? Tolerance { get; set; }
}