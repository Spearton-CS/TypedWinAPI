using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class ADVAPI32
{
    public static void Generate(StringBuilder sb)
    {
#if !DEBUG
        try
        {
#endif
            Console.WriteLineInfo("Starting generation for ADVAPI32...");

            HandleTemplate.Generate(sb, "ADVAPI32",
                new HandleTemplate.Handle("HKey", "Handle to an ADVAPI32 registry key"));

            Console.WriteLineSuccess("Generation done for ADVAPI32, saving...");

            File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/ADVAPI32/Handles/RootHandles.g.cs"), sb.ToString());

            Console.WriteLineSuccess("Saved generation for ADVAPI32");
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation for an ADVAPI32:\r\n{ex}");
        }
#endif
    }
}