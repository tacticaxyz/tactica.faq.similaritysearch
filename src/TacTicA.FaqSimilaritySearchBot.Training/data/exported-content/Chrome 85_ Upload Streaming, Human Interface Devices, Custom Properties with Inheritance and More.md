URL:https://blog.chromium.org/2020/07/chrome-85-upload-streaming-human.html
# Chrome 85: Upload Streaming, Human Interface Devices, Custom Properties with Inheritance and More
- **Published**: 2020-07-23T12:25:00.009-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 85 is beta as of July 23, 2020.

Fetch Upload Streaming
----------------------

Fetch upload streaming lets web developers make a fetch with a [ReadableStream](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream) body. Starting in Chrome 85, it's [available for an origin trial](https://developers.chrome.com/origintrials/#/view_trial/-7680889164480380927).

Previously, you could only start a request once you had the whole body ready to go. But now, you can start sending data while you're still generating the content, improving performance and memory usage.

For example, an online form could initiate a fetch as soon as a user focuses a text input field. By the time the user clicks enter, fetch() headers would already have been sent. This feature also allows you to send content as it's generated on the client, such as audio and video. For more information, see [Streaming requests with the fetch API](https://web.dev/fetch-upload-streaming).

See the [Origin Trials section](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#origin-trials) for information on signing up and for a list of other origin trials starting in this release. This origin trial is expected to run through Chrome 87 in January 2021.

WebHID API
----------

**Note:** At the time this was originally published, WebHID was scheduled to begin an origin trial in Chrome 85. The timeline has since been pushed back to Chrome 86.

There is a long tail of human interface devices (HIDs) that are too new, too old, or too uncommon to be accessible by systems' device drivers. The WebHID API solves this by providing a way to implement device-specific logic in JavaScript.

An HID is one that takes input from or provides output to humans. Examples of devices include keyboards, pointing devices (mice, touchscreens, etc.), and gamepads.

The inability to access uncommon or unusual HID devices is particularly painful when it comes to gamepad support. Gamepad inputs and outputs are not well standardized and web browsers often require custom logic for specific devices. This is unsustainable and results in poor support for the long tail of older and uncommon devices.

We're working on an article to show you how to use the new API. In the meantime, we've found some demos from a few eager engineers that you can use to try the new API. To see those demos, check out [Human interface devices on the web: a few quick examples](https://web.dev/hid-examples/).

See the [Origin Trials section](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#origin-trials) for information on signing up and for a list of other origin trials starting in this release. This origin trial is expected to run through Chrome 87 in January 2021.

Windows Support for getInstalledRelatedApps()
---------------------------------------------

The navigator.getInstalledRelatedApps() method determines whether a site's corresponding native app is installed. This allows customization of a user experience for already-installed apps. For example, users can be redirected from a product marketing page directly into an app. Functionality can be centralized to prevent users from seeing duplicate notifications and save developers from maintaining two code bases. Sites can even avoid prompting for installation of a PWA if a native app is already on a user's device.

It does all this while protecting user privacy. Entries in the web app manifest and the Android manifest file ensure that sites cannot use the API to request arbitrary information about users' installed apps.

This method was implemented on Android in Chrome 80. Starting in Chrome 85, it's available on Microsoft Windows. This addition is the result of work from Microsoft. For details on using this method, see [Is your app installed? getInstalledRelatedApps() will tell you!](https://web.dev/get-installed-related-apps/).

@property
---------

CSS Houdini is a [set of APIs and CSS features](https://developer.mozilla.org/en-US/docs/Web/Houdini#The_Houdini_APIs) that exposes the CSS rendering engine. It lets developers create new CSS features without waiting for a native implementation in browsers. CSS Houdini's @property rule is part of the [CSS Properties and Values API](https://developer.mozilla.org/en-US/docs/Web/API/CSS_Properties_and_Values_API), which allows defining custom properties with inheritance, type checking, and default values. The first part of this API, [CSS.registerProperty(), was implemented in Chrome 78](https://web.dev/css-props-and-vals/). That method's capabilities are now available in stylesheets through the @property.

Take the image below, for example. What you're seeing is a transition created with a CSS custom property. In addition to being impossible without the new API, this transition is also type safe. For more information, see [@property: giving superpowers to CSS variables](https://web.dev/at-property/).

![](https://lh4.googleusercontent.com/_9-HI9MJm8ceOq7KAufk0iA2q-KZRifd2TYY22XdjVEIefm6Vu_hJ3XLePtbDna3nPwkrnczbkxVAEs9L7EygV4RGpT8LtMYHn6iPKgHHoxLxvll5TShDPV2OV39fUnDVJzzEq_zCg)

Origin Trials
-------------

In addition to those listed above, this version of Chrome introduces the new origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).

### New Origin Trials

#### Declarative Shadow DOM

A [declarative API](https://www.chromestatus.com/feature/5191745052606464) to allow the creation of shadow roots using only HTML and no JavaScript. This API allows Web Components that use Shadow DOM to also make use of server-side rendering (SSR), to get rendered content on screen quickly without requiring JavaScript for shadow root attachment. The origin trial is expected to [run through Chrome 87](https://developers.chrome.com/origintrials/#/view_trial/2024368032503037953) in January 2020.

#### RTCRtpEncodingParameters.adaptivePtime Property

The [RTCRtpEncodingParameters.adaptivePtime property](https://www.chromestatus.com/feature/5752004691361792) lets a sender in a real-time communication (RTC) system enable or disable adaptive packet rates. Because the packet rate is a big determining factor to the overall bitrate of an audio stream, an optimal congestion control is needed to adapt the packet rate. The audio packet rate is analogous to the video frame rate, which also plays an important role in the video bitrate adaptation.  
  
Although adaptive packet rate may be ubiquitously beneficial, we need this API for applications to enable and disable it, since, otherwise, it may introduce interoperability problems. Some implementations have taken a fixed packet rate as an assumption, and thus may fail or perform sub-optimally with an adaptive packet rate. The origin trial is expected to [run through Chrome 87](https://developers.chrome.com/origintrials/#/register_trial/3163778738227773441) in January 2021.

#### Portals

Portals enable seamless navigations between sites or pages by allowing a page to show another page as an inset. For more information, see [Hands-on with Portals: seamless navigation on the Web](https://web.dev/hands-on-portals/). The origin trial is expected to [run through Chrome 86](https://developers.chrome.com/origintrials/#/view_trial/-7680889164480380927) in early November.

Other Features in this Release
------------------------------

### App Shortcuts

App shortcuts are now available on desktop in addition to Android, which debuted in Chrome 84. This feature improves users' productivity and facilitates reengagement with key tasks by providing quick access to common actions. For sites that are already Progressive Web Apps, creating shortcuts requires only adding items to the web app manifest. This addition is the result of work from Microsoft. For more information, see [Get things done quickly with app shortcuts](https://web.dev/app-shortcuts/).

### Autoupgrade Mixed Content

Chrome is now [auto-upgrading images](https://chromestatus.com/feature/5557268741357568) served over HTTP from HTTPS sites by rewriting URLs to HTTPS without falling back to HTTP when secure content is not available. Chrome has been auto-upgrading audio and video content since version 80.

### AVIF Image Decode

Adds [support for decoding AVIF content](https://www.chromestatus.com/feature/4905307790639104) natively using existing AV1 decoders. AVIF is a next generation image format standardized by the [Alliance for Open Media](https://aomedia.org/). There are three primary motivations for supporting AVIF:

* Reducing bandwidth consumption to load pages faster and reduce overall data consumption. AVIF offers significant file size reduction for images compared with JPEG or WebP.
* Adding HDR color support. AVIF is a path to HDR image support for the web. JPEG is limited in practice to 8-bit color depth. With displays increasingly capable of higher brightness, color bit depth, and color gamuts, web stakeholders are increasingly interested in preserving image data that is lost with JPEG.
* Supporting ecosystem interest. Companies with a large web presence have expressed an interest in shipping AVIF images on the web.

### Changes to Persistent Storage for Installed Web Apps

Getting [persistent storage](https://web.dev/persistent-storage/) is easier and more predictable for installed web apps, including PWAs and Trusted Web Activities. If an installed web app requests persistent storage by calling `navigator.storage.persist()`, it will be granted automatically. Other sites will continue to use the existing [heuristics](https://web.dev/persistent-storage/#chrome-and-other-chromium-based-browsers).

### CSS

#### Color Adjust: Remove 'only' and Support 'dark' or 'light' for color-scheme”

Chrome made [two changes](https://www.blogger.com/blog/post/edit/2471378914199150966/8521804084878530634) to match those made in the CSS Color Adjustment level 1 spec.

* The 'only' keyword is no longer special and is treated as a <custom-ident> as any other unknown color-scheme. The 'only' keyword was previously only allowed in combination with 'light', but had otherwise no effect in Chrome.
* Page authors can now use dark-themed UA rendering even when the preferred color-scheme is 'light'. The new behavior is:
  + color-scheme: light -> always light
  + color-scheme: dark -> always dark
  + color-scheme: light dark -> select the preferred scheme

This means content which has a dark theme in its CSS will be able to match it with dark themed UA controls.  
  
This change improves interoperability with WebKit which already had this behavior for 'color-scheme: dark'.

#### content-visibility Property

Adds a CSS property called [content-visibility](https://www.chromestatus.com/feature/4613920211861504), which allows automatic or script management of content visibility. When hidden, the element's contents (subtree or replaced element contents) are not drawn or hit-tested and have CSS containment applied, allowing for rendering optimizations. The 'auto' keyword allows for the user-agent to manage content visibility based on proximity to the viewport, whereas the 'hidden' keyword allows full script control of content visibility.

#### counter-set

[CSS counter-set](https://www.chromestatus.com/feature/4688138070917120) is an additional property introduced in [CSS Lists Module Level 3](https://drafts.csswg.org/css-lists-3/) to control counters by setting an existing counter to a specified value. This builds on other implemented counter control properties, specifically counter-reset (which creates a new counter with a specified value) and counter-increment (which increments an existing counter by a specified amount). This feature is needed for precise counter control, since otherwise it is not possible to set an existing counter to a value other than figuring out how to increment or decrement it.

### Event Timing API

The [Event Timing API](https://www.chromestatus.com/features/5167290693713920) enables web developers to measure event latency both before and after the page load. Monitoring event latency requires an event listener. This precludes measuring event latency early in page load, and adds unnecessary performance overhead.

### Expose Picture-in-Picture Window in leavepictureinpicture event

(Desktop only) The leavepictureinpicture event [now exposes a reference to pictureInPictureWindow](https://www.chromestatus.com/feature/5719215132639232) so that web developers no longer need to keep a global reference to that object.

### Named pages with page-orientation

Support is added for [several CSS properties](https://www.chromestatus.com/feature/5173237715566592) and descriptors for printing.

* The 'page' CSS property.
* Named pages. For example: @page foobar {}
* The 'page-orientation' descriptor with values 'upright' (default), 'rotate-left', or 'rotate-right'.

### Referrer Policy: Default to strict-origin-when-cross-origin

Web developers may specify a referrer policy on their documents, which impacts the Referer header sent on outgoing requests and navigations. When no such policy is specified, Chrome [will now use strict-origin-when-cross-origin as the default](https://www.chromestatus.com/feature/6251880185331712) policy, instead of no-referrer-when-downgrade. On cross-origin requests made from documents without a specified referrer policy, this reduces the Referer header to the initiating origin.

### Update Fallback Content's Behavior for ImageInputType and HTMLImageElement

Changes the [behavior of fallback content](https://www.chromestatus.com/feature/5428567112417280) for ImageInputType and HTMLImageElement. Such content will now render exactly the same as alt text would.

### Update the Behavior of the "disabled" Attribute for HTMLLinkElement

Corrects [several spec inconsistencies](https://www.chromestatus.com/feature/5110851973414912) related to the <link> tag's disabled attribute.

* Values for the disabled attribute were not accessible through document.stylesheets.
* Toggling the disabled attribute to false then back to true caused it to appear and remain in document.stylesheets.
* The only way to enable an alternate stylesheet was by disabling, then reenabling it.
* Disabled links were not setting link.ownerNode to null.

These behaviors are eliminated in compliance with a [spec update](https://github.com/whatwg/html/pull/4519).

### Web Bluetooth writeValueWithResponse() and writeValueWithoutResponse()

Adds two new methods, [writeValueWithResponse() and writeValueWithoutResponse()](https://www.chromestatus.com/feature/5152041850634240), which resolve several issues with the existing method for writing to GATT characteristics and enable developers to control whether the device returns a response. The existing writeValue() method will remain for backwards compatibility, but its use is discouraged. The following problems with the existing method have been corrected:

* It does not allow specifying the type of GATT characteristic write that should be used. This is particularly a problem for devices that support both write types. Writing without response is often desirable for performance reasons, however on most platforms, writing with response is used by default.
* The ability to write with or without response is platform-specific. Currently most platforms prefer writing with a response, but Android prefers writing without a response if both types are available.
* On most platforms, the current implementation depends on the device correctly reporting the available GATT characteristic write types via GATT characteristic properties. If these properties are not set, the characteristic cannot be written to.

The new APIs also do not depend on the GATT characteristic properties being set correctly which allows working around buggy Bluetooth devices.

### WebAssembly BigInt Integration

WebAssembly now [imports and exports](https://www.chromestatus.com/feature/5648655109324800) WebAssembly function parameters of type i64 using BigInt.

### WebAuthn getPublicKey(), getPublicKeyAlgorithm() and getAuthenticatorData()

[Several methods](https://www.chromestatus.com/feature/5102556109864960) from the Web Authentication Level 2 spec have been added.

* getPublicKey() and getPublicKeyAlgorithm() save sites from parsing Concise Binary Object Representation (CBOR) and CBOR Object Signing and Encryption (COSE) in order to use security keys. CBOR and COSE are somewhat obscure at this time and there's no need for most sites to have to worry about them as the browser is capable of translating them into more standard formats.
* getAuthenticatorData() returns the authenticator data contained within attestationObject.

JavaScript
----------

This version of Chrome incorporates version 8.1 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

### JavaScript Logical Assignment Operators

Adds the logical assignment operators ||=, &&=, and ??= to JavaScript. This rounds out the compound assignment operators to also include logical binary operators. Currently only mathematical and bitwise binary operators are supported. This improvement is for shipping terser, clearer JavaScript. For more information, see [Logical assignment](https://v8.dev/features/logical-assignment).

### Promise.any() and AggregateError

Adds [two new JavaScript features](https://www.chromestatus.com/feature/5574922384441344) to V8. Promise.any() accepts an iterable of promises and returns a promise that is fulfilled by the first given promise to be fulfilled, or rejected with an AggregateError holding the rejection reasons if all of the given promises are rejected. AggregateError is a support class that aggregates one or more errors into a single object.  
This rounds out standard JS support for commonly available Promise combinators already available in userland libraries.

### String.prototype.replaceAll()

JavaScript now has support for [global substring replacement](https://www.chromestatus.com/feature/6040389083463680) through the new String.prototype.replaceAll() method.

Deprecations, and Removals
--------------------------

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

### AppCache Removal Begins

Chrome 85 starts a spec-mandated turn down of AppCache in Chrome. For details and instructions for managing the transition gracefully, see [Preparing for AppCache removal](https://web.dev/appcache-removal/). For information on a feature that will help you identify uses of this and other deprecated APIs, see [Know your code health](https://web.dev/reporting-observer/).

### Reject insecure SameSite=None cookies

Use of cookies with SameSite set to None without the Secure attribute is no longer supported.  
Any cookie that requests SameSite=None but is not marked Secure will be rejected. This feature started rolling out to users of Stable Chrome on July 14, 2020. See [SameSite Updates](https://www.chromium.org/updates/same-site) for a full timeline and details. Cookies delivered over plaintext channels may be cataloged or modified by network attackers. Requiring secure transport for cookies intended for cross-site usage reduces this risk.