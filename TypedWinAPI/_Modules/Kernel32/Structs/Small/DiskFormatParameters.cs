using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 20)]
public struct DiskFormatParameters
{
    [FieldOffset(0)] public MediaType MediaType;
    [FieldOffset(4)] public uint StartCylinderNumber;
    [FieldOffset(8)] public uint EndCylinderNumber;
    [FieldOffset(12)] public uint StartHeadNumber;
    [FieldOffset(16)] public uint EndHeadNumber;

    public readonly override string ToString() =>
    $"""
    MediaType: {MediaType},
    StartCylinderNumber: {StartCylinderNumber},
    EndCylinderNumber: {EndCylinderNumber},
    StartHeadNumber: {StartHeadNumber},
    EndHeadNumber: {EndHeadNumber}
    """;
}