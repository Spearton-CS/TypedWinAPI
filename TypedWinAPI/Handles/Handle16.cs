using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using TypedWinAPI.Contracts;

namespace TypedWinAPI;

/// <summary>
/// Struct over <see cref="ushort"/> or <see cref="short"/> or <see cref="void"/>*. Abstraction over every Handle.
/// </summary>
[
    StructLayout(LayoutKind.Explicit, Size = 8),
    DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
    DebuggerStepThrough,
    SkipLocalsInit
]
public unsafe readonly struct Handle16 :
    IHandle16TSelfContracts<Handle16>, IHandle16Contracts<Handle16>
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator &(Handle16 a, void* b) => (Handle16)(ushort)(a.UnsignedValue & (ushort)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator |(Handle16 a, void* b) => (Handle16)(ushort)(a.UnsignedValue | (ushort)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle16 operator ^(Handle16 a, void* b) => (Handle16)(ushort)(a.UnsignedValue ^ (ushort)b);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is Handle16 h ? this == h
            : obj is ushort unsig ? this == unsig
                : obj is short sig && this == sig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle16 other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(ushort other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(short other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;

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
    public static bool operator ==(Handle16 a, void* b) => (void*)a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle16 a, void* b) => (void*)a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

    #endregion

    #region Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(object? obj)
        => obj is Handle16 h ? CompareTo(h)
            : obj is ushort unsig ? CompareTo(unsig)
                : obj is short sig ? CompareTo(sig)
                    : 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle16 other) => UnsignedValue.CompareTo(other.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(ushort other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(short other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((ushort)other);

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle16 a, void* b) => (void*)a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle16 a, void* b) => (void*)a.UnsignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle16 a, void* b) => (void*)a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle16 a, void* b) => (void*)a.UnsignedValue >= b;

    #endregion

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