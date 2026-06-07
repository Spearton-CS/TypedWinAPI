namespace TypedWinAPI.GDIPlus;

public enum TextRenderingHint : int
{
    SystemDefault = 0,
    SingleBitPerPixelGridFit = 1,
    SingleBitPerPixel = 2,
    AntiAliasGridFit = 3,
    AntiAlias = 4,
    ClearTypeGridFit = 5 // Best quality for LCD screens
}