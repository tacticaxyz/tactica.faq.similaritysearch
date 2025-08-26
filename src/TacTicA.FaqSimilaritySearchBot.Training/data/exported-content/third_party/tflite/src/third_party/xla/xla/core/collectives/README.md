URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\third_party\xla\xla\core\collectives\README.md
# XLA Collective Communication API

A set of APIs defining collective communication libraries abstraction for XLA
backends. We have different backend specific implementation, i.e. on GPU default
collectives API implemented on top of NCCL and on CPU we use Gloo.

XLA collective library is largely inspired by MPI collectives and uses similar
terminology.