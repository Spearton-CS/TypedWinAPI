namespace TypedWinAPI.Kernel32;

public enum MountMgrControlCode : uint
{
    // DeviceType: 0x006D (MountManager)
    QueryPoints = 0x006D0008, // Get mount points / drive letters
    VolumeMountPointCreated = 0x006D0004,
    VolumeMountPointDeleted = 0x006D000C,
    QueryAutoMount = 0x006D003C,
    SetAutoMount = 0x006D0040
}
