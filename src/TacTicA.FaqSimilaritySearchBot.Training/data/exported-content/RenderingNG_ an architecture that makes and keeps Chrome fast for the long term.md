URL:https://blog.chromium.org/2021/10/renderingng.html
# RenderingNG: an architecture that makes and keeps Chrome fast for the long term
- **Published**: 2021-10-06T12:37:00.001-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEh67x9GG_EvidjIC1u6nNQe5ClGqafqQ0LjQIs_jzlM8ZqzKPcxihUR2u_3UG1nCp3mXcLnftmjV40l2JQnaY6998FWizsui1nSQdrKxeT26uSUyL6rQi7jd0R8nvHfIMeeZX_v_OVUYyZ6/w579-h241/image1.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEh67x9GG_EvidjIC1u6nNQe5ClGqafqQ0LjQIs_jzlM8ZqzKPcxihUR2u_3UG1nCp3mXcLnftmjV40l2JQnaY6998FWizsui1nSQdrKxeT26uSUyL6rQi7jd0R8nvHfIMeeZX_v_OVUYyZ6/s1999/image1.jpg)

  
*Our continual investments in the performance of Chrome have led to significant improvements in battery life, memory, and the speed of the web. This post in [The Fast & the Curious series](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) highlights the rendering journey of Chrome over the past eight years, a journey that has led to a browser that is better across the board. For example, Chrome 94, as compared with Chrome 93:*

* *is up to 8% more responsive on real pages,*
* *saves more than 1400 years of CPU time per day, and*
* *improves battery life by up to 0.5%*

*In addition, recent versions of Chrome are much better than those of years past with:*

* *150% or more faster graphics rendering, and*
* *greater reliability, due to a 6x reduction in GPU driver crashes on problematic hardware*

**Introduction**
================

[RenderingNG](https://developer.chrome.com/blog/renderingng/) is a long-term project to systematically improve Chrome performance as experienced by our users over time, while also anticipating future needs. This enables the web to stay fast even as the web becomes ever richer and more featureful.  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEip8lgM4HzW4HOuDGIZcFgV2S23bQn9Su7fcNXT0zGBBDL2mFyzcV_ca8pa4KVmpztXVl2yPMPoP6tW8bY7YMxnL6kYsRLYwloYsn3LS4LHiypeZcgc-JOOHz0V4lueHeOA6oQ5Np8HLOik/s320/image2.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEip8lgM4HzW4HOuDGIZcFgV2S23bQn9Su7fcNXT0zGBBDL2mFyzcV_ca8pa4KVmpztXVl2yPMPoP6tW8bY7YMxnL6kYsRLYwloYsn3LS4LHiypeZcgc-JOOHz0V4lueHeOA6oQ5Np8HLOik/s1080/image2.gif)

  

[RenderingNG](https://developer.chrome.com/blog/renderingng/)

  
  
We began the journey more than 8 years ago, and I’m happy to report that in 2021, the core RenderingNG projects are [coming to a conclusion](https://developer.chrome.com/blog/renderingng/#key-projects-that-make-up-renderingng). This not only makes the existing web super fast, but even better, it means Chrome is ready for the next generation of web content.  
  
RenderingNG is comprised of three elements: performance, reliability and extensibility.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEivPCHjGNfrCLvRM9hud-ta4tg95Il-2lrisV-yZYkNWVl0MjYgBmhfjifC70Us0NMOpZCj2qwpFKntNI01od0k5dGFB75blllfItgstorBPGxofJ4HdFi99INNwwuAw9OO5sbPQspBQ7He/s320/image1.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEivPCHjGNfrCLvRM9hud-ta4tg95Il-2lrisV-yZYkNWVl0MjYgBmhfjifC70Us0NMOpZCj2qwpFKntNI01od0k5dGFB75blllfItgstorBPGxofJ4HdFi99INNwwuAw9OO5sbPQspBQ7He/s1080/image1.jpg)

The [pyramid of success](https://developer.chrome.com/blog/renderingng/#the-pyramid-of-success)

**Performance**
===============

Let’s start with performance.

### GPU & multi-core

A great way Chrome can render content faster is to take advantage of the multi-core CPUs and advanced GPUs present in today’s devices. Multi-core means we can do multiple kinds of work in parallel. For example, Chrome parallelizes running JavaScript, scrolling a web page, decoding an image or video, and rastering new content that will be on-screen soon. GPUs enable even more parallelization by [rastering](https://en.wikipedia.org/wiki/Raster_graphics) every pixel on-screen, rather than one-at-a-time, yielding a large speedup.  
  
Earlier generations of browsers were not built to natively support these technologies, because at the time GPUs and multi-core computers were not widespread. It turned out that bolting on highly parallel features was extremely challenging, requiring the team to re-architect the entire Chrome rendering pipeline over time. This re-architecture is RenderingNG.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj-Wh6nzhDPgT-7w5cSkIZ6864kYjoJcLymnB0Oy4uvyS5TaAeOx_kjdPvKmgdj78avyTIYseFUbsBKvv_clk9i2YxsUfbRH3xEGNpMfjDMMUaayDeqJoRjtlf7pyKcEBXyNY-MBBeuWXhE/s320/image6.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj-Wh6nzhDPgT-7w5cSkIZ6864kYjoJcLymnB0Oy4uvyS5TaAeOx_kjdPvKmgdj78avyTIYseFUbsBKvv_clk9i2YxsUfbRH3xEGNpMfjDMMUaayDeqJoRjtlf7pyKcEBXyNY-MBBeuWXhE/s1078/image6.gif)

  

### Scaling up and scaling down

To avoid exhausting available resources and potentially diminishing the user experience of the web, browsers must be respectful of efficiency. They should not slow down your ability to interact with your computer or phone, or keep you from multitasking between the browser and other apps. Likewise, browsers also need to maximize battery life of your phone and laptop, and prevent the device itself from getting too hot (here’s looking at you, CPU cooling fans!). And finally, the browser must always be smooth and responsive to the user.  
  
This means that the browser needs to be able to scale up and down its use of the GPU and multi-threading to balance multitasking, battery, and device temperature. As one example of scaling up, it’s important that scrolling happen in parallel with JavaScript on all devices; otherwise the browser will have poor user responsiveness. On the other hand, there are times when the browser must scale down because battery life may be considered more important than maximum use of GPU and CPU resources to make rendering faster.  
  
It turns out to be challenging to be able to scale up and scale down seamlessly, and in a way that doesn’t break web content or make the browser unresponsive in key situations. RenderingNG applies novel technologies throughout the stack to make this work, including a complete rewrite of how compositing works, enabling the flexible use of GPU or CPU computations for arbitrary pieces of web pages, in order to pick the right fit for each web page and device.  
  

### Performance isolation

The third key technique is performance isolation. Performance isolation is what allows you to have a nice experience reading your email while music and video is playing in the background: your computer and operating system (OS) architecture makes sure that they all share the CPU fairly and smoothly. (This feature has been around for native apps for so long, we just take it for granted, but [it wasn’t always that way](https://en.wikipedia.org/wiki/Cooperative_multitasking)!)  
  
Browsers already have good isolation from other apps on your computer (thanks to the OS), but within a web page, it can be difficult to isolate all the pieces, such as iframes for ads and other embedded content, video and audio, animations, scrolling, JavaScript, and various other browser tasks. In earlier eras of the web, it was a huge achievement to simply make all these features work at all. Now the bar has been raised, and they need to fit together seamlessly in order to create a reliably fast user experience on the web.  
  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg1umnBNG1y_HNYJzwpQcglWujaPOdAJLJE7t5ndZBVpUiPOzpRtmNRwR-j1JbHlBeEQTYLeNRYrjXYUI_lw6SEG3Us6JTuXq3Kja6bE1WAHuQSY1M85JEF-GuP4BmGIgXVOImNt4LFGB6q/s320/image4.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg1umnBNG1y_HNYJzwpQcglWujaPOdAJLJE7t5ndZBVpUiPOzpRtmNRwR-j1JbHlBeEQTYLeNRYrjXYUI_lw6SEG3Us6JTuXq3Kja6bE1WAHuQSY1M85JEF-GuP4BmGIgXVOImNt4LFGB6q/s1077/image4.gif)

RenderingNG’s architecture implements performance isolation for all of these features.

Reliability
===========

Most of our work has been focused on [reliability](https://developer.chrome.com/blog/renderingng/#reliability) of the user experience. This is especially true when rewriting the entire rendering stack of a web browser--a huge and potentially risky undertaking.

We did this with four key techniques:

* Comprehensive testing, such as a huge battery of [Web Platform Tests](https://wpt.fyi/results/),
* Measuring progress in reliability, through metrics that track performance & quality, and committed goals such as [Compat2021](https://wpt.fyi/compat2021),
* [Listening to and acting on](https://docs.google.com/document/d/1JOtp1LS7suqTjMuv41jQFc7aCTR33zJKPoGjKpvVFCA/edit) bug reports and feedback,
* Good [software design patterns](https://developer.chrome.com/blog/renderingng-architecture/).

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhxURJXvSSpw3jA1IfH_CatWKGev1QkNWaXEtTKYoxQ8XnR5LLZd9jDkb3eXVZjfxrWqChOF4EEG-DR8fDJ0caUy4EWPZcdA-bFTNAkEYqaRK9t7x9brpBSV2NlcOsEVwJA5sR8dticFtFA/w541-h270/image3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhxURJXvSSpw3jA1IfH_CatWKGev1QkNWaXEtTKYoxQ8XnR5LLZd9jDkb3eXVZjfxrWqChOF4EEG-DR8fDJ0caUy4EWPZcdA-bFTNAkEYqaRK9t7x9brpBSV2NlcOsEVwJA5sR8dticFtFA/s708/image3.png)

[Compat2021](https://web.dev/compat2021/) improvements [over time](https://wpt.fyi/compat2021)

Extensibility
=============

Finally, we always have one eye toward what web apps will need now and in the future to unlock better and better experiences for users. These apps are always pushing at the boundary of what is possible to do well on the web, and sometimes beyond. When they go beyond what current web APIs or architectures were designed for, the web app may still work, but it’ll sometimes be slower and more cumbersome to use---and more taxing on your computer than necessary. We are [filling these gaps with new APIs](https://developer.chrome.com/blog/renderingng/#extensibility-the-right-tools-for-the-job) that allow web apps to continue doing all these things, but in a way that is much easier to implement performantly.  
  
[Extensibility](https://developer.chrome.com/blog/renderingng/#extensibility-the-right-tools-for-the-job) has been part of the design of RenderingNG from the beginning, and is a big reason why the system is clean and [modular](https://developer.chrome.com/blog/renderingng-architecture/#rendering-pipeline-structure).  
  

Results
=======

The [first](https://developer.chrome.com/blog/renderingng/#key-projects-that-make-up-renderingng) RenderingNG performance optimization shipped in 2015. Below we’ve highlighted a few of the many subsequent performance improvements since then.

### CompositeAfterPaint: faster and more responsive on all pages [1]

In the M94 release, we will ship [CompositeAfterPaint](https://developer.chrome.com/blog/renderingng/#compositeafterpaint), a new compositing subsystem that allows for arbitrary scaling up and down of GPU use for web app content. Even better, due to more efficient, purpose-built algorithms in this subsystem, CompositeAfterPaint will substantially improve:  

* Scroll latency by up to 8%
* Responsiveness by up to 3%
* Peak rendering speed by up to 3%
* GPU memory use by more than 3%
* CPU time spent rendering and interacting with tabs, resulting in a savings of more than 1400 years of CPU time per day
* Battery life by up to 0.5%

### 

### GPU Raster: dramatically faster than before [2]

When it [shipped](https://developer.chrome.com/blog/renderingng/#gpu-acceleration-everywhere) on Mac in 2016, GPU raster resulted in a 37% improvement on the overall MotionMark benchmark, and 150% on HTML categories. We subsequently brought similar wins to all other platforms and content types, concluding in 2020. In 2021 we shipped improvements focused on further GPU acceleration for 2D Canvas rendering, with up to a 1000% improvement in the Path rendering test, and a 130% improvement overall on the MotionMark 1.2 benchmark, as measured on an Apple M1 Mac.

### Out-of-process Raster: much-improved reliability [1]

Out-of-process raster [shipped](https://developer.chrome.com/blog/renderingng/#viz) on Android in 2018. This reduced the crash rate for problematic GPU drivers by 6x, bringing reliability in line with other drivers.

Learn more
==========

If you’d like to learn more about RenderingNG, head over to the Chrome Developers Blog, where we are publishing a whole [series](https://developer.chrome.com/tags/rendering/) about the project, with more to come over time.  
  
Thanks for reading!

Posted by Chris Harrelson, Lead Rendering Software Engineer  
  
*[1] Data source: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.  
[2] Data source: [MotionMark](https://browserbench.org/MotionMark1.2/).*