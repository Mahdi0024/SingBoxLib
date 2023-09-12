using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class RedirectInbound : InboundConfig
{
    public RedirectInbound()
    {
        Type = "redirect";
        Tag = "redirect-in";
    }
}