using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using TypedWinAPI.Contracts;

namespace TypedWinAPI;

/// <summary>
/// Represents a Win32 4-byte boolean value.
/// </summary>
/// <remarks>
/// In native Windows API, <c>BOOL</c> is a 32-bit integer where 0 is <c>FALSE</c> 
/// and any non-zero value is <c>TRUE</c>. This structure ensures correct marshaling 
/// and provides seamless integration with .NET <see cref="bool"/>.
/// </remarks>
[
    StructLayout(LayoutKind.Explicit, Size = 4),
    DebuggerDisplay("{ToString(),nq}")
]
public readonly struct Bool4 :
    IEqualityOperators<Bool4, Bool4, bool>, IEquatable<Bool4>,
    IEqualityOperators<Bool4, bool, bool>, IEquatable<bool>,
    IFormattable, ISpanFormattable, IUtf8SpanFormattable,
    IParsable<Bool4>, ISpanParsable<Bool4>, IUtf8SpanParsable<Bool4>,

    IImplicitCast<Bool4, bool>,
    IExplicitCast<Bool4, uint>, IExplicitCast<Bool4, int>
{
    #region Construction

    /// <summary> Initializes a new instance with a raw unsigned integer value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Bool4(uint raw) => RawUnsigned = raw;
    /// <summary> Initializes a new instance with a raw signed integer value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Bool4(int raw) => RawSigned = raw;

    #endregion

    #region Fields

    /// <summary> The raw unsigned 32-bit representation of the boolean value. </summary>
    [FieldOffset(0)] public readonly uint RawUnsigned;
    /// <summary> The raw signed 32-bit representation of the boolean value. </summary>
    [FieldOffset(0)] public readonly int RawSigned;

    #endregion

    #region Math

    /// <summary>
    /// Win32 constant for TRUE (1)
    /// </summary>
    public static Bool4 True
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(1);
    }
    /// <summary>
    /// Win32 constant for FALSE (0)
    /// </summary>
    public static Bool4 False
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(0);
    }

    #endregion

    #region Logical operators

    /// <summary> Returns true if the <see cref="Bool4"/> represents a non-zero value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator true(Bool4 win32) => (bool)win32;
    /// <summary> Returns true if the <see cref="Bool4"/> represents a zero value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator false(Bool4 win32) => !(bool)win32;

    #endregion

    #region Equality

    /// <summary> Compares this instance to a specified object. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => obj is Bool4 win32 ? this == win32 : obj is bool dotnet && this == dotnet;

    /// <summary> Compares this instance to another <see cref="Bool4"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Bool4 other) => this == other;
    /// <summary> Compares two <see cref="Bool4"/> values for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Bool4 a, Bool4 b) => (bool)a == (bool)b;
    /// <summary> Compares two <see cref="Bool4"/> values for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Bool4 a, Bool4 b) => (bool)a != (bool)b;

    /// <summary> Compares this instance to a standard .NET <see cref="bool"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(bool other) => this == other;
    /// <summary> Compares a <see cref="Bool4"/> with a <see cref="bool"/> for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Bool4 a, bool b) => (bool)a == b;
    /// <summary> Compares a <see cref="Bool4"/> with a <see cref="bool"/> for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Bool4 a, bool b) => (bool)a != b;

    /// <summary> Returns the hash code for this instance. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => ((bool)this).GetHashCode();

    #endregion

    #region Format and Parse

    /// <summary> Returns the string representation of the boolean value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => ((bool)this).ToString();
    /// <summary>
    /// Returns the string representation of the boolean value.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(IFormatProvider? provider) => ((bool)this).ToString(provider);

    /// <summary>
    /// Writes the string representation of the boolean value into <see cref="Span{T}"/> in UTF-16
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="written"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written)
        => ((bool)this).TryFormat(destination, out written);
    /// <summary>
    /// Writes the string representation of the boolean value into <see cref="Span{T}"/> in UTF-8
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="written"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written)
        => Utf8Formatter.TryFormat(this, destination, out written);

    /// <summary>
    /// Parses the string representation of the boolean value, can throw an exception.
    /// </summary>
    /// <param name="s"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 Parse(string s) => bool.Parse(s);
    /// <summary>
    /// Trying to parse the string representation of the boolean value, can throw and exception
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string? s, scoped out Bool4 result)
    {
        if (bool.TryParse(s, out bool dotnetResult))
        {
            result = dotnetResult;
            return true;
        }
        else
        {
            result = false;
            return false;
        }
    }

    /// <summary>
    /// Parses the string representation of the boolean value, can throw an exception.
    /// </summary>
    /// <param name="s"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 Parse(ReadOnlySpan<char> s) => bool.Parse(s);
    /// <summary>
    /// Trying to parse the string representation of the boolean value, can throw and exception
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, scoped out Bool4 result)
    {
        if (bool.TryParse(s, out bool dotnetResult))
        {
            result = dotnetResult;
            return true;
        }
        else
        {
            result = false;
            return false;
        }
    }

    /// <summary>
    /// Parses the string representation of the boolean value, can throw an exception.
    /// </summary>
    /// <param name="s"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 Parse(ReadOnlySpan<byte> s)
    {
        if (TryParse(s, out Bool4 result))
            return result;
        else
            throw new FormatException("Valid values: true and false (any case)");
    }
    /// <summary>
    /// Trying to parse the string representation of the boolean value, can throw and exception
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, scoped out Bool4 result)
    {
        if (Utf8Parser.TryParse(s, out bool dotnetResult, out _))
        {
            result = dotnetResult;
            return true;
        }
        else
        {
            result = false;
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    readonly string IFormattable.ToString([ConstantExpected] string? format, IFormatProvider? provider) => ((bool)this).ToString(provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    readonly bool ISpanFormattable.TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format, IFormatProvider? provider)
        => TryFormat(destination, out written);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    readonly bool IUtf8SpanFormattable.TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format, IFormatProvider? provider)
        => TryFormat(destination, out written);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Bool4 IParsable<Bool4>.Parse(string s, IFormatProvider? provider) => Parse(s);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IParsable<Bool4>.TryParse(string? s, IFormatProvider? provider, scoped out Bool4 result) => TryParse(s, out result);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Bool4 ISpanParsable<Bool4>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool ISpanParsable<Bool4>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out Bool4 result) => TryParse(s, out result);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Bool4 IUtf8SpanParsable<Bool4>.Parse(ReadOnlySpan<byte> s, IFormatProvider? provider) => Parse(s);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IUtf8SpanParsable<Bool4>.TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out Bool4 result) => TryParse(s, out result);

    #endregion

    #region Cast

    /// <summary> Implicitly converts a <see cref="Bool4"/> to a .NET <see cref="bool"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(Bool4 win32) => win32.RawUnsigned != 0;
    /// <summary> Implicitly converts a .NET <see cref="bool"/> to a <see cref="Bool4"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Bool4(bool dotnet) => new(dotnet ? 1u : 0u);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(Bool4 win32) => win32.RawUnsigned;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool4(uint raw) => new(raw);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(Bool4 win32) => win32.RawSigned;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool4(int raw) => new(raw);

    #endregion
}