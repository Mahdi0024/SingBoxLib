namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a hosts DNS server configuration.
/// </summary>
public sealed class HostsDnsServer : DnsServer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HostsDnsServer"/> class.
    /// </summary>
    public HostsDnsServer()
    {
        Type = "hosts";
    }

    /// <summary>
    /// List of paths to hosts files.
    /// </summary>
    [JsonPropertyName("path")]
    public List<string>? Path { get; set; }

    /// <summary>
    /// Predefined hosts mapping.
    /// </summary>
    [JsonPropertyName("predefined")]
    public Dictionary<string, object>? Predefined { get; set; }
}
