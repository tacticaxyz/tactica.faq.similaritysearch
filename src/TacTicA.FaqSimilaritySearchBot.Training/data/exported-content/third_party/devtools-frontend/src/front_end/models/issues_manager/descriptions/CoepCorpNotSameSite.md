URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\CoepCorpNotSameSite.md
# Specify a more permissive Cross-Origin Resource Policy to prevent a resource from being blocked

Your site tries to access an external resource that only allows same-site usage.
This behavior prevents a document from loading any non-same-site resources which don’t explicitly grant permission to be loaded.

To solve this, add the following to the resource’s HTML response header: `Cross-Origin-Resource-Policy: cross-origin`
⚠️If you set this header, any website can embed this resource.
