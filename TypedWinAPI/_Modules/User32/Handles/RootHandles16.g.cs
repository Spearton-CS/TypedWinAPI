#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

/// <summary>
/// Handle16 to an User32 ...
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 2),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct ATOM
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ATOM() => Handle16Value = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ATOM(Handle16 h) => Handle16Value = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ATOM(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ATOM(ushort unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ATOM(short sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle16 Handle16Value;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly ushort UnsignedValue;
    [FieldOffset(0)] public readonly short SignedValue;

    #endregion

    #region Math

    public static ATOM MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ATOM)Handle16.MinValue;
    }

    public static ATOM MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ATOM)Handle16.MaxValue;
    }

    public static ATOM Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ATOM)Handle16.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator <<(ATOM a, int shift) => (ATOM)(ushort)(a.Handle16Value << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator >>(ATOM a, int shift) => (ATOM)(ushort)(a.Handle16Value >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator >>>(ATOM a, int shift) => (ATOM)(ushort)(a.Handle16Value >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator &(ATOM a, ATOM b) => (ATOM)(ushort)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator |(ATOM a, ATOM b) => (ATOM)(ushort)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator ^(ATOM a, ATOM b) => (ATOM)(ushort)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator ~(ATOM a) => (ATOM)(ushort)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator &(ATOM a, Handle16 b) => (ATOM)(a.Handle16Value & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator |(ATOM a, Handle16 b) => (ATOM)(a.Handle16Value | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator ^(ATOM a, Handle16 b) => (ATOM)(a.Handle16Value ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator &(ATOM a, ushort b) => (ATOM)(ushort)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator |(ATOM a, ushort b) => (ATOM)(ushort)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator ^(ATOM a, ushort b) => (ATOM)(ushort)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator &(ATOM a, short b) => (ATOM)(short)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator |(ATOM a, short b) => (ATOM)(short)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator ^(ATOM a, short b) => (ATOM)(short)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator &(ATOM a, void* b) => (ATOM)(ushort)(a.UnsignedValue & (ushort)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator |(ATOM a, void* b) => (ATOM)(ushort)(a.UnsignedValue | (ushort)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM operator ^(ATOM a, void* b) => (ATOM)(ushort)(a.UnsignedValue ^ (ushort)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is ATOM other ? this == other
                : obj is Handle16 h ? this == h
                    : obj is ushort unsig ? this == unsig
                        : obj is short sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(ATOM other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle16 other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(ushort other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(short other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo([NotNullWhen(true)] object? obj)
        => obj is ATOM other ? CompareTo(other)
                : obj is Handle16 h ? CompareTo(h)
                    : obj is ushort unsig ? CompareTo(unsig)
                        : obj is short sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(ATOM other) => Handle16Value.CompareTo(other.Handle16Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle16 other) => Handle16Value.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(ushort other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(short other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((ushort)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ATOM a, ATOM b) => a.Handle16Value == b.Handle16Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ATOM a, ATOM b) => a.Handle16Value != b.Handle16Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ATOM a, ATOM b) => a.Handle16Value < b.Handle16Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ATOM a, ATOM b) => a.Handle16Value > b.Handle16Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ATOM a, ATOM b) => a.Handle16Value <= b.Handle16Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ATOM a, ATOM b) => a.Handle16Value >= b.Handle16Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ATOM a, Handle16 b) => a.Handle16Value == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ATOM a, Handle16 b) => a.Handle16Value != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ATOM a, Handle16 b) => a.Handle16Value < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ATOM a, Handle16 b) => a.Handle16Value > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ATOM a, Handle16 b) => a.Handle16Value <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ATOM a, Handle16 b) => a.Handle16Value >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(ATOM a, ushort b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(ATOM a, ushort b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(ATOM a, ushort b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(ATOM a, ushort b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(ATOM a, ushort b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(ATOM a, ushort b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(ATOM a, short b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(ATOM a, short b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(ATOM a, short b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(ATOM a, short b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(ATOM a, short b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(ATOM a, short b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(ATOM a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(ATOM a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(ATOM a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(ATOM a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(ATOM a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(ATOM a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => Handle16Value.GetHashCode();

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => Handle16Value.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => Handle16Value.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => Handle16Value.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => Handle16Value.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM Parse(string s, IFormatProvider? provider = null) => (ATOM)Handle16.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out ATOM result)
    {
        Unsafe.SkipInit(out result);
		return Handle16.TryParse(s, provider, out Unsafe.As<ATOM, Handle16>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (ATOM)Handle16.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out ATOM result)
    {
        Unsafe.SkipInit(out result);
		return Handle16.TryParse(s, provider, out Unsafe.As<ATOM, Handle16>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (ATOM)Handle16.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out ATOM result)
    {
        Unsafe.SkipInit(out result);
		return Handle16.TryParse(s, provider, out Unsafe.As<ATOM, Handle16>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(Handle16 h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle16(ATOM h) => h.Handle16Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(ushort h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ushort(ATOM h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(short h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator short(ATOM h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(ATOM h) => h.PointerValue;

    #endregion
}
#nullable restore