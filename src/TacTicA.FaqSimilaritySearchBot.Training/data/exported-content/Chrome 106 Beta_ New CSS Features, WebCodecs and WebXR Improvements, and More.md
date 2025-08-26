URL:https://blog.chromium.org/2022/09/chrome-106-beta-new-css-features.html
# Chrome 106 Beta: New CSS Features, WebCodecs and WebXR Improvements, and More
- **Published**: 2022-09-01T14:34:00.000-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, ChromeOS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 106 is beta as of September 1, 2022. You can [download the latest on Google.com](https://www.google.com/chrome/beta/) for desktop or on Google Play Store on Android.

Origin Trials
=============

This version of Chrome supports the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

Anonymous iframes
-----------------

Anonymous iframes give developers a way to load documents in third-party iframes using new and ephemeral contexts. Anonymous iframes are a generalization of COEP, i.e. Cross-Origin-Embedder-Policy: credentialless to support third-party iframes that may not deploy COEP. As with COEP: credentialless, it replaces the opt-in of cross-origin subresources with avoiding loading of non-public resources. This removes the constraint that third party iframes must support COEP in order to be embedded in a COEP page and unblocks developers looking to adopt cross-origin-isolation.

The origin trial is expected to last through Chrome 108. To sign up for the origin trial, visit [its sign up page](https://developer.chrome.com/origintrials/#/view_trial/2518638091606949889).

Pop-Up API
----------

The [Pop-Up API](https://www.chromestatus.com/feature/5463833265045504) lets developers build transient user interface elements to display on top of other web app interface elements. This API is useful for creating interactive elements such as action menus, form element suggestions, content pickers, and teaching user interfaces.

This API uses a new `popup` content attribute to enable any element to be displayed in the [top layer](https://developer.chrome.com/blog/what-is-the-top-layer/). This attribute's effect on the pop-up is similar to that of the `<dialog>` element, but has several important differences, including light-dismiss behavior, pop-up interaction management, animation, event support, and non-modal mode.

The origin trial is expected to last through Chrome 110. To sign up for the origin trial, visit [its sign up page](https://developer.chrome.com/origintrials/#/view_trial/4500221927649968129).

Other Features in this Release
==============================

Client Hints persistency in Android WebView
-------------------------------------------

Client Hints are [now persisted on Android WebView](https://www.chromestatus.com/feature/4936247663919104), creating parity with the rest of the web platform. Previously, WebView did not persist the list of Client Hints a page requests, so the initial load of a website would never include Client Hints. Only subresources on a given page would receive them. This undermined the use of the Client Hints system, which is to empower websites to adapt content to the user agent. For more information on Client Hints, see [HTTP Client hints](https://developer.mozilla.org/en-US/docs/Web/HTTP/Client_hints).

CSS
---

### grid-template properties interpolation

In CSS Grid, the `'grid-template-columns'` and `'grid-template-rows'` properties allow developers to define line names and track sizing of grid columns and rows respectively. [Supporting interpolation](https://www.chromestatus.com/feature/6037871692611584) for these properties allows grid layouts to smoothly transition between states, instead of snapping at the halfway point of an animation or transition.

### 'ic' length unit

The `'ic' length unit` expresses CSS lengths relative to the advanced measure of the water ideograph used in some Asian fonts such as Chinese and Japanese. This allows authors to size elements to fit a given number of full width glyphs for such fonts. Gecko and WebKit already support this unit. Adding this to Chrome is part of [Interop 2022](https://web.dev/interop-2022/).

### ‘preserve-parent-color' value for the ‘forced-color-adjust' CSS property.

The `'preserve-parent-color' value has been added` to the `'forced-color-adjust'` CSS property. Previously, when the forced colors mode was enabled, the `'color'` property was inherited. Now, when the `'preserve-parent-color'` value is used, the `'color'` property will use the value of its parent. Otherwise, the `'forced-color-adjust: preserve-parent-color'` value behaves the same as `'forced-color-adjust: none'`.

### Unprefix -webkit-hyphenate-character property

Chrome now supports [the unprefixed hyphenate-character property](https://www.chromestatus.com/feature/5169156928831488) in addition to the `-webkit-hyphenate-character` property. The `-webkit-hyphenate-character` property will be deprecated at a later date.

JavaScript: Intl.NumberFormat v3 API
------------------------------------

`Intl.NumberFormat` has the following [new features](https://www.chromestatus.com/feature/5707621009981440):

* Three new functions to format a range of numbers: `formatRange()`, `formatRangeToParts()`, and `selectRange()`
* A grouping enum
* New rounding and precision options
* Rounding priority
* Interpretation of strings as decimals
* Rounding modes
* Sign display negative (zero shown without a negative sign)

For more information, see the [original proposal's README](https://github.com/tc39/proposal-intl-numberformat-v3/blob/master/README.md).

SerialPort BYOB reader support
------------------------------

The underlying data source for a `ReadableStream` provided by a `SerialPort` [is now a readable byte stream](https://www.chromestatus.com/feature/6716022686482432). SerialPort "bring your own buffer" (BYOB) is backwards-compatible with existing code that calls `port.readable.getReader()` with no parameters. To detect support for this feature, pass `'byob'` as the mode parameter when calling `getReader()`. For example:

```
port.readable.getReader({ mode: 'byob' });
```

Older implementations will throw a `TypeError` when the new parameter is passed.  
  
BYOB readers allow developers to specify the buffer into which data is read instead of the stream allocating a new buffer for each chunk. In addition to potentially reducing memory pressure, this allows the developer to control how much data is received because the stream cannot return more than there is space for in the provided buffer. For more information, see [Read from and write to a serial port](https://web.dev/serial/#:~:text=Bring%20Your%20Own%20Buffer).

WebCodecs dequeue event
-----------------------

A `dequeue` event and associated callback [have been added to the audio and video interfaces](https://www.chromestatus.com/feature/5195706034290688), specifically: `AudioDecoder`, `AudioEncoder`, `VideoDecoder`, and `VideoEncoder`.

Developers may initially queue encoding or decoding work by calling `encode()` or `decode()` respectively. The new `dequeue` event is fired to indicate when the underlying codec has ingested some or all of the queued work. The decrease in the queue size is already reflected by a lower value of `encoder.encodeQueueSize` and `decoder.decodeQueueSize` attributes. The new event eliminates the need to call `setTimeout()` to determine when the queue has decreased (in other words, when they should queue more work).

WebXR Raw Camera Access
-----------------------

Applications using the WebXR Device API can [now access pose-synchronized camera image textures](https://chromestatus.com/feature/5759984304390144) in the contexts that also allow interacting with other AR features provided by WebXR.

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Remove non-ASCII characters in cookie domain attributes
-------------------------------------------------------

To align with the latest spec ([RFC 6265bis](https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-rfc6265bis/#section-5.5)), [Chromium now rejects](https://www.chromestatus.com/feature/5534966262792192) cookies with a `Domain` attribute that contains non-ASCII characters (for example, `éxample.com`).

Support for IDN domain attributes in cookies has been long unspecified, with Chromium, Safari, and Firefox all behaving differently. This change standardizes Firefox's behavior of rejecting cookies with non-ASCII domain attributes.  
  
Since Chromium has previously accepted non-ASCII characters and tried to convert them to normalized punycode for storage, we will now apply stricter rules and require valid ASCII (punycode if applicable) domain attributes.

Remove HTTP/2 push
------------------

Chrome has [removed the ability](https://www.chromestatus.com/feature/6302414934114304) to receive, keep in memory, and use HTTP/2 push streams sent by the server. See [Removing HTTP/2 Server Push from Chrome](https://developer.chrome.com/blog/removing-push/) for details and suggested alternative APIs.