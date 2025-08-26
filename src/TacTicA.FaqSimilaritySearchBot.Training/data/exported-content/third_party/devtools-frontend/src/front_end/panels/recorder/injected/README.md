URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\panels\recorder\injected\README.md
# Recording Client

This folder contains the recorder client code that gets injected into target pages.
The code consists of a single file where the code is defined within a single closure
so that it's serializable.

In the future, we might want to split into submodules and find a way to bundle everything
into something serializable.
