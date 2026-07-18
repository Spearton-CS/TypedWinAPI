using System.Numerics;
using System.Runtime.CompilerServices;

namespace TypedWinAPI.User32;

unsafe partial struct WParam :
    IEqualityOperators<WParam, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<WParam, Handle16, bool>, IEquatable<Handle16>,
    IEqualityOperators<WParam, nint, bool>, IEquatable<nint>,
    IEqualityOperators<WParam, nuint, bool>, IEquatable<nuint>
{
    public static WParam Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(nuint.Zero);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WParam(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WParam(Handle16 h) => Handle16Value = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WParam(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WParam(nint signed) => SignedValue = signed;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WParam(nuint unsigned) => UnsignedValue = unsigned;

    #region Decomposition

    /// <summary>
    /// Extracts the mouse wheel delta or other high-word values from a window message's WPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly short GetDelta() => (short)((SignedValue >> 16) & 0xFFFF);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly SysCommandType GetSysCommandType() => (SysCommandType)(SignedValue & 0xFFF0);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, Handle right) => left.HandleValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, Handle right) => left.HandleValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle16 other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, Handle16 right) => left.Handle16Value == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, Handle16 right) => left.Handle16Value != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, void* right) => left.PointerValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, void* right) => left.PointerValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, nint right) => left.SignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, nint right) => left.SignedValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, nuint right) => left.UnsignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, nuint right) => left.UnsignedValue != right;

    #endregion

    #region ValueType override

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => SignedValue.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => SignedValue.ToString("X16");

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle (WParam WParam) => WParam.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(Handle ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(WParam WParam) => WParam.Handle16Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(Handle16 ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(WParam WParam) => WParam.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(void* ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(WParam WParam) => WParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(nuint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(WParam WParam) => WParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(nint signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(WParam WParam) => (uint)WParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(uint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(WParam WParam) => (int)WParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(int signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool4(WParam WParam) => WParam.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(Bool4 b) => (WParam)(b ? 1 : 0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool1(WParam WParam) => WParam.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(Bool1 b) => (WParam)(b ? 1 : 0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator bool(WParam WParam) => WParam.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(bool b) => (WParam)(b ? 1 : 0);

    #endregion
}