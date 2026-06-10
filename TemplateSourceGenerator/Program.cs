using System.Diagnostics.CodeAnalysis;
using System.Text;

using TemplateSourceGenerator.Groups;
using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator;

internal static class Program
{
    public const string TypedWinAPI_DIR = "../../../../TypedWinAPI";

    internal static void Generate(StringBuilder sb, [ConstantExpected] string path, [ConstantExpected] string displayName, Action<StringBuilder> gen)
    {
        try
        {
            Console.WriteLineInfo($"Starting generation for {displayName}");
            gen(sb);
            Console.WriteLineSuccess($"Generation done for {displayName}, saving...");
            File.WriteAllText(Path.GetFullPath($"{TypedWinAPI_DIR}/{path}"), sb.ToString());
            sb.Clear();
            Console.WriteLineSuccess($"Generation saved for {displayName}");
        }
#if !DEBUG
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an exception during generation for an {displayName}:\r\n{ex}");
        }
#endif
        finally
        {
            sb.Clear();
        }
    }

    static void Main()
    {
#if !DEBUG
        try
        {
#endif
        StringBuilder sb = new();

        Console.WriteLineInfo("Starting generation...");

        ADVAPI32.Generate(sb);

        GDI32.Generate(sb);

        GDIPlus.Generate(sb);

        Kernel32.Generate(sb);

        MSimg32.Generate(sb);

        SHCore.Generate(sb);

        Shell32.Generate(sb);

        User32.Generate(sb);

        Console.WriteLineSuccess("Generation ended");
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an exception during generation:\r\n{ex}");
        }
#endif
    }

    extension(Console)
    {
        public static void Write(string? text, ConsoleColor fore)
        {
            var oldFore = Console.ForegroundColor;
            Console.ForegroundColor = fore;
            Console.Write(text);
            Console.ForegroundColor = oldFore;
        }
        public static void WriteLine(string? text, ConsoleColor fore)
        {
            var oldFore = Console.ForegroundColor;
            Console.ForegroundColor = fore;
            Console.WriteLine(text);
            Console.ForegroundColor = oldFore;
        }
        public static void WriteSuccess(string? text) => Write(text, ConsoleColor.Green);
        public static void WriteInfo(string? text) => Write(text, ConsoleColor.Blue);
        public static void WriteWarning(string? text) => Write(text, ConsoleColor.Yellow);
        public static void WriteError(string? text) => Write(text, ConsoleColor.Red);

        public static void WriteLineSuccess(string? text) => WriteLine(text, ConsoleColor.Green);
        public static void WriteLineInfo(string? text) => WriteLine(text, ConsoleColor.Blue);
        public static void WriteLineWarning(string? text) => WriteLine(text, ConsoleColor.Yellow);
        public static void WriteLineError(string? text) => WriteLine(text, ConsoleColor.Red);
    }
}