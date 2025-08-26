URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\ci\official\containers\ml_build\README.md
WIP ML Build Docker container for ML repositories (Tensorflow, JAX and XLA).

This container branches off from
/tensorflow/tools/tf_sig_build_dockerfiles/. However, since
hermetic CUDA and hermetic Python is now available for Tensorflow, a lot of the
requirements installed on the original container can be removed to reduce the
footprint of the container and make it more reusable across different ML
repositories.
