namespace SingBoxLib.Configuration.Log;

/// <summary>
/// Represents the configuration for sing-box logging.
/// </summary>
public sealed class LogConfig
{
    /// <summary>
    /// Disable logging, no output after start.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// Log level. One of: trace debug info warn error fatal panic.
    /// </summary>
    [JsonPropertyName("level")]
    public string? Level { get; set; }

    /// <summary>
    /// Output file path. Will not write log to console if enabled.
    /// </summary>
    [JsonPropertyName("output")]
    public string? Output { get; set; }

    /// <summary>
    /// Add time to each line.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public bool? Timestamp { get; set; }
}
/// <summary>
/// Predefined log level constants.
/// </summary>
public static class LogLevels
{
    /// <summary>
    /// Trace log level.
    /// </summary>
    public const string Trace = "trace";

    /// <summary>
    /// Debug log level.
    /// </summary>
    public const string Debug = "debug";

    /// <summary>
    /// Info log level.
    /// </summary>
    public const string Info = "info";

    /// <summary>
    /// Warn log level.
    /// </summary>
    public const string Warn = "warn";

    /// <summary>
    /// Error log level.
    /// </summary>
    public const string Error = "error";

    /// <summary>
    /// Fatal log level.
    /// </summary>
    public const string Fatal = "fatal";

    /// <summary>
    /// Panic log level.
    /// </summary>
    public const string Panic = "panic";
}
