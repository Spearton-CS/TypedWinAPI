namespace TypedWinAPI.User32;

partial struct HelpInfo
{
    public HelpInfo() => cbSize = 40;
    public HelpInfo(HelpInfoContextType iContextType, int iCtrlId, Handle hItemHandle, nuint dwContextId, Point mousePos)
    {
        cbSize = 40;
        this.iContextType = iContextType;
        this.iCtrlId = iCtrlId;
        this.hItemHandle = hItemHandle;
        this.dwContextId = dwContextId;
        this.mousePos = mousePos;
    }
    public HelpInfo(HelpInfoContextType iContextType, int iCtrlId, HWND hItemHWND, nuint dwContextId, Point mousePos)
    {
        cbSize = 40;
        this.iContextType = iContextType;
        this.iCtrlId = iCtrlId;
        this.hItemHWND = hItemHWND;
        this.dwContextId = dwContextId;
        this.mousePos = mousePos;
    }
    public HelpInfo(HelpInfoContextType iContextType, int iCtrlId, HMenu hItemHMenu, nuint dwContextId, Point mousePos)
    {
        cbSize = 40;
        this.iContextType = iContextType;
        this.iCtrlId = iCtrlId;
        this.hItemHMenu = hItemHMenu;
        this.dwContextId = dwContextId;
        this.mousePos = mousePos;
    }
}