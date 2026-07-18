#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI;

/// <summary>
/// Blittable (unmanaged) primitive (read-only) struct with size 4. Abstraction over Win32 HResult
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 4)]
public unsafe readonly partial struct HResult :
	IEqualityOperators<HResult, HResult, bool>, IEquatable<HResult>
{

	#region Fields

	[FieldOffset(0)] public readonly int SignedValue;

	[FieldOffset(0)] public readonly uint UnsignedValue;

	#endregion

}

#nullable restore

