URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\rust-toolchain\lib\rustlib\src\rust\library\core\src\ffi\c_ulonglong.md
Equivalent to C's `unsigned long long` type.

This type will almost always be [`u64`], but may differ on some systems. The C standard technically only requires that this type be an unsigned integer with the size of a [`long long`], although in practice, no system would have a `long long` that is not a `u64`, as most systems do not have a standardised [`u128`] type.

[`long long`]: c_longlong
