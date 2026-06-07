using System.Runtime.InteropServices;

namespace TypedWinAPI.MSimg32;

public static unsafe partial class MSimg32
{
    public const string DLL = "msimg32";

    #region Transparency

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 AlphaBlend(
        GDI32.HDC hdcDest,
        int xDest, int yDest, int wDest, int hDest,
        GDI32.HDC hdcSrc,
        int xSrc, int ySrc, int wSrc, int hSrc,
        BlendFunction blendFunction);

    #endregion

}