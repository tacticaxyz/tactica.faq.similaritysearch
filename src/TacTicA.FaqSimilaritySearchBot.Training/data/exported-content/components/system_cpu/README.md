URL:https://source.chromium.org/chromium/chromium/src/+/main:components\system_cpu\README.md
This directory contains classes for collecting CPU usage from the operating
system. `system_cpu::CpuProbe` is a base class that provides a common interface
across different platforms and acts as a dependency injection point for tests.
Currently supports Linux/ChromeOS, Mac, and Windows.