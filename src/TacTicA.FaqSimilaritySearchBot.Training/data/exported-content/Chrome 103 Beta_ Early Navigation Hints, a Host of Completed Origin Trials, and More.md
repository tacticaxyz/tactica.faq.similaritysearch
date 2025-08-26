URL:https://blog.chromium.org/2022/05/chrome-103-beta-early-navigation-hints.html
# Chrome 103 Beta: Early Navigation Hints, a Host of Completed Origin Trials, and More
- **Published**: 2022-05-26T13:54:00.002-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 103 is beta as of May 26, 2022. You can [download the latest on Google.com](https://www.blogger.com/blog/post/edit/2471378914199150966/133027011330334491) for desktop or on Google Play Store on Android.

Early Hints for Navigation
==========================

Chrome now supports the [103 Early Hints HTTP response code](https://www.chromestatus.com/feature/5207422375297024) for navigation. (Note: the correspondence with the Chrome release number is a coincidence.) When a 103 response includes `<link rel=preload>` or other link headers Chromium tries to preload (and/or preconnect, prefetch) specified resources before the final response is received. This gives web developers a way to optimize [core web vitals](https://web.dev/vitals/) such as Largest Contentful Paint (LCP).

HTTP/2 introduced the concept of server push, a mechanism that allows a server to preemptively send data to the client. Server push was intended to improve site performance. In the years since, developers have generally preferred preloading from the client side of a web interaction. 103 early hints for navigation provides a new way to do that.

For information on the work that went into bringing this to the web, see [Beyond Server Push: The 103 Early Hints Status Code](https://www.fastly.com/blog/beyond-server-push-experimenting-with-the-103-early-hints-status-code).

Origin Trials
=============

Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

New Origin Trials
-----------------

### Federated Credentials Management

The [Federated Credential Management API](https://developer.chrome.com/origintrials/#/view_trial/3977804370874990593) allows users to log in to websites with their federated accounts in a privacy preserving manner. It allows the browser to understand the context in which the relying party and identity provider exchange information, inform the user about the information and privilege levels being shared and prevent unintended abuse. For more information, see [Participate in a Federated Credential Management API origin trial for IdPs](https://developer.chrome.com/blog/fedcm-origin-trial/).

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgXPmNTmWrIaYRXVpNr8JMnNog4WtnO8wJ6knn6Y6yUg_LnReqaHpjfenuEcNIGU87dOUVQ8B2EH41HILAoxeyuv7yRPpiAh_G4qpWT8y_BYQMaV7sPennLrOngG1lPU3MEaAys6nDSbyGRP2KiMgD2p6ImL6bPouce8ShtKxlk6fbj_PclCHG48pQhyw/w640-h282/%5Bdraft%5Dchrome1--ukeg0xhn0m.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgXPmNTmWrIaYRXVpNr8JMnNog4WtnO8wJ6knn6Y6yUg_LnReqaHpjfenuEcNIGU87dOUVQ8B2EH41HILAoxeyuv7yRPpiAh_G4qpWT8y_BYQMaV7sPennLrOngG1lPU3MEaAys6nDSbyGRP2KiMgD2p6ImL6bPouce8ShtKxlk6fbj_PclCHG48pQhyw/s512/%5Bdraft%5Dchrome1--ukeg0xhn0m.png)

  

Completed Origin Trials
-----------------------

The following features, previously in a Chrome origin trial, are now enabled by default.

### Local Font Access

Web applications can now [enumerate local fonts and metadata about each](https://web.dev/local-fonts/). The new API also gives web applications access to table data stored within local fonts, allowing those fonts to be rendered within their applications using custom text stacks.

**Note:** The Chrome 102 beta post erroneously listed this feature as shipping in that version.

### Same-Origin Prerendering Triggered by the Speculation Rules API

Prerendering [loads a web page before it is needed](https://www.chromestatus.com/feature/5355965538893824), so that when the actual navigation to that page occurs, it can be shown instantly. To speed up page loads. Chrome's previous prerender mechanism is now replaced with [No State Prefetch](https://developer.chrome.com/blog/nostate-prefetch/). No State Prefetch doesn't generally result in an instant page load experience, but the new feature does. This feature is supported on Android only.

### Update User-Agent Client Hints GREASE Implementation

The implementation of `GREASE` in User Agent Client Hints [is now aligned with the current spec](https://www.chromestatus.com/feature/5630916006248448), which includes additional `GREASE` characters beyond the current semicolon and space, and which recommends varying the arbitrary version. This helps prevent bad assumptions from being built on top of User-Agent strings.

Other Features in this Release
==============================

AbortSignal.timeout() Static Method
-----------------------------------

Returns [a new AbortSignal object](https://www.chromestatus.com/feature/5768400507764736) that is automatically aborted after a given number of milliseconds. Use this method to easily implement timeouts for signal-accepting asynchronous APIs, such as `fetch()`. For example:  
  
`fetch(url, { signal: AbortSignal.timeout(10_000) });`

ARIA Attribute Reflection for the role Attribute
------------------------------------------------

The `Element` and `ElementInternal` interfaces [now include an `ARIA` property](https://www.chromestatus.com/feature/5188935855636480) called ariaRoleDescription which returns or modifies the ARIA role attribute directly. This feature is only supported on desktop.

avif is Now a Permitted Web Share File Extension
------------------------------------------------

The avif image file format is [now sharable by Web Share](https://www.chromestatus.com/feature/5116829864296448). Adding avif to the other allowed image file types helps spread the use of it. A website might like their users to be able to share pictures and other files through social media, email, chat, etc. The Web Share API is already shipped to more platforms such as ChromeOS and Windows, but avif is not supported yet.

"deflate-raw" Compression Format
--------------------------------

Chrome supports a new compression format, `deflate-raw`, to give web developers access to the raw deflate stream without any headers or footers. This is needed, for example, to read and write zip files.

form rel Attribute
------------------

[The `'rel'` attribute has been added to form elements](https://www.chromestatus.com/feature/5139812343349248). This makes it possible to prevent `window.opener` from being present on websites navigated to by form elements which have `rel=noopener`. It also prevents the `referer` header from being sent with `rel=noreferrer`.

popstate Fires Before Load
--------------------------

Chromium now matches Firefox and by [firing `popstate` immediately after URL changes](https://www.chromestatus.com/feature/5080172872073216) so that the order of events is now `popstate` then `hashchange` across both platforms. Before this change, Chromium fired `hashchange` asynchronously after a task, and delayed `popstate` until the load event. This means the event order could be either `hashchange` then `popstate`, or `popstate` then `hashchange`, depending on how long a document took to load.

Restrict Gamepad Usage
----------------------

The Gampepad API now [requires a secure context](https://chromestatus.com/feature/5138714634223616). Additionally a new feature policy called `'gamepad'` has been added with a default allowlist of `'self'`.

SerialPort forget()
-------------------

The [`SerialPort forget()` method](https://web.dev/serial/#revoke-access) allows web developers to voluntarily revoke a permission to a serial port that was granted by a user. Some sites may not be interested in retaining long-term permissions to access serial ports. For example, for an educational web application used on a shared computer with many devices, a large number of accumulated user-generated permissions creates a poor user experience.  
  
In addition to user agent mitigations to avoid this problem, such as defaulting to a session scoped permission on the first request or expiring infrequently used permissions, it should be possible for the site itself to clean up user-generated permissions it no longer needs.

This follows the recent additions of a `forget()` method for the `HIDDevice` and `USBDevice` interfaces.

Support visual-box on overflow-clip-margin
------------------------------------------

The `overflow-clip-margin` CSS property [now supports `visual-box`](https://www.chromestatus.com/feature/5082351989161984), which specifies the box edge to use as the overflow clip edge origin. Valid values are `content-box`, `padding-box` (the default), or `border-box`. The `overflow-clip-margin` property specifies how far an element's content is allowed to paint before being clipped.

User Activation Required for SPC Credential Enrollment
------------------------------------------------------

A [user activation requirement](https://www.chromestatus.com/feature/5104475634139136) has been added for Secure Payment Confirmation credential enrollment in a cross-origin iframe. This is being done to help mitigate [a privacy issue](https://github.com/w3c/secure-payme).

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Block External Protocol in Sandboxed iframe
-------------------------------------------

Sandboxed iframes are not blocked from opening external applications. Currently, developers sandbox untrusted content and block user navigation. Blocking probably should have also included links to external apps or to the Play store. [This has now been fixed](https://chromestatus.com/feature/5680742077038592).

Sites that need navigation can add the following values to the `<iframe>` element's sandbox property:

* `allow-popups`
* `allow-top-navigation`
* `allow-top-navigation-with-user-activation`

Remove Battery Status API on Insecure Origins
---------------------------------------------

The Battery Status API is [no longer supported on insecure contexts](https://chromestatus.com/feature/4878376799043584), specifically HTTP pages and HTTPS iframes embedded in HTTP pages. This is being removed in accordance with our policy of [deprecating powerful features on insecure origins](https://www.chromium.org/Home/chromium-security/deprecating-powerful-features-on-insecure-origins), This also follows [a spec change](https://github.com/w3c/battery/issues/15).

Remove <param> Element
----------------------

Given the removal of plugins from the web platform, and the relative lack of use of `<param>`, it is being [removed from the web platform](https://chromestatus.com/feature/6283184588193792).

Posted by Joseph Medley