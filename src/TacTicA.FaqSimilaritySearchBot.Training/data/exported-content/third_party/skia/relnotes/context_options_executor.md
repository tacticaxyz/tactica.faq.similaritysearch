URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\skia\relnotes\context_options_executor.md
Graphite's `ContextOptions` struct now has an `fExecutor` member. This allows clients to give Graphite threads on which it can perform work. Initially, this facility will be used to compile Pipelines in parallel.
