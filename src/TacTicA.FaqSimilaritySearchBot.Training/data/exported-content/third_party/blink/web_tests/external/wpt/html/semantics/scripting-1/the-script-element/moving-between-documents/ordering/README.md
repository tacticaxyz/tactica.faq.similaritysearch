URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\external\wpt\html\semantics\scripting-1\the-script-element\moving-between-documents\ordering\README.md
The tests in this directory checks side effects (other than script
evaluation/event firing, which is covered by the tests in the parent directory)
caused by scripts moved between Documents.

The tests assume that script loading is not canceled when moved between
documents (which is not explicitly specified as of Jan 2022).
