URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\virtual\customizable-select-in-page-disabled\README.md
This is a virtual test suite which enables the CustomizableSelect flag but
disables the follow-up work for customizable select in the
CustomizableSelectInPage flag. This represents behavior that we are currently
shipping in stable.

Flags: --disable-features=CustomizableSelectInPage --enable-features=CustomizableSelect
Bug: crbug.com/1511354
