using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

/// <summary>
/// Mapped from VIDEO_MODE_INFORMATION (WDK). 
/// This is the standard return structure for video query IOCTLs.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 48)]
public struct VideoModeInformation()
{
    [FieldOffset(0)] public uint Length = 48;
    [FieldOffset(4)] public VideoDisplayMode ModeIndex;
    [FieldOffset(8)] public uint VisScreenWidth;
    [FieldOffset(12)] public uint VisScreenHeight;
    [FieldOffset(16)] public uint BitsPerPlane;
    [FieldOffset(20)] public uint NumberOfPlanes;
    [FieldOffset(24)] public uint Frequency;
    [FieldOffset(28)] public uint XMillimeter;
    [FieldOffset(32)] public uint YMillimeter;
    [FieldOffset(36)] public uint NumberOfButtons;
    [FieldOffset(40)] public uint NumberOfPointerButtons;
    [FieldOffset(44)] public Bool4 Interlaced;

    public override string ToString() => $"Res: {VisScreenWidth}x{VisScreenHeight} @ {Frequency}Hz";
}