URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\oak\src\enclave_apps\oak_echo_raw_enclave_app\README.md
# Oak Echo Raw

Echo enclave application that can be run under Restricted Kernel.

Echo binary receives a message as bytes, and sends back the same bytes, without
interpreting them.

This binary doesn't use microRPC to communicate between the Untrusted Launcher
and the guest VM, but instead uses a raw SimpleIO channel. The binary is used
primarily for Vanadium tests.
