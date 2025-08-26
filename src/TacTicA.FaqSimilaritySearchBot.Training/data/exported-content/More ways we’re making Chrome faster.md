URL:https://blog.chromium.org/2023/04/more-ways-were-making-chrome-faster.html
# More ways we’re making Chrome faster
- **Published**: 2023-04-13T10:29:00.000-07:00
  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiED83PUD3mCG2ea-hkNQas9v8urhqtDIM4VDrMKN7P7wIF4TJOtD3cdiJNwZsyKX119C3EVq9FXaFo025FTFiMAEo45g-yaRMIE-CcjvNCOl8a81lAnOLA3_tGrdhAaiLLzyS71XpUFP6A1OKsKBRzC13Jyna7SGR9NqKstpVu-RYa3msMxpVwesrrcA/w400-h166/The%20Fast%20+%20The%20Curious%20Logo_Revised_Header.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiED83PUD3mCG2ea-hkNQas9v8urhqtDIM4VDrMKN7P7wIF4TJOtD3cdiJNwZsyKX119C3EVq9FXaFo025FTFiMAEo45g-yaRMIE-CcjvNCOl8a81lAnOLA3_tGrdhAaiLLzyS71XpUFP6A1OKsKBRzC13Jyna7SGR9NqKstpVu-RYa3msMxpVwesrrcA/s4501/The%20Fast%20+%20The%20Curious%20Logo_Revised_Header.jpg)

From the beginning of Chrome, one of our [4 founding principles](https://www.chromium.org/developers/core-principles/) has been speed, and it remains a core principle that guides our work. Today’s [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post shares how recent technical improvements to Chrome have helped us reach a new performance milestone on the Speedometer browser benchmark across platforms. 

Speed is a critical factor in determining your experience while browsing the Web. The faster the browser, the more enjoyable your browsing experience will be. With the latest release of Chrome, we went deep under the hood of Chrome’s engine to look for every opportunity to increase the speed and efficiency, from improved caching to better memory management.

Improved HTML Parsing & optimizing specific features

We discovered some targeted optimizations for the highly used JS `Object.prototype.toString` and `Array.prototype.join`functions. We also implemented targeted improvements in CSS’s InterpolableColor.

`innerHTML` is a very common way of updating the DOM via JavaScript so we added specialized fast paths for parsing. To our happy surprise, it seems some of this work will also be benefitting WebKit, which will [include it in their engine](https://github.com/WebKit/WebKit/pull/9926) as well. Our goal is always to create a better web experience for all web users so we’re happy to see this work having expanded impact!

More efficient pointer compression & allocations in V8 & Oilpan

Pointer compression is used to save memory in both [V8](https://v8.dev/blog/pointer-compression) and [Oilpan](https://v8.dev/blog/oilpan-pointer-compression) (the garbage collector for DOM objects). We made optimizations to how we compress and decompress pointers, and we avoid compressing high-traffic fields. Given how frequently these operations are done, it has a wide spread impact on performance. We also moved frequently accessed objects like JavaScript’s `undefined` to the beginning of the memory bases, allowing them to be accessed using faster machine code.

The improved features and efficient pointer compression collectively gave us a 10% increase in Apple’s [Speedometer 2.1 browser benchmark](https://browserbench.org/Speedometer2.1/) over the course of three months.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjWNiHdyHhg-PihZ28UdVJ9k-f65mOJrN4-btXOftf-Y9JpAQwqxQhsp4IGjYq4wgU-4CUcTQB5iTHixrBsNHbxN2sG-BJIm6JyugUL_U42NyxVJyFpy0GHaqNOWlqeZfKoRzTK5urVMz1SxFexPpPFBDKon619A2arHK3dUsa2nLP_BrfKAiPTdf9_Ww/w640-h314/Chrome_Fast%20_%20Curious%20Speedometer%20Improvements_Graphic_3_1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjWNiHdyHhg-PihZ28UdVJ9k-f65mOJrN4-btXOftf-Y9JpAQwqxQhsp4IGjYq4wgU-4CUcTQB5iTHixrBsNHbxN2sG-BJIm6JyugUL_U42NyxVJyFpy0GHaqNOWlqeZfKoRzTK5urVMz1SxFexPpPFBDKon619A2arHK3dUsa2nLP_BrfKAiPTdf9_Ww/s2804/Chrome_Fast%20_%20Curious%20Speedometer%20Improvements_Graphic_3_1.png)

### Getting the Most out of High-End Mobile Devices

Chrome on Android has always been optimized for a small footprint, but the Android ecosystem is diverse and contains devices with varying levels of capabilities. To maximize the performance of Chrome on high-end devices, we are now targeting them with a version of Chrome that uses compiler flags tuned for speed rather than binary size.

For capable devices, these versions of Chrome run the Speedometer 2.1 benchmark 30% faster.

Posted by Thomas Nattestad, Senior Product Manager, and Andrew Grieve, Software Engineer

  