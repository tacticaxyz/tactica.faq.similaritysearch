URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\virtual\input-closes-select\README.md
This suite enables InputClosesSelect flag, which re-adds legacy behavior to the
HTML parser which turns `<select><input>` into `<select></select><input>` to
de-risk the launch of SelectParserRelaxation.

--enable-features=SelectParserRelaxation,InputClosesSelect
