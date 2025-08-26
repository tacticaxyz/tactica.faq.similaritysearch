URL:https://blog.chromium.org/2021/11/chrome-97-webtransport-new-array-static.html
# Chrome 97: WebTransport, New Array Static Methods and More
- **Published**: 2021-11-18T11:41:00.001-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links. Chrome 97 is beta as of November 18, 2021.

Preparing for a Three Digit Version Number
==========================================

Next year, Chrome will release version 100. This will add a digit to the version number reported in Chrome's user agent string. To help site owners test for the new string, Chrome 96 introduces a runtime flag that causes Chrome to return '100' in its user agent string. This new flag called `chrome://flags/#force-major-version-to-100` is available from Chrome 96 onward. For more information, see [Force Chrome major version to 100 in the User-Agent string.](https://developer.chrome.com/blog/force-major-version-to-100/)

Features in this Release
========================

Auto-expand Details Elements
----------------------------

Closed details elements are now searchable and can now be linked to. These hidden elements will also automatically expand when `find-in-page`, `ScrollToTextFragment`, and element fragment navigation are used.

Content-Security-Policy Delivery via Response Headers for Dedicated Workers.
----------------------------------------------------------------------------

Dedicated workers are [now governed by Content Security Policy](https://www.chromestatus.com/feature/5715844005888000). Previously, Chrome incorrectly applied the Content Security Policy of the owner document.

CSS
---

### font-synthesis Property

The [`font-synthesis` CSS property](https://www.chromestatus.com/feature/5640605355999232) controls whether user agents are allowed to synthesize oblique, bold, and small-caps font faces when a font family lacks oblique, bold, and small-caps faces, respectively. Without the `font-synthesis` property some web pages that do not have font families with the required variations may have unnatural forms of fonts

### transform: perspective(none)

The `perspective()` function now [supports the value `'none'` as an argument](https://www.chromestatus.com/feature/5687325523705856). This causes the function to behave as though it were passed an argument that is infinite. This makes it easier (or, in some cases, possible) to do animations involving the `perspective()` function where one of the endpoints of the animation is the identity matrix.

Feature Policy for Keyboard API
-------------------------------

Chrome supports a [new `keyboard-map` value](https://www.chromestatus.com/feature/5657965899022336) for the allow list of a feature policy. `Keyboard.getLayoutMap()` helps identify a key pressed key for different keyboard layouts such as English and French. This method is unavailable in iframe elements. The architecture of some web apps (Excel, Word, and PowerPoint) that could not use the Keyboard API can now do so.

HTMLScriptElement.supports() Method
-----------------------------------

The [`HTMLScriptElement.supports()` method](https://www.chromestatus.com/feature/5712146835963904) provides a unified way to detect new features that use script elements. Currently there is no simple way to know what kind of types can be used for the type attribute of `HTMLScriptElement`.

Late Newline Normalization in Form Submission
---------------------------------------------

Newlines in form entries are [now normalized the same as Gecko and WebKit](https://www.chromestatus.com/feature/5654547184746496), solving a long-standing interoperability problem where Gecko and WebKit normalized newlines late, while Chrome did them early. Starting in Chrome 97, early normalization is removed and late normalization is extended to all encoding types.

Standardize Existing Client Hint Naming
---------------------------------------

Chrome 97 standardizes client hint names by [prefixing them with `Sec-CH-`](https://www.chromestatus.com/feature/6658223894429696). Affected client hints are `dpr`, `width`, `viewport-width`, `device-memory`, `rtt`, `downlink`, and `ect`. Chrome will continue to support existing versions of these hints. Nevertheless, web developers should plan for their eventual deprecation and removal.

WebTransport
------------

WebTransport is a protocol framework that enables clients constrained by the Web security model to communicate with a remote server using a secure multiplexed transport.

Currently, Web application developers have two APIs for bidirectional communications with a remote server: `WebSockets` and `RTCDataChannel`. `WebSockets` are TCP-based, thus having all of the drawbacks of TCP (head of line blocking, lack of support for unreliable data transport) that make it a poor fit for latency-sensitive applications. `RTCDataChannel` is based on the Stream Control Transmission Protocol (SCTP), which does not have these drawbacks; however, it is designed to be used in a peer-to-peer context, which causes its use in client-server settings to be fairly low. `WebTransport` provides a client-server API that supports bidirectional transfer of both unreliable and reliable data, using UDP-like datagrams and cancellable streams. `WebTransport` calls are visible in the Network panel of DevTools and identified as such in the Type column.

For more information, see [Experimenting with WebTransport](https://web.dev/webtransport/).

JavaScript
==========

This version of Chrome incorporates version x.x of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

Array and TypedArray findLast() and findLastIndex()
---------------------------------------------------

`Array` and `TypedArray` now support the [`findLast()` and `fileLastIndex()` static methods](https://chromestatus.com/feature/5693639729610752). These functions are analogous to `find()` and `findIndex()` but search from the end of an array instead of the beginning.

Deprecations and Removals
=========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Remove SDES Key Exchange for WebRTC
-----------------------------------

The SDES key exchange mechanism for WebRTC has been declared a MUST NOT in the relevant IETF standards since 2013. The SDES specification has been declared historic by the IETF. Its usage in Chrome has declined significantly over the recent year. Consequently [it is removed](https://www.chromestatus.com/feature/5695324321480704) as of Chrome 97.

Remove WebSQL in Third-Party Contexts
-------------------------------------

[WebSQL in third-party contexts is now removed](https://www.chromestatus.com/feature/5684870116278272). The Web SQL Database standard was first proposed in April 2009 and abandoned in November 2010. Gecko never implemented this feature and WebKit deprecated it in 2019. The W3C encourages [Web Storage](https://developer.mozilla.org/en-US/docs/Web/API/Web_Storage_API) and [Indexed Database](https://developer.mozilla.org/en-US/docs/Web/API/IndexedDB_API) for those needing alternatives.

Remove SDP Plan B
-----------------

The Session Description Protocol (SDP) used to establish a session in WebRTC has been implemented with two different dialects in Chromium: Unified Plan and Plan B. Plan B is not cross-browser compatible and [is hereby removed](https://www.chromestatus.com/features/5823036655665152).