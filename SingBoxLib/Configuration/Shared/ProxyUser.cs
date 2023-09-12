namespace SingBoxLib.Configuration.Inbound;

public sealed class ProxyUser
{
    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }
}