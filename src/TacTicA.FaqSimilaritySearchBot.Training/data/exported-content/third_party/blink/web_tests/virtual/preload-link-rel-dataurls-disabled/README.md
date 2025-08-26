URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\virtual\preload-link-rel-dataurls-disabled\README.md
# virtual/preload-link-rel-dataurls-disabled

This directory is for tests that need the PreloadLinkRelDataUrls feature flag
disabled to match the experimental behavior where we do not support preloading
data URLs.
Tests under `virtual/preload-link-rel-dataurls-disabled` are run with
`--disable-features=PreloadLinkRelDataUrls`.
