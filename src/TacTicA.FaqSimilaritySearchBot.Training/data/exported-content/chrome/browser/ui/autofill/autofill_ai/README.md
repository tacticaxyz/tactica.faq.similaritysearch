URL:https://source.chromium.org/chromium/chromium/src/+/main:chrome\browser\ui\autofill\autofill_ai\README.md
This directory contains files that use Autofill UI infrastructure but are
related to Autofill AI.

They are in an Autofill subdirectory (as opposed to, e.g.,
`//chrome/browser/ui/autofill_ai`) because of their
dependencies:
- They depend on Autofill UI code by extending from `AutofillBubbleBase` and
  `AutofillBubbleControllerBase`.
- Autofill UI code depends on them because the view is instantiated
  via `AutofillBubbleHandler`.
