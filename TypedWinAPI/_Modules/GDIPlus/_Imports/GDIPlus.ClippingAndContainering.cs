using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    #region Clip

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetClipRectI")]
    public static partial int SetClipRect(HGraphics graphics, int x, int y, int w, int h, CombineMode combineMode);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetClipRect")]
    public static partial int SetClipRect(HGraphics graphics, float x, float y, float w, float h, CombineMode combineMode);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipResetClip")]
    public static partial int ResetClip(HGraphics graphics);

    #endregion

    #region Container

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipBeginContainer")]
    public static partial Status BeginContainer(HGraphics graphics, in RectF dstRect, in RectF srcRect, Unit unit, out GraphicsContainerState state);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipEndContainer")]
    public static partial Status EndContainer(HGraphics graphics, GraphicsContainerState state);

    #endregion
}