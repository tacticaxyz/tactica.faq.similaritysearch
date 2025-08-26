URL:https://source.chromium.org/chromium/chromium/src/+/main:components\captive_portal\README.md
The captive portal component is a layered component. The core/ subdirectory
includes code shared across all platforms, including iOS; code in core/
cannot depend on the Content API. The content/ subdirectory, meanwhile, is
used only on //content-based platforms and can freely use the Content API.
