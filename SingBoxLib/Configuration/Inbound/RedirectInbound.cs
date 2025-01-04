using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Only supported on Linux and macOS.
/// </summary>
public sealed class RedirectInbound : InboundConfig
{
    public RedirectInbound(string? tag = null)
    {
        Type = "redirect";
        Tag = tag ?? "redirect-in";
    }
}