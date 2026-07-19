#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.Shell32;
/// <summary>
/// Blittable (unmanaged) large struct with size 120. Abstraction over Win32 ExecuteInfoW
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 120)]
public unsafe partial struct ExecuteInfoW
{

	#region Fields

	[FieldOffset(0)] public readonly uint cbSize;

	[FieldOffset(8)] public ExecuteMask fMask;

	[FieldOffset(16)] public User32.HWND hwnd;

	[FieldOffset(24)] public char* lpVerb;

	[FieldOffset(32)] public char* lpFile;

	[FieldOffset(40)] public char* lpParameters;

	[FieldOffset(48)] public char* lpDirectory;

	[FieldOffset(56)] public User32.ShowWindowCommand nShow;

	[FieldOffset(64)] public Kernel32.HInstance hInstApp;

	[FieldOffset(72)] public SHItemID* lpIDList;

	[FieldOffset(80)] public char* lpClass;

	[FieldOffset(88)] public ADVAPI32.HKey hKeyClass;

	[FieldOffset(96)] public User32.HotKey dwHotKey;

	[FieldOffset(104)] public User32.HIcon hIcon;

	[FieldOffset(104)] public SHCore.HMonitor hMonitor;

	[FieldOffset(112)] public HProcess hProcess;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is ExecuteInfoW other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(scoped in ExecuteInfoW other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(scoped in ExecuteInfoW a, scoped in ExecuteInfoW b)
	{
		return
		a.cbSize == b.cbSize &&

		a.fMask == b.fMask &&

		a.hwnd == b.hwnd &&

		a.lpVerb == b.lpVerb &&

		a.lpFile == b.lpFile &&

		a.lpParameters == b.lpParameters &&

		a.lpDirectory == b.lpDirectory &&

		a.nShow == b.nShow &&

		a.hInstApp == b.hInstApp &&

		a.lpIDList == b.lpIDList &&

		a.lpClass == b.lpClass &&

		a.hKeyClass == b.hKeyClass &&

		a.dwHotKey == b.dwHotKey &&

		a.hIcon == b.hIcon &&

		a.hProcess == b.hProcess
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(scoped in ExecuteInfoW a, scoped in ExecuteInfoW b)
	{
		return
		!(a.cbSize == b.cbSize) ||

		!(a.fMask == b.fMask) ||

		!(a.hwnd == b.hwnd) ||

		!(a.lpVerb == b.lpVerb) ||

		!(a.lpFile == b.lpFile) ||

		!(a.lpParameters == b.lpParameters) ||

		!(a.lpDirectory == b.lpDirectory) ||

		!(a.nShow == b.nShow) ||

		!(a.hInstApp == b.hInstApp) ||

		!(a.lpIDList == b.lpIDList) ||

		!(a.lpClass == b.lpClass) ||

		!(a.hKeyClass == b.hKeyClass) ||

		!(a.dwHotKey == b.dwHotKey) ||

		!(a.hIcon == b.hIcon) ||

		!(a.hProcess == b.hProcess)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	ExecuteInfoW
	{
		cbSize: {{cbSize}},

		fMask: {{fMask}},

		hwnd: {{hwnd}},

		lpVerb: {{(nuint)lpVerb:X16}},

		lpFile: {{(nuint)lpFile:X16}},

		lpParameters: {{(nuint)lpParameters:X16}},

		lpDirectory: {{(nuint)lpDirectory:X16}},

		nShow: {{nShow}},

		hInstApp: {{hInstApp}},

		lpIDList: {{(nuint)lpIDList:X16}},

		lpClass: {{(nuint)lpClass:X16}},

		hKeyClass: {{hKeyClass}},

		dwHotKey: {{dwHotKey}},

		hIcon: {{hIcon}},

		hMonitor: {{hMonitor}},

		hProcess: {{hProcess}}
	}
	""";

	#endregion
#endif
}
#nullable restore

