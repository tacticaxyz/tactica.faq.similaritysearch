URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\third_party\xla\xla\core\host_offloading\README.md
# XLA Host Offloading

XLA host offloading allows us to run part of the HLO module on the host attached
to the accelerator device (TPU or GPU) using the XLA:CPU compiler. On JAX side
it is available as `jax.experimental.compute_on` API.

With `compute_on` annotation, JAX + XLA can be used to implement
[ZeRO-Offload](https://arxiv.org/abs/2101.06840) host offloading.