URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\corsRedirectContainsCredentials.md
# Ensure CORS requests are not redirected to URLs containing credentials

A cross-origin resource sharing (CORS) request was blocked because the response was a redirect to a URL that includes credentials, i.e. redirected to a URL of the form `https://username:password@example.com`.

To fix this issue, ensure CORS requests are not redirected to URLs that include credentials.
