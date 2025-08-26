URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\http\tests\origin_trials\webexposed\README.md
This directory is for testing the interfaces that are exposed to the
web for features enabled via origin trial.

Since experimental features are enabled by default when running layout
tests, the tests here will likely pass without an origin trial token.
A virtual test suite (origin-trials-runtimeflags-disabled) covers
this. Depending on the test, it may be necessary to add specific
results in the directory:

web_tests/virtual/origin-trials-runtimeflags-disabled/http/tests/origin_trials/webexposed/
