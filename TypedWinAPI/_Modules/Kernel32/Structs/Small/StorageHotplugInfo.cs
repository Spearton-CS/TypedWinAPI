using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct StorageHotplugInfo()
{
    [FieldOffset(0)] public uint Size = 8;
    [FieldOffset(4)] public Bool1 MediaRemovable; // Used as boolean (non-zero = true)
    [FieldOffset(5)] public Bool1 MediaHotplug;
    [FieldOffset(6)] public Bool1 DeviceHotplug;
    [FieldOffset(7)] public Bool1 WriteCacheEnableOverride;

    public readonly override string ToString() =>
    $"""
    Size: {Size},
    MediaRemovable: {MediaRemovable},
    MediaHotplug: {MediaHotplug},
    DeviceHotplug: {DeviceHotplug},
    WriteCacheOverride: {WriteCacheEnableOverride}
    """;
}