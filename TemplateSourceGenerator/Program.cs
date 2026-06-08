using System.Text;

using TemplateSourceGenerator.Groups;

namespace TemplateSourceGenerator;

internal static class Program
{
    public const string TypedWinAPI_DIR = "../../../../TypedWinAPI";

    static void Main()
    {
#if !DEBUG
        try
        {
#endif
            StringBuilder sb = new();

            Console.WriteLineInfo("Starting generation...");
            ADVAPI32.Generate(sb);
            sb.Clear();
            GDI32.Generate(sb);
            sb.Clear();
            GDIPlus.Generate(sb);
            sb.Clear();
            Kernel32.Generate(sb);
            sb.Clear();
            MSimg32.Generate(sb);
            sb.Clear();
            SHCore.Generate(sb);
            sb.Clear();
            Shell32.Generate(sb);
            sb.Clear();
            User32.Generate(sb);
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation:\r\n{ex}");
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