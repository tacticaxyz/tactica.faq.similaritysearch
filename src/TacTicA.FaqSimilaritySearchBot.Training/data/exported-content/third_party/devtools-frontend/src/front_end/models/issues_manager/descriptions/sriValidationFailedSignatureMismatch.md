URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriValidationFailedSignatureMismatch.md
# Signature verification failed.

The public key specified in the [`signature-input`](signatureInputHeader)
header's [`keyid` parameter](signatureParameters) does not match the signature
specified in the [`signature`](signatureHeader) header. Verification failed.

The following is the signature base over which the verification attempt was made:

```
{PLACEHOLDER_signatureBase}
```
