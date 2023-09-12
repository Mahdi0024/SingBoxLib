namespace SingBoxLib.Configuration.Inbound.Shared;

public sealed class ProxyUserInbound
{
    [JsonProperty("name")]
    public string? Username { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }
}