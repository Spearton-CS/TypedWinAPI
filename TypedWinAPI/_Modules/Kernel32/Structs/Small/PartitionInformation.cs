using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public struct PartitionInformation
{
    [FieldOffset(0)] public long StartingOffset;
    [FieldOffset(8)] public long PartitionLength;
    [FieldOffset(16)] public uint HiddenSectors;
    [FieldOffset(20)] public uint PartitionNumber;
    [FieldOffset(24)] public PartitionType PartitionType;
    [FieldOffset(25)] public Bool1 BootIndicator;
    [FieldOffset(26)] public Bool1 RecognizedPartition;
    [FieldOffset(27)] public Bool1 RewritePartition;
}
