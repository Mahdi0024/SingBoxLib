namespace SingBoxLib.Runtime.Api.Clash.Models;

public class LogInfo
{
    [JsonProperty("level")]
    public string Level { get; set; } = null!;

    [JsonProperty("payload")]
    public string Payload { get; set; } = null!;
}