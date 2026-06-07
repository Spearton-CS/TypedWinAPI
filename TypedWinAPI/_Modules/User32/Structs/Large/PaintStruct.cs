using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

/// <summary>
/// Contains information for an application that can be used to paint the client area of a window owned by that application.
/// </summary>
/// <remarks>
/// Directly compatible with the native Win32 <c>PAINTSTRUCT</c> structure.
/// Size is explicitly set to 72 bytes to match the x64 alignment requirements.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 72)]
public unsafe struct PaintStruct
    : IEqualityOperators<PaintStruct, PaintStruct, bool>, IEquatable<PaintStruct>
{
    /// <summary> A handle to the display DC to be used for painting. </summary>
    [FieldOffset(0)] public Handle hdc;

    /// <summary> Indicates whether the background must be erased. </summary>
    [FieldOffset(8)] public Bool4 fErase;

    /// <summary> A <see cref="Rect"/> structure that specifies the upper left and lower right corners of the rectangle in which the painting is requested. </summary>
    [FieldOffset(12)] public Rect rcPaint;

    /// <summary> Reserved; used internally by the system. </summary>
    [FieldOffset(28)] public Bool4 fRestore;

    /// <summary> Reserved; used internally by the system. </summary>
    [FieldOffset(32)] public Bool4 fIncUpdate;

    /// <summary> Reserved; used internally by the system. </summary>
    [FieldOffset(40)] internal fixed byte rgbReserved[32];

    /// <summary>
    /// Provides a view of the structure as a span of bytes for efficient memory operations.
    /// </summary>
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Span<byte> AsSpan()
        => MemoryMarshal.CreateSpan(ref Unsafe
                        .As<Handle, byte>(ref Unsafe
                        .AsRef(in hdc)), sizeof(PaintStruct));

    /// <summary> Determines whether the specified object is equal to the current structure. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => obj is PaintStruct other && this == other;

    /// <summary> Compares this instance to another <see cref="PaintStruct"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PaintStruct other) => this == other;

    /// <summary> Compares two <see cref="PaintStruct"/> instances for equality using byte-wise comparison. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PaintStruct left, PaintStruct right) => left.AsSpan().SequenceEqual(right.AsSpan());

    /// <summary> Compares two <see cref="PaintStruct"/> instances for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PaintStruct left, PaintStruct right) => !(left == right);

    /// <summary> Returns a hash code for this instance. </summary>
    /// <remarks> Always returns -1 as the structure is mutable and large; avoid using as a key in hash-based collections. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly int GetHashCode() => -1;
}