URL:https://blog.chromium.org/2021/08/chrome-94-beta-webcodecs-webgpu.html
# Chrome 94 Beta: WebCodecs, WebGPU, Scheduling, and More
- **Published**: 2021-08-26T12:06:00.000-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 94 is beta as of August 26, 2021.

WebCodecs
---------

Existing media APIs (`HTMLMediaElement`, [Media Source Extensions](https://developer.mozilla.org/en-US/docs/Web/API/Media_Source_Extensions_API), `WebAudio`, `MediaRecorder`, and [WebRTC](https://developer.mozilla.org/en-US/docs/Web/API/WebRTC_API)) are high-level and narrowly-focused. A low-level codec API would better support emerging applications, such as latency-sensitive game streaming, client-side effects or transcoding, and polyfillable media container support, without the increased network and CPU cost of JavaScript or WebAssembly codec implementations.

The WebCodecs API eliminates these deficiencies by giving programmers a way to use media components that are already present in the browser. Specifically:

* Video and audio decoders
* Video and audio encoders
* Raw video frames
* Image decoders

This feature has also completed its origin trial in Chrome 93 and is now available by default. For more information, see [Video processing with WebCodecs](https://web.dev/webcodecs/).

WebGPU
------

The WebGPU API is the successor to the WebGL and WebGL2 graphics APIs for the Web. It provides modern features such as "GPU compute" as well as lower overhead access to GPU hardware and better, more predictable performance. This is an improvement over the existing WebGL interfaces, which were designed for drawing images but could only be repurposed for other kinds of computations with great effort.

WebGPU exposes modern computer graphics capabilities, specifically Direct3D 12, Metal, and Vulkan, for performing rendering and computation operations on a graphics processing unit (GPU). Advantages of WebGPU over earlier technologies include:

* Separating resource management, work preparation, and submission to the GPU.
* Pipeline states that function similarly to OS APIs.
* Binding groups that allow graphics drivers to perform needed preparations in advance of rendering.

This feature is starting an origin trial in Chrome 94 with the hope of shipping in Chrome 99. For more information, see [Access modern GPU features with WebGPU](https://web.dev/gpu/).

Scheduling APIs: Prioritized scheduler.postTask()
-------------------------------------------------

It's difficult to build web apps that are responsive to user interaction and that remain responsive over time. Scripts are one of the primary culprits hurting responsiveness. Consider a "search-as-you-type" feature: an app with this capability needs to keep up with the user's typing at the same time that it is fetching and displaying results. This doesn't take into account anything happening on the page such as animation, which must be rendered smoothly.

The problem is usually tackled by chunking and scheduling main thread work, specifically executing work asynchronously at appropriate times. This approach has its own problems, including the fact that whatever priority the developer sets, it's still competing for time on the main thread, which doesn't recognize the developer's prioritization, and is also responsible for browser tasks such as `fetch()` operations and garbage collection.

The [`scheduler.postTask()` method](https://www.chromestatus.com/feature/6031161734201344) fixes these scheduling dilemmas by letting developers schedule tasks (JavaScript callbacks) with an OS browser scheduler at three levels of priority: user-blocking, user-visible, and background. It also exposes a `TaskController` interface, which can dynamically cancel tasks and change their priority.

This feature completed its origin trial in Chrome 93 and is now available by default in Chrome. For a list of other new and completed origin trials, see the Origin Trials section below.

Origin Trials
-------------

In addition to the items above, this version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

### New Origin Trials

#### Early Hints for Navigation

Chrome is testing [a new HTTP status code](https://developer.chrome.com/origintrials/#/view_trial/2856408063659737089): 103 Early Hints for preloading subresources earlier.   
When a 103 response includes `<link rel=preload>` or other link headers Chromium tries to preload (and/or preconnect, prefetch) specified resources before the final response is received. This gives web developers a way to optimize apps, sites, and pages.

### Completed Origin Trials

The following features, previously in a Chrome origin trial, are now enabled by default.

#### Canvas Color Management

This update [formalizes that the default color space](https://www.chromestatus.com/feature/5807007661555712) for `CanvasRenderingContext2D` objects and `ImageData` objects is sRGB. This clarifies that the `CanvasRenderingContext2D` interface is fully color managed (that all inputs are converted to the canvas color space). These were previously conventions and not clearly specified. This updates makes the following changes:

* Adds parameters to specify a non-sRGB color space when creating a `CanvasRenderingContext2D` object or an `ImageData` object.
* Adds support for the Display P3 color space for these parameters.

Content displayed by `CanvasRenderingContext2D` is currently limited to the sRGB color space, which is less than the capabilities of modern displays and cameras. This feature allows creating a `CanvasRenderingContext2D` object that is in the Display P3 color space. This also clears up several points of ambiguity about the color behavior of `CanvasRenderingContext2D`.

#### VirtualKeyboard API

The `VirtualKeyboard` interface has methods and properties to [control when a virtual keyboard is shown or hidden](https://www.chromestatus.com/feature/5680057076940800). It also fires events with the size of the virtual keyboard when it occludes content in the page. The virtual keyboard is the on-screen keyboard used for input in scenarios where a hardware keyboard may not be available.

Unlike a hardware keyboard, a virtual keyboard can adapt its shape to optimize for the expected input. Developers have control over the displayed shape of the virtual keyboard through the `inputmode` attribute, but have limited control over when the virtual keyboard is shown or hidden.

Other features in this release
------------------------------

### CSS

#### Align transform-style: preserve-3d and perspective Property with the Spec

[The transform-style: preserve-3d and perspective properties now align with the spec](https://www.chromestatus.com/feature/5640541339385856). The preserve-3d property allows child elements to participate in the parent's 3D scene, and the perspective property applies a perspective transform to child elements. Before this change, Chromium applied both of these effects based on the containing block hierarchy rather than the DOM tree, and allowed them to extend through elements without transform-related properties on them.

#### flex-basis Honors Keywords 'content' and 'min/max/fit-content'

[Chrome now supports](https://www.chromestatus.com/feature/5635933158244352) the keywords `content`, `min-content`, `max-content`, and `fit-content` as values for the `flex-basis` property and its `flex` shorthand. The `content` keyword makes flex base size use the default sizing rules as if `flex-basis` and preferred size property (`width` or `height`) are both `auto`, ignoring any specified `width` or `height` in the main axis dimension when `flex-basis` is `auto`. The other keywords are the same as usual and give more options for specifying the flex base size.

In responsive layouts, when adding or removing `display:flex` to a container, you previously had to sometimes add/remove values for each individual item. `content` eliminates the need in some situations.

#### scrollbar-gutter

The [`scrollbar-gutter` property](https://www.chromestatus.com/feature/5746559209701376) provides control over the presence of scrollbar gutters (the space reserved to display a scrollbar), allowing developers to prevent layout changes as content expands while avoiding unwanted visuals when scrolling isn't needed.  
  
Note that the presence of the scrollbars themselves is determined by the `overflow` property. The choice of classical or overlay scrollbars is up to the user agent. This property provides developers with more control over how their layouts interact with the scrollbars provided by the browser.

### MediaStreamTrack Insertable Streams (a.k.a. Breakout Box)

This API lets developers [manipulate raw media carried by `MediaStreamTracks`](https://web.dev/mediastreamtrack-insertable-media-processing/) such as the output of cameras, microphones, screen captures or the decoder part of a codec and the input to the decoder part of a codec. It uses WebCodecs interfaces to represent raw media frames and exposes them using streams, similar to the way the WebRTC Insertable Streams exposes encoded data from [RTCPeerConnections](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection). Example use cases include [funny hats](https://www.w3.org/TR/webrtc-nv-use-cases/#funnyhats*) and [real-time object identification and annotation](https://www.w3.org/TR/webrtc-nv-use-cases/#machinelearning*).

### Return Fixed Lists for navigator.plugins and navigator.mimeTypes

With the removal of Flash, there is no longer a need to return anything for `navigator.plugins` and `navigator.mimeTypes`. These APIs were used primarily for:

* Probing for Flash player support
* Fingerprinting.

Some sites use these APIs to probe for PDF viewer support. With this change, [these arrays will return fixed lists](https://www.chromestatus.com/feature/5741884322349056) containing a standard list of PDF viewer plugins.

Note that this is not the removal or change of any API, it is merely the return of fixed arrays for these two existing APIs.

JavaScript
----------

This version of Chrome incorporates version 9.4 of the V8 JavaScript engine. It specifically includes the change listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

### Self Profiling API

Chrome now supports [a web-exposed sampling profiler](https://www.chromestatus.com/feature/5170190448852992) for measuring client JavaScript execution time. Gathering JavaScript profiles from real users can help developers debug slow observed performance without invasive manual instrumentation.

Deprecations, and Removals
--------------------------

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

### Deprecate and Remove WebSQL in Third-Party Contexts

[WebSQL in third-party contexts is now deprecated](https://www.chromestatus.com/feature/5684870116278272). Removal is expected in Chrome 97. The Web SQL Database standard was first proposed in April 2009 and abandoned in November 2010. Gecko never implemented this feature and WebKit deprecated in in 2019. The W3C encourages [Web Storage](https://developer.mozilla.org/en-US/docs/Web/API/Web_Storage_API) and [Indexed Database](https://developer.mozilla.org/en-US/docs/Web/API/IndexedDB_API) for those needing alternatives.

Developers should expect that WebSQL itself will be deprecated and removed when usage is low enough.

### Restrict Private Network Requests for Subresources to Secure Contexts

Private network requests for subresources [may now only be initiated from a secure context](https://developer.chrome.com/blog/private-network-access-update/). Private network requests are those initiated from a public network, targeting a private network. Examples include internet to *intranet* requests and intranet loopbacks.

This is a first step towards fully implementing [Private Network Access](https://wicg.github.io/private-network-access/). Servers running inside local networks, or on a user's device, expose powerful capabilities to the web in ways that can be quite dangerous. Private Network Access proposes a set of changes to limit the impact of requests to these servers by ensuring that the servers are opting-into any communication with external entities.

For this opt-in to have any meaning, the servers need to be able to ensure that the client origin is authenticated. To that end, only secure contexts are empowered to make external requests.