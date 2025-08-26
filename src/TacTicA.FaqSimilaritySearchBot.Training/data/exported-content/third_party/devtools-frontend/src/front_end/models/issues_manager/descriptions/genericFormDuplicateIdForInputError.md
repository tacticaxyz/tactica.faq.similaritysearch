URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\genericFormDuplicateIdForInputError.md
# Duplicate form field id in the same form

Multiple form field elements in the same form have the same `id` attribute value. This might prevent the browser from correctly autofilling the form.

To fix this issue, use unique `id` attribute values for each form field.
