using System.Text.Json.Serialization;
using SingBoxLib.Configuration.NetworkNamespace.Abstract;

namespace SingBoxLib.Configuration.NetworkNamespace;

/// <summary>
/// Attach to an existing network namespace.
/// </summary>
public sealed class DefaultNetworkNamespace : NetworkNamespaceConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultNetworkNamespace"/> class.
    /// </summary>
    public DefaultNetworkNamespace()
    {
        Type = "default";
    }

    /// <summary>
    /// Name or path of the network namespace.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }
}