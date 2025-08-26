URL:https://blog.chromium.org/2023/04/how-webassembly-is-accelerating-new-web.html
# How WebAssembly is accelerating new web functionality
- **Published**: 2023-04-03T08:34:00.004-07:00
WebAssembly is fundamentally changing how new developer capabilities and functionality can be created on the web. In order to maintain browser interoperability, new web capabilities need to go through a rigorous standardization process and cross browser implementations. Decades of major investment has pushed the browser functionality to astonishing heights, but this process can take time and the web doesn’t need to have every capability built in. After years of investing in lower level capabilities that act as building blocks for higher level functionality, we are seeing a new dawn of expanded functionality at a dramatically expanded pace.

WebAssembly
-----------

[WebAssembly](https://webassembly.org/) is a portable bytecode format compiled from other languages to offer maximized performance. By leveraging WebAssembly, developers can take libraries and functionality from other platforms and performantly bring them to the web, without requiring any reimplementation. WebAssembly also offers advanced computation primitives like parallelizable [threads](https://chromestatus.com/feature/5724132452859904) and Single Instruction Multiple Data ([SIMD](https://chromestatus.com/feature/6533147810332672)) that enable it to maximize the performance from the CPU. 

  

With WebAssembly offering portability plus performant access to the CPU the web now has the necessary low level building blocks for a huge variety of new functionality to be built. All of this, of course, rests on the incredible foundation that is the full web platform—full of powerful capabilities, rendering methods, and much more. 

Real world examples
-------------------

We’ve dedicated [a whole blog post to showcasing just a small proportion of the new functionality being made available thanks to WebAssembly](https://web.dev/wasm-libraries/). 

  

Some of these examples are functionality that tried to go through the standard process but didn’t make it for a variety of reasons. Other examples are being actively standardized and implemented across browsers. 

* [FFMPEG on Wasm](https://github.com/ffmpegwasm/ffmpeg.wasm) is enabling web apps to work effectively with videos. [WebCodecs](https://developer.mozilla.org/en-US/docs/Web/API/WebCodecs_API) is a standardized alternative that offers similar encoding and decoding support, but it hasn’t been shipped across browsers yet.
* WebAssembly powers background blurring for VC calls in Google Meet and there is now [a dedicated standards proposal](https://github.com/riju/backgroundBlur/blob/main/explainer.md) for this functionality
* Web SQL was standardized and even shipped in Chrome for many years but never adopted sufficiently across browsers. [SQLite on Wasm](https://developer.chrome.com/blog/sqlite-wasm-in-the-browser-backed-by-the-origin-private-file-system/) will replace Web SQL which will [eventually be removed from Chrome](https://developer.chrome.com/blog/deprecating-web-sql/).
* [Universal Scene Descriptor (USD) is shipping in Safari](https://webkit.org/blog/8421/viewing-augmented-reality-assets-in-safari-for-ios/) but isn’t available in other browsers.

Advantages of this new development paradigm
-------------------------------------------

### Faster iteration speed

Because functionality doesn’t have to go through standards and get approval before shipping, iteration cycles go from taking years down to days or even hours. Approaches like Origin Trials help enable more experimentation but still require weeks or months for iterations. When you change the iteration rate of something, you fundamentally change the thing itself. 

  

Some fields like machine learning are advancing so fast that it is incredibly hard for standards-based approaches to keep up. By the time one design has gone through standardization and cross browser implementation, the field has moved on to something new which would have to go through the whole process again. 

  

That being said, standardization is still essential for many things (see disadvantages section below) and when feasible, standardizing should absolutely be attempted. 

### Immediate support across browsers

Because wasm is  supported across browsers, the functionality built on top of it will work across all browsers immediately as well. Interop and cross browser implementation of features is [the biggest pain point for developers](https://insights.developer.mozilla.org/reports/mdn-web-developer-needs-assessment-2020.html#needs-assessment-ranking-of-all-needs) and by moving functionality to these lower level primitives, we’ll remove much of this concern. 

### Improved security

Because this functionality is built on top of incredibly hardened security sandboxes, there is substantially improved security compared to natively implemented APIs. Flash for example was removed from the web in large part because it was just too difficult to harden the complex plugin sufficiently, but now it can be [run in WebAssembly](https://medium.com/leaningtech/preserving-flash-content-with-webassembly-done-right-eb6838b7e36f), eliminating almost all security concerns. 

Disadvantages and limitations
-----------------------------

As with any new solution to complex problems, WebAssembly is not without disadvantages and limitations. Some of these are inherent and some have some promising solutions. 

### This won’t replace JavaScript for most web development

WebAssembly won’t replace JavaScript or make it obsolete, but rather extend its capabilities. 

  

WebAssembly in the browser is still entirely dependent on JavaScript and needs to interface through JavaScript to access other web functionality. Libraries and new functionality enabled by WebAssembly will be utilized through JavaScript APIs. While there are some proposals that could enable wasm to wasm module communication and direct interfacing with Web APIs, this is still in the early stages of development. 

### Bundle size of pages

By moving more logic and functionality into userland, the size of pages will increase as well. This is a large problem as lower bundle size is [the most important thing for a good user experience](https://v8.dev/blog/cost-of-javascript-2019). As a result, developers should think carefully before ballooning their bundle size with this functionality, and it may be more relevant for larger web apps than smaller ecommerce or blog sites. This has long been an issue for JavaScript-heavy frameworks and is something where more solutions could be possible to improve the situation. 

  

Another potential mitigation here is to look at the popular functionality being shipped in userland and use that as an input about what functionality should be standardized to ship with the browser itself. By being battle-hardened in userland, browsers will have higher confidence and validation on what they should ship, dramatically simplifying the standards and implementation work. WebCodecs replacing wasm compiled FFMPEG or [the handwriting recognition API](https://github.com/WICG/handwriting-recognition/blob/main/explainer.md) to replace [the wasm compiled option](https://github.com/gugray/hanzi_lookup) are perfect examples of this. 

### Device capability access

WebAssembly and other primitives are largely computation mechanisms and don't give any kind of root system access to the OS or device itself. Functionality like hardware access (USB or Bluetooth), screen or window management, input controls, file system, clipboard, and much more still require platform level APIs to access. Chromium’s Fugu project is specifically aiming to enable all of these cases for Chromium-based browsers, but implementations across other browsers would still be needed here. 

Conclusion
----------

WebAssembly is already enabling new functionality in the browser, but more than that it represents a fundamentally new approach to how functionality gets developed. The best way to improve a thing is to improve how you improve it and then basking in second order growth. As with any new paradigm there are advantages and disadvantages, but overall this is a powerful new approach for browsers and developers everywhere. I can’t wait to see what we all build together with it.

By Thomas Nattestad, Product Manager - WebAssembly