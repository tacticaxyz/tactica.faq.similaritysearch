URL:https://blog.chromium.org/2022/01/chrome-98-beta-color-gradient-vector.html
# Chrome 98 Beta: Color Gradient Vector Fonts, Region Capture Origin Trial, and More
- **Published**: 2022-01-10T09:41:00.005-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 98 is beta as of January 10, 2022. You can [download the latest on Google.com](https://www.google.com/chrome/beta/) for desktop or on Google Play Store on Android.

COLRv1 Color Gradient Vector Fonts
==================================

In this version Chrome supports COLRv1 color gradient vector fonts as an additional new font format. A color font contains glyphs with multiple colors in them, which can be for example an emoji or a country flag or a multi-colored letter.

COLRv1 is an evolution of the COLRv0 font format intended to make color fonts widespread on the web. COLRv1 fonts bring expressive visual capabilities such as gradients, transforms and compositions at a very small font size. COLRv1 fonts also support OpenType variations. Internal shape reuse and a compact font format definition, plus effective compression, lead to very small font sizes.

The image illustrates the example of Noto Color Emoji, which is about 9MB as a bitmap font, but only 1.85MB as a COLRv1 vector font (after WOFF2 compression).

|  |
| --- |
| [Two national park emojis, one crisp, one blurry and a bar chart comparing binary size of Noto Emoji as Bitmap font and as COLRv1 font, about 9MB vs. 1.85MB](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj_iz7ADQI4OilwjI40fOSu3RvRzj30TgBQCXbYKFjI9lK6M1YrWmbdTOZaS5MT6-7mHvD_x0xtQPIRgaT6byLY6PzLqgM6u5bz-MIuhC3CL-XTZ1qv9d9B7HegMkV1eVf8QXZRtuSAS61D/) |
| *Crisp COLRv1 vector font (left) compared to a bitmap font (right). Noto Emoji font size as bitmap font vs. COLRv1 font after WOFF2 compression.* |

For more information, see [COLRv1 Color Gradient Vector Fonts in Chrome 98](https://developer.chrome.com/blog/colrv1-fonts/).

Preparing for a Three Digit Version Number
==========================================

This year, Chrome will release version 100, adding a digit to the version number reported in Chrome's user agent string. To help site owners test for the new string, Chrome 96 introduced a runtime flag that causes Chrome to return '100' in its user agent string. This new flag called chrome://flags/#force-major-version-to-100 has been available from Chrome 96 onward. For more information, see [Force Chrome major version to 100 in the User-Agent string](https://developer.chrome.com/blog/force-major-version-to-100/).

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

New Origin Trial
----------------

### Region Capture

Region Capture is an [API for cropping a self-capture video track](https://www.chromestatus.com/feature/5712447794053120). Applications can currently obtain a capture of the tab in which they run using `getDisplayMedia()`, either with or without `preferCurrentTab`. In this case, the application may want to crop the resulting video track to remove some content from it (typically before sharing it remotely).

Other Features in this Release
==============================

Adding auto Keyword for contain-intrinsic-size
----------------------------------------------

Support for [the auto keyword in `contain-intrinsic-size`](https://www.chromestatus.com/feature/6740477866934272) is added, letting websites use the last-remembered size of an element (if any), which provides for a better user experience than for elements with `content-visibility: auto`. Without this feature, web developers have to guess the rendered size of the element; when used with `content-visibility: auto`, this may lead to elements jumping around.

AudioContext.outputLatency
--------------------------

The new [`AudioContext.outputLatency` property](https://www.chromestatus.com/feature/5682265146261504) is an estimate in seconds of audio output latency. Technically, this is the interval between the time the user agent requests the host system to buffer and the time at which the first sample in the buffer is processed by the audio output device. For devices such as speakers or headphones that produce an acoustic signal, this latter time refers to the time when a sample's sound is produced. This is already implemented in Firefox.

CSS Color Adjust: 'only' Keyword for color-scheme
-------------------------------------------------

The `only` keyword, which has been re-added to the specification for `color-scheme`, is [now supported in Chrome](https://www.chromestatus.com/feature/5157621012103168). It allows opting out of color-scheme for single, specific elements. For example, this allows overriding of force darkening. A few examples illustrate its use.

`div { color-scheme: light }`

This forces the div element out of color-scheme dark.  
  
`div { color-scheme: only light }`

This keeps the `color-scheme` for the element light as above, and opts it out of forced darkening by the user agent.

document.adoptedStyleSheets is Now Mutable
------------------------------------------

**Note:** This feature was incorrectly listed as shipping in Chrome 98. It actually shipped in Chrome 99.

In compliance with the spec, [the `document.adoptedStyleSheets` property is now mutable](https://www.chromestatus.com/feature/5638996492288000), meaning operations such as `push()` and `pop()` now work on it. The previous implementation of `adoptedStyleSheets` was unwieldy. For example, to add a sheet, the entire array had to be re-assigned:  
  
`document.adoptedStyleSheets = [...adoptedStyleSheets, newSheet];`  
With the new implementation, the same operation looks like this:

```
document.adoptedStyleSheets.push(newSheet);
```

High Dynamic Range Color Media Queries
--------------------------------------

Chrome now supports the CSS media queries `'dynamic-range'` and `'video-dynamic-range'` for [detecting the current display device's support for HDR](https://www.chromestatus.com/feature/5680926106320896). Possible values are `'standard'` and `'high'`. These queries allow pages to toggle CSS rules or respond using `Window.matchMedia()`.

New window.open() Behavior for Popups, Tabs, and Windows
--------------------------------------------------------

As per a spec update, this version of Chrome lets you [specify whether `window.open()` launches a new window or a new tab](https://www.chromestatus.com/feature/5663031909416960). The following examples show the new syntax. The first will open a pop up window. The second will open a new tab or window.  
  
`const popup = window.open('_blank','','popup=1');  
  
const tab = window.open('_blank','','popup=0');`  
  
Additionally, `window.statusbar.visible` now correctly returns correct values: specifically, `false` for popups, and `true` for tabs, and windows.

Private Network Access Preflight Requests for Subresources
----------------------------------------------------------

CORS preflight requests are [now sent ahead of private network requests for subresources](https://www.chromestatus.com/feature/5737414355058688), asking for explicit permission from the target server. A private network request is any request from a public website to a private IP address or localhost, or from a private website (e.g. intranet) to localhost. Sending a preflight request mitigates the risk of cross-site request forgery attacks against private network devices such as routers, which are often not prepared to defend against this threat.

structuredClone() Method on Windows and Workers
-----------------------------------------------

Windows and Workers now support the `structuredClone()` methods for making deep copies of objects. A deep copy is one that copies an object's properties, but invokes itself recursively when it finds a reference to another object, creating a copy of that object as well. This ensures that two pieces of code don't accidentally share an object and unknowingly manipulate each others' state. For an explanation of deep copies and how to use them, see [Deep-copying in JavaScript using structuredClone](https://web.dev/structured-clone/).

WebAuthn minPinLength Extension
-------------------------------

[Chrome now](https://www.chromestatus.com/feature/5729885776510976) exposes the [CTAP 2.1 minPinLength extension via Web Authentication](https://fidoalliance.org/specs/fido-v2.1-ps-20210615/fido-client-to-authenticator-protocol-v2.1-ps-20210615.html#sctn-minpinlength-extension). This allows sites preconfigured for a security key to learn the configured minimum PIN length for the authenticator.

Window Controls Overlay for Installed Desktop Web Apps
------------------------------------------------------

When the [window controls overlay](https://www.chromestatus.com/feature/5741247866077184) is enabled for installed desktop web apps, the app's client area is extended to cover the entire window—including the title bar area—and the window control buttons (close, maximize/restore, minimize) are overlaid on top of the client area. The web developer is responsible for drawing and input-handling for the entire window except for the window controls overlay. Developers can use this feature to make their installed desktop web apps look like OS apps.

WritableStream controller AbortSignal
-------------------------------------

[`WritableStreamDefaultController` now supports a signal property](https://www.chromestatus.com/feature/5698931422920704) which returns an instance of [`AbortSignal`](https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal), allowing a `WritableStream` operation to be stopped if needed. The streams APIs provide ubiquitous, interoperable primitives for creating, composing, and consuming streams of data. This change permits an underlying sink to rapidly abort an ongoing write or close when requested by the writer. Previously, when `writer.abort()` was called, a long-running write would still have to continue to completion before the stream could be aborted. With this change, the write can be aborted immediately. In addition to being exposed to streams authored in JavaScript, this facility will also be used by platform-provided streams such as `WebTransport`.

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Remove SDES Key Exchange for WebRTC
-----------------------------------

The SDES key exchange mechanism for WebRTC has been declared a MUST NOT in the relevant IETF standards since 2013. Its usage in Chrome has declined significantly over the last year. [SDES is removed](https://chromestatus.com/features/5695324321480704) because it is a security problem. It exposes session keys to Javascript, which means that entities with access to the negotiation exchange, or with the ability to subvert the Javascript, can decrypt the media sent over the connection.