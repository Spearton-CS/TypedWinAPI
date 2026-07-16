using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI;

[
#if ManagedStrings
    DebuggerDisplay("{ToString(),nq}"),
#endif
    SkipLocalsInit
]
public partial struct HResult :
    IEqualityOperators<HResult, int, bool>, IEquatable<int>,
    IEqualityOperators<HResult, uint, bool>, IEquatable<uint>
{
    #region Constructor

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HResult() => SignedValue = 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HResult(int sig) => SignedValue = sig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HResult(uint unsig) => UnsignedValue = unsig;

    #endregion

    #region Consts

    public static HResult S_OK
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }
    public static HResult E_InvalidArg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(unchecked((int)0x80070057));
    }
    public static HResult E_AccessDenied
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(unchecked((int)0x80070005));
    }

    #endregion

    #region Bits

    public readonly bool IsSuccess
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => SignedValue >= 0;
    }
    public readonly bool IsError
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => SignedValue < 0;
    }

    public readonly bool IsCustomerFacility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (SignedValue & 0x20000000) != 0;
    }
    public readonly bool IsReservedSet
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (SignedValue & 0x10000000) != 0;
    }

    public readonly ushort Facility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ushort)((SignedValue >> 16) & 0x1FFF);
    }
    public readonly ushort Code
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ushort)(SignedValue & 0xFFFF);
    }

    #endregion

#if ManagedObjects
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void ThrowIfFailed()
    {
        if (IsError)
            Marshal.ThrowExceptionForHR(SignedValue);
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator true(HResult hresult) => hresult.IsSuccess;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator false(HResult hresult) => hresult.IsError;

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HResult raw) => this == raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HResult left, HResult right) => left.SignedValue == right.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HResult left, HResult right) => left.SignedValue != right.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(int raw) => this == raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HResult left, int right) => left.SignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HResult left, int right) => left.SignedValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(uint raw) => this == raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HResult left, uint right) => left.UnsignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HResult left, uint right) => left.UnsignedValue != right;

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(HResult hresult) => hresult.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HResult(int raw) => new(raw);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(HResult hresult) => hresult.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HResult(uint raw) => new(raw);

    #endregion

#if ManagedStrings
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => IsSuccess ? $"Success (0x{SignedValue:X8})" : $"Error (0x{SignedValue:X8})";
#endif
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => SignedValue;
}