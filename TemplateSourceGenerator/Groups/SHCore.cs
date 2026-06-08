using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class SHCore
{
    public static void Generate(StringBuilder sb)
    {
#if !DEBUG
        try
        {
#endif
        Console.WriteLineInfo("Starting generation for SHCore...");

        HandleTemplate.Generate(sb, "SHCore",
            new HandleTemplate.Handle("HMonitor", "Handle to a SHCore monitor"));

        Console.WriteLineSuccess("Generation done for SHCore, saving...");

        File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/SHCore/Handles/RootHandles.g.cs"), sb.ToString());

        Console.WriteLineSuccess("Saved generation for SHCore");
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation for an SHCore:\r\n{ex}");
        }
#endif
    }
}