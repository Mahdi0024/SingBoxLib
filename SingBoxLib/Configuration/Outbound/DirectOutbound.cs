namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// direct outbound send requests directly.
/// </summary>
public sealed class DirectOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DirectOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public DirectOutbound(string? tag = null)
    {
        Type = "direct";
        Tag = tag ?? "direct-out";
    }
}