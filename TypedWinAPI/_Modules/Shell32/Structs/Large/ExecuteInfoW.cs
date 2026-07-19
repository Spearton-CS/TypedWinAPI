namespace TypedWinAPI.Shell32;

unsafe partial struct ExecuteInfoW
{
    public ExecuteInfoW() => this.cbSize = 120;
    public ExecuteInfoW(
        ExecuteMask fMask,
        User32.HWND hwnd,
        char* lpVerb,
        char* lpFile,
        char* lpParameters,
        char* lpDirectory,
        User32.ShowWindowCommand nShow,
        Kernel32.HInstance hInstApp,
        SHItemID* lpIDList,
        char* lpClass,
        ADVAPI32.HKey hKeyClass,
        User32.HotKey dwHotKey,
        User32.HIcon hIcon,
        SHCore.HMonitor hMonitor,
        HProcess hProcess)
    {
        this.cbSize = 120;
        this.fMask = fMask;
        this.hwnd = hwnd;
        this.lpVerb = lpVerb;
        this.lpFile = lpFile;
        this.lpParameters = lpParameters;
        this.lpDirectory = lpDirectory;
        this.nShow = nShow;
        this.hInstApp = hInstApp;
        this.lpIDList = lpIDList;
        this.lpClass = lpClass;
        this.hKeyClass = hKeyClass;
        this.dwHotKey = dwHotKey;
        this.hIcon = hIcon;
        this.hMonitor = hMonitor;
        this.hProcess = hProcess;
    }
}