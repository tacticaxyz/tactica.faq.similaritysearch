URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriSignatureInputHeaderInvalidParameter.md
# Invalid parameter on the list of components in a `signature-input` header.

The `signature-input` header's [Inner Lists](sfInnerList) must be specified with the
[`keyid` and `type` parameters](signatureParameters). The following parameters may
also be specified:

* `created`
* `expires`
* `nonce`

No other parameter may be specified.
