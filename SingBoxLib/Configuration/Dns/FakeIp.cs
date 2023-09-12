namespace SingBoxLib.Configuration.Dns;

public sealed class FakeIp
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("inet4_range")]
    public string? Inet4Range { get; set; }

    [JsonProperty("inet6_range")]
    public string? Inet6Range { get; set; }
}