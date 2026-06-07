using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

/// <summary>
/// Defines the x- and y-coordinates of a point.
/// </summary>
/// <remarks>
/// Directly compatible with the native Win32 <c>POINT</c> structure.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly record struct Point(
    [field: FieldOffset(0)] int X,
    [field: FieldOffset(4)] int Y)
    : IEqualityOperators<Point, Point, bool>, IEquatable<Point>,
        IAdditionOperators<Point, Size, Point>, ISubtractionOperators<Point, Size, Point>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point operator +(Point left, Size right) => new(left.X + right.Width, left.Y + right.Height);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point operator -(Point left, Size right) => new(left.X - right.Width, left.Y - right.Height);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point operator checked +(Point left, Size right) => new(checked(left.X + right.Width), checked(left.Y + right.Height));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point operator checked -(Point left, Size right) => new(checked(left.X - right.Width), checked(left.Y - right.Height));
}