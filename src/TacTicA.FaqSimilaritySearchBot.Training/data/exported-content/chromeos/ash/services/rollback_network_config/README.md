URL:https://source.chromium.org/chromium/chromium/src/+/main:chromeos\ash\services\rollback_network_config\README.md
# Rollback Network Config

This service provides support for Chrome OS Enterprise Rollback. It handles
importing and exporting network configurations to be preserved during a rollback.

The implementation of this service lives in
chrome/browser/ash/net/rollback_network_config because it has Chrome
dependencies.