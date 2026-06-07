using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct FsFileZeroDataInformation
{
    [FieldOffset(0)] public long FileOffset;
    [FieldOffset(8)] public long BeyondFinalZero;

    public readonly override string ToString() =>
    $"""
    FileOffset: {FileOffset},
    BeyondFinalZero: {BeyondFinalZero}
    """;
}