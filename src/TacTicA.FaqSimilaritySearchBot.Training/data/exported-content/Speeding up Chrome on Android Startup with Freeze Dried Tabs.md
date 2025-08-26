URL:https://blog.chromium.org/2022/09/speeding-up-chrome-on-android-startup.html
# Speeding up Chrome on Android Startup with Freeze Dried Tabs
- **Published**: 2022-09-15T09:05:00.001-07:00
![](https://lh6.googleusercontent.com/AfryV8_rRENiOVvLdJn_UVDx6Wbl69sHOtVzGZKtusjJIa5l2E90aYS5ZwPSYryQk_nyAWGQp-9eTPOg0Z8GbxzWrFtA1DfxAbSQlu0dugtggsnPxhPEoK4M7CUpIjqpz5b_w0ZhKsjzbZ2GGDkQLmjNemKhNRkMTgG07VnzZh3_jPn-rJXnGv2QUeykGQDiFOhbEozL-k131A42sDeJI8YbDAF10SF4Bg)

We believe that "good enough" is never enough when it comes to pushing the performance of Chrome. Today’s [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post explores how we sped up the startup times of Chrome on Android by more than 20% by providing an interactive freeze-dried preview of a tab on startup. Read on to see how the screenshot falls short, and freeze-drying your tabs makes for a better browser.

  

Background and Motivation
=========================

  

Rendering web content can be computationally intensive and can feel slow at times compared to a native application. A lot of work needs to be done to dynamically load resources over the network, run JavaScript, render CSS, fonts, etc. On mobile devices this is particularly challenging and Chrome can often only keep a handful of web pages loaded at a time due to the memory constraints of the device.

This leads to the question of whether there is a lighter-weight way to represent web content when the situation calls for it—for example, in transitional UI like the tab switcher or during startup when a lot of warm-up work is occurring. The de-facto option for this is a screenshot which is visually accurate and allows a user to see at a glance what they are opening. However, a screenshot is also more limited than a web page as it is constrained to whatever was last visible and is entirely static.

  

What if we could make these transitional glimpses of web content more useful, interactable and engaging while waiting for the real page to be ready?

  

Case Study: Showing Web Content faster at Cold Start
====================================================

  

Chrome App cold startup on Android is expensive. To start drawing a web page at the median takes 3.4s from launch ([First Contentful Paint /FCP](https://web.dev/fcp/)). This can feel slow compared to other apps and is due to all the work needed to process a  page’s HTML, CSS, JS and Fonts. 

  

What if, instead, we showed an interactive snapshot of the page at startup?

  

We call this snapshot a Freeze Dried Tab as it removes a number of features from a live web page, but provides enough content and interactivity to be more helpful than a static screenshot. The key elements we felt that a screenshot lacked were the ability to navigate through links and scroll through a page’s content beyond what is shown in the viewport (including iframes).

  

A Freeze Dried Tab provides all these capabilities and more. It is faster to start than a live web page and provides enough capabilities to get started with the content until the full page is ready. Once the page is loaded, we then transition to it automatically and seamlessly!

  

Testing has shown that by using a Freeze Dried Tab we can speed up the median time taken to draw all the content of the page to just 2.8s from launch (~20% faster compared to starting to draw normally). Since all the content is there and there’s often no [layout shift](https://web.dev/cls/), it feels even faster!

  

![](https://lh5.googleusercontent.com/QbxKeKZXZ4NhN9zRNp6VUz3akuLcLpxqXN0njrWmhaRMugktDiMSAot6_MckdyCuz5wccWxSJX7wKzlA0Feow1-fryPWIE758oUolGfvkiKzaMUf-EkPCpVQdBQueIdbpu8b3ydS-BM0c61tMKeO5a7fHUs-LnlLv-o8vA3yP5uthaFfnf1tiYnSspp2yfBGDvo0gJUk4hq0sLDcShbE2ve86DWSMsHfww)

The distribution shift in startup time caused by Freeze Dried Tabs.

Data source for all statistics: Real-world data anonymously aggregated from Chrome clients [[1]](https://www.google.com/chrome/privacy/whitepaper.html#usagestats)

  

Freeze Dried Tabs - More Details
================================

  

To Freeze Dry a web page we capture the visual state of the page as a set of vector graphics along with any hyperlinks. We can then “reconstitute” (play back) these vector graphics in a lighter-weight fashion by simply rastering the vector graphics. This reduces the rendering cost of showing a full web page (including the content outside the viewport) and still supports hyperlinks.

  

This format provides a number of benefits over a screenshot, but is still not as fully featured as a web page. This is why we believe they are an ideal candidate for transitional views where loading the live page might take some time, but we want to have a more interactive view than a screenshot.

  

![](https://lh6.googleusercontent.com/5KeJlD-AdYw8lcc89Glf-ZuEQgF64fz_nMdxg8q6Bu4YjjK1yFv8606CYE7Tt0QHVXtlsqCxd6bcjn61M_wZ1ZHqCzRiS_9m80Q4OPB7E7LraWGF2LxFwg-Picn_Rpv9DGU2HUxmQsFzWttOCNEtMPYCJfHJ5XXmBjYFtBzuG0N2n2vYJEoNwXg2aK3kjoj6-ekW9K6soQtC021mcg6C-Vj9EzSo014m8w)

\*Values are estimates from an emulated Pixel 2 XL running Android P.

1Utility process is 30 MB overhead with on average ~10 MB of content and 20 MB of bitmaps

  

Key Challenges in Developing the Technology
===========================================

  

Building this technology was an interesting and challenging experience. In particular, aggregating content from iframes, supporting subframe scrolling, and handling all the geometry is a complicated process.

However, the most interesting challenges came from performance!

  

### Capture

  

During capture of the page, saving the content is mostly straightforward; geometry from the DOM with CSS styling is easily converted into vector graphics which are small and easy to store.

  

Storing images from the page in this format is also straightforward, although high-resolution images are both large (0.1-10 MB) and slow to compress O(100 ms) + MBs of memory overhead. For this reason, images are usually stored without modification in their default encoding; however, sometimes particularly large images might get dropped.

  

Fonts are files describing how to draw each glyph they contain. These files are particularly large for fonts from languages with a large number of characters such as Chinese or which are composed of images such as emoji. A single English-language font is often around 100 kB in size, and fonts for emoji can easily be several MB. Pages often embed multiple fonts and these fonts are not saved on the local system, so we need to save them as part of the captured data. In early testing, we tried to store every font used in the page to ensure visual fidelity. However, some pages were as large as 100 MB when stored in this manner. This was simply unacceptable from a performance and storage point of view.

  

To overcome this challenge we turned to font subsetting. Subsetting strips every unused glyph from a font file. This reduces the data in a font to only what is required by the page. As such, that 100 MB page was reduced to just 400 kB, < 1% of the original size!

  

### Playback

  

Keeping playback performance within a reasonable bound was also a challenge. The vector graphics are rasterized into a bitmap for display; however, at 32-bits per pixel, on a modern phone screen just a single viewport of content is easily larger than 10 MB. To mitigate the memory overhead of these bitmaps, we generate them dynamically as a user scrolls. 

  

More details: the page’s contents are divided into tiles which are smaller than a single viewport. We generate bitmaps for all tiles currently in the viewport and those for a region around the viewport are prefetched to keep scrolling smooth. Experimentation with compressing the out-of-viewport bitmaps until they were in view showed potential memory savings from 10 MB down to just 100 kB. However, after gathering more performance data it was determined that the compression resulted in a significant increase in browser jankiness and for example [[FID](https://web.dev/fid/)] due to the additional CPU overhead. Consequently, this behavior was removed in favor of smaller tiles and more proactive discarding of out-of-viewport bitmaps.  

  

Conclusion
==========

  

Freeze Dried Tabs are a compelling alternative to screenshots particularly for transitional views or places where web content might not be immediately available and waiting for it to become available would be slow. They provide additional fidelity over a screenshot and allow some useful user behavior such as links and scrolling to behave similarly to how they would in a web page. 

  

Currently, Freeze Dried Tabs are being used in Chrome to provide a 20% perceptible speedup in cold startup on Android. We are exploring additional places where this technology might be used.

Posted by Calder Kitagawa, Chrome Software Engineer

  