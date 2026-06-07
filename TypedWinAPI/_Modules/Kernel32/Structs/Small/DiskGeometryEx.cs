using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public struct DiskGeometryEx
{
    [FieldOffset(0)] public DiskGeometry Geometry;
    [FieldOffset(24)] public long DiskSize;

    public readonly override string ToString() =>
    $$"""
    {{Geometry}},
    DiskSize: {{DiskSize}}
    """;
}