using System.Text.Json.Serialization;
using SingBoxLib.Configuration.NetworkNamespace.Abstract;

namespace SingBoxLib.Configuration.NetworkNamespace;

/// <summary>
/// Create a new network namespace, without root privilege.
/// </summary>
public sealed class UnshareNetworkNamespace : NetworkNamespaceConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnshareNetworkNamespace"/> class.
    /// </summary>
    public UnshareNetworkNamespace()
    {
        Type = "unshare";
    }

    /// <summary>
    /// Path to write the PID of the process holding the namespace open.
    /// </summary>
    [JsonPropertyName("pid_file")]
    public string? PidFile { get; set; }
}