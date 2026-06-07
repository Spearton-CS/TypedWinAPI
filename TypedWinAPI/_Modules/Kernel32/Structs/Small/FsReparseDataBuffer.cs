using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct FsReparseDataBuffer
{
    // --- Common Header (8 bytes) ---
    [FieldOffset(0)] public FsReparseTag ReparseTag;
    [FieldOffset(4)] public ushort ReparseDataLength;
    [FieldOffset(6)] public ushort Reserved;

    // --- UNION 1: Symbolic Link Buffer ---
    [FieldOffset(8)] public ushort SymlinkSubstituteNameOffset;
    [FieldOffset(10)] public ushort SymlinkSubstituteNameLength;
    [FieldOffset(12)] public ushort SymlinkPrintNameOffset;
    [FieldOffset(14)] public ushort SymlinkPrintNameLength;
    [FieldOffset(16)] public uint SymlinkFlags;
    // (Path buffer physically starts at offset 20)

    // --- UNION 2: Mount Point (Junction) Buffer ---
    [FieldOffset(8)] public ushort MountPointSubstituteNameOffset;
    [FieldOffset(10)] public ushort MountPointSubstituteNameLength;
    [FieldOffset(12)] public ushort MountPointPrintNameOffset;
    [FieldOffset(14)] public ushort MountPointPrintNameLength;
    // (Path buffer physically starts at offset 16)

    public readonly override string ToString() =>
    $"""
    ReparseTag: 0x{ReparseTag:X8},
    DataLength: {ReparseDataLength}
    """;
}