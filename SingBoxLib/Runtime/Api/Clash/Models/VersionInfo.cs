namespace SingBoxLib.Runtime.Api.Clash.Models;

public class VersionInfo
{
    [JsonProperty("meta")]
    public bool Meta { get; set; }

    [JsonProperty("premium")]
    public bool Premium { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; } = null!;
}