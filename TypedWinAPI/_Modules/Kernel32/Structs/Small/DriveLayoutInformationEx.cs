using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 192)]
public struct DriveLayoutInformationEx
{
    [FieldOffset(0)] public PartitionStyle PartitionStyle;
    [FieldOffset(4)] public uint PartitionCount;

    [FieldOffset(8)] public DriveLayoutMbr Mbr;
    [FieldOffset(8)] public DriveLayoutGpt Gpt;

    [FieldOffset(48)] public PartitionInformationEx FirstEntry;
}
