URL:https://source.chromium.org/chromium/chromium/src/+/main:android_webview\browser\README.md
# //android\_webview/browser/

This folder holds WebView's browser-specific native code.

## Folder dependencies

Like with other content embedders, `//android_webview/browser/` can depend on
`//android_webview/common/` but not `//android_webview/renderer/`. It can also
depend on content layer (and lower layers) as other embedders would (ex. can
depend on `//content/public/browser/`, `//content/public/common/`).
