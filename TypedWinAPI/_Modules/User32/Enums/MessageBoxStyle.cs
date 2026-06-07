namespace TypedWinAPI.User32;

[Flags]
public enum MessageBoxStyle : uint
{
    // Buttons
    Ok = 0x00000000,
    OkCancel = 0x00000001,
    AbortRetryIgnore = 0x00000002,
    YesNoCancel = 0x00000003,
    YesNo = 0x00000004,
    RetryCancel = 0x00000005,
    CancelTryContinue = 0x00000006,

    // Icons
    IconHand = 0x00000010,
    IconQuestion = 0x00000020,
    IconExclamation = 0x00000030,
    IconAsterisk = 0x00000040,
    IconError = IconHand,
    IconStop = IconHand,
    IconWarning = IconExclamation,
    IconInformation = IconAsterisk,

    // Default Button
    DefButton1 = 0x00000000,
    DefButton2 = 0x000000100,
    DefButton3 = 0x000000200,
    DefButton4 = 0x000000300,

    // Modality
    AppModal = 0x00000000,
    SystemModal = 0x00001000,
    TaskModal = 0x00002000
}