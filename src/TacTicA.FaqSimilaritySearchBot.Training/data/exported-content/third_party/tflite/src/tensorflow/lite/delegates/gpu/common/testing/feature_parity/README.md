URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\tensorflow\lite\delegates\gpu\common\testing\feature_parity\README.md
### TFLite Delegate Feature Parity Testing

These tests ensure feature parity across TFLite GPU delegates. Every test
receives a simple automatically generated tflite model as an input. Model runs
with default tflite cpu interpreter and an delegated interpreter. Test succeeds
when output results for both interpretes match with the given accuracy.

