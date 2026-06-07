using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

// It is a VRA, so union data immediately follows this 8-byte header in memory.
[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct FsReparseDataBufferHeader
{
    [FieldOffset(0)] public uint ReparseTag;
    [FieldOffset(4)] public ushort ReparseDataLength;
    [FieldOffset(6)] public ushort Reserved;

    public readonly override string ToString() =>
    $"""
    ReparseTag: 0x{ReparseTag:X8},
    ReparseDataLength: {ReparseDataLength}
    """;
}