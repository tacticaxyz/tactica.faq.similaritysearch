URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriSignatureHeaderValueIsNotByteSequence.md
# A `signature` header member's value is not a Byte Sequence.

Responses' [`signature`](signatureHeader) header should be formatted as a
[Dictionary](sfDictionary) containing one or more signatures. Each member's key
is a label for the signature which maps it to the relevant metadata defined in
a [`signature-input`](signatureInputHeader) header. Each member's value is a
[Byte Sequence](sfByteSequence) containing the signature itself.

For example, the following header contains a single Ed25519 signature labeled
"label":

```
Signature: label=:gHim9e5Pk2H7c9BStOmxSmkyc8+ioZgoxynu3d4INAT4dwfj5LhvaV9DFnEQ9p7C0hzW4o4Qpkm5aApd6WLLCw==:
```
