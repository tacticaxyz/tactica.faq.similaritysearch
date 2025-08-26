URL:https://blog.chromium.org/2020/12/chrome-88-digital-goods-lighting.html
# Chrome 88: Digital Goods, Lighting Estimation in Augmented Reality, and More
- **Published**: 2020-12-03T11:57:00.018-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D88). Chrome 88 is beta as of December 3, 2020.

Digital Goods API
=================

Chrome now supports an API for [querying and managing digital products](https://www.chromestatus.com/feature/5339955595313152) to facilitate in-app purchases from web applications. This is used with the [Payment Request API](https://developer.mozilla.org/en-US/docs/Web/API/Payment_Request_API), which is used to make the actual purchases. The API would be linked to a digital distribution service connected via the user agent. In Chromium, this is specifically a web API wrapper around the [Android Play Billing API](https://developer.android.com/google/play/billing/integrate).

This is needed so that web apps in the Play Store can accept purchases for digital goods. (Play policies prevent them from accepting payment via any other method.) Without this, websites that sell digital goods are not installable through the Play Store.

In Chrome 88, this is available for Android in an origin trial. For a list of other origin trials starting in this release, see below.

Origin Trials
=============

This version of Chrome introduces the origin trial described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).

New Origin Trials
-----------------

### WebXR: AR Lighting Estimation

Allows sites to query for estimates of the environmental lighting conditions within [WebXR sessions](https://developer.mozilla.org/en-US/docs/Web/API/XRSession). This exposes both spherical harmonics representing the ambient lighting, as well as a cubemap texture representing "reflections". Adding lighting estimation can help to make models feel more natural and like they "fit" better with the user's environment. This can make them feel more "real" or "natural".

In Chrome 88, this is available for Android only.

Completed Origin Trials
-----------------------

The following features, previously in Chrome origin trials, are now enabled by default.

### performance.measureMemory() Method

Adds the performance.measureMemory() method that estimates the memory usage of the web page in case the page is currently isolated (e.g. on Desktop). Because the method is gated behind COOP/COEP web sites need to enabled [crossOriginIsolated](https://web.dev/why-coop-coep/) to use this method. For more information, see [Monitor your web page's total memory usage with measureMemory()](https://web.dev/monitor-total-page-memory-usage/).

### PointerLock unadjustedMovement

Adds the ability to request unadjusted/unaccelerated mouse movement data when in `PointerLock`. If `unadjustedMovement` is set to true, then the pointer movements will not be affected by the underlying platform modifications such as mouse acceleration. For more information, see [Disable mouse acceleration to provide a better FPS gaming experience](https://web.dev/disable-mouse-acceleration/).

Other features in this release
==============================

### Anchor target=\_blank implies rel=noopener by Default

To mitigate "tab-napping" attacks, in which a new tab/window opened by a victim context may navigate that opener context, anchors that target `_blank` will behave as though `rel` is set to `noopener`. To opt out of this behavior, you can set `rel` to opener. This conforms to a change in the HTML standard.

### Dark Mode Form Controls and Scrollbars

Dark mode is an accessibility feature that allows web authors to enable their web pages to be viewed in dark mode. When enabled, users are able to view dark mode supported websites by toggling the dark mode settings on their OS. The benefits of dark mode are being easier on the eyes in a low light environment and lower battery consumption. For more about dark mode and form controls, see [Improved dark mode default styling with the color-scheme CSS property and the corresponding meta tag](https://web.dev/color-scheme/).

### AbortSignal in addEventListener()

Adds [the `AbortSignal` option](https://www.chromestatus.com/feature/5658622220566528), named `signal`, to the options parameter of `addEventListener()`. The `signal` option must first be created by an `AbortController` by accessing the `signal` property on an `AbortController` instance. Once the signal is passed in to `addEventListener()`, calling `AbortController.abort()` removes the event listener added with `addEventListener()`.

### CSS aspect-ratio Property

Allows [explicitly specifying an aspect ratio](https://www.chromestatus.com/feature/5738050678161408) for any element to get similar behavior to a replaced element. This generalizes the aspect ratio concept to general elements. It allows various effects, examples include sizing `<iframe>` elements using an aspect ratio, filmstrips where each element has the same height but needs an appropriate width, and cases where a replaced element is wrapped by a component but should keep the aspect ratio.

### CSS Selectors 4: Complex :not()

Allows [complex selectors inside the `:not()` pseudo class](https://www.chromestatus.com/feature/5014164156186624), such as `:not(.a + .b .c)`.

### Don't Clear adoptedStyleSheets on Adoption to/from <template>

When adopting a shadow root into a `<template>` document from a document that the `<template>` is in (or vice versa), Chrome will [no longer clear its `adoptedStyleSheets`](https://www.chromestatus.com/feature/5980793119703040).  
  
Currently Chrome always clears `adoptedStyleSheets` when the shadow root containing it is adopted into a different document. This ensures that constructed stylesheets are not used across `<iframe>` elements, but this also covers adopting into/from `<template>` elements, causing some confusion for the web developer.

### ElementInternals.shadowRoot Attribute

[A new attribute on `ElementInternals`, `shadowRoot`](https://www.chromestatus.com/feature/5721288276443136), allows custom elements to access their own shadow root, regardless of open/closed status. Additionally, further restrictions are added to the `attachInternals()` method to ensure that custom elements get the first chance to attach the `ElementInternals` interface. With this change, the `attachInternals()` method will throw an exception if called before the custom element constructor being run.

This feature was mostly driven, at least initially, by the declarative Shadow DOM feature introduction. With declarative Shadow DOM, there was a problem with closed shadow roots: declarative shadow content loads before the custom element is upgraded, which means that closed shadow content would have been inaccessible.  
  
In addition to the declarative Shadow DOM use case, this feature also offers a convenience to custom element authors, who no longer need to keep a reference to attached shadow roots, and can instead use the `ElementInternals` interface.

### Make Type Optional in WakeLock.request()

The `type` parameter in `WakeLock.request()` [is now optional](https://www.chromestatus.com/feature/5725750881681408) and defaults to `"screen"`, which is currently the only allowed value. For more information, see [Stay awake with the Screen Wake Lock API](https://web.dev/wake-lock/#get-wake-lock).

### Origin Isolation

[Origin isolation](https://www.chromestatus.com/feature/5683766104162304) allows developers to opt in to giving up certain cross-origin same-site access capabilities—namely synchronous scripting via `document.domain`, and calling `postMessage()` with `WebAssembly.Module` instances. This gives the browser more flexibility in implementation technologies.   
  
Reasons why a site may want better isolation include: performance isolation, allocations of large amounts of memory, side-channel protection (e.g. against Spectre), and improved memory measurement.

### path() Support in clip-path CSS Property

Adds [support for `path()`](https://www.chromestatus.com/feature/5633533638868992) as a value for the CSS `clip-path` property, which allows specifying SVG-style paths for clipping. This supplements the four basic shapes currently supported by `clip-path`: `circle`, `ellipse`, `polygon`, and `url`. For example, the following would clip an element with a triangle:  
  
`clip-path: path(oddeven, 'M 5 5 h 100 v 100 Z')`

### Permissions-Policy Header

The `Permissions-Policy` HTTP header [replaces the existing `Feature-Policy` header](https://www.chromestatus.com/feature/5745992911552512) for controlling delegation of permissions and powerful features. The header uses a structured syntax, and allows sites to more tightly restrict which origins can be granted access to features.

### RTCRtpTransceiver.stop()

Transceivers allow the sending and/or receiving of media in WebRTC. [Stopping a transceiver](https://www.chromestatus.com/feature/5410592384876544) makes it permanently inactive and frees its network port, encoder, and decoder resources. This also makes its `m=` section in the SDP reusable by future transceivers, preventing the SDP from growing indefinitely as transceivers are added and removed. This is part of "Perfect Negotiation", which makes signaling in WebRTC race free and less error-prone.

### JavaScript

This version of Chrome incorporates version 8.8 of the V8 JavaScript engine. It specifically includes the change listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

#### Shared Array Buffers, Atomics, and Futex APIs

Adds the JavaScript type `SharedArrayBuffer` gated behind COOP/COEP. A `SharedArrayBuffer` allows a message to be posted to a worker by sending a reference instead of a copy of the sent data.  
  
JavaScript [Atomics](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Atomics) provides atomic loads and stores and read/modify/write accesses to `SharedArrayBuffer` objects. `Atomics.wait()` provides the ability for a worker to wait for another worker to signal it, without having to spinlock.

The primary use case for `SharedArrayBuffer` is for asm.js code, but it is also useful for implementing other higher-level sharing between Workers.

For more information, see [Making your website "cross-origin isolated" using COOP and COEP](https://web.dev/coop-coep/).

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Don't Allow Popups During Page Unload (Enterprises)
---------------------------------------------------

Since Chrome 80, pages have no longer been able to [open a new page during unloading](https://www.chromestatus.com/feature/5989473649164288) using `window.open()`. Since then enterprises have been able to use the AllowPopupsDuringPageUnload policy flag to allow popups during page unload. Starting in Chrome 88, this flag is no longer supported.

FTP Support Removed
-------------------

Chrome is removing support for FTP URLs. The legacy FTP implementation in Chrome has no support for encrypted connections (FTPS), nor proxies. Usage of FTP in the browser is sufficiently low that it is no longer viable to invest in improving the existing FTP client. In addition, more capable FTP clients are available on all affected platforms.

Google Chrome 72 and later removed support for fetching document subresources over FTP and rendering of top level FTP resources. Navigating to FTP URLs results in showing a directory listing or a download depending on the type of resource. A bug in Google Chrome 74 and later resulted in dropping support for accessing FTP URLs over HTTP proxies. Proxy support for FTP was removed entirely in Google Chrome 76.

The remaining capabilities of Google Chrome's FTP implementation were restricted to either displaying a directory listing or downloading a resource over unencrypted connections.

In Chrome 77, FTP support was disabled by default for fifty percent of users but was available with flags.

In Chrome 88 all FTP support is disabled.

Web Components v0 Removed
-------------------------

Web Components v0 have been in a reverse origin trial since Chrome 80. This allowed users of the API time to upgrade their sites while ensuring that new adopters of Web Components used version 1. The reverse origin trial ends with Chrome 87, making Chrome 88 the first in which version 0 is no longer supported. The Web Components v1 APIs replace Web Components v0 and are fully supported in Chrome, Safari, Firefox, and Edge. This removal covers the items listed below.

* [Custom Elements v0](https://www.chromestatus.com/feature/4642138092470272)
* [HTML Imports](https://www.chromestatus.com/feature/5144752345317376)
* [Shadow DOM v0](https://www.chromestatus.com/feature/4507242028072960)