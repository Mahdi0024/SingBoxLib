using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// does not need dial fields
/// </summary>
public sealed class DnsOutbound : OutboundConfig
{
    public DnsOutbound()
    {
        Type = "dns";
        Tag = "dns-out";
    }
}