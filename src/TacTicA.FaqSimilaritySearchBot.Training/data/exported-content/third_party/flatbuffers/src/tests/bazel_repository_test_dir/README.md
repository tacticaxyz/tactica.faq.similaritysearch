URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\flatbuffers\src\tests\bazel_repository_test_dir\README.md
This directory is not intended to be used independently of the flatbuffers
repository. Instead, this whole directory serves as a unit test for the
C++ integration in the flatbuffers repo.

Run this test from the top-level of the flatbuffers repo.
```console
$ bazel test //tests:bazel_repository_test
```
