# Prefix and Type mapping rules.

---

## Prefix map

### Prefix must be replaced to Name suffix if no other "mark" in name to type.
- ### E.g., cchFilename -> FileNameChars, cchNameLength -> NameLength

---

| Prefix | TypedWinAPI Type | Name suffix | Comment |
| :---: | :---: | :---: | :---: |
| cb | uint | Bytes | --- |
| cch | uint | Chars | --- |
| cw | uint | Words | --- |
| c | uint | Count | --- |
| ch | char | Char | --- |
| by | byte | --- | --- |
| w | ushort | --- | --- |
| dw | uint | --- | --- |
| qw | ulong | --- | --- |
| i | int | Index | --- |
| n | int / uint | Number | --- |
| h | Handle / H... | Handle | --- |
| p / lp | pointer / ref / in / out | --- | --- |
| f / b | Bool1 | Flag | --- |
| rc | Gdi32.Rect | Rect / Bounds | --- |
| pt | Gdi32.Point | Point / Pos | --- |
| sz | byte* | --- | null-terminated ANSI-string |
| wsz / lpwsz | char* | --- | null-terminated UTF16-string |
| psz / lpsz | char* / byte* | --- | null-terminated string |
| pfn / lpfn / fn | delegate* unmanaged | Callback / Proc | --- |
| clr | uint / Gdi32.ColorRef | Color | --- |
| hr | HResult | Result / Status | --- |
| id | uint | Id | --- |

---

## Type map

### In this map only "primitives", so I'll not continue it using "GDI32 handles" and other 1-in-1 named types.
### Every nint|nuint if possible should be a long|ulong, because TypedWinAPI is 64-bit only targeting.

---

| Win32 | TypedWinAPI | Comment |
| :---: | :---: | :---: |
| BYTE | byte | --- |
| WORD | ushort | --- |
| DWORD | uint | --- |
| QWORD | ulong | --- |
| SHORT | short | --- |
| USHORT | ushort | --- |
| LONG / INT | int | --- |
| ULONG / UINT | uint | --- |
| LONGLONG | long | --- |
| ULONGLONG | ulong | --- |
| FLOAT | float | --- |
| DOUBLE | double | --- |
| ULONG_PTR / DWORD_PTR | ulong | --- |
| LONG_PTR / INT_PTR | long | --- |
| SIZE_T | ulong | Bytes / Size |
| SSIZE_T | long | Bytes / Size |
| BOOL | Bool4 | --- |
| BOOLEAN | Bool1 | --- |
| Handle / H... | Handle / H... | --- |
| LPSTR / LPCSTR | byte* (null-terminated) | --- |
| LPWSTR / LPCWSTR | char* (null-terminated) | --- |
| VOID* / LPVOID / PVOID | void* / long | --- |

---