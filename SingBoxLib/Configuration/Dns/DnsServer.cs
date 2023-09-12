namespace SingBoxLib.Configuration.Dns;

public sealed class DnsServer
{
    [JsonProperty("tag")]
    public string? Tag { get; set; }

    [JsonProperty("address")]
    public string? Address { get; set; }

    [JsonProperty("address_resolver")]
    public string? AddressResolver { get; set; }

    [JsonProperty("address_strategy")]
    public string? AddressStrategy { get; set; }

    [JsonProperty("strategy")]
    public string? Strategy { get; set; }

    [JsonProperty("detour")]
    public string? Detour { get; set; }
}