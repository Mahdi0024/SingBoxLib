namespace SingBoxLib.Runtime.Api.Clash.Models;

public class LogInfo
{
    [JsonPropertyName("level")]
    public string Level { get; set; } = null!;

    [JsonPropertyName("payload")]
    public string Payload { get; set; } = null!;
}