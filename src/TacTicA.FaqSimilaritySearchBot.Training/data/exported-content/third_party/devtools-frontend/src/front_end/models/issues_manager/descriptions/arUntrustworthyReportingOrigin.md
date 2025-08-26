URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\arUntrustworthyReportingOrigin.md
# Ensure that attribution reporting origins are trustworthy

This page tried to register a source or trigger using the Attribution Reporting
API but failed because the reporting origin was not potentially trustworthy.

The reporting origin is typically the server that sets the
`Attribution-Reporting-Register-Source` or
`Attribution-Reporting-Register-Trigger` header.

The reporting origin must use HTTPS unless it is `localhost` or `127.0.0.1`.
