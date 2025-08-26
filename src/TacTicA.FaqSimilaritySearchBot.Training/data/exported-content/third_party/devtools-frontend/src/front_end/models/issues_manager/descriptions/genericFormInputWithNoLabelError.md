URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\genericFormInputWithNoLabelError.md
# Form field without valid aria-labelledby attribute or associated label

A form field has neither a valid `aria-labelledby` attribute nor an associated `<label>`. This might prevent the browser from correctly autofilling the form and accessibility tools from working correctly.

To fix this issue, provide a `<label>` describing the purpose of the form field.
