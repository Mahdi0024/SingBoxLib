namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents multiplexing configuration settings.
/// </summary>
public sealed class MultiplexConfig
{
    /// <summary>
    /// Gets or sets whether multiplexing is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// protocol constants are provided via MultiplexProtocols class
    /// </summary>
    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of connections.
    /// </summary>
    [JsonPropertyName("max_connections")]
    public int? MaxConnections { get; set; }

    /// <summary>
    /// Gets or sets the minimum number of streams.
    /// </summary>
    [JsonPropertyName("min_streams")]
    public int? MinStreams { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of streams.
    /// </summary>
    [JsonPropertyName("max_streams")]
    public int? MaxStreams { get; set; }

    /// <summary>
    /// Gets or sets whether padding is enabled.
    /// </summary>
    [JsonPropertyName("padding")]
    public bool? Padding { get; set; }
}