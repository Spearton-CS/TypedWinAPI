// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.User32;

/// <summary>
/// Handle to an User32 window
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HWND :
    // --- Default contracts ---
    IHandleTSelfContracts<HWND>,
    IHandleTBaseHandleContracts<HWND, Handle>,
    IHandleContracts<HWND>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HWND() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HWND(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HWND(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HWND(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HWND(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HWND MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HWND)Handle.MinValue;
    }

    public static HWND MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HWND)Handle.MaxValue;
    }

    public static HWND Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HWND)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator <<(HWND a, int shift) => (HWND)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator >>(HWND a, int shift) => (HWND)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator >>>(HWND a, int shift) => (HWND)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator &(HWND a, HWND b) => (HWND)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator |(HWND a, HWND b) => (HWND)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator ^(HWND a, HWND b) => (HWND)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator ~(HWND a) => (HWND)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator &(HWND a, Handle b) => (HWND)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator |(HWND a, Handle b) => (HWND)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator ^(HWND a, Handle b) => (HWND)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator &(HWND a, nuint b) => (HWND)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator |(HWND a, nuint b) => (HWND)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator ^(HWND a, nuint b) => (HWND)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator &(HWND a, nint b) => (HWND)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator |(HWND a, nint b) => (HWND)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator ^(HWND a, nint b) => (HWND)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator &(HWND a, void* b) => (HWND)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator |(HWND a, void* b) => (HWND)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND operator ^(HWND a, void* b) => (HWND)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HWND other ? this == other
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


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
    public readonly int CompareTo([NotNullWhen(true)] object? obj)
        => obj is HWND other ? CompareTo(other)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HWND other) => HandleValue.CompareTo(other.HandleValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HWND a, HWND b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HWND a, HWND b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HWND a, HWND b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HWND a, HWND b) => a.HandleValue > b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HWND a, HWND b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HWND a, HWND b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HWND a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HWND a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HWND a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HWND a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HWND a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HWND a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HWND a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HWND a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HWND a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HWND a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HWND a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HWND a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HWND a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HWND a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HWND a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HWND a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HWND a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HWND a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HWND a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HWND a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HWND a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HWND a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HWND a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HWND a, void* b) => a.PointerValue >= b;

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
    public static HWND Parse(string s, IFormatProvider? provider = null) => (HWND)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HWND result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HWND, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HWND)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HWND result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HWND, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HWND)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HWND result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HWND, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HWND(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HWND h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HWND(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HWND h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HWND(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HWND h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HWND(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HWND h) => h.PointerValue;

    #endregion
}

/// <summary>
/// Handle to an User32 menu
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HMenu :
    // --- Default contracts ---
    IHandleTSelfContracts<HMenu>,
    IHandleTBaseHandleContracts<HMenu, Handle>,
    IHandleContracts<HMenu>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMenu() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMenu(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMenu(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMenu(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMenu(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HMenu MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HMenu)Handle.MinValue;
    }

    public static HMenu MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HMenu)Handle.MaxValue;
    }

    public static HMenu Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HMenu)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator <<(HMenu a, int shift) => (HMenu)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator >>(HMenu a, int shift) => (HMenu)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator >>>(HMenu a, int shift) => (HMenu)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator &(HMenu a, HMenu b) => (HMenu)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator |(HMenu a, HMenu b) => (HMenu)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator ^(HMenu a, HMenu b) => (HMenu)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator ~(HMenu a) => (HMenu)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator &(HMenu a, Handle b) => (HMenu)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator |(HMenu a, Handle b) => (HMenu)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator ^(HMenu a, Handle b) => (HMenu)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator &(HMenu a, nuint b) => (HMenu)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator |(HMenu a, nuint b) => (HMenu)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator ^(HMenu a, nuint b) => (HMenu)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator &(HMenu a, nint b) => (HMenu)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator |(HMenu a, nint b) => (HMenu)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator ^(HMenu a, nint b) => (HMenu)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator &(HMenu a, void* b) => (HMenu)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator |(HMenu a, void* b) => (HMenu)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu operator ^(HMenu a, void* b) => (HMenu)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HMenu other ? this == other
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


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
    public readonly int CompareTo([NotNullWhen(true)] object? obj)
        => obj is HMenu other ? CompareTo(other)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HMenu other) => HandleValue.CompareTo(other.HandleValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HMenu a, HMenu b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HMenu a, HMenu b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HMenu a, HMenu b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HMenu a, HMenu b) => a.HandleValue > b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HMenu a, HMenu b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HMenu a, HMenu b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HMenu a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HMenu a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HMenu a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HMenu a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HMenu a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HMenu a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HMenu a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HMenu a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HMenu a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HMenu a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HMenu a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HMenu a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HMenu a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HMenu a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HMenu a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HMenu a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HMenu a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HMenu a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HMenu a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HMenu a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HMenu a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HMenu a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HMenu a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HMenu a, void* b) => a.PointerValue >= b;

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
    public static HMenu Parse(string s, IFormatProvider? provider = null) => (HMenu)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HMenu result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMenu, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HMenu)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HMenu result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMenu, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMenu Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HMenu)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HMenu result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMenu, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HMenu h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HMenu h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HMenu h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HMenu h) => h.PointerValue;

    #endregion
}

/// <summary>
/// Handle to an User32 cursor
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HCursor :
    // --- Default contracts ---
    IHandleTSelfContracts<HCursor>,
    IHandleTBaseHandleContracts<HCursor, Handle>,
    IHandleContracts<HCursor>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HCursor() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HCursor(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HCursor(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HCursor(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HCursor(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HCursor MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HCursor)Handle.MinValue;
    }

    public static HCursor MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HCursor)Handle.MaxValue;
    }

    public static HCursor Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HCursor)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator <<(HCursor a, int shift) => (HCursor)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator >>(HCursor a, int shift) => (HCursor)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator >>>(HCursor a, int shift) => (HCursor)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator &(HCursor a, HCursor b) => (HCursor)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator |(HCursor a, HCursor b) => (HCursor)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator ^(HCursor a, HCursor b) => (HCursor)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator ~(HCursor a) => (HCursor)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator &(HCursor a, Handle b) => (HCursor)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator |(HCursor a, Handle b) => (HCursor)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator ^(HCursor a, Handle b) => (HCursor)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator &(HCursor a, nuint b) => (HCursor)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator |(HCursor a, nuint b) => (HCursor)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator ^(HCursor a, nuint b) => (HCursor)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator &(HCursor a, nint b) => (HCursor)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator |(HCursor a, nint b) => (HCursor)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator ^(HCursor a, nint b) => (HCursor)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator &(HCursor a, void* b) => (HCursor)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator |(HCursor a, void* b) => (HCursor)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor operator ^(HCursor a, void* b) => (HCursor)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HCursor other ? this == other
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


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
    public readonly int CompareTo([NotNullWhen(true)] object? obj)
        => obj is HCursor other ? CompareTo(other)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HCursor other) => HandleValue.CompareTo(other.HandleValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HCursor a, HCursor b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HCursor a, HCursor b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HCursor a, HCursor b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HCursor a, HCursor b) => a.HandleValue > b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HCursor a, HCursor b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HCursor a, HCursor b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HCursor a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HCursor a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HCursor a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HCursor a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HCursor a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HCursor a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HCursor a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HCursor a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HCursor a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HCursor a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HCursor a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HCursor a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HCursor a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HCursor a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HCursor a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HCursor a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HCursor a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HCursor a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HCursor a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HCursor a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HCursor a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HCursor a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HCursor a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HCursor a, void* b) => a.PointerValue >= b;

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
    public static HCursor Parse(string s, IFormatProvider? provider = null) => (HCursor)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HCursor result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HCursor, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HCursor)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HCursor result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HCursor, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HCursor Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HCursor)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HCursor result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HCursor, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HCursor h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HCursor h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HCursor h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HCursor h) => h.PointerValue;

    #endregion
}

/// <summary>
/// Handle to an User32 icon
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HIcon :
    // --- Default contracts ---
    IHandleTSelfContracts<HIcon>,
    IHandleTBaseHandleContracts<HIcon, Handle>,
    IHandleContracts<HIcon>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HIcon() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HIcon(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HIcon(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HIcon(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HIcon(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HIcon MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HIcon)Handle.MinValue;
    }

    public static HIcon MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HIcon)Handle.MaxValue;
    }

    public static HIcon Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HIcon)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator <<(HIcon a, int shift) => (HIcon)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator >>(HIcon a, int shift) => (HIcon)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator >>>(HIcon a, int shift) => (HIcon)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator &(HIcon a, HIcon b) => (HIcon)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator |(HIcon a, HIcon b) => (HIcon)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator ^(HIcon a, HIcon b) => (HIcon)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator ~(HIcon a) => (HIcon)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator &(HIcon a, Handle b) => (HIcon)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator |(HIcon a, Handle b) => (HIcon)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator ^(HIcon a, Handle b) => (HIcon)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator &(HIcon a, nuint b) => (HIcon)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator |(HIcon a, nuint b) => (HIcon)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator ^(HIcon a, nuint b) => (HIcon)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator &(HIcon a, nint b) => (HIcon)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator |(HIcon a, nint b) => (HIcon)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator ^(HIcon a, nint b) => (HIcon)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator &(HIcon a, void* b) => (HIcon)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator |(HIcon a, void* b) => (HIcon)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon operator ^(HIcon a, void* b) => (HIcon)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HIcon other ? this == other
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


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
    public readonly int CompareTo([NotNullWhen(true)] object? obj)
        => obj is HIcon other ? CompareTo(other)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HIcon other) => HandleValue.CompareTo(other.HandleValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HIcon a, HIcon b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HIcon a, HIcon b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HIcon a, HIcon b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HIcon a, HIcon b) => a.HandleValue > b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HIcon a, HIcon b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HIcon a, HIcon b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HIcon a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HIcon a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HIcon a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HIcon a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HIcon a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HIcon a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HIcon a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HIcon a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HIcon a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HIcon a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HIcon a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HIcon a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HIcon a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HIcon a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HIcon a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HIcon a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HIcon a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HIcon a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HIcon a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HIcon a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HIcon a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HIcon a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HIcon a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HIcon a, void* b) => a.PointerValue >= b;

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
    public static HIcon Parse(string s, IFormatProvider? provider = null) => (HIcon)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HIcon result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HIcon, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HIcon)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HIcon result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HIcon, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HIcon Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HIcon)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HIcon result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HIcon, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HIcon h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HIcon h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HIcon h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HIcon h) => h.PointerValue;

    #endregion
}

