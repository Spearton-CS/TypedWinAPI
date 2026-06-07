using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

/// <summary>
/// Represents a color in ARGB format (0xAARRGGBB), as required by GDI+.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 4)]
public readonly record struct Color(
    [field: FieldOffset(0)] uint Argb)
    : IEqualityOperators<Color, Color, bool>, IEquatable<Color>,
    IEqualityOperators<Color, GDI32.Color, bool>, IEquatable<GDI32.Color>
{
    [FieldOffset(0)] public readonly byte B;
    [FieldOffset(1)] public readonly byte G;
    [FieldOffset(2)] public readonly byte R;
    [FieldOffset(3)] public readonly byte A;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Color(byte r, byte g, byte b, byte a = 255) : this(
        b | ((uint)g << 8) | ((uint)r << 16) | ((uint)a << 24))
    { }

    /// <summary> Converts from ABGR (used in some specialized graphics APIs). </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color FromAbgr(uint abgr)
        => new((abgr & 0xFF00FF00) | ((abgr & 0x00FF0000) >> 16) | ((abgr & 0x000000FF) << 16));

    /// <summary> Converts from RGBA layout. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color FromRgba(uint rgba)
        => new((rgba >> 8) | (rgba << 24));

    /// <summary> Converts from BGRA layout. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color FromBgra(uint bgra)
        => new((bgra << 24) | (bgra >> 8));

    /// <summary> Returns the color in ABGR integer format. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToAbgr()
        => (Argb & 0xFF00FF00) | ((Argb & 0x00FF0000) >> 16) | ((Argb & 0x000000FF) << 16);

    /// <summary> Returns the color in RGBA integer format. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToRgba()
        => (Argb << 8) | A;

    /// <summary> Returns the color in BGRA integer format. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToBgra()
        => ((uint)B << 24) | ((uint)G << 16) | ((uint)R << 8) | A;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(GDI32.Color other)
        => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Color left, GDI32.Color right)
        => left.Argb == right.ToArgb();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Color left, GDI32.Color right)
        => left.Argb != right.ToArgb();

    /// <summary> Implicit conversion for easier interoperability. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator uint(Color color) => color.Argb;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Color(uint argb) => new(argb);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GDI32.Color(Color c) => new(c.R, c.G, c.B, c.A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Color(GDI32.Color c) => new(c.R, c.G, c.B, c.A);
}