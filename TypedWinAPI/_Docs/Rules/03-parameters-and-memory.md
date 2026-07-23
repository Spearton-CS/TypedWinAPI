# Parameter and Memory rules.

---

# Ref-parameters map

- ## Can be null -> T*
- ## Can't be null, mutable, init by caller -> ref T
- ## Can't be null, mutable, init by callee -> out T
- ## Can't be null, immutable, init by caller -> in T