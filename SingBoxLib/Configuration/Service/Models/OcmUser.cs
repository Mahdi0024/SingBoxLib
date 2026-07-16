namespace SingBoxLib.Configuration.Service.Models;

/// <summary>
/// Represents an authorized user for OCM.
/// </summary>
public sealed class OcmUser
{
    /// <summary>
    /// Username identifier.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Bearer token for authentication.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}
