using SingboxLib.Configuration.Route.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingboxLib.Configuration.Route;
public sealed class RouteRuleSetInline : RouteRuleSetBase
{
    public RouteRuleSetInline()
    {
        Type = "inline";
    }
    [JsonProperty("rules")]
    public required List<RouteRuleHeadlessBase> Rules { get; set; }
}
