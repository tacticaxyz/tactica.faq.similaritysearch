URL:https://blog.chromium.org/2022/02/chrome-99-css-cascade-layers-new-picker.html
# Chrome 99: CSS Cascade Layers, a New Picker for Input Elements, and More
- **Published**: 2022-02-03T13:54:00.002-08:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 99 is beta as of February 3, 2022. You can [download the latest on Google.com](https://www.blogger.com/blog/post/edit/2471378914199150966/133027011330334491) for desktop or on Google Play Store on Android.

Preparing for Chrome 100
========================

This year, Chrome will release version 100, adding a digit to the version number reported in Chrome's user agent string. To help site owners test for the new string, Chrome 96 introduced a runtime flag that causes Chrome to return '100' in its user agent string. This new flag called chrome://flags/#force-major-version-to-100 has been available since Chrome 96. For more information, see [Force Chrome major version to 100 in the User-Agent string](https://developer.chrome.com/blog/force-major-version-to-100/).

CSS Cascade Layers
==================

CSS cascade layers (`@layer` rule and layered `@import` syntax) provide a structured way to organize and balance concerns within a single origin. Rules within a single cascade layer cascade together without interleaving with style rules outside the layer. This allows authors to achieve a certain cascade ordering for same-origin rules in a proper way.

Cascade layers allow authors to create layers to represent element defaults, third-party libraries, themes, components, overrides, etc.—and are able to re-order the cascade of layers in an explicit way. Without cascade layers, authors need to tweak, e.g., selector specificity, `@import` or source ordering to achieve a certain cascade ordering, which is cumbersome and error-prone.

For more information, see [Cascade layers are coming to your browser](https://developer.chrome.com/blog/cascade-layers/).

New showPicker() Method on HTMLInputElement Objects
===================================================

The new `showPicker()` method on `HTMLInputElement` allows web developers to programmatically show a browser picker for input elements (temporal, color, file, and those with suggestions like datalist or autofill).

![Date pickers on various systems](https://lh4.googleusercontent.com/mh-EzsBO7guOcVIbCddPDm1y0RDKtCxkjJqWuIqXQNR-teW4hfNkuXLVHZecX3ElFQbw8_9q8MW0vHIHuHIcxBPtAt-QbsVBZwXj0UwRWtuOV7BQoUP0n_8QYEgKZfyhy7USvUP9hw=w665-h180 "Date pickers on various systems")

Developers have been asking for years for a way to programmatically open a browser date picker. Without it, they've had to rely on custom widget libraries and CSS hacks for specific browsers.

This is currently possible in some browsers, for some controls, via the `click()` method. Unfortunately, that doesn't work in all browsers, making the experience inconsistent across systems and users. Providing `showPicker()` gives developers a supported alternative to `click()`, and aligns Chromium's `click()` behavior with the specification and other browsers in in the future. For more information, see [Show a browser picker for date, time, color, and files](https://developer.chrome.com/blog/show-picker/).

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

New Origin Trials
-----------------

### Dark Mode Support for Web Apps

Web app manifests [now support the color\_scheme\_dark field](https://www.chromestatus.com/feature/5714780426862592) for specifying a different theme color and background color for dark mode. Currently in the web app manifest, only a single theme color and background color can be defined. This means there is no way for apps to specify a different color to use for dark mode.

Completed Origin Trials
-----------------------

The following features, previously in a Chrome origin trial, are now enabled by default.

### Handwriting Recognition API

This API lets web applications use handwriting recognition services that are available on operating systems to recognize hand-written text in real time. This reduces the need for third-party integration by apps that use handwriting recognition. For more information, see [Recognize your users' handwriting](https://web.dev/handwriting-recognition/).

### Window Controls Overlay for Installed Desktop Web Apps

Window controls overlay extends an app's client area to cover the entire window, including the title bar, and the window control buttons (close, maximize/restore, minimize). The web app developer is responsible for drawing and input-handling for the entire window except for the window controls overlay. Developers can use this feature to make their installed desktop web apps look like operating system apps. For more information, see [Customize the window controls overlay of your PWA's title bar](https://web.dev/window-controls-overlay/).

Other Features in this Release
==============================

Allow infinity, -infinity and NaN in CSS calc()
-----------------------------------------------

To improve conformance with the spec, [the CSS `calc()` method now allows](https://www.chromestatus.com/feature/5657825571241984) infinity and NaN using the `'infinity'`, `'-infinity'`, and `'NaN'` keywords or expressions that can be evaluated as such, for example: 'calc(1/0)'.

CSS Color Adjust: 'only' Keyword for color-scheme
-------------------------------------------------

**Note:** This feature was erroneously listed as shipping in Chrome 98. It actually shipped in Chrome 99.

The only keyword, which has been re-added to the specification for `color-scheme`, [is now supported in Chrome](https://chromestatus.com/feature/5157621012103168). It allows opting out of `color-scheme` for single, specific elements. For example, this allows overriding of force darkening. A few examples illustrate its use.

```
div { color-scheme: light }
```

This forces the `div` element out of `color-scheme` dark.

```
div { color-scheme: only light }
```

This keeps the `color-scheme` for the element light as above, and opts it out of forced darkening by the user agent.

document.adoptedStyleSheets is Now Mutable
------------------------------------------

In compliance with the spec, the `document.adoptedStyleSheets` property [is now mutable](https://chromestatus.com/feature/5638996492288000), meaning operations such as `push()` and `pop()` work on it. The previous implementation of `adoptedStyleSheets` was unwieldy. For example, to add a sheet, the entire array had to be re-assigned:

```
document.adoptedStyleSheets = [...adoptedStyleSheets, newSheet];
```

With the new implementation, the same operation looks like this:

```
document.adoptedStyleSheets.push(newSheet);
```

**Note:** Previously, this feature was incorrectly listed as shipping in Chrome 98.

Improve Alignment with Spec for Exposing nextHopProtocol Across Origin Boundaries
---------------------------------------------------------------------------------

The `PerformanceResourceTiming` interface exposes the `nextHopProtocol` property to describe the underlying connection type used to fetch a resource. To follow the spec, [Chrome is removing an old special case](https://www.chromestatus.com/feature/5706026861985792) where cross-origin requests exposed potentially sensitive information, putting users at risk.

New Canvas 2D Features
----------------------

Chrome has added several new attributes to the `CanvasRenderingContext2D` interface to conform to specs:

* `ContextLost` and `ContextRestored` events
* `"willReadFrequently"` option for canvases where lots of readback is expected
* More CSS text modifier support
* A reset() method
* A `roundRect` draw primitive
* Conic gradients
* Better support for SVG filters

For more information, see [It's always been you Canvas2D](https://web.dev/canvas2d/).

Unprefixed text-emphasis Properties
-----------------------------------

Chrome 99 [introduces unprefixed versions of text emphasis](https://www.chromestatus.com/feature/5679635154075648) CSS properties, specifically: `"text-emphasis"`, `"text-emphasis-color"`, `"text-emphasis-position"`, and `"text-emphasis-style"` CSS properties. These are unprefixed versions of `"-webkit-text-emphasis"`, `"-webkit-text-emphasis-color"`, `"-webkit-text-emphasis-position"`, and `"-webkit-text-emphasis-style"`.

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Remove Battery Status API on Insecure Origins
---------------------------------------------

[Battery Status API is no longer supported on insecure origins](https://chromestatus.com/feature/4878376799043584), such as HTTP pages or HTTPS iframes embedded in HTTP pages. The Battery Status API allows web developers to access, among other things, a system's battery charging level and whether it is being charged. It is a powerful feature that has been around for over a decade and, as such, was originally designed with different security constraints.

Remove font-family -webkit-standard
-----------------------------------

This version of Chrome [removes support for the `font-family` value `"-webkit-standard"`](https://www.chromestatus.com/feature/5639265565278208). This value is merely an alias for the proprietary keyword `"-webkit-body"` and is only exposed because it's inherited from WebKit. Removing this improves alignment with the CSS specifications and with Firefox.

Remove GamepadList
------------------

The `navigator.getGamepads()` method [now returns an array](https://get-gamepads.glitch.me/) of `Gamepad` objects [instead of a GamepadList](https://www.chromestatus.com/feature/5693119438782464). `GamepadList` is no longer supported in Chrome. This brings Chrome in line with spec and with Gecko and Webkit. For information on Gamepads generally, see [Play the Chrome dino game with your gamepad](https://web.dev/gamepad/).

Update WebCodecs to Match Spec
------------------------------

Chrome has [removed two items](https://www.chromestatus.com/feature/5667793157488640) because of recent changes in the WebCodecs spec..  
  
The `EncodedVideoChunkOutputCallback()` method takes an `EncodedVideoChunkMetadata` dictionary. Previously a member called temporalLayerId was located at `EncodedVideoChunkMetadata.temporalLayerId`. In conformance with the spec, it is now located at `EncodedVideoChunkMetadata.SvcOutputMetadata.temporalLayerId`.  
  
The spec requires that the `VideoFrame()` constructor include a timestamp argument (`VideoFrameInit.timestamp`) for `CanvasImageSource` types that don't implicitly have a timestamp (e.g. `HTMLCanvasElement`). Failing to include the timestamp should result in a `TypeError`, but Chrome previously defaulted the timestamp to zero. This seems helpful, but is problematic if you then send the `VideoFrame` to a `VideoEncoder`, where timestamps are used to guide bitrate control.