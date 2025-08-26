URL:https://blog.chromium.org/2022/06/chrome-104-beta-new-media-query-syntax.html
# Chrome 104 Beta: New Media Query Syntax, Region Capture, and More
- **Published**: 2022-06-23T15:04:00.002-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 104 is beta as of June 23, 2022. You can [download the latest on Google.com](https://www.google.com/chrome/beta/) for desktop or on Google Play Store on Android.

Region Capture
==============

Chrome on Desktop can now crop self-captured video tracks. Web apps are already able to capture video in a tab using `getDisplayMedia()`. Region capture allows web apps to crop a track and remove content from it, typically before sharing it remotely.

For example, consider a productivity web app with built-in video conferencing. During a video conference, a web app could use cropping to exclude the video conferencing portion of the screen (outlined in red below) avoiding a hall-of-mirrors effect. For more information, see [Better tab sharing with Region Capture](https://developer.chrome.com/docs/web-platform/region-capture/).

[![A region capture window: broadcast content in blue, cropped content in red.](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgahf8S_W0OwGCUp7HAQGJRFoi3qKbWWbcvI0mGRS95y5hjltIaPR-7uuq-R95UDaX3u8ZjAkTEqleyg-CInac2RDKiB_T31dA2gm-WrNlBhES5hrECaKCaTBdX5ZyhTH5WyUs2jovh0v1aAme3F92uZOXOTwN4PN5DYziAvWwxvYDSk2s60q4CD3YBaQ/s16000/region-capture.png "When broadcasting content, the red portion will be cropped.")](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgahf8S_W0OwGCUp7HAQGJRFoi3qKbWWbcvI0mGRS95y5hjltIaPR-7uuq-R95UDaX3u8ZjAkTEqleyg-CInac2RDKiB_T31dA2gm-WrNlBhES5hrECaKCaTBdX5ZyhTH5WyUs2jovh0v1aAme3F92uZOXOTwN4PN5DYziAvWwxvYDSk2s60q4CD3YBaQ/s845/region-capture.png)

  

Media Queries Level 4 Syntax and Evaluation
===========================================

Media Queries enable [responsive design](https://web.dev/learn/design/), and the range features that enable testing the minimum and maximum size of the viewport are used [by around 80% of sites](https://almanac.httparchive.org/en/2021/css#media-features-in-use) that use media queries.

The Media Queries Level 4 specification includes a new syntax for these range queries. They can now be written using ordinary mathematical comparison operators. Also supported are the logical operators `or` and `not`, and nesting and evaluation of "unknown" features. For example, a media query previously written like this:

```
@media (min-width: 400px) { … }
```

Can now be written like this:

```
@media (width >= 400px) { … }
```

For more information, see [New syntax for range media queries in Chrome 104](http://developer.chrome.com/blog/media-query-range-syntax/).

Origin Trials
=============

This version of Chromium supports the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chromium, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

New Origin Trials
-----------------

### Focusgroup

The `focusgroup` CSS property improves keyboard focus navigation using the keyboard arrow keys among a set of focusable elements. Adding this feature to browsers allows web developers to control focus navigation without custom solutions that can lead to a lack of consistency, accessibility, and interoperability. [Sign up here](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/html-focusgroup-attribute/registration/) for the Microsoft Edge origin trial. It's scheduled to last through 107.

### Opt Out of Credit Card Storage

Secure Payment Confirmation now supports a means for users to opt out of storing their credit card data to make later purchases easier. To use the new feature, set `showOptOut` to `true` on `methodData.data`, which is passed as the first parameter of the `PaymentRequest()` constructor. For example:

```
const methodata = [{ 
  …
  data: {
    …
    showOptOut: true
    …
  }
}];
const request = new PaymentRequest(methodData, details);
```

To see an example in context [check out the demo](https://rsolomakhin.github.io/pr/spc-opt-out/). You can [sign up here](https://developer.chrome.com/origintrials/#/view_trial/3293257227514675201) for the origin trial. It's scheduled to last through Chrome 106.

### Shared Element Transitions

Shared Element Transitions enables the creation of polished transitions in single-page applications (SPAs). Minimal development effort is required by devs to make transitions look nice; they can choose to use default animation properties, or they can customize their own transition effects to achieve the desired transition experience.Transitions are set declaratively using CSS properties. For more information, see [Shared Element Transitions](https://github.com/WICG/shared-element-transitions/blob/main/explainer.md). Visit the dashboard to [sign up for the origin trial](https://www.google.com/url?q=https://chromestatus.com/feature/5193009714954240&sa=D&source=docs&ust=1655396015685272&usg=AOvVaw3HhlvSDCzPW65WHM23ioHj).

Completed Origin Trials
-----------------------

The following features, previously in a Chrome origin trial, are now enabled by default.

### Speculation Rules

Speculation rules provide a mechanism for web content to permit [prefetching or prerendering of certain URLs](https://www.chromestatus.com/feature/5740655424831488). For example:

```
<script type="speculationrules">
  {
    "prefetch": [
      {"source": "list", "urls": ["/weather/kitchener", "/weather/seattle", "/weather/tokyo"]}
    ]
  }
</script>
```

### Subresource Loading with Web Bundles

Subresource loading with web bundles is a way to load many resources efficiently. To use the feature a web page declares that certain resources are provided by a web bundle at a particular URL. For example:

```
<script type="webbundle">
{
   "source": "https://example.com/dir/subresources.wbn",
   "resources": ["https://example.com/dir/a.js", "https://example.com/dir/b.js", "https://example.com/dir/c.png"]
}
</script>
```

For information on creating web bundles, see [Get started with Web Bundles](https://web.dev/web-bundles/). For more information on subresource loading using web bundles, see [Origin Trial for Subresource Loading with Web Bundles](https://chromium.googlesource.com/chromium/src.git/+/refs/heads/master/content/browser/web_package/subresource_loading_origin_trial.md).

Other Features in this Release
==============================

Cookie Expires/Max-Age Attribute Upper Limit
--------------------------------------------

When cookies are set with an explicit Expires/Max-Age attribute [the value will now be capped](https://www.chromestatus.com/feature/4887741241229312) to no more than 400 days. Previously, there was no limit and cookies could expire as much as multiple millennia in the future. This follows a [change in the spec](https://httpwg.org/http-extensions/draft-ietf-httpbis-rfc6265bis.html#name-the-expires-attribute:~:text=The%20limit%20SHOULD%20NOT%20be%20greater%20than%20400%20days%20(34560000%20seconds)%20in%20the%20future.).  
  
400 days was chosen as a round number close to 13 months. This duration ensures that sites visited roughly once a year (for example, sites for choosing health insurance benefits) will continue to work.

CSS object-view-box
-------------------

The [`object-view-box` property](https://www.chromestatus.com/feature/5213032857731072) allows authors to specify a portion of an image that should draw within the content box of a target replaced element. This enables creation of images with a custom glow or shadow applied, with proper `ink-overflow` behavior such as a CSS shadow would have. For more information, see [First Look At The CSS object-view-box Property](https://ishadeed.com/article/css-object-view-box/).

Fullscreen Capability Delegation
--------------------------------

[Fullscreen Capability Delegation](https://www.chromestatus.com/feature/6441688242323456) allows a Window to transfer the ability to call `requestFullscreen()` to another Window it trusts after relinquishing the transient user activation at the sender Window. This feature is based on the [general delegation mechanism](https://chromestatus.com/feature/5708770829139968) that shipped in Chrome 100.

Multi-Screen Window Placement: Fullscreen Companion Window
----------------------------------------------------------

Fullscreen Companion Window allows sites to place fullscreen content and a popup window on separate screens from a single user activation. There is a [demo available](https://michaelwasserman.github.io/window-placement-demo/) with [source code](https://github.com/michaelwasserman/window-placement-demo) on GitHub.

Permissions Policy for Web Bluetooth API
----------------------------------------

Web Bluetooth is [now controllable with a Permissions Policy](https://www.chromestatus.com/feature/6439287120723968). The token is named `"bluetooth"` and has a default allowlist of `'self'`.

visual-box on overflow-clip-margin
----------------------------------

The [`overflow-clip-margin` property](https://www.chromestatus.com/feature/5082351989161984) specifies how far an element's content is allowed to paint before being clipped. This feature allows using `visual-box` values to configure the reference box that defines the overflow clip edge the content is clipped to.

Web Custom Formats for Async Clipboard API
------------------------------------------

[Web Custom Formats](https://www.chromestatus.com/feature/5649558757441536) lets websites read and write arbitrary unsanitized payloads using a standardized web custom format, as well as read and write a limited subset of OS-specific formats (for supporting legacy apps).  
  
The name of the clipboard format is mangled by the browser in a standardized way to indicate that the content is from the web. This allows platform applications to opt-in to accepting the unsanitized content.

Some web app developers want to exchange data payloads between web and platform applications via operating system clipboards. The [Clipboard API](https://developer.mozilla.org/en-US/docs/Web/API/Clipboard_API) supports the most popular standardized data types (text, image, rich text) across all platforms. However, this API does not scale to the long tail of specialized formats. In particular, custom formats, non-web-standard formats like TIFF (a large image format), and proprietary formats like `docx` (a document format), are not supported by the current Web Platform.

WebGL Canvas Color Management
-----------------------------

As per the spec, Chromium's implementation of WebGL [now allows specifying](https://chromestatus.com/feature/4814886323355648):

* The color space of a drawing buffer.
* The color space that content should be converted to when importing as a texture.

Before this version of Chrome, both of these defaulted to sRGB. Now they can also use "display-p3".

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Block Third-Party Contexts Navigating to Filesystem URLs
--------------------------------------------------------

iframes can [no longer navigate to filesystem URLs](https://chromestatus.com/feature/5816343679991808). Top frame support for navigating to filesystem URLs was dropped in Chrome 68.

Remove Non-Standard Client Hint Mode
------------------------------------

Four client hints (`dpr`, `width`, `viewport-width`, and `device-memory`) have a default allowlist of `self` but behave as though they have a default allowlist of `*` on Android, contrary to the spec. [This is now fixed](https://www.chromestatus.com/feature/5694492182052864), increasing privacy on Android by requiring explicit delegation of these hints.

Remove U2F API (Cryptotoken)
----------------------------

Chrome's legacy U2F API for interacting with security keys [is no longer supported](https://www.chromestatus.com/feature/5759004926017536). U2F security keys themselves are not deprecated and will continue to work.

Affected sites should migrate to the [Web Authentication API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Authentication_API). Credentials that were originally registered via the U2F API can be challenged via web authentication. USB security keys that are supported by the U2F API are also supported by the Web Authentication API.

U2F is Chrome's original security key API. It allows sites to register public key credentials on USB security keys and challenge them for building phishing-resistant two-factor authentication systems. U2F never became an open web standard and was subsumed by the Web Authentication API (launched in Chrome 67). Chrome never directly supported the FIDO U2F JavaScript API, but rather shipped a component extension called cryptotoken, which exposes an equivalent `chrome.runtime.sendMessage()` method. U2F and Cryptotoken are firmly in maintenance mode and have encouraged sites to migrate to the Web Authentication API for the last two years.