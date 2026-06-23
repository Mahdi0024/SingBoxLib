namespace SingBoxLib.Configuration.Route.Abstract;

/// <summary>
/// Represents the base class for headless route rules.
/// </summary>
[JsonConverter(typeof(RouteRuleHeadlessBaseConverter))]
public abstract class RouteRuleHeadlessBase : RouteRuleBase
{
}
