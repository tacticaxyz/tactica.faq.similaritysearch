URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\genericFormAriaLabelledByToNonExistingId.md
# An aria-labelledby attribute doesn't match any element id

An `aria-labelledby` attribute doesn't match any element `id`. This might prevent
the browser from correctly autofilling the form and accessibility tools from
working correctly.

To fix this issue, make sure that `aria-labelledby` is a space-separated list of
element `id`s.
