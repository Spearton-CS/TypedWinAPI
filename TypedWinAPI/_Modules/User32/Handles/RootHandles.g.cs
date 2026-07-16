#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.User32;

/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over Win32 HWND
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HWND :
	IEqualityOperators<HWND, HWND, bool>, IEquatable<HWND>,
	IEqualityOperators<HWND, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<HWND, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HWND, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif

#if ManagedStrings
	IParsable<HWND>, ISpanParsable<HWND>, IUtf8SpanParsable<HWND>,
	IFormattable, ISpanFormattable, IUtf8SpanFormattable,
#endif

	IComparisonOperators<HWND, HWND, bool>, IComparable<HWND>,
	IComparisonOperators<HWND, Handle, bool>, IComparable<Handle>,
    IComparisonOperators<HWND, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HWND, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HWND() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HWND(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HWND(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HWND(nint sig) => SignedValue = sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HWND(Handle @base) => PointerValue = @base.PointerValue;

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
		if (obj is HWND other)
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
	public readonly bool Equals(HWND other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HWND a, HWND b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HWND a, HWND b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HWND a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HWND a, Handle b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HWND a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HWND a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HWND a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HWND a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HWND a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HWND a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HWND other)
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
	public readonly int CompareTo(HWND other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HWND a, HWND b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HWND a, HWND b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HWND a, HWND b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HWND a, HWND b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HWND a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HWND a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HWND a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HWND a, Handle b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HWND a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HWND a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HWND a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HWND a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HWND a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HWND a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HWND a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HWND a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HWND a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HWND a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HWND a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HWND a, nint b) => a.SignedValue >= b;

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
    public static HWND Parse(string s, IFormatProvider? provider = null) => (HWND)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HWND result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HWND, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HWND)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HWND result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HWND, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HWND)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HWND result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HWND, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HWND(Handle @base) => new(@base);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HWND(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HWND(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HWND(nint sig) => new(sig);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HWND self) => new(self.PointerValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HWND h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HWND h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HWND h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over Win32 HMenu
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HMenu :
	IEqualityOperators<HMenu, HMenu, bool>, IEquatable<HMenu>,
	IEqualityOperators<HMenu, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<HMenu, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HMenu, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif

#if ManagedStrings
	IParsable<HMenu>, ISpanParsable<HMenu>, IUtf8SpanParsable<HMenu>,
	IFormattable, ISpanFormattable, IUtf8SpanFormattable,
#endif

	IComparisonOperators<HMenu, HMenu, bool>, IComparable<HMenu>,
	IComparisonOperators<HMenu, Handle, bool>, IComparable<Handle>,
    IComparisonOperators<HMenu, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HMenu, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMenu() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMenu(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMenu(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMenu(nint sig) => SignedValue = sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMenu(Handle @base) => PointerValue = @base.PointerValue;

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
		if (obj is HMenu other)
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
	public readonly bool Equals(HMenu other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMenu a, HMenu b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMenu a, HMenu b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMenu a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMenu a, Handle b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMenu a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMenu a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMenu a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMenu a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMenu a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMenu a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HMenu other)
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
	public readonly int CompareTo(HMenu other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMenu a, HMenu b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMenu a, HMenu b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMenu a, HMenu b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMenu a, HMenu b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMenu a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMenu a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMenu a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMenu a, Handle b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMenu a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMenu a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMenu a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMenu a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMenu a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMenu a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMenu a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMenu a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMenu a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMenu a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMenu a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMenu a, nint b) => a.SignedValue >= b;

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
    public static HMenu Parse(string s, IFormatProvider? provider = null) => (HMenu)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HMenu result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HMenu, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HMenu)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HMenu result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HMenu, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HMenu)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HMenu result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HMenu, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HMenu(Handle @base) => new(@base);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(nint sig) => new(sig);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HMenu self) => new(self.PointerValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HMenu h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HMenu h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HMenu h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over Win32 HCursor
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HCursor :
	IEqualityOperators<HCursor, HCursor, bool>, IEquatable<HCursor>,
	IEqualityOperators<HCursor, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<HCursor, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HCursor, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif

#if ManagedStrings
	IParsable<HCursor>, ISpanParsable<HCursor>, IUtf8SpanParsable<HCursor>,
	IFormattable, ISpanFormattable, IUtf8SpanFormattable,
#endif

	IComparisonOperators<HCursor, HCursor, bool>, IComparable<HCursor>,
	IComparisonOperators<HCursor, Handle, bool>, IComparable<Handle>,
    IComparisonOperators<HCursor, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HCursor, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HCursor() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HCursor(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HCursor(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HCursor(nint sig) => SignedValue = sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HCursor(Handle @base) => PointerValue = @base.PointerValue;

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
		if (obj is HCursor other)
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
	public readonly bool Equals(HCursor other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HCursor a, HCursor b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HCursor a, HCursor b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HCursor a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HCursor a, Handle b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HCursor a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HCursor a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HCursor a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HCursor a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HCursor a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HCursor a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HCursor other)
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
	public readonly int CompareTo(HCursor other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HCursor a, HCursor b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HCursor a, HCursor b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HCursor a, HCursor b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HCursor a, HCursor b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HCursor a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HCursor a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HCursor a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HCursor a, Handle b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HCursor a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HCursor a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HCursor a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HCursor a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HCursor a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HCursor a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HCursor a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HCursor a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HCursor a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HCursor a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HCursor a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HCursor a, nint b) => a.SignedValue >= b;

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
    public static HCursor Parse(string s, IFormatProvider? provider = null) => (HCursor)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HCursor result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HCursor, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HCursor)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HCursor result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HCursor, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HCursor)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HCursor result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HCursor, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HCursor(Handle @base) => new(@base);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(nint sig) => new(sig);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HCursor self) => new(self.PointerValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HCursor h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HCursor h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HCursor h) => h.SignedValue;

	#endregion
}
/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over Win32 HIcon
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HIcon :
	IEqualityOperators<HIcon, HIcon, bool>, IEquatable<HIcon>,
	IEqualityOperators<HIcon, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<HIcon, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HIcon, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif

#if ManagedStrings
	IParsable<HIcon>, ISpanParsable<HIcon>, IUtf8SpanParsable<HIcon>,
	IFormattable, ISpanFormattable, IUtf8SpanFormattable,
#endif

	IComparisonOperators<HIcon, HIcon, bool>, IComparable<HIcon>,
	IComparisonOperators<HIcon, Handle, bool>, IComparable<Handle>,
    IComparisonOperators<HIcon, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HIcon, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HIcon() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HIcon(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HIcon(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HIcon(nint sig) => SignedValue = sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HIcon(Handle @base) => PointerValue = @base.PointerValue;

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
		if (obj is HIcon other)
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
	public readonly bool Equals(HIcon other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HIcon a, HIcon b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HIcon a, HIcon b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HIcon a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HIcon a, Handle b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HIcon a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HIcon a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HIcon a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HIcon a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HIcon a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HIcon a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HIcon other)
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
	public readonly int CompareTo(HIcon other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HIcon a, HIcon b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HIcon a, HIcon b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HIcon a, HIcon b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HIcon a, HIcon b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HIcon a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HIcon a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HIcon a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HIcon a, Handle b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HIcon a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HIcon a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HIcon a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HIcon a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HIcon a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HIcon a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HIcon a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HIcon a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HIcon a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HIcon a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HIcon a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HIcon a, nint b) => a.SignedValue >= b;

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
    public static HIcon Parse(string s, IFormatProvider? provider = null) => (HIcon)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HIcon result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HIcon, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HIcon)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HIcon result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HIcon, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HIcon)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HIcon result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HIcon, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HIcon(Handle @base) => new(@base);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(nint sig) => new(sig);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HIcon self) => new(self.PointerValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HIcon h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HIcon h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HIcon h) => h.SignedValue;

	#endregion
}

#nullable restore
