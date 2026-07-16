namespace SingBoxLib.Configuration.Service.Models;

/// <summary>
/// Represents an authorized user for CCM.
/// </summary>
public sealed class CcmUser
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
