using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.Shell32;

[StructLayout(LayoutKind.Explicit, Size = 2)]
public unsafe readonly record struct SHItemID(
    [field: FieldOffset(0)] ushort cb)
{
    public readonly bool IsTerminator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => cb <= 2;
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> GetDataSpan() => cb <= 2 ? [] : new((byte*)Unsafe.AsPointer(in this) + 2, cb - 2);
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly byte* GetDataPtr() => cb <= 2 ? null : (byte*)Unsafe.AsPointer(in this) + 2;
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ref readonly SHItemID GetNextRef() => ref *(SHItemID*)((byte*)Unsafe.AsPointer(in this) + cb);
}