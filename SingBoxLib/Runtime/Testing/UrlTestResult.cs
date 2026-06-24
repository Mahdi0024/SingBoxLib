using SingBoxLib.Parsing;

namespace SingBoxLib.Runtime.Testing;

/// <summary>
/// Represents the result of a proxy node URL latency and health test.
/// </summary>
public readonly struct UrlTestResult
{
    /// <summary>
    /// Gets the tested profile item.
    /// </summary>
    public required ProfileItem Profile { get; init; }

    /// <summary>
    /// Gets the test delay / latency in milliseconds.
    /// </summary>
    public          int         Delay   { get; init; }

    /// <summary>
    /// Gets whether the test was successful.
    /// </summary>
    public required bool        Success { get; init; }
}
