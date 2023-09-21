namespace SingBoxLib.Runtime.Api.Clash.Models;

public class TrafficInfo
{
    [JsonProperty("up")]
    public int Up { get; set; }

    [JsonProperty("down")]
    public int Down { get; set; }
}