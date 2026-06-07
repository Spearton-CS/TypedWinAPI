namespace TypedWinAPI.Kernel32;

public enum StorageControlCode : uint
{
    GetDeviceNumber = 0x002D1080, // Physical drive index (e.g. 0 for \PhysicalDrive0)
    CheckVerify = 0x002D4800, // Check for media presence/change
    EjectMedia = 0x002D4808, // Open tray / eject drive
    LoadMedia = 0x002D480C, // Close tray
    Reserve = 0x002D4810, // Reserve device for exclusive use
    Release = 0x002D4814, // Release reservation
    GetHotplugInfo = 0x002D0014,  // Check if device is removable/safe to unplug
    QueryProperty = 0x002D1400,
    ManageDataSetAttributes = 0x002D5010
}