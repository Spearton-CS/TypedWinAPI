namespace TypedWinAPI.User32;

partial struct TrackMouseEvent
{
    public TrackMouseEvent() => cbSize = 24;
    public TrackMouseEvent(TrackMouseEventFlags dwFlags, HWND hwndTrack, uint dwHoverTime)
    {
        cbSize = 24;
        this.dwFlags = dwFlags;
        this.hwndTrack = hwndTrack;
        this.dwHoverTime = dwHoverTime;
    }
}