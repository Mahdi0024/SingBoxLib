using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Block outbound configuration.
/// </summary>
public sealed class BlockOutbound : OutboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlockOutbound"/> class.
    /// </summary>
    public BlockOutbound()
    {
        Type = "block";
    }
}