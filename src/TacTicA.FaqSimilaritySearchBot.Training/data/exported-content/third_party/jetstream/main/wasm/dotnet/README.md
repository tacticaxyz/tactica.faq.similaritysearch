URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\jetstream\main\wasm\dotnet\README.md
# .NET on WebAssembly

Tests [.NET on WebAssembly](https://github.com/dotnet/runtime). This benchmark tests operations
on .NET implementation of String, JSON serialization, specifics of .NET exceptions and computation
of a 3D scene using Mono Interpreter & AOT. Source code: [.NET](wasm/dotnet)

## Build instructions

Download .NET SDK 9.0.3xx

- [dotnet-sdk-win-x64.zip](https://aka.ms/dotnet/9.0.3xx/daily/dotnet-sdk-win-x64.zip)
- [dotnet-sdk-linux-x64.tar.gz](https://aka.ms/dotnet/9.0.3xx/daily/dotnet-sdk-linux-x64.tar.gz)

Run `build.sh` script. It will install `wasm-tools` workload & build the benchmark code twice (for Mono interpreter & AOT).

To run the benchmark code on `jsc`, we are prepending `import.meta.url ??= ""` to `dotnet.js`.

## Background on .NET / build output files

Mono AOT works in a "mixed mode". It is not able to compile all code patterns and in various scenarios it falls back to interpreter.
Because of that we are still loading managed dlls (all the other not-`dotnet.native.wasm` files).

Structure of the build output

- `dotnet.js` is entrypoint JavaScript with public API.
- `dotnet.runtime.js` is internal implementation of JavaScript logic for .NET.
- `dotnet.native.js` is emscripten module configured for .NET.
- `dotnet.native.wasm` is unmanaged code (Mono runtime + AOT compiled code).
- `System.*.wasm` is .NET BCL that has unused code trimmed away.
- `dotnet.wasm` is the benchmark code.
