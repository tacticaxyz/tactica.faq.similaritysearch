URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\rust-toolchain\lib\rustlib\src\rust\library\portable-simd\crates\core_simd\examples\README.md
### `stdsimd` examples

This crate is a port of example uses of `stdsimd`, mostly taken from the `packed_simd` crate.

The examples contain, as in the case of `dot_product.rs`, multiple ways of solving the problem, in order to show idiomatic uses of SIMD and iteration of performance designs.

Run the tests with the command 

```
cargo run --example dot_product
```

and verify the code for `dot_product.rs` on your machine.
