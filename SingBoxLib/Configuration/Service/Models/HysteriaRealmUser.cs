namespace SingBoxLib.Configuration.Service.Models;

/// <summary>
/// Represents an authorized user for Hysteria Realm rendezvous service.
/// </summary>
public sealed class HysteriaRealmUser
{
    /// <summary>
    /// Username.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Bearer token presented by Hysteria2 inbounds/outbounds.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    /// <summary>
    /// Maximum number of realm slots this user may hold concurrently.
    /// </summary>
    [JsonPropertyName("max_realms")]
    public int? MaxRealms { get; set; }
}
