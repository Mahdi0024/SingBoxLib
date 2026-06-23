namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Only supported on Linux and macOS.
/// </summary>
public sealed class RedirectInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RedirectInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public RedirectInbound(string? tag = null)
    {
        Type = "redirect";
        Tag = tag;
    }
}