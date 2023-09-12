namespace SingBoxLib.Configuration.Experimantal;

public sealed class V2rayApi
{
    [JsonProperty("listen")]
    public string? Listen { get; set; }

    [JsonProperty("stats")]
    public Stats? Stats { get; set; }
}

public sealed class Stats
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("inbounds")]
    public List<string>? Inbounds { get; set; }

    [JsonProperty("outbounds")]
    public List<string>? Outbounds { get; set; }

    [JsonProperty("users")]
    public List<string>? Users { get; set; }
}