URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\virtual\main-thread-clip-path-animation\README.md
This test suite contains ALL tests that have compositable clip path animations,
even incidentally. This suite ensures that *main thread* clip path animations
do not lose coverage even if composited clip path animations are enabled by
default.