namespace SingBoxLib.Configuration.Service.Models;

/// <summary>
/// Represents USB device matching criteria for USB/IP configurations.
/// </summary>
public sealed class UsbDeviceMatch
{
    /// <summary>
    /// USB bus ID.
    /// </summary>
    [JsonPropertyName("bus_id")]
    public string? BusId { get; set; }

    /// <summary>
    /// USB vendor ID.
    /// </summary>
    [JsonPropertyName("vendor_id")]
    public int? VendorId { get; set; }

    /// <summary>
    /// USB product ID.
    /// </summary>
    [JsonPropertyName("product_id")]
    public int? ProductId { get; set; }

    /// <summary>
    /// Device serial number.
    /// </summary>
    [JsonPropertyName("serial")]
    public string? Serial { get; set; }
}
