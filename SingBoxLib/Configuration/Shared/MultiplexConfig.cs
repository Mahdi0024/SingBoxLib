namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents multiplexing configuration settings.
/// </summary>
public sealed class MultiplexConfig
{
    /// <summary>
    /// Gets or sets whether multiplexing is enabled.
    /// </summary>
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// protocol constants are provided via MultiplexProtocols class
    /// </summary>
    [JsonProperty("protocol")]
    public string? Protocol { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of connections.
    /// </summary>
    [JsonProperty("max_connections")]
    public int? MaxConnections { get; set; }

    /// <summary>
    /// Gets or sets the minimum number of streams.
    /// </summary>
    [JsonProperty("min_streams")]
    public int? MinStreams { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of streams.
    /// </summary>
    [JsonProperty("max_streams")]
    public int? MaxStreams { get; set; }

    /// <summary>
    /// Gets or sets whether padding is enabled.
    /// </summary>
    [JsonProperty("padding")]
    public bool? Padding { get; set; }
}