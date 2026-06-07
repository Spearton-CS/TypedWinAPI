namespace TypedWinAPI.Kernel32;

public enum VideoControlCode : uint
{
    // DeviceType: Video (0x0023)
    SetDisplayMode = 0x00230004,
    QueryDisplayParameters = 0x00230008
}
