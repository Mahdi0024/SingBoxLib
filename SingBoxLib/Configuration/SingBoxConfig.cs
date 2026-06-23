namespace SingBoxLib.Configuration;

public sealed class SingBoxConfig
{
    [JsonProperty("log")]
    public LogConfig? Log { get; set; }

    [JsonProperty("dns")]
    public DnsConfig? Dns { get; set; }

    [JsonProperty("ntp")]
    public NtpConfig? Ntp { get; set; }

    [JsonProperty("endpoints")]
    public List<EndpointConfig>? Endpoints { get; set; }

    [JsonProperty("inbounds")]
    public List<InboundConfig>? Inbounds { get; set; }

    [JsonProperty("outbounds")]
    public List<OutboundConfig>? Outbounds { get; set; }

    [JsonProperty("route")]
    public RouteConfig? Route { get; set; }

    [JsonProperty("experimental")]
    public ExperimentalConfig? Experimental { get; set; }

    private static JsonSerializerSettings _serializerSettings = new() { NullValueHandling = NullValueHandling.Ignore };
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, _serializerSettings);
    }
}