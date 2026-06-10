using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class Kernel32
{
    public static void Generate(StringBuilder sb)
    {
        Program.Generate(sb, "_Modules/Kernel32/Handles/RootHandles.g.cs", "Kernel32 (Root)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "Kernel32",
                new("HInstance", "Handle to a Kernel32 ... instance"),
                new("HDevice", "Handle to a Kernel32 device"));
        });
    }
}