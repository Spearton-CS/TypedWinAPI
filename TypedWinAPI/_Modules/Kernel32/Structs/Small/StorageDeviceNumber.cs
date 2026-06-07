using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct StorageDeviceNumber
{
    [FieldOffset(0)] public DeviceType DeviceType;
    [FieldOffset(4)] public uint DeviceNumber;
    [FieldOffset(8)] public uint PartitionNumber;

    public readonly override string ToString() =>
    $"""
    DeviceType: {DeviceType},
    DeviceNumber: {DeviceNumber},
    PartitionNumber: {PartitionNumber}
    """;
}