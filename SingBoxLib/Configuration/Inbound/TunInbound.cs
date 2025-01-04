﻿using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class TunInbound : InboundConfig
{
    public TunInbound(string? tag = null)
    {
        Type = "tun";
        Tag = tag ?? "tun-in";
    }

    /// <summary>
    /// Virtual device name, automatically selected if empty.
    /// </summary>
    [JsonProperty("interface_name")]
    public string? InterfaceName { get; set; }

    /// <summary>
    /// IPv4 and IPv6 prefix for the tun interface.
    /// </summary>
    [JsonProperty("address")]
    public List<string> Address { get; set; }

    /// <summary>
    /// The maximum transmission unit for the tun interface.
    /// </summary>
    [JsonProperty("mtu")]
    public int? Mtu { get; set; }

    /// <summary>
    /// Set the default route to the Tun.
    /// </summary>
    [JsonProperty("auto_route")]
    public bool? AutoRoute { get; set; }

    /// <summary>
    /// Linux iproute2 table index generated by auto_route.
    /// Default value: 2022.
    /// </summary>
    [JsonProperty("iproute2_table_index")]
    public int? IpRoute2TableIndex { get; set; }

    /// <summary>
    /// Linux iproute2 rule start index generated by auto_route.
    /// Default value: 9000.
    /// </summary>
    [JsonProperty("iproute2_rule_index")]
    public int? IpRoute2RuleIndex { get; set; }

    /// <summary>
    /// Automatically configure iptables/nftables to redirect connections.
    /// Only supported on Linux with <see cref="AutoRoute"/> enabled.
    /// </summary>
    [JsonProperty("auto_redirect")]
    public bool? AutoRedirect { get; set; }

    /// <summary>
    /// Connection input mark used by route[_exclude]_address_set with auto_redirect.
    /// Default value: 0x2023
    /// </summary>
    [JsonProperty("auto_redirect_input_mark")]
    public string? AutoRedirectInputMark { get; set; }

    /// <summary>
    /// Used with route_exclude_address_set when <see cref="AutoRoute"/> is enabled.
    /// Default value: 0x2024
    /// </summary>
    [JsonProperty("auto_redirect_output_mark")]
    public string? AutoRedirectOutputMark { get; set; }

    /// <summary>
    /// Enables strict routing rules to prevent IP address leaks and DNS hijacking on different operating systems.
    /// When true, ensures that all network traffic is routed through a VPN tunnel, mitigating potential privacy risks.
    /// </summary>
    [JsonProperty("strict_route")]
    public bool? StrictRoute { get; set; }

    /// <summary>
    /// Enforce strict routing rules when <see cref="AutoRoute"/> is enabled.
    /// </summary>
    [JsonProperty("route_address")]
    public List<string>? RouteAddress { get; set; }

    /// <summary>
    /// Add the destination IP CIDR rules in the specified rule-sets to the firewall. Unmatched traffic will bypass the sing-box routes.
    /// </summary>
    [JsonProperty("route_address_set")]
    public List<string>? RouteAddressSet { get; set; }

    /// <summary>
    /// Add the destination IP CIDR rules in the specified rule-sets to the firewall.Matched traffic will bypass the sing-box routes.
    /// </summary>
    [JsonProperty("route_exclude_address_set")]
    public List<string>? RouteExcludeAddressSet { get; set; }

    /// <summary>
    /// Enable endpoint-independent NAT.
    /// Performance may degrade slightly, so it is not recommended to enable on when it is not needed.
    /// <b>This item is only available on the gvisor stack, other stacks are endpoint-independent NAT by default.</b>
    /// </summary>
    [JsonProperty("endpoint_independent_nat")]
    public bool? EndpointIndependentNat { get; set; }

    /// <summary>
    /// UDP NAT expiration time.
    /// 5m will be used by default.
    /// </summary>
    [JsonProperty("udp_timeout")]
    public new string? UdpTimeout { get; set; }

    /// <summary>
    /// TCP/IP stack. see <see href="http://sing-box.sagernet.org/configuration/inbound/tun/#stack">Stack</see>.
    /// Defaults to the mixed stack if the gVisor build tag is enabled, otherwise defaults to the system stack.
    /// </summary>
    [JsonProperty("stack")]
    public string? Stack { get; set; }

    /// <summary>
    /// Limit interfaces in route. Not limited by default.
    /// Interface rules are only supported on Linux and require <see cref="AutoRoute"/>.
    /// Conflict with <see cref="ExcludeInterface"/>.
    /// </summary>
    [JsonProperty("include_interface")]
    public List<string>? IncludeInterface { get; set; }

    /// <summary>
    /// Exclude interfaces in route.
    /// Conflict with <see cref="IncludeInterface"/>.
    /// </summary>
    [JsonProperty("exclude_interface")]
    public List<string>? ExcludeInterface { get; set; }

    /// <summary>
    /// Limit users in route. Not limited by default.
    /// <b>UID rules are only supported on Linux and require <see cref="AutoRoute"/>.</b>
    /// </summary>
    [JsonProperty("include_uid")]
    public List<int>? IncludeUid { get; set; }

    /// <summary>
    /// Exclude users in route.
    /// </summary>
    [JsonProperty("exclude_uid")]
    public List<int>? ExcludeUid { get; set; }

    /// <summary>
    /// Limit android users in route.
    /// <b>Android user and package rules are only supported on Android and require <see cref="AutoRoute"/>.</b>
    /// </summary>
    [JsonProperty("include_android_user")]
    public List<int>? IncludeAndroidUser { get; set; }

    /// <summary>
    /// Limit android packages in route.
    /// </summary>
    [JsonProperty("include_package")]
    public List<string>? IncludePackage { get; set; }

    /// <summary>
    /// Limit android packages in route.
    /// </summary
    [JsonProperty("exclude_package")]
    public List<string>? ExcludePackage { get; set; }

    /// <summary>
    /// Exclude custom routes when <see cref="AutoRoute"/> is enabled.
    /// </summary>
    [JsonProperty("route_exclude_address")]
    public List<string>? RouteExcludeAddress { get; set; }

    /// <summary>
    /// Limit users in route, but in range.
    /// </summary>
    [JsonProperty("include_uid_range")]
    public List<string>? IncludeUidRange { get; set; }

    /// <summary>
    /// Exclude users in route, but in range.
    /// </summary>
    [JsonProperty("exclude_uid_range")]
    public List<string>? ExcludeUidRange { get; set; }

    /// <summary>
    /// Platform-specific settings, provided by client applications.
    /// </summary>
    [JsonProperty("platform")]
    public TunPlatformSettings? Platform { get; set; }
}

public sealed class TunPlatformSettings
{

    [JsonProperty("http_proxy")]
    public TunPlatformHttpServer? HttpProxy { get; set; }
    public sealed class TunPlatformHttpServer
    {
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("server")]
        public string? Server { get; set; }

        [JsonProperty("server_port")]
        public int? ServerPort { get; set; }

        [JsonProperty("match_domain")]
        public List<string>? MatchDomain { get; set; }

        [JsonProperty("bypass_domain")]
        public List<string>? BypassDomain { get; set; }

    }
}

public static class TunStacks
{
    public const string System = "system";
    public const string gVisor = "gvisor";
    public const string Mixed = "mixed";
}