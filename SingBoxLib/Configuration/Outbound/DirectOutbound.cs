using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// direct outbound send requests directly.
/// </summary>
public sealed class DirectOutbound : OutboundWithDialFields
{
    public DirectOutbound(string? tag = null)
    {
        Type = "direct";
        Tag = tag ?? "direct-out";
    }
}