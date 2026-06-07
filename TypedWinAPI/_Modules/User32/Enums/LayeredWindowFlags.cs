namespace TypedWinAPI.User32;

[Flags]
public enum LayeredWindowFlags : uint
{
    /// <summary> Use crKey as the transparency color. </summary>
    ColorKey = 0x00000001,
    /// <summary> Use bAlpha to determine the opacity of the layered window. </summary>
    Alpha = 0x00000002
}