namespace SingBoxLib.Configuration.Dns.Abstract;

/// <summary>
/// Represents the base class for DNS rules in the sing-box configuration.
/// </summary>
[JsonConverter(typeof(DnsRuleBaseConverter))]
public abstract class DnsRuleBase
{
}
