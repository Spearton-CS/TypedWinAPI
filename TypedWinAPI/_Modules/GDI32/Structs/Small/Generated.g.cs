#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Struct;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.GDI32;

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 32)
]
public unsafe struct Bitmap :
    IStructContracts<Bitmap>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is Bitmap other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Bitmap other) => this == other;
    public static bool operator ==(Bitmap a, Bitmap b)
    {
        if (a.bmType != b.bmType)
            return false;
        if (a.bmWidth != b.bmWidth)
            return false;
        if (a.bmHeight != b.bmHeight)
            return false;
        if (a.bmWidthBytes != b.bmWidthBytes)
            return false;
        if (a.bmPlanes != b.bmPlanes)
            return false;
        if (a.bmBitsPixel != b.bmBitsPixel)
            return false;
        if (a.bmBits != b.bmBits)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            Bitmap: {
                bmType: {{bmType}}
                bmWidth: {{bmWidth}}
                bmHeight: {{bmHeight}}
                bmWidthBytes: {{bmWidthBytes}}
                bmPlanes: {{bmPlanes}}
                bmBitsPixel: {{bmBitsPixel}}
                bmBits: {{(nuint)bmBits:X16}}
            }
            """;
    }

    public static bool operator !=(Bitmap a, Bitmap b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		bmType = default;
		bmWidth = default;
		bmHeight = default;
		bmWidthBytes = default;
		bmPlanes = default;
		bmBitsPixel = default;
		bmBits = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type int on offset 0
    /// </summary>
    [FieldOffset(0)] public int bmType;
    /// <summary>
    /// Field of type int on offset 4
    /// </summary>
    [FieldOffset(4)] public int bmWidth;
    /// <summary>
    /// Field of type int on offset 8
    /// </summary>
    [FieldOffset(8)] public int bmHeight;
    /// <summary>
    /// Field of type int on offset 12
    /// </summary>
    [FieldOffset(12)] public int bmWidthBytes;
    /// <summary>
    /// Field of type ushort on offset 16
    /// </summary>
    [FieldOffset(16)] public ushort bmPlanes;
    /// <summary>
    /// Field of type BitDepth on offset 18
    /// </summary>
    [FieldOffset(18)] public BitDepth bmBitsPixel;
    /// <summary>
    /// Field of type void* on offset 24
    /// </summary>
    [FieldOffset(24)] public void* bmBits;

    #endregion

    #region Functions

    /// <summary>
    /// Returns a Span of the actual pixel data, not the struct metadata.
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly Span<byte> GetPixelData()
    {
        return bmBits is null ? [] : new Span<byte>(bmBits, bmHeight * bmWidthBytes);
    }

    #endregion
}
#nullable restore