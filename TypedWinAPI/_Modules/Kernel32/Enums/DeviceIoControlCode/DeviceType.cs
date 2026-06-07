namespace TypedWinAPI.Kernel32;

/// <summary>
/// Identifies the type of device for which the control code is intended.
/// </summary>
public enum DeviceType : uint
{
    CdRom = 0x0002,
    Disk = 0x0007,
    FileSystem = 0x0009,
    FullScreenVideo = 0x0022,
    Dvd = 0x0033,
    Keyboard = 0x000B,
    MassStorage = 0x002D,
    Mouse = 0x000F,
    Network = 0x0012,
    ParallelPort = 0x0016,
    Screen = 0x001D,
    SerialPort = 0x001B,
    Video = 0x0023,
    VirtualDisk = 0x0024
}