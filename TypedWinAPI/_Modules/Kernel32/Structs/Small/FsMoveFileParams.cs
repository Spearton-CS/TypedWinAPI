using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public unsafe struct FsMoveFileParams
{
    [FieldOffset(0)] public void* FileHandle;
    [FieldOffset(8)] public long StartingVcn;
    [FieldOffset(16)] public long StartingLcn;
    [FieldOffset(24)] public uint ClusterCount;

    public readonly override string ToString() =>
    $"""
    FileHandle: 0x{(nuint)FileHandle:X},
    StartingVcn: {StartingVcn},
    StartingLcn: {StartingLcn},
    ClusterCount: {ClusterCount}
    """;
}