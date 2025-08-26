URL:https://blog.chromium.org/2020/02/chrome-81-near-field-communications.html
# Chrome 81: Near Field Communications, Augmented Reality, and More
- **Published**: 2020-02-13T17:55:00.001-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D81). Chrome 81 is beta as of February 13, 2020.  

Web NFC for mobile
==================

NFC stands for Near Field Communications, a short-range wireless technology for transmitting small amounts of data, usually between a specialized NFC device and a reader. If you've scanned a badge to enter a building, you may have used used NFC.   
  
Web NFC allows a web app to read and write to NFC tags. This opens new use cases to the web, including providing information about museum exhibits, inventory management, providing information in a conference badge, and many others.   
  
![](https://lh5.googleusercontent.com/7gAWZBHaZVtx4S0xBexbXxCVH726FasA-IwRi8TAoV77RTk6PrPKXZ4lDbhC5Wa1x3h8oFOF9Pv83n-MH4PZKGc6_oArJl_tPOOgN80vQQd1YJIHXeg3QykWGAbpbCnhjAwBrOtQ)
*A demonstration of Web NFC cards*  

Reading and writing are simple operations. You'll need a little instruction for constructing and interpreting payloads, but it's not complicated. Fortunately, we have an article, [Interact with NFC devices on the web](https://www.google.com/url?q=https://web.dev/nfc&sa=D&ust=1581287505442000&usg=AFQjCNG4PP2zLimwjoHBWgA7SoDnwuJteA). Check it out. A few code samples are shown below.  
  
Writing a string to an NFC tag:  
  

```
if ("NDEFWriter" in window) {
  const writer = new NDEFWriter();
  await writer.write("Hello world!");
}
```

  
Scanning messages from NFC tags:  
  

```
if ("NDEFReader" in window) {
  const reader = new NDEFReader();
  await reader.scan();
  reader.onreading = ({ message }) => {
    console.log(`Message read from a NFC tag: ${message}`);
  };
}
```

  
Chrome 81 introduces the mobile web to NFC with an origin trial. See the Origin Trials section for information on signing up and for a list of other origin trials starting in this release.  

Augmented Reality and Hit Testing
=================================

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjp7yP1ZsPFA5JMAgMCXJXmrwegDSvybJAiRZIc1bxm5CjYRSwiyjrTVZVGGSaifX73ePq1f-yggzuEJ6GeQMFU7n5ibrOaibJON4sxw8r_fja6dARrAPxc0oZssrV0WVfkjFCmItk28fY3/s400/augmented-reality.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjp7yP1ZsPFA5JMAgMCXJXmrwegDSvybJAiRZIc1bxm5CjYRSwiyjrTVZVGGSaifX73ePq1f-yggzuEJ6GeQMFU7n5ibrOaibJON4sxw8r_fja6dARrAPxc0oZssrV0WVfkjFCmItk28fY3/s1600/augmented-reality.png)

Chrome 81 adds two new immersive features to the web, both designed to support augmented reality. The WebXR Device API, first enabled in Chrome 79, now supports augmented reality. We've also added support for the WebXR Hit Test API, an API for placing objects in a real-world view.   
  
If you've already used the new API to create virtual reality, you'll be happy to know there's very little new to learn to use AR. This is because the spec was designed with the spectrum of immersive experiences in mind. Regardless of the degree of augmentation or virtualization, the application flow is the same. The differences are merely a matter of setting and requesting different properties during object creation.  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjvXcbgAinEEnk5JZ4MKgbo1mvjwI5Ndt35rT1Ygz-Wdni7fdrDpvG5jWvuKXEeBo_vSMYztEBkJTCR3hwMi7KADmLW9kHIR49cNFVbPsJtp5_TW4j9zY58l9M-HteuGOt2jBH2X2iI0ewl/s400/reticales.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjvXcbgAinEEnk5JZ4MKgbo1mvjwI5Ndt35rT1Ygz-Wdni7fdrDpvG5jWvuKXEeBo_vSMYztEBkJTCR3hwMi7KADmLW9kHIR49cNFVbPsJtp5_TW4j9zY58l9M-HteuGOt2jBH2X2iI0ewl/s1600/reticales.png)

  
The WebXR Hit Test API provides a means for an immersive experience to interact with the real world. Specifically, it enables you to place virtual objects on real-world points in a camera view. The image below from one of the Immersive Web Working Group's sample apps illustrates this. The broken blue circle indicates a point returned from the hit test API. If I tap the screen a sunflower will be placed there. The new API captures both the location of a hit test and the orientation of the point that was detected. You'll notice in the image a sunflower has been placed on both the floor and the wall.   
  
If you're completely new to the WebXR Device API, check out our earlier articles, [Virtual reality comes to the web](https://web.dev/vr-comes-to-the-web/) and Virtual reality comes to the web, part II. If you're already familiar with entering a WebXR session and constructing a frame loop, then check out [our new article on Web AR](https://web.dev/web-ar/). Also check out our article on the [WebXR Hit Test API](https://web.dev/ar-hit-test/).  

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).  

PointerLock unadjustedMovement
------------------------------

Scripts now have the ability to [request unadjusted and unaccelerated mouse movement data](https://developers.chrome.com/origintrials/#/view_trial/-8986933056417824767) when in PointerLock. If unadjustedMovement is set to true, then pointer movements will not be affected by the underlying platform modifications such as mouse acceleration.  

Other features in this release
==============================

Buffered Flag for Long Tasks
----------------------------

Chrome 81 [updates the buffered flag of PerformanceObserver](https://www.chromestatus.com/feature/6306761277440000) to support long tasks. In particular, this feature provides a way to gain insight into early long tasks for apps or pages that register a PerformanceObserver early.  

CSS image-orientation property
------------------------------

Chrome will by default respect EXIF metadata within images indicating desired orientation. The accompanying image-orientation property allows developers to override this behavior.  

CSS Color Adjust: color-scheme
------------------------------

A [new meta tag and](https://www.chromestatus.com/features/6070987093180416) CSS property lets sites opt-in to following the preferred color scheme when rendering UI elements such as default colors of form controls and scrollbars as well as the used values of the CSS system colors. For Chrome 81 only initial color and background are affected.  

Exclude Implicit Tracks from grid-template-rows and grid-template-columns Resolved Values
-----------------------------------------------------------------------------------------

[Implicit tracks are now excluded from the resolved values](https://www.chromestatus.com/feature/5958076270116864) of the grid-template-rows and grid-template-columns. Previously, all tracks were included, whether implicit or explicit.

Note: This was mistakenly included though it did not actually ship.  

hrefTranslate attribute on HTMLAnchorElement
--------------------------------------------

The HTMLAnchorElement [now has an hrefTranslate attribute](https://www.chromestatus.com/features/6298864638230528), providing the ability for a page to hint to a user agent's translation engine that the destination site of an href should be translated if followed.  

IntersectionObserver Document Root
----------------------------------

The IntersectionObserver() constructor [now takes a Document as the 'root' argument](https://www.chromestatus.com/features/5714474851893248), causing intersections to be calculated against the scrolling viewport of the document. This is primarily targeted towards observers running in an iframe. Previously, there was no way to measure intersection with the scrolling viewport of the iframe's document.  

Modernized Form Controls
------------------------

In version 81, Chrome modernizes the appearance of form controls on Windows, ChromeOS, and Linux while improving their accessibility and touch support. (Mac and Android support are coming soon.) It's hoped that this will reduce the need to build custom form controls. This change is the result of collaboration between Microsoft and Google. For more information, see the [recent talk at CDS](https://www.youtube.com/watch?v=ZFvPLrKZywA) or the [MS blog post](https://blogs.windows.com/msedgedev/2019/10/15/form-controls-microsoft-edge-chromium/). For a closer look at the controls, [this page](http://concrete-hardboard.glitch.me/) gives an example of all of the elements that changed.  

Move onwebkit{animation,transition}XX handlers to GlobalEventHandlers
---------------------------------------------------------------------

Until now, the prefixed onwebkit{animation,transition}XX handlers were only available on the Window object in Chrome. They are [now on HTMLElement and Document](https://www.chromestatus.com/feature/4833112531927040) as required by the spec. This fix brings Chrome in line with Gecko and Webkit.  
  
Note: This change is intended to improve interoperability on existing web pages. These handlers are still obsolete so web developers should use the non-refixed versions on new pages.  

Position State for Media Session
--------------------------------

Adds [support for tracking position state](https://www.chromestatus.com/feature/5677548182700032) in a media session. The position state is a combination of the playback rate, duration, and current playback time. This can then be used by browsers to display position in the UI and with the addition of seeking can support seeking/scrubbing too. For a code sample and demonstration, see [our sample](https://googlechrome.github.io/samples/media-session/video.html).  
![](https://lh5.googleusercontent.com/D6iCSy9rZ2_aKbEc1w90p97Vh_nRkBOQayDdKLSMyOp82uP8kgzHgHku9Wvvism3glhED9FLUsCAJecp0EwDERRbSGmEUIbevOx9V0x8VNLXofO4jFBdF_UMdhAPydC-v_-4lDYR)  

SubmitEvent
-----------

Chrome now supports [a SubmitEvent type](https://chromestatus.com/features/5187248926490624), an Event subtype which is dispatched on form submission. The SubmitEvent has a submitter property that refers to attributes of the submitter button including the entry data, the formaction attribute, the formenctype attribute, the formmethod attribute, and the formtarget attribute.   
  
Currently, applications are doing their own form submission by calling preventDefault() during onsubmit. This approach has the limitation that the received event does not include the button that triggered the submission.  

WebAudio: ConvolverNode.channelCount and channelCountMode
---------------------------------------------------------

For a ConvolverNode, the channelCount [can now be set to 1 or 2](https://www.chromestatus.com/feature/6248507407073280). The channelCountMode can be "explicit" or "clamped-max". Previously, a channelCount of 1 was not allowed and neither was a mode of "explicit".  
  
This release also extends ConvolverNode capabilities slightly to allow developers to choose the desired behavior without having to add a GainNode to do the desired mixing.  

WebRTC
------

### RTCPeerConnection.onicecandidateerror event changes

The candidateerror event [now has an explicit address and port](https://www.chromestatus.com/feature/5698302152540160), replacing hostCandidate.  

### onclosing Event for RTCDataChannel

[Adds the onclosing event to the RTCDataChannel object](https://www.chromestatus.com/feature/5733328181264384), which signals to the user of a data channel that the other side has started closing the channel. The user agent will continue reading from the queue (if it contains anything) until the queue is empty, but no more data can be sent.  

WorkerOptions for shared workers constructor
--------------------------------------------

[Adds the WorkerOptions object](https://www.chromestatus.com/features/5642256117661696) as the second argument for a shared worker constructor. The previous second argument, a string containing the worker's name is still supported.  

WritableStream.close()
----------------------

WritableStream objects [now have a close() method](https://www.chromestatus.com/feature/5440098147500032) that closes a stream if it is unlocked. This is directly equivalent to getting a writer, using the writer to close the stream, and then unlocking it again.  

JavaScript
==========

This version of Chrome incorporates version 8.1 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent changes](https://v8.dev/blog) in the V8 release notes.  

Intl.DisplayNames()
-------------------

The Intl.DisplayNames() object lets an app or script [get localized names of language, script, currency codes, and commonly used names of date fields and symbols.](https://www.chromestatus.com/feature/4965112605573120) This will reduce the size of apps (thereby improving latency), make it easier to build internationalized UI components, reduce translation costs, and provide more consistent translations across the web.  

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).  

Deprecation and Remove "basic-card" support Payment Handler
-----------------------------------------------------------

This version of Chrome removes the basic-card polyfill for Payment Request API in iOS Chrome. As a result, the Payment Request API is temporarily disabled in iOS Chrome. For full details, see [Rethinking Payment Request for iOS](https://www.google.com/url?q=https://blog.chromium.org/2020/01/rethinking-payment-request-for-ios.html&sa=D&ust=1581287505507000&usg=AFQjCNFf5bi-68IcQTns9C24XVn_BTwgGw).  

Remove supportedType field from BasicCardRequest
------------------------------------------------

Specifying "supportedTypes":[type] parameter for "basic-card" payment method shows cards of only the requested type, which is one of "credit", "debit", or "prepaid".  
  
The card type parameter has been removed from the spec and is [now removed from Chrome](https://www.chromestatus.com/feature/5709702556024832), because of the difficulty of accurate card type determination. Merchants today must check card type with their PSP, because they cannot trust the card type filter in the browser:  
  

* Only issuing banks know the card type with certainty and downloadable card type databases have low accuracy, so it's impossible to know accurately the type of the cards stored locally in the browser.
* The "basic-card" payment method in Chrome no longer shows cards from Google Pay, which may have connections with issuing banks.

  
Firefox removed "supportedTypes" in version 65.  

Remove the <discard> element
----------------------------

Chrome 81 [removes the <discard> element](https://www.chromestatus.com/features/4870172764536832). It is only implemented in Chromium, and is thus not possible to use interoperably. For most use cases it can be replaced with a combination of animation of the 'display' property and a removal (JavaScript) callback/event handler.  

Remove TLS 1.0 and TLS 1.1
--------------------------

**Note:** Removal of TLS 1.0 and TLS 1.1 has been delayed to Chrome 83, which is expected to ship in late May 2020.

This version of Chrome [removes TLS 1.0 and TLS 1.1](https://www.chromestatus.com/feature/5759116003770368). TLS (Transport Layer Security) is the protocol which secures HTTPS. It has a long history stretching back to the nearly twenty-year-old TLS 1.0 and its even older predecessor, SSL. Both TLS 1.0 and 1.1 have a number of weaknesses.  

* TLS 1.0 and 1.1 use MD5 and SHA-1, both weak hashes, in the transcript hash for the Finished message.
* TLS 1.0 and 1.1 use MD5 and SHA-1 in the server signature. (Note: this is not the signature in the certificate.)
* TLS 1.0 and 1.1 only support RC4 and CBC ciphers. RC4 is broken and has since been removed. TLS's CBC mode construction is flawed and was vulnerable to attacks.
* TLS 1.0's CBC ciphers additionally construct their initialization vectors incorrectly.
* TLS 1.0 is no longer PCI-DSS compliant.

Supporting TLS 1.2 is a prerequisite to avoiding the above problems. The TLS working group has deprecated TLS 1.0 and 1.1. Chrome deprecated these features in version 72 in early 2019.  

TLS 1.3 downgrade hardening bypass
----------------------------------

TLS 1.3 includes a backwards-compatible hardening measure [to strengthen downgrade protections](https://www.chromestatus.com/feature/5128354539765760). However, when we shipped TLS 1.3 last year, we had to partially disable this measure due to incompatibilities with some non-compliant TLS-terminating proxies. Chrome currently implements the hardening measure for certificates which chain up to known roots, but allows a bypass for certificates chaining up to unknown roots. We intend to enable it for all connections.  
  
Downgrade protection mitigates the security impact of the various legacy options we retain for compatibility. This means user's connections are more secure and, when security vulnerabilities are discovered, it is less of a scramble to respond to them. (That, in turn, means fewer broken sites for users down the road.) This also aligns with [RFC 8446](https://tools.ietf.org/html/rfc8446).