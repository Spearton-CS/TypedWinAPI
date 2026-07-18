#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.User32;

/// <summary>
/// Helper structure to decode keyboard message flags contained in lParam.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly partial struct KeyEventArgsFlags :
	IEqualityOperators<KeyEventArgsFlags, KeyEventArgsFlags, bool>, IEquatable<KeyEventArgsFlags>
{
	#region Construct

	public KeyEventArgsFlags(
LParam lParam
	)
	{
		this.lParam = lParam;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly LParam lParam;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is KeyEventArgsFlags other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(KeyEventArgsFlags other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(KeyEventArgsFlags a, KeyEventArgsFlags b)
	{
		return
		a.lParam == b.lParam
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(KeyEventArgsFlags a, KeyEventArgsFlags b)
	{
		return
		!(a.lParam == b.lParam)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	KeyEventArgsFlags
	{
		lParam: {{lParam}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 16. Abstraction over Win32 Rect
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 16)]
public unsafe readonly partial struct Rect :
	IEqualityOperators<Rect, Rect, bool>, IEquatable<Rect>
{
	#region Construct

	public Rect(
int Left,
int Top,
int Right,
int Bottom
	)
	{
		this.Left = Left;

		this.Top = Top;

		this.Right = Right;

		this.Bottom = Bottom;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly int Left;

	[FieldOffset(4)] public readonly int Top;

	[FieldOffset(8)] public readonly int Right;

	[FieldOffset(12)] public readonly int Bottom;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is Rect other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Rect other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Rect a, Rect b)
	{
		return
		a.Left == b.Left &&

		a.Top == b.Top &&

		a.Right == b.Right &&

		a.Bottom == b.Bottom
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Rect a, Rect b)
	{
		return
		!(a.Left == b.Left) ||

		!(a.Top == b.Top) ||

		!(a.Right == b.Right) ||

		!(a.Bottom == b.Bottom)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	Rect
	{
		Left: {{Left}},

		Top: {{Top}},

		Right: {{Right}},

		Bottom: {{Bottom}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 24. Abstraction over Win32 TrackMouseEvent
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 24)]
public unsafe readonly partial struct TrackMouseEvent :
	IEqualityOperators<TrackMouseEvent, TrackMouseEvent, bool>, IEquatable<TrackMouseEvent>
{

	#region Fields

	[FieldOffset(0)] public readonly uint cbSize;

	[FieldOffset(4)] public readonly TrackMouseEventFlags dwFlags;

	[FieldOffset(8)] public readonly HWND hwndTrack;

	[FieldOffset(16)] public readonly uint dwHoverTime;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is TrackMouseEvent other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(TrackMouseEvent other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(TrackMouseEvent a, TrackMouseEvent b)
	{
		return
		a.cbSize == b.cbSize &&

		a.dwFlags == b.dwFlags &&

		a.hwndTrack == b.hwndTrack &&

		a.dwHoverTime == b.dwHoverTime
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(TrackMouseEvent a, TrackMouseEvent b)
	{
		return
		!(a.cbSize == b.cbSize) ||

		!(a.dwFlags == b.dwFlags) ||

		!(a.hwndTrack == b.hwndTrack) ||

		!(a.dwHoverTime == b.dwHoverTime)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	TrackMouseEvent
	{
		cbSize: {{cbSize}},

		dwFlags: {{dwFlags}},

		hwndTrack: {{hwndTrack}},

		dwHoverTime: {{dwHoverTime}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 40. Abstraction over Win32 MinMaxInfo
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 40)]
public unsafe partial struct MinMaxInfo :
	IEqualityOperators<MinMaxInfo, MinMaxInfo, bool>, IEquatable<MinMaxInfo>
{
	#region Construct

	public MinMaxInfo(
Point ptReserved,
Point ptMaxSize,
Point ptMaxPosition,
Point ptMinTrackSize,
Point ptMaxTrackSize
	)
	{
		this.ptReserved = ptReserved;

		this.ptMaxSize = ptMaxSize;

		this.ptMaxPosition = ptMaxPosition;

		this.ptMinTrackSize = ptMinTrackSize;

		this.ptMaxTrackSize = ptMaxTrackSize;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public Point ptReserved;

	[FieldOffset(8)] public Point ptMaxSize;

	[FieldOffset(16)] public Point ptMaxPosition;

	[FieldOffset(24)] public Point ptMinTrackSize;

	[FieldOffset(32)] public Point ptMaxTrackSize;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is MinMaxInfo other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(MinMaxInfo other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(MinMaxInfo a, MinMaxInfo b)
	{
		return
		a.ptReserved == b.ptReserved &&

		a.ptMaxSize == b.ptMaxSize &&

		a.ptMaxPosition == b.ptMaxPosition &&

		a.ptMinTrackSize == b.ptMinTrackSize &&

		a.ptMaxTrackSize == b.ptMaxTrackSize
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(MinMaxInfo a, MinMaxInfo b)
	{
		return
		!(a.ptReserved == b.ptReserved) ||

		!(a.ptMaxSize == b.ptMaxSize) ||

		!(a.ptMaxPosition == b.ptMaxPosition) ||

		!(a.ptMinTrackSize == b.ptMinTrackSize) ||

		!(a.ptMaxTrackSize == b.ptMaxTrackSize)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	MinMaxInfo
	{
		ptReserved: {{ptReserved}},

		ptMaxSize: {{ptMaxSize}},

		ptMaxPosition: {{ptMaxPosition}},

		ptMinTrackSize: {{ptMinTrackSize}},

		ptMaxTrackSize: {{ptMaxTrackSize}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 40. Abstraction over Win32 MSG
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 40)]
public unsafe partial struct MSG :
	IEqualityOperators<MSG, MSG, bool>, IEquatable<MSG>
{
	#region Construct

	public MSG(
HWND hwnd,
uint message,
WParam wParam,
LParam lParam,
uint time,
Point pt
	)
	{
		this.hwnd = hwnd;

		this.message = message;

		this.wParam = wParam;

		this.lParam = lParam;

		this.time = time;

		this.pt = pt;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public HWND hwnd;

	[FieldOffset(8)] public uint message;

	[FieldOffset(12)] public WParam wParam;

	[FieldOffset(20)] public LParam lParam;

	[FieldOffset(28)] public uint time;

	[FieldOffset(32)] public Point pt;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is MSG other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(MSG other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(MSG a, MSG b)
	{
		return
		a.hwnd == b.hwnd &&

		a.message == b.message &&

		a.wParam == b.wParam &&

		a.lParam == b.lParam &&

		a.time == b.time &&

		a.pt == b.pt
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(MSG a, MSG b)
	{
		return
		!(a.hwnd == b.hwnd) ||

		!(a.message == b.message) ||

		!(a.wParam == b.wParam) ||

		!(a.lParam == b.lParam) ||

		!(a.time == b.time) ||

		!(a.pt == b.pt)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	MSG
	{
		hwnd: {{hwnd}},

		message: {{message}},

		wParam: {{wParam}},

		lParam: {{lParam}},

		time: {{time}},

		pt: {{pt}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 40. Abstraction over Win32 HelpInfo
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 40)]
public unsafe partial struct HelpInfo :
	IEqualityOperators<HelpInfo, HelpInfo, bool>, IEquatable<HelpInfo>
{

	#region Fields

	[FieldOffset(0)] public uint cbSize;

	[FieldOffset(4)] public HelpInfoContextType iContextType;

	[FieldOffset(8)] public int iCtrlId;

	[FieldOffset(16)] public Handle hItemHandle;

	[FieldOffset(16)] public HWND hItemHWND;

	[FieldOffset(16)] public HMenu hItemHMenu;

	[FieldOffset(24)] public nuint dwContextId;

	[FieldOffset(32)] public Point mousePos;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is HelpInfo other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HelpInfo other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HelpInfo a, HelpInfo b)
	{
		return
		a.cbSize == b.cbSize &&

		a.iContextType == b.iContextType &&

		a.iCtrlId == b.iCtrlId &&

		a.hItemHandle == b.hItemHandle &&

		a.dwContextId == b.dwContextId &&

		a.mousePos == b.mousePos
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HelpInfo a, HelpInfo b)
	{
		return
		!(a.cbSize == b.cbSize) ||

		!(a.iContextType == b.iContextType) ||

		!(a.iCtrlId == b.iCtrlId) ||

		!(a.hItemHandle == b.hItemHandle) ||

		!(a.dwContextId == b.dwContextId) ||

		!(a.mousePos == b.mousePos)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	HelpInfo
	{
		cbSize: {{cbSize}},

		iContextType: {{iContextType}},

		iCtrlId: {{iCtrlId}},

		hItemHandle: {{hItemHandle}},

		hItemHWND: {{hItemHWND}},

		hItemHMenu: {{hItemHMenu}},

		dwContextId: {{dwContextId}},

		mousePos: {{mousePos}}
	}
	""";

	#endregion
#endif
}
#nullable restore

