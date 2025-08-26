URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\tensorflow\lite\schema\builtin_ops_list\README.md
# Builtin Ops List Generator.

This directory contains a code generator to generate a pure C header for
builtin ops lists.

Whenever you add a new builtin op, please execute:

```sh
bazel run \
  //tensorflow/lite/schema/builtin_ops_header:generate > \
  tensorflow/lite/builtin_ops.h &&
bazel run \
  //tensorflow/lite/schema/builtin_ops_list:generate > \
  tensorflow/lite/kernels/builtin_ops_list.inc
```
