using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public readonly struct HotKey
    : IEqualityOperators<HotKey, HotKey, bool>, IEquatable<HotKey>,
        IEqualityOperators<HotKey, uint, bool>, IEquatable<uint>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HotKey(uint raw) => Raw = raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HotKey(VirtualKey vk, HotKeyModifier modifier)
    {
        VirtualKeyRaw = (byte)vk;
        Modifier = modifier;
    }

    [FieldOffset(0)] public readonly uint Raw;
    // Low byte: Virtual Key (e.g. VK_F5)
    [FieldOffset(0)] public readonly byte VirtualKeyRaw;
    public readonly VirtualKey VirtualKey
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (VirtualKey)VirtualKeyRaw;
    }
    // High byte: Modifier flags (Shift, Ctrl, Alt)
    [FieldOffset(1)] public readonly HotKeyModifier Modifier;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? other) => other is HotKey hk ? this == hk : other is uint raw && this == raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HotKey other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(uint other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HotKey a, HotKey b) => a.Raw == b.Raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HotKey a, HotKey b) => a.Raw == b.Raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HotKey a, uint b) => a.Raw == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HotKey a, uint b) => a.Raw != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(HotKey hk) => hk.Raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HotKey(uint raw) => new(raw);
}