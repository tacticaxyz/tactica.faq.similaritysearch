URL:https://source.chromium.org/chromium/chromium/src/+/main:components\services\paint_preview_compositor\README.md
Paint Preview Compositor is a service for compositing SkPictures and metadata
representing the painted contents of a webpage (collection of RenderFrames) into
bitmaps. These bitmaps can be consumed by a UI to replay a static version of a
webpage without a renderer (effectively a large screenshot represented by
paint-ops).
