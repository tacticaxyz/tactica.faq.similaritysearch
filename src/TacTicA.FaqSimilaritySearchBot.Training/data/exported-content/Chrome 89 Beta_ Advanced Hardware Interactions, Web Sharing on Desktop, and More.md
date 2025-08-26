URL:https://blog.chromium.org/2021/01/chrome-89-beta-advanced-hardware.html
# Chrome 89 Beta: Advanced Hardware Interactions, Web Sharing on Desktop, and More
- **Published**: 2021-01-28T11:40:00.006-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D89). Chrome 89 is beta as of January 28, 2021.

WebHID API
==========

There is a long tail of human interface devices (HIDs) that are too new, too old, or too uncommon to be accessible by systems' device drivers. The WebHID API solves this by providing a way to implement device-specific logic in JavaScript.

A human interface device is one that takes input from or provides output to humans. Examples of devices include keyboards, pointing devices (mice, touchscreens, etc.), and gamepads.

The inability to access uncommon or unusual HID devices is particularly painful, for example, when it comes to gamepad support. Gamepad inputs and outputs are not well standardized and web browsers often require custom logic for specific devices. This is unsustainable and results in poor support for the long tail of older and uncommon devices.

With its origin trial over, WebHID is enabled by default in Chrome 89 on desktop. To learn how to use it, check out [Connecting to uncommon HID devices](https://web.dev/hid/), and see demos in [Human interface devices on the web: a few quick examples](https://web.dev/hid-examples).

Web NFC
=======

NFC stands for Near Field Communications, a short-range wireless technology for transmitting small amounts of data, usually between a specialized NFC device and a reader. If you've scanned a badge to enter a building, you may have used NFC.

Web NFC allows a web app to read from and write to NFC tags. This opens new use cases to the web, including providing information about museum exhibits, inventory management, providing information in a conference badge, and many others. In Chrome 89 on Android, Web NFC is enabled by default.

![](https://lh6.googleusercontent.com/VlnOVtjnGZY0xdkA__MVrqrm62y0hVs8-qsW17ZDlc9PhKBDpMHjZ4x0grAPEVgF6MGf80H2FQNrBhPvKaq4-QkA6ddk29bpZj8mNnnSiBsCBq9MidJy6xT5aVfIAbf5-pXduFTDE6wmAQ6cJlw6PJRnRcr8O7y3TRu7V_DGFBEmqqrw)

*Web NFC cards demo at Chrome Dev Summit*

With NFC reading and writing are simple operations. You'll need a little instruction for constructing and interpreting payloads, but it's not complicated. Fortunately, we have an article, [Interact with NFC devices on the web](https://web.dev/nfc). Check it out. We have [some samples](https://googlechrome.github.io/samples/web-nfc/) you can play with. Here's a taste:

Writing a string to an NFC tag:

```` ```
if ("NDEFReader" in window) {
  const ndef = new NDEFReader();
  await ndef.write("Hello world!");
}
``` ````

Scanning messages from NFC tags:

```` ```
if ("NDEFReader" in window) {
  const ndef = new NDEFReader();
  await ndef.scan();
  ndef.onreading = ({ message }) => {
    console.log(`Records read from a NFC tag: ${message.records.length}`);
  };
}
``` ````

Web Serial API
==============

A serial port is a bidirectional communication interface that allows sending and receiving data byte by byte. The Web Serial API brings this capability to websites, letting them control devices such as microcontrollers and 3D printers.

In educational, hobbyist, and industrial settings, peripheral devices are already controlled through web pages. In all such cases device control requires installation of adapters and drivers. The Web Serial API improves the user experience by enabling direct communication between a website and a peripheral.

Its origin trial is over and the Web Serial API is now enabled on desktop. A [demo is available](https://googlechromelabs.github.io/serial-terminal/) on GitHub. For information about using it, see [Read to and write from a serial port](https://web.dev/serial/).

Web Sharing on Desktop
======================

To allow users to easily share content on social networks, developers have manually integrated sharing buttons into their site for each social service. This often leads to users not being able to share with the services they actually use, in addition to bloated page sizes and security risks from third-party code. On the receiving end, only platform apps could register to be share targets and receive shares from other apps.

Chrome for Android started adding these features between Chrome 61 and 75. In Chrome 89, web sharing is available on Windows and ChromeOS, while registering as a share target is supported on ChromeOS. On these platforms, sites can now use `navigator.share()` on desktop to trigger a share dialog box. And an entry to the web app manifest allows a PWA to act as a share target.

For information on web sharing, see [Integrate with the OS sharing UI with the Web Share API](https://web.dev/web-share/). To learn to configure a PWA as a share target, see [Receiving shared data with the Web Share Target API](https://web.dev/web-share-target/).

Origin Trials
=============

There are no new origin trials in this version of Chrome. To register for current origin trials, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).

Other features in this release
==============================

AVIF Image Decode
-----------------

Chrome now supports [decoding AVIF content](https://www.chromestatus.com/feature/4905307790639104) natively using existing AV1 decoders on Android and WebView. (Desktop support was added in Chrome 85.) AVIF is a next generation image format standardized by the [Alliance for Open Media](https://aomedia.org/). There are three primary motivations for supporting AVIF:

* Reducing bandwidth consumption to load pages faster and reduce overall data consumption. AVIF offers significant file size reduction for images compared with JPEG or WebP.
* Adding HDR color support. AVIF is a path to HDR image support for the web. JPEG is limited in practice to 8-bit color depth. With displays increasingly capable of higher brightness, color bit depth, and color gamuts, web stakeholders are increasingly interested in preserving image data that is lost with JPEG.
* Supporting ecosystem interest. Companies with a large web presence have expressed an interest in shipping AVIF images on the web.

Cross-origin opener policy reporting API
----------------------------------------

[A new reporting API](https://www.chromestatus.com/feature/5755687994916864) helps developers deploy [cross-origin opener policy](https://web.dev/coop-coep/). In addition to reporting breakages when COOP is enforced, the API provides a report-only mode for COOP. The report-only mode for COOP will not enforce COOP, but it will report potential breakages that would have happened had we enforced COOP. Developers can inspect the [reporting API](https://developers.google.com/web/updates/2020/10/devtools#frame-details) with Chrome DevTools.

Display override in web app manifests
-------------------------------------

The new `display_override` field for the web app manifest allows developers to specify an explicit fallback chain for the `display` field. The following example specifies a `"minimal-ui"`, falling back to `"standalone"`.

```` ```
{
  "display": "standalone",
  "display_override": ["minimal-ui"],
}
``` ````

This API is intended for advanced use cases and display modes, and its capabilities are limited. You can learn more in its [Chrome Status entry](https://www.chromestatus.com/feature/5728570678706176).

Expose ReadableStreamDefaultController interface
------------------------------------------------

Chrome now [exposes the `ReadableStreamDefaultController` interface on the global object](https://www.chromestatus.com/feature/5711333280448512), as with the other ReadableStream-related classes. This eliminates a previous limitation where instances had to be created inside stream constructors.

performance.measureUserAgentSpecificMemory()
--------------------------------------------

The feature adds a [`performance.measureUserAgentSpecificMemory()` function](https://www.chromestatus.com/feature/5685965186138112) which estimates the memory usage of the web page. The method is gated behind COOP/COEP thus the web site needs to be [cross-origin isolated](https://web.dev/why-coop-coep/) to use it.

Potentially trustworthy data: urls
----------------------------------

To conform to current web standards, Chrome now [treats all data: urls as potentially trustworthy](https://www.chromestatus.com/feature/5634194258526208).   
For background, It's often necessary to evaluate whether a URL is secure in order to only enable certain features when minimum standards of authentication and confidentiality are met. For that purpose, web standards rely on the definition of "potentially trustworthy URL", which includes URLs with the "data" scheme in the latest version of the Secure Contexts specification. Blink previously only treated some data: URLs as potential trustworthy.

Streams API: Byte Streams
-------------------------

The streams APIs provide ubiquitous, interoperable primitives for creating, composing, and consuming streams of data. For streams representing bytes, Chrome now supports [an extended version of the readable stream](https://www.chromestatus.com/feature/4535319661641728) to handle bytes efficiently, specifically by minimizing copies.

Byte streams allow for Bring Your Own Buffer (BYOB) readers to be acquired. The default implementation can give a range of different outputs such as strings or array buffers in the case of web sockets, whereas byte streams guarantee byte output. Furthermore, being able to have BYOB readers has stability benefits. This is because if a buffer detaches, there's now a guarantee that the same buffer won't be written to twice, hence avoiding race conditions. BYOB readers also do not need to garbage collect for every read, because buffers are reused.

Support for full 'filter' property syntax on SVG elements
---------------------------------------------------------

Chrome now [allows the full syntax of the `'filter'` property](https://www.chromestatus.com/feature/5076637643177984) to be used on SVG elements which previously only supported single `url()` references. This lets filter functions such as `blur()`, `sepia()` and `grayscale()` apply to both SVG elements and non-SVG elements. It makes the platform support for `'filter'` more uniform and allows for easier application of some "canned" effects. Without this feature developers need to use a full SVG `<filter>` element definition even for basic filters such as `grayscale()` or `blur()`.

WebAuthentication API: ResidentKeyRequirement and credProps extension
---------------------------------------------------------------------

Chrome now supports [two new features related to the Web Authentication API](https://www.chromestatus.com/feature/5701094648840192). The `AuthenticatorSelectionCriteria.residentKey` property specifies for web authentication credential registration whether a client-side discoverable credential should be created.

The Web Authentication `credProps` extension indicates to the relying party whether a created credential is client-side discoverable. "Client-side discoverable credentials" are a type of WebAuthn credential that can be challenged by a relying party without needing to provide the credential ID in the WebAuthn API request. Browsers display a list of all discoverable credentials from a given authenticator (either external security key or built-in) and let the user choose one to sign in with.

CSS
===

::target-text pseudo-element
----------------------------

Adds [a highlight pseudo element](https://www.chromestatus.com/feature/5689463273422848) to allow authors to style [`scroll-to-text` fragments](https://chromestatus.com/feature/4733392803332096) differently from the default user agent highlighting.

flow-relative Corner Rounding properties
----------------------------------------

[Flow-relative corner rounding properties](https://www.chromestatus.com/feature/5631002091192320) now allow control of corners using logical mappings rather than physical properties. Additionally, this allows authors to set different corner border radii depending on the direction and writing mode of the page.This brings Chrome in line with the [CSS Logical Properties and Values](https://drafts.csswg.org/css-logical/) spec. The following logical properties have been added:

* `border-start-start-radius`
* `border-start-end-radius`
* `border-end-start-radius`
* `border-end-end-radius`

Forced colors property
----------------------

[The `forced-colors` media feature](https://www.chromestatus.com/feature/5757293075365888) detects whether the user agent is enforcing a user-chosen limited color palette on the page.

Forced colors adjust property
-----------------------------

[The `forced-color-adjust` property](https://www.chromestatus.com/feature/5757293075365888) allows authors to opt particular elements out of forced colors mode, restoring full control over the colors to CSS.

JavaScript
==========

This version of Chrome incorporates version 8.9 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

Top-level await
---------------

Chrome now [allows the `await` keyword at the top level](https://www.chromestatus.com/feature/5767881411264512) within JavaScript modules. This allows more seamless integration of asynchronous calls into the module loading process. Today this is accomplished by wrapping modules in async functions, but this pushes complexity into dependent modules and exposes implementation details.

Developer Notes
===============

Image Orientation with EXIF
---------------------------

EXIF information is now always used to [orient cross-origin images](https://bugs.chromium.org/p/chromium/issues/detail?id=1110330). That is, setting `image-orientation: none` in CSS has no effect on non-secure-origin images. The spec discussion behind the change is available in [a CSS working group draft](https://github.com/w3c/csswg-drafts/issues/5165).

Deprecations and Removals
=========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Remove prefixed events for <link rel=prerender>
-----------------------------------------------

The legacy prefixed events (`webkitprerenderstart`, `webkitprerenderstop`, `webkitprerenderload`, and `webkitprerenderdomcontentloaded`) dispatched on `<link rel=prerender>` [are now removed from Chrome](https://www.chromestatus.com/feature/4925917174431744).

Stop cloning sessionStorage for windows opened with noopener
------------------------------------------------------------

When a window is opened with noopener, Chrome will [no longer clone the `sessionStorage`](https://www.chromestatus.com/feature/5679997870145536) of its opener; it will instead start an empty `sessionStorage` namespace. This brings Chrome in conformance with the HTML specification.