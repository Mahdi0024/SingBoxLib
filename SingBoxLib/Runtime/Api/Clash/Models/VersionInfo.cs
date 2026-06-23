namespace SingBoxLib.Runtime.Api.Clash.Models;

public class VersionInfo
{
    [JsonPropertyName("meta")]
    public bool Meta { get; set; }

    [JsonPropertyName("premium")]
    public bool Premium { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; } = null!;
}