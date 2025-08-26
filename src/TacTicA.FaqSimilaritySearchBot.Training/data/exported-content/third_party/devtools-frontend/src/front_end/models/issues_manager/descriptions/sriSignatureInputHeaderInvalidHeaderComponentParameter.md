URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriSignatureInputHeaderInvalidHeaderComponentParameter.md
# Invalid parameter on a header component in a `signature-input` header.

The header [`unencoded-digest`](unencodedDigestHeader) must be specified as
being strictly serialized in the signature base, using the
[`sf` parameter](componentParameterSf). No other parameter may be specified.
