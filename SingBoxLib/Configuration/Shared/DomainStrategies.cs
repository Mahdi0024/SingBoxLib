namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Constants representing domain resolution strategies.
/// </summary>
public static class DomainStrategies
{
    /// <summary>
    /// Prefer resolving IPv4 addresses.
    /// </summary>
    public const string PreferIPV4 = "prefer_ipv4";

    /// <summary>
    /// Prefer resolving IPv6 addresses.
    /// </summary>
    public const string PreferIPV6 = "prefer_ipv6";

    /// <summary>
    /// Resolve IPv4 addresses only.
    /// </summary>
    public const string IPV4Only = "ipv4_only";

    /// <summary>
    /// Resolve IPv6 addresses only.
    /// </summary>
    public const string IPV6Only = "ipv6_only";
}