URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\unencodedDigestMalformedDictionary.md
# An `unencoded-digest` header cannot be parsed.

[`unencoded-digest`](unencodedDigestHeader) headers must be formatted as a
[Dictionary](sfDictionary), wherein each member's label specifies the hashing
algorithm, and the value is a [Byte Sequence](sfByteSequence) containing the
digest. The digest delivered with this response did not format the response
correctly.

For example, if the body was "Hello, world.", the following would be a correctly
formatted header:

```
Unencoded-Digest: sha-256=:+MO/YqmqPm/BYZwlDkir51GTc9Pt9BvmLrXcRRma8u8=:
```
