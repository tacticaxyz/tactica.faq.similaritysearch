URL:https://blog.chromium.org/2023/02/do-more-with-chrome-on-single-charge-on.html
# Do more with Chrome on a single charge on MacBooks
- **Published**: 2023-02-28T08:59:00.004-08:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi1scoAQql2pxtQ4ec-UX4DT1dNsy4v0H1rvtTboGWGaEOfMu3LwiJPK2eXS0qcEFrVTKgn2CmXMQr8oNBBCJkTHx90HJrMyJ2IzKZYBqipjIsn596-NerQyJGuFoqjV59cc4ZaWF5h9e_H6Q1W57hA6QAA_mEtKrRBVFppBm-ygv3RbKldvGxEg0XY1Q/w400-h166/Fast%20Curious%20logo.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi1scoAQql2pxtQ4ec-UX4DT1dNsy4v0H1rvtTboGWGaEOfMu3LwiJPK2eXS0qcEFrVTKgn2CmXMQr8oNBBCJkTHx90HJrMyJ2IzKZYBqipjIsn596-NerQyJGuFoqjV59cc4ZaWF5h9e_H6Q1W57hA6QAA_mEtKrRBVFppBm-ygv3RbKldvGxEg0XY1Q/s561/Fast%20Curious%20logo.png)

  

From the beginning, we designed Chrome to be efficient. Being efficient is not just about loading pages as fast as possible, it’s also about doing it with the least amount of resources possible. Today’s [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post explores how we improved Chrome to maximize battery life on Mac, so you can enjoy browsing and watching videos longer than ever before.

With the latest release of Chrome, we’ve made it possible to do more on your MacBook on a single charge thanks to a ton of optimizations under the hood. In our testing, we found that you can browse for 17 hours or watch YouTube for 18 hours on a MacBook Pro (13", M2, 2022). And with Chrome’s [Energy Saver](https://blog.google/products/chrome/new-chrome-features-to-save-battery-and-make-browsing-smoother/) mode enabled, you can browse an additional 30 minutes on battery(1). Of course, we care deeply about all our users, not just those with the latest hardware. That’s why you’ll also see performance gains on older models as well.

Here’s a closer look at some of the changes we made:

Fine tuning iframes

We realized that many iframes live just a few seconds. As a result, we fine-tuned the garbage collection and memory compression heuristics for recently created iframes. This results in less energy consumed to reduce short-term memory usage (without impact on long-term memory usage).

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiaYJDCNGWEhoYNvgzyqaeDfz_Y587deJ_xw9WJYmm6kRl3_5IXg3SkYbIwq2zknvDGltfPjY3khuodiBZWHCOJQbH3LiHM0Yk_5twgRwpGz02GRrJ8hGJ6NRULde45CkPZ1xxPZ3X0A_gtfv4GzvXFCoVk6ehL89LOGoOVykkf9drGXT9O4xkKd-Xw4g/w640-h310/Fast%20&%20Curious_Battery%20Life%20Blog%20Assets_V2_3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiaYJDCNGWEhoYNvgzyqaeDfz_Y587deJ_xw9WJYmm6kRl3_5IXg3SkYbIwq2zknvDGltfPjY3khuodiBZWHCOJQbH3LiHM0Yk_5twgRwpGz02GRrJ8hGJ6NRULde45CkPZ1xxPZ3X0A_gtfv4GzvXFCoVk6ehL89LOGoOVykkf9drGXT9O4xkKd-Xw4g/s5771/Fast%20&%20Curious_Battery%20Life%20Blog%20Assets_V2_3.png)

Tweaking timers

Javascript timers were introduced at the beginning of the Web’s history. Since then, Web developers have access to more efficient APIs to achieve the same (or better!) results. But Javascript timers still drive a large proportion of a Web page’s power consumption. As a result, we tweaked the way they fire in Chrome to let the CPU wake up less often.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg8wQI11UDCm3gCILBibO9P2X9652WkLbEWCxYXlQtGpYx0ATH_ScprIGbOl4QM55jfUgUrcfjla9TieV6OwLMbX1gRu82N2qHEjYV33PMxOMYaxH7xEOdNlTsOcgeXbIGvYx3tSye9GncgyGzuVdqCfEEPcHuqn0qPl5wO01a7nQ3XD3NRhFK0oDUYTQ/w640-h310/Fast%20&%20Curious_Battery%20Life%20Blog%20Assets_V2_1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg8wQI11UDCm3gCILBibO9P2X9652WkLbEWCxYXlQtGpYx0ATH_ScprIGbOl4QM55jfUgUrcfjla9TieV6OwLMbX1gRu82N2qHEjYV33PMxOMYaxH7xEOdNlTsOcgeXbIGvYx3tSye9GncgyGzuVdqCfEEPcHuqn0qPl5wO01a7nQ3XD3NRhFK0oDUYTQ/s5771/Fast%20&%20Curious_Battery%20Life%20Blog%20Assets_V2_1.png)

Similarly, we identified opportunities to cancel internal timers when they’re no longer needed, reducing the number of times that the CPU is woken up.

Streamlining data structures

We identified data structures in which there were frequent accesses with the same key and optimized their access pattern.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgtRHz8G4vD-oJWZBkUMKGpXiGvOi4rtC_9FL2zM_FHz-E-ACg44WJCl3IRMsaML-77kUPeGDPfrcPaVDr1zaQXhDi1gCYYlE19786pCIMjMd35inQZMTgQYZqR_QCdBPPoTA62D5z4ClJWaneDR-MwHxtUArrKNDRfz1JuhShptQU-ThQG7lZqQ93GqA/w640-h368/Fast%20&%20Curious_Battery%20Life%20Blog%20Assets_V2_2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgtRHz8G4vD-oJWZBkUMKGpXiGvOi4rtC_9FL2zM_FHz-E-ACg44WJCl3IRMsaML-77kUPeGDPfrcPaVDr1zaQXhDi1gCYYlE19786pCIMjMd35inQZMTgQYZqR_QCdBPPoTA62D5z4ClJWaneDR-MwHxtUArrKNDRfz1JuhShptQU-ThQG7lZqQ93GqA/s5771/Fast%20&%20Curious_Battery%20Life%20Blog%20Assets_V2_2.png)

Eliminating unnecessary redraws

We navigated on real-world sites with a bot and identified Document Object Model (DOM) change patterns that don’t affect pixels on the screen. We modified Chrome to detect those early and bypass the unnecessary style, layout, paint, raster and gpu steps. We implemented similar optimizations for changes to the Chrome UI.

There’s always more work to be done. With the [open-source benchmark suite](https://source.chromium.org/chromium/chromium/src/+/main:tools/mac/power), we’ll be able to tap the broader community of devs to help us to improve Chrome’s power consumption in 2023 and beyond.

Posted by François Doray, Software Developer, Chrome

\_\_\_  
1 Testing conducted in February 2023 using Chrome 110.0.5481.100 on a MacBook Pro (13”, M2, 2022 with 8 GB RAM running MacOS Ventura 13.2.1) and measured using our [open-source benchmark suite](https://source.chromium.org/chromium/chromium/src/+/main:tools/mac/power).