#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.MSimg32;

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 4. Abstraction over Win32 BlendFunction
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 4)]
public unsafe readonly partial struct BlendFunction :
	IEqualityOperators<BlendFunction, BlendFunction, bool>, IEquatable<BlendFunction>
{

	#region Fields

	[FieldOffset(0)] public readonly int SignedRaw;

	[FieldOffset(0)] public readonly uint UnsignedRaw;

	[FieldOffset(0)] public readonly byte BlendOp;

	[FieldOffset(1)] public readonly byte BlendFlags;

	[FieldOffset(2)] public readonly byte SourceConstantAlpha;

	[FieldOffset(3)] public readonly byte AlphaFormat;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is BlendFunction other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(BlendFunction other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(BlendFunction a, BlendFunction b)
	{
		return
		a.SignedRaw == b.SignedRaw
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(BlendFunction a, BlendFunction b)
	{
		return
		!(a.SignedRaw == b.SignedRaw)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	BlendFunction
	{
		SignedRaw: {{SignedRaw}},

		UnsignedRaw: {{UnsignedRaw}},

		BlendOp: {{BlendOp}},

		BlendFlags: {{BlendFlags}},

		SourceConstantAlpha: {{SourceConstantAlpha}},

		AlphaFormat: {{AlphaFormat}}
	}
	""";

	#endregion
#endif
}

#nullable restore

