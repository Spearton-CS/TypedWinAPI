namespace TemplateSourceGenerator;

internal static class Const
{
    public static readonly string[]
        DefaultUsings =
        [
            "System.Diagnostics",
            "System.Diagnostics.CodeAnalysis",
            "System.Runtime.CompilerServices",
            "System.Runtime.InteropServices",
            "TypedWinAPI.Contracts",
            "TypedWinAPI.Contracts.Ptr"
        ],
        DefaultAttributes =
        [
            "StructLayout(LayoutKind.Explicit, Size = 8)",
            "DebuggerDisplay(\"{ToString(),nq}\")",
            "DebuggerStepThrough",
            "SkipLocalsInit"
        ];

    public const string Inlined = "[MethodImpl(MethodImplOptions.AggressiveInlining)]";
}