URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\external\wpt\web-bundle\README.md
This directory contains tests for the
[Web Bundles](https://wicg.github.io/webpackage/draft-yasskin-wpack-bundled-exchanges.html).

`generate-test-wbns.sh` requires command-line tools in the
[webpackage repository](https://github.com/WICG/webpackage).
To install them, run:
```
go install github.com/WICG/webpackage/go/bundle/cmd/...@latest
export PATH=$PATH:$(go env GOPATH)/bin
```
