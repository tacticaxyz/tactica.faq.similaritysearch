URL:https://blog.chromium.org/2020/04/chrome-83-beta-cross-site-scripting.html
# Chrome 83 Beta: Cross-site Scripting Protection, Improved Form Controls, and Safe Cross-origin Resource Sharing
- **Published**: 2020-04-17T07:41:00.002-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 83 is beta as of April 16, 2020.  

Trusted Types for DOM Manipulation
==================================

DOM-based cross-site scripting (DOM XSS) is one of the most common web security vulnerabilities. It can even be introduced to your application unintentionally. Trusted types is a new technology that helps you write and maintain applications that are free of DOM XSS vulnerabilities by default. It does this by securing dangerous APIs.   
  
Consider a property like `Element.innerHTML`. This property can open your site to harmful HTML manipulation. Trusted types would cause your script to throw an error if this property were used. To do this, set a new content security policy. For example:  
  
  

```
Content-Security-Policy: require-trusted-types-for 'script';
report-uri //my-csp-endpoint.example
```

  
  
For more information on trusted types, see [Prevent DOM-based cross-site scripting vulnerabilities with Trusted Types](https://web.dev/trusted-types/).  

Improved Form Controls
======================

HTML form controls provide the backbone for much of the web's interactivity. They're easy for developers to use, have built-in accessibility, and are familiar to our users. Unfortunately, the styling of form controls is wildly inconsistent. The earliest form controls matched the operating system on which they displayed, and later controls followed whatever design style was popular at the time they were created. This variation forced developers to spend extra time in development and to ship extra code.   
  
Over the last year, Chrome and Edge have collaborated to improve the appearance and function of HTML form controls. This work included making the focused states of controls and other interactive elements easier to perceive. The images below show the old and new versions of some controls in Chrome.   
  
The old versions:  
![](https://lh3.googleusercontent.com/Yrw-54mhu6WWPdl5pI9dEmZt2rHeo7YQDmRD9mvGfUHIFwtszRY_Lfa4KDdypM7fbxRDkceoHsXAbPhw4mz9dCZtSPDnJJDdaF2YWdZ05NNbHXDD98NLtUJ4W3tkYTT9SSOQO3M8)  
  
The new versions:  
![](https://lh6.googleusercontent.com/WLjG9k0ctIUOfJai0QqFBqxXy5TdoS06q6_mcwJYzqcu5TATgTjAkzEKpf7m8of5ymdwR9QKI1SSFOs31ubDTr5M5pcN1T7TWpFn2N766VG31dk0JibAMMlt-ChNNgFg1f6IfAqK)  
The new form controls have already shipped in Microsoft Edge and are now available in Chrome 83. For more information see Microsoft's article [Improving form controls in Microsoft Edge and Chromium](https://blogs.windows.com/msedgedev/2019/10/15/form-controls-microsoft-edge-chromium/) or our post on the Chromium blog [Updates to Form Controls and Focus](https://blog.chromium.org/2020/03/updates-to-form-controls-and-focus.html).  
  

New Cross-Origin Policies
=========================

Some web APIs increase the risk of side-channel attacks like Spectre. To mitigate that risk, browsers offer an opt-in-based isolated environment called cross-origin isolated. This is done through two new HTTP headers: `Cross-Origin-Embedder-Policy`  
and `Cross-Origin-Opener-Policy`. With these headers, web pages can safely use privileged features including:  

* `Performance.measureMemory()`
* JS Self-Profiling API

The cross-origin isolated state also prevents modifications of `document.domain`.   
  
  
For more information, see [Making your website "cross-origin isolated" using COOP and COEP](https://web.dev/coop-coep/).  

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).  
  

Native File System
------------------

The Native File System API is in a new origin trial, scheduled to run from Chrome 83 to Chrome 85. This API enables developers to build web apps that interact with files on the user's local device such as IDEs, photo and video editors, text editors, and more. After a user grants access, the API lets apps read or save changes directly to files and folders on the user's device. It does this by invoking the platform's own open and save dialog boxes. For more information, see [The Native File System API: Simplifying access to local files](https://web.dev/native-file-system/).  
  

Performance.measureMemory()
---------------------------

The new `Performance.measureMemory()` function estimates the memory usage of a web page to measure the memory usage of a web app or page in production. The use cases include:  

* Analysis of correlation between memory usage and user metrics
* Detection of memory regressions
* Evaluation of feature launches in A/B tests
* Memory optimization.

Currently web developers resort to the non-standard performance.memory API that is used in 20% of page loads. For more information, see [Monitor your web page's total memory usage with performance.measureMemory()](https://web.dev/monitor-total-page-memory-usage/).  
  

Prioritized Scheduler.postTask()
--------------------------------

The `Scheduler.postTask()` method allows developers to schedule tasks (javascript callbacks) with a native browser scheduler at three levels of priority: `user-blocking`, `user-visible`, and `background`. It also exposes a `TaskController` object, which can be used to dynamically cancel tasks and change their priority.  
  

WebRTC Insertable Streams
-------------------------

The [WebRTC Insertable Streams API](https://github.com/alvestrand/webrtc-media-streams/blob/master/explainer.md) lets applications provide custom data processing in the encoding and decoding of a WebRTC `MediaStreamTrack` One use case for this is the end-to-end encryption of the data transferred between peer connections via an intermediate server. To use insertable streams add one of the new parameters to the `RTCPeerConnection`interface. Other WebRTC updates in the release are listed in the next section.  

Other features in this release
==============================

ARIA Annotations
----------------

[New ARIA annotations](https://www.chromestatus.com/feature/4666935918723072) support screen reader accessibility for comments, suggestions, and text highlights with semantic meanings (similar to `<mark>`). Additionally, related information can now be tied semantically to an element allowing descriptions, definitions, footnotes and comments to be tied to another element.  
Annotations were not previously possible without resorting to live region hacks, which are not as reliable as semantics, and do not work well with braille displays. As a result, screen reader users have non-optimal support for collaboration features of online word processors.  
  

'auto' keyword for '-webkit-appearance' CSS property
----------------------------------------------------

The `-webkit-appearance` CSS property has [a new `auto` keyword](https://www.chromestatus.com/feature/5913213940006912), which indicates the default appearance of the target element. This is a step on the way towards replacing the non-standard `-webkit-appearance` property with a future fully standardized `appearance` property.   
  

Barcode Detection API
---------------------

Chrome now supports the Barcode Detection API, a subset of the Shape Detection API which provides the ability to detect and decode barcodes in an image provided by a script. The image may come from any type of image buffer source such as an `<image>`, `<video>` or `<canvas>` tag. Previously supporting barcode detection on a web page required inclusion of a large third-party library. This API is only available on devices with [Google Play Services](https://play.google.com/store/apps/details?id=com.google.android.gms) installed and is not available on uncertified devices. For information about the Barcode Detection API as well as the other Shape Detection APIs, see [The Shape Detection API: a picture is worth a thousand words, faces, and barcodes](https://web.dev/shape-detection/).  
  

CSS Color Adjust: color-scheme meta tag
---------------------------------------

Many operating systems now have a "dark mode" preference. Some browsers already offer an option to transform web pages into a dark theme. The `prefers-color-scheme` media query lets authors support their own dark theme so they have full control over experiences they build. The meta tag lets a site explicitly opt-in to fully supporting a dark theme so that the browser loads a different user agent sheet and not ever apply transformations. For more information, read [Improved dark mode default styling with the color-scheme CSS property and the corresponding meta tag](https://web.dev/color-scheme/).  
  

display:inline-grid/grid/inline-flex/flex for <button>
------------------------------------------------------

The `display` keywords `inline-grid`, `grid`, `inline-flex`, and `flex` [now function with the `<button>` element](https://www.chromestatus.com/feature/5213452823953408) when the align property is applied. ([Demo](https://codepen.io/jpmedley/pen/MWwmoQE))  
  

ES Modules for shared workers ('module' type option)
----------------------------------------------------

JavaScript now supports modules in shared workers. Setting `module` type by the constructor's type attribute, worker scripts are loaded as ES modules and the import statement is available in worker contexts. With this feature, web developers can more easily write programs in a composable way and share them among a page and workers. For more information, see [What about shared workers](https://web.dev/module-workers/#what-about-shared-workers) in Threading the web with module workers.  
  

Improvements to font-display: optional
--------------------------------------

A few changes have been made to the way `font-display` works on Chrome.  

* Setting `font-display` to `optional` no longer causes relayout
* Web font preloading is allowed to slightly block rendering (for all `font-display` values), so that if the font loads fast enough, we don't need to render with fallback.

Consequently, when `font-display: optional` and preloading are used together, you'll never see layout shifting from font swapping. For more information, see [Prevent layout shifting and flashes of invisibile text (FOIT) by preloading optional fonts](https://web.dev/preload-optional-fonts/).  
  

IndexedDB relaxed durability transactions
-----------------------------------------

`IDBDatabase.transaction()` now accepts an optional `durability` argument  
to control flushing of data to storage. This allows developers to explicitly trade off durability for performance. Previously after writing an IndexedDB transaction, Firefox did not flush to disk but Chrome did. This provided increased durability by guaranteeing that data is written to the device's disk rather than merely to an intermediate OS cache. Unfortunately, this comes with a significant performance cost.
  
Valid options are `"default"`, `"strict"`, and `"relaxed"`. The `"default"` option uses whatever behavior is provided by the user agent and is currently the default. An example is shown below. The current value may be read using `IDBTransaction.durability`.  
  

```
const iDBTransaction = database.transaction(
  [ "storeName" ],
  "readwrite",
  {
    durability: "relaxed"
  }
);
```

  
  

Out-Of-Renderer Cross-Origin Resource Sharing
---------------------------------------------

Out-Of-Renderer Cross-Origin Resource Sharing (OOR-CORS) is a new CORS implementation that inspects network accesses. Chrome's previous CORS implementation was only available to Blink core parts, XHR and Fetch APIs, while a simplified implementation was used in other parts of the application. HTTP requests made by some internal modules could not be inspected for CORS at all. The new implementation addresses these shortcomings.  
  

Reversed range for <input type=time>
------------------------------------

Chrome [now supports reversed ranges for `<input>` elements](https://www.chromestatus.com/feature/5347108783652864) whose `type` is `time`, allowing developers to express time inputs that cross midnight. A reversed range is one where the maximum is less than the minimum. In this state, the input allows values that are less than the minimum or greater than the maximum, but not between them. This functionality has been in the specification for many years, but has not yet been implemented in Chrome.   
  

Support "JIS-B5" and "JIS-B4" @page
-----------------------------------

Chrome [now supports two page sizes for the @page rule](https://www.chromestatus.com/feature/5112328557166592), both listed in the CSS Paged Media Module Level 3 spec.  

* "JIS-B5": 182mm wide by 257mm high
* "JIS-B4": 257mm wide by 364mm high

This feature completes Chrome's implementation of this section of the standard.  
  

@supports selector() feature query function
-------------------------------------------

The new `@supports` function provides [feature detection for CSS selectors](https://www.chromestatus.com/feature/5555643303854080). Web authors can use this feature to query whether the UA supports the selector before they actually try to apply the specified style rules matching the selector. For example:  
  

```
@supports selector(::before) {
  div { background: green };
}
```

WebRTC
------

Chrome has added the following web RTC features in addition to the one already mention under Origin Trials.  

### RTCPeerConnection.canTrickleIceCandidates

The `canTrickleIceCandidates` boolean property indicates whether a remote peer is capable of handling trickle candidates. It exposes information from the SDP session description.  
  

### RTCRtpEncodingParameters.maxFramerate

[This encoding parameter](https://www.chromestatus.com/feature/6216116758118400) allows developers to limit the framerate on a video layer before sending. Use `RTCRtpSender.setParameters()` to set the new framerate, which takes effect after the current picture is complete. read it back using `RTCRtpEncodingParameters.maxFramerate`. Setting `maxFramerate` to 0 freezes the video on the next frame.  
  

### RTCRtpSendParameters.degradationPreference

A new attribute for `RTCRtpSendParameters` called `degradationPreference` allows developers to control how quality degrades when constraints such as bandwidth or CPU prevent encoding at the configured frame rate and resolution. For example, on a screen share app, users will probably prefer screen legibility over animations. On a video conference users likely prefer a smooth frame rate over a higher resolution. Valid values for `degradationPreference` are `"maintain-framerate"`, `"maintain-resolution"`, and `"balanced"`.  
  

WebXR DOM Overlay
-----------------

DOM overlay is a feature for immersive AR on handheld devices that lets two-dimensional page content be shown as an interactive transparent layer on top of the WebXR content and camera image. With this feature, developers can use the DOM to create user interfaces for WebXR experiences. For VR, inline sessions are by definition within the DOM. For AR, though, there is no inline mode making this particularly important for certain use cases. To try the feature use one of the [two](https://klausw.github.io/a-frame-car-sample/index.html) [samples](https://klausw.github.io/three.js/examples/webvr_lorenzattractor.html) in Chrome 83. This feature is currently only available on ARCore-based handheld devices.  
  

JavaScript
==========

This version of Chrome incorporates version 8.3 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.  

fractionalSecondDigits option for Intl.DateTimeFormat
-----------------------------------------------------

Chrome 83 [adds the `fractionalSecondDigits` property](https://www.chromestatus.com/feature/5704965743968256) to the `Intl.DateTimeFormat` object to control the format of fractions of a second. The Date object in ECMAScript stores time information with millisecond precision, which some web developers need to output. The value of this property is an integer between 0 and 3 to represent how many digits the `DateTimeFormat` should output after the decimal mark.  

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).  

Disallow Downloads in Sandboxed iframes
---------------------------------------

Chrome now [prevents downloads in sandboxed iframes](https://www.chromestatus.com/feature/5706745674465280), though this restriction can be lifted via an `'allow-downloads'` keyword in the sandbox attribute list. This allows content providers to restrict malicious or abusive downloads. Downloads can bring security vulnerabilities to a system. Even though additional security checks are done in Chrome and the operating system, we feel blocking downloads in sandboxed iframes also fits the purpose of the sandbox.  
  
Posted by Joe Medley