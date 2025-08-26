URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\sriValidationFailedIntegrityMismatch.md
# Integrity verification failed.

The signature associated with a response could be successfully verified, but the
public keys asserted in the [`signature-input`](signatureInputHeader)
header's [`keyid` parameter](signatureParameters) do not match the integrity
assertions made by the request's initiator. Verificiation failed.

The following are the keys specified by the request's initiator:

{PLACEHOLDER_integrityAssertions}
