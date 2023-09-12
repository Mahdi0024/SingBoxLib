namespace SingBoxLib.Configuration.Shared;

public sealed class Hysteria2Obfs
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }
}