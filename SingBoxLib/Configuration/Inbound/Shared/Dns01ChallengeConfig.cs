namespace SingBoxLib.Configuration.Inbound.Shared;

public class Dns01ChallengeConfig
{
    [JsonProperty("provider")]
    public string? Provider { get; set; }

    [JsonProperty("access_key_id")]
    public string? AccessKeyId { get; set; }

    [JsonProperty("access_key_secret")]
    public string? AccessKeySecret { get; set; }

    [JsonProperty("region_id")]
    public string RegionId { get; set; }

    [JsonProperty("api_token")]
    public string ApiToken { get; set; }
}
