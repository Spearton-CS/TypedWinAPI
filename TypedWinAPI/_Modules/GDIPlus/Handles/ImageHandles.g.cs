#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.GDIPlus;

/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over HBitmap
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HBitmap :
	IEqualityOperators<HBitmap, HBitmap, bool>, IEquatable<HBitmap>,
		IEqualityOperators<HBitmap, Handle, bool>, IEquatable<Handle>,
	    IEqualityOperators<HBitmap, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HBitmap, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif
	IComparisonOperators<HBitmap, HBitmap, bool>, IComparable<HBitmap>,
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
	public static explicit operator HBitmap(Handle @base) => new(@base);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nint sig) => new(sig);

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
