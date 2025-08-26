URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\arWebAndOsHeaders.md
# Ensure that attribution responses contain either web or OS headers, not both

This page included web and OS Attribution Reporting API headers in the same
HTTP response, which is prohibited.

The response may set at most one of the following headers:

- `Attribution-Reporting-Register-OS-Source`
- `Attribution-Reporting-Register-OS-Trigger`
- `Attribution-Reporting-Register-Source`
- `Attribution-Reporting-Register-Trigger`
