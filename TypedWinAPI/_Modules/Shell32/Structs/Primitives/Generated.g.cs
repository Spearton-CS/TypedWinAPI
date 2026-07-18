#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.Shell32;

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 2. Abstraction over Win32 SHItemID
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 2)]
public unsafe readonly partial struct SHItemID :
	IEqualityOperators<SHItemID, SHItemID, bool>, IEquatable<SHItemID>
{
	#region Construct

	public SHItemID(
	ushort cb
	)
	{
		this.cb = cb;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly ushort cb;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is SHItemID other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(SHItemID other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(SHItemID a, SHItemID b)
	{
		return
		a.cb == b.cb
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(SHItemID a, SHItemID b)
	{
		return
		!(a.cb == b.cb)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	SHItemID
	{
		cb: {{cb}}
	}
	""";

	#endregion
#endif
}

#nullable restore

