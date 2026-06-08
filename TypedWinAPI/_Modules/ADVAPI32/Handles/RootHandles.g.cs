// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.ADVAPI32;

/// <summary>
/// Handle to an ADVAPI32 registry key
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HKey :
    // --- Default contracts ---
    IHandleTSelfContracts<HKey>,
    IHandleTBaseHandleContracts<HKey, Handle>,
    IHandleContracts<HKey>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HKey() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HKey(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HKey(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HKey(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HKey(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HKey MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HKey)Handle.MinValue;
    }

    public static HKey MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HKey)Handle.MaxValue;
    }

    public static HKey Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HKey)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator <<(HKey a, int shift) => (HKey)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator >>(HKey a, int shift) => (HKey)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator >>>(HKey a, int shift) => (HKey)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator &(HKey a, HKey b) => (HKey)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator |(HKey a, HKey b) => (HKey)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator ^(HKey a, HKey b) => (HKey)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator ~(HKey a) => (HKey)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator &(HKey a, Handle b) => (HKey)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator |(HKey a, Handle b) => (HKey)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator ^(HKey a, Handle b) => (HKey)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator &(HKey a, nuint b) => (HKey)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator |(HKey a, nuint b) => (HKey)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator ^(HKey a, nuint b) => (HKey)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator &(HKey a, nint b) => (HKey)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator |(HKey a, nint b) => (HKey)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator ^(HKey a, nint b) => (HKey)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator &(HKey a, void* b) => (HKey)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator |(HKey a, void* b) => (HKey)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey operator ^(HKey a, void* b) => (HKey)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HKey other ? this == other
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HKey other) => this == other;

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
        => obj is HKey other ? CompareTo(other)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HKey other) => HandleValue.CompareTo(other.HandleValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HKey a, HKey b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HKey a, HKey b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HKey a, HKey b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HKey a, HKey b) => a.HandleValue > b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HKey a, HKey b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HKey a, HKey b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HKey a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HKey a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HKey a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HKey a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HKey a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HKey a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HKey a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HKey a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HKey a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HKey a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HKey a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HKey a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HKey a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HKey a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HKey a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HKey a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HKey a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HKey a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HKey a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HKey a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HKey a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HKey a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HKey a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HKey a, void* b) => a.PointerValue >= b;

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
    public static HKey Parse(string s, IFormatProvider? provider = null) => (HKey)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HKey result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HKey, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HKey)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HKey result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HKey, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HKey Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HKey)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HKey result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HKey, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HKey(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HKey h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HKey(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HKey h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HKey(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HKey h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HKey(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HKey h) => h.PointerValue;

    #endregion
}