URL:https://blog.chromium.org/2020/10/chrome-87-beta-webauthn-in-devtools.html
# Chrome 87 Beta: WebAuthn in DevTools, Pan/Tilt/Zoom, Flow Relative Shorthands and More
- **Published**: 2020-10-15T11:06:00.005-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 87 is beta as of October 15, 2020.

WebAuthn Tab in DevTools
------------------------

Testing web authentication has long been difficult because developers need devices to test their code. Starting in Chrome 87, authentication can be emulated and debugged using a new panel in DevTools. You can find the panel in DevTools by selecting **More options**, then **More tools**, then **WebAuthn**. To learn how to use it, see the section in [What's New in DevTools (Chrome 87)](https://developers.google.com/web/updates/2020/10/devtools#webauthn).

![](https://lh3.googleusercontent.com/24rUeaeOXh0gI5GYDqzM4VKnIbKNU6UOtlJKpilFZgJlSfCQhhJW1yk3Bzk42zLJ_iReS73Fh6loZTCH-bzF7Hk4FI-GJz9RiBsGOo_Ap6el9lYnvA3FJx7WmZSM3KHs62XAj6LYmw)

Control camera pan, tilt, and zoom
----------------------------------

Room-scale video conferencing solutions deploy cameras with pan, tilt, and zoom capabilities so that software can point the camera at meeting participants. Starting in Chrome 87, the pan, tilt, and zoom features on cameras are accessible to websites using media track constraints in `MediaDevices.getUserMedia()` and `MediaStreamTrack.applyConstraints()`.

Websites are only allowed to control these capabilities when users explicitly grant permission. For details on using the new capabilities and a demo, see [Control camera pan, tilt, and zoom](https://web.dev/camera-pan-tilt-zoom/).

[

](https://storage.googleapis.com/web-dev-assets/camera-pan-tilt-zoom/ptz_h264.mp4)

CSS flow-relative shorthand and offset properties
-------------------------------------------------

The trend in CSS for many years has been to supplement physical properties with logical properties. Properties that assume language flows left to right and top to bottom don't work in non-European text such as vertical Chinese text, or Arabic. Modern CSS rules use flow-relative terms like start and end and provide rules for dealing with the text's axis (direction).

The first step in implementing this in Chrome was to implement the most granular flow-relative features of the [CSS Logical Properties and Values](https://www.w3.org/TR/css-logical-1) spec. Chrome 87 ships shorthands and   
offsets to make these logical properties and values a bit easier to write. What was once written with multiple CSS rules can now be written as one. For example, separate rules for `margin-block-start` and `margin-block-end` may now be written using a single `margin-block` property.

For a list of all flow-relative shorthands now supported by Chrome, and explanations for how to use them, see [Logical layout enhancements with flow-relative shorthands](https://web.dev/logical-property-shorthands/). For more CSS-related updates, see the CSS section, below.

Completed Origin Trials
-----------------------

Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. The following feature, previously in a Chrome origin trial, is now enabled by default.

#### Cookie Store API

The Cookie Store API [exposes HTTP cookies to service workers](https://www.chromestatus.com/feature/5658847691669504) and offers an asynchronous alternative to `document.cookie`.

Other features in this release
------------------------------

#### cross-origin isolation

Chrome 87 has a number of changes related to cross-origin isolation. Chrome will now use origin instead of site as agent cluster key for cross-origin isolated agent clusters. Mutation of `document.domain` is no longer supported for cross-origin isolated agent clusters. This change also introduces `window.crossOriginIsolated`, a boolean that indicates whether APIs that require cross-origin isolation are allowed to use it. Supporting APIs include:

* `SharedArrayBuffer` (required for WebAssembly Threads)
* `performance.measureMemory()`
* [JS Self-Profiling API](https://wicg.github.io/js-self-profiling/)

For more information, see [Making your website "cross-origin isolated" using COOP and COEP](https://web.dev/coop-coep/).

#### iframe attribute for limiting same-origin iframe document access

Adds [the `disallowdocumentaccess` property](https://www.chromestatus.com/feature/5648946183536640) to disallow cross-document scripting between iframes from the same origin in the same parent document. This also puts same-origin iframes in separate event loops.

**Note:** This item was pulled from Chrome 87 beta and was not in later builds.

#### isInputPending()

Sometimes long-running scripts block user input. A lag between a user's action and a response by an app is a bad user experience. To address this, Chrome has added a method called `isInputPending()`, accessible from `navigator.scheduling`, which can be called from long-running operations. You can find [an example of the method's use](https://wicg.github.io/is-input-pending/#examples-of-usage) in the draft spec.

#### Range Request Headers in Service Workers

HTTP range requests, which have been available in major browsers for several years, allow servers to send requested data to the client in chunks. This has proved especially useful for large media files where the user experience is improved through smoother playback and improved pause and resume functions.

Historically, range requests and services workers did not work well together, forcing developers to build [work-arounds](https://code-tree.github.io/sw-partial-content/). Starting in Chrome 87, passing range requests through to the network from inside a service worker will "just work."

For an explanation of the issues with range requests and what's changed in Chrome 87, see [Handling range requests in a service worker](https://web.dev/sw-range-requests/).

#### Streams API: transferable streams

[Transferable streams](https://www.chromestatus.com/feature/5298733486964736) now allows `ReadableStream`, `WritableStream`, and `TransformStream` objects to be passed as arguments to `postMessage()`. The streams APIs provide ubiquitous, interoperable primitives for creating, composing, and consuming streams of data. A natural thing to do with a stream is to pass it to a web worker. This provides a fluent primitive for offloading work to another thread.

Offloading work onto a worker is important for a smooth user experience, but the ergonomics can be awkward. Transferable streams solve this problem for streams. Once the stream itself has been transferred, the data is transparently cloned in the background.

#### Transition related event handlers

The `ontransitionrun`, `ontransitionstart`, and `ontransitioncancel` [event handler attributes](https://www.chromestatus.com/feature/5354694014664704) allow developers to add event listeners for `'transitionrun'`, `'transitionstart'`, and `'transitioncancel'` events on elements, Document objects, and Window objects.

#### WakeLockSentinel.released Attribute

The `WakeLockSentinel` object has [a new property called `released`](https://www.chromestatus.com/feature/5632527123349504) that indicates whether a sentinel has already been released. It defaults to false and changes to true when a release event is dispatched. The new attribute helps web developers know when locks are released so that they do not need to keep track of them manually.

### CSS

#### @font-face descriptors to override font metrics

New [`@font-face` descriptors](https://www.chromestatus.com/feature/5651198621253632) have been added to `ascent-override`, `descent-override`, and `line-gap-override` to override metrics of the font. This Improves interoperably across browsers and operating systems, so that the same font always looks the same on the same site, regardless of OS or browser. Additionally, it aligns metrics between two web fonts present simultaneously, but for different glyphs. Finally, it overrides font metrics for a fallback font to emulate a web font, to minimize cumulative layout shift.

#### Text Decoration and Underline Properties

Chrome now supports [several new text decoration and underline properties](https://www.chromestatus.com/feature/5747636764147712). These properties solve use cases where underlines are too close to the text baseline and ink-skipping triggers too early in a text run. These use cases solve problems caused by the launch of the `text-decoration-skip-ink` property. The new properties are `text-decoration-thickness`, `text-underline-offset` and a `from-font` keyword for `text-underline-position`.

#### The quotes Property Supports the 'auto' Value

CSS2 allowed browsers to define the default value for the quotes property, which Chrome formerly followed. Chrome 87 [now follows CSS Generated Content Module Level 3](https://www.chromestatus.com/feature/4922661488558080) in which the `'auto'` keyword is the default value. That spec requires that a typographically appropriate value be used for quotes based on the content language of the element and/or its parent.

### JavaScript

This version of Chrome incorporates version 8.7 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

#### Atomics.waitAsync()

[Chrome now supports `Atomics.waitAsync()`](https://www.chromestatus.com/feature/6243382101803008), the async version of `Atomics.wait()`. `Atomics.waitAsync()` allows programmers to wait on a `SharedArrayBuffer` location in the same fashion as `Atomics.wait()` but returns a Promise instead.

`Atomics.wait()` blocks the thread and cannot be used on the main web browser thread, where blocking is disallowed. This makes coordination via `SharedArrayBuffers` between the main thread and worker threads more ergonomic.

### Deprecations and Removals

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

#### Comma separator in iframe allow attribute

Permissions policy declarations in an `<iframe>` tag [can no longer use commas](https://www.chromestatus.com/feature/5740835259809792) as a separator between items. Developers should use semicolons instead.

#### -webkit-font-size-delta

Blink [will no longer support](https://www.chromestatus.com/feature/6267981828980736) the rarely-used `-webkit-font-size-delta` property. Developers should use `font-size` to control font size instead.

#### Deprecate FTP support

Chrome is [deprecating and removing support for FTP URLs](https://www.chromestatus.com/features/6246151319715840). The current FTP implementation in Google Chrome has no support for encrypted connections (FTPS), nor proxies. Usage of FTP in the browser is sufficiently low that it is no longer viable to invest in improving the existing FTP client. In addition, more capable FTP clients are available on all affected platforms.  
  
Google Chrome 72 and later removed support for fetching document subresources over FTP and rendering of top level FTP resources. Currently navigating to FTP URLs results in showing a directory listing or a download depending on the type of resource. A bug in Google Chrome 74 and later resulted in dropping support for accessing FTP URLs over HTTP proxies. Proxy support for FTP was removed entirely in Google Chrome 76. In Chrome 86, FTP was turned off for pre-release channels (Canary and Beta) and was experimentally turned off for one percent of stable users.   
  
The remaining capabilities of Google Chrome's FTP implementation are restricted to either displaying a directory listing or downloading a resource over unencrypted connections.

Remainder of the deprecation follows this timeline:

#### Chrome 87

FTP support will be disabled by default for fifty percent of users but can be enabled using the flags listed above.

#### Chrome 88

FTP support will be disabled.