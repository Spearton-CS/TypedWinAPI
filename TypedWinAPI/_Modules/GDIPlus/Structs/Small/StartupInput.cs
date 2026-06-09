    using System.Runtime.InteropServices;

    namespace TypedWinAPI.GDIPlus;

    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public unsafe struct StartupInput
    {
        [FieldOffset(0)] public uint GdiplusVersion;
        [FieldOffset(4)] public delegate* unmanaged<DebugEventLevel, nint, void> DebugEventCallback;
        [FieldOffset(12)] public Bool4 SuppressBackgroundThread;
        [FieldOffset(16)] public Bool4 SuppressExternalCodecs;

        public static readonly StartupInput Default = new()
        {
            GdiplusVersion = 1,
            SuppressBackgroundThread = false,
            SuppressExternalCodecs = false,
            DebugEventCallback = null
        };
    }