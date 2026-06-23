namespace SingBoxLib.Configuration.Endpoint.Abstract;
/// <summary>
/// Represents the base class for endpoint configurations.
/// </summary>
[JsonDerivedType(typeof(WireGuardEndpoint))]
public abstract class EndpointConfig : OutboundWithDialFields
{
}
