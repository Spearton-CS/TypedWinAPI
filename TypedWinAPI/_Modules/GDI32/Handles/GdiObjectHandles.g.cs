// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.GDI32;

/// <summary>
/// Handle to a GDI32 region object
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HRegion :
    // --- Default contracts ---
    IHandleTSelfContracts<HRegion>,
	IHandleTBaseHandleContracts<HRegion, HObj>,
    IHandleTBaseHandleContracts<HRegion, Handle>,
    IHandleContracts<HRegion>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HRegion() => HObjValue = default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HRegion(HObj h) => HObjValue = h;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HRegion(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HRegion(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HRegion(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HRegion(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

	[FieldOffset(0)] public readonly HObj HObjValue;
    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HRegion MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HRegion)HObj.MinValue;
    }

    public static HRegion MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HRegion)HObj.MaxValue;
    }

    public static HRegion Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HRegion)HObj.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator <<(HRegion a, int shift) => (HRegion)a.HObjValue << shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator >>(HRegion a, int shift) => (HRegion)a.HObjValue >> shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator >>>(HRegion a, int shift) => (HRegion)a.HObjValue >>> shift;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator &(HRegion a, HObj b) => (HRegion)a.HObjValue & b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator |(HRegion a, HObj b) => (HRegion)a.HObjValue | b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator ^(HRegion a, HObj b) => (HRegion)a.HObjValue ^ b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator &(HRegion a, HRegion b) => (HRegion)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator |(HRegion a, HRegion b) => (HRegion)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator ^(HRegion a, HRegion b) => (HRegion)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator ~(HRegion a) => (HRegion)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator &(HRegion a, Handle b) => (HRegion)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator |(HRegion a, Handle b) => (HRegion)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator ^(HRegion a, Handle b) => (HRegion)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator &(HRegion a, nuint b) => (HRegion)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator |(HRegion a, nuint b) => (HRegion)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator ^(HRegion a, nuint b) => (HRegion)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator &(HRegion a, nint b) => (HRegion)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator |(HRegion a, nint b) => (HRegion)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator ^(HRegion a, nint b) => (HRegion)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator &(HRegion a, void* b) => (HRegion)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator |(HRegion a, void* b) => (HRegion)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion operator ^(HRegion a, void* b) => (HRegion)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HRegion other ? this == other
			: obj is HObj @HObj ? this == @HObj
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HObj other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HRegion other) => this == other;

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
        => obj is HRegion other ? CompareTo(other)
			: obj is HObj @HObj ? CompareTo(@HObj)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HObj other) => HObjValue.CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HRegion other) => HObjValue.CompareTo(other.HObjValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HRegion a, HRegion b) => a.HObjValue == b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HRegion a, HRegion b) => a.HObjValue != b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HRegion a, HRegion b) => a.HObjValue < b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HRegion a, HRegion b) => a.HObjValue > b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HRegion a, HRegion b) => a.HObjValue <= b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HRegion a, HRegion b) => a.HObjValue >= b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HRegion a, HObj b) => a.HObjValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HRegion a, HObj b) => a.HObjValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HRegion a, HObj b) => a.HObjValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HRegion a, HObj b) => a.HObjValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HRegion a, HObj b) => a.HObjValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HRegion a, HObj b) => a.HObjValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HRegion a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HRegion a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HRegion a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HRegion a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HRegion a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HRegion a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HRegion a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HRegion a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HRegion a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HRegion a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HRegion a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HRegion a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HRegion a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HRegion a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HRegion a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HRegion a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HRegion a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HRegion a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HRegion a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HRegion a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HRegion a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HRegion a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HRegion a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HRegion a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HObjValue.GetHashCode();

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HObjValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HObjValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion Parse(string s, IFormatProvider? provider = null) => (HRegion)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HRegion result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HRegion, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HRegion)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HRegion result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HRegion, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HRegion Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HRegion)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HRegion result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HRegion, HObj>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(HObj h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HObj(HRegion h) => h.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HRegion h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HRegion h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HRegion h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HRegion(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HRegion h) => h.PointerValue;

    #endregion
}

/// <summary>
/// Handle to a GDI32 pen object
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
	IHandleTBaseHandleContracts<HPen, HObj>,
    IHandleTBaseHandleContracts<HPen, Handle>,
    IHandleContracts<HPen>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPen() => HObjValue = default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPen(HObj h) => HObjValue = h;

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

	[FieldOffset(0)] public readonly HObj HObjValue;
    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HPen MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HPen)HObj.MinValue;
    }

    public static HPen MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HPen)HObj.MaxValue;
    }

    public static HPen Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HPen)HObj.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen operator <<(HPen a, int shift) => (HPen)a.HObjValue << shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen operator >>(HPen a, int shift) => (HPen)a.HObjValue >> shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen operator >>>(HPen a, int shift) => (HPen)a.HObjValue >>> shift;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen operator &(HPen a, HObj b) => (HPen)a.HObjValue & b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen operator |(HPen a, HObj b) => (HPen)a.HObjValue | b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen operator ^(HPen a, HObj b) => (HPen)a.HObjValue ^ b;

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
			: obj is HObj @HObj ? this == @HObj
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HObj other) => this == other;

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
			: obj is HObj @HObj ? CompareTo(@HObj)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HObj other) => HObjValue.CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HPen other) => HObjValue.CompareTo(other.HObjValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HPen a, HPen b) => a.HObjValue == b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HPen a, HPen b) => a.HObjValue != b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HPen a, HPen b) => a.HObjValue < b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HPen a, HPen b) => a.HObjValue > b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HPen a, HPen b) => a.HObjValue <= b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HPen a, HPen b) => a.HObjValue >= b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HPen a, HObj b) => a.HObjValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HPen a, HObj b) => a.HObjValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HPen a, HObj b) => a.HObjValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HPen a, HObj b) => a.HObjValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HPen a, HObj b) => a.HObjValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HPen a, HObj b) => a.HObjValue >= b;

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


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HPen a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HPen a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HPen a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HPen a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HPen a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HPen a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HPen a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HPen a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HPen a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HPen a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HPen a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HPen a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HPen a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HPen a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HPen a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HPen a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HPen a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HPen a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HObjValue.GetHashCode();

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HObjValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HObjValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen Parse(string s, IFormatProvider? provider = null) => (HPen)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HPen result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HPen, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HPen)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HPen result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HPen, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPen Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HPen)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HPen result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HPen, HObj>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPen(HObj h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HObj(HPen h) => h.HObjValue;

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
/// Handle to a GDI32 palette object
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HPalette :
    // --- Default contracts ---
    IHandleTSelfContracts<HPalette>,
	IHandleTBaseHandleContracts<HPalette, HObj>,
    IHandleTBaseHandleContracts<HPalette, Handle>,
    IHandleContracts<HPalette>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPalette() => HObjValue = default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPalette(HObj h) => HObjValue = h;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPalette(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPalette(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPalette(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HPalette(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

	[FieldOffset(0)] public readonly HObj HObjValue;
    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HPalette MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HPalette)HObj.MinValue;
    }

    public static HPalette MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HPalette)HObj.MaxValue;
    }

    public static HPalette Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HPalette)HObj.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator <<(HPalette a, int shift) => (HPalette)a.HObjValue << shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator >>(HPalette a, int shift) => (HPalette)a.HObjValue >> shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator >>>(HPalette a, int shift) => (HPalette)a.HObjValue >>> shift;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator &(HPalette a, HObj b) => (HPalette)a.HObjValue & b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator |(HPalette a, HObj b) => (HPalette)a.HObjValue | b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator ^(HPalette a, HObj b) => (HPalette)a.HObjValue ^ b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator &(HPalette a, HPalette b) => (HPalette)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator |(HPalette a, HPalette b) => (HPalette)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator ^(HPalette a, HPalette b) => (HPalette)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator ~(HPalette a) => (HPalette)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator &(HPalette a, Handle b) => (HPalette)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator |(HPalette a, Handle b) => (HPalette)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator ^(HPalette a, Handle b) => (HPalette)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator &(HPalette a, nuint b) => (HPalette)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator |(HPalette a, nuint b) => (HPalette)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator ^(HPalette a, nuint b) => (HPalette)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator &(HPalette a, nint b) => (HPalette)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator |(HPalette a, nint b) => (HPalette)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator ^(HPalette a, nint b) => (HPalette)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator &(HPalette a, void* b) => (HPalette)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator |(HPalette a, void* b) => (HPalette)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette operator ^(HPalette a, void* b) => (HPalette)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HPalette other ? this == other
			: obj is HObj @HObj ? this == @HObj
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HObj other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HPalette other) => this == other;

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
        => obj is HPalette other ? CompareTo(other)
			: obj is HObj @HObj ? CompareTo(@HObj)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HObj other) => HObjValue.CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HPalette other) => HObjValue.CompareTo(other.HObjValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HPalette a, HPalette b) => a.HObjValue == b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HPalette a, HPalette b) => a.HObjValue != b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HPalette a, HPalette b) => a.HObjValue < b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HPalette a, HPalette b) => a.HObjValue > b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HPalette a, HPalette b) => a.HObjValue <= b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HPalette a, HPalette b) => a.HObjValue >= b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HPalette a, HObj b) => a.HObjValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HPalette a, HObj b) => a.HObjValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HPalette a, HObj b) => a.HObjValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HPalette a, HObj b) => a.HObjValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HPalette a, HObj b) => a.HObjValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HPalette a, HObj b) => a.HObjValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HPalette a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HPalette a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HPalette a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HPalette a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HPalette a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HPalette a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HPalette a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HPalette a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HPalette a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HPalette a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HPalette a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HPalette a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HPalette a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HPalette a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HPalette a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HPalette a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HPalette a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HPalette a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HPalette a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HPalette a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HPalette a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HPalette a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HPalette a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HPalette a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HObjValue.GetHashCode();

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HObjValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HObjValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette Parse(string s, IFormatProvider? provider = null) => (HPalette)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HPalette result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HPalette, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HPalette)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HPalette result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HPalette, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HPalette Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HPalette)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HPalette result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HPalette, HObj>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(HObj h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HObj(HPalette h) => h.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HPalette h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HPalette h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HPalette h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HPalette(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HPalette h) => h.PointerValue;

    #endregion
}

/// <summary>
/// Handle to a GDI32 font object
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
	IHandleTBaseHandleContracts<HFont, HObj>,
    IHandleTBaseHandleContracts<HFont, Handle>,
    IHandleContracts<HFont>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HFont() => HObjValue = default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HFont(HObj h) => HObjValue = h;

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

	[FieldOffset(0)] public readonly HObj HObjValue;
    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HFont MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HFont)HObj.MinValue;
    }

    public static HFont MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HFont)HObj.MaxValue;
    }

    public static HFont Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HFont)HObj.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont operator <<(HFont a, int shift) => (HFont)a.HObjValue << shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont operator >>(HFont a, int shift) => (HFont)a.HObjValue >> shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont operator >>>(HFont a, int shift) => (HFont)a.HObjValue >>> shift;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont operator &(HFont a, HObj b) => (HFont)a.HObjValue & b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont operator |(HFont a, HObj b) => (HFont)a.HObjValue | b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont operator ^(HFont a, HObj b) => (HFont)a.HObjValue ^ b;

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
			: obj is HObj @HObj ? this == @HObj
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HObj other) => this == other;

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
			: obj is HObj @HObj ? CompareTo(@HObj)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HObj other) => HObjValue.CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HFont other) => HObjValue.CompareTo(other.HObjValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HFont a, HFont b) => a.HObjValue == b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HFont a, HFont b) => a.HObjValue != b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HFont a, HFont b) => a.HObjValue < b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HFont a, HFont b) => a.HObjValue > b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HFont a, HFont b) => a.HObjValue <= b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HFont a, HFont b) => a.HObjValue >= b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HFont a, HObj b) => a.HObjValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HFont a, HObj b) => a.HObjValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HFont a, HObj b) => a.HObjValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HFont a, HObj b) => a.HObjValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HFont a, HObj b) => a.HObjValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HFont a, HObj b) => a.HObjValue >= b;

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


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HFont a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HFont a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HFont a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HFont a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HFont a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HFont a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HFont a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HFont a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HFont a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HFont a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HFont a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HFont a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HFont a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HFont a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HFont a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HFont a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HFont a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HFont a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HObjValue.GetHashCode();

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HObjValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HObjValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont Parse(string s, IFormatProvider? provider = null) => (HFont)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HFont result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HFont, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HFont)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HFont result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HFont, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HFont Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HFont)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HFont result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HFont, HObj>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HFont(HObj h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HObj(HFont h) => h.HObjValue;

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

/// <summary>
/// Handle to a GDI32 brush object
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
	IHandleTBaseHandleContracts<HBrush, HObj>,
    IHandleTBaseHandleContracts<HBrush, Handle>,
    IHandleContracts<HBrush>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBrush() => HObjValue = default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBrush(HObj h) => HObjValue = h;

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

	[FieldOffset(0)] public readonly HObj HObjValue;
    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HBrush MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBrush)HObj.MinValue;
    }

    public static HBrush MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBrush)HObj.MaxValue;
    }

    public static HBrush Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBrush)HObj.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush operator <<(HBrush a, int shift) => (HBrush)a.HObjValue << shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush operator >>(HBrush a, int shift) => (HBrush)a.HObjValue >> shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush operator >>>(HBrush a, int shift) => (HBrush)a.HObjValue >>> shift;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush operator &(HBrush a, HObj b) => (HBrush)a.HObjValue & b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush operator |(HBrush a, HObj b) => (HBrush)a.HObjValue | b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush operator ^(HBrush a, HObj b) => (HBrush)a.HObjValue ^ b;

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
			: obj is HObj @HObj ? this == @HObj
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HObj other) => this == other;

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
			: obj is HObj @HObj ? CompareTo(@HObj)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HObj other) => HObjValue.CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HBrush other) => HObjValue.CompareTo(other.HObjValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBrush a, HBrush b) => a.HObjValue == b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBrush a, HBrush b) => a.HObjValue != b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBrush a, HBrush b) => a.HObjValue < b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBrush a, HBrush b) => a.HObjValue > b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBrush a, HBrush b) => a.HObjValue <= b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBrush a, HBrush b) => a.HObjValue >= b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBrush a, HObj b) => a.HObjValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBrush a, HObj b) => a.HObjValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBrush a, HObj b) => a.HObjValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBrush a, HObj b) => a.HObjValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBrush a, HObj b) => a.HObjValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBrush a, HObj b) => a.HObjValue >= b;

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


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HBrush a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HBrush a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HBrush a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HBrush a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HBrush a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HBrush a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HBrush a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HBrush a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HBrush a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HBrush a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HBrush a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HBrush a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HBrush a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HBrush a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HBrush a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HBrush a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HBrush a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HBrush a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HObjValue.GetHashCode();

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HObjValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HObjValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush Parse(string s, IFormatProvider? provider = null) => (HBrush)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HBrush result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HBrush, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HBrush)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HBrush result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HBrush, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBrush Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HBrush)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HBrush result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HBrush, HObj>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBrush(HObj h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HObj(HBrush h) => h.HObjValue;

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
/// Handle to a GDI32 bitmap object
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HBitmap :
    // --- Default contracts ---
    IHandleTSelfContracts<HBitmap>,
	IHandleTBaseHandleContracts<HBitmap, HObj>,
    IHandleTBaseHandleContracts<HBitmap, Handle>,
    IHandleContracts<HBitmap>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap() => HObjValue = default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap(HObj h) => HObjValue = h;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

	[FieldOffset(0)] public readonly HObj HObjValue;
    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HBitmap MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBitmap)HObj.MinValue;
    }

    public static HBitmap MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBitmap)HObj.MaxValue;
    }

    public static HBitmap Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBitmap)HObj.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator <<(HBitmap a, int shift) => (HBitmap)a.HObjValue << shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator >>(HBitmap a, int shift) => (HBitmap)a.HObjValue >> shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator >>>(HBitmap a, int shift) => (HBitmap)a.HObjValue >>> shift;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, HObj b) => (HBitmap)a.HObjValue & b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, HObj b) => (HBitmap)a.HObjValue | b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, HObj b) => (HBitmap)a.HObjValue ^ b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, HBitmap b) => (HBitmap)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, HBitmap b) => (HBitmap)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, HBitmap b) => (HBitmap)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ~(HBitmap a) => (HBitmap)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, Handle b) => (HBitmap)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, Handle b) => (HBitmap)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, Handle b) => (HBitmap)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, nuint b) => (HBitmap)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, nuint b) => (HBitmap)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, nuint b) => (HBitmap)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, nint b) => (HBitmap)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, nint b) => (HBitmap)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, nint b) => (HBitmap)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, void* b) => (HBitmap)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, void* b) => (HBitmap)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, void* b) => (HBitmap)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HBitmap other ? this == other
			: obj is HObj @HObj ? this == @HObj
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HObj other) => this == other;

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
    public readonly int CompareTo([NotNullWhen(true)] object? obj)
        => obj is HBitmap other ? CompareTo(other)
			: obj is HObj @HObj ? CompareTo(@HObj)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HObj other) => HObjValue.CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HBitmap other) => HObjValue.CompareTo(other.HObjValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, HBitmap b) => a.HObjValue == b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, HBitmap b) => a.HObjValue != b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBitmap a, HBitmap b) => a.HObjValue < b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBitmap a, HBitmap b) => a.HObjValue > b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBitmap a, HBitmap b) => a.HObjValue <= b.HObjValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBitmap a, HBitmap b) => a.HObjValue >= b.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, HObj b) => a.HObjValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, HObj b) => a.HObjValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBitmap a, HObj b) => a.HObjValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBitmap a, HObj b) => a.HObjValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBitmap a, HObj b) => a.HObjValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBitmap a, HObj b) => a.HObjValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBitmap a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBitmap a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBitmap a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBitmap a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HBitmap a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HBitmap a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HBitmap a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HBitmap a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HBitmap a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HBitmap a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HBitmap a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HBitmap a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HBitmap a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HBitmap a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HBitmap a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HBitmap a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HBitmap a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HBitmap a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HBitmap a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HBitmap a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HBitmap a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HBitmap a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HObjValue.GetHashCode();

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HObjValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HObjValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HObjValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(string s, IFormatProvider? provider = null) => (HBitmap)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HBitmap, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HBitmap)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HBitmap, HObj>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HBitmap)HObj.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
		return HObj.TryParse(s, provider, out Unsafe.As<HBitmap, HObj>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(HObj h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HObj(HBitmap h) => h.HObjValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HBitmap h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HBitmap h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HBitmap h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HBitmap h) => h.PointerValue;

    #endregion
}

