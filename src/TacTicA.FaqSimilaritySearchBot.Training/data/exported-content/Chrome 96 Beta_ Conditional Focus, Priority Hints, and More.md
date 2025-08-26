URL:https://blog.chromium.org/2021/10/chrome-96-beta-conditional-focus.html
# Chrome 96 Beta: Conditional Focus, Priority Hints, and More
- **Published**: 2021-10-21T10:50:00.000-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 96 is beta as of October 21, 2021.

Preparing for a Three Digit Version Number
------------------------------------------

Next year, Chrome will release version 100. This will add a digit to the version number reported in Chrome's user agent string. To help site owners test for the new string, Chrome 96 introduces a runtime flag that causes Chrome to return '100' in its user agent string. This new flag called `chrome://flags/#force-major-version-to-100` is available from Chrome 96 onward.

Origin Trials
-------------

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

### New Origin Trials

#### Conditional Focus

Applications that capture other windows or tabs currently have no way to control whether the calling item or the captured item gets focus. (Think of a presentation feature in a video conference app.) [Chrome 96 makes this possible](https://developer.chrome.com/origintrials/#/view_trial/4329085141809889281) with a subclass of `MediaStreamTrack` called `FocusableMediaStreamTrack`, which supports a new `focus()` method. Consider the following code:

```
stream = await navigator.mediaDevices.getDisplayMedia();
let [track] = stream.getVideoTracks();
```

Where formerly, `getVideoTracks()` would return an array of `MediaStreamTrack` objects, it now returns `FocusableMediaStreamTrack` objects. (Note that this is expected to change to `BrowserCaptureMediaStreamTrack` in Chrome 97. At the time of this writing, Canary already does this.)

To determine which display media gets focus, the next line of this code would call `track.focus()` with either `"focus-captured-surface"` to focus the newly captured window or tab, or with `"no-focus-change"` to keep the focus with the calling window. On Chrome 96 or later, you can step through our [demo code](https://eladalon1983.github.io/conditional-focus/demo/) to see this in action.

#### Priority Hints

Priority Hints [introduces a developer-set `"importance"` attribute](https://web.dev/priority-hints/) to influence the computed priority of a resource. Supported importance values are `"auto"`, `"low"`, and `"high"`. Priority Hints indicate a resource's relative importance to the browser, allowing more control over the order resources are loaded. Many factors influence a resource's priority in browsers including type, visibility, and preload status of a resource.

Other Features in this Release
------------------------------

### Allow Simple Range Header Values Without Preflight

Requests with simple range headers [can now be sent](https://www.chromestatus.com/feature/5652396366626816) without [a preflight request](https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#preflighted_requests). CORS requests can use the Range header in limited ways (only one valid range) without triggering a preflight request.

### Back-forward Cache on Desktop

The [back-forward cache](https://www.chromestatus.com/feature/5815270035685376) stores pages to allow for instant navigations to previously-visited pages after cross-site navigations.

### Cross-Origin-Embedder-Policy: credentialless

`Cross-Origin-Embedder-Policy` has [a new `credentialless` option](https://www.chromestatus.com/feature/4918234241302528) that causes cross-origin `no-cors` requests to omit credentials (cookies, client certificates, etc.). Similarly to `COEP:require-corp`, it can enable cross-origin isolation.

Sites that want to continue using [SharedArrayBuffer](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/SharedArrayBuffer) must opt-in to cross-origin isolation. Doing so using `COEP: require-corp` is difficult to deploy at scale and requires all subresources to explicitly opt-in. This is fine for some sites, but creates dependency problems for sites that gather content from users (Google Earth, social media generally, forums, etc).

### CSS

#### :autofill Pseudo Class

The new [`autofill` pseudo class](https://www.chromestatus.com/feature/5592445322526720) enables styling autofilled form elements. This is a standardization of the `:-webkit-autofill` pseudo class which is already supported in WebKit. Firefox supports the standard version.

#### Disable Propagation of Body Style to Viewport when Contained

Some properties like writing-mode, direction, and backgrounds are propagated from body to the viewport. To avoid infinite loops for CSS Container Queries, the [spec and implementation were changed](https://www.chromestatus.com/feature/5663240823504896) to not propagate those properties when containment is applied to HTML or BODY.

#### font-synthesis Property

The [`font-synthesis` CSS property](https://www.chromestatus.com/feature/5640605355999232) controls whether user agents are allowed to synthesize oblique, bold, and small-caps font faces when a font family lacks faces.

### EME MediaKeySession Closed Reason

The `MediaKeySession.closed` property [now uses an enum to indicate the reason](https://www.chromestatus.com/feature/5632124143009792) the `MediaKeySession` object closed. The closed property returns a Promise that resolves when the session closes. Where previously, the Promise simply resolved, it [now resolves with a string](https://www.google.com/url?q=https://googlechrome.github.io/samples/media/key-session-closed-reason.html&sa=D&source=docs&ust=1634547430725000&usg=AOvVaw3cXtJIna_rtEkWm9LLzyft) indicating the reason for closing. The returned string will be one of `"internal-error"`, `"closed-by-application"`, `"release-acknowledged"`, `"hardware-context-reset"`, or `"resource-evicted"`.

### HTTP to HTTPS Redirect for HTTPS DNS Records

Chrome will always [connect to a website via HTTPS](https://www.chromestatus.com/feature/5485544526053376) when an HTTPS record is available from the domain name service (DNS).

### InteractionID in EventTiming

The `PerformanceEventTiming` interface now includes an attribute called `interactiveID`. This is a browser-generated ID that enables [linking multiple `PerformanceEventTiming` entries](https://www.chromestatus.com/feature/5674224959094784) when they correspond to the same user interaction. Developers can currently use the Event Timing API to gather performance data about events they care about. Unfortunately, it is hard to link events that correspond to the same user interaction. For instance, when a user taps, many events are generated, such as `pointerdown`, `mousedown`, `pointerup`, `mouseup`, and `click`.

### New Media Query: prefers-contrast

Chrome supports [a new media query](https://www.chromestatus.com/feature/5646323212615680) called `'prefers-contrast'`, which lets authors adapt web content to the user's contrast preference as set in the operating system (specifically, increased contrast mode on macOS and high contrast mode on Windows). Valid options are `'more'`, `'less'`, `'custom'`, or `'no-preference'`.

### Unique id for Desktop PWAs

Web app [manifests now support an optional `id` field](https://developer.chrome.com/blog/pwa-manifest-id/) that globally identifies a web app. When the `id` field is not present, a PWA falls back to `start_url`. This field is currently only supported on desktop.

### URL Protocol Handler Registration for PWAs

Enable web applications to [register themselves as handlers of custom URL protocols/schemes](https://web.dev/url-protocol-handler/) using their installation manifest. Operating system applications often register themselves as protocol handlers to increase discoverability and usage. Web sites can already register to handle schemes via `registerProtocolHandler()`. The new feature takes this a step further by letting web apps be launched directly when a custom scheme link is invoked.

### WebAssembly

#### Content Security Policy

Chrome has [enhanced Content Security Policy](https://www.chromestatus.com/feature/5499765773041664) to improve interoperability with WebAssembly. The `wasm-unsafe-eval` controls WebAssembly execution (with no effect on JavaScript execution). Additionally, the `script-src` policies now include WebAssembly.

#### Reference Types

WebAssembly modules can now [hold references to JavaScript and DOM objects](https://www.chromestatus.com/feature/5166497248837632). Specifically, they can be passed as arguments, stored in local and global variables, and stored in WebAssembly.Table objects.

Deprecations and Removals
-------------------------

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

### The "basic-card" Method of PaymentRequest API

The [PaymentRequest API](https://developer.mozilla.org/en-US/docs/Web/API/Payment_Request_API) has [deprecated the basic card payment method](https://blog.chromium.org/2021/10/sunsetting-basic-card-payment-method-in.html). Its usage is low and declining. It underperforms when compared to other payment methods in time-to-checkout and completion rate. Developers can switch to other payment methods as an alternative. Examples include Google Pay, Apple Pay, and Samsung Pay.  
  
Removal timeline:

* Chrome 96: the basic-card method is deprecated in the [Reporting API](https://developer.mozilla.org/en-US/docs/Web/API/Reporting_API).
* Chrome 100: the basic-card method will be removed.