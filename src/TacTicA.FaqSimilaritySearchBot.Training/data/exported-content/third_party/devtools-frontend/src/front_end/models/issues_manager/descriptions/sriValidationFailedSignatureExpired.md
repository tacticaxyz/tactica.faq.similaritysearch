URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriValidationFailedSignatureExpired.md
# Signature verification failed: the signature is expired.

The [`expires` parameter](signatureParameters) specified in a
[`signature-input`](signatureInputHeader) header is a UNIX timestamp
representing a time in the past. The signature has therefore expired, and
verification is not possible.
