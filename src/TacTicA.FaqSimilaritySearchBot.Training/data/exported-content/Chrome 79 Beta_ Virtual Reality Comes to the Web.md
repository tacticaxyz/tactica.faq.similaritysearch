URL:https://blog.chromium.org/2019/10/chrome-79-beta-virtual-reality-comes-to.html
# Chrome 79 Beta: Virtual Reality Comes to the Web
- **Published**: 2019-10-31T13:30:00.001-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D79). Chrome 79 is beta as of October 31, 2019.  

Virtual Reality Comes to the Web
================================

The WebXR Device API is shipping in Chrome. Developers can now create immersive experiences for smartphones and head-mounted displays. Other browsers will be supporting these specs soon, including Firefox Reality, Oculus Browser, Edge and Magic Leap's Helio browser, among others.  
  
This launch sets the foundation for immersive features to come, such as supporting augmented reality, tools, and expanding the real-world understanding of immersive experiences. Many experiences can be enhanced with immersive functionality. Examples include games, home buying, viewing products in your home before buying them and more. To get started with virtual reality and the new API, read [Virtual reality comes to the web](https://web.dev/vr-comes-to-the-web/).  
  
![](https://lh3.googleusercontent.com/zFVgcyP5KmH5QEn4KK7VpxA9oCJ-ANHbeYoDemIq1LN2hsbelZ8pdBz0wTw8U6rVdSSrTGsHcUCkgC5LsO1xmmvheZIZNio-JDJkTV2weAm5nbVll2E5LZ9PzLVA1UVdatkYPNfr)  

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).  

Support for rendersubtree Attribute
-----------------------------------

Adds the [rendersubtree attribute](https://www.google.com/url?q=https://developers.chrome.com/origintrials/%23/view_trial/3677189095748009985&sa=D&ust=1572453840152000&usg=AFQjCNH8LewYeenDV96GQPIVirVti9Ln9Q) to all HTML elements, which locks a DOM element for display. When rendersubtree is set to `"invisible"`, the element's content is not drawn or hit-tested, allowing for rendering optimizations. The rendersubtree `"activatable"` token allows the browser to remove the invisible attribute, rendering the content, and making it visible.  

Wake Lock API based on Promises
-------------------------------

Adds an [update of the Wake Lock API](https://developers.google.com/web/updates/2018/12/wakelock) that introduce promises and wake lock types. The Wake Lock API brought a standard, secure, and safe way to prevent some device features such as the screen or CPU cycles from going into power saving state. This update addresses some of the shortcomings of the older API which was limited to screen Wake Lock and didn't address certain security and privacy issues.  

Other Features in this Release
==============================

Adaptive Icon Display for Installed PWAs on Android
---------------------------------------------------

Android Oreo introduced [adaptive icons](https://developer.android.com/guide/practices/ui_guidelines/icon_design_adaptive), which enforced the same shape for all icons on the home screen and in the launcher. Before Android O icons could be any shape and there was no background behind each icon. For example, gmail was rectangular, and Play was a triangle. Consequently, such icons were placed in a white circle. With adaptive icon display, Android will automatically mask irregularly shaped icons to fit properly. To make PWA icons safe for display on Android O or later, read [Adaptive icon support in PWAs with maskable icons](https://web.dev/maskable-icon/).  

Autofocus Support for any Focusable HTML/SVG Element
----------------------------------------------------

[Adds the `autofocus` attribute](https://www.chromestatus.com/feature/5654905853313024) to any focusable HTML or SVG element. The `autofocus` was previously supported for a limited number of HTML elements, and there were elements which could receive focus but didn't support the `autofocus` attribute. This feature fixes the inconsistencies.  

Compute img/video Aspect Ratio from Width Or Height HTML Attributes
-------------------------------------------------------------------

The aspect ratio of an image [is now computed](https://www.chromestatus.com/feature/5695266130755584) so that it can be used for sizing an image using CSS before it loads. This avoids unnecessary relayouts when the image loads.  

font-optical-sizing
-------------------

The `font-optical-sizing` property  
automatically sets the font size to the opsz - optical sizing axis of variable fonts that support optical sizing. This improves styling and legibility of fonts depending on font size because the font chooses a glyph shape that works optimally at the given font size. For example, the glyph contrast is improved in fonts in heading sizes when compared to the same font at body text size.
  

list-style-type: <string>
-------------------------

Allows a stylesheet to use an [arbitrary character for the list style marker](https://www.chromestatus.com/feature/5893875400966144). Examples include "-", "+", "★" and "▸". Since CSS Level 2, `list-style-type` has supported keywords like `disc` or `decimal` to define the appearance of the list item marker.  
Without this, developers are often forced to hide the real marker and insert the arbitrary marker using a `::before` pseudo element via the content property. Unfortunately, the fake marker won't be nicely positioned by `list-style-position`.  

Reject Worklet.addModule() with a More Specific Error
-----------------------------------------------------

When `Worklet.addModule()` fails, a promise rejects with [a more specific error object](https://www.chromestatus.com/feature/5116796497559552) than it did previously. `Worklet.addModule()` can fail for various reasons, including, for example, network errors and syntax errors. Before this change, `Worklet.addModule()` rejected with `AbortError` regardless of the actual cause. That made it difficult for developers to debug worklets. After this change, `Worklet.addModule()` rejects with a clearer error such as `SyntaxError`.  

Retrieve a Service Worker Object Corresponding to a Worker Itself
-----------------------------------------------------------------

A service worker can [now get its ServiceWorker object](https://www.chromestatus.com/feature/6678900060979200) with `self.serviceWorker` in a service worker script and its current state with `self.serviceWorker.state`. A service worker instance previously had no way to get its current lifecycle state. This removes the need for the hack wherein the current lifecycle state is tracked with a global variable, a method that is error prone and doesn't correctly capture waiting periods.  

Stop Evaluating Script Elements Moved Between Documents During Fetching
-----------------------------------------------------------------------

Chrome [no longer evaluates](https://www.chromestatus.com/feature/6025903192670208) scripts or fire `error` and `load` events if `<script>` elements are moved between documents during fetching. Script elements can still be moved between documents, but they won't be executed. This prevents possible security bugs caused by exploitation of `<script>` elements moved between documents.  

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).  

### -webkit-appearance Keywords for Arbitrary Elements

[Changes -webkit-appearance keywords](https://chromestatus.com/feature/4867142128238592) to work only with specific element types. If a keyword is applied to a non-supported element, the element takes the default appearance.