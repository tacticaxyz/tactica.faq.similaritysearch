URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\web_tests\external\wpt\html\webappapis\scripting\processing-model-2\integration-with-the-javascript-job-queue\resources\README.md
A couple notes about the files scattered in this `resources/` directory:

* The nested directory structure is necessary here so that relative URL resolution can be tested; we need different sub-paths for each document.

* The semi-duplicate `window-to-open.html`s scattered throughout are present because Firefox, at least, does not fire `Window` `load` events for 404s, so we want to ensure that no matter which global is used, `window`'s `load` event is hit and our tests can proceed.
