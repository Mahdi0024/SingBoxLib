namespace SingBoxLib.Configuration.Dns;

public sealed class DnsConfig
{
    [JsonProperty("servers")]
    public List<DnsServer>? Servers { get; set; }

    [JsonProperty("rules")]
    public List<object>? Rules { get; set; }

    [JsonProperty("final")]
    public string? Final { get; set; }

    [JsonProperty("strategy")]
    public string? Strategy { get; set; }

    [JsonProperty("disable_cache")]
    public bool? DisableCache { get; set; }

    [JsonProperty("disable_expire")]
    public bool? DisableExpire { get; set; }

    [JsonProperty("independent_cache")]
    public bool? IndependentCache { get; set; }

    [JsonProperty("reverse_mapping")]
    public bool? ReverseMapping { get; set; }

    [JsonProperty("fakeip")]
    public FakeIp? Fakeip { get; set; }
}