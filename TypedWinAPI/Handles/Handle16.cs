using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI;

/// <summary>
/// Struct over <see cref="ushort"/> or <see cref="short"/> or <see cref="void"/>*. Abstraction over every Handle.
/// </summary>
[
    StructLayout(LayoutKind.Explicit, Size = 2),
    DebuggerDisplay("{UnsignedValue.ToString(\"X4\"),nq}"),
    DebuggerStepThrough,
    SkipLocalsInit
]
public unsafe readonly struct Handle16 :
    IEqualityOperators<Handle16, Handle16, bool>, IEquatable<Handle16>,
    IEqualityOperators<Handle16, ushort, bool>, IEquatable<ushort>,
    IEqualityOperators<Handle16, short, bool>, IEquatable<short>,

#if ManagedObjects
    IComparable,
#endif
    IComparisonOperators<Handle16, Handle16, bool>, IComparable<Handle16>,
    IComparisonOperators<Handle16, ushort, bool>, IComparable<ushort>,
    IComparisonOperators<Handle16, short, bool>, IComparable<short>,

#if ManagedStrings
    IParsable<Handle16>, ISpanParsable<Handle16>, IUtf8SpanParsable<Handle16>,
    IFormattable, ISpanFormattable, IUtf8SpanFormattable,
#endif

    IMinMaxValue<Handle16>,
    IShiftOperators<Handle16, int, Handle16>,
    IBitwiseOperators<Handle16, Handle16, Handle16>,
    IBitwiseOperators<Handle16, ushort, Handle16>,
    IBitwiseOperators<Handle16, short, Handle16>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle16() => UnsignedValue = 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle16(ushort unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle16(short sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly ushort UnsignedValue;
    [FieldOffset(0)] public readonly short SignedValue;

    #endregion

    #region Math

    public static Handle16 MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(ushort.MinValue);
    }
    public static Handle16 MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(ushort.MaxValue);
    }

    public static Handle16 Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new((ushort)0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator <<(Handle16 a, int shift) => (Handle16)(ushort)(a.UnsignedValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator >>(Handle16 a, int shift) => (Handle16)(ushort)(a.UnsignedValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator >>>(Handle16 a, int shift) => (Handle16)(ushort)(a.UnsignedValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator &(Handle16 a, Handle16 b) => (Handle16)(ushort)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator |(Handle16 a, Handle16 b) => (Handle16)(ushort)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator ^(Handle16 a, Handle16 b) => (Handle16)(ushort)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator ~(Handle16 a) => (Handle16)(ushort)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator &(Handle16 a, ushort b) => (Handle16)(ushort)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator |(Handle16 a, ushort b) => (Handle16)(ushort)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator ^(Handle16 a, ushort b) => (Handle16)(ushort)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator &(Handle16 a, short b) => (Handle16)(short)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator |(Handle16 a, short b) => (Handle16)(short)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator ^(Handle16 a, short b) => (Handle16)(short)(a.SignedValue ^ b);

    #endregion

    #region Equality

#if ManagedObjects
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is Handle16 h ? this == h
            : obj is ushort unsig ? this == unsig
                : obj is short sig && this == sig;
#endif
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle16 other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(ushort other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(short other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle16 a, Handle16 b) => a.UnsignedValue == b.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle16 a, Handle16 b) => a.UnsignedValue != b.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle16 a, ushort b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle16 a, ushort b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle16 a, short b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle16 a, short b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

    #endregion

    #region Comparability

#if ManagedObjects
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(object? obj)
        => obj is Handle16 h ? CompareTo(h)
            : obj is ushort unsig ? CompareTo(unsig)
                : obj is short sig ? CompareTo(sig)
                    : 0;
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle16 other) => UnsignedValue.CompareTo(other.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(ushort other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(short other) => SignedValue.CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle16 a, Handle16 b) => a.UnsignedValue < b.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle16 a, Handle16 b) => a.UnsignedValue > b.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle16 a, Handle16 b) => a.UnsignedValue <= b.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle16 a, Handle16 b) => a.UnsignedValue >= b.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle16 a, ushort b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle16 a, ushort b) => a.UnsignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle16 a, ushort b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle16 a, ushort b) => a.UnsignedValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle16 a, short b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle16 a, short b) => a.SignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle16 a, short b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle16 a, short b) => a.SignedValue >= b;

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
    public static Handle16 Parse(string s, IFormatProvider? provider = null) => (Handle16)ushort.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out Handle16 result)
    {
        Unsafe.SkipInit(out result);
        return ushort.TryParse(s, provider, out Unsafe.As<Handle16, ushort>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (Handle16)ushort.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out Handle16 result)
    {
        Unsafe.SkipInit(out result);
        return ushort.TryParse(s, provider, out Unsafe.As<Handle16, ushort>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (Handle16)ushort.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out Handle16 result)
    {
        Unsafe.SkipInit(out result);
        return ushort.TryParse(s, provider, out Unsafe.As<Handle16, ushort>(ref result));
    }

    #endregion
#endif

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(void* ptr) => new((ushort)ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(ushort unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(short sig) => new(sig);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(Handle16 h) => (void*)h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ushort(Handle16 h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator short(Handle16 h) => h.SignedValue;

    #endregion
}