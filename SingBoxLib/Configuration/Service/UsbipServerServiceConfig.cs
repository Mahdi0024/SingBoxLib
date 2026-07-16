namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the USB/IP Server service configuration.
/// </summary>
public sealed class UsbipServerServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UsbipServerServiceConfig"/> class.
    /// </summary>
    public UsbipServerServiceConfig()
    {
        Type = "usbip-server";
    }

    /// <summary>
    /// The device source provider. One of: default, dynamic.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// List of device matches selecting which local USB devices to export.
    /// </summary>
    [JsonPropertyName("devices")]
    public List<UsbDeviceMatch>? Devices { get; set; }
}
