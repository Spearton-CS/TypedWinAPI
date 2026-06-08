// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.GDIPlus;

/// <summary>
/// Handle to a GDI+ session token
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HSessionToken :
	// --- Default contracts ---
	IHandleTSelfContracts<HSessionToken>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HSessionToken, Handle>,
	IHandleContracts<HSessionToken>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HSessionToken() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HSessionToken(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HSessionToken(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HSessionToken(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HSessionToken(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HSessionToken MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HSessionToken)Handle.MinValue;
	}

	public static HSessionToken MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HSessionToken)Handle.MaxValue;
	}

	public static HSessionToken Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HSessionToken)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator <<(HSessionToken a, int shift) => (HSessionToken)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator >>(HSessionToken a, int shift) => (HSessionToken)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator >>>(HSessionToken a, int shift) => (HSessionToken)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator &(HSessionToken a, HSessionToken b) => (HSessionToken)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator |(HSessionToken a, HSessionToken b) => (HSessionToken)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator ^(HSessionToken a, HSessionToken b) => (HSessionToken)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator ~(HSessionToken a) => (HSessionToken)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator &(HSessionToken a, Handle b) => (HSessionToken)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator |(HSessionToken a, Handle b) => (HSessionToken)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator ^(HSessionToken a, Handle b) => (HSessionToken)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator &(HSessionToken a, nuint b) => (HSessionToken)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator |(HSessionToken a, nuint b) => (HSessionToken)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator ^(HSessionToken a, nuint b) => (HSessionToken)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator &(HSessionToken a, nint b) => (HSessionToken)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator |(HSessionToken a, nint b) => (HSessionToken)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator ^(HSessionToken a, nint b) => (HSessionToken)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator &(HSessionToken a, void* b) => (HSessionToken)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator |(HSessionToken a, void* b) => (HSessionToken)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken operator ^(HSessionToken a, void* b) => (HSessionToken)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HSessionToken other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HSessionToken other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HSessionToken other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HSessionToken other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HSessionToken a, HSessionToken b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HSessionToken a, HSessionToken b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HSessionToken a, HSessionToken b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HSessionToken a, HSessionToken b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HSessionToken a, HSessionToken b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HSessionToken a, HSessionToken b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HSessionToken a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HSessionToken a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HSessionToken a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HSessionToken a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HSessionToken a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HSessionToken a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HSessionToken a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HSessionToken a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HSessionToken a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HSessionToken a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HSessionToken a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HSessionToken a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HSessionToken a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HSessionToken a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HSessionToken a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HSessionToken a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HSessionToken a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HSessionToken a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HSessionToken a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HSessionToken a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HSessionToken a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HSessionToken a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HSessionToken a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HSessionToken a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken Parse(string s, IFormatProvider? provider = null) => (HSessionToken)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HSessionToken result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HSessionToken, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HSessionToken)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HSessionToken result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HSessionToken, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HSessionToken Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HSessionToken)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HSessionToken result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HSessionToken, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HSessionToken(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HSessionToken h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HSessionToken(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HSessionToken h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HSessionToken(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HSessionToken h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HSessionToken(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HSessionToken h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ pen
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HPen :
	// --- Default contracts ---
	IHandleTSelfContracts<HPen>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HPen, Handle>,
	IHandleContracts<HPen>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPen(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HPen MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HPen)Handle.MinValue;
	}

	public static HPen MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HPen)Handle.MaxValue;
	}

	public static HPen Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HPen)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator <<(HPen a, int shift) => (HPen)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator >>(HPen a, int shift) => (HPen)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator >>>(HPen a, int shift) => (HPen)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator &(HPen a, HPen b) => (HPen)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator |(HPen a, HPen b) => (HPen)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator ^(HPen a, HPen b) => (HPen)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator ~(HPen a) => (HPen)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator &(HPen a, Handle b) => (HPen)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator |(HPen a, Handle b) => (HPen)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator ^(HPen a, Handle b) => (HPen)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator &(HPen a, nuint b) => (HPen)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator |(HPen a, nuint b) => (HPen)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator ^(HPen a, nuint b) => (HPen)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator &(HPen a, nint b) => (HPen)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator |(HPen a, nint b) => (HPen)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator ^(HPen a, nint b) => (HPen)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator &(HPen a, void* b) => (HPen)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator |(HPen a, void* b) => (HPen)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen operator ^(HPen a, void* b) => (HPen)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HPen other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HPen other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HPen other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HPen other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, HPen b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, HPen b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, HPen b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, HPen b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, HPen b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, HPen b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPen a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPen a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPen a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPen a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPen a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPen a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen Parse(string s, IFormatProvider? provider = null) => (HPen)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HPen result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HPen, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HPen)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HPen result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HPen, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPen Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HPen)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HPen result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HPen, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPen(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HPen h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPen(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HPen h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPen(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HPen h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPen(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HPen h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ path
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HPath :
	// --- Default contracts ---
	IHandleTSelfContracts<HPath>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HPath, Handle>,
	IHandleContracts<HPath>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPath() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPath(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPath(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPath(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HPath(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HPath MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HPath)Handle.MinValue;
	}

	public static HPath MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HPath)Handle.MaxValue;
	}

	public static HPath Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HPath)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator <<(HPath a, int shift) => (HPath)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator >>(HPath a, int shift) => (HPath)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator >>>(HPath a, int shift) => (HPath)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator &(HPath a, HPath b) => (HPath)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator |(HPath a, HPath b) => (HPath)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator ^(HPath a, HPath b) => (HPath)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator ~(HPath a) => (HPath)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator &(HPath a, Handle b) => (HPath)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator |(HPath a, Handle b) => (HPath)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator ^(HPath a, Handle b) => (HPath)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator &(HPath a, nuint b) => (HPath)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator |(HPath a, nuint b) => (HPath)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator ^(HPath a, nuint b) => (HPath)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator &(HPath a, nint b) => (HPath)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator |(HPath a, nint b) => (HPath)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator ^(HPath a, nint b) => (HPath)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator &(HPath a, void* b) => (HPath)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator |(HPath a, void* b) => (HPath)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath operator ^(HPath a, void* b) => (HPath)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HPath other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HPath other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HPath other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HPath other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPath a, HPath b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPath a, HPath b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPath a, HPath b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPath a, HPath b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPath a, HPath b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPath a, HPath b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPath a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPath a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPath a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPath a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPath a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPath a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPath a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPath a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPath a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPath a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPath a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPath a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPath a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPath a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPath a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPath a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPath a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPath a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HPath a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HPath a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HPath a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HPath a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HPath a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HPath a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath Parse(string s, IFormatProvider? provider = null) => (HPath)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HPath result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HPath, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HPath)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HPath result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HPath, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPath Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HPath)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HPath result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HPath, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPath(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HPath h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPath(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HPath h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPath(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HPath h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HPath(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HPath h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ matrix
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HMatrix :
	// --- Default contracts ---
	IHandleTSelfContracts<HMatrix>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HMatrix, Handle>,
	IHandleContracts<HMatrix>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMatrix() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMatrix(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMatrix(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMatrix(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HMatrix(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HMatrix MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HMatrix)Handle.MinValue;
	}

	public static HMatrix MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HMatrix)Handle.MaxValue;
	}

	public static HMatrix Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HMatrix)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator <<(HMatrix a, int shift) => (HMatrix)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator >>(HMatrix a, int shift) => (HMatrix)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator >>>(HMatrix a, int shift) => (HMatrix)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator &(HMatrix a, HMatrix b) => (HMatrix)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator |(HMatrix a, HMatrix b) => (HMatrix)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator ^(HMatrix a, HMatrix b) => (HMatrix)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator ~(HMatrix a) => (HMatrix)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator &(HMatrix a, Handle b) => (HMatrix)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator |(HMatrix a, Handle b) => (HMatrix)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator ^(HMatrix a, Handle b) => (HMatrix)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator &(HMatrix a, nuint b) => (HMatrix)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator |(HMatrix a, nuint b) => (HMatrix)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator ^(HMatrix a, nuint b) => (HMatrix)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator &(HMatrix a, nint b) => (HMatrix)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator |(HMatrix a, nint b) => (HMatrix)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator ^(HMatrix a, nint b) => (HMatrix)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator &(HMatrix a, void* b) => (HMatrix)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator |(HMatrix a, void* b) => (HMatrix)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix operator ^(HMatrix a, void* b) => (HMatrix)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HMatrix other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HMatrix other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HMatrix other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HMatrix other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMatrix a, HMatrix b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMatrix a, HMatrix b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMatrix a, HMatrix b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMatrix a, HMatrix b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMatrix a, HMatrix b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMatrix a, HMatrix b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMatrix a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMatrix a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMatrix a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMatrix a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMatrix a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMatrix a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMatrix a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMatrix a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMatrix a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMatrix a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMatrix a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMatrix a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMatrix a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMatrix a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMatrix a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMatrix a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMatrix a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMatrix a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HMatrix a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HMatrix a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HMatrix a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HMatrix a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HMatrix a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HMatrix a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix Parse(string s, IFormatProvider? provider = null) => (HMatrix)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HMatrix result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMatrix, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HMatrix)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HMatrix result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMatrix, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HMatrix Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HMatrix)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HMatrix result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMatrix, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HMatrix(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HMatrix h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HMatrix(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HMatrix h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HMatrix(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HMatrix h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HMatrix(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HMatrix h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ graphics
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HGraphics :
	// --- Default contracts ---
	IHandleTSelfContracts<HGraphics>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HGraphics, Handle>,
	IHandleContracts<HGraphics>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HGraphics() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HGraphics(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HGraphics(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HGraphics(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HGraphics(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HGraphics MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HGraphics)Handle.MinValue;
	}

	public static HGraphics MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HGraphics)Handle.MaxValue;
	}

	public static HGraphics Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HGraphics)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator <<(HGraphics a, int shift) => (HGraphics)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator >>(HGraphics a, int shift) => (HGraphics)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator >>>(HGraphics a, int shift) => (HGraphics)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator &(HGraphics a, HGraphics b) => (HGraphics)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator |(HGraphics a, HGraphics b) => (HGraphics)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator ^(HGraphics a, HGraphics b) => (HGraphics)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator ~(HGraphics a) => (HGraphics)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator &(HGraphics a, Handle b) => (HGraphics)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator |(HGraphics a, Handle b) => (HGraphics)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator ^(HGraphics a, Handle b) => (HGraphics)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator &(HGraphics a, nuint b) => (HGraphics)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator |(HGraphics a, nuint b) => (HGraphics)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator ^(HGraphics a, nuint b) => (HGraphics)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator &(HGraphics a, nint b) => (HGraphics)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator |(HGraphics a, nint b) => (HGraphics)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator ^(HGraphics a, nint b) => (HGraphics)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator &(HGraphics a, void* b) => (HGraphics)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator |(HGraphics a, void* b) => (HGraphics)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics operator ^(HGraphics a, void* b) => (HGraphics)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HGraphics other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HGraphics other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HGraphics other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HGraphics other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HGraphics a, HGraphics b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HGraphics a, HGraphics b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HGraphics a, HGraphics b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HGraphics a, HGraphics b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HGraphics a, HGraphics b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HGraphics a, HGraphics b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HGraphics a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HGraphics a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HGraphics a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HGraphics a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HGraphics a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HGraphics a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HGraphics a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HGraphics a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HGraphics a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HGraphics a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HGraphics a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HGraphics a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HGraphics a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HGraphics a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HGraphics a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HGraphics a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HGraphics a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HGraphics a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HGraphics a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HGraphics a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HGraphics a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HGraphics a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HGraphics a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HGraphics a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics Parse(string s, IFormatProvider? provider = null) => (HGraphics)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HGraphics result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HGraphics, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HGraphics)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HGraphics result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HGraphics, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGraphics Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HGraphics)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HGraphics result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HGraphics, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HGraphics(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HGraphics h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HGraphics(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HGraphics h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HGraphics(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HGraphics h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HGraphics(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HGraphics h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ image
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HImage :
	// --- Default contracts ---
	IHandleTSelfContracts<HImage>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HImage, Handle>,
	IHandleContracts<HImage>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HImage() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HImage(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HImage(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HImage(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HImage(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HImage MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HImage)Handle.MinValue;
	}

	public static HImage MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HImage)Handle.MaxValue;
	}

	public static HImage Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HImage)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator <<(HImage a, int shift) => (HImage)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator >>(HImage a, int shift) => (HImage)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator >>>(HImage a, int shift) => (HImage)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator &(HImage a, HImage b) => (HImage)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator |(HImage a, HImage b) => (HImage)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator ^(HImage a, HImage b) => (HImage)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator ~(HImage a) => (HImage)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator &(HImage a, Handle b) => (HImage)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator |(HImage a, Handle b) => (HImage)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator ^(HImage a, Handle b) => (HImage)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator &(HImage a, nuint b) => (HImage)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator |(HImage a, nuint b) => (HImage)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator ^(HImage a, nuint b) => (HImage)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator &(HImage a, nint b) => (HImage)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator |(HImage a, nint b) => (HImage)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator ^(HImage a, nint b) => (HImage)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator &(HImage a, void* b) => (HImage)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator |(HImage a, void* b) => (HImage)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage operator ^(HImage a, void* b) => (HImage)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HImage other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HImage other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HImage other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HImage other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HImage a, HImage b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HImage a, HImage b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HImage a, HImage b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HImage a, HImage b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HImage a, HImage b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HImage a, HImage b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HImage a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HImage a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HImage a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HImage a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HImage a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HImage a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HImage a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HImage a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HImage a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HImage a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HImage a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HImage a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HImage a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HImage a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HImage a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HImage a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HImage a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HImage a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HImage a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HImage a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HImage a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HImage a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HImage a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HImage a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage Parse(string s, IFormatProvider? provider = null) => (HImage)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HImage result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HImage, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HImage)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HImage result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HImage, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HImage Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HImage)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HImage result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HImage, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HImage(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HImage h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HImage(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HImage h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HImage(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HImage h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HImage(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HImage h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ string format
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HStringFormat :
	// --- Default contracts ---
	IHandleTSelfContracts<HStringFormat>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HStringFormat, Handle>,
	IHandleContracts<HStringFormat>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HStringFormat() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HStringFormat(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HStringFormat(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HStringFormat(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HStringFormat(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HStringFormat MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HStringFormat)Handle.MinValue;
	}

	public static HStringFormat MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HStringFormat)Handle.MaxValue;
	}

	public static HStringFormat Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HStringFormat)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator <<(HStringFormat a, int shift) => (HStringFormat)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator >>(HStringFormat a, int shift) => (HStringFormat)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator >>>(HStringFormat a, int shift) => (HStringFormat)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator &(HStringFormat a, HStringFormat b) => (HStringFormat)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator |(HStringFormat a, HStringFormat b) => (HStringFormat)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator ^(HStringFormat a, HStringFormat b) => (HStringFormat)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator ~(HStringFormat a) => (HStringFormat)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator &(HStringFormat a, Handle b) => (HStringFormat)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator |(HStringFormat a, Handle b) => (HStringFormat)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator ^(HStringFormat a, Handle b) => (HStringFormat)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator &(HStringFormat a, nuint b) => (HStringFormat)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator |(HStringFormat a, nuint b) => (HStringFormat)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator ^(HStringFormat a, nuint b) => (HStringFormat)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator &(HStringFormat a, nint b) => (HStringFormat)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator |(HStringFormat a, nint b) => (HStringFormat)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator ^(HStringFormat a, nint b) => (HStringFormat)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator &(HStringFormat a, void* b) => (HStringFormat)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator |(HStringFormat a, void* b) => (HStringFormat)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat operator ^(HStringFormat a, void* b) => (HStringFormat)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HStringFormat other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HStringFormat other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HStringFormat other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HStringFormat other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HStringFormat a, HStringFormat b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HStringFormat a, HStringFormat b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HStringFormat a, HStringFormat b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HStringFormat a, HStringFormat b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HStringFormat a, HStringFormat b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HStringFormat a, HStringFormat b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HStringFormat a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HStringFormat a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HStringFormat a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HStringFormat a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HStringFormat a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HStringFormat a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HStringFormat a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HStringFormat a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HStringFormat a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HStringFormat a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HStringFormat a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HStringFormat a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HStringFormat a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HStringFormat a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HStringFormat a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HStringFormat a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HStringFormat a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HStringFormat a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HStringFormat a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HStringFormat a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HStringFormat a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HStringFormat a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HStringFormat a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HStringFormat a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat Parse(string s, IFormatProvider? provider = null) => (HStringFormat)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HStringFormat result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HStringFormat, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HStringFormat)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HStringFormat result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HStringFormat, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HStringFormat Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HStringFormat)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HStringFormat result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HStringFormat, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HStringFormat(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HStringFormat h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HStringFormat(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HStringFormat h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HStringFormat(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HStringFormat h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HStringFormat(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HStringFormat h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ brush
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HBrush :
	// --- Default contracts ---
	IHandleTSelfContracts<HBrush>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HBrush, Handle>,
	IHandleContracts<HBrush>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HBrush(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HBrush MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HBrush)Handle.MinValue;
	}

	public static HBrush MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HBrush)Handle.MaxValue;
	}

	public static HBrush Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HBrush)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator <<(HBrush a, int shift) => (HBrush)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator >>(HBrush a, int shift) => (HBrush)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator >>>(HBrush a, int shift) => (HBrush)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator &(HBrush a, HBrush b) => (HBrush)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator |(HBrush a, HBrush b) => (HBrush)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator ^(HBrush a, HBrush b) => (HBrush)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator ~(HBrush a) => (HBrush)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator &(HBrush a, Handle b) => (HBrush)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator |(HBrush a, Handle b) => (HBrush)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator ^(HBrush a, Handle b) => (HBrush)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator &(HBrush a, nuint b) => (HBrush)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator |(HBrush a, nuint b) => (HBrush)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator ^(HBrush a, nuint b) => (HBrush)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator &(HBrush a, nint b) => (HBrush)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator |(HBrush a, nint b) => (HBrush)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator ^(HBrush a, nint b) => (HBrush)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator &(HBrush a, void* b) => (HBrush)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator |(HBrush a, void* b) => (HBrush)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush operator ^(HBrush a, void* b) => (HBrush)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HBrush other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HBrush other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HBrush other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HBrush other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, HBrush b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, HBrush b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, HBrush b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, HBrush b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, HBrush b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, HBrush b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HBrush a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HBrush a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HBrush a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HBrush a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HBrush a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HBrush a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush Parse(string s, IFormatProvider? provider = null) => (HBrush)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HBrush result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HBrush, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HBrush)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HBrush result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HBrush, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBrush Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HBrush)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HBrush result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HBrush, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBrush(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HBrush h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBrush(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HBrush h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBrush(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HBrush h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HBrush(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HBrush h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ font family
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HFontFamily :
	// --- Default contracts ---
	IHandleTSelfContracts<HFontFamily>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HFontFamily, Handle>,
	IHandleContracts<HFontFamily>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontFamily() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontFamily(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontFamily(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontFamily(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontFamily(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HFontFamily MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFontFamily)Handle.MinValue;
	}

	public static HFontFamily MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFontFamily)Handle.MaxValue;
	}

	public static HFontFamily Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFontFamily)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator <<(HFontFamily a, int shift) => (HFontFamily)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator >>(HFontFamily a, int shift) => (HFontFamily)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator >>>(HFontFamily a, int shift) => (HFontFamily)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator &(HFontFamily a, HFontFamily b) => (HFontFamily)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator |(HFontFamily a, HFontFamily b) => (HFontFamily)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator ^(HFontFamily a, HFontFamily b) => (HFontFamily)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator ~(HFontFamily a) => (HFontFamily)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator &(HFontFamily a, Handle b) => (HFontFamily)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator |(HFontFamily a, Handle b) => (HFontFamily)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator ^(HFontFamily a, Handle b) => (HFontFamily)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator &(HFontFamily a, nuint b) => (HFontFamily)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator |(HFontFamily a, nuint b) => (HFontFamily)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator ^(HFontFamily a, nuint b) => (HFontFamily)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator &(HFontFamily a, nint b) => (HFontFamily)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator |(HFontFamily a, nint b) => (HFontFamily)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator ^(HFontFamily a, nint b) => (HFontFamily)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator &(HFontFamily a, void* b) => (HFontFamily)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator |(HFontFamily a, void* b) => (HFontFamily)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily operator ^(HFontFamily a, void* b) => (HFontFamily)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HFontFamily other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HFontFamily other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HFontFamily other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HFontFamily other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontFamily a, HFontFamily b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontFamily a, HFontFamily b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontFamily a, HFontFamily b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontFamily a, HFontFamily b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontFamily a, HFontFamily b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontFamily a, HFontFamily b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontFamily a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontFamily a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontFamily a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontFamily a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontFamily a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontFamily a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontFamily a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontFamily a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontFamily a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontFamily a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontFamily a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontFamily a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontFamily a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontFamily a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontFamily a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontFamily a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontFamily a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontFamily a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontFamily a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontFamily a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontFamily a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontFamily a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontFamily a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontFamily a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily Parse(string s, IFormatProvider? provider = null) => (HFontFamily)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HFontFamily result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFontFamily, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HFontFamily)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HFontFamily result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFontFamily, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontFamily Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HFontFamily)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HFontFamily result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFontFamily, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontFamily(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HFontFamily h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontFamily(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HFontFamily h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontFamily(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HFontFamily h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontFamily(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HFontFamily h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ font collection
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HFontCollection :
	// --- Default contracts ---
	IHandleTSelfContracts<HFontCollection>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HFontCollection, Handle>,
	IHandleContracts<HFontCollection>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontCollection() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontCollection(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontCollection(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontCollection(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFontCollection(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HFontCollection MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFontCollection)Handle.MinValue;
	}

	public static HFontCollection MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFontCollection)Handle.MaxValue;
	}

	public static HFontCollection Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFontCollection)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator <<(HFontCollection a, int shift) => (HFontCollection)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator >>(HFontCollection a, int shift) => (HFontCollection)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator >>>(HFontCollection a, int shift) => (HFontCollection)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator &(HFontCollection a, HFontCollection b) => (HFontCollection)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator |(HFontCollection a, HFontCollection b) => (HFontCollection)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator ^(HFontCollection a, HFontCollection b) => (HFontCollection)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator ~(HFontCollection a) => (HFontCollection)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator &(HFontCollection a, Handle b) => (HFontCollection)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator |(HFontCollection a, Handle b) => (HFontCollection)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator ^(HFontCollection a, Handle b) => (HFontCollection)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator &(HFontCollection a, nuint b) => (HFontCollection)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator |(HFontCollection a, nuint b) => (HFontCollection)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator ^(HFontCollection a, nuint b) => (HFontCollection)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator &(HFontCollection a, nint b) => (HFontCollection)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator |(HFontCollection a, nint b) => (HFontCollection)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator ^(HFontCollection a, nint b) => (HFontCollection)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator &(HFontCollection a, void* b) => (HFontCollection)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator |(HFontCollection a, void* b) => (HFontCollection)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection operator ^(HFontCollection a, void* b) => (HFontCollection)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HFontCollection other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HFontCollection other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HFontCollection other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HFontCollection other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontCollection a, HFontCollection b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontCollection a, HFontCollection b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontCollection a, HFontCollection b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontCollection a, HFontCollection b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontCollection a, HFontCollection b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontCollection a, HFontCollection b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontCollection a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontCollection a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontCollection a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontCollection a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontCollection a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontCollection a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontCollection a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontCollection a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontCollection a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontCollection a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontCollection a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontCollection a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontCollection a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontCollection a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontCollection a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontCollection a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontCollection a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontCollection a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFontCollection a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFontCollection a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFontCollection a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFontCollection a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFontCollection a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFontCollection a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection Parse(string s, IFormatProvider? provider = null) => (HFontCollection)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HFontCollection result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFontCollection, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HFontCollection)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HFontCollection result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFontCollection, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFontCollection Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HFontCollection)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HFontCollection result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFontCollection, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontCollection(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HFontCollection h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontCollection(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HFontCollection h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontCollection(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HFontCollection h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFontCollection(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HFontCollection h) => h.PointerValue;

	#endregion
}

/// <summary>
/// Handle to a GDI+ font
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HFont :
	// --- Default contracts ---
	IHandleTSelfContracts<HFont>,
	// --- Default contracts ---
	IHandleTBaseHandleContracts<HFont, Handle>,
	IHandleContracts<HFont>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont() => HandleValue = default;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(Handle h) => HandleValue = h;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(void* ptr) => PointerValue = ptr;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(nuint unsig) => UnsignedValue = unsig;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HFont(nint sig) => SignedValue = sig;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly Handle HandleValue;
	[FieldOffset(0)] public readonly void* PointerValue;
	[FieldOffset(0)] public readonly nuint UnsignedValue;
	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Math

	public static HFont MinValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFont)Handle.MinValue;
	}

	public static HFont MaxValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFont)Handle.MaxValue;
	}

	public static HFont Zero
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => (HFont)Handle.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator <<(HFont a, int shift) => (HFont)a.HandleValue << shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator >>(HFont a, int shift) => (HFont)a.HandleValue >> shift;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator >>>(HFont a, int shift) => (HFont)a.HandleValue >>> shift;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator &(HFont a, HFont b) => (HFont)(a.UnsignedValue & b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator |(HFont a, HFont b) => (HFont)(a.UnsignedValue | b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator ^(HFont a, HFont b) => (HFont)(a.UnsignedValue ^ b.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator ~(HFont a) => (HFont)~a.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator &(HFont a, Handle b) => (HFont)(a.HandleValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator |(HFont a, Handle b) => (HFont)(a.HandleValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator ^(HFont a, Handle b) => (HFont)(a.HandleValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator &(HFont a, nuint b) => (HFont)(a.UnsignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator |(HFont a, nuint b) => (HFont)(a.UnsignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator ^(HFont a, nuint b) => (HFont)(a.UnsignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator &(HFont a, nint b) => (HFont)(a.SignedValue & b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator |(HFont a, nint b) => (HFont)(a.SignedValue | b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator ^(HFont a, nint b) => (HFont)(a.SignedValue ^ b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator &(HFont a, void* b) => (HFont)(a.UnsignedValue & (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator |(HFont a, void* b) => (HFont)(a.UnsignedValue | (nuint)b);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont operator ^(HFont a, void* b) => (HFont)(a.UnsignedValue ^ (nuint)b);

	#endregion

	#region Equality and Comparability

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is HFont other ? this == other
				: obj is Handle h ? this == h
					: obj is nuint unsig ? this == unsig
						: obj is nint sig && this == sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HFont other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Handle other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nuint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(nint other) => this == other;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(void* other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo([NotNullWhen(true)] object? obj)
		=> obj is HFont other ? CompareTo(other)
				: obj is Handle h ? CompareTo(h)
					: obj is nuint unsig ? CompareTo(unsig)
						: obj is nint sig ? CompareTo(sig) : 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HFont other) => HandleValue.CompareTo(other.HandleValue);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, HFont b) => a.HandleValue == b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, HFont b) => a.HandleValue != b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, HFont b) => a.HandleValue < b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, HFont b) => a.HandleValue > b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, HFont b) => a.HandleValue <= b.HandleValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, HFont b) => a.HandleValue >= b.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, Handle b) => a.HandleValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, Handle b) => a.HandleValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, Handle b) => a.HandleValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, Handle b) => a.HandleValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, Handle b) => a.HandleValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, Handle b) => a.HandleValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, nuint b) => a.UnsignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, nint b) => a.SignedValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, nint b) => a.SignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HFont a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HFont a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HFont a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HFont a, void* b) => a.PointerValue > b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HFont a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HFont a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => HandleValue.GetHashCode();

	#endregion

	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() => HandleValue.ToString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
		=> HandleValue.TryFormat(destination, out written, format, provider);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont Parse(string s, IFormatProvider? provider = null) => (HFont)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(string s, IFormatProvider? provider, scoped out HFont result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFont, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HFont)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HFont result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFont, Handle>(ref result));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFont Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HFont)Handle.Parse(s, provider);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HFont result)
	{
		Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HFont, Handle>(ref result));
	}

	#endregion

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFont(Handle h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HFont h) => h.HandleValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFont(nuint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nuint(HFont h) => h.UnsignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFont(nint h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator nint(HFont h) => h.SignedValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HFont(void* h) => new(h);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator void*(HFont h) => h.PointerValue;

	#endregion
}

