using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class Kernel32
{
    public static void Generate(StringBuilder sb)
    {
#if !DEBUG
        try
        {
#endif
        Console.WriteLineInfo("Starting generation for Kernel32...");

        HandleTemplate.Generate(sb, "Kernel32",
            new("HInstance", "Handle to a Kernel32 ... instance"),
            new("HDevice", "Handle to a Kernel32 device"));

        Console.WriteLineSuccess("Generation done for Kernel32, saving...");

        File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/Kernel32/Handles/RootHandles.g.cs"), sb.ToString());

        Console.WriteLineSuccess("Saved generation for Kernel32");
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation for an Kernel32:\r\n{ex}");
        }
#endif
    }
}