namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the USB/IP Client service configuration.
/// </summary>
public sealed class UsbipClientServiceConfig : ServiceConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UsbipClientServiceConfig"/> class.
    /// </summary>
    public UsbipClientServiceConfig()
    {
        Type = "usbip-client";
    }

    /// <summary>
    /// Only detour takes effect in dial fields.
    /// </summary>
    [JsonPropertyName("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// The remote usbip-server address.
    /// </summary>
    [JsonPropertyName("server")]
    public string? Server { get; set; }

    /// <summary>
    /// The remote usbip-server port.
    /// </summary>
    [JsonPropertyName("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// List of device matches selecting which remote devices to import.
    /// </summary>
    [JsonPropertyName("devices")]
    public List<UsbDeviceMatch>? Devices { get; set; }
}
