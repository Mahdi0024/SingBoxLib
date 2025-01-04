namespace SingBoxLib.Configuration.Log;

public sealed class LogConfig
{
    /// <summary>
    /// Disable logging, no output after start.
    /// </summary>
    [JsonProperty("disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// Log level. One of: trace debug info warn error fatal panic.
    /// </summary>
    [JsonProperty("level")]
    public string? Level { get; set; }

    /// <summary>
    /// Output file path. Will not write log to console if enabled.
    /// </summary>
    [JsonProperty("output")]
    public string? Output { get; set; }

    /// <summary>
    /// Add time to each line.
    /// </summary>
    [JsonProperty("timestamp")]
    public bool? Timestamp { get; set; }
}
public static class LogLevels
{
    public const string Trace = "trace";
    public const string Debug = "debug";
    public const string Info = "info";
    public const string Warn = "warn";
    public const string Error = "error";
    public const string Fatal = "fatal";
    public const string Panic = "panic";
}
