URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\virtual\blur-on-remove\README.md
This directory contains tests with --disable-features=OmitBlurEventOnElementRemoval.
It maintains tests for the existing behavior of firing the blur event for an
element when it's being removed from the DOM, with the intention to remove or
update the expectations for these tests when the behavior change becomes stable.
