namespace TypedWinAPI.User32;

[Flags]
public enum UpdateLayeredWindowFlags : uint
{
    ColorKey = 0x00000001, // ULW_COLORKEY
    Alpha = 0x00000002, // ULW_ALPHA
    Opaque = 0x00000004, // ULW_OPAQUE
    ExAlpha = 0x00000008  // ULW_EXALPHA
}