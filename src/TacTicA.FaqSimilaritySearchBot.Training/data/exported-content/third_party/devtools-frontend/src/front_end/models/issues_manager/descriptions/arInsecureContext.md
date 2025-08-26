URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\arInsecureContext.md
# Ensure that the attribution registration context is secure

This page tried to register a source or trigger using the Attribution Reporting
API but failed because the page that initiated the registration was not secure.

The registration context must use HTTPS unless it is `localhost` or
`127.0.0.1`.
