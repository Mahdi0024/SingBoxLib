namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents a headless route rule.
/// </summary>
public sealed class RouteRuleHeadless: RouteRuleHeadlessBase
{
    /// <summary>
    /// Gets or sets the list of query types.
    /// </summary>
    [JsonPropertyName("query_type")]
    public List<object>? QueryType { get; set; }

    /// <summary>
    /// Gets or sets the list of networks.
    /// </summary>
    [JsonPropertyName("network")]
    public List<string>? Network { get; set; }

    /// <summary>
    /// Gets or sets the list of domains.
    /// </summary>
    [JsonPropertyName("domain")]
    public List<string>? Domain { get; set; }

    /// <summary>
    /// Gets or sets the list of domain suffixes.
    /// </summary>
    [JsonPropertyName("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    /// <summary>
    /// Gets or sets the list of domain keywords.
    /// </summary>
    [JsonPropertyName("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    /// <summary>
    /// Gets or sets the list of domain regular expressions.
    /// </summary>
    [JsonPropertyName("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    /// <summary>
    /// Gets or sets the list of source IP CIDRs.
    /// </summary>
    [JsonPropertyName("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    /// <summary>
    /// Gets or sets the list of destination IP CIDRs.
    /// </summary>
    [JsonPropertyName("ip_cidr")]
    public List<string>? IpCidr { get; set; }

    /// <summary>
    /// Gets or sets the list of source ports.
    /// </summary>
    [JsonPropertyName("source_port")]
    public List<int>? SourcePort { get; set; }

    /// <summary>
    /// Gets or sets the list of source port ranges.
    /// </summary>
    [JsonPropertyName("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    /// <summary>
    /// Gets or sets the list of destination ports.
    /// </summary>
    [JsonPropertyName("port")]
    public List<int>? Port { get; set; }

    /// <summary>
    /// Gets or sets the list of destination port ranges.
    /// </summary>
    [JsonPropertyName("port_range")]
    public List<string>? PortRange { get; set; }

    /// <summary>
    /// Gets or sets the list of process names.
    /// </summary>
    [JsonPropertyName("process_name")]
    public List<string>? ProcessName { get; set; }

    /// <summary>
    /// Gets or sets the list of process paths.
    /// </summary>
    [JsonPropertyName("process_path")]
    public List<string>? ProcessPath { get; set; }

    /// <summary>
    /// Gets or sets the list of process path regular expressions.
    /// </summary>
    [JsonPropertyName("process_path_regex")]
    public List<string>? ProcessPathRegex { get; set; }

    /// <summary>
    /// Gets or sets the list of package names.
    /// </summary>
    [JsonPropertyName("package_name")]
    public List<string>? PackageName { get; set; }

    /// <summary>
    /// Gets or sets the list of network types.
    /// </summary>
    [JsonPropertyName("network_type")]
    public List<string>? NetworkType { get; set; }

    /// <summary>
    /// Gets or sets whether the network is expensive.
    /// </summary>
    [JsonPropertyName("network_is_expensive")]
    public bool? IsNetworkExpensive { get; set; }

    /// <summary>
    /// Gets or sets whether the network is constrained.
    /// </summary>
    [JsonPropertyName("network_is_constrained")]
    public bool? IsNetworkConstrained { get; set; }

    /// <summary>
    /// Gets or sets the list of WiFi SSIDs.
    /// </summary>
    [JsonPropertyName("wifi_ssid")]
    public List<string>? WifiSsid { get; set; }

    /// <summary>
    /// Gets or sets the list of WiFi BSSIDs.
    /// </summary>
    [JsonPropertyName("wifi_bssid")]
    public List<string>? WifiBssid { get; set; }

    /// <summary>
    /// Gets or sets the list of android package name regular expressions.
    /// </summary>
    [JsonPropertyName("package_name_regex")]
    public List<string>? PackageNameRegex { get; set; }

    /// <summary>
    /// Gets or sets the network interface addresses.
    /// </summary>
    [JsonPropertyName("network_interface_address")]
    public Dictionary<string, List<string>>? NetworkInterfaceAddress { get; set; }

    /// <summary>
    /// Gets or sets the default interface addresses.
    /// </summary>
    [JsonPropertyName("default_interface_address")]
    public List<string>? DefaultInterfaceAddress { get; set; }

    /// <summary>
    /// Gets or sets whether to invert the rule match.
    /// </summary>
    [JsonPropertyName("invert")]
    public bool? Invert { get; set; }
}