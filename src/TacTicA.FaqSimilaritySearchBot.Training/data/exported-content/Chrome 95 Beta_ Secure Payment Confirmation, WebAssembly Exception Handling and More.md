URL:https://blog.chromium.org/2021/09/chrome-95-beta-secure-payment.html
# Chrome 95 Beta: Secure Payment Confirmation, WebAssembly Exception Handling and More
- **Published**: 2021-09-23T16:37:00.003-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 95 is beta as of September 23, 2021.

Origin Trials
-------------

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

### New Origin Trials

#### Access Handles for the File System Access API

It's our [eventual goal](https://github.com/WICG/storage-foundation-api-explainer/issues/4#issuecomment-853370759) to merge the origin private file system of the File System Access API with the [Storage Foundation API](https://chromestatus.com/feature/5670244905385984) to reduce the number of entry points for getting access to file-based storage in the browser. A first step toward this objective is the newly proposed [access handle](https://github.com/WICG/file-system-access/blob/main/AccessHandle.md). The new feature differs from existing functionality by offering in-place and exclusive write access to a file's content. This change, along with the ability to consistently read unflushed modifications and the availability of a synchronous variant on dedicated workers, significantly improves performance and unblocks new use cases. To join the origin trial, see [its entry on Chrome Origin Trials](https://www.google.com/url?q=https://developer.chrome.com/origintrials/%23/view_trial/3378825620434714625&sa=D&source=editors&ust=1632322938025000&usg=AOvVaw2QHjz5Bm-HjLWnHt1xaJH3). For more on access handlers, see the information we've added to [The File System Access API: simplifying access to local files](https://web.dev/file-system-access/#accessing-storage-foundation-api-files-from-the-origin-private-file-system).

#### Reduce User Agent String Information

Chrome is trying to [reduce the amount of information the user agent string exposes](https://blog.chromium.org/2021/09/user-agent-reduction-origin-trial-and-dates.html) in HTTP requests as well as in `navigator.userAgent`, `navigator.appVersion`, and `navigator.platform`. The user agent string can be used for passive user fingerprinting. To join the origin trial, see [its entry on Chrome Origin Trials](https://www.google.com/url?q=https://developer.chrome.com/origintrials/%23/view_trial/-7123568710593282047&sa=D&source=editors&ust=1632322938025000&usg=AOvVaw207ZCzhuIHuw9cXAfgBMMn).

### Completed Origin Trials

The following features, previously in a Chrome origin trial, are now enabled by default.

#### Secure Payment Confirmation

[Secure payment confirmation](https://www.chromestatus.com/feature/5702310124584960) augments the payment authentication experience on the web with the help of the [Web Authentication API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Authentication_API). The feature adds a new 'payment' extension to that API, which allows a relying party such as a bank to opt-in to creating a `PublicKeyCredential` that can be queried by any merchant origin as part of an online checkout via the [Payment Request API](https://developer.mozilla.org/en-US/docs/Web/API/Payment_Request_API) using the `'secure-payment-confirmation'` payment method.

This feature enables a consistent, low friction, strong authentication experience using platform authenticators. Strong authentication with the user's bank is becoming a requirement for online payments in many regions, including the European Union. The proposed feature provides a better user experience and stronger security than existing solutions.

#### WebAssembly Exception Handling

WebAssembly [now provides exception handling](https://developer.chrome.com/origintrials/#/view_trial/2393663201947418625) support. Exception handling allows code to break control flow when an exception is thrown. The exception can be any that is known by the WebAssembly module, or it may be an unknown exception that was thrown by a called imported function.

Other Features in this Release
------------------------------

### Adding droppedEntriesCount to PerformanceObserver Callback

Currently, web developers can call `PerformanceObserver.observe()` with the [buffered option](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver/observe#parameters) to listen to past and future performance entries about their site. Unfortunately, past entries need to be stored, and there is a buffer size limit. The `droppedEntriesCount` parameter helps developers know if they may have lost an entry due to storage being full.

[The `droppedEntriesCount` property](https://www.chromestatus.com/feature/5320666234486784) is one of the options specified as the third parameter of the callback passed in the [`PerformanceObserver` constructor](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver/PerformanceObserver). It provides the number of entries dropped due to the buffer being full.

### EyeDropper API

[The EyeDropper API](https://www.chromestatus.com/feature/6304275594477568) provides a browser-supplied eyedropper for the construction of custom color pickers. Creative applications built for the web could benefit from an ability to sample a color from pixels on the screen. Many OS applications, PowerPoint for example, have this ability but are unable to carry it over to their web equivalents.  
  
Even though some browsers have eyedropper capability built into `<input type=color>` elements, web applications are limited in their ability to integrate this into their custom color pickers since the eyedropper is generally accessible only through the non-customizable popup triggered by the `<input>` element.

### New UA platform Version Source on Windows for User Agent Client Hints

Chrome has updated the value [provided by the `Sec-CH-UA-Platform-Version` on Windows](https://www.chromestatus.com/feature/5080939765956608) to provide a reasonable level of fidelity to allow sites to identify meaningful Windows platform changes. This enables sites to deliver appropriate binary executables and help content specific to a particular operating system version. The current user agent string and existing `Sec-CH-UA-Platform-Version` implementation provides the major and minor version Windows components. However, as of Windows 10, Windows generally doesn't increase either of these numbers across significant releases. Notably, Windows 11 does not increase either of these numbers. You can find a table of value mappings to Windows releases in the [UA Client Hints' repo issue 220](https://github.com/WICG/ua-client-hints/commit/5c1be8772eaf3b823c3c07d6baa6d7348a77627d).

### self.reportError()

This function, available in windows and workers, [allows developers to report errors](https://www.chromestatus.com/feature/5634523220934656) to the console and any global "error" event handlers in the same way as an uncaught JavaScript exception. It is mainly useful for custom event-dispatching or callback-manipulating libraries.  
This allows library developers to report exceptions in the same way the browser does, which is useful when they need custom control over running the callback.

### URLPattern

[URLPattern](https://web.dev/urlpattern/) is a new web API that provides operating system support for matching URLs given a pattern string. It can be used in JavaScript directly or by passing patterns to other web platform APIs such as, for example, as a service worker scope. Both web platform features and JavaScript applications often need to match against URLs. Examples include, service worker scopes on the web platform and URL routing in JavaScript frameworks. Past web platform features have individually created their own URL matching mechanisms. JavaScript has relied on libraries such as path-to-regexp.

Deprecations, and Removals
--------------------------

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

### FTP Support Removed

Chrome is [removing support for FTP URLs](https://www.chromestatus.com/feature/6246151319715840). Use of FTP in the browser is sufficiently low that it is no longer viable to invest in improving the existing FTP client. In addition, more capable FTP clients are available on all affected platforms.  
  
Google Chrome 72 and later removed support for fetching document subresources over FTP and rendering of top level FTP resources. Currently navigating to FTP URLs results in showing a directory listing or a download depending on the type of resource. A bug in Google Chrome 74 and later resulted in dropping support for accessing FTP URLs over HTTP proxies. Proxy support for FTP was removed entirely in Google Chrome 76. In Chrome 86 FTP support was turned off for pre-release channels (Canary and Beta) and experimentally turned off for one percent of stable users, though it could be reenabled via the command line. In Chrome 87 it was turned off for fifty percent of users but could also be enabled through the command line. Since Chrome 88, it was only available through a deprecation trial and is now disabled.

### Support for URLs with non-IPv4 Hostnames Ending in Numbers

Most hostnames that aren't valid IPv4 addresses, but end in numbers are treated as valid, and looked up via DNS (for example, `http://foo.127.1/`). Per the Public Suffix List spec, the eTLD+1 of the hostname in that URL should be `127.1`. If that is ever fed back into a URL, `http://127.1/` is mapped to `http://127.0.0.1/` by the URL spec, which seems potentially dangerous. `127.0.0.0.1` could also potentially be used to confuse users. [URLs with these hostnames are now rejected](https://www.chromestatus.com/feature/5679790780579840).

### WebAssembly Cross-Origin Module Sharing

[Chrome now deprecates sharing WebAssembly modules](https://www.chromestatus.com/feature/5650158039597056) between cross-origin, but same-site environments to [allow agent clusters to be scoped to origins long term](https://developer.chrome.com/blog/wasm-module-sharing-restricted-to-same-origin/).

### Deprecate U2F API (Cryptotoken)

Chrome's legacy U2F API for interacting with security keys is deprecated and beginning a deprecation trial in Chrome 95 wherein the API remains enabled by default, but the trial token will disable the key for participating sites. U2F security keys themselves are not deprecated and will continue to work.

Affected sites should migrate to the [Web Authentication API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Authentication_API). Credentials that were originally registered via the U2F API can be challenged via web authentication. USB security keys that are supported by the U2F API are also supported by the Web Authentication API.

U2F is Chrome's original security key API. It allows sites to register public key credentials on USB security keys and challenge them for building phishing-resistant two-factor authentication systems. U2F never became an open web standard and was subsumed by the Web Authentication API (launched in Chrome 67). Chrome never directly supported the FIDO U2F JavaScript API, but rather shipped a component extension called cryptotoken, which exposes an equivalent `chrome.runtime.sendMessage()` method. U2F and Cryptotoken are firmly in maintenance mode and have encouraged sites to migrate to the Web Authentication API for the last two years.

The following timeline is currently planned for deprecation and removal:

#### Chrome 93

Stable as of August 31, 2021. Support added for the googleLegacyAppIdSupport extension.

#### Chrome 95

Beta as of September 23, 2021. The following changes were implemented:

* Gated U2F API requests behind a user permission prompt.
* Logged a deprecation notice in the DevTools console for every request.

#### Chrome 98

Beta expected in early January 2022, stable in February. The deprecation trial will continue, but its behavior will reverse: the API will be disabled by default, but may be kept alive by trial participants.

#### Chrome 103

Beta expected in late May 2022, stable in late June. The deprecation trial will end.

#### Chrome 104

Beta expected in late June 2022, stable in early August. The  U2F API will be fully removed.