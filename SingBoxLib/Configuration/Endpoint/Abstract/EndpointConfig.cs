namespace SingBoxLib.Configuration.Endpoint.Abstract;

/// <summary>
/// Represents the base class for endpoint configurations.
/// </summary>
[JsonConverter(typeof(EndpointConfigConverter))]
public abstract class EndpointConfig : OutboundWithDialFields
{
}
