#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// --- Custom usings ---
using System.Numerics;

namespace TypedWinAPI.GDIPlus;

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 32)
]
public readonly unsafe struct RectF :
	// --- Custom contracts ---
	IEqualityOperators<RectF, User32.Rect, bool>,
	IEquatable<User32.Rect>,
	IEqualityOperators<RectF, (float X, float Y, float Width, float Height), bool>,
	IEquatable<(float X, float Y, float Width, float Height)>,
	IEqualityOperators<RectF, (int X, int Y, int Width, int Height), bool>,
	IEquatable<(int X, int Y, int Width, int Height)>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is RectF other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(RectF other) => this == other;
    public static bool operator ==(RectF a, RectF b)
    {
		return a.Location == b.Location && a.Width == b.Width && a.Height == b.Height;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            RectF: {
                X: {{X}}
                Y: {{Y}}
                Location: {{Location}}
                Width: {{Width}}
                Height: {{Height}}
            }
            """;
    }

    public static bool operator !=(RectF a, RectF b)
    {
        return a.Location != b.Location && a.Width == b.Width && a.Height == b.Height;
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type float on offset 0
    /// </summary>
    [FieldOffset(0)] public readonly float X;
    /// <summary>
    /// Field of type float on offset 4
    /// </summary>
    [FieldOffset(4)] public readonly float Y;
    /// <summary>
    /// Field of type PointF on offset 0
    /// </summary>
    [FieldOffset(0)] public readonly PointF Location;
    /// <summary>
    /// Field of type float on offset 8
    /// </summary>
    [FieldOffset(8)] public readonly float Width;
    /// <summary>
    /// Field of type float on offset 12
    /// </summary>
    [FieldOffset(12)] public readonly float Height;

    #endregion

    #region Functions

    /// <summary>
    /// Function with return type RectF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public RectF ()
    {
        X = 0;
		Y = 0;
		Width = 0;
		Height = 0;
    }
    /// <summary>
    /// Function with return type RectF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public RectF (float x, float y, float width, float height)
    {
        X = x;
		Y = y;
		Width = width;
		Height = height;
    }
    /// <summary>
    /// Function with return type void
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly void Deconstruct(out float x, out float y, out float width, out float height)
    {
        x = X;
		y = Y;
		width = Width;
		height = Height;
    }
    /// <summary>
    /// Function with return type void
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly void Deconstruct(out PointF location, out float width, out float height)
    {
        location = Location;
		width = Width;
		height = Height;
    }
    /// <summary>
    /// Function with return type void
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly void ToLBTR(out float left, out float bottom, out float top, out float right)
    {
        left = X;
		top = Y;
		bottom = Y + Height;
		right = X + Width;
    }
    /// <summary>
    /// Function with return type RectF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static RectF FromLTBR(float left, float top, float bottom, float right)
    {
        return new(left, top, bottom - top, right - left);
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals(User32.Rect other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals((float X, float Y, float Width, float Height) other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals((int X, int Y, int Width, int Height) other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  ==(RectF a, User32.Rect b)
    {
        return a.Location == b.Location && a.Width == b.Width && a.Height == b.Height;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  !=(RectF a, User32.Rect b)
    {
        return a.Location != b.Location || a.Width != b.Width || a.Height != b.Height;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  ==(RectF a, (float X, float Y, float Width, float Height) b)
    {
        return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  !=(RectF a, (float X, float Y, float Width, float Height) b)
    {
        return a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  ==(RectF a, (int X, int Y, int Width, int Height) b)
    {
        return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
    }
    /// <summary>
    /// Function with return type 
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator  !=(RectF a, (int X, int Y, int Width, int Height) b)
    {
        return a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height;
    }
    /// <summary>
    /// Function with return type RectF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static implicit operator RectF (User32.Rect other)
    {
        return new(other.X, other.Y, other.Width, other.Height);
    }
    /// <summary>
    /// Function with return type User32.Rect
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator User32.Rect (RectF other)
    {
        return new((int)other.X, (int)other.Y, (int)other.Width, (int)other.Height);
    }
    /// <summary>
    /// Function with return type RectF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator RectF ((float X, float Y, float Width, float Height) other)
    {
        return new(other.X, other.Y, other.Width, other.Height);
    }
    /// <summary>
    /// Function with return type (float X, float Y, float Width, float Height)
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator (float X, float Y, float Width, float Height) (RectF other)
    {
        return (other.X, other.Y, other.Width, other.Height);
    }
    /// <summary>
    /// Function with return type RectF
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator RectF ((int X, int Y, int Width, int Height) other)
    {
        return new(other.X, other.Y, other.Width, other.Height);
    }
    /// <summary>
    /// Function with return type (int X, int Y, int Width, int Height)
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator (int X, int Y, int Width, int Height) (RectF other)
    {
        return ((int)other.X, (int)other.Y, (int)other.Width, (int)other.Height);
    }

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 24)
]
public unsafe struct StartupInput()
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is StartupInput other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(StartupInput other) => this == other;
    public static bool operator ==(StartupInput a, StartupInput b)
    {
        if (a.GdiplusVersion != b.GdiplusVersion)
            return false;
        if (a.DebugEventCallback != b.DebugEventCallback)
            return false;
        if (a.SuppressBackgroundThread != b.SuppressBackgroundThread)
            return false;
        if (a.SuppressExternalCodecs != b.SuppressExternalCodecs)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            StartupInput: {
                GdiplusVersion: {{GdiplusVersion}}
                DebugEventCallback: {{(nuint)DebugEventCallback:X16}}
                SuppressBackgroundThread: {{SuppressBackgroundThread}}
                SuppressExternalCodecs: {{SuppressExternalCodecs}}
            }
            """;
    }

    public static bool operator !=(StartupInput a, StartupInput b)
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
		GdiplusVersion = 1;
		DebugEventCallback = null;
		SuppressBackgroundThread = false;
		SuppressExternalCodecs = false;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public uint GdiplusVersion = 1;
    /// <summary>
    /// Field of type delegate* unmanaged[DebugEventLevel, nint, void] on offset 8
    /// </summary>
    [FieldOffset(8)] public delegate* unmanaged<DebugEventLevel, nint, void> DebugEventCallback = null;
    /// <summary>
    /// Field of type Bool4 on offset 16
    /// </summary>
    [FieldOffset(16)] public Bool4 SuppressBackgroundThread = false;
    /// <summary>
    /// Field of type Bool4 on offset 20
    /// </summary>
    [FieldOffset(20)] public Bool4 SuppressExternalCodecs = false;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 16)
]
public unsafe struct StartupOutput()
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is StartupOutput other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(StartupOutput other) => this == other;
    public static bool operator ==(StartupOutput a, StartupOutput b)
    {
        if (a.NotificationHook != b.NotificationHook)
            return false;
        if (a.NotificationUnhook != b.NotificationUnhook)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            StartupOutput: {
                NotificationHook: {{(nuint)NotificationHook:X16}}
                NotificationUnhook: {{(nuint)NotificationUnhook:X16}}
            }
            """;
    }

    public static bool operator !=(StartupOutput a, StartupOutput b)
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
		NotificationHook = null;
		NotificationUnhook = null;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type delegate* unmanaged[out nint, delegate* unmanaged[void], Status] on offset 0
    /// </summary>
    [FieldOffset(0)] public delegate* unmanaged<out nint, delegate* unmanaged<void>, Status> NotificationHook = null;
    /// <summary>
    /// Field of type delegate* unmanaged[nint, void] on offset 8
    /// </summary>
    [FieldOffset(8)] public delegate* unmanaged<nint, void> NotificationUnhook = null;

    #endregion
}
#nullable restore