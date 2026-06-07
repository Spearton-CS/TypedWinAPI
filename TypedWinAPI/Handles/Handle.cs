using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using TypedWinAPI.Contracts;

namespace TypedWinAPI;

/// <summary>
/// Struct over <see cref="nuint"/> or <see cref="nint"/> or <see cref="void"/>*. Abstraction over every Handle.
/// </summary>
[
    StructLayout(LayoutKind.Explicit, Size = 8),
    DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
    DebuggerStepThrough,
    SkipLocalsInit
]
public unsafe readonly struct Handle :
    IHandleTSelfContracts<Handle>, IHandleContracts<Handle>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle() => PointerValue = null;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static Handle MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(nuint.MinValue);
    }
    public static Handle MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(nuint.MaxValue);
    }

    public static Handle Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(nuint.Zero);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator <<(Handle a, int shift) => (Handle)(a.UnsignedValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator >>(Handle a, int shift) => (Handle)(a.UnsignedValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator >>>(Handle a, int shift) => (Handle)(a.UnsignedValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator &(Handle a, Handle b) => (Handle)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator |(Handle a, Handle b) => (Handle)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator ^(Handle a, Handle b) => (Handle)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator ~(Handle a) => (Handle)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator &(Handle a, nuint b) => (Handle)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator |(Handle a, nuint b) => (Handle)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator ^(Handle a, nuint b) => (Handle)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator &(Handle a, nint b) => (Handle)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator |(Handle a, nint b) => (Handle)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator ^(Handle a, nint b) => (Handle)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator &(Handle a, void* b) => (Handle)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator |(Handle a, void* b) => (Handle)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle operator ^(Handle a, void* b) => (Handle)(a.UnsignedValue ^ (nuint)b);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is Handle h ? this == h
            : obj is nuint unsig ? this == unsig
                : obj is nint sig && this == sig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle a, Handle b) => a.PointerValue == b.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle a, Handle b) => a.PointerValue != b.PointerValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

    #endregion

    #region Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(object? obj)
        => obj is Handle h ? CompareTo(h)
            : obj is nuint unsig ? CompareTo(unsig)
                : obj is nint sig ? CompareTo(sig)
                    : 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle a, Handle b) => a.PointerValue < b.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle a, Handle b) => a.PointerValue > b.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle a, Handle b) => a.PointerValue <= b.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle a, Handle b) => a.PointerValue >= b.PointerValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle a, nuint b) => a.UnsignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle a, nuint b) => a.UnsignedValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle a, nint b) => a.SignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle a, nint b) => a.SignedValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Handle a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Handle a, void* b) => a.PointerValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Handle a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Handle a, void* b) => a.PointerValue >= b;

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
    public static Handle Parse(string s, IFormatProvider? provider = null) => (Handle)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out Handle result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<Handle, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (Handle)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out Handle result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<Handle, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (Handle)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out Handle result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<Handle, nuint>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(nint sig) => new(sig);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(Handle h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(Handle h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(Handle h) => h.SignedValue;

    #endregion
}