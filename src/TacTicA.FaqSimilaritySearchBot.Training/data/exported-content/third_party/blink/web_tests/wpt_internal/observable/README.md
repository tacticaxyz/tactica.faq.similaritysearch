URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\wpt_internal\observable\README.md
# Observable API internal tests

This is the `wpt_internal` directory for DOM Observable tests. Tests in here
cannot be upstreamed to https://github.com/web-platform-tests/wpt/ because they
rely on various Chrome internals like the `internals` API, or v8-specific
test-only internals like the `gc()` global.
