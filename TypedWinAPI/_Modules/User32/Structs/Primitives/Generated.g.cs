#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.User32;

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 8. Abstraction over Win32 Point
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly partial struct Point :
	IEqualityOperators<Point, Point, bool>, IEquatable<Point>
{
	#region Construct

	public Point(
	int X,
	int Y
	)
	{
		this.X = X;

		this.Y = Y;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly int X;

	[FieldOffset(4)] public readonly int Y;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is Point other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Point other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Point a, Point b)
	{
		return
		a.X == b.X &&

		a.Y == b.Y
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Point a, Point b)
	{
		return
		!(a.X == b.X) &&

		!(a.Y == b.Y)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	Point
	{
		X: {{X}},

		Y: {{Y}}
	}
	""";

	#endregion
#endif
}

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 8. Abstraction over Win32 Size
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly partial struct Size :
	IEqualityOperators<Size, Size, bool>, IEquatable<Size>
{
	#region Construct

	public Size(
	int Width,
	int Height
	)
	{
		this.Width = Width;

		this.Height = Height;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly int Width;

	[FieldOffset(4)] public readonly int Height;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is Size other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Size other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Size a, Size b)
	{
		return
		a.Width == b.Width &&

		a.Height == b.Height
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Size a, Size b)
	{
		return
		!(a.Width == b.Width) &&

		!(a.Height == b.Height)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	Size
	{
		Width: {{Width}},

		Height: {{Height}}
	}
	""";

	#endregion
#endif
}

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 4. Abstraction over Win32 HotKey
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 4)]
public unsafe readonly partial struct HotKey :
	IEqualityOperators<HotKey, HotKey, bool>, IEquatable<HotKey>
{
	#region Construct

	public HotKey(
	uint Raw
	)
	{
		this.Raw = Raw;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly uint Raw;

	[FieldOffset(0)] public readonly byte VirtualKeyRaw;

	[FieldOffset(0)] public readonly VirtualKey VirtualKey;

	[FieldOffset(1)] public readonly HotKeyModifier Modifier;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is HotKey other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HotKey other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HotKey a, HotKey b)
	{
		return
		a.Raw == b.Raw
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HotKey a, HotKey b)
	{
		return
		!(a.Raw == b.Raw)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	HotKey
	{
		Raw: {{Raw}},

		VirtualKeyRaw: {{VirtualKeyRaw}},

		VirtualKey: {{VirtualKey}},

		Modifier: {{Modifier}}
	}
	""";

	#endregion
#endif
}

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 8. Abstraction over Win32 LParam
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly partial struct LParam :
	IEqualityOperators<LParam, LParam, bool>, IEquatable<LParam>
{

	#region Fields

	[FieldOffset(0)] public readonly nint SignedValue;

	[FieldOffset(0)] public readonly nuint UnsignedValue;

	[FieldOffset(0)] public readonly void* PointerValue;

	[FieldOffset(0)] public readonly Handle HandleValue;

	[FieldOffset(0)] public readonly Handle16 Handle16Value;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is LParam other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(LParam other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(LParam a, LParam b)
	{
		return
		a.SignedValue == b.SignedValue
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(LParam a, LParam b)
	{
		return
		!(a.SignedValue == b.SignedValue)
;
	}

	#endregion
}

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 8. Abstraction over Win32 LResult
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly partial struct LResult :
	IEqualityOperators<LResult, LResult, bool>, IEquatable<LResult>
{

	#region Fields

	[FieldOffset(0)] public readonly nint SignedValue;

	[FieldOffset(0)] public readonly nuint UnsignedValue;

	[FieldOffset(0)] public readonly void* PointerValue;

	[FieldOffset(0)] public readonly Handle HandleValue;

	[FieldOffset(0)] public readonly Handle16 Handle16Value;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is LResult other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(LResult other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(LResult a, LResult b)
	{
		return
		a.SignedValue == b.SignedValue
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(LResult a, LResult b)
	{
		return
		!(a.SignedValue == b.SignedValue)
;
	}

	#endregion
}

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 8. Abstraction over Win32 WParam
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly partial struct WParam :
	IEqualityOperators<WParam, WParam, bool>, IEquatable<WParam>
{

	#region Fields

	[FieldOffset(0)] public readonly nint SignedValue;

	[FieldOffset(0)] public readonly nuint UnsignedValue;

	[FieldOffset(0)] public readonly void* PointerValue;

	[FieldOffset(0)] public readonly Handle HandleValue;

	[FieldOffset(0)] public readonly Handle16 Handle16Value;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is WParam other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(WParam other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(WParam a, WParam b)
	{
		return
		a.SignedValue == b.SignedValue
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(WParam a, WParam b)
	{
		return
		!(a.SignedValue == b.SignedValue)
;
	}

	#endregion
}

#nullable restore

