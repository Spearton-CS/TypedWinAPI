namespace TypedWinAPI.GDI32;

public enum FontOutputPrecision : byte
{
    Default = 0,
    String = 1,
    Character = 2,
    Stroke = 3,
    TrueType = 4,
    Device = 5,
    Raster = 6,
    TrueTypeOnly = 7,
    Outline = 8,
    ScreenOutline = 9,
    PostScriptOnly = 10
}