#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// --- Custom usings ---
using System.Numerics;
// --- Custom usings ---
using System.Numerics;

namespace TypedWinAPI.GDIPlus;

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 4)
]
public readonly unsafe struct GraphicsContainerState()
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is GraphicsContainerState other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(GraphicsContainerState other) => this == other;
    public static bool operator ==(GraphicsContainerState a, GraphicsContainerState b)
    {
        if (a.Raw != b.Raw)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            GraphicsContainerState: {
                Raw: {{Raw}}
            }
            """;
    }

    public static bool operator !=(GraphicsContainerState a, GraphicsContainerState b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public readonly uint Raw = 0;

    #endregion

    #region Properties

    /// <summary>
    /// Property of type GraphicsContainerState
    /// </summary>
    public static GraphicsContainerState Invalid
    {
		[
		MethodImpl(MethodImplOptions.AggressiveInlining)
		]
        get
        {
            return new(0);
        }
    }

    #endregion

    #region Functions

    /// <summary>
    /// Function with return type GraphicsContainerState
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public GraphicsContainerState (uint raw)
		: this()
    {
        Raw = raw;
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator uint (GraphicsContainerState state)
    {
        return state.Raw;
    }
    /// <summary>
    /// Function with return type GraphicsContainerState
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator GraphicsContainerState (uint raw)
    {
        return new(raw);
    }

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 4)
]
public readonly unsafe struct Color()  :
	// --- Custom contracts ---
	IEqualityOperators<Color, uint, bool>,
	IEquatable<uint>,
	IEqualityOperators<Color, GDI32.Color, bool>,
	IEquatable<GDI32.Color>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is Color other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Color other) => this == other;
    public static bool operator ==(Color a, Color b)
    {
        if (a.Argb != b.Argb)
            return false;
        if (a.B != b.B)
            return false;
        if (a.G != b.G)
            return false;
        if (a.R != b.R)
            return false;
        if (a.A != b.A)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            Color: {
                Argb: {{Argb}}
                B: {{B}}
                G: {{G}}
                R: {{R}}
                A: {{A}}
            }
            """;
    }

    public static bool operator !=(Color a, Color b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public readonly uint Argb = 0;
    /// <summary>
    /// Field of type byte on offset 0
    /// </summary>
    [FieldOffset(0)] public readonly byte B;
    /// <summary>
    /// Field of type byte on offset 1
    /// </summary>
    [FieldOffset(1)] public readonly byte G;
    /// <summary>
    /// Field of type byte on offset 2
    /// </summary>
    [FieldOffset(2)] public readonly byte R;
    /// <summary>
    /// Field of type byte on offset 3
    /// </summary>
    [FieldOffset(3)] public readonly byte A;

    #endregion

    #region Functions

    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public Color (uint argb)
		: this()
    {
        Argb = argb;
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public Color (byte r, byte g, byte b, byte a = 255)
		: this (
    b | ((uint)g << 8) | ((uint)r << 16) | ((uint)a << 24))
    {
        
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static Color FromAbgr(uint abgr)
    {
        return new((abgr & 0xFF00FF00) | ((abgr & 0x00FF0000) >> 16) | ((abgr & 0x000000FF) << 16));
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static Color FromRgba(uint rgba)
    {
        return new((rgba >> 8) | (rgba << 24));
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static Color FromBgra(uint bgra)
    {
        return new((bgra << 24) | (bgra >> 8));
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly uint ToAbgr()
    {
        return (Argb & 0xFF00FF00) | ((Argb & 0x00FF0000) >> 16) | ((Argb & 0x000000FF) << 16);
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly uint ToRgba()
    {
        return (Argb << 8) | A;
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly uint ToBgra()
    {
        return ((uint)B << 24) | ((uint)G << 16) | ((uint)R << 8) | A;
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals(uint other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals(GDI32.Color other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type operator
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator ==(Color left, uint right)
    {
        return left.Argb == right;
    }
    /// <summary>
    /// Function with return type operator
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator !=(Color left, uint right)
    {
        return left.Argb != right;
    }
    /// <summary>
    /// Function with return type operator
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator ==(Color left, GDI32.Color right)
    {
        return left.Argb == right.ToArgb();
    }
    /// <summary>
    /// Function with return type operator
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator !=(Color left, GDI32.Color right)
    {
        return left.Argb != right.ToArgb();
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator uint (Color color)
    {
        return color.Argb;
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator Color (uint argb)
    {
        return new(argb);
    }
    /// <summary>
    /// Function with return type GDI32.Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator GDI32.Color (Color c)
    {
        return new(c.R, c.G, c.B, c.A);
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator Color (GDI32.Color c)
    {
        return new(c.R, c.G, c.B, c.A);
    }

    #endregion
}

/// <summary>
/// Defines the x- and y-coordinates of a point.
/// <remarks>
/// Floating-point 32-bit coordinates
/// </remarks>
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 8)
]
public readonly unsafe struct PointF :
	// --- Custom contracts ---
	IEqualityOperators<PointF, User32.Point, bool>,
	IEquatable<User32.Point>,
	IEqualityOperators<PointF, (float X, float Y), bool>,
	IEquatable<(float X, float Y)>,
	IEqualityOperators<PointF, (int X, int Y), bool>,
	IEquatable<(int X, int Y)>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is PointF other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PointF other) => this == other;
    public static bool operator ==(PointF a, PointF b)
    {
        if (a.X != b.X)
            return false;
        if (a.Y != b.Y)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            PointF: {
                X: {{X}}
                Y: {{Y}}
            }
            """;
    }

    public static bool operator !=(PointF a, PointF b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type float on offset 0
    /// </summary>
    [FieldOffset(0)] public readonly float X;
    /// <summary>
    /// Field of type float on offset 4
    /// </summary>
    [FieldOffset(4)] public readonly float Y;

    #endregion

    #region Functions

    /// <summary>
    /// Function with return type PointF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public PointF ()
    {
        X = 0;
		Y = 0;
    }
    /// <summary>
    /// Function with return type PointF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public PointF (float x, float y)
    {
        X = x;
		Y = y;
    }
    /// <summary>
    /// Function with return type void
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly void Deconstruct(out float x, out float y)
    {
        x = X;
		y = Y;
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals(User32.Point other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals((float X, float Y) other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals((int X, int Y) other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  ==(PointF a, User32.Point b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  !=(PointF a, User32.Point b)
    {
        return a.X != b.X || a.Y != b.Y;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  ==(PointF a, (float X, float Y) b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  !=(PointF a, (float X, float Y) b)
    {
        return a.X != b.X || a.Y != b.Y;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  ==(PointF a, (int X, int Y) b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  !=(PointF a, (int X, int Y) b)
    {
        return a.X != b.X || a.Y != b.Y;
    }
    /// <summary>
    /// Function with return type PointF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static implicit operator PointF (User32.Point other)
    {
        return new(other.X, other.Y);
    }
    /// <summary>
    /// Function with return type User32.Point
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator User32.Point (PointF other)
    {
        return new((int)other.X, (int)other.Y);
    }
    /// <summary>
    /// Function with return type PointF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator PointF ((float X, float Y) other)
    {
        return new(other.X, other.Y);
    }
    /// <summary>
    /// Function with return type (float X, float Y)
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator (float X, float Y) (PointF other)
    {
        return (other.X, other.Y);
    }
    /// <summary>
    /// Function with return type PointF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator PointF ((int X, int Y) other)
    {
        return new(other.X, other.Y);
    }
    /// <summary>
    /// Function with return type (int X, int Y)
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator (int X, int Y) (PointF other)
    {
        return ((int)other.X, (int)other.Y);
    }

    #endregion
}
#nullable restore