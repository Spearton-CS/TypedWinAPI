#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.User32;

/// <summary>
/// Blittable (unmanaged) large struct with size 72. Abstraction over Win32 CreateStructW
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 72)]
public unsafe partial struct CreateStructW
{
	#region Construct

	public CreateStructW(
void* lpCreateParams,
Kernel32.HInstance hInstance,
HMenu hMenu,
HWND hwndParent,
int cy,
int cx,
int y,
int x,
WindowStyles style,
char* lpszName,
char* lpszClass,
WindowExStyles dwExStyle
	)
	{
		this.lpCreateParams = lpCreateParams;

		this.hInstance = hInstance;

		this.hMenu = hMenu;

		this.hwndParent = hwndParent;

		this.cy = cy;

		this.cx = cx;

		this.y = y;

		this.x = x;

		this.style = style;

		this.lpszName = lpszName;

		this.lpszClass = lpszClass;

		this.dwExStyle = dwExStyle;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public void* lpCreateParams;

	[FieldOffset(8)] public Kernel32.HInstance hInstance;

	[FieldOffset(16)] public HMenu hMenu;

	[FieldOffset(24)] public HWND hwndParent;

	[FieldOffset(32)] public int cy;

	[FieldOffset(36)] public int cx;

	[FieldOffset(40)] public int y;

	[FieldOffset(44)] public int x;

	[FieldOffset(48)] public WindowStyles style;

	[FieldOffset(52)] public char* lpszName;

	[FieldOffset(60)] public char* lpszClass;

	[FieldOffset(68)] public WindowExStyles dwExStyle;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is CreateStructW other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(scoped in CreateStructW other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(scoped in CreateStructW a, scoped in CreateStructW b)
	{
		return
		a.lpCreateParams == b.lpCreateParams &&

		a.hInstance == b.hInstance &&

		a.hMenu == b.hMenu &&

		a.hwndParent == b.hwndParent &&

		a.cy == b.cy &&

		a.cx == b.cx &&

		a.y == b.y &&

		a.x == b.x &&

		a.style == b.style &&

		a.lpszName == b.lpszName &&

		a.lpszClass == b.lpszClass &&

		a.dwExStyle == b.dwExStyle
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(scoped in CreateStructW a, scoped in CreateStructW b)
	{
		return
		!(a.lpCreateParams == b.lpCreateParams) ||

		!(a.hInstance == b.hInstance) ||

		!(a.hMenu == b.hMenu) ||

		!(a.hwndParent == b.hwndParent) ||

		!(a.cy == b.cy) ||

		!(a.cx == b.cx) ||

		!(a.y == b.y) ||

		!(a.x == b.x) ||

		!(a.style == b.style) ||

		!(a.lpszName == b.lpszName) ||

		!(a.lpszClass == b.lpszClass) ||

		!(a.dwExStyle == b.dwExStyle)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	CreateStructW
	{
		lpCreateParams: {{(nuint)lpCreateParams:X16}},

		hInstance: {{hInstance}},

		hMenu: {{hMenu}},

		hwndParent: {{hwndParent}},

		cy: {{cy}},

		cx: {{cx}},

		y: {{y}},

		x: {{x}},

		style: {{style}},

		lpszName: {{(nuint)lpszName:X16}},

		lpszClass: {{(nuint)lpszClass:X16}},

		dwExStyle: {{dwExStyle}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) large struct with size 72. Abstraction over Win32 PaintStruct
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 72)]
public unsafe partial struct PaintStruct
{

	#region Fields

	[FieldOffset(0)] public Handle hdc;

	[FieldOffset(8)] public Bool4 fErase;

	[FieldOffset(12)] public Rect rcPaint;

	[FieldOffset(28)] public Bool4 fRestore;

	[FieldOffset(32)] public Bool4 fIncUpdate;

	[FieldOffset(40)] public fixed byte rgbReserved[32];

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is PaintStruct other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(scoped in PaintStruct other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(scoped in PaintStruct a, scoped in PaintStruct b)
	{
		return
		a.hdc == b.hdc &&

		a.fErase == b.fErase &&

		a.rcPaint == b.rcPaint &&

		a.fRestore == b.fRestore &&

		a.fIncUpdate == b.fIncUpdate &&

		MemoryMarshal.CreateReadOnlySpan< byte>(in a.rgbReserved[0], 32).SequenceEqual(MemoryMarshal.CreateReadOnlySpan< byte>(in b.rgbReserved[0], 32))
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(scoped in PaintStruct a, scoped in PaintStruct b)
	{
		return
		!(a.hdc == b.hdc) ||

		!(a.fErase == b.fErase) ||

		!(a.rcPaint == b.rcPaint) ||

		!(a.fRestore == b.fRestore) ||

		!(a.fIncUpdate == b.fIncUpdate) ||

		!(MemoryMarshal.CreateReadOnlySpan< byte>(in a.rgbReserved[0], 32).SequenceEqual(MemoryMarshal.CreateReadOnlySpan< byte>(in b.rgbReserved[0], 32)))
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	PaintStruct
	{
		hdc: {{hdc}},

		fErase: {{fErase}},

		rcPaint: {{rcPaint}},

		fRestore: {{fRestore}},

		fIncUpdate: {{fIncUpdate}},

		rgbReserved: {{"fixed byte[32]"}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) large struct with size 80. Abstraction over Win32 WndClassExW
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 80)]
public unsafe partial struct WndClassExW
{

	#region Fields

	[FieldOffset(0)] public uint cbSize;

	[FieldOffset(4)] public ClassStyles style;

	[FieldOffset(8)] public delegate* unmanaged[Stdcall]<HWND, WndProcMsgType, WParam, LParam, LResult> lpfnWndProc;

	[FieldOffset(16)] public int cbClsExtra;

	[FieldOffset(20)] public int cbWndExtra;

	[FieldOffset(24)] public Kernel32.HInstance hInstance;

	[FieldOffset(32)] public HIcon hIcon;

	[FieldOffset(40)] public HCursor hCursor;

	[FieldOffset(48)] public Handle hbrBackground;

	[FieldOffset(56)] public char* lpszMenuName;

	[FieldOffset(64)] public char* lpszClassName;

	[FieldOffset(72)] public HIcon hIconSm;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is WndClassExW other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(scoped in WndClassExW other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(scoped in WndClassExW a, scoped in WndClassExW b)
	{
		return
		a.cbSize == b.cbSize &&

		a.style == b.style &&

		a.lpfnWndProc == b.lpfnWndProc &&

		a.cbClsExtra == b.cbClsExtra &&

		a.cbWndExtra == b.cbWndExtra &&

		a.hInstance == b.hInstance &&

		a.hIcon == b.hIcon &&

		a.hCursor == b.hCursor &&

		a.hbrBackground == b.hbrBackground &&

		a.lpszMenuName == b.lpszMenuName &&

		a.lpszClassName == b.lpszClassName &&

		a.hIconSm == b.hIconSm
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(scoped in WndClassExW a, scoped in WndClassExW b)
	{
		return
		!(a.cbSize == b.cbSize) ||

		!(a.style == b.style) ||

		!(a.lpfnWndProc == b.lpfnWndProc) ||

		!(a.cbClsExtra == b.cbClsExtra) ||

		!(a.cbWndExtra == b.cbWndExtra) ||

		!(a.hInstance == b.hInstance) ||

		!(a.hIcon == b.hIcon) ||

		!(a.hCursor == b.hCursor) ||

		!(a.hbrBackground == b.hbrBackground) ||

		!(a.lpszMenuName == b.lpszMenuName) ||

		!(a.lpszClassName == b.lpszClassName) ||

		!(a.hIconSm == b.hIconSm)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	WndClassExW
	{
		cbSize: {{cbSize}},

		style: {{style}},

		lpfnWndProc: {{(nuint)lpfnWndProc:X16}},

		cbClsExtra: {{cbClsExtra}},

		cbWndExtra: {{cbWndExtra}},

		hInstance: {{hInstance}},

		hIcon: {{hIcon}},

		hCursor: {{hCursor}},

		hbrBackground: {{hbrBackground}},

		lpszMenuName: {{(nuint)lpszMenuName:X16}},

		lpszClassName: {{(nuint)lpszClassName:X16}},

		hIconSm: {{hIconSm}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) large struct with size 68. Abstraction over Win32 MsgBoxParamsW
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 68)]
public unsafe partial struct MsgBoxParamsW
{

	#region Fields

	[FieldOffset(0)] public uint cbSize;

	[FieldOffset(4)] public HWND hwndOwner;

	[FieldOffset(12)] public Kernel32.HInstance hInstance;

	[FieldOffset(20)] public char* lpszText;

	[FieldOffset(28)] public char* lpszCaption;

	[FieldOffset(36)] public MessageBoxStyle dwStyle;

	[FieldOffset(40)] public char* lpszIcon;

	[FieldOffset(48)] public nuint dwContextHelpId;

	[FieldOffset(56)] public delegate* unmanaged[Stdcall]<HelpInfo*, void> lpfnMsgBoxCallback;

	[FieldOffset(64)] public Kernel32.LanguageId dwLanguageId;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is MsgBoxParamsW other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(scoped in MsgBoxParamsW other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(scoped in MsgBoxParamsW a, scoped in MsgBoxParamsW b)
	{
		return
		a.cbSize == b.cbSize &&

		a.hwndOwner == b.hwndOwner &&

		a.hInstance == b.hInstance &&

		a.lpszText == b.lpszText &&

		a.lpszCaption == b.lpszCaption &&

		a.dwStyle == b.dwStyle &&

		a.lpszIcon == b.lpszIcon &&

		a.dwContextHelpId == b.dwContextHelpId &&

		a.lpfnMsgBoxCallback == b.lpfnMsgBoxCallback &&

		a.dwLanguageId == b.dwLanguageId
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(scoped in MsgBoxParamsW a, scoped in MsgBoxParamsW b)
	{
		return
		!(a.cbSize == b.cbSize) ||

		!(a.hwndOwner == b.hwndOwner) ||

		!(a.hInstance == b.hInstance) ||

		!(a.lpszText == b.lpszText) ||

		!(a.lpszCaption == b.lpszCaption) ||

		!(a.dwStyle == b.dwStyle) ||

		!(a.lpszIcon == b.lpszIcon) ||

		!(a.dwContextHelpId == b.dwContextHelpId) ||

		!(a.lpfnMsgBoxCallback == b.lpfnMsgBoxCallback) ||

		!(a.dwLanguageId == b.dwLanguageId)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	MsgBoxParamsW
	{
		cbSize: {{cbSize}},

		hwndOwner: {{hwndOwner}},

		hInstance: {{hInstance}},

		lpszText: {{(nuint)lpszText:X16}},

		lpszCaption: {{(nuint)lpszCaption:X16}},

		dwStyle: {{dwStyle}},

		lpszIcon: {{(nuint)lpszIcon:X16}},

		dwContextHelpId: {{dwContextHelpId}},

		lpfnMsgBoxCallback: {{(nuint)lpfnMsgBoxCallback:X16}},

		dwLanguageId: {{dwLanguageId}}
	}
	""";

	#endregion
#endif
}
#nullable restore

