URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\third_party\xla\xla\tools\hlo_opt\gpu_specs\README.md
The specs in this folder are obtained by calling
`Compiler::TargetConfig::ToString()`, which turns the config into a
`GpuTargetConfigProto`, and then to a `std::string`. Most of the spec is the
device description as a proto `GpuDeviceInfoProto`.

The specs are useful when compiling with the flag
`--xla_gpu_target_config_filename`. Since a hardware generation may have several
SKUs, a spec may not be identical to what we would get on a particular machine,
but it will be "close enough".
