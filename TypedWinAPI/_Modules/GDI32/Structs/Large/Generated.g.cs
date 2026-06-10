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
	StructLayout(LayoutKind.Explicit, Size = 40)
]
public unsafe struct BitmapInfo()  :
    IStructContracts<BitmapInfo>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is BitmapInfo other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(BitmapInfo other) => this == other;
    public static bool operator ==(BitmapInfo a, BitmapInfo b)
    {
        if (a.biSize != b.biSize)
            return false;
        if (a.biWidth != b.biWidth)
            return false;
        if (a.biHeight != b.biHeight)
            return false;
        if (a.biPlanes != b.biPlanes)
            return false;
        if (a.biBitCount != b.biBitCount)
            return false;
        if (a.biCompression != b.biCompression)
            return false;
        if (a.biSizeImage != b.biSizeImage)
            return false;
        if (a.biXPelsPerMeter != b.biXPelsPerMeter)
            return false;
        if (a.biYPelsPerMeter != b.biYPelsPerMeter)
            return false;
        if (a.biClrUsed != b.biClrUsed)
            return false;
        if (a.biClrImportant != b.biClrImportant)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            BitmapInfo: {
                biSize: {{biSize}}
                biWidth: {{biWidth}}
                biHeight: {{biHeight}}
                biPlanes: {{biPlanes}}
                biBitCount: {{biBitCount}}
                biCompression: {{biCompression}}
                biSizeImage: {{biSizeImage}}
                biXPelsPerMeter: {{biXPelsPerMeter}}
                biYPelsPerMeter: {{biYPelsPerMeter}}
                biClrUsed: {{biClrUsed}}
                biClrImportant: {{biClrImportant}}
            }
            """;
    }

    public static bool operator !=(BitmapInfo a, BitmapInfo b)
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
		biSize = 40;
		biWidth = default;
		biHeight = default;
		biPlanes = default;
		biBitCount = default;
		biCompression = default;
		biSizeImage = default;
		biXPelsPerMeter = default;
		biYPelsPerMeter = default;
		biClrUsed = default;
		biClrImportant = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type int on offset 0
    /// </summary>
    [FieldOffset(0)] public int biSize = 40;
    /// <summary>
    /// Field of type int on offset 4
    /// </summary>
    [FieldOffset(4)] public int biWidth;
    /// <summary>
    /// Field of type int on offset 8
    /// </summary>
    [FieldOffset(8)] public int biHeight;
    /// <summary>
    /// Field of type short on offset 12
    /// </summary>
    [FieldOffset(12)] public short biPlanes;
    /// <summary>
    /// Field of type BitCount on offset 14
    /// </summary>
    [FieldOffset(14)] public BitCount biBitCount;
    /// <summary>
    /// Field of type Compression on offset 16
    /// </summary>
    [FieldOffset(16)] public Compression biCompression;
    /// <summary>
    /// Field of type int on offset 20
    /// </summary>
    [FieldOffset(20)] public int biSizeImage;
    /// <summary>
    /// Field of type int on offset 24
    /// </summary>
    [FieldOffset(24)] public int biXPelsPerMeter;
    /// <summary>
    /// Field of type int on offset 28
    /// </summary>
    [FieldOffset(28)] public int biYPelsPerMeter;
    /// <summary>
    /// Field of type int on offset 32
    /// </summary>
    [FieldOffset(32)] public int biClrUsed;
    /// <summary>
    /// Field of type int on offset 36
    /// </summary>
    [FieldOffset(36)] public int biClrImportant;

    #endregion
}
#nullable restore