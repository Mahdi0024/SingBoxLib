namespace SingBoxLib.Configuration.Route.Abstract;

/// <summary>
/// Represents the base class for route rules.
/// </summary>
[JsonDerivedType(typeof(RouteRule))]
[JsonDerivedType(typeof(RouteLogicalRule))]
public abstract class RouteRuleBase
{
}