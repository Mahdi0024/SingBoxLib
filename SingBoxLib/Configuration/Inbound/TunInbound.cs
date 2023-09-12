using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class TunInbound : InboundConfig
{
    public TunInbound()
    {
        Type = "tun";
        Tag = "tun-in";
    }

    [JsonProperty("interface_name")]
    public string? InterfaceName { get; set; }

    [JsonProperty("inet4_address")]
    public string? INet4Address { get; set; }

    [JsonProperty("inet6_address")]
    public string? INet6Address { get; set; }

    [JsonProperty("mtu")]
    public int? Mtu { get; set; }

    [JsonProperty("auto_route")]
    public bool? AutoRoute { get; set; }

    [JsonProperty("strict_route")]
    public bool? StrictRoute { get; set; }

    [JsonProperty("inet4_route_address")]
    public List<string>? INet4RouteAddress { get; set; }

    [JsonProperty("inet6_route_address")]
    public List<string>? INet6RouteAddress { get; set; }

    [JsonProperty("endpoint_independent_nat")]
    public bool? EndpointIndependantNat { get; set; }

    [JsonProperty("stack")]
    public string? Stack { get; set; }

    [JsonProperty("include_interface")]
    public List<string>? IncludeInterface { get; set; }

    [JsonProperty("exclude_interface")]
    public List<string>? ExcludeInterface { get; set; }

    [JsonProperty("include_uid")]
    public List<int>? IncludeUid { get; set; }

    [JsonProperty("include_uid_range")]
    public List<string>? IncludeUidRange { get; set; }

    [JsonProperty("exclude_uid")]
    public List<int>? ExcludeUid { get; set; }

    [JsonProperty("exclude_uid_range")]
    public List<string>? ExcludeUidRange { get; set; }

    [JsonProperty("include_android_user")]
    public List<int>? IncludeAndroidUser { get; set; }

    [JsonProperty("include_package")]
    public List<string>? IncludePackage { get; set; }

    [JsonProperty("exclude_package")]
    public List<string>? ExcludePackage { get; set; }
}

public sealed class TunPlatformSettings
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }
}