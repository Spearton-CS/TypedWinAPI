using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipTranslateWorldTransform")]
    public static partial Status TranslateWorldTransform(HGraphics graphics, float dx, float dy, MatrixOrder order);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipScaleWorldTransform")]
    public static partial Status ScaleWorldTransform(HGraphics graphics, float sx, float sy, MatrixOrder order);
}