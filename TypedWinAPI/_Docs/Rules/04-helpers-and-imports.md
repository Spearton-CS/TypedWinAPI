# Imports and Helpers rules

---

## Import signature:
- ### Only `LibraryImport` attribute, `DllImport` isn't option
- ### `SetLastError = true` only if Win32 explicitly state `GetLastError` | `SetLastError` support
- ### No-marshalling types only (blittable), BUT special-cases as optional overloads:
	- ### `string` instead of `char*` | `byte*` in some cases, when `#if ManagedStrings`
	- ### `SafeHandle`s instead of `Handle`s, when `#if ManagedObjects`
- ### Only public imports, no "magic private import without typing"

---

## Helpers:
- ### `MethodImpl(MethodImplOptions.AggressiveInlining)` MUST be on any helper, if helper can't be inlined - it's not helper, it's "heavy-weight logic", that should be in optional `assembly`
- ### If possible - helper must be "zero-cost" at runtime (e.g., take args, provide them into Import, but cast some `enum`s into other types)

---

## Overloading:
- ### If possible - overload must be inline-helper (e.g., cast `enum` to raw type)
- ### If not - LibraryImport (e.g., different arg count, `T*` vs `ref/in/out T`)

---

## Import points:
- ### Only TypedWinAPI.*Module*.*Module* `public static unsafe partial class`.