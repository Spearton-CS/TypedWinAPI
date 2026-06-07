# Windows API with strong-typing and 100% fixed layout *where it possible*.

- ### Targetting .NET 10+, NativeAOT with trimming, X64|ARM64 and Windows 10|11.
- ### ***X86|ARM32 are 100% unsupported, everything before Windows 10 - untested and in theory a most of functions - supported, but without guarantees. ARM64 WASN'T EVER TESTED***

- ### *Bc it's a just background repo, it's still very small by percentage of implemented Windows API and CAN contain some bugs or mistyping in some places*

## Projects structure:

| Namespace | Directory in repo | Comment |
| :--- | :--- | :--- |
| | | |
| **TypedWinAPI** | `/TypedWinAPI/Enums/` | Reserved for abstract enums for whole library |
| **TypedWinAPI** | `/TypedWinAPI/Handles/` | Base abstractions over handles. `Handle` and `Handle16` + `.tt` templates |
| **TypedWinAPI** | `/TypedWinAPI/Structs/Large/` | Reserved for abstract structs for whole library, those are more than 32 bytes |
| **TypedWinAPI** | `/TypedWinAPI/Structs/Primitives/` | Base abstractions over Win32 typedefs. `Bool1` (8bit), `Bool4` (32bit), `HResult` |
| **TypedWinAPI** | `/TypedWinAPI/Structs/Small/` | Reserved for abstract structs for whole library, those are less or equal to 32 bytes. |
| | | |
| **TypedWinAPI.Contracts** | `/TypedWinAPI/Contracts/` | Zero-cost-abstractions for generics and just clean-code. Handle contracts and etc. |
| | | |
| **TypedWinAPI.XXX** | `/TypedWinAPI/_Modules/XXX/` | "Module" of WinAPI, it's just a some single `.dll` (such as `kernel32.dll` or `user32.dll`) |
| **TypedWinAPI.XXX** | `/TypedWinAPI/_Modules/XXX/_Imports/` | Static classes with imports of WinAPI, if possible - have many, if not - just XXX static class with all imports |
| **TypedWinAPI.XXX** | `/TypedWinAPI/_Modules/XXX/Enums/` | Enums from WinAPI, sometimes replace raw numbers or "magic constant" and "struct-over-integer" |
| **TypedWinAPI.XXX** | `/TypedWinAPI/_Modules/XXX/Handles/` | Handles derived from `/TypedWinAPI/Handles/` abstractions, only created by .tt template |
| **TypedWinAPI.XXX** | `/TypedWinAPI/_Modules/XXX/Structs/Large/` | Structs more than 32 bytes |
| **TypedWinAPI.XXX** | `/TypedWinAPI/_Modules/XXX/Structs/Primitives/` | Structs less or equal to 8 bytes, but not every small struct that less or equal to 8 bytes are primitive |
| **TypedWinAPI.XXX** | `/TypedWinAPI/_Modules/XXX/Structs/Small/` | Structs less or equal to 32 bytes |