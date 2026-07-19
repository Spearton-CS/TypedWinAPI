namespace TypedWinAPI.User32;

unsafe partial struct MsgBoxParamsW
{
    public MsgBoxParamsW() => this.cbSize = 68;
    public MsgBoxParamsW(
        HWND hwndOwner,
        Kernel32.HInstance hInstance,
        char* lpszText,
        char* lpszCaption,
        MessageBoxStyle dwStyle,
        char* lpszIcon,
        nuint dwContextHelpId,
        delegate* unmanaged[Stdcall]<HelpInfo*, void> lpfnMsgBoxCallback,
        Kernel32.LanguageId dwLanguageId)
    {
        this.cbSize = 68;
        this.hwndOwner = hwndOwner;
        this.hInstance = hInstance;
        this.lpszText = lpszText;
        this.lpszCaption = lpszCaption;
        this.dwStyle = dwStyle;
        this.lpszIcon = lpszIcon;
        this.dwContextHelpId = dwContextHelpId;
        this.lpfnMsgBoxCallback = lpfnMsgBoxCallback;
        this.dwLanguageId = dwLanguageId;
    }
}