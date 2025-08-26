URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\corsDisabledScheme.md
# Ensure CORS requests are made on supported schemes

A cross-origin resource sharing (CORS) request was blocked because the scheme of the request's URL doesn't support CORS.

To fix this issue, ensure all CORS request URLs specify a supported scheme, e.g. most commonly https://.

Note that if an opaque response is sufficient, then for some schemes the request's mode can be set to `no-cors` to fetch the resource with CORS disabled; that way the scheme doesn't need to support CORS, but the response content is inaccessible (opaque).
