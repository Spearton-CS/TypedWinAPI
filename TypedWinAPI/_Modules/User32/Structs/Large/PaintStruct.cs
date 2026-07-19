namespace TypedWinAPI.User32;

partial struct PaintStruct
{
    public PaintStruct(Handle hdc, Bool4 fErase, Rect rcPaint, Bool4 fRestore, Bool4 fIncUpdate)
    {
        this.hdc = hdc;
        this.fErase = fErase;
        this.rcPaint = rcPaint;
        this.fRestore = fRestore;
        this.fIncUpdate = fIncUpdate;
    }
}