URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\rust\chromium_crates_io\vendor\simd-adler32-v0_3\CHANGELOG.md
# Changelog

## 0.3.3 - 2021-04-14

### Features

- **from_checksum**: add `Adler32::from_checksum`

### Performance Improvements

- **scalar**: improve scalar performance by 90-600%
  - Defer modulo until right before u16 overflow
