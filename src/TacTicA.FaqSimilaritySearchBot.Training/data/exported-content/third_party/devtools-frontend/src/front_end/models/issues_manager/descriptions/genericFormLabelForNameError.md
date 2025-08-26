URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\genericFormLabelForNameError.md
# Incorrect use of <label for=FORM_ELEMENT>

The label's `for` attribute refers to a form field by its `name`, not its `id`. This might prevent the browser from correctly autofilling the form and accessibility tools from working correctly.

To fix this issue, refer to form fields by their `id` attribute.
