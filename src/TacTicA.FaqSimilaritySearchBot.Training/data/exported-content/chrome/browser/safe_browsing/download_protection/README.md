URL:https://source.chromium.org/chromium/chromium/src/+/main:chrome\browser\safe_browsing\download_protection\README.md
This directory includes code that scans downloaded content for security reasons.
This includes:
  * Safe Browsing metadata checks.
  * Chrome Advanced Protection Program file download scans.
  * Chrome Enterprise Connectors file download scans.

Code shared with user uploads cloud scanning should be added to
`//chrome/browser/safe_browsing/cloud_content_scanning/` instead.

Code specific to user uploads cloud scanning or Chrome Enterprise Connectors
should be added to `//chrome/browser/enterprise/connectors/` instead.
