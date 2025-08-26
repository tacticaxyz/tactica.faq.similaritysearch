URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\rust\chromium_crates_io\vendor\bitflags-v2\CONTRIBUTING.md
# Updating compile-fail test outputs

`bitflags` uses the `trybuild` crate to integration test its macros. Since Rust error messages change frequently enough that `nightly` builds produce spurious failures, we only check the compiler output in `beta` builds. If you run:

```
TRYBUILD=overwrite cargo +beta test --all
```

it will run the tests and update the `trybuild` output files.
