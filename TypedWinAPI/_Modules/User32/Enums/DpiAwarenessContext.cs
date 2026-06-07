namespace TypedWinAPI.User32;

public enum DpiAwarenessContext : long
{
    Unaware = -1,
    SystemAware = -2,
    PerMonitorAware = -3,
    PerMonitorAwareV2 = -4,
    UnawareGdiScaled = -5
}