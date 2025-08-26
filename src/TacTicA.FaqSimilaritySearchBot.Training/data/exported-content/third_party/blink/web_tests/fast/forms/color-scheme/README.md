URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\fast\forms\color-scheme\README.md
This directory holds tests that need to be validated across different color schemes (ex. forced colors mode).

If you are adding a test to this directory, make sure your test actually needs to be validated across multiple color schemes, and that there isn't already a color scheme validation test that covers your scenario. If your test does not need color scheme validation, add it outside of this directory.