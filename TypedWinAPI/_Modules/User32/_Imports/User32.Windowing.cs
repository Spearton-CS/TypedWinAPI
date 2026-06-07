using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

unsafe partial class User32
{
    #region Registration and unregistration

    /// <summary> Registers a window class for subsequent use in calls to the CreateWindowExW function. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial ATOM RegisterClassExW(in WndClassExW classEx);

    #endregion

    #region Creation

    /// <summary> Creates an overlapped, pop-up, or child window with an extended window style. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND CreateWindowExW(
        WindowExStyles dwExStyle, char* lpClassName, char* lpWindowName, WindowStyles dwStyle,
        int X, int Y, int nWidth, int nHeight, HWND hWndParent, HMenu hMenu, Kernel32.HInstance hInstance, void* lpParam);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND CreateWindowExW(WindowExStyles dwExStyle, char* lpClassName, char* lpWindowName, WindowStyles dwStyle,
        Rect rect, HWND hWndParent, HMenu hMenu, Kernel32.HInstance hInstance, void* lpParam)
        => CreateWindowExW(dwExStyle, lpClassName, lpWindowName, dwStyle,
            rect.X, rect.Y, rect.Width, rect.Height, hWndParent, hMenu, hInstance, lpParam);

    /// <summary> Creates a window using managed strings for class and window names. </summary>
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial HWND CreateWindowExW(
        WindowExStyles dwExStyle, string? lpClassName, string? lpWindowName, WindowStyles dwStyle,
        int X, int Y, int nWidth, int nHeight, HWND hWndParent, HMenu hMenu, Kernel32.HInstance hInstance, void* lpParam);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HWND CreateWindowExW(WindowExStyles dwExStyle, string? lpClassName, string? lpWindowName, WindowStyles dwStyle,
        Rect rect, HWND hWndParent, HMenu hMenu, Kernel32.HInstance hInstance, void* lpParam)
        => CreateWindowExW(dwExStyle, lpClassName, lpWindowName, dwStyle,
            rect.X, rect.Y, rect.Width, rect.Height, hWndParent, hMenu, hInstance, lpParam);

    #endregion

    #region Destroying

    /// <summary> Destroys the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 DestroyWindow(HWND hwnd);

    #endregion

    #region WndProc

    /// <summary> Calls the default window procedure to provide default processing for any window messages. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial LResult DefWindowProcW(HWND hwnd, WndProcMsgType msg, WParam wParam, LParam lParam);

    /// <summary> Indicates to the system that a thread has made a request to terminate (quit). </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial void PostQuitMessage(int nExitCode);

    /// <summary> Retrieves a message from the calling thread's message queue. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 GetMessageW(out MSG lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
    /// <summary> Translates virtual-key messages into character messages. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 TranslateMessage(in MSG lpMsg);
    /// <summary> Dispatches a message to a window procedure. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial LResult DispatchMessageW(in MSG lpMsg);
    /// <summary> Places (posts) a message in the message queue associated with the thread that created the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 PostMessageW(HWND hWnd, WndProcMsgType msg, WParam wParam, LParam lParam);

    /// <summary> Retrieves information about the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GetWindowLongPtrW")]
    public static partial void* GetWindowLongPtrW(HWND hWnd, WindowLongIndex nIndex);
    /// <summary> Changes an attribute of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "SetWindowLongPtrW")]
    public static partial void* SetWindowLongPtrW(HWND hWnd, WindowLongIndex nIndex, nint dwNewLong);

    #endregion

    #region Window size & position

    /// <summary> Sets the specified window's show state. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 ShowWindow(HWND hWnd, ShowWindowCommand nCmdShow);
    /// <summary> Determines the visibility state of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 IsWindowVisible(HWND hWnd);

    /// <summary> Changes the position and dimensions of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 MoveWindow(HWND hWnd, int X, int Y, int nWidth, int nHeight, Bool4 bRepaint);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 MoveWindow(HWND hWnd, Rect rect, Bool4 bRepaint)
        => MoveWindow(hWnd, rect.X, rect.Y, rect.Width, rect.Height, bRepaint);

    /// <summary> Changes the size, position, and Z order of a child, pop-up, or top-level window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 SetWindowPos(HWND hWnd, HWND hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 SetWindowPos(HWND hWnd, HWND hWndInsertAfter, Rect rect, SetWindowPosFlags uFlags)
        => SetWindowPos(hWnd, hWndInsertAfter, rect.X, rect.Y, rect.Width, rect.Height, uFlags);

    /// <summary> Retrieves the dimensions of the bounding rectangle of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 GetWindowRect(HWND hWnd, out Rect lpRect);
    /// <summary> Retrieves the coordinates of a window's client area. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 GetClientRect(HWND hWnd, out Rect lpRect);
    /// <summary> Calculates the required size of the window rectangle, based on the desired client-rectangle size. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 AdjustWindowRectEx(ref Rect lpRect, WindowStyles dwStyle, Bool4 bMenu, WindowExStyles dwExStyle);

    #endregion

    #region Non-Client area

    /// <summary> Changes the text of the specified window's title bar (if it has one). </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial void SetWindowTextW(HWND hWnd, char* lpText);
    /// <summary> Changes the window text using a managed string. </summary>
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void SetWindowTextW(HWND hWnd, string lpText);

    /// <summary> Copies the text of the specified window's title bar into a buffer. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetWindowTextW(HWND hWnd, char* lpString, int nMaxCount);
    /// <summary> Copies the window text into a managed char array. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetWindowTextW(HWND hWnd, [Out] char[] lpString, int nMaxCount);

    /// <summary> Retrieves the length, in characters, of the specified window's title bar text. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetWindowTextLengthW(HWND hWnd);

    #endregion

    #region Z-Order

    /// <summary> Sets the keyboard focus to the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND SetFocus(HWND hWnd);
    /// <summary> Retrieves the handle to the window that has the keyboard focus. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND GetFocus();

    /// <summary> Brings the thread that created the specified window into the foreground and activates the window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 SetForegroundWindow(HWND hWnd);
    /// <summary> Retrieves a handle to the foreground window (the window with which the user is currently working). </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND GetForegroundWindow();

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 EnumChildWindows(HWND hWndParent, delegate* unmanaged[Fastcall]<HWND, LParam, Bool4> lpEnumFunc, LParam lParam);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND FindWindowExW(HWND hWndParent, HWND hWndChildAfter, char* lpszClass, char* lpszWindow);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
    public static partial HWND FindWindowExW(HWND hWndParent, HWND hWndChildAfter, string? lpszClass, string? lpszWindow);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND GetWindow(HWND hWnd, GetWindowCommand uCmd);

    #endregion

    #region Parenting

    /// <summary> Retrieves a handle to the specified window's parent or owner. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND GetParent(HWND hWnd);
    /// <summary> Changes the parent window of the specified child window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HWND SetParent(HWND hWndChild, HWND hWndNewParent);

    #endregion

    #region Painting

    /// <summary> Adds a rectangle to the specified window's update region. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 InvalidateRect(HWND hWnd, in Rect lpRect, Bool4 bErase);
    /// <summary> Invalidates the entire client area of the specified window. </summary>
    public static Bool4 InvalidateRect(HWND hWnd, Bool4 bErase)
        => InvalidateRect(hWnd, in Unsafe.NullRef<Rect>(), bErase);
    /// <summary> Updates the client area of the specified window by sending a WM_PAINT message. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 UpdateWindow(HWND hWnd);

    /// <summary> Prepares the specified window for painting and fills a <see cref="PaintStruct"/> structure. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial GDI32.HDC BeginPaint(HWND hWnd, out PaintStruct lpPaint);
    /// <summary> Marks the end of painting in the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 EndPaint(HWND hWnd, in PaintStruct lpPaint);

    /// <summary> Fills a rectangle by using the specified brush. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int FillRect(GDI32.HDC hDC, in Rect lprc, GDI32.HBrush hbr);

    #endregion

    #region Input

    /// <summary> Posts messages when the mouse pointer leaves a window or hovers over a window for a specified amount of time. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 TrackMouseEvent(ref TrackMouseEvent lpEventTrack);

    #endregion

    #region Layered windows

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 SetLayeredWindowAttributes(HWND hwnd, GDI32.Color crKey, byte bAlpha, LayeredWindowFlags dwFlags);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 UpdateLayeredWindow(HWND hwnd,
        GDI32.HDC hdcDst, Point* ptDest, Size* size,
        GDI32.HDC hdcSrc, Point* ptSrc,
        GDI32.Color crKey, in MSimg32.BlendFunction pBlend, UpdateLayeredWindowFlags dwFlags);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 UpdateLayeredWindow(HWND hwnd,
        GDI32.HDC hdcDst, in Point ptDest, in Size size,
        GDI32.HDC hdcSrc, in Point ptSrc,
        GDI32.Color crKey, in MSimg32.BlendFunction pBlend, UpdateLayeredWindowFlags dwFlags);

    #endregion

    #region MessageBox

    [LibraryImport(DLL, SetLastError = true)]
    public static partial MessageBoxResult MessageBoxW(HWND hWnd, char* lpText, char* lpCaption, MessageBoxStyle uType);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
    public static partial MessageBoxResult MessageBoxW(HWND hWnd, string? lpText, string? lpCaption, MessageBoxStyle uType);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial MessageBoxResult MessageBoxIndirectW(in MsgBoxParamsW lpmbp);

    #endregion
}