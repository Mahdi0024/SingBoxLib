namespace SingBoxLib.Runtime.Api.Clash.Models;

public class TrafficInfo
{
    [JsonPropertyName("up")]
    public int Up { get; set; }

    [JsonPropertyName("down")]
    public int Down { get; set; }
}