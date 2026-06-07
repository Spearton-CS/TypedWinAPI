namespace TypedWinAPI.GDIPlus;

[Flags]
public enum FontStyle : int
{
    Regular = 0,
    Bold = 1,
    Italic = 2,
    BoldItalic = 3,
    Underline = 4,
    Strikeout = 8
}