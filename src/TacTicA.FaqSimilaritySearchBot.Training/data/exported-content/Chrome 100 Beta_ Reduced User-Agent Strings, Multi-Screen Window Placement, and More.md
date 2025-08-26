URL:https://blog.chromium.org/2022/03/chrome-100-beta-reduced-user-agent.html
# Chrome 100 Beta: Reduced User-Agent Strings, Multi-Screen Window Placement, and More
- **Published**: 2022-03-03T12:21:00.000-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 100 is beta as of March 3. 2022. You can [download the latest on Google.com](https://www.blogger.com/blog/post/edit/2471378914199150966/133027011330334491) for desktop or on Google Play Store on Android.

Last Version for Unreduced User-Agent String
============================================

Chromium 100 will be the last version to support an unreduced User-Agent string by default (as well as the related `navigator.userAgent`, `navigator.appVersion`, and `navigator.platform` DOM APIs). The origin trial that [allowed sites to test the fully reduced User-Agent](https://developer.chrome.com/origintrials/#/view_trial/-7123568710593282047) will end on April 19, 2022. After that date, the User-Agent String will be gradually reduced. To review the whole schedule, see [Chromium Blog: User-Agent Reduction Origin Trial and Dates](https://blog.chromium.org/2021/09/user-agent-reduction-origin-trial-and-dates.html). Sites that need more time to test or [migrate to User-Agent Client Hints](https://web.dev/migrate-to-ua-ch/) can enroll in the deprecation origin trial [scheduled from Chrome 100 to 113](https://developer.chrome.com/origintrials/#/view_trial/2608710084154359809), inclusive. In contrast to the first origin trial, which previews the fully reduced User-Agent string, the deprecation trial maintains the legacy User-Agent. The deprecation trial is expected to end in late May of 2023.

This is part of a strategy to replace use of the User-Agent string with the  
new User-Agent Client Hints API. To learn about User-Agent Client Hints, see [Migrate to User-Agent Client Hints](https://web.dev/migrate-to-ua-ch/) and [Improving user privacy and developer experience with User-Agent Client Hints](https://web.dev/user-agent-client-hints/).

Multi-Screen Window Placement
=============================

The Multi-Screen Window Placement API, now available on desktop, lets you enumerate the displays connected to your machine and to place windows on specific screens. This unlocks use cases like multi-window apps that need to accurately position certain windows. It also adds a new `screen` option to the `Element.requestFullscreen()` method which allows you to determine which screen to start a full screen view on.

[![A multi-screen setup.](https://blogger.googleusercontent.com/img/a/AVvXsEgtGhn3kNRSGWBRGewgC3BYz3fi5IAnL0sp_imdTkye0m4l43OuJjTAPn85Hj3_YhJm4JCHuebIJXuvoGSuWgnIBDy3hBLysDRxvNchVlJc1OukR5q1aMTnvV2JrFE96IhiOShpq6Nc6nOpnrHI3L-WCEhEqnnH1uJACOeOaIN_Sv8J8_NuxNM-RJp5rw=w320-h298 "A multi-screen setup.")](https://blogger.googleusercontent.com/img/a/AVvXsEgtGhn3kNRSGWBRGewgC3BYz3fi5IAnL0sp_imdTkye0m4l43OuJjTAPn85Hj3_YhJm4JCHuebIJXuvoGSuWgnIBDy3hBLysDRxvNchVlJc1OukR5q1aMTnvV2JrFE96IhiOShpq6Nc6nOpnrHI3L-WCEhEqnnH1uJACOeOaIN_Sv8J8_NuxNM-RJp5rw=s571)

  
    
  
New use cases include:

* A slideshow app presenting on a projector, while showing speaker notes on a laptop screen.
* A financial app opening a dashboard of windows across multiple monitors.
* A medical app opening images (for example, x-rays) on a high-resolution grayscale display.
* A creativity app showing secondary windows (for example, a palette) on a separate screen.
* Multi-screen layouts in gaming, signage, artistic, and other types of apps.

For more information, see [Managing several displays with the Multi-Screen Window Placement API](https://web.dev/multi-screen-window-placement/).

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

Continuing Origin Trials
------------------------

The following origin trial is being extended to the listed version.

### Media Source Extensions in Workers

Chrome is continuing an origin trial for making the Media Source Extensions (MSE) API [available from dedicated workers](https://developer.chrome.com/origintrials/#/view_trial/3847199981681246209). This feature improves performance when buffering playing media in an `HTMLMediaElement` on the main Window. By creating a `MediaSource` object in a dedicated worker, an application may then create an ObjectURL for it and call `postMessage()` to pass that URL to the main thread for attaching to an `HTMLMediaElement`. The context that created the `MediaSource` object may then use it to buffer media. Web authors have consistently requested that MSE be available from Worker contexts. This extended origin trial is expected to end in Chrome 103, in late July 2022.

Completed Origin Trials
-----------------------

The following feature, previously in a Chrome origin trial, is now enabled by default.

### Digital Goods API

Chrome now provides an API for querying and managing digital products to facilitate in-app purchases from web applications. The new API works with the Payment Request API, which is used for the actual purchases. The API can be linked to a digital distribution service connected through the user agent. In Chromium, this is specifically a web API wrapper around the Android Play Billing API.

This API lets web apps in the Play Store accept purchases for digital goods. (Play policies prevent them from accepting payment via any other method.) Without this, websites that sell digital goods are not installable through the Play Store.

For more information, see [Receive Payments via Google Play Billing with the Digital Goods API and the Payment Request API - Chrome Developers](https://developer.chrome.com/docs/android/trusted-web-activity/receive-payments-play-billing/).

Other Features in this Release
==============================

AbortSignal.prototype.throwIfAborted()
--------------------------------------

Chrome now [throws an `AbortSignal` object's reason](https://www.chromestatus.com/feature/5029737100476416) if the signal is aborted. This convenience method allows signal-handling functions to check a signal's abort status and propagate the abort reason. For example, it could be called after asynchronous operations that might change a signal's state.

Abort signal handling functions often need to check the signal's status and propagate the error if the signal has been aborted. This provides a convenient and consistent way to do this. An example is already [available on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal/throwIfAborted#examples).

Capability Delegation
---------------------

Capability delegation means allowing a frame to relinquish its ability to call a restricted API and transfer that ability to a (sub) frame it trusts. If an app wants to delegate its ability to call a restricted JavaScript feature (for example, popups, or fullscreen) to a known and trusted third-party frame, this API allows it to transfer this ability to the target frame for a specified period. This is in contrast to static mechanisms such as an iframe's allow attributes.

Many merchant websites host their online store on their own domain but outsource the payment collection and processing infrastructure to a payment service provider (PSP) to comply with security and regulatory complexities around card payments. This workflow is implemented as a "pay" button inside the top (merchant) frame where it can blend better with the rest of the merchant's website, and payment request code inside a cross-origin iframe from the PSP. The [Payment Request API](https://developer.mozilla.org/en-US/docs/Web/API/Payment_Request_API) used by the PSP code is gated by transient user activation (to prevent malicious attempts like unattended or repeated payment requests). Because the top (merchant) frame's user interaction is not visible to the iframe, the PSP code needs to delegate in response to a click in the top frame before it can start payment processing.

HIDDevice forget()
------------------

The [`HIDDevice` `forget()` method](https://www.google.com/url?q=https://web.dev/hid/%23revoke-access&sa=D&source=docs&ust=1646065188537268&usg=AOvVaw3UTyzaYw6yA6VnrI8f54Hd) allows web developers to voluntarily revoke a permission to an HIDDevice that was granted by a user. Some sites may not be interested in retaining long-term permissions to access HID devices. For example, for an educational web application used on a shared computer with many devices, a large number of accumulated user-generated permissions creates a poor user experience.  
  
In addition to user agent mitigations to avoid this problem, such as defaulting to a session scoped permission on the first request or expiring infrequently used permissions, it should be possible for the site itself to clean up user-generated permissions it no longer needs.

mix-blend-mode: "plus-lighter"
------------------------------

The `mix-blend-mode` property now [supports the `"plus-lighter"` value](https://www.chromestatus.com/feature/5677338286096384), which adds the source and destination colors multiplied by their respective alphas. This operation is useful when crossfading between two elements that contain common pixels. In that case, `"plus-lighter"` ensures that the common pixels do not change in appearance as opacity changes from 0 to 1 on one element and from 1 to 0 on the other.

Sec-CH-UA-WoW64 Client Hint
---------------------------

This hint serves solely as a backwards compatible shim for sites relying on "WoW64-ness" (32-bit apps running in 64-bit Windows) as they [transition from the User-Agent string to UA-CH](https://web.dev/migrate-to-ua-ch/). It returns a boolean value.

SerialPort Integration with WritableStream Controller's Abort Signal
--------------------------------------------------------------------

When using `WritableStream`, serial ports [can now be closed without waiting](https://www.chromestatus.com/feature/4778232531386368) for all write operations to finish. If the port is waiting for the peer device to provide a flow control signal it could be blocked indefinitely. The intent of aborting a `WritableStream` is to immediately stop writing data to the underlying sink.

TLS ALPN Extension in wss-schemed WebSockets Connections
--------------------------------------------------------

The TLS ALPN extension is [now included when initiating a new connection](https://www.chromestatus.com/feature/5687059162333184) for wss-schemed `WebSockets`, offering just the default "http/1.1" protocol. Currently, unlike HTTPS connections, such connections do not offer ALPN at all. Changing this aligns with Firefox and Safari, hardens against cross-protocol attacks (ALPACA, for example), and makes wss eligible for the false start optimization. It also simplifies work on the HTTPS DNS record.

Web NFC: NDEFReader makeReadOnly()
----------------------------------

The [`NDEFReader` `makeReadOnly()` method](https://www.google.com/url?q=https://web.dev/nfc/%23make-read-only&sa=D&source=docs&ust=1646065188538039&usg=AOvVaw3p-6rssvNSRjDA4HXKzooW) allows web developers to make NFC tags permanently read-only with Web NFC.

WebTransport serverCertificateHashes Option
-------------------------------------------

In `WebTransport`, [the `serverCertificateHashes` option](https://chromestatus.com/feature/5690646332440576) allows a website to connect to a web transport server by authenticating the certificate against the expected certificate hash instead of using the Web public key infrastructure (PKI).

This feature allows Web developers to connect to WebTransport servers that would normally find obtaining a publicly trusted certificate challenging, such as hosts that are not publically routable, or virtual machines that are ephemeral in nature.

Deprecations, and Removals
==========================

This version of Chrome has only one deprecation, described [at the top of this article](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#Last-Version-for-Unreduced-User-Agent-String).   
Visit ChromeStatus.com for lists of [ongoing deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).