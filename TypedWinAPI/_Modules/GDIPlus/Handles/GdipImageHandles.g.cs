using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using TypedWinAPI.Contracts;

namespace TypedWinAPI.GDIPlus;


/// <summary>
/// Handle to a GDI+ bitmap
/// </summary>
[
    StructLayout(LayoutKind.Explicit, Size = 8),
    DebuggerDisplay("{ToString(),nq}"),
    DebuggerStepThrough,
    SkipLocalsInit
]
public unsafe readonly struct HBitmap :
    IHandleTSelfContracts<HBitmap>,
    IHandleTBaseHandleContracts<HBitmap, HImage>,
    IHandleContracts<HBitmap>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap() => HImageValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HBitmap(HImage h) => HImageValue = h;
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

    [FieldOffset(0)] public readonly HImage HImageValue;
    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HBitmap MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBitmap)HImage.MinValue;
    }
    public static HBitmap MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBitmap)HImage.MaxValue;
    }

    public static HBitmap Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HBitmap)HImage.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator <<(HBitmap a, int shift) => (HBitmap)(a.HImageValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator >>(HBitmap a, int shift) => (HBitmap)(a.HImageValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator >>>(HBitmap a, int shift) => (HBitmap)(a.HImageValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, HBitmap b) => (HBitmap)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, HBitmap b) => (HBitmap)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, HBitmap b) => (HBitmap)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ~(HBitmap a) => (HBitmap)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator &(HBitmap a, HImage b) => (HBitmap)(a.HImageValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator |(HBitmap a, HImage b) => (HBitmap)(a.HImageValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap operator ^(HBitmap a, HImage b) => (HBitmap)(a.HImageValue ^ b);

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

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HBitmap other ? this == other
            : obj is HImage @HImage ? this == @HImage
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HBitmap other) => this == other;
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
    public static bool operator ==(HBitmap a, HBitmap b) => a.HImageValue == b.HImageValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, HBitmap b) => a.HImageValue != b.HImageValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, HImage b) => a.HImageValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, HImage b) => a.HImageValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBitmap a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBitmap a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HImageValue.GetHashCode();

    #endregion

    #region Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(object? obj)
        => obj is HBitmap other ? CompareTo(other)
            : obj is HImage @HImage ? CompareTo(@HImage)
            : obj is Handle h ? CompareTo(h)
                : obj is nuint unsig ? CompareTo(unsig)
                    : obj is nint sig ? CompareTo(sig)
                        : 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HBitmap other) => HImageValue.CompareTo(other.HImageValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HImage other) => HImageValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBitmap a, HBitmap b) => a.HImageValue < b.HImageValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBitmap a, HBitmap b) => a.HImageValue > b.HImageValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBitmap a, HBitmap b) => a.HImageValue <= b.HImageValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBitmap a, HBitmap b) => a.HImageValue >= b.HImageValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBitmap a, HImage b) => a.HImageValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBitmap a, HImage b) => a.HImageValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBitmap a, HImage b) => a.HImageValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBitmap a, HImage b) => a.HImageValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBitmap a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBitmap a, Handle b) => a.HandleValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBitmap a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBitmap a, Handle b) => a.HandleValue >= b;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HBitmap a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HBitmap a, void* b) => a.PointerValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HBitmap a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HBitmap a, void* b) => a.PointerValue >= b;

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HImageValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HImageValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HImageValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HImageValue.TryFormat(destination, out written, format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(string s, IFormatProvider? provider = null) => (HBitmap)HImage.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
		return HImage.TryParse(s, provider, out Unsafe.As<HBitmap, HImage>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HBitmap)HImage.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
		return HImage.TryParse(s, provider, out Unsafe.As<HBitmap, HImage>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HBitmap Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HBitmap)HImage.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HBitmap result)
    {
        Unsafe.SkipInit(out result);
		return HImage.TryParse(s, provider, out Unsafe.As<HBitmap, HImage>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(HImage h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBitmap(nint sig) => new(sig);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HImage(HBitmap h) => h.HImageValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HBitmap h) => h.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HBitmap h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HBitmap h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HBitmap h) => h.SignedValue;

    #endregion
}
