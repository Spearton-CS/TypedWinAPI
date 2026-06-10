using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class ADVAPI32
{
    public static void Generate(StringBuilder sb)
    {
        Program.Generate(sb, "_Modules/ADVAPI32/Handles/RootHandles.g.cs", "ADVAPI32 (Root)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "ADVAPI32",
                new HandleTemplate.Handle("HKey", "Handle to an ADVAPI32 registry key"));
        });
    }
}