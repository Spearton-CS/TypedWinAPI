#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Struct;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.GDI32;

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
    IReadOnlyStructContracts<Color>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is Color other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Color other) => this == other;
    public static bool operator ==(Color a, Color b)
    {
        if (a.Value != b.Value)
            return false;
        if (a.R != b.R)
            return false;
        if (a.G != b.G)
            return false;
        if (a.B != b.B)
            return false;
        if (a.A != b.A)
            return false;

		return true;
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
    /// Raw 32-bit unsigned number underlying this Color
    /// </summary>
    [FieldOffset(0)] public readonly uint Value = 0;
    /// <summary>
    /// Raw 8-bit unsigned number as Red-channel of this Color
    /// </summary>
    [FieldOffset(0)] public readonly byte R;
    /// <summary>
    /// Raw 8-bit unsigned number as Green-channel of this Color
    /// </summary>
    [FieldOffset(1)] public readonly byte G;
    /// <summary>
    /// Raw 8-bit unsigned number as Blue-channel of this Color
    /// </summary>
    [FieldOffset(2)] public readonly byte B;
    /// <summary>
    /// Raw 8-bit unsigned number as Alpha-channel of this Color
    /// </summary>
    [FieldOffset(3)] public readonly byte A;

    #endregion

    #region Functions

    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public  Color(uint value)
		: this()
    {
        Value = value;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public  Color(byte r, byte g, byte b)
		: this(r | ((uint)g << 8) | ((uint)b << 16))
    {
        
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public  Color(byte r, byte g, byte b, byte a)
		: this(r | ((uint)g << 8) | ((uint)b << 16) | ((uint)a << 24))
    {
        
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static Color FromBgr(uint value)
    {
        return new(value);
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static Color FromRgb(uint value)
    {
        return new(
		    ((value >> 16) & 0xFF)
		    | (value & 0x00FF00)
		    | ((value & 0xFF) << 16)
		    | 0xFF000000);
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static Color FromRgba(uint value)
    {
        return new(
		    (value >> 24)
		    | ((value >> 8) & 0xFF00)
		    | ((value << 8) & 0xFF0000)
		    | (value << 24));
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static Color FromArgb(uint value)
    {
        return new(
		    ((value >> 16) & 0xFF)
		    | (value & 0xFF00)
		    | ((value & 0xFF) << 16)
		    | (value & 0xFF000000));
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly uint ToBgr()
    {
        return Value;
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly uint ToRgb()
    {
        return (uint)R << 24 | (uint)G << 16 | (uint)B << 8;
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly uint ToRgba()
    {
        return (uint)R << 24 | (uint)G << 16 | (uint)B | A;
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly uint ToArgb()
    {
        return (uint)A << 24 | (uint)R << 16 | (uint)G << 8 | B;
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator uint (Color gdic)
    {
        return gdic.Value;
    }
    /// <summary>
    /// Function with return type Color
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator Color (uint raw)
    {
        return new(raw);
    }

    #endregion
}
#nullable restore