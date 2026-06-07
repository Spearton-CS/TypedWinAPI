using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

// NOTE: The strings are located dynamically based on these offsets inside the VRA block.
[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct MountMgrMountPoint
{
    [FieldOffset(0)] public uint SymbolicLinkNameOffset;
    [FieldOffset(4)] public ushort SymbolicLinkNameLength;
    [FieldOffset(6)] public ushort Reserved1;
    [FieldOffset(8)] public uint UniqueIdOffset;
    [FieldOffset(12)] public ushort UniqueIdLength;
    [FieldOffset(14)] public ushort Reserved2;
    [FieldOffset(16)] public uint DeviceNameOffset;
    [FieldOffset(20)] public ushort DeviceNameLength;
    [FieldOffset(22)] public ushort Reserved3;

    public readonly override string ToString() =>
    $"""
    SymbolicLinkName: Offset {SymbolicLinkNameOffset}, Length {SymbolicLinkNameLength}
    UniqueId: Offset {UniqueIdOffset}, Length {UniqueIdLength}
    DeviceName: Offset {DeviceNameOffset}, Length {DeviceNameLength}
    """;
}