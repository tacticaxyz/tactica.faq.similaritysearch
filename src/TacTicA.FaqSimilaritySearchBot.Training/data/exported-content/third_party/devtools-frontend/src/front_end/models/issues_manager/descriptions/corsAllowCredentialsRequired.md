URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\corsAllowCredentialsRequired.md
# Ensure CORS requests include credentials only when allowed

A cross-origin resource sharing (CORS) request was blocked because it was configured to include credentials but the `Access-Control-Allow-Credentials` response header of the request or the associated preflight request was not set to `true`.

To fix this issue, ensure that resources that expect credentialed CORS requests set the `Access-Control-Allow-Credentials` header to `true`.
Note that this requires the `Access-Control-Allow-Origin` header to not be a wildcard `*`.
