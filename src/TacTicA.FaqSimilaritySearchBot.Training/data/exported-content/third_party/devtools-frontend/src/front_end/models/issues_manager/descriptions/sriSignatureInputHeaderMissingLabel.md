URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriSignatureInputHeaderMissingLabel.md
# Label mismatch between `signature` and `signature-input` headers.

A [`signature`](signatureHeader) header specifies a signature whose label does
not appear in a corresponding [`signature-input`](signatureInputHeader) header.
Without a `signature-input` header's definition of the signature's metadata,
the signature cannot be verified.
