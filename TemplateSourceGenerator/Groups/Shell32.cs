using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class Shell32
{
    public static void Generate(StringBuilder sb)
    {
        Program.Generate(sb, "_Modules/Shell32/Handles/RootHandles.g.cs", "Shell32 (Root)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "Shell32",
                new HandleTemplate.Handle("HProcess", "Handle to a Shell32 process"));
        });
    }
}