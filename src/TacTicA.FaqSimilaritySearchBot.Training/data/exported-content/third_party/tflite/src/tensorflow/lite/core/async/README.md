URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\tensorflow\lite\core\async\README.md
# TfLite asynchronous execution

WARNING: This feature is experimental and subject to change.

Experimental support for TFLite asynchronous execution and interoperability.

## Directory structure

| Directory          | Description                                         |
| ------------------ | --------------------------------------------------- |
| `/async`           | Asynchronous execution APIs. Definition for async kernel.  |
| `/async/interop`   | Data structures supporting buffer and sync object interop. Reconciliation functions for buffer / sync attributes. |
| `/async/interop/c` | C APIs for buffer and sync object interop.          |
