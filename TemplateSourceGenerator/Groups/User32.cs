using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class User32
{
    public static void Generate(StringBuilder sb)
    {
#if !DEBUG
        try
        {
#endif
            Console.WriteLineInfo("Starting generation for User32...");

            HandleTemplate.Generate(sb, "User32",
                new("HWND", "Handle to an User32 window"),
                new("HMenu", "Handle to an User32 menu"),
                new("HCursor", "Handle to an User32 cursor"),
                new("HIcon", "Handle to an User32 icon"));

            Console.WriteLineSuccess("Generation done for User32, saving...");

            File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/User32/Handles/RootHandles.g.cs"), sb.ToString());

            Console.WriteLineSuccess("Saved generation for User32");

            Console.WriteLineInfo("Starting generation for User32 (16-bit)...");

            Handle16Template.Generate(sb, "User32",
                new Handle16Template.Handle16("ATOM", "Handle16 to an User32 ..."));

            Console.WriteLineSuccess("Generation done for User32 (16-bit), saving...");

            File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/User32/Handles/RootHandles16.g.cs"), sb.ToString());

            Console.WriteLineSuccess("Saved generation for User32 (16-bit)");
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation for an User32:\r\n{ex}");
        }
#endif
    }
}