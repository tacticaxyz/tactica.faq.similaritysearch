URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\dawn\docs\dawn\features\norm16_texture_formats.md
# Norm16 texture formats

Adds support for norm16 formats with `CopySrc|CopyDest|RenderAttachment|TextureBinding` usages, multisampling and resolving capabilities.
Additional formats are:

 - `wgpu::TextureFormat::R16Snorm`
 - `wgpu::TextureFormat::RG16Snorm`
 - `wgpu::TextureFormat::RGBA16Snorm`
 - `wgpu::TextureFormat::R16Unorm`
 - `wgpu::TextureFormat::RG16Unorm`
 - `wgpu::TextureFormat::RGBA16Unorm`

The initial tracking bug was https://crbug.com/dawn/1982.
