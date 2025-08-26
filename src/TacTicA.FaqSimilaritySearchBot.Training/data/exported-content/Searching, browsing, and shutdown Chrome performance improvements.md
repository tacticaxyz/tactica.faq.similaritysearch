URL:https://blog.chromium.org/2021/11/searching-browsing-shutdown-chrome-performance-improvements.html
# Searching, browsing, and shutdown Chrome performance improvements
- **Published**: 2021-11-01T10:04:00.010-07:00
*[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhEla8ATT6YFRR-WRWz6rYikJTRguAKKB5LKefpCd3XIRnfS2JTtRnjFDyJfjsqj890eM5N0K4r7EDsju4WJqSCE8U1zCK4d2ScapEh9KR6Z9hCEFgOaL5yH6vYefoEgTxR7P0coztCpt4R/w702-h292/image1.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhEla8ATT6YFRR-WRWz6rYikJTRguAKKB5LKefpCd3XIRnfS2JTtRnjFDyJfjsqj890eM5N0K4r7EDsju4WJqSCE8U1zCK4d2ScapEh9KR6Z9hCEFgOaL5yH6vYefoEgTxR7P0coztCpt4R/s1999/image1.jpg)

Chrome has long-term investments in performance improvement across many projects and we are pleased to share improvements across speed, memory, and unexpected hangs in today’s [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) series post. One in six searches is now as fast as a blink of an eye, Chrome OS browsing now uses up to 20% less memory [thanks to our PartitionAlloc investment](https://blog.chromium.org/2021/04/efficient-and-safe-allocations-everywhere.html), and we’ve resolved some thorny Chrome OS and Windows shutdown experiences.*

Omnibox
=======

You’ve probably noticed that potential queries are suggested to you as you type when you’re searching the web using Chrome’s omnibox (as long as the “Autocomplete searches and URLs” feature is turned on in Chrome settings.) This makes searching for information faster and easier, as you don’t have to type in the entire search query -- once you’ve entered enough text for the suggestion to be the one you want, you can quickly select it.   
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhmBrL8llGFT3x4B9VUFCYUnwfs1C1Ul8NUYTDlrgPpl5l2pJ-5l_ifMq8CIBg94GpnZWf-RvYb96x4gouOgIHt1qTADzuV-zmFSUul3FRIiqOPvReH-SCgzc9jJA0-iJZ2Lak-DLlugeUm/w654-h439/image2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhmBrL8llGFT3x4B9VUFCYUnwfs1C1Ul8NUYTDlrgPpl5l2pJ-5l_ifMq8CIBg94GpnZWf-RvYb96x4gouOgIHt1qTADzuV-zmFSUul3FRIiqOPvReH-SCgzc9jJA0-iJZ2Lak-DLlugeUm/s1999/image2.png)  
  
  
Searching in Chrome is now even faster, as search results are prefetched if a suggested query is very likely to be selected. This means that you see the search results more quickly, as they’ve been fetched from the web server before you even select the query. In fact, our experiments found that search results are now 4X more likely to be shown within 500 ms!  
  
Currently, this only happens if Google Search is your default search engine. However, other search providers can trigger this feature by adding information to the query suggestions sent from their servers to Chrome, as described in this [article](https://sites.google.com/a/chromium.org/dev/developers/design-documents/omnibox-prefetch-for-default-search-engines).  

Chrome OS PartitionAlloc
========================

Chrome’s new memory allocator, [PartitionAlloc](https://blog.chromium.org/2021/04/efficient-and-safe-allocations-everywhere.html), rolled out on Android and Windows in M89, bringing improved memory usage [up to 22% savings] and performance [up to 9% faster responsiveness]. Since then, we have also implemented PartitionAlloc on Linux in M92 and Chrome OS in M93. We are now pleased to announce that M93 field data from Chrome OS shows a total memory footprint reduction of 15% in addition to a 20% browser process memory reduction, improving the Chromebook browsing experience for both single and multi-tabs.  
  

Resolving the #1 shutdown hang
==============================

Often software engineers add a cache to a system with the goal of improving performance. But a frequent corollary of caching is that the cache may introduce other problems (code complexity, stability, memory consumption, data consistency), and may even make performance worse. In this case, a local cache was added years ago to Chrome's history system with the goal of making startup faster. The premise at the time, which seemed to bear out in lab testing, was that caching Chrome's internal in-memory history index would be faster than reindexing the history at each startup.  
  
Thanks to our continuing systematic investigation into real-world performance using crash data in conjunction with anonymized performance metrics, we uncovered that not only did this cache add code complexity and unnecessary memory usage, but it was also our top contributor to shutdown hangs in the browser. This is because on some OSes, background priority threads can be starved of I/O indefinitely while there is any other I/O happening elsewhere on the system. Moreover, the performance benefits to our users were minimal, based on analysis of field data. We've now removed the cache and resolved our top shutdown hang. This was a great illustration of the principle that caching is not always the answer!  
  
Stay tuned for many more performance improvements to come!  
  
Posted by Yana Yushkina, Product Manager, Chrome Browser  
  
*Data source for all statistics: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.*

  