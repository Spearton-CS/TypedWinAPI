using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

partial struct Rect
{
    [FieldOffset(0)] public readonly Point Location;
    [FieldOffset(0)] public readonly int X;
    [FieldOffset(4)] public readonly int Y;

    /// <summary> Gets the width of the rectangle (Right - Left). </summary>
    public readonly int Width
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Right - Left;
    }
    /// <summary> Gets the height of the rectangle (Bottom - Top). </summary>
    public readonly int Height
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Bottom - Top;
    }
    /// <summary> Gets the dimensions of the rectangle as a <see cref="TypedWinAPI.User32.Size"/>. </summary>
    public readonly Size Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(Width, Height);
    }

    /// <summary> Creates a new <see cref="Rect"/> from the specified position and dimensions. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Rect FromXYWH(int x, int y, int width, int height) => new(x, y, x + width, y + height);
    /// <summary> Deconstructs the rectangle into its X, Y, Width, and Height components. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void ToXYWH(out int x, out int y, out int width, out int height)
    {
        x = X; y = Y;
        width = Width; height = Height;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Deconstruct(out int left, out int top, out int right, out int bottom)
    {
        left = Left; top = Top;
        right = Right; bottom = Bottom;
    }
}