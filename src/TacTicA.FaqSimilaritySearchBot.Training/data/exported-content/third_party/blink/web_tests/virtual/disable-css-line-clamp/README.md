URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\virtual\disable-css-line-clamp\README.md
Tests with the CSSLineClamp blink feature disabled.

Since this feature changes the behavior of -webkit-line-clamp to hide clamped
lines from paint, and it is not yet enabled by default, this virtual test suite
makes sure that the behavior without it does not change.
