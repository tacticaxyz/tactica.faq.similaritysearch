URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\perfetto\test\sanitizers\README.md
LLVM sanitizers smoke tests
---------------------------
The only purpose of this binary is to verify that the various build configs for
sanitizers (`is_asan`, `is_lsan`, `is_msan`, `is_tsan`, `is_ubsan`) do actually
work and spot violations, rather than unconditionally succeeding if we mess up
the build config.
