URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\tflite\src\tensorflow\core\profiler\backends\README.md
This directory contains subclasses of `tensorflow::profiler::ProfilerInterface`
and related code.

`tensorflow::ProfilerSession` manages a collection of profile sources. Each
profile source implements a subclass of
`tensorflow::profiler::ProfilerInterface`.
