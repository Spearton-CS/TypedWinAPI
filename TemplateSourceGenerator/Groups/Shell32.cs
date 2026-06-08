using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class Shell32
{
    public static void Generate(StringBuilder sb)
    {
#if !DEBUG
        try
        {
#endif
        Console.WriteLineInfo("Starting generation for Shell32...");

        HandleTemplate.Generate(sb, "Shell32",
            new HandleTemplate.Handle("HProcess", "Handle to a Shell32 process"));

        Console.WriteLineSuccess("Generation done for Shell32, saving...");

        File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/Shell32/Handles/RootHandles.g.cs"), sb.ToString());

        Console.WriteLineSuccess("Saved generation for Shell32");
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation for an Shell32:\r\n{ex}");
        }
#endif
    }
}