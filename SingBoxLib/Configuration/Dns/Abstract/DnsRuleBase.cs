namespace SingBoxLib.Configuration.Dns.Abstract;

/// <summary>
/// Represents the base class for DNS rules in the sing-box configuration.
/// </summary>
[JsonDerivedType(typeof(DnsRule))]
[JsonDerivedType(typeof(DnsLogicalRule))]
public abstract class DnsRuleBase
{
}