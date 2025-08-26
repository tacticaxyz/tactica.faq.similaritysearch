URL:https://blog.chromium.org/2022/03/chrome-101-federated-credential.html
# Chrome 101: Federated Credential Management Origin Trial, Media Capabilities for WebRTC, and More
- **Published**: 2022-03-31T11:19:00.006-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 101 is beta as of March 31, 2022. You can [download the latest on Google.com](https://www.google.com/chrome/beta/) for desktop or on Google Play Store on Android.

Reduce User Agent String Information
====================================

Chrome is trying to [reduce the amount of information the user agent string exposes](https://www.chromestatus.com/feature/5704553745874944) in HTTP requests as well as in `navigator.userAgent`, `navigator.appVersion`, and `navigator.platform`. We're doing this to prevent the user agent string from being used for passive user fingerprinting. To join the origin trial, see [its entry on Chrome Origin Trials](https://developer.chrome.com/origintrials/#/view_trial/-7123568710593282047). See [the end of this article](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#depsrems) for additional deprecations and removals.

Origin Trials
=============

This version of Chrome introduces the origin trial described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

New Origin Trial
----------------

### Federated Credential Management API

Federated Credential Management API (FedCM) aims to create privacy-preserving identity federation and is designed to make identity federation continue to allow use cases without the need for cross-site tracking such as third-party cookies. [This feature starts its origin trial in 101 on Android only](https://developer.chrome.com/origintrials/#/view_trial/3977804370874990593). We expect to add desktop support in Chrome 102.

Completed Origin Trials
-----------------------

The following feature, previously in a Chrome origin trial, is now enabled by default.

### Priority Hints

Priority Hints provides a way to [indicate a resource's relative importance](https://web.dev/priority-hints/) to the browser, allowing more control over the order resources are loaded.

Other Features in this Release
==============================

AudioContext.outputLatency
--------------------------

[`AudioContext.outputLatency` property](https://www.chromestatus.com/feature/5682265146261504) is an estimation in seconds of the interval between when the user agent requests a host system to play a buffer and when the first sample in the buffer is processed by the audio output device. For devices such as speakers or headphones that produce an acoustic signal, 'processed by the audio output device' refers to the time when a sample's sound is produced. This property helps developers compensate for the latency between the input and the output. It's also useful for synchronization of video and audio streams.

This property is already implemented in Firefox.

font-palette and Custom @font-palette-values Palettes
-----------------------------------------------------

The `font-palette` CSS property allows [selecting a palette from a color font](https://chromestatus.com/feature/5674031696052224). In combination with the `@font-palette-values` `at-rule`, custom palettes can be defined. This feature is useful in designs where an icon or emoji font is used with dark or light mode, or when using multi-colored icon fonts that use the `font-palette` to harmonize with the content's color scheme.

hwb() CSS function
------------------

HWB (short for 'hue whiteness blackness') is another method of specifying sRGB colors, similar to HSL, but often even easier for humans to work with. The `hwb()` function [specifies HWB values in CSS](https://chromestatus.com/feature/5637256860663808). The function takes three arguments. The first, `hue`, specifies hue in degrees (not constrained to the range [0, 360]). The next two, `whiteness` and `blackness`, are specified as percentages.

Make Popup Argument for window.open() Evaluate to 'true'
--------------------------------------------------------

This feature follows a recent change to the spec for [parsing the `popup` argument for `window.open()`](https://www.chromestatus.com/feature/5669245760307200). Previously, when `popup` was set equal to true, `window.open()` was interpreted to mean false. This is counterintuitive and confusing. This change makes boolean features easier to use and understand.

MediaCapabilities API for WebRTC
--------------------------------

The MediaCapabilities API has been extended to support WebRTC streams. The MediaCapabilities API helps websites make informed decisions on what codec, resolution, etc. to use for video playback by indicating whether a configuration is supported and also whether the playback is expected to be smooth.   
Without this feature, web apps need to guess about suitable configurations. This can result in poor quality such as when an application uses low resolution or frame rates unnecessarily, or stuttering when the frame rate is too high.

Secure Payment Confirmation API V3
----------------------------------

The following features from version three of the Secure Payment Confirmation API [are now implemented](https://www.chromestatus.com/feature/5675682238562304):

* A relying party ID that is a required input. Because this is required, existing code will need to be updated.
* An optional boolean to allow failed instrument icon download.
* A `payeeName` property as an optional input.

USBDevice forget()
------------------

The [`USBDevice` `forget()` method](https://web.dev/usb/#revoke-access) allows web developers to voluntarily revoke a permission to a USBDevice that was granted by a user.

WebUSB sameObject Behavior
--------------------------

`USBConfiguration`, `USBInterface`, `USBAlternateInterface`, and `USBEndpoint` instances are [now only strictly equal](https://www.chromestatus.com/feature/5769668454252544) ("===") when they are retrieved from accessors on the same `USBDevice`.

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Remove WebSQL in Third-Party Contexts
-------------------------------------

[WebSQL in third-party contexts is now removed](https://www.chromestatus.com/feature/5684870116278272). The Web SQL Database standard was first proposed in April 2009 and abandoned in November 2010. Gecko never implemented this feature and WebKit deprecated it in 2019. The W3C encourages [Web Storage](https://developer.mozilla.org/en-US/docs/Web/API/Web_Storage_API) and [Indexed Database](https://developer.mozilla.org/en-US/docs/Web/API/IndexedDB_API) for those needing alternatives.

Developers should expect that WebSQL itself will be deprecated and removed when usage is low enough.