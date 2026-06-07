using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 40)]
public struct DriveLayoutGpt
{
    [FieldOffset(0)] public Guid DiskId;
    [FieldOffset(16)] public long StartingUsableOffset;
    [FieldOffset(24)] public long UsableLength;
    [FieldOffset(32)] public uint MaxPartitionCount;
}