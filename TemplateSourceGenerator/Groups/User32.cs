using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class User32
{
    public static void Generate(StringBuilder sb)
    {
        Program.Generate(sb, "_Modules/User32/Handles/RootHandles.g.cs", "User32 (Root)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "User32",
                new("HWND", "Handle to an User32 window"),
                new("HMenu", "Handle to an User32 menu"),
                new("HCursor", "Handle to an User32 cursor"),
                new("HIcon", "Handle to an User32 icon"));
        });

        Program.Generate(sb, "_Modules/User32/Handles/RootHandles16.g.cs", "User32 (Root 16-bit)", static (sb) =>
        {
            Handle16Template.Generate(sb, "User32",
                new Handle16Template.Handle16("ATOM", "Handle16 to an User32 ..."));
        });
    }
}