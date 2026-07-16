using System.Text.Json.Serialization;

namespace SingBoxLib.Configuration.Endpoint.Abstract;

/// <summary>
/// Represents the base class for endpoint configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(WireGuardEndpoint), "wireguard")]
[JsonDerivedType(typeof(TailscaleEndpoint), "tailscale")]
public abstract class EndpointConfig : OutboundWithDialFields
{
}