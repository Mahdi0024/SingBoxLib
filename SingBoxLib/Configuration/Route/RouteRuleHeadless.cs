using SingboxLib.Configuration.Route.Abstract;
using SingBoxLib.Configuration.Route.Abstract;

namespace SingboxLib.Configuration.Route;

public class RouteRuleHeadless: RouteRuleHeadlessBase
{
    [JsonProperty("query_type")]
    public List<object>? QueryType { get; set; }

    [JsonProperty("network")]
    public List<string>? Network { get; set; }

    [JsonProperty("domain")]
    public List<string>? Domain { get; set; }

    [JsonProperty("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    [JsonProperty("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    [JsonProperty("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    [JsonProperty("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    [JsonProperty("ip_cidr")]
    public List<string>? IpCidr { get; set; }

    [JsonProperty("source_port")]
    public List<int>? SourcePort { get; set; }

    [JsonProperty("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    [JsonProperty("port")]
    public List<int>? Port { get; set; }

    [JsonProperty("port_range")]
    public List<string>? PortRange { get; set; }

    [JsonProperty("process_name")]
    public List<string>? ProcessName { get; set; }

    [JsonProperty("process_path")]
    public List<string>? ProcessPath { get; set; }

    [JsonProperty("process_path_regex")]
    public List<string>? ProcessPathRegex { get; set; }

    [JsonProperty("package_name")]
    public List<string>? PackageName { get; set; }

    [JsonProperty("network_type")]
    public List<string>? NetworkType { get; set; }

    [JsonProperty("network_is_expensive")]
    public bool? IsNetworkExpensive { get; set; }

    [JsonProperty("network_is_constrained")]
    public bool? IsNetworkConstrained { get; set; }

    [JsonProperty("wifi_ssid")]
    public List<string>? WifiSsid { get; set; }

    [JsonProperty("wifi_bssid")]
    public List<string>? WifiBssid { get; set; }

    [JsonProperty("invert")]
    public bool? Invert { get; set; }
}