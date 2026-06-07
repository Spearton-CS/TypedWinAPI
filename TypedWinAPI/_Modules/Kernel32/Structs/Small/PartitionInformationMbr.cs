using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 112)]
public struct PartitionInformationMbr
{
    [FieldOffset(0)] public PartitionType PartitionType;
    [FieldOffset(1)] public Bool1 BootIndicator;
    [FieldOffset(2)] public Bool1 RecognizedPartition;
    [FieldOffset(4)] public uint HiddenSectors;
    [FieldOffset(8)] public Guid PartitionId;
}
