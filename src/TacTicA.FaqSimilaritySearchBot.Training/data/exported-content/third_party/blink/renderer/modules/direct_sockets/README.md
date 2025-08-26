URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\blink\renderer\modules\direct_sockets\README.md
This directory implements the Blink side of the [Direct Sockets
API](https://github.com/WICG/direct-sockets/blob/main/docs/explainer.md).

It will connect to a DirectSocketsService Mojo service in the browser,
which performs security checks, provides dialogs, and forwards requests to
the Network service.
