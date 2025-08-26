URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\genericFormLabelHasNeitherForNorNestedInput.md
# No label associated with a form field

A `<label>` isn't associated with a form field.

To fix this issue, nest the `<input>` in the `<label>` or provide a `for` attribute on the `<label>` that matches a form field `id`.
