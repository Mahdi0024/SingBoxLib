using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class BlockOutbound : OutboundConfig
{
    public BlockOutbound()
    {
        Type = "block";
        Tag = "block-out";
    }
}