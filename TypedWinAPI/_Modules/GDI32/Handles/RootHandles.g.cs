#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.GDI32;

/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HDC
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HDC :
	IEqualityOperators<HDC, HDC, bool>, IEquatable<HDC>,
		IEqualityOperators<HDC, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HDC, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HDC, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HDC, HDC, bool>, IComparable<HDC>,
		IComparisonOperators<HDC, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HDC, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HDC, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HDC() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HDC(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HDC(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HDC(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HDC(Handle @base) => PointerValue = @base.PointerValue;
	
	#endregion

	#region Fields

	[FieldOffset(0)] public readonly void* PointerValue;

	[FieldOffset(0)] public readonly nuint UnsignedValue;

	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is HDC other)
			return this == other;
				else if (obj is Handle @Handle)
			return this == @Handle;
				else if (obj is nuint unsig)
			return this == unsig;
		else if (obj is nint sig)
			return this == sig;
		else
			return false;
	}
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HDC other) => this == other;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HDC a, HDC b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HDC a, HDC b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HDC a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HDC a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HDC a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HDC a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HDC a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HDC a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HDC a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HDC a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HDC other)
			return CompareTo(other);
				else if (obj is Handle @Handle)
			return CompareTo(@Handle);
				else if (obj is nuint unsig)
			return CompareTo(unsig);
		else if (obj is nint sig)
			return CompareTo(sig);
		else
			return 0;
	}
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HDC other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HDC a, HDC b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HDC a, HDC b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HDC a, HDC b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HDC a, HDC b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HDC a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HDC a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HDC a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HDC a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HDC a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HDC a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HDC a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HDC a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HDC a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HDC a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HDC a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HDC a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HDC a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HDC a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HDC a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HDC a, nint b) => a.SignedValue >= b;

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
    public static HDC Parse(string s, IFormatProvider? provider = null) => (HDC)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HDC result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HDC, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDC Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HDC)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HDC result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HDC, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDC Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HDC)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HDC result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HDC, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HDC(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HDC(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HDC(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HDC(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HDC self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HDC h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HDC h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HDC h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HObj
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HObj :
	IEqualityOperators<HObj, HObj, bool>, IEquatable<HObj>,
		IEqualityOperators<HObj, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HObj, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HObj, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HObj, HObj, bool>, IComparable<HObj>,
		IComparisonOperators<HObj, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HObj, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HObj, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HObj() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HObj(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HObj(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HObj(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HObj(Handle @base) => PointerValue = @base.PointerValue;
	
	#endregion

	#region Fields

	[FieldOffset(0)] public readonly void* PointerValue;

	[FieldOffset(0)] public readonly nuint UnsignedValue;

	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is HObj other)
			return this == other;
				else if (obj is Handle @Handle)
			return this == @Handle;
				else if (obj is nuint unsig)
			return this == unsig;
		else if (obj is nint sig)
			return this == sig;
		else
			return false;
	}
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HObj other) => this == other;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HObj a, HObj b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HObj a, HObj b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HObj a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HObj a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HObj a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HObj a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HObj a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HObj a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HObj a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HObj a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HObj other)
			return CompareTo(other);
				else if (obj is Handle @Handle)
			return CompareTo(@Handle);
				else if (obj is nuint unsig)
			return CompareTo(unsig);
		else if (obj is nint sig)
			return CompareTo(sig);
		else
			return 0;
	}
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HObj other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HObj a, HObj b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HObj a, HObj b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HObj a, HObj b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HObj a, HObj b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HObj a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HObj a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HObj a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HObj a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HObj a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HObj a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HObj a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HObj a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HObj a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HObj a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HObj a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HObj a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HObj a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HObj a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HObj a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HObj a, nint b) => a.SignedValue >= b;

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
    public static HObj Parse(string s, IFormatProvider? provider = null) => (HObj)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HObj result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HObj, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HObj Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HObj)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HObj result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HObj, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HObj Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HObj)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HObj result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HObj, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HObj(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HObj(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HObj(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HObj(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HObj self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HObj h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HObj h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HObj h) => h.SignedValue;

	#endregion
}

#nullable restore
