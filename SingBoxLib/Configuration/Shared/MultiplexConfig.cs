namespace SingBoxLib.Configuration.Shared;

public sealed class MultiplexConfig
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// protocol constants are provided via MultiplexProtocols class
    /// </summary>
    [JsonProperty("protocol")]
    public string? Protocol { get; set; }

    [JsonProperty("max_connections")]
    public int? MaxConnections { get; set; }

    [JsonProperty("min_streams")]
    public int? MinStreams { get; set; }

    [JsonProperty("max_streams")]
    public int? MaxStreams { get; set; }

    [JsonProperty("padding")]
    public bool? Padding { get; set; }
}