using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public readonly record struct RectF(
    [field: FieldOffset(0)] float X,
    [field: FieldOffset(4)] float Y,
    [field: FieldOffset(8)] float Width,
    [field: FieldOffset(12)] float Height
    )
    : IEqualityOperators<RectF, RectF, bool>, IEquatable<RectF>,
    IEqualityOperators<RectF, User32.Rect, bool>, IEquatable<User32.Rect>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(User32.Rect other)
        => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(RectF left, User32.Rect right)
        => left.X == right.X && left.Y == right.Y
            && left.Width == right.Width && left.Height == right.Height;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(RectF left, User32.Rect right)
        => left.X != right.X || left.Y != right.Y
            || left.Width != right.Width || left.Height != right.Height;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void ToLTBR(out float left, out float top, out float bottom, out float right)
    {
        left = X; top = Y;
        bottom = Y + Height; right = X + Width;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RectF FromLTBR(float left, float top, float bottom, float right)
        => new(left, top, bottom - top, right - left);
}