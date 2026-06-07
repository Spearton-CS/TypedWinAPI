using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

/// <summary>
/// Defines the x- and y-coordinates of a point.
/// </summary>
/// <remarks>
/// Directly compatible with the native Win32 <c>POINT</c> structure.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly record struct PointF(
    [field: FieldOffset(0)] float X,
    [field: FieldOffset(4)] float Y) :
    IEqualityOperators<PointF, PointF, bool>, IEquatable<PointF>,
    IEqualityOperators<PointF, User32.Point, bool>, IEquatable<User32.Point>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(User32.Point other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PointF left, User32.Point right)
        => left.X == right.X && left.Y == right.Y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PointF left, User32.Point right)
        => left.X != right.X || left.Y != right.Y;
}