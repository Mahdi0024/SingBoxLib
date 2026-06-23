namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Tor outbound.
/// </summary>
public sealed class TorOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TorOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public TorOutbound(string? tag = null)
    {
        Type = "tor";
        Tag = tag ?? "tor-out";
    }
    /// <summary>
    /// The path to the Tor executable.
    /// Embedded Tor will be ignored if set.
    /// </summary>
    [JsonProperty("executable_path")]
    public string? ExecutablePath { get; set; }

    /// <summary>
    /// List of extra arguments passed to the Tor instance when started.
    /// </summary>
    [JsonProperty("extra_args")]
    public List<string>? ExtraArgs { get; set; }

    /// <summary>
    /// The data directory of Tor.
    /// Each start will be very slow if not specified.
    /// </summary>
    [JsonProperty("data_directory")]
    public string? DataDirectory { get; set; }

    /// <summary>
    /// Map of torrc options.
    /// See <see href="https://linux.die.net/man/1/tor">tor(1)</see> for details.
    /// </summary>
    [JsonProperty("torrc")]
    public Torrc? Torrc { get; set; }
}

/// <summary>
/// Represents torrc configuration options.
/// </summary>
public sealed class Torrc
{
    /// <summary>
    /// Gets or sets ClientOnly option.
    /// </summary>
    [JsonProperty("ClientOnly")]
    public int? ClientOnly { get; set; }
}