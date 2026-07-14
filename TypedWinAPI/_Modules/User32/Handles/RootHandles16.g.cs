#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.User32;

/// <summary>
/// Struct over <see cref="ushort"/>, or <see cref="ushort"/> or <see langword="void"/>*. Abstraction over ATOM
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 2),
	DebuggerDisplay("{UnsignedValue.ToString(\"X4\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct ATOM :
	IEqualityOperators<ATOM, ATOM, bool>, IEquatable<ATOM>,
		IEqualityOperators<ATOM, Handle16, bool>, IEquatable<Handle16>,
	    IEqualityOperators<ATOM, ushort, bool>, IEquatable<ushort>,
    IEqualityOperators<ATOM, short, bool>, IEquatable<short>,

#if ManagedObjects
	IComparable,
#endif

#if ManagedStrings
	IParsable<ATOM>, ISpanParsable<ATOM>, IUtf8SpanParsable<ATOM>,
	IFormattable, ISpanFormattable, IUtf8SpanFormattable,
#endif

	IComparisonOperators<ATOM, ATOM, bool>, IComparable<ATOM>,
		IComparisonOperators<ATOM, Handle16, bool>, IComparable<Handle16>,
	    IComparisonOperators<ATOM, ushort, bool>, IComparable<ushort>,
    IComparisonOperators<ATOM, short, bool>, IComparable<short>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ATOM() => UnsignedValue = 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ATOM(ushort unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ATOM(short sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ATOM(Handle16 @base) => UnsignedValue = @base.UnsignedValue;
	
	#endregion

	#region Fields

	[FieldOffset(0)] public readonly ushort UnsignedValue;

	[FieldOffset(0)] public readonly short SignedValue;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is ATOM other)
			return this == other;
				else if (obj is Handle16 @Handle16)
			return this == @Handle16;
				else if (obj is ushort unsig)
			return this == unsig;
		else if (obj is short sig)
			return this == sig;
		else
			return false;
	}
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(ATOM other) => this == other;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle16 other) => this == other;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(ushort other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(short other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(ATOM a, ATOM b) => a.UnsignedValue == b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(ATOM a, ATOM b) => a.UnsignedValue != b.UnsignedValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(ATOM a, Handle16 b) => a.UnsignedValue == b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(ATOM a, Handle16 b) => a.UnsignedValue != b.UnsignedValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(ATOM a, ushort b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(ATOM a, ushort b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(ATOM a, short b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(ATOM a, short b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is ATOM other)
			return CompareTo(other);
				else if (obj is Handle16 @Handle16)
			return CompareTo(@Handle16);
				else if (obj is ushort unsig)
			return CompareTo(unsig);
		else if (obj is short sig)
			return CompareTo(sig);
		else
			return 0;
	}
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(ATOM other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle16 other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(ushort other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(short other) => SignedValue.CompareTo(other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(ATOM a, ATOM b) => a.UnsignedValue < b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(ATOM a, ATOM b) => a.UnsignedValue > b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(ATOM a, ATOM b) => a.UnsignedValue <= b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(ATOM a, ATOM b) => a.UnsignedValue >= b.UnsignedValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(ATOM a, Handle16 b) => a.UnsignedValue < b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(ATOM a, Handle16 b) => a.UnsignedValue > b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(ATOM a, Handle16 b) => a.UnsignedValue <= b.UnsignedValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(ATOM a, Handle16 b) => a.UnsignedValue >= b.UnsignedValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(ATOM a, ushort b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(ATOM a, ushort b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(ATOM a, ushort b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(ATOM a, ushort b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(ATOM a, short b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(ATOM a, short b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(ATOM a, short b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(ATOM a, short b) => a.SignedValue >= b;

	#endregion

#if ManagedStrings
	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => UnsignedValue.ToString("X16");
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => UnsignedValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => UnsignedValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => UnsignedValue.TryFormat(destination, out written, format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM Parse(string s, IFormatProvider? provider = null) => (ATOM)ushort.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out ATOM result)
    {
        Unsafe.SkipInit(out result);
        return ushort.TryParse(s, provider, out Unsafe.As<ATOM, ushort>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (ATOM)ushort.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out ATOM result)
    {
        Unsafe.SkipInit(out result);
        return ushort.TryParse(s, provider, out Unsafe.As<ATOM, ushort>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (ATOM)ushort.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out ATOM result)
    {
        Unsafe.SkipInit(out result);
        return ushort.TryParse(s, provider, out Unsafe.As<ATOM, ushort>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator ATOM(Handle16 @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(void* ptr) => new((ushort)ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(ushort unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(short sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle16(ATOM self) => new(self.UnsignedValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(ATOM h) => (void*)h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ushort(ATOM h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator short(ATOM h) => h.SignedValue;

	#endregion
}

#nullable restore
