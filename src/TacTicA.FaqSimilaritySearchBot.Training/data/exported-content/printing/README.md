URL:https://source.chromium.org/chromium/chromium/src/+/main:printing\README.md
`//printing` contains foundational code that is used for printing. It can depend
on other low-level directories like `//cc/paint` and `//ui`, but not higher
level code like `//components` or `//content`. Higher level printing code should
live in `//components/printing` or the embedder.
