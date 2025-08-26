URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\http\tests\streams\README.md
# Streams Tests in Blink

Tests for ReadableStream and WritableStream can be found at
LayoutTests/external/wpt/streams. Only things specific to Blink are in this
directory.

* chromium/ - Tests for functionality specific to Blink.
* resources/ - Contains rs-utils.js, which is used by stream-related tests in
  ../fetch.
* transferables/ - Contains tests for transferable streams. These will be
  upstreamed to wpt once they are standardised.
