URL:https://blog.chromium.org/2024/06/how-chrome-achieved-highest-score-ever.html
# How Chrome achieved the highest score ever on Speedometer 3
- **Published**: 2024-06-06T09:15:00.000-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjTQhp2W8dIjin6cG9FZFPANCCxZkFh9n1Nkn60O8XvgU4XVY_rq3ChNITmiJ1VG16BHnsxVijTYMc06SNA0VHjqfee6dqZLgfjazWxh7p1b3i-pj4thXDt3QyK3vWSpRgrTHaxiSFfPvc1YRDtdcBOorm85i53-FebJDWUXrJA4a_oMAYNbxjTFE0PPbJc/s16000/Fast%20Curious_image.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjTQhp2W8dIjin6cG9FZFPANCCxZkFh9n1Nkn60O8XvgU4XVY_rq3ChNITmiJ1VG16BHnsxVijTYMc06SNA0VHjqfee6dqZLgfjazWxh7p1b3i-pj4thXDt3QyK3vWSpRgrTHaxiSFfPvc1YRDtdcBOorm85i53-FebJDWUXrJA4a_oMAYNbxjTFE0PPbJc/s400/Fast%20Curious_image.png)

  

*Today’s The Fast and the Curious post explores how Chrome achieved the highest score on the new Speedometer 3.0, an upgraded browser benchmarking tool to optimize the performance of Web applications. Try out [Chrome](https://www.google.com/chrome/) today!*

[Speedometer 3.0](https://browserbench.org/Speedometer3.0/) is a recently published benchmark for [measuring browser performance](https://webkit.org/blog/15131/speedometer-3-0-the-best-way-yet-to-measure-browser-performance/) that was created as an industry collaboration between companies like Google, Apple, Mozilla, Intel, and Microsoft. This benchmark helped us identify areas in which we could optimize Chrome to deliver a faster browser experience to all our users.

Here’s a closer look at how we further optimized Chrome to achieve the highest score ever Speedometer 3, by carefully tracking its recent performance over time as the updated benchmark was being developed. Since the inception of Speedometer 3 in May 2022, we've driven a 72% increase in Chrome’s Speedometer score - translating into performance gains for our users:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjhWV2DrIDMUUKPwXhOGaWNB1Md15huKND9UdpxiFs8taTD8PvDbGcbQnqgzibx8A9Q0SShTLxW0AyjGoJnNwIW-OEPfo5NN8vy0KvcS6vj7PnscI2-FE7_TZ19aTsjIRK5iYohctES6JgahB5W72NJVDkGJ_LhhyT_f9dcGKhVD9FsupDKI_bGwm4WtHw-/s16000/Fast%20&%20Curious%20In-Line%20Graph%20_%20Speedometer%20improvements_HighRes-04.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjhWV2DrIDMUUKPwXhOGaWNB1Md15huKND9UdpxiFs8taTD8PvDbGcbQnqgzibx8A9Q0SShTLxW0AyjGoJnNwIW-OEPfo5NN8vy0KvcS6vj7PnscI2-FE7_TZ19aTsjIRK5iYohctES6JgahB5W72NJVDkGJ_LhhyT_f9dcGKhVD9FsupDKI_bGwm4WtHw-/s8333/Fast%20&%20Curious%20In-Line%20Graph%20_%20Speedometer%20improvements_HighRes-04.png)

  

### Optimizing workloads

By looking at the workloads in Speedometer and in which functions Chrome was spending the most time, we were able to make targeted optimizations to those functions that each drove an increase in Chrome’s score. For example, the SpaceSplitString function is used heavily to turn space-separated strings such as those in “class=’foo bar’ ” into a list representation. In this function we removed some unnecessary bound checks. When we detect that there are duplicated stylesheets, we dedupe them and reference a single stylesheet instance. We made an optimization to reduce the cost of drawing paths and arcs by tuning memory allocations. When creating form editors we detected some unnecessary processing that occurs when form elements are created. Within querySelector, we were able to detect what selector was commonly used and create a hot-path for that.

We [previously shared](https://blog.chromium.org/2023/04/more-ways-were-making-chrome-faster.html) how we optimized innerHTML using specialized fast paths for parsing, an implementation that also [made its way into WebKit](https://github.com/WebKit/WebKit/pull/9926). Some workloads in Speedometer 3 use [DOMParser](https://developer.mozilla.org/en-US/docs/Web/API/DOMParser) so we extended the same optimization for another 1% gain.

We worked with the Harfbuzz maintainer to also optimize how Chrome renders [AAT](https://en.wikipedia.org/wiki/Apple_Advanced_Typography#AAT_Layout) fonts such as those used by Apple Mac OS system fonts. Text starts as a processed stream of unicode characters that is then transformed into a glyph stream that is then run through a state machine defined in the AAT font. The optimization allows us to determine more quickly whether glyphs actually participate in the rules for the state machine, leading to speed-ups when processing text using AAT.

### Picking the right code to focus on

An important strategy for achieving high performance is tiering up code, which is picking the right code to further optimize within the engine. Intel contributed profile guided tiering to V8 that remembers tiering decisions from the past such that if a function was stably tiered up in the past, we eagerly tier it up on future runs.

### Improving garbage collection

Another area of changes that drove around 3% progression on Speedometer 3 was improvements around garbage collection. V8’s garbage collector has a [long history of making use of renderer idle time](https://queue.acm.org/detail.cfm?id=2977741) to avoid interfering with actual application code. The recent changes follow this spirit by extending existing mechanisms to prefer garbage collection in idle time on otherwise very active renderers where possible. Specifically, DOM finalization code that is run on reclaiming objects is now also run in idle time. Previously, such operations would compete with regular application code over CPU resources. In addition, V8 now supports a much more compact layout for objects that wrap DOM elements, i.e., all objects that are exposed to JavaScript frameworks. The compact layout reduces memory pressure and results in less time spent on garbage collection.

*Posted by Thomas Nattestad, Chrome Product Manager*