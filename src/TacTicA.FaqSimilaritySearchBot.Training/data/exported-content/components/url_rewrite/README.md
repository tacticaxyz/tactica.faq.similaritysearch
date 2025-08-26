URL:https://source.chromium.org/chromium/chromium/src/+/main:components\url_rewrite\README.md
The URL Rewrite component provides utilities that allow adjusting URLRequest
based on the provided URL rewrite rules defined in UrlRequestRewrite mojom.

The UrlRequestRulesReceiver mojom interface is used by browser process to set
renderer process rewrite rules.

The URLLoaderThrottle implementation applies the rewrite rules to the
URLRequest.
