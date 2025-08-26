URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\external\wpt\fetch\fetch-later\quota\cross-origin-iframe\README.md
# Quota Tests for Cross-Origin iframes

This folder contains tests to cover fetchLater() requests from cross-origin
iframe.

According to [spec], up to 16 cross-origin iframes can get a minimal quota (8kb)
to make fetchLater() calls.

[spec]: https://whatpr.org/fetch/1647.html#available-deferred-fetch-quota
