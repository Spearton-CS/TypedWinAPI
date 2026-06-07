namespace TypedWinAPI.Shell32;

[Flags]
public enum ExecuteMask : uint
{
    None = 0x00000000,
    Class = 0x00000001, // Use lpClass field (Progid)
    ClassKey = 0x00000003, // Use hkeyClass field (Registry key)
    IdList = 0x00000004, // Use lpIDList field (PIDL)
    InvokeIdList = 0x0000000C, // Invoke context menu using lpIDList
    Icon = 0x00000010, // Use hIcon field
    HotKey = 0x00000020, // Use dwHotKey field
    NoCloseProcess = 0x00000040, // Returns valid process handle in hProcess
    ConnectNetDrv = 0x00000080, // Validates and connects network drives
    NoZoneChecks = 0x00000100, // Disables Zone Check prompts (e.g. internet file warnings)
    FlagNoUi = 0x00000400, // Prevents error message dialogs
    Unicode = 0x00004000, // Forces unicode interpretation inside shell
    NoConsole = 0x00008000, // Prevents creating a console window for console apps
    AsmvVerb = 0x00010000, // Application state management flags
    DdeWait = 0x00000100, // Wait for DDE conversation to terminate
    DoZoneChecks = 0x00800000, // Enforces security zone checks
    NoAsync = 0x00100000, // Wait for execution to complete before returning
    FlagHInstIsHInstance = 0x00000020, // Forces hInstApp to remain a handle rather than error status
    WaitForInputIdle = 0x02000000, // Waits for new process to become idle before returning
    FlagLogUsage = 0x04000000  // Logs application execution telemetry
}