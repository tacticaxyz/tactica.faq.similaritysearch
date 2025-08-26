URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriSignatureInputHeaderInvalidComponentName.md
# A `signature-input` header member's value contains an unknown component.

The metadata delivered via [`signature-input`](signatureInputHeader) can only
contain a limited set of components in the list it specifies. The known
components are:

* "`unencoded-digest`"
* "`@path`"
