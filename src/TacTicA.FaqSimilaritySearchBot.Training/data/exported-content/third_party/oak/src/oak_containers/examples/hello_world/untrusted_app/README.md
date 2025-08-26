URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\oak\src\oak_containers\examples\hello_world\untrusted_app\README.md
<!-- Oak Logo Start -->
<!-- An HTML element is intentionally used since GitHub recommends this approach to handle different images in dark/light modes. Ref: https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax#specifying-the-theme-an-image-is-shown-to -->
<!-- markdownlint-disable-next-line MD033 -->
<h1><picture><source media="(prefers-color-scheme: dark)" srcset="/docs/oak-logo/svgs/oak-containers-negative-colour.svg?sanitize=true"><source media="(prefers-color-scheme: light)" srcset="/docs/oak-logo/svgs/oak-containers.svg?sanitize=true"><img alt="Project Oak Containers Logo" src="/docs/oak-logo/svgs/oak-containers.svg?sanitize=true"></picture></h1>
<!-- Oak Logo End -->

# Hello World Untrusted App

Implementation of the untrusted part (outside the TEE) of the Oak Containers
Hello World example application.

## Web Client

To run the server:

1. Build the Oak Containers binaries:

   ```sh
   just all_oak_containers_binaries
   ```

2. Start the server:

   ```sh
   cargo run --manifest-path oak_containers/examples/hello_world/untrusted_app/Cargo.toml -- rest --container-bundle bazel-bin/oak_containers/examples/hello_world/trusted_app/bundle.tar
   ```

To access the web client:

1. Open an unsafe instance of Chrome with CORS disabled, via the
   `--disable-web-security` flag:

   - On macOS this can be done via:

     ```sh
     open -n -a /Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --args --user-data-dir="/tmp/chrome_dev_test" --disable-web-security --new-window "http://localhost:8080/"
     ```

   - On other platforms, locate your chrome executable and launch it with the
     `--disable-web-security` flag.

Note: Using an unsafe browser instance is for development purposes only and
should not be used for general browsing.
