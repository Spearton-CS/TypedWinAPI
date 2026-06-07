using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct DiskGeometry
{
    [FieldOffset(0)] public long Cylinders;
    [FieldOffset(8)] public MediaType MediaType;
    [FieldOffset(12)] public uint TracksPerCylinder;
    [FieldOffset(16)] public uint SectorsPerTrack;
    [FieldOffset(20)] public uint BytesPerSector;

    public readonly override string ToString() =>
    $$"""
    Cylinders: {{Cylinders}},
    MediaType: {{MediaType}},
    TracksPerCylinder: {{TracksPerCylinder}},
    SectorsPerTrack: {{SectorsPerTrack}},
    BytesPerSector: {{BytesPerSector}}
    """;
}