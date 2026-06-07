namespace TypedWinAPI.Kernel32;

[Flags]
public enum VolumeDirtyFlags : uint
{
    None = 0,
    /// <summary>The volume is dirty and requires a Chkdsk.</summary>
    IsDirty = 0x01,
    /// <summary>An upgrade is scheduled for this volume.</summary>
    UpgradeScheduled = 0x02
}