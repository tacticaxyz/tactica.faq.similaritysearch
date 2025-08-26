URL:https://blog.chromium.org/2021/04/chrome-91-handwriting-recognition-webxr.html
# Chrome 91: Handwriting Recognition, WebXR Plane Detection and More
- **Published**: 2021-04-22T14:46:00.010-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 91 is beta as of April 22, 2021.

Origin Trials
-------------

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

### New Origin Trials

#### Declarative Link Capturing for PWAs

The new Web App Manifest member called `capture_links` controls what happens when the user navigates to a page within scope of an installed web app. It allows sites to automatically open a new PWA window when the user clicks a link to their app or to have a single window mode like mobile apps. [Sign up for the origin trial](https://developer.chrome.com/origintrials/#/view_trial/4285175045443026945) and learn more on the origin trial dashboard.

#### WebTransport

WebTransport is a protocol framework that enables clients constrained by the Web security model to communicate with a remote server using a secure multiplexed transport.

Currently, Web application developers have two APIs for bidirectional communications with a remote server: `WebSockets` and `RTCDataChannel`. `WebSockets` are TCP-based, thus having all of the drawbacks of TCP (head of line blocking, lack of support for unreliable data transport) that make it a poor fit for latency-sensitive applications. `RTCDataChannel` is based on the Stream Control Transmission Protocol (SCTP), which does not have these drawbacks; however, it is designed to be used in a peer-to-peer context, which causes its use in client-server settings to be fairly low. `WebTransport` provides a client-server API that supports bidirectional transfer of both unreliable and reliable data, using UDP-like datagrams and cancellable streams. `WebTransport` calls are visible in the Network panel of DevTools and identified as such in the Type column.

For more information, see [Experimenting with WebTransport](https://web.dev/webtransport/). [Sign up for the origin trial](https://www.google.com/url?q=https://developer.chrome.com/origintrials/%23/view_trial/793759434324049921&sa=D&source=editors&ust=1619104452220000&usg=AOvVaw2ge7dt3GG_6ucYabUaGf_l) and learn more on the origin trial dashboard.

#### WebXR Plane Detection API

WebXR applications can now retrieve data about planes (flat surfaces) in the user's environment, allowing better user experiences with less processing power. Without this feature plane detection requires custom computer vision algorithms using data from `MediaDevices.getUserMedia()`. These solutions usually fall short of quality and accuracy expectations for AR experiences and don't support world scale. [Sign up for the origin tria](https://developer.chrome.com/origintrials/#/view_trial/1154047404513689601)l and learn more on the dashboard.

### Completed Origin Trials

The following features, previously in a Chrome origin trial, are now enabled by default.

#### WebAssembly SIMD

WebAssembly SIMD exposes hardware SIMD instructions to WebAssembly applications in a platform-independent way. This introduces a new 128-bit type that can represent different types of packed data, and several vector operations that work on packed data. SIMD can boost performance by exploiting data level parallelism and is also useful when compiling native code to WebAssembly. For more information, see the V8 feature explainer for [WebAssembly SIMD](https://v8.dev/features/simd).

Other features in this release
------------------------------

### Align performance API timer resolution to cross-origin isolated capability

Coarsening of `performance.now()` and related timestamps based on site isolation status is [now consistent across platforms](https://developer.chrome.com/blog/cross-origin-isolated-hr-timers). This decreases the resolution on desktop from 5 microseconds to 100 microseconds in non-isolated contexts. It also increases their resolution on Android from 100 microseconds to 5 microseconds in cross-origin isolated contexts, where it's safe to do so.

### Clipboard: Read-Only Files Support

On desktop, apps can now [read files from the clipboard](https://www.chromestatus.com/features/5671807392677888) (but not write files to the clipboard). For files on the clipboard, apps have read-only access.

```
async function onPaste(e) {
  let file = e.clipboardData.files[0];
  let contents = await file.text();  
}
```

### CSS

#### Custom Counter Styles

The [CSS `@counter-style` rule](https://www.chromestatus.com/feature/5692693659254784) allows web authors to specify and use custom counter styles in list markers and CSS counters. This helps internationalization. This change implements all of the features in [CSS Counter Styles Level 3](https://drafts.csswg.org/css-counter-styles-3) except:

* Image symbols, which no browsers support, and is 'at-risk' per the spec
* The `speak-as` descriptor, which is an accessibility feature
* The `symbols()` function.

#### Single <compound-selector> for :host() and :host-context()

The `:host()` and `:host-context()` pseudo-classes [now accept a single `<compound-selector>`](https://www.chromestatus.com/feature/5755183847964672) in addition to a `<compound-selector-list>`.

### Form Controls Visual Refresh on Android

Form controls have a new, refreshed appearance, with better accessibility and touch support. This was a collaboration between Microsoft and Google, and if you'd like additional information, you can view a [past CDS talk](https://www.youtube.com/watch?v=ZFvPLrKZywA) or the [Microsoft's blog post](https://blogs.windows.com/msedgedev/2019/10/15/form-controls-microsoft-edge-chromium/).

In this release, we have brought the same form controls UX to Android as already launched on other platforms. The new form controls include automatically darkening form controls and scrollbars when in dark mode.

Dark mode is an accessibility feature that allows web authors to enable their web pages to be viewed in dark mode. When enabled, users are able to view dark mode supported websites by toggling the dark mode settings on their Android devices. dark mode is easier on the eyes in a low light environment and lowers battery consumption.

### GravitySensor Interface

The `GravitySensor` interface provides [a three-axis reading of the gravity force](https://www.chromestatus.com/feature/5384099747332096). It's already possible to derive readings close to those provided by this interface removing the `LinerAccelerometer` reading from the `Accelerometer` reading.

### Suggested file name and location for the File System Access API

When using the File System Access API, web apps can now [suggest the name and location of a file or directory](https://www.chromestatus.com/feature/6013006146174976) that is being created or loaded. This provides a better user experience and brings web apps closer to the behavior of system apps. For more about the File System Access API, see [The File System Access API: simplifying access to local files](https://web.dev/file-system-access/).

### WebOTP API: cross-origin iframe support

The WebOTP API is now [usable in cross-origin iframes](https://web.dev/web-otp-iframe) when enabled by a permission policy. The WebOTP API gives developers the ability to programmatically read one time codes from specially-formatted SMS messages addressed to their origin to reduce user friction. Many sites embed iframes that handle authentication.

### WebSockets over HTTP/2

Chrome supports [WebSockets over HTTP/2](https://www.chromestatus.com/feature/6251293127475200) in Chromium as specified in [RFC 8441](https://tools.ietf.org/html/rfc8441). This is only used for secure WebSockets requests, and only when there is already an HTTP/2 connection where the server has already advertised support for WebSockets over HTTP/2 via the HTTP/2 SETTINGS parameter defined in the specification.

### Credentials sharing for sites affiliated with Digital Asset Links

Since 2015 developers have used Digital Asset Links (DALs) to associate Android apps with websites to assist users with logging in. If you employ multiple domains that share the same account management backend, you can now also associate them with one another to enable users to [save credentials once and have the Chrome password manager suggest them to any of the affiliated websites](https://developer.chrome.com/blog/site-affiliation/). For more information, see [Enable Chrome to share login credentials across affiliated sites](https://developer.chrome.com/blog/site-affiliation/).

JavaScript
----------

This version of Chrome incorporates version 9.1 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

### ES Modules for service workers ('module' type option)

JavaScript now supports [modules in service workers](https://www.chromestatus.com/feature/4609574738853888). Setting `'module'` type by the constructor's type attribute, worker scripts are loaded as ES modules and the `import` statement is available on worker contexts. With this feature, web developers can more easily write programs in a composable way and share them among a page and workers.

### Checks for Private Fields

Developers can now [test for the existence of private fields](https://www.chromestatus.com/feature/5006138707804160) in an object using the syntax `#foo in obj`.

Deprecations, and Removals
--------------------------

This version of Chrome introduces the deprecation listed below. Visit ChromeStatus.com for lists of [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

### Remove alert(), confirm(), and prompt() for Cross Origin iframes

Chrome allows iframes to trigger Javascript dialogs. For example it shows “<URL> says ...” when the iframe is the same origin as the top frame, and “An embedded page on this page says...” when the iframe is cross-origin. This is confusing, and has led to spoofs where sites pretend the message comes from Chrome or a different website.

Chrome 91 deprecates this ability. [Removing support](https://chromestatus.com/feature/5148698084376576) for cross origin iframes’ ability to call `alert()`, `confirm()`, and `prompt()` will prevent this kind of spoofing, and unblock further UI simplifications. For example, this means notexample.com will no longer be able to call `window.alert()`, `window.prompt()`, or `window.confirm()` if embedded in an iframe on example.com.