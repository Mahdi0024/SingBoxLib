using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class SelectorOutbound : OutboundConfig
{
    public SelectorOutbound()
    {
        Type = "selector";
        Tag = "selector-out";
    }

    [JsonProperty("outbounds")]
    public List<string>? Outbounds { get; set; }

    [JsonProperty("default")]
    public string? Default { get; set; }
}