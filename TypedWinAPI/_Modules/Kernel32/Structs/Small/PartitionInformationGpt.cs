using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 112)]
public unsafe struct PartitionInformationGpt
{
    [FieldOffset(0)] public Guid PartitionType;
    [FieldOffset(16)] public Guid PartitionId;
    [FieldOffset(32)] public PartitionAttributes Attributes;
    [FieldOffset(40)] public fixed char Name[36];
}
