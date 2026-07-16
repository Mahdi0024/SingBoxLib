using System.Text.Json.Serialization;
using SingBoxLib.Configuration.NetworkNamespace;

namespace SingBoxLib.Configuration.NetworkNamespace.Abstract;

/// <summary>
/// Represents the base class for network namespace configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DefaultNetworkNamespace), "default")]
[JsonDerivedType(typeof(UnshareNetworkNamespace), "unshare")]
public abstract class NetworkNamespaceConfig
{
    /// <summary>
    /// Gets or sets the network namespace type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; internal set; }

    /// <summary>
    /// The tag of the network namespace.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
}