URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\cookieExcludePortMismatch.md
# Cookie was not sent due to port mismatch

Cookies can only be accessed by origins that share the same port as the origin
that initially set the cookie.

If this cookie is required for the request, the cookie will need to be set by an
origin with the same port as the request. Alternatively, you can utilize the
Domain attribute, which allows access to a cookie with a mismatched port.
