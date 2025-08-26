URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\protobuf\.bazelci\README.md
# Bazel CI test

The `.bazelci/presubmit.yml` file is used by https://buildkite.com/bazel/protobuf
to test building protobuf with Bazel on Bazel CI. It should contain the same
set of tests as `.bcr/presubmit.yml` which is the tests that will run before
publishing protobuf to BCR.
