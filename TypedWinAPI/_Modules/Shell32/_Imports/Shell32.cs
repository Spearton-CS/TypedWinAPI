using System.Runtime.InteropServices;

namespace TypedWinAPI.Shell32;

public static unsafe partial class Shell32
{
    public const string DLL = "shell32.dll";

    #region Execution and operations

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 ShellExecuteW(in ExecuteInfoW pExecInfo);

    #endregion

    #region Special folders and Known folders



    #endregion
}