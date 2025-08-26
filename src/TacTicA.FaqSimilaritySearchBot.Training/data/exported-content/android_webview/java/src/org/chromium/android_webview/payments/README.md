URL:https://source.chromium.org/chromium/chromium/src/+/main:android_webview\java\src\org\chromium\android_webview\payments\README.md
# PaymentRequest API

## Reference

This directory provides WebView specific implementation for the PaymentRequest
API that is defined in https://w3c.github.io/payment-request/ with tutorials in
https://web.dev/explore/payments and implemented in `//components/payments`.
This implementation can only invoke Android apps through
`org.chromium.intent.action.PAY` intents.

## Review Policy

Although this directory is owned by the Payments team, please loop in the
[WebView OWNERS](https://chromium.googlesource.com/chromium/src/+/main/android_webview/OWNERS)
for changes that materially affect WebView's behaviour.
