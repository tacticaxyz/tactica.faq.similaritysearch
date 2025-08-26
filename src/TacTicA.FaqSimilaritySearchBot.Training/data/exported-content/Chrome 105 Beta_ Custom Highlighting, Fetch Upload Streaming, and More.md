URL:https://blog.chromium.org/2022/08/chrome-105-beta-custom-highlighting.html
# Chrome 105 Beta: Custom Highlighting, Fetch Upload Streaming, and More
- **Published**: 2022-08-05T13:33:00.002-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 105 is beta as of August 5th, 2022. You can [download the latest on Google.com](https://www.google.com/chrome/beta/) for desktop or on Google Play Store on Android.

Custom Highlight API
====================

The [Custom Highlight API](https://www.chromestatus.com/feature/5436441440026624) extends the concept of highlighting pseudo-elements by providing a way to style the text of arbitrary ranges, rather than being limited to the user agent-defined `::selection`, `::inactive-selection`, `::spelling-error`, and `::grammar-error`. This is useful in a variety of scenarios, including editing frameworks that wish to implement their own selection, find-in-page over virtualized documents, multiple selection to represent online collaboration, or spell checking frameworks.  
  
Without this feature, web developers and framework authors are forced to modify the underlying structure of the DOM tree to achieve the rendering they desire. This is complicated in cases where the desired highlight spans across multiple subtrees, and it also requires DOM updates to adjust highlights as they change. The custom highlight API provides a programmatic way of adding and removing highlights that does not affect the underlying DOM structure, but instead applies styles to text based on range objects.

In 105, only the color and background-color pseudo elements are supported. Support for other items will be added later.

Container Queries
=================

Container queries allow authors to style elements according to the size of a container element. This capability means that a component owns its responsive styling logic. This makes the component much more resilient, as the styling logic is attached to it, no matter where it appears on the page.

Container queries are similar to media queries, but evaluate against the size of a container rather than the size of the viewport. A known issue is that container queries do not work when an author combines it with table layout in a multicolumn layout. We expect to fix this in 106. For more information, see [@container and :has(): two powerful new responsive APIs](https://developer.chrome.com/blog/has-with-cq-m105). For other CSS features in this release, see below.

:has() Pseudo Class
===================

The `:has()` pseudo class specifies an element having at least one element that matches the relative selector passed as an argument. Unlike other selectors, the `:has()` pseudo class applies, for a specified element, a style rule to preceding elements, specifically, siblings, ancestors, and preceding siblings of ancestors. For example, the following rule matches only anchor tags that have an image tag as a child.

```
a:has(> img)
```

For more information, see [@container and :has(): two powerful new responsive APIs](https://developer.chrome.com/blog/has-with-cq-m105). For other CSS features in this release, see below.

Fetch Upload Streaming
======================

Fetch upload streaming lets web developers make a fetch with a `ReadableStream` body. Previously, you could only start a request once you had the whole body ready to go. But now, you can start sending data while you're still generating the content, improving performance and memory usage.

For example, an online form could initiate a fetch as soon as a user focuses a text input field. By the time the user clicks enter, `fetch()` headers would already have been sent. This feature also allows you to send content as it's generated on the client, such as audio and video. For more information, see [Streaming requests with the fetch API](https://web.dev/fetch-upload-streaming).

Window Controls Overlay for Installed Desktop Web Apps
======================================================

Window controls overlay extends an app's client area to cover the entire window, including the title bar, and the window control buttons (close, maximize/restore, minimize). The web app developer is responsible for drawing and input handling for the entire window except for the window controls overlay. Developers can use this feature to make their installed desktop web apps look like operating system apps. For more information, see [Customize the window controls overlay of your PWA's title bar](https://web.dev/window-controls-overlay/).

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgw6Cad1Wg5uzl7KrXRcLlMBnVW1U4Fwu1JJO_qza-IJifORk_yq3884EYYONblMHAi-Mc6-l-_CLmDBe_xuuKCQYj6JYoHmfGuFHh_EYkcz02A_ETOpW-laBFcnQeBdF_JyAbzk3Q-bUlmgfHsWyIdRhX27bHwfmMg_zEp8cFtC5RZJfd9gt1G-aczKQ/w651-h148/overlay.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgw6Cad1Wg5uzl7KrXRcLlMBnVW1U4Fwu1JJO_qza-IJifORk_yq3884EYYONblMHAi-Mc6-l-_CLmDBe_xuuKCQYj6JYoHmfGuFHh_EYkcz02A_ETOpW-laBFcnQeBdF_JyAbzk3Q-bUlmgfHsWyIdRhX27bHwfmMg_zEp8cFtC5RZJfd9gt1G-aczKQ/s1600/overlay.png)

Origin Trials
=============

No origin trials are beginning in this version of Chrome. However there are a number of ongoing origin trials which you can find on the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

Completed Origin Trials
-----------------------

The following features, previously in a Chrome origin trial, are now enabled by default.

Media Source Extensions in Workers
----------------------------------

The Media Source Extensions (MSE) API is [now available from `DedicatedWorker` contexts](https://www.chromestatus.com/feature/5177263249162240) to enable improved performance of buffering media for playback by an `HTMLMediaElement` on the main Window context. By creating a `MediaSource` object in a `DedicatedWorker`, an application may then obtain a `MediaSourceHandle` from it and call `postMessage()` to transfer it to the main thread for attaching to an `HTMLMediaElement`. The context that created the `MediaSource` object may then use it to buffer media.

Viewport-height Client Hint
---------------------------

Chrome supports the new [`Sec-CH-Viewport-Height` client hint](https://www.chromestatus.com/feature/5646861215989760). This is a counterpart to the `Sec-CH-Viewport-Width` previously introduced in Chrome. Together they provide information about a viewport's size to an origin. To use these hints, pass `Sec-CH-Viewport-Height` or `Sec-CH-Viewport-Width` to the `Accept-CH` header.

Other Features in this Release
==============================

Accurate Screen Labels for Multi-Screen Window Placement
--------------------------------------------------------

This release enhances the screen label strings provided by the [Multi-Screen Window Placement API](https://web.dev/multi-screen-window-placement/). Specifically, it refines `ScreenDetailed.label` property by replacing the previous placeholders with information from the device's Extended Display Identification Data (EDID) or from a higher-level operating system API. For example, instead of returning "External Display 1", the label property will now return something like "HP z27n" or "Built-in Retina Display". These more accurate labels match those shown by operating systems in display settings dialog boxes. The labels are only exposed to sites that have been granted the `"window-placement"` permission by the user.

CSS: Preventing Overscroll Effects for Fixed Elements
-----------------------------------------------------

Setting an element's `position` CSS property to `fixed` (unless the element's [containing block](https://developer.mozilla.org/en-US/docs/Web/CSS/Containing_block) is not the root) will now prevent it from performing the effects specified by overscroll-behavior. In particular, `fixed-position` elements will not move during overscroll effects.

DisplayMediaStreamConstraints.systemAudio
-----------------------------------------

A [new constraint is being added](https://www.chromestatus.com/feature/4649448880734208) to `MediaDevices.getDisplayMedia()` to indicate whether system audio should be offered to the user. User agents sometimes offer audio for capturing alongside video. But not all audio is created alike. Consider video-conferencing applications. Tab audio is often useful, and can be shared with remote participants. But system audio includes participants' own audio, and may not be appropriate to share back. To use the new constraint, pass `systemAudio` as a constraint. For example:

```
const stream = await navigator.mediaDevices.getDisplayMedia({
  video: true,
  audio: true,
  systemAudio: "exclude"  // or "include"
});
```

This feature is only supported on desktop.

Expose TransformStreamDefaultController
---------------------------------------

To conform with spec the `TransformStreamDefaultController` class is [now available on the global scope](https://www.chromestatus.com/feature/5130793182035968). This class already exists and can be accessed using code such as  
  
`let TransformStreamDefaultController;  
new TransformStream({ start(c) { TransformStreamDefaultController = c.constructor; } });`  
  
This change makes such code unnecessary since `TransformStreamDefaultController` is now on the global scope. Possible uses for this class include monkey patching properties onto `TransformStreamDefaultController.prototype`, or feature-testing existing properties of it more easily. Note that the class is not constructible. In other words, this throws an error:

`new TransformStreamDefaultController()`

HTML Sanitizer API
------------------

The HTML Sanitizer API is an easy to use and safe way to remove executable code from arbitrary, user-supplied content. The goal of the API is to make it easier to build web applications that are free of cross-site scripting vulnerabilities and ship part of the maintenance burden for such apps to the platform.

In this release, only basic functionality is supported, specifically [`Element.setHTML()`](https://developer.mozilla.org/en-US/docs/Web/API/Element/setHTML). The Sanitize interface will be added at a later stage. Namespaced content (SVG + MathML) is not yet supported, only HTML. For more information on the API, see [HTML Sanitizer API - Web APIs](https://developer.mozilla.org/en-US/docs/Web/API/HTML_Sanitizer_API).

import.meta.resolve()
---------------------

The [`import.meta.resolve()` method](https://www.chromestatus.com/feature/5086507990777856) returns the URL to which the passed specifier would resolve in the context of the current script. That is, it returns the URL that would be imported if you called `import()`. A specifier is a URL beginning with a valid scheme or one of `/`, `./`, or `../`. See the HTML spec for [examples](https://html.spec.whatwg.org/#resolve-a-module-specifier).

This method makes it easier to write scripts which are not sensitive to their exact location, or to the web application's module setup. Some of its capabilities are doable today, in a longer form, by combining `new URL()` and the existing `import.meta.url()` method. But the integration with import maps allows resolving URLs that are affected by import maps.

Improvements to the Navigation API
----------------------------------

Chrome 105 introduces two new methods on the NavigateEvent of the [Navigation API](https://developer.chrome.com/docs/web-platform/navigation-api/) (introduced in 102) to improve on methods that have proved problematic in practice. `intercept()`, which let's developers control the state following the navigation, replaces `transitionWhile()`, which proved difficult to use. The `scroll()` method, which scrolls to an anchor specified in the URL, replaces `restoreScroll()` which does not work for all types of navigation. For explanations of the problems with the existing methods and examples of using the new, see [Changes to NavigateEvent](https://developer.chrome.com/blog/navigateevent-intercept/).

The `transitionWhile()` and `restoreScroll()` methods are also deprecated in this release. We expect to remove them in 108. See below for [other deprecations and removals](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#Deprecations-and-Removals) in this release.

onbeforeinput Global Event Handler Content Attribute
----------------------------------------------------

The [`nbeforeinput` global content attribute is now supported](https://www.chromestatus.com/feature/6627326972919808) in Chrome. The `beforeinput` form was already available via `addEventListener()`. Chrome now also allows feature detection by testing against d`ocument.documentElement.onbeforeinput`

Opaque Response Blocking v0.1
-----------------------------

[Opaque Response Blocking (ORB)](https://chromestatus.com/feature/4933785622675456) is a replacement for Cross-Origin Read Blocking (CORB). CORB and ORB are both heuristics that attempt to prevent cross-origin disclosure of "no-cors" subresources.

Picture-in-Picture API Comes to Android
---------------------------------------

The Picture-in-Picture API allows websites to create a floating video window that is always on top of other windows so that users may continue consuming media while they interact with other sites or applications on their device. This feature has been available on desktop since Chrome 70. It's now available for Chrome running on Android 11 or later. This change only applies to `<video>` elements. For information on using the Picture-in-Picture API, see [Watch video using Picture-in-Picture](https://developer.chrome.com/blog/watch-video-using-picture-in-picture/).

Response.json()
---------------

The `Response()` constructor allows for creating the body of the response from many types; however the existing `response.json()` instance method does not let you directly create a JSON object. The [`Response.json()` static method](https://www.chromestatus.com/feature/5197912798658560) fills this gap.

Response.json() returns a new Response object and takes two arguments. The first argument takes a string to convert to JSON. The second is an optional initialization object.

Syntax Changes to Markup Based Client Hints Delegation
------------------------------------------------------

The [syntax for the delegation of client hints to third-party content](https://www.chromestatus.com/feature/6308751530262528) that requires client information lost by user agent reduction, which shipped in Chrome 100, is changing.

**Previous syntax:**  
`<meta name="accept-ch" value="sec-ch-dpr=(https://foo.bar https://baz.qux), sec-ch-width=(https://foo.bar)">`  
  
**New syntax:**  
`<meta http-equiv="delegate-ch" value="sec-ch-dpr https://foo.bar https://baz.qux; sec-ch-width https://foo.bar">`

Writable Directory Prompts for the File System Access API
---------------------------------------------------------

Chromium now allows [returning a directory with both read and write permissions](https://chromestatus.com/feature/6383970247770112) in a single prompt for the [File System Access API](https://developer.mozilla.org/en-US/docs/Web/API/File_System_Access_API). Previously, `Window.showDirectoryPicker()` returned a read-only directory (after showing a read access prompt), requiring a second prompt to get write access. This double prompt is a poor user experience and contributes to confusion and permission fatigue among users.

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of planned deprecations, [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Remove WebSQL in Non-secure Contexts
------------------------------------

WebSQL in non-secure contexts [is now removed](https://www.chromestatus.com/feature/5175124599767040). The Web SQL Database standard was first proposed in April 2009 and abandoned in November 2010. Gecko never implemented this feature and WebKit deprecated it in 2019. The W3C encourages Web Storage and Indexed Database for those needing alternatives.

Developers should expect that WebSQL itself will be deprecated and removed when usage is low enough.

CSS Default Keyword is Disallowed in Custom Identifiers
-------------------------------------------------------

The CSS keyword [`'default'` is no longer allowed](https://chromestatus.com/feature/5096490737860608) within CSS custom identifiers, which are used for many types of user-defined names in CSS (for example, names created by `@keyframes` rules, counters, `@container` names, custom layout or paint names). This adds `'default'` to the list of names that are restricted from use in custom identifiers, specifically `'inherit'`, `'initial'`, `'unset'`, `'revert'`, and `'revert-layer'`.

Deprecations in the Navigation API
----------------------------------

The `transitionWhile()` and `restoreScroll()` methods are also deprecated in this release, and we expect to remove them in 108. Developers who need this functionality should use the new `intercept()` and `scroll()` methods. For explanations of the problems with the existing methods and examples of using the new, see [Changes to NavigateEvent](https://developer.chrome.com/blog/navigateevent-intercept/) .

Deprecate Non-ASCII Characters in Cookie Domain Attributes
----------------------------------------------------------

To align with the latest spec ([RFC 6265bis](https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-rfc6265bis/#section-5.5)), [Chromium will soon reject](https://www.chromestatus.com/feature/5534966262792192) cookies with a `Domain` attribute that contains a non-ASCII character (for example, `Domain=éxample.com`).  
Support for IDN domain attributes in cookies has been long unspecified, with Chromium, Safari, and Firefox all behaving differently. This change standardizes Firefox's behavior of rejecting cookies with non-ASCII domain attributes.  
  
Since Chromium has previously accepted non-ASCII characters and tried to convert them to normalized punycode for storage, we will now apply stricter rules and require valid ASCII (punycode if applicable) domain attributes.

A warning is printed to the console starting in 105. Removal is expected in 106.

Remove Gesture Scroll DOM Events
--------------------------------

The gesture scroll DOM events [have been removed from Chrome](https://chromestatus.com/feature/5166018807726080), specifically, `gesturescrollstart`, `gesturescrollupdate` and `gesturescrollend`. These were non-standard APIs that were added to Blink for use in plugins, but had also been exposed to the web.