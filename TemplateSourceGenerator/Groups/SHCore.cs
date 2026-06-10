using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class SHCore
{
    public static void Generate(StringBuilder sb)
    {
        Program.Generate(sb, "_Modules/SHCore/Handles/RootHandles.g.cs", "SHCore (Root)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "SHCore",
                new HandleTemplate.Handle("HMonitor", "Handle to a SHCore monitor"));
        });
    }
}