URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\oak\src\sev_serial\README.md
# Serial Port logging device driver for SEV-SNP

This is a basic implementation of a serial port driver that is compatible with
raw port-based IO and the AMD SEV-ES and SEV-SNP GHCB IOIO protocol. The
intended use is for emergency logging, such as during early startup when the
guest communications channel is not yet set up or when panicking.
