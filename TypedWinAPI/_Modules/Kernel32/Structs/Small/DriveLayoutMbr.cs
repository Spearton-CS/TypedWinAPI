using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 40)]
public struct DriveLayoutMbr
{
    public const uint SignatureConst = 0xAA55;

    [FieldOffset(0)] public uint Signature;
    [FieldOffset(4)] public uint CheckSum;
}
