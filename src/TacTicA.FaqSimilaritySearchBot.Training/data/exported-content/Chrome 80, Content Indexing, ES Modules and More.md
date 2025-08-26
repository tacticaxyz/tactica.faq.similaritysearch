URL:https://blog.chromium.org/2019/12/chrome-80-content-indexing-es-modules.html
# Chrome 80, Content Indexing, ES Modules and More
- **Published**: 2019-12-19T12:36:00.002-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D80). Chrome 80 is beta as of December 19, 2019.  

Content Indexing
================

![](https://lh5.googleusercontent.com/tkanWDKiU0jTm_ovD1MMjiV9cMX_XPexDY5_kyiZwScsnlPblj-wZUfWOax8aBAuzY3xl7h8tS4x92npA8UDJiKXH7jJfXTnehfU-g08RPbDZS8I-T62Dqzkrc5-3vN-UzCsXgAg)  
A progressive web app can store content such as images, videos, articles, and more for offline access using the [Cache Storage API](https://developers.google.com/web/fundamentals/instant-and-offline/web-storage/cache-api) or [IndexedDB](https://developer.mozilla.org/en-US/docs/Web/API/IndexedDB_API). But how do users discover this content? How do they know that they can consume or use it, even when a network is unavailable?  
  
The Content Indexing API provides metadata about content that your web app has already cached. More specifically, it stores URLs for HTML documents that display stored media. The new API lets you add, list, and remove resources. Browsers can use the information in the index to display a list of offline-capable content. Here's what it looks like in Chrome 80.  
  
The Content Indexing API is in an origin trial from Chrome 80 to Chrome 82. For details about the API, see [Experimenting with the Content Indexing API](https://web.dev/content-indexing-api/). See the Origin Trials section for information on signing up and for a list of other origin trials starting in this release.  

ECMAScript Modules in Web Workers
=================================

Web Workers have been available in most browsers for more than ten years. Consequently, the method for importing modules into a worker, `importScripts()`, has not been state of the art for some time. It blocks execution of the worker while it fetches and evaluates the imported script. It also executes scripts in the global scope, which can lead to name collisions and its associated problems.  
  
Enter Module Workers. The Worker constructor now supports a `type` option with the value `"module"`, which changes script loading and execution to match `<script type="module">`.   
  
  

```
const worker = new Worker('worker.js', {
  type: 'module'
});
```

  
Module Workers support standard JavaScript imports and dynamic import for lazy-loading without blocking worker execution. For background and details see [ES Modules in Web Workers](https://web.dev/module-workers/).  

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).  

New Properties for the Contact Picker
-------------------------------------

This version of Chrome is shipping the [Contact Picker API](https://web.dev/contact-picker/), ending an origin trial that started in Chrome 77. (More on that below.) At the same time it's starting a new origin trial that adds features to that API. Before requesting that a user select contacts, an app must specify which data it wants back. Currently, only the contact's name, email address, and telephone number are available. The new origin trial adds to this the user's mailing address (`'address'`) and image (`'icon'`).  

Other features in this release
==============================

Autoupgrade Mixed Content
-------------------------

Chrome is now [auto-upgrading HTTP content in HTTPS sites](https://www.chromestatus.com/feature/5557268741357568) by rewriting URLs to HTTPS without falling back to HTTP when secure content is not available. In this version of Chrome only audio and video content are so treated.  

Compression Streams
-------------------

JavaScript can now [perform gzip and deflate compression](https://chromestatus.com/feature/5855937971617792) using streams. This covers two interfaces: `CompressionStream` and `DecompressionStream`.  
  
It is possible to compress stream data without this feature, but common libraries like zlib are complex to use. Compression streams make it easy for developers to compress data, and avoid the need to bundle a compressor with an application.  

Contact Picker API
------------------

The Contact Picker API is a new, on-demand picker for Android Chrome that allows users to select entries from their contact list and share limited details of the selected entries with a website. It allows users to share only what they want, when they want, and makes it easier for users to reach and connect with their friends and family. See [A Contact Picker for the Web](https://web.dev/contact-picker/) for details. Additionally, a new origin trial adds members to the properties that may be returned by `ContactsManager.getProperties()`. See the [Origin Trials](https://www.blogger.com/blogger.g?blogID=2471378914199150966#Content-Indexing) section, above, for details.  
  

Cookie updates
--------------

The SameSite attribute was introduced in Chrome 51 and Firefox 60 to allow sites to declare whether cookies should be restricted to a same-site (sometimes called first-party) context, mitigating the risk of cross-site request forgeries (CSRF).  
  
In Chrome 80, the backward compatible behaviors described below are removed. For more on these features, read [SameSite cookies explained](https://web.dev/samesite-cookies-explained).  

#### Disallow defaulting of SameSite attribute to 'None'

The SameSite attribute now defaults to Lax meaning your cookies are only available to other sites from top-level navigations. As originally implemented in Chrome, the SameSite attribute defaults to None, which was essentially the Web's status quo. Cookies have valid cross-site use cases, but if a site owner did not previously want to allow cross-site cookie use there was no way to declare such an intent or enforce it.  

#### Value 'None' no longer allowed on insecure contexts

Chrome now requires that when the SameSite attribute is set to None, that the Secure attribute must also be present. The Secure attribute requires that the attached cookie can only be transmitted over a secure protocol such as HTTPS.  

CSS Improvements
----------------

#### line-break: anywhere

The `line-break: anywhere` declaration allows soft wrapping around every typographic character unit, including around any punctuation character or preserved spaces, or in the middles of words. It disregards any prohibition against line breaks, even those introduced by characters with the GL, WJ, or ZWJ character class (see [UAX 14](https://unicode.org/reports/tr14/)) or mandated by the word-break property.  

#### overflow-wrap: anywhere

The `overflow-wrap: anywhere` declaration allows an otherwise unbreakable sequence of characters to be broken at an arbitrary point if there are no otherwise-acceptable break points in a line. Additionally, soft wrap opportunities introduced by `anywhere` are considered when calculating min-content intrinsic sizes.  

Decoding Encrypted Media
------------------------

The capabilities of `MediaCapabilities.decodingInfo()`are now available for encrypted media. The `decodingInfo()` method (available in [multiple browsers](https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilities/decodingInfo#Browser_compatibility)) allows websites to get more information about the decoding abilities of the client. This enables more informed selection of media streams for the user, enabling scenarios such as smoothly and power-efficiently decoding a video for the available bandwidth and screen size.  

Delegating Shipping Address and Contact Information in Web Payments
-------------------------------------------------------------------

The Payment Handler API now [lets the browser delegate handling](https://www.chromestatus.com/feature/5660404216758272) of the shipping address and payer's contact information to Payment Handlers. Delegating collection of the shipping address and contact information to payment handlers can lead to better user experiences because the payment app may have more accurate information than the browser. It can also reduce the checkout steps by one since the browser can show the payment handler window directly rather than showing the payment sheet UI first to collect shipping address and/or payer's contact information. To keep updated on other technical updates around Payment Request API / Payment Handler API on Chrome, [subscribe to paymentrequest@chromium.org](https://groups.google.com/a/chromium.org/forum/#!forum/paymentrequest).  

Fetch Metadata Destination header
---------------------------------

Chrome now supports the `Sec-Fetch-Dest` HTTP request header which exposes a request's destination to a server, providing it with information on which to base security decisions. The spec provides [a list of its possible values](https://w3c.github.io/webappsec-fetch-metadata/#sec-fetch-dest-header).  

HTMLVideoElement.getVideoPlaybackQuality()
------------------------------------------

This method retrieves [information about video playback performance](https://www.chromestatus.com/feature/5687791428042752). Such information may be used to alter bitrate, framerate, or resolution, either upward or downward, to provide a better user experience.  

JavaScript optional chaining
----------------------------

Provides [safe access to descendent object members](https://v8.dev/features/optional-chaining) with parents that may or may not be null. This applies to objects as well as functions. For example, consider an object reference with three levels such as a.b.c. Testing for the existence of c would previously require nesting said test inside a test for b. This change allows you to test for c directly without an error being thrown when b is null.  

Nullish coalescing
------------------

Adds [support for the 'nullish' operator](https://v8.dev/features/nullish-coalescing) to JS.  

Offscreen Canvases Now Support getTransform()
---------------------------------------------

The `OffscreenCanvasRenderingContext2D` [now supports `getTransform()`](https://www.chromestatus.com/feature/5092323908124672). Like its `CanvasRenderingContext2D` counterpart, this method lets you retrieve the transformation matrix that is currently applied to the context.  

Support for SVG in favicons
---------------------------

Chrome now supports [using SVG images as favicons](https://www.chromestatus.com/feature/5180316371124224). Scalable formats for favicons reduce the resources for a website or app. For example, a website could have one (or more) hand-tuned icons for small sizes and use a scalable icon as a catch-all.  

Text URL Fragments
------------------

Users or authors [can now link to a specific portion](https://github.com/WICG/ScrollToTextFragment) of a page using a text fragment provided in a URL. When the page is loaded, the browser highlights the text and scrolls the fragment into view. For example, the URL below loads a wiki page for 'Cat' and scrolls to the content listed in the `text` parameter.  
  
  

```
https://en.example.org/wiki/Cat#:~:text=On islands, birds can contribute as much as 60% of a cat's diet
```

  

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22). The descriptions here are just a summary of what's being deprecated and removed. You can find longer descriptions of all these items and replacements and remediations in Deprecations and removals in Chrome 80.  

Disallow Popups During Page Unload
----------------------------------

Pages may no longer use the `window.open()` method to [open a new page during unload](https://www.chromestatus.com/feature/5989473649164288). The popup blocker already prohibits this, but now it is prohibited whether or not the popup blocker is enabled. For now, enterprises can use the `AllowPopupsDuringPageUnload` policy flag to allow popups during unload. Chrome expects to remove this flag in version 82.  

Disallow Synchronous XMLHttpRequest() in Page Dismissal
-------------------------------------------------------

Chrome now disallows synchronous calls to `XMLHttpRequest()` during page dismissal when the page is being navigated away from or is closed by the user. This applies to `beforeunload`, `unload`, `pagehide`, and `visibilitychange`.  
  
To ensure that data is sent to the server when a page unloads, Chrome recommends `sendBeacon()` or `Fetch` `keep-alive`. For now, enterprise users can use the `AllowSyncXHRInPageDismissal` policy flag and developers can use the origin trial flag `allow-sync-xhr-in-page-dismissal` to allow synchronous XMLHttpRequest() requests during page unload. This is a temporary opt-out measure. Chrome expects to remove this flag in version 82.   
  
For details about this and the alternatives, see [Improving page dismissal in synchronous XMLHttpRequest()](https://web.dev/disallow-synchronous-xhr).  

FTP Support Deprecated
----------------------

Chrome has been removing capabilities from its FTP support since version 72. The reason for this is that usage of FTP in the browser is sufficiently low that it is no longer viable to invest in improving the existing FTP client. In addition, more capable FTP clients are available on all affected platforms. In Chrome 80, the client's capabilities are restricted to either displaying a directory listing or downloading a resource over unencrypted connections. For more information, see Deprecations and removals in Chrome 80.  

Non-origin-clean ImageBitmap serialization and transferring removed
-------------------------------------------------------------------

Starting in Chrome 80, errors are raised when a script tries to serialize or transfer a non-origin-clean `ImageBitmap` object. A non-origin-clean `ImageBitmap` is one that contains data from cross-origin images that are not verified by CORS logic.  

Protocol handling now requires a secure context
-----------------------------------------------

The methods `registerProtocolHandler()` and `unregisterProtocolHandler()` now require a secure context. These methods are capable of reconfiguring client states such that they would allow transmission of potentially sensitive data over a network.   

Remove -webkit-appearance:button for arbitrary elements
-------------------------------------------------------

Changes `-webkit-appearance:button` to work only with `<button>` and `<input>` buttons. If `button` is specified for an unsupported element, the element has the default appearance. All other `-webkit-appearance` keywords already have this restriction.   

Web Components v0 removed
-------------------------

Web Components v0 are now removed from Chrome. The Web Components v1 APIs are a web platform standard that has shipped in Chrome, Safari, Firefox, and (soon) Edge. For guidance on upgrading, read [Web Components update: more time to upgrade to v1 APIs](https://developers.google.com/web/updates/2019/07/web-components-time-to-upgrade?hl=en). This deprecation covers the items listed below.   

* Custom Elements v0
* HTML Imports v0
* Shadow DOM v0