URL:https://blog.chromium.org/2025/07/introducing-skia-graphite-chromes.html
# Introducing Skia Graphite: Chrome's rasterization backend for the future
- **Published**: 2025-07-08T10:46:00.000-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi_oXM-_56tbxbRYQxIunAhz47yN-RJHgS4FSb4wnuyaBN5amMkmRSGXu9oWoQ9apIB-DOl1RRi69mwcOLlV2EaD8HBjBPFg0p1dud7HStcmzIRYa3wwq11BjsKOeC_pUykrZMSJvsl2RlCQktC0xw28TpBnEbqBJxev7D-ZFHVBt20bshdN6wLtogSN6MG/s1600/Fast%20Curious_image%20%281%29.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi_oXM-_56tbxbRYQxIunAhz47yN-RJHgS4FSb4wnuyaBN5amMkmRSGXu9oWoQ9apIB-DOl1RRi69mwcOLlV2EaD8HBjBPFg0p1dud7HStcmzIRYa3wwq11BjsKOeC_pUykrZMSJvsl2RlCQktC0xw28TpBnEbqBJxev7D-ZFHVBt20bshdN6wLtogSN6MG/s1600/Fast%20Curious_image%20%281%29.png)

*Today's The Fast and the Curious post covers the launch of Skia's new rasterization backend, Graphite, in Chrome on Apple Silicon Macs. Graphite is instrumental in helping Chrome achieve exceptional scores on Motionmark 1.3 and is key to unlocking a ton of future improvements in Chrome Graphics.*

A brief history of Skia in Chrome
=================================

In Chrome, Skia is used to render paint commands from Blink and the browser UI into pixels on your screen, a process called rasterization. Skia has powered Chrome Graphics [since the very beginning](https://www.google.com/url?q=https://blog.chromium.org/2008/10/graphics-in-google-chrome.html&sa=D&source=docs&ust=1744655288075052&usg=AOvVaw2iZg3ILJvcyGeG8RDYzVNv). Skia eventually ran into performance issues as the web evolved and became more complex, which led Chrome and Skia to invest in a GPU accelerated rasterization backend called Ganesh.

Over the years, Ganesh matured into a solid highly performant rasterization backend and GPU rasterization launched on all platforms in Chrome on top of GL (via ANGLE on Windows D3D9/11). However, Ganesh always had a GL-centric design with too many specialized code paths and the team was hitting a wall when trying to implement optimizations that took advantage of modern graphics APIs in a principled manner.

This set the stage for the team to rethink GPU rasterization from the ground up in the form of a new rasterization backend, Graphite. Graphite was developed from the start to be principled by having fewer and more comprehensible code paths. This forward looking design helps take advantage of modern graphics APIs like Metal, Vulkan and D3D12 and paradigms like compute based path rasterization, and is multithreaded by default.

Results
=======

With Graphite in Chrome, we increased our Motionmark 1.3 scores by almost 15% on a Macbook Pro M3. At the same time, we improved real world metrics like INP (interaction to next paint time), LCP (time to largest contentful paint), graphics smoothness (percent dropped frames), GPU process malloc memory usage, and others. This all means substantially smoother interactions, less stutter when scrolling, and less time waiting for sites to show.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjK7OcoGT0p5zxAfiA30b8wcjhxDlovG2IUL3DNsazr0NBYBK-yoizvfdjng-6jOXE_T4hEGGGR6D3MsytJj6qkFkjS8Fjs8PjYHbHvCljY6fwmpMUIalNFg4QRp2fpFolLIQJmwar4IrhBtgbzuyhh7zRMbSv_rHSsDBycZ0G0SDn53owruvmmkgqTs9qr/s1600/Screenshot%202025-07-08%20at%2012.40.51%E2%80%AFPM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjK7OcoGT0p5zxAfiA30b8wcjhxDlovG2IUL3DNsazr0NBYBK-yoizvfdjng-6jOXE_T4hEGGGR6D3MsytJj6qkFkjS8Fjs8PjYHbHvCljY6fwmpMUIalNFg4QRp2fpFolLIQJmwar4IrhBtgbzuyhh7zRMbSv_rHSsDBycZ0G0SDn53owruvmmkgqTs9qr/s1600/Screenshot%202025-07-08%20at%2012.40.51%E2%80%AFPM.png)

Differences between Graphite and Ganesh
=======================================

### Modern graphics APIs

Ganesh was originally implemented on OpenGL ES, which had minimal support for multi-threading or GPU capabilities like compute shaders. Since then, modern graphics APIs like Vulkan, Metal and D3D12 have evolved to take advantage of multithreading and expose new GPU capabilities. They allow applications to have much more control over when and how expensive work such as allocating GPU resources is performed and scheduled, while utilizing both the CPU and the GPU effectively.

While we were able to adapt Ganesh to support modern graphics APIs, it had accumulated enough technical debt that it became hard to fully take advantage of the multi-threading and GPU compute capabilities of modern graphics APIs.

For Graphite in Chrome, we chose to use Chrome's WebGPU implementation, [Dawn](https://dawn.googlesource.com/dawn), as the abstraction layer for platform native graphics APIs like Metal, Vulkan and D3D. Dawn provides a baseline for capabilities common in modern graphics APIs and helps us reduce the long term maintenance burden by leveraging Dawn's mature well tested native backends instead of implementing them from scratch for Graphite.

### 2D depth(?!) testing

A core part of the GPU rendering pipeline is depth testing, which can reduce or eliminate overdraw by drawing opaque objects in front to back order, followed by translucent objects back to front. In graphics, "overdraw" refers to the unnecessary rendering of the same pixels multiple times, which can negatively impact performance and battery life, especially on mobile devices.

Ganesh never utilized the depth testing capabilities of graphics cards, which was admittedly intended for rendering 3D content and not accelerating 2D graphics. Ganesh suffers from overdraw due to its reliance on adhering to strict painters order when drawing both opaque and translucent objects.

Graphite extends Skia’s GPU rendering to take advantage of the depth test by assigning each “draw” a *z* value defining its painter’s ordering index. While transparent effects and images must still be drawn from back to front, opaque objects in the foreground can now automatically eliminate overdraw. This means opaque draws can be re-ordered to minimize expensive GPU state changes while relying on the depth buffer to produce correct output.

Depth testing is also used to implement clipping in Graphite by treating clip shapes as depth only draws as opposed to maintaining a clip stack like in Ganesh. Besides reducing algorithmic complexity, a significant benefit to this approach is that the shader program required to render a “draw” does not also depend on the state of the clip stack.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhJvgOlBS_vrfP7D7vbi9seLOrlsKLhSWmuo6Lc6RiHIjvm23kjXT7zNM_iFS_ojrEowtoLhvSaCgDeoSWlwFWDH5vyqE23zhLCjPPrs6fLVTiGWw-os-ErUrz3VicU1r_Za-A4tRzyeW1BrVmqz8sgK7QLNMK27eB2u7lPeX1Kb9O4o-6y3bNzRZi9z3VZ/s1600/Screenshot%202025-07-08%20at%2012.42.02%E2%80%AFPM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhJvgOlBS_vrfP7D7vbi9seLOrlsKLhSWmuo6Lc6RiHIjvm23kjXT7zNM_iFS_ojrEowtoLhvSaCgDeoSWlwFWDH5vyqE23zhLCjPPrs6fLVTiGWw-os-ErUrz3VicU1r_Za-A4tRzyeW1BrVmqz8sgK7QLNMK27eB2u7lPeX1Kb9O4o-6y3bNzRZi9z3VZ/s1600/Screenshot%202025-07-08%20at%2012.42.02%E2%80%AFPM.png)

Left: Frame from Motionmark Suits Right: Depth buffer for the same frame.

### Multithreading

Chromium is a complex multi-process application, with render processes issuing commands to a shared GPU process that is responsible for actually displaying everything in a webpage, tab, and even the browser UI. The GPU process main thread is the primary driver of all rendering work and is where all GPU commands are issued.

Due to the single threaded nature of Ganesh and OpenGL, only a limited set of work could be moved to other threads, making it easy to overload the main thread causing increased jank and latency ultimately hurting user experience.

In contrast, Graphite's API is designed to take advantage of multithreading capabilities of modern graphics APIs. Graphite’s new core API is centered around independent *Recorders* that can produce *Recordings* on multiple threads, with minimal need to synchronize between them. Even though the *Recordings* are submitted to the GPU on the main thread, more expensive work is moved to other threads when producing *Recordings*, keeping the GPU main thread free.

### Performance cliffs and pipeline compilation

When Ganesh was initially implemented, the programmable capabilities of graphics cards were quite limited, and branching in particular was expensive. To work around this, Ganesh had many specialized shader pipelines to handle common cases. These specializations are hard to predict and depend on a large number of factors related to each individual draw, leading to an explosion of different pipelines for essentially the same page content. Since these pipelines must each be compiled, it doesn't work well for modern web content which might have effects and animations trigger new pipelines at any moment, causing noticeable jank.

Graphite’s design philosophy is instead to consolidate the number of rendering pipelines as much as possible while still preserving performance. This reduces the number of pipelines that have to be compiled, and makes it possible for Chrome to ensure they are compiled at startup so they do not interrupt active browsing. Ganesh’s specialization approach also led to surprising performance cliffs. For example, while it could handle simple cases, real page content was often a complex mix. By consolidating pipelines, complex content can be rendered as effectively as simple content.

Future Plans
============

### Multithreaded Rasterization

Currently, Graphite is integrated into Chromium using two Recorders: one handles web content tiles and Canvas2D on the main thread, while the other is for compositing. In the future, this model will open up a number of exciting possibilities to further improve Chrome’s performance. Instead of saturating the main GPU thread with the tasks from each renderer process, rasterization can be forked across multiple threads.

Current:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj3Yp75STRKmlqx_4MJ5OTvQ5Tz1z7v2xRopsCekbpxOuUrxWptOz5ihk6VIJNTtj4uwKzV2CGOC_s_hJXKRKYkyOd1mKeol4SO20GdRuRQLS7KlkWpy5TuslgfJJz8fuoXUMvDwHmtqgFVGVsb08Yf5th5LX84dwGBRHZqSAOdcAxZYOPKu_tVWJBFkBIL/s1600/Screenshot%202025-07-08%20at%2012.43.01%E2%80%AFPM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj3Yp75STRKmlqx_4MJ5OTvQ5Tz1z7v2xRopsCekbpxOuUrxWptOz5ihk6VIJNTtj4uwKzV2CGOC_s_hJXKRKYkyOd1mKeol4SO20GdRuRQLS7KlkWpy5TuslgfJJz8fuoXUMvDwHmtqgFVGVsb08Yf5th5LX84dwGBRHZqSAOdcAxZYOPKu_tVWJBFkBIL/s1600/Screenshot%202025-07-08%20at%2012.43.01%E2%80%AFPM.png)

Future:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjfZABxcWDhyphenhyphen8ziigDEkaW97viWcKe-TVFCf9gISovY__siuJKB09cUmyV4TPqB78Y1LzOyU5zHQgeH_eGEZ9aepscWyFWVhTtrpu6QwHzWGBmG70iPibu4e4NX47XHBOXV0Ufa6eyEvV2-i9gD-KlrOdfHMrmfpp7ueXPvsRsmgLgCBQvTxGEMvRmb4M9i/s1600/Screenshot%202025-07-08%20at%2012.44.09%E2%80%AFPM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjfZABxcWDhyphenhyphen8ziigDEkaW97viWcKe-TVFCf9gISovY__siuJKB09cUmyV4TPqB78Y1LzOyU5zHQgeH_eGEZ9aepscWyFWVhTtrpu6QwHzWGBmG70iPibu4e4NX47XHBOXV0Ufa6eyEvV2-i9gD-KlrOdfHMrmfpp7ueXPvsRsmgLgCBQvTxGEMvRmb4M9i/s1600/Screenshot%202025-07-08%20at%2012.44.09%E2%80%AFPM.png)

### Reducing GPU memory for simple content

Graphite recordings can also be re-issued to the GPU with certain dynamic changes such as translation. This can be used to accelerate scrolling while eliminating the unnecessary work to re-issue rendering commands. This lets us automatically reduce the amount of GPU memory required to cache web content as tiles. If the content is simple enough, the performance difference between drawing a cached image and drawing its content can be worth skipping allocating a tile for it and just re-rendering it each frame.

### GPU Compute Path Rasterization

In the landscape of 2D graphics rendering, [GPU compute-based path rasterization](https://raphlinus.github.io/rust/graphics/gpu/2020/06/13/fast-2d-rendering.html) is very much en vogue with recent implementations like [Pathfinder](https://github.com/pcwalton/pathfinder) and [vello](https://github.com/linebender/vello). We would like to implement these ideas in Skia, possibly using a [hybrid approach](https://docs.google.com/document/d/1gEqf7ehTzd89Djf_VpkL0B_Fb15e0w5fuv_UzyacAPU/preview). Currently, Graphite relies on MSAA where it can, but in many cases we can't due to poor performance on older integrated GPUs or high memory overhead on non-tiling GPUs, and we have to fallback to CPU path rasterization using an atlas for caching. GPU compute based path rasterization would allow us to improve over both the visual quality of MSAA which is often limited to 4 samples per pixel and over the performance of CPU rasterization.

These are future directions the Chrome Graphics team plans to pursue, and we are excited to see how far we can push the needle.

Posted By Michael Ludwig & Sunny Sachanandani