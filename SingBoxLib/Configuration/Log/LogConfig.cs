namespace SingBoxLib.Configuration.Log;

public sealed class LogConfig
{
    [JsonProperty("disabled")]
    public bool? Disabled { get; set; }

    [JsonProperty("level")]
    public string? Level { get; set; }

    [JsonProperty("output")]
    public string? Output { get; set; }

    [JsonProperty("timestamp")]
    public bool? Timestamp { get; set; }
}