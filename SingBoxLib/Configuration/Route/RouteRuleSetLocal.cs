using SingboxLib.Configuration.Route.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingboxLib.Configuration.Route;
public sealed class RouteRuleSetLocal : RouteRuleSetBase
{
    public RouteRuleSetLocal()
    {
        Type = "local";
    }
    [JsonProperty("format")]
    public required string Format { get; set; }

    [JsonProperty("path")]
    public required string Path { get; set; }
}
