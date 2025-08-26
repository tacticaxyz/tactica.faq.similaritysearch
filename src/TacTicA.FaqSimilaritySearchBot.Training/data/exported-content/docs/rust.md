URL:https://source.chromium.org/chromium/chromium/src/+/main:docs\rust.md
# Rust in Chromium

[TOC]

# Why?

Handling untrustworthy data in non-trivial ways is a major source of security
bugs, and it's therefore against Chromium's security policies
[to do it in the Browser or Gpu process](../docs/security/rule-of-2.md) unless
you are working in a memory-safe language.

Rust provides a cross-platform, memory-safe language so that all platforms can
handle untrustworthy data directly from a privileged process, without the
performance overhead and complexity of a utility process.

# Status

The Rust toolchain is enabled for and supports all platforms and development
environments that are supported by the Chromium project. The first milestone
to include full production-ready support was M119.

Rust can be used anywhere in the Chromium repository (not just `//third_party`)
subject to [current interop capabilities][interop-rust-doc], however it is
currently subject to a internal approval and FYI process. Googlers can view
go/chrome-rust for details. New usages of Rust are documented at
[`rust-fyi@chromium.org`](https://groups.google.com/a/chromium.org/g/rust-fyi).

For questions or help, reach out to
[`rust-dev@chromium.org`](https://groups.google.com/a/chromium.org/g/rust-dev),
or [`#rust` channel](https://chromium.slack.com/archives/C01T3EWCJ9Z)
on the [Chromium Slack](https://www.chromium.org/developers/slack/),
or (Google-internal, sorry)
[Chrome Rust chatroom](https://chat.google.com/room/AAAAk1UCFGg?cls=7).

If you use VSCode, we have [additional advice below](#using-vscode).

# First-party Rust libraries

First-party Rust libraries should use the
[`rust_static_library`](
https://source.chromium.org/chromium/chromium/src/+/main:build/rust/rust_static_library.gni)
GN template (not the built-in `rust_library`) to integrate properly into the
mixed-language Chromium build and get the correct compiler options applied to
them.

Rust libraries that depend on other first-party Rust libraries
should import APIs using `chromium::import!` from
[the Chromium prelude library](../build/rust/chromium_prelude/)
rather than
[`use some_crate_name::foo`](https://doc.rust-lang.org/reference/items/use-declarations.html).
This avoids concerns about non-globally-unique crate names.
This guidance doesn't apply when depending on Rust standard library
nor when depending on crates from `//third_party/rust`.

See
[`//docs/rust-ffi.md`](rust-ffi.md)
for how to interop with Rust code from C/C++.

Mapping of Chromium APIs to Rust:

* `gtest` integration is provided by
[`//testing/rust_gtest_interop`](../testing/rust_gtest_interop/README.md)
library.
* [log](https://docs.rs/log) crate has been integrated into `//base` and can be
  used in place of `LOG(...)` from C++ side.
    - TODO(https://crbug.com/374023535): Logging may not yet work in component builds
    - Note that the standard library also includes a helpful
      [`dbg!`](https://doc.rust-lang.org/std/macro.dbg.html) macro which writes
      everything about a variable to `stderr`.

# Third-party Rust libraries

## crates.io

See
[`//third_party/rust/README-importing-new-crates.md`](../third_party/rust/README-importing-new-crates.md)
for instructions on how to import a crate from https://crates.io into Chromium.

The crates will get updated semi-automatically through the process described in
[`../tools/crates/create_update_cl.md`](../tools/crates/create_update_cl.md).

These libraries use the
[`cargo_crate`](
https://source.chromium.org/chromium/chromium/src/+/main:build/rust/cargo_crate.gni)
GN template.

## Other libraries

Third-party Rust libraries that are not distributed through [crates.io](
https://crates.io) should live outside of `//third_party/rust`.
Such libraries will typically depend on `//third_party/rust` crates
and use `//build/rust/*.gni` templates, but there is no other Chromium
tooling to import such libraries or keep them updated.
For examples, see `//third_party/crabbyavif` or
`//third_party/cloud_authenticator`.

# Unstable features

Unstable features are **unsupported** by default in Chromium. Any use of an
unstable language or library feature should be agreed upon by the Rust toolchain
team before enabling it.  See
[`tools/rust/unstable_rust_feature_usage.md`](../tools/rust/unstable_rust_feature_usage.md)
for more details.

# Using VSCode

1. Ensure you're using the `rust-analyzer` extension for VSCode, rather than
   earlier forms of Rust support.
2. Run `gn` with the `--export-rust-project` flag, such as:
   `gn gen out/Release --export-rust-project`.
3. `ln -s out/Release/rust-project.json rust-project.json`
4. When you run VSCode, or any other IDE that uses
   [rust-analyzer](https://rust-analyzer.github.io/) it should detect the
   `rust-project.json` and use this to give you rich browsing, autocompletion,
   type annotations etc. for all the Rust within the Chromium codebase.
5. Point rust-analyzer to the rust toolchain in Chromium. Otherwise you will
   need to install Rustc in your system, and Chromium uses the nightly
   compiler, so you would need that to match. Add the following to
   `.vscode/settings.json` in the Chromium checkout:
   ```
   {
      // The rest of the settings...

      "rust-analyzer.cargo.extraEnv": {
        "PATH": "../../third_party/rust-toolchain/bin:$PATH",
      }
   }
   ```
   This assumes you are working with an output directory like `out/Debug` which
   has two levels; adjust the number of `..` in the path according to your own
   setup.

# Using cargo

If you are building a throwaway or experimental tool, you might like to use pure
`cargo` tooling rather than `gn` and `ninja`. Even then, you may choose
to restrict yourself to the toolchain and crates that are already approved for
use in Chromium, by

* Using `tools/crates/run_cargo.py` (which will use
  Chromium's `//third_party/rust-toolchain/bin/cargo`)
* Configuring `.cargo/config.toml` to ask to use the crates vendored
  into Chromium's `//third_party/rust/chromium_crates_io`.

An example of how this can work can be found in
https://crrev.com/c/6320795/5.

[interop-rust-doc]: https://docs.google.com/document/d/1kvgaVMB_isELyDQ4nbMJYWrqrmL3UZI4tDxnyxy9RTE/edit?tab=t.0#heading=h.fpqr6hf3c3j0
