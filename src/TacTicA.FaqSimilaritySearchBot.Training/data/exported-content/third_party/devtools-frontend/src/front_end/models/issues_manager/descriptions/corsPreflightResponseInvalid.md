URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\corsPreflightResponseInvalid.md
# Ensure preflight responses are valid

A cross-origin resource sharing (CORS) request was blocked because the response to the associated [preflight request](issueCorsPreflightRequest) failed, had an unsuccessful HTTP status code, and/or was a redirect.

To fix this issue, ensure all CORS preflight `OPTIONS` requests are answered with a successful HTTP status code (2xx) and do not redirect.
