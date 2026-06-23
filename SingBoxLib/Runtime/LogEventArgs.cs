namespace SingBoxLib.Runtime;

/// <summary>
/// Specifies the stream where the log line originated from.
/// </summary>
public enum LogStream
{
    /// <summary>
    /// Standard output stream.
    /// </summary>
    StandardOutput,
    /// <summary>
    /// Standard error stream.
    /// </summary>
    StandardError
}

/// <summary>
/// Provides data for the log event.
/// </summary>
public readonly struct LogEventArgs
{
    /// <summary>
    /// The log message line.
    /// </summary>
    public string Line { get; }

    /// <summary>
    /// The stream from which the log originated.
    /// </summary>
    public LogStream Stream { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogEventArgs"/> struct.
    /// </summary>
    public LogEventArgs(string line, LogStream stream)
    {
        Line = line;
        Stream = stream;
    }
}
