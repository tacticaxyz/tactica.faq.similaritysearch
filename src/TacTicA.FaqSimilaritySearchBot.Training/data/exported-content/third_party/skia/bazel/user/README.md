URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\skia\bazel\user\README.md
If you wish to define custom Bazel configurations (e.g. custom builds), make a text file in this
folder called buildrc. It should follow the
[.bazelrc conventions](https://bazel.build/docs/bazelrc#config).

Users are free to put their custom builds in the $HOME/.bazelrc file as per usual, but if they
wish to avoid conflicts with other Bazel projects, this is a safer place to store them.