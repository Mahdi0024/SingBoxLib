using SingboxLib.Configuration.Route.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingboxLib.Configuration.Route;
public sealed class RouteRuleSetRemote : RouteRuleSetBase
{
    public RouteRuleSetRemote()
    {
        Type = "remote";
    }
    [JsonProperty("format")]
    public required string Format { get; set; }

    [JsonProperty("url")]
    public required string Url { get; set; }

    [JsonProperty("download_detour")]
    public string? DownloadDetour { get; set; }

    [JsonProperty("update_interval")]
    public string? UpdateInterval { get; set; }
}
