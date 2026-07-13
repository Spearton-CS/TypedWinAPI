#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.GDI32;

/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HRegion
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HRegion :
	IEqualityOperators<HRegion, HRegion, bool>, IEquatable<HRegion>,
		IEqualityOperators<HRegion, HObj, bool>, IEquatable<HObj>,
		IEqualityOperators<HRegion, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HRegion, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HRegion, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HRegion, HRegion, bool>, IComparable<HRegion>,
		IComparisonOperators<HRegion, HObj, bool>, IComparable<HObj>,
		IComparisonOperators<HRegion, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HRegion, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HRegion, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HRegion() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HRegion(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HRegion(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HRegion(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HRegion(HObj @base) => PointerValue = @base.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HRegion(Handle @base) => PointerValue = @base.PointerValue;
	
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
		if (obj is HRegion other)
			return this == other;
				else if (obj is HObj @HObj)
			return this == @HObj;
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
	public readonly bool Equals(HRegion other) => this == other;
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
	public static bool operator ==(HRegion a, HRegion b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HRegion a, HRegion b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HRegion a, HObj b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HRegion a, HObj b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HRegion a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HRegion a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HRegion a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HRegion a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HRegion a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HRegion a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HRegion a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HRegion a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HRegion other)
			return CompareTo(other);
				else if (obj is HObj @HObj)
			return CompareTo(@HObj);
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
	public readonly int CompareTo(HRegion other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HObj other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HRegion a, HRegion b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HRegion a, HRegion b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HRegion a, HRegion b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HRegion a, HRegion b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HRegion a, HObj b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HRegion a, HObj b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HRegion a, HObj b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HRegion a, HObj b) => a.PointerValue >= b.PointerValue;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HRegion a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HRegion a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HRegion a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HRegion a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HRegion a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HRegion a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HRegion a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HRegion a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HRegion a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HRegion a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HRegion a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HRegion a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HRegion a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HRegion a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HRegion a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HRegion a, nint b) => a.SignedValue >= b;

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
    public static HRegion Parse(string s, IFormatProvider? provider = null) => (HRegion)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HRegion result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HRegion, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HRegion)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HRegion result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HRegion, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HRegion)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HRegion result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HRegion, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HRegion(HObj @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HRegion(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator HObj(HRegion self) => new(self.PointerValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HRegion self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HRegion h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HRegion h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HRegion h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HPen
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HPen :
	IEqualityOperators<HPen, HPen, bool>, IEquatable<HPen>,
		IEqualityOperators<HPen, HObj, bool>, IEquatable<HObj>,
		IEqualityOperators<HPen, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HPen, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HPen, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HPen, HPen, bool>, IComparable<HPen>,
		IComparisonOperators<HPen, HObj, bool>, IComparable<HObj>,
		IComparisonOperators<HPen, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HPen, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HPen, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(HObj @base) => PointerValue = @base.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(Handle @base) => PointerValue = @base.PointerValue;
	
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
		if (obj is HPen other)
			return this == other;
				else if (obj is HObj @HObj)
			return this == @HObj;
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
	public readonly bool Equals(HPen other) => this == other;
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
	public static bool operator ==(HPen a, HPen b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, HPen b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, HObj b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, HObj b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HPen other)
			return CompareTo(other);
				else if (obj is HObj @HObj)
			return CompareTo(@HObj);
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
	public readonly int CompareTo(HPen other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HObj other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, HPen b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, HPen b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, HPen b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, HPen b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, HObj b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, HObj b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, HObj b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, HObj b) => a.PointerValue >= b.PointerValue;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, nint b) => a.SignedValue >= b;

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
    public static HPen Parse(string s, IFormatProvider? provider = null) => (HPen)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HPen result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HPen, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HPen)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HPen result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HPen, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HPen)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HPen result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HPen, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPen(HObj @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPen(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPen(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPen(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPen(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator HObj(HPen self) => new(self.PointerValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HPen self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HPen h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HPen h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HPen h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HPalette
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HPalette :
	IEqualityOperators<HPalette, HPalette, bool>, IEquatable<HPalette>,
		IEqualityOperators<HPalette, HObj, bool>, IEquatable<HObj>,
		IEqualityOperators<HPalette, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HPalette, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HPalette, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HPalette, HPalette, bool>, IComparable<HPalette>,
		IComparisonOperators<HPalette, HObj, bool>, IComparable<HObj>,
		IComparisonOperators<HPalette, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HPalette, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HPalette, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPalette() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPalette(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPalette(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPalette(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPalette(HObj @base) => PointerValue = @base.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPalette(Handle @base) => PointerValue = @base.PointerValue;
	
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
		if (obj is HPalette other)
			return this == other;
				else if (obj is HObj @HObj)
			return this == @HObj;
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
	public readonly bool Equals(HPalette other) => this == other;
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
	public static bool operator ==(HPalette a, HPalette b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPalette a, HPalette b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPalette a, HObj b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPalette a, HObj b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPalette a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPalette a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPalette a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPalette a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPalette a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPalette a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPalette a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPalette a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HPalette other)
			return CompareTo(other);
				else if (obj is HObj @HObj)
			return CompareTo(@HObj);
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
	public readonly int CompareTo(HPalette other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HObj other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPalette a, HPalette b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPalette a, HPalette b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPalette a, HPalette b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPalette a, HPalette b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPalette a, HObj b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPalette a, HObj b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPalette a, HObj b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPalette a, HObj b) => a.PointerValue >= b.PointerValue;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPalette a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPalette a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPalette a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPalette a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPalette a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPalette a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPalette a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPalette a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPalette a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPalette a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPalette a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPalette a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPalette a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPalette a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPalette a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPalette a, nint b) => a.SignedValue >= b;

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
    public static HPalette Parse(string s, IFormatProvider? provider = null) => (HPalette)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HPalette result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HPalette, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HPalette)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HPalette result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HPalette, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HPalette)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HPalette result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HPalette, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPalette(HObj @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPalette(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator HObj(HPalette self) => new(self.PointerValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HPalette self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HPalette h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HPalette h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HPalette h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HFont
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HFont :
	IEqualityOperators<HFont, HFont, bool>, IEquatable<HFont>,
		IEqualityOperators<HFont, HObj, bool>, IEquatable<HObj>,
		IEqualityOperators<HFont, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HFont, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HFont, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HFont, HFont, bool>, IComparable<HFont>,
		IComparisonOperators<HFont, HObj, bool>, IComparable<HObj>,
		IComparisonOperators<HFont, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HFont, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HFont, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(HObj @base) => PointerValue = @base.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(Handle @base) => PointerValue = @base.PointerValue;
	
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
		if (obj is HFont other)
			return this == other;
				else if (obj is HObj @HObj)
			return this == @HObj;
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
	public readonly bool Equals(HFont other) => this == other;
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
	public static bool operator ==(HFont a, HFont b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, HFont b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, HObj b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, HObj b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HFont other)
			return CompareTo(other);
				else if (obj is HObj @HObj)
			return CompareTo(@HObj);
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
	public readonly int CompareTo(HFont other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HObj other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, HFont b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, HFont b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, HFont b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, HFont b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, HObj b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, HObj b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, HObj b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, HObj b) => a.PointerValue >= b.PointerValue;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, nint b) => a.SignedValue >= b;

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
    public static HFont Parse(string s, IFormatProvider? provider = null) => (HFont)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HFont result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HFont, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HFont)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HFont result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HFont, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HFont)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HFont result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HFont, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFont(HObj @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFont(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HFont(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HFont(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HFont(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator HObj(HFont self) => new(self.PointerValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HFont self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HFont h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HFont h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HFont h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HBrush
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HBrush :
	IEqualityOperators<HBrush, HBrush, bool>, IEquatable<HBrush>,
		IEqualityOperators<HBrush, HObj, bool>, IEquatable<HObj>,
		IEqualityOperators<HBrush, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HBrush, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HBrush, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HBrush, HBrush, bool>, IComparable<HBrush>,
		IComparisonOperators<HBrush, HObj, bool>, IComparable<HObj>,
		IComparisonOperators<HBrush, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HBrush, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HBrush, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(HObj @base) => PointerValue = @base.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(Handle @base) => PointerValue = @base.PointerValue;
	
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
		if (obj is HBrush other)
			return this == other;
				else if (obj is HObj @HObj)
			return this == @HObj;
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
	public readonly bool Equals(HBrush other) => this == other;
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
	public static bool operator ==(HBrush a, HBrush b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, HBrush b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, HObj b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, HObj b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HBrush other)
			return CompareTo(other);
				else if (obj is HObj @HObj)
			return CompareTo(@HObj);
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
	public readonly int CompareTo(HBrush other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HObj other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, HBrush b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, HBrush b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, HBrush b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, HBrush b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, HObj b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, HObj b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, HObj b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, HObj b) => a.PointerValue >= b.PointerValue;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, nint b) => a.SignedValue >= b;

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
    public static HBrush Parse(string s, IFormatProvider? provider = null) => (HBrush)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HBrush result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HBrush, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HBrush)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HBrush result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HBrush, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HBrush)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HBrush result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HBrush, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBrush(HObj @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBrush(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBrush(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBrush(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBrush(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator HObj(HBrush self) => new(self.PointerValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HBrush self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HBrush h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HBrush h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HBrush h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HBitmap
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HBitmap :
	IEqualityOperators<HBitmap, HBitmap, bool>, IEquatable<HBitmap>,
		IEqualityOperators<HBitmap, HObj, bool>, IEquatable<HObj>,
		IEqualityOperators<HBitmap, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HBitmap, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HBitmap, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HBitmap, HBitmap, bool>, IComparable<HBitmap>,
		IComparisonOperators<HBitmap, HObj, bool>, IComparable<HObj>,
		IComparisonOperators<HBitmap, Handle, bool>, IComparable<Handle>,
	    IComparisonOperators<HBitmap, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HBitmap, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBitmap() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBitmap(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBitmap(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBitmap(nint sig) => SignedValue = sig;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBitmap(HObj @base) => PointerValue = @base.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBitmap(Handle @base) => PointerValue = @base.PointerValue;
	
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
		if (obj is HBitmap other)
			return this == other;
				else if (obj is HObj @HObj)
			return this == @HObj;
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
	public readonly bool Equals(HBitmap other) => this == other;
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
	public static bool operator ==(HBitmap a, HBitmap b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBitmap a, HBitmap b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBitmap a, HObj b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBitmap a, HObj b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBitmap a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBitmap a, Handle b) => a.PointerValue != b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBitmap a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBitmap a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBitmap a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBitmap a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBitmap a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBitmap a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HBitmap other)
			return CompareTo(other);
				else if (obj is HObj @HObj)
			return CompareTo(@HObj);
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
	public readonly int CompareTo(HBitmap other) => UnsignedValue.CompareTo(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HObj other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBitmap a, HBitmap b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBitmap a, HBitmap b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBitmap a, HBitmap b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBitmap a, HBitmap b) => a.PointerValue >= b.PointerValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBitmap a, HObj b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBitmap a, HObj b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBitmap a, HObj b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBitmap a, HObj b) => a.PointerValue >= b.PointerValue;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBitmap a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBitmap a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBitmap a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBitmap a, Handle b) => a.PointerValue >= b.PointerValue;
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBitmap a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBitmap a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBitmap a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBitmap a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBitmap a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBitmap a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBitmap a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBitmap a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBitmap a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBitmap a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBitmap a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBitmap a, nint b) => a.SignedValue >= b;

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
    public static HBitmap Parse(string s, IFormatProvider? provider = null) => (HBitmap)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HBitmap, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HBitmap)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HBitmap, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HBitmap)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HBitmap, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBitmap(HObj @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBitmap(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nint sig) => new(sig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator HObj(HBitmap self) => new(self.PointerValue);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HBitmap self) => new(self.PointerValue);
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HBitmap h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HBitmap h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HBitmap h) => h.SignedValue;

	#endregion
}

#nullable restore
