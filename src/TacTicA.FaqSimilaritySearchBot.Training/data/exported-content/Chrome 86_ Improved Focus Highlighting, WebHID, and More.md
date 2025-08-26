URL:https://blog.chromium.org/2020/09/chrome-86-improved-focus-highlighting.html
# Chrome 86: Improved Focus Highlighting, WebHID, and More
- **Published**: 2020-09-03T15:14:00.003-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 86 is beta as of September 3, 2020.

CSS Pseudo-Class: focus-visible and the Quick Focus Highlight
-------------------------------------------------------------

For users who rely on a keyboard or similar assistive technology to navigate the web, the focus indicator is a crucial visual affordance. To improve both the user and developer experience of working with focus, Chrome 86 is introducing two features.

The first is a CSS selector, :focus-visible, which lets a developer opt-in to the same heuristic the browser uses when it's deciding whether to display a default focus indicator.

The second is a user setting called Quick Focus Highlight. When enabled, this setting causes an additional focus indicator to appear over the active element. Importantly, this indicator will be visible even if the page has disabled focus styles with CSS and it causes any :focus or :focus-visible styles to always be displayed. For details, see [Giving users and developers more control over focus](https://blog.chromium.org/2020/09/giving-users-and-developers-more.html).

![An animation of the quick focus highlight showing how it temporarily highlights a link in a line of text and then fades out to not obscure the text content.](https://lh3.googleusercontent.com/wdnRyP2HviHI6UiFh-aCkVzNGzk0NWouNBV5ELT7nT8dXFi1jbnSGPFygFpgjZFU89SI7_rXrgsUrg6OoUMHUsedyduot403v1t1vkZuStYZ-yYroHCUFi0ZXfChKUiFSQUWslJE9w)

WebHID API
----------

**Note:** The origin trial for this feature was originally announced as starting in Chrome 85. That timeline changed.

There is a long tail of human interface devices (HIDs) that are too new, too old, or too uncommon to be accessible by systems' device drivers. The WebHID API solves this by providing a way to implement device-specific logic in JavaScript.

An HID is one that takes input from or provides output to humans. Examples of devices include keyboards, pointing devices (mice, touchscreens, etc.), and gamepads.

The inability to access uncommon or unusual HID devices is particularly painful when it comes to gamepad support. Gamepad inputs and outputs are not well standardized and web browsers often require custom logic for specific devices. This is unsustainable and results in poor support for the long tail of older and uncommon devices.

We're working on an article to show you how to use the new API. In the meantime, we've found some demos from a few eager engineers that you can use to try the new API. To see those demos, check out [Human interface devices on the web: a few quick examples](https://www.blogger.com/blog/post/edit/2471378914199150966/6731598246400651105). The [Origin Trials section](https://www.blogger.com/blog/post/edit/2471378914199150966/6731598246400651105) has information on signing up and a list of other origin trials starting in this release. This origin trial is expected to run through Chrome 87 in January 2021.

Origin Trials
-------------

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).

### New Origin Trials

#### Cross-Screen Window Placement

Adds new [screen information APIs](https://developers.chrome.com/origintrials/#/view_trial/1411878483180650497) and makes incremental improvements to existing window placement APIs, allowing web applications to offer compelling multi-screen experiences.

The existing [window.screen property](https://developer.mozilla.org/en-US/docs/Web/API/Window/screen) offers a limited view of available screen space, while window placement functions are generally restricted to the current screen. This feature unlocks modern multi-screen capabilities for web applications.

#### battery-savings Meta Tag

[Adds a meta tag](https://developers.chrome.com/origintrials/#/view_trial/4114038259602948097) allowing a site to recommend measures for the user agent to apply in order to save battery life and optimize CPU usage. Websites that are known to have high CPU or battery costs may want to request that the UA optimize for CPU or battery, even if the user has not requested it. Most modern operating systems also have battery saving features that activate either when the battery is low or the user wishes to save battery. Ideally web sites should be able to respect these settings. Sites may wish to advise the user agent on which strategies work best for the site in these situations.

#### Secure Payment Confirmation

[Secure payment confirmation](https://developers.chrome.com/origintrials/#/view_trial/42784196460019713) augments the payment authentication experience on the web with the help of the [Web Authentication API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Authentication_API). The feature adds a new PaymentCredential credential type to the [Credential Management API](https://developer.mozilla.org/en-US/docs/Web/API/Credential_Management_API), which allows a relying party such as a bank to create a PublicKeyCredential that can be queried by any merchant origin as part of an online checkout via the [Payment Request API](https://developer.mozilla.org/en-US/docs/Web/API/Payment_Request_API) using the proposed secure-payment-confirmation payment method.

This feature enables a consistent, low friction, strong authentication experience using platform authenticators. Strong authentication with the user's bank is becoming a requirement for online payments in many regions, including the European Union. The new feature provides a better user experience and stronger security than existing solutions.

#### Cross-Origin-Opener-Policy Reporting API

Adds a reporting API to [help developers deploy cross-origin opener policy](https://developers.chrome.com/origintrials/#/view_trial/2780972769901281281) (COOP) on their websites. In addition to reporting breakages when COOP is enforced, it proves a report-only mode that reports potential breakages that would have happened had COOP been enforced. To register for the origin trial, follow the link above. For more information, see [Making your website "cross-origin isolated" using COOP and COEP](https://web.dev/coop-coep/).

### Completed Origin Trials

The following features, previously in a Chrome origin trial, are now enabled by default.

#### Native File System

The new Native File System API enables developers to build powerful web apps that interact with files on the user's local device such as IDEs, photo and video editors, text editors, and more. After a user grants access, this API allows web apps to read or save changes directly to files and folders on the user's device. It does all this by invoking the platform's own open and save dialog boxes. The image below shows a web page invoked using the open dialog box on Mac.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiKvel8L36VOa_0TJ-XZqGa1XunSXfUmCrzM9m5hSQpQLzvn4EXrsgwW0ZjUqlIk59AWgLWQw8J1wzfLfHKVMkygNMVlUPlwWs61ACTRgALdCnpckldA7kmRVErDxfUQ0IdwjBJG0iUVldM/w640-h462/native-file-system.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiKvel8L36VOa_0TJ-XZqGa1XunSXfUmCrzM9m5hSQpQLzvn4EXrsgwW0ZjUqlIk59AWgLWQw8J1wzfLfHKVMkygNMVlUPlwWs61ACTRgALdCnpckldA7kmRVErDxfUQ0IdwjBJG0iUVldM/s1081/native-file-system.png)

To learn more, see sample code, and a text editor demonstration app, see [The Native File System API: Simplifying access to local files](https://web.dev/native-file-system/) for details.

**Note:** The API surface is changed considerably from what was available in the origin trial. Differences are [explained in detail](https://github.com/WICG/native-file-system/blob/master/changes.md) in the spec repo. In the coming weeks, watch the web.dev article listed above for a full explanation of how to use the production version of the API.

Other Features in This Release
------------------------------

### Altitude and Azimuth for PointerEvents v3

[Adds Altitude and Azimuth angles to PointerEvents](https://www.chromestatus.com/feature/5731966710185984). Adds tiltX and tiltY to altitude and azimuth transformation and altitude and azimuth to tiltX and tiltY transformation depending on which pair is available from the device. These angles are those commonly measured by devices. Altitude and azimuth can be calculated using trigonometry from tiltX, tiltY. From a hardware perspective it is easier and less expensive to measure tiltX and tiltY.

From a stylus app perspective altitude and azimuth makes more sense and is more intuitive for users. Using tiltX and tiltY requires a developer to visualize the intersection angle between two imaginary planes, while azimuth and altitude are easier to visualize just by looking at the pen and the screen surface.

Adding azimuth and altitude makes the API more intuitive. Providing conversion between tiltX and tiltY and altitude and azimuth and vice versa allows for backwards compatibility with apps using tiltX and tiltY (even if newer devices might only return altitude and azimuth).

### A Well-Known URL for Changing Passwords

**Note:** this was erroneously listed as shipping in Chrome 86. It is actually shipping in Chrome 87.

Websites can set [a well-known URL for changing passwords](https://www.blogger.com/blog/post/edit/2471378914199150966/5647775477348732729) (for example, /.well-known/change-password). This URL's purpose is to redirect users to the change password page in order for them to modify their passwords quickly. Chrome leverages this URL to help users change their passwords when it detects a saved, compromised password. For more information, see [Help users change passwords easily by adding a well-known URL for changing passwords](https://www.blogger.com/blog/post/edit/2471378914199150966/5647775477348732729).

### Change Encoding of Space Character when URLs are Computed by Custom Protocol Handlers

The navigator.registerProtocolHandler() handler [now replaces spaces](https://www.chromestatus.com/feature/5678518908223488) with "%20" instead of "+". This makes Chrome consistent with other browsers such as Firefox.

### CSS ::marker Pseudo-Element

Adds [a pseudo-element for customizing numbers and bullets](https://web.dev/css-marker-pseudo-element/) for <ul> and <ol> elements. This change lets developers control the color, size, bullet shape, and number type.

### Document-Policy Header

[Document Policy](https://www.chromestatus.com/feature/5756689661820928) restricts the surface area of the web platform on a per-document basis, similar to iframe sandboxing, but more flexibly. It can do things like:

* Restrict the use of poorly-performing images.
* Disable slow synchronous JavaScript APIs.
* Configure iframe, image, or script loading styles.
* Restrict overall document sizes or network usage.
* Restrict patterns which cause page re-layout.

Additionally, the header allows sites to opt out of fragment and text-fragment scrolling on load as a privacy mitigation for the scroll-to-text-fragment feature. This is the first part of the Document Policy API to ship.

### EME persistent-usage-record Session

Adds [a new MediaKeySessionType](https://www.chromestatus.com/feature/5638708017496064) named "persistent-usage-record session", for which the license and keys are not persisted and for which a record of key usage is persisted when the keys available within the session are destroyed. This feature may help content providers understand how decryption keys are used for purposes like fraud detection.

### FetchEvent.handled

A FetchEvent dispatched to a service worker is in a loading pipeline, which is performance sensitive. The new [FetchEvent.handled property](https://www.chromestatus.com/feature/5654467158474752) returns a promise that resolves when a response is returned from a service worker to its client. This enables a service worker to delay tasks that can only run after responses are complete.

### HTMLMediaElement.preservesPitch

Adds a property to determine whether the pitch of an audio or video element should be [preserved when adjusting the playback rate](https://www.chromestatus.com/feature/5742134990733312). This feature is wanted for creative purposes (for example, pitch-shifting in "DJ deck" style applications). It also prevents the introduction of artifacts from pitch-preserving algorithms at playback speeds very close to 1.00. It is already supported by Safari and Firefox.

### Imperative Shadow DOM Distribution API

Web developers can now [explicitly set the assigned nodes](https://www.chromestatus.com/feature/5711021289242624) for a slot element. This solves two problems with Shadow DOM v1:

* Web developers must specify a slot attribute for every one of a shadow host's children (except for elements for the default slot).
* Component creators can't change the slotting behavior based on conditions.

For information on how the new API solves these issues, see the [Imperative Shadow DOM Distribution API explainer](https://github.com/w3c/webcomponents/blob/gh-pages/proposals/Imperative-Shadow-DOM-Distribution-API.md).

### Move window.location.fragmentDirective

The window.location.fragmentDirective property [has been moved](https://www.chromestatus.com/feature/5679640498667520) to document.fragmentDirective. This is a change to the [text fragments feature](https://web.dev/text-fragments/).

### New Display Values for the <fieldset> Element

[The <fieldset> element now supports](https://www.chromestatus.com/feature/5962796351094784) 'inline-grid', 'grid', 'inline-flex', and 'flex' keywords for the CSS 'display' property.

### ParentNode.replaceChildren() Method

Adds [a method to replace all children](https://www.chromestatus.com/feature/6143552666992640) of the ParentNode with the passed-in nodes. Previously, there are a couple different ways to replace a node's children with a new set of nodes including:

* Using node.innerHTML and node.append() to clear and replace all child nodes.
* Using node.removeChild() and node.append() in a loop.

### Safelist Distributed Web Schemes for registerProtocolHandler()

Chrome has extended the list of URL schemes that can be overridden via registerProtocolHandler() to include cabal, dat, did, dweb, ethereum, hyper, ipfs, ipns, and ssb. Extending the list to include decentralized web protocols allows resolution of links to generic entities independently of the website or gateway that's providing access to it. For more information, see [Programmable Custom Protocol Handlers](https://arewedistributedyet.com/programmable-custom-protocol-handlers/) at [are we distributed yet?](https://arewedistributedyet.com/)

### text/html Support for the Asynchronous Clipboard API

The [Asynchronous Clipboard API](https://web.dev/async-clipboard/) currently does not support the text/html format. Chrome 86 adds support for [copying and pasting HTML](https://www.chromestatus.com/feature/5357049665814528) from the clipboard. The HTML is sanitized when it is read and written to the clipboard. The purpose of this change is to allow use cases such as:

* Web editors, to copy and paste rich text with images and links.
* Remote desktop applications, to synchronize text/html payloads across devices.

This is also intended to help the replacement of document.execCommand() for copy and paste functionality.

### VP9 for macOS Big Sur

The VP9 video codec is now available on macOS Big Sur whenever it's supported in the underlying hardware. If developers [use the Media Capabilities API](https://web.dev/youtube-media-capabilities/) to detect playback smoothness and power efficiency, the logic in their player should automatically start preferring VP9 at higher resolutions without any action on their part. To take full advantage of this feature, developers should encode their VP9 files in multiple resolutions to accommodate varying user bandwidths and connections.

### WebRTC Insertable Streams

Enables the [insertion of user-defined processing steps](https://www.chromestatus.com/features/6321945865879552) in the encoding and decoding of a WebRTC MediaStreamTrack. This allows applications to insert custom data processing. An important use case this supports is end-to-end encryption of the encoded data transferred between RTCPeerConnections via an intermediate server.

Deprecations, and Removals
--------------------------

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

### Remove WebComponents v0 from WebView

Web Components v0 was removed from desktop and Android in Chrome 80. Chromium 86 removes them from WebView. This removal includes [Custom Elements v0](https://www.chromestatus.com/feature/4642138092470272), [Shadow DOM v0](https://www.chromestatus.com/feature/4507242028072960), and [HTML Imports](https://www.chromestatus.com/feature/5144752345317376).

### Deprecate FTP Support

Chrome is deprecating and removing support for FTP URLs. The current FTP implementation in Google Chrome has no support for encrypted connections (FTPS), or proxies. Usage of FTP in the browser is sufficiently low that it is no longer viable to invest in improving the existing FTP client. In addition, more capable FTP clients are available on all affected platforms.

Chrome 72 and later removed support for fetching document subresources over FTP and rendering of top level FTP resources. Currently navigating to FTP URLs results in showing a directory listing or a download depending on the type of resource. A bug in Google Chrome 74 and later resulted in dropping support for accessing FTP URLs over HTTP proxies. Proxy support for FTP was removed entirely in Google Chrome 76.

The remaining capabilities of Google Chrome's FTP implementation are restricted to either displaying a directory listing or downloading a resource over unencrypted connections.

Deprecation of support will follow this timeline:

#### Chrome 86

FTP is still enabled by default for most users, but turned off for pre-release channels (Canary and Beta) and will be experimentally turned off for one percent of stable users. In this version you can re-enable it from the command line using either the --enable-ftp command line flag or the --enable-features=FtpProtocol flag.

#### Chrome 87

FTP support will be disabled by default for fifty percent of users but can be enabled using the flags listed above.

#### Chrome 88

FTP support will be disabled.