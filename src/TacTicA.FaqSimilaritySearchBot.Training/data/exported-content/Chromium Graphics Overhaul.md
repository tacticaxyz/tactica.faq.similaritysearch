URL:https://blog.chromium.org/2010/08/chromium-graphics-overhaul.html
# Chromium Graphics Overhaul
- **Published**: 2010-08-27T10:00:00.000-07:00
For some time now, there’s been a lot of work going on to overhaul Chromium’s graphics system. New APIs and markup like WebGL and 3D CSS transforms are a major motivation for this work, but it also lets Chromium begin to take advantage of the GPU to speed up its entire drawing model, including many common 2D operations such as compositing and image scaling. As a lot of that work has been landing in tip-of-tree Chromium lately, we figured it was time for a primer.  
  
At its core, this graphics work relies on a new process (yes, another one) called the GPU process. The GPU process accepts graphics commands from the renderer process and pushes them to OpenGL or Direct3D (via [ANGLE](http://code.google.com/p/angleproject/)). Normally, renderer processes wouldn’t be able to access these APIs, so the GPU process runs in a modified sandbox. Creating a specialized process like this allows Chromium’s sandbox to continue to contain as much as possbile: the renderer process is still unable to access the system’s graphics APIs, and the GPU process contains less logic.   
  
With this basic piece of infrastructure, we’ve started accelerating some content in Chromium. A web page can naturally be divided into a number of more or less independent layers. Layers can contain text styled with CSS, images, videos, and WebGL or 2D canvases. Currently, most of the common layer contents, including text and images, are still rendered on the CPU and are simply handed off to the compositor for the final display. Other layers use the GPU to accelerate needed operations that touch a lot of pixels. Video layers, for example, can now do color conversion and scaling in a shader on the GPU. Finally, there are some layers that can be fully rendered on the GPU, such as those containing WebGL elements.  
  
After these layers are rendered, there’s still a crucial last step to blend them all onto a single page as quickly as possible. Performing this last step on the CPU would have erased most of the performance gains achieved by accelerating individual layers, so Chromium now composites layers on the GPU when run with the --enable-accelerated-compositing flag.  
  
If you’d like to read more about this work, take a look at this [design doc](https://sites.google.com/a/chromium.org/dev/developers/design-documents/gpu-accelerated-compositing-in-chrome) which outlines Chromium’s accelerated compositing system. Over time, we’re looking into moving even more of the rendering from the CPU to the GPU to achieve impressive speedups.  
  
  
Posted by Vangelis Kokkevis, Software Engineer