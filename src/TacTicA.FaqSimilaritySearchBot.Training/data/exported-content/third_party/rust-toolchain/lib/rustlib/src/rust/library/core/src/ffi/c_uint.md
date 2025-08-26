URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\rust-toolchain\lib\rustlib\src\rust\library\core\src\ffi\c_uint.md
Equivalent to C's `unsigned int` type.

This type will almost always be [`u32`], but may differ on some esoteric systems. The C standard technically only requires that this type be an unsigned integer with the same size as an [`int`]; some systems define it as a [`u16`], for example.

[`int`]: c_int
