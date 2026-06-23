namespace SingBoxLib.Configuration.Route.Abstract;

/// <summary>
/// Represents the base class for route rules.
/// </summary>
[JsonConverter(typeof(RouteRuleBaseConverter))]
public abstract class RouteRuleBase
{
}