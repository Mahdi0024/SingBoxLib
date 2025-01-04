using SingboxLib.Configuration.Route.Abstract;
using SingBoxLib.Configuration.Route.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingboxLib.Configuration.Route;
internal class RouteRuleHeadlessLogical : RouteRuleHeadlessBase
{
    public RouteRuleHeadlessLogical()
    {
        Type = "logical";
    }

    [JsonProperty("type")]
    public string? Type { get; internal set; }

    [JsonProperty("mode")]
    public required string Mode { get; set; }

    [JsonProperty("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    [JsonProperty("invert")]
    public bool? Invert { get; set; }
}
