URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\third_party\puppeteer\package\src\injected\README.md
# Injected

This folder contains code that is injected into every Puppeteer execution context. Each file is transpiled using esbuild into a script in `src/generated` which is then imported into server code.

See `tools/generate_sources.ts` for more information.
