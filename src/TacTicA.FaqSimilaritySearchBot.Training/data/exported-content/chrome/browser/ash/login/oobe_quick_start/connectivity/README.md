URL:https://source.chromium.org/chromium/chromium/src/+/main:chrome\browser\ash\login\oobe_quick_start\connectivity\README.md
This directory contains the functionality needed to connect to a phone over
Bluetooth and drive the device-to-device communication for Quick Start, and is
owned by the Cross Device team.

TargetDeviceConnectionBroker is the main entry point. Calling code is expected
to obtain a member of this class from TargetDeviceConnectionBrokerFactory.
