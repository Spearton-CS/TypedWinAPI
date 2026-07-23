# Naming and Casing rules

---

## Casing:
- ## C#-casing
	- ### PascalCase for Types, Functions, Properties, Fields
	- ### camelCase for parameters
	- ### UPPERCASE for abbreviations and some cases, where short-names those similar to abb. (HWND, ATOM) Because we're not in Java, no one types Hwnd

---

## Imports:
- ### 1-in-1 from Win32 (keep all suffixes and prefixes)
- ### C#-casing
- ### One Entry Point - One named method (and any count of overloads)

---

## Helpers:
- ### 1-in-1 from Native if "ported" from C/C++
- ### 1-in-1 from Import if "inlined-overload" (DeviceIoControl with "raw uint" -> DeviceIoControl with typed enums)
- ### C#-casing

---

## Types:
- ### C#-casing
- ### Keep suffixes (such as W) from Win32
- ### New enums (from unnamed constants for special methods) should be named using name of Function | Struct