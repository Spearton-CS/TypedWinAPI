namespace TypedWinAPI.User32;

unsafe partial struct WndClassExW
{
    public WndClassExW() => this.cbSize = 80;
    public WndClassExW(
        ClassStyles style,
        delegate* unmanaged[Stdcall]<HWND, WndProcMsgType, WParam, LParam, LResult> lpfnWndProc,
        int cbClsExtra,
        int cbWndExtra,
        Kernel32.HInstance hInstance,
        HIcon hIcon,
        HCursor hCursor,
        Handle hbrBackground,
        char* lpszMenuName,
        char* lpszClassName,
        HIcon hIconSm)
    {
        this.cbSize = 80;
        this.style = style;
        this.lpfnWndProc = lpfnWndProc;
        this.cbClsExtra = cbClsExtra;
        this.cbWndExtra = cbWndExtra;
        this.hInstance = hInstance;
        this.hIcon = hIcon;
        this.hCursor = hCursor;
        this.hbrBackground = hbrBackground;
        this.lpszMenuName = lpszMenuName;
        this.lpszClassName = lpszClassName;
        this.hIconSm = hIconSm;
    }
}