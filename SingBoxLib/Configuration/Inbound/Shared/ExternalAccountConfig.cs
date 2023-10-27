namespace SingBoxLib.Configuration.Inbound.Shared;

public class ExternalAccountConfig
{
    [JsonProperty("key_id")]
    public string? KeyId { get; set; }

    [JsonProperty("mac_key")]
    public string? MacKey { get; set; }
}
