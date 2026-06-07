using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 144)]
public struct PartitionInformationEx
{
    [FieldOffset(0)] public PartitionStyle PartitionStyle;
    [FieldOffset(8)] public long StartingOffset;
    [FieldOffset(16)] public long PartitionLength;
    [FieldOffset(24)] public uint PartitionNumber;
    [FieldOffset(28)] public Bool1 RewritePartition;

    [FieldOffset(32)] public PartitionInformationMbr Mbr;
    [FieldOffset(32)] public PartitionInformationGpt Gpt;
}
