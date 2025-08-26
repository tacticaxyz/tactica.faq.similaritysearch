URL:https://source.chromium.org/chromium/chromium/src/+/main:ios\web_view\README.md
Contains code to build an Objective-C framework which renders web content with
`[CWVWebView]`. See the exposed API in `//ios/web_view/public/*` for more
details.

NOTE: This code is not used by Chrome for iOS (`//ios/chrome`), but is rather
a separate product/embedder of the `//ios/web` rendering layer.

[CWVWebView]: public/cwv_web_view.h