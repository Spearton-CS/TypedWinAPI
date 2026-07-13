using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI;

/// <summary>
/// Represents a Win32 1-byte boolean value.
/// </summary>
/// <remarks>
/// In native Windows API, <c>BOOLEAN</c> is a 8-bit integer where 0 is <c>FALSE</c> 
/// and any non-zero value is <c>TRUE</c>. This structure ensures correct marshaling 
/// and provides seamless integration with .NET <see cref="bool"/>.
/// </remarks>
[
    StructLayout(LayoutKind.Explicit, Size = 1),
    DebuggerDisplay("{ToString(),nq}")
]
public readonly struct Bool1 :
    IEqualityOperators<Bool1, Bool1, bool>, IEquatable<Bool1>,
    IEqualityOperators<Bool1, bool, bool>, IEquatable<bool>,
    IFormattable, ISpanFormattable, IUtf8SpanFormattable,
    IParsable<Bool1>, ISpanParsable<Bool1>, IUtf8SpanParsable<Bool1>
{
    #region Construction

    /// <summary> Initializes a new instance with a raw unsigned sbyteeger value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Bool1(byte raw) => RawUnsigned = raw;
    /// <summary> Initializes a new instance with a raw signed sbyteeger value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Bool1(sbyte raw) => RawSigned = raw;

    #endregion

    #region Fields

    /// <summary> The raw unsigned 32-bit representation of the boolean value. </summary>
    [FieldOffset(0)] public readonly byte RawUnsigned;
    /// <summary> The raw signed 32-bit representation of the boolean value. </summary>
    [FieldOffset(0)] public readonly sbyte RawSigned;

    #endregion

    #region Math

    /// <summary>
    /// Win32 constant for TRUE (1)
    /// </summary>
    public static Bool1 True
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(1);
    }
    /// <summary>
    /// Win32 constant for FALSE (0)
    /// </summary>
    public static Bool1 False
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(0);
    }

    #endregion

    #region Logical operators

    /// <summary> Returns true if the <see cref="Bool1"/> represents a non-zero value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator true(Bool1 win32) => (bool)win32;
    /// <summary> Returns true if the <see cref="Bool1"/> represents a zero value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator false(Bool1 win32) => !(bool)win32;

    #endregion

    #region Equality

    /// <summary> Compares this instance to a specified object. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => obj is Bool1 win32 ? this == win32 : obj is bool dotnet && this == dotnet;

    /// <summary> Compares this instance to another <see cref="Bool1"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Bool1 other) => this == other;
    /// <summary> Compares two <see cref="Bool1"/> values for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Bool1 a, Bool1 b) => (bool)a == (bool)b;
    /// <summary> Compares two <see cref="Bool1"/> values for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Bool1 a, Bool1 b) => (bool)a != (bool)b;

    /// <summary> Compares this instance to a standard .NET <see cref="bool"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(bool other) => this == other;
    /// <summary> Compares a <see cref="Bool1"/> with a <see cref="bool"/> for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Bool1 a, bool b) => (bool)a == b;
    /// <summary> Compares a <see cref="Bool1"/> with a <see cref="bool"/> for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Bool1 a, bool b) => (bool)a != b;

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
    /// Writes the string representation of the boolean value sbyteo <see cref="Span{T}"/> in UTF-16
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="written"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written)
        => ((bool)this).TryFormat(destination, out written);
    /// <summary>
    /// Writes the string representation of the boolean value sbyteo <see cref="Span{T}"/> in UTF-8
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
    public static Bool1 Parse(string s) => bool.Parse(s);
    /// <summary>
    /// Trying to parse the string representation of the boolean value, can throw and exception
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string? s, scoped out Bool1 result)
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
    public static Bool1 Parse(ReadOnlySpan<char> s) => bool.Parse(s);
    /// <summary>
    /// Trying to parse the string representation of the boolean value, can throw and exception
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, scoped out Bool1 result)
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
    public static Bool1 Parse(ReadOnlySpan<byte> s)
    {
        if (TryParse(s, out Bool1 result))
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
    public static bool TryParse(ReadOnlySpan<byte> s, scoped out Bool1 result)
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
    static Bool1 IParsable<Bool1>.Parse(string s, IFormatProvider? provider) => Parse(s);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IParsable<Bool1>.TryParse(string? s, IFormatProvider? provider, scoped out Bool1 result) => TryParse(s, out result);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Bool1 ISpanParsable<Bool1>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool ISpanParsable<Bool1>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out Bool1 result) => TryParse(s, out result);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Bool1 IUtf8SpanParsable<Bool1>.Parse(ReadOnlySpan<byte> s, IFormatProvider? provider) => Parse(s);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IUtf8SpanParsable<Bool1>.TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out Bool1 result) => TryParse(s, out result);

    #endregion

    #region Cast

    /// <summary> Implicitly converts a <see cref="Bool1"/> to a .NET <see cref="bool"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(Bool1 win32) => win32.RawUnsigned != 0;
    /// <summary> Implicitly converts a .NET <see cref="bool"/> to a <see cref="Bool1"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Bool1(bool dotnet) => new(dotnet ? (byte)1 : (byte)0);

    /// <summary> Implicitly converts a <see cref="Bool1"/> to a <see cref="Bool4"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Bool4(Bool1 u1) => u1 ? Bool4.True : Bool4.False;
    /// <summary> Implicitly converts a <see cref="Bool4"/> to a <see cref="Bool1"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Bool1(Bool4 u32) => u32 ? Bool1.True : Bool1.False;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator byte(Bool1 win32) => win32.RawUnsigned;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool1(byte raw) => new(raw);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator sbyte(Bool1 win32) => win32.RawSigned;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool1(sbyte raw) => new(raw);

    #endregion
}