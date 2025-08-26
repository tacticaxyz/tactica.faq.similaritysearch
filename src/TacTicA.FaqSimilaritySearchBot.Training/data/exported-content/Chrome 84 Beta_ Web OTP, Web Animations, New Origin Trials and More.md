URL:https://blog.chromium.org/2020/05/chrome-84-beta-web-otp-web-animations.html
# Chrome 84 Beta: Web OTP, Web Animations, New Origin Trials and More
- **Published**: 2020-05-28T11:22:00.004-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 84 is beta as of May 28, 2020.  

Web OTP API
===========

The Web OTP API (formerly called the SMS Receiver API) helps users enter an OTP on a web page when a specially-crafted SMS message is delivered to the user's Android phone.  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgO1f4pe7Mq-bWKrVT-nlHfzZV-286dtWoTNnKqN72xalJr9R43HNDr4upArA7pWdD7rZf0p8aHsXbz8dPHWguKJ7x_tgqwV8em4x_2tIFtSMennhhCEK0Zec9NOzsvh-Sk6-uecsM4ybMm/w640-h360/otp.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgO1f4pe7Mq-bWKrVT-nlHfzZV-286dtWoTNnKqN72xalJr9R43HNDr4upArA7pWdD7rZf0p8aHsXbz8dPHWguKJ7x_tgqwV8em4x_2tIFtSMennhhCEK0Zec9NOzsvh-Sk6-uecsM4ybMm/)

When verifying the ownership of a phone number, it is typically done by sending a one-time-password (OTP) over SMS which must be manually entered by the user (or copied and pasted). This manual user flow requires directing the user to the native SMS app and back to their web app with the code. With the Web OTP API, developers can help users enter the code with one tap.  
For more information, see [Verify phone numbers on the web with the Web OTP API](https://web.dev/web-otp/).  

Web Animations
==============

Animations on the web help users navigate a digital space, help users remember your app or site, and provide implicit hints around how to use your product. Now, developers have greater control over web animations with the Web Animations API.  
Although parts of the API have been around for some time, the new implementation in Chrome is a milestone in its development. In addition to greater spec compliance, Chrome now supports compositing operations, which control how effects are combined and offers many new hooks which enable replaceable events. Additionally, the API now supports Promises, which allow for animation sequencing and for greater control over how animations interact with other app features.   
For more information and instructions for using web animations, see [Web Animations API improvements in Chromium 84](https://web.dev/web-animations/).
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgEsHnOkB-ot98KTIbKAwXkBb9Tv-hRaHFg7lEmlzOLjNsDbBZswxNhdeW7PWX0maMqp04bQVxaKbDLCx8NeJYGiIG_6XsfJRv_NBUiu0NdydNQhA5w2c_tlGlKKbYwveKrH6xlNLbFsvVC/w640-h404/animation.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgEsHnOkB-ot98KTIbKAwXkBb9Tv-hRaHFg7lEmlzOLjNsDbBZswxNhdeW7PWX0maMqp04bQVxaKbDLCx8NeJYGiIG_6XsfJRv_NBUiu0NdydNQhA5w2c_tlGlKKbYwveKrH6xlNLbFsvVC/)  

Origin Trials
=============

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials themselves, visit the [Origin Trials Guide for Web Developers](https://github.com/GoogleChrome/OriginTrials/blob/gh-pages/developer-guide.md).  

New Origin Trials
-----------------

### Cookie Store API

The Cookie Store API [exposes HTTP cookies to service workers](https://www.chromestatus.com/feature/5658847691669504) and offers an asynchronous alternative to document.cookie.  

### Idle Detection

The Idle Detection API notifies developers when a user is idle, indicating such things as lack of interaction with the keyboard, mouse, screen, activation of a screensaver, locking of the screen, or moving to a different screen. A developer-defined threshold triggers the notification. For more information, see [Detect inactive users with the Idle Detection API](https://web.dev/idle-detection/).  

### Origin Isolation

[Origin isolation](https://www.chromestatus.com/feature/5683766104162304) allows web developers to opt in to giving up certain cross-origin same-site access capabilities—namely synchronous scripting via document.domain, and calling `postMessage()` to `WebAssembly.Module` instances. This gives the browser more flexibility in implementation technologies. In particular, Chrome now uses this as a hint to put the origin in its own process, subject to resource or platform limitations.  
Site isolation, i.e. process-per-site, is the current state of the art in protecting websites from each other. Certain legacy features prevent us from aligning this protection boundary with the origin boundary. Origin isolation allows developers to voluntarily give up these legacy features, in exchange for better isolation.  

### WebAssembly SIMD

WebAssembly SIMD [exposes hardware SIMD instructions to WebAssembly](https://www.chromestatus.com/features/6533147810332672) applications in a platform-independent way. The SIMD proposal introduces a new 128-bit value type that can be used to represent different types of packed data, and several vector operations that operate on packed data.  
SIMD can boost performance by exploiting data level parallelism and is also useful when compiling native code to WebAssembly.  

Completed Origin Trials
-----------------------

The following features, previously in a Chrome origin trial, are now enabled by default.  

### Content Indexing API

The Content Indexing API, now out of its origin trial, provides metadata about content that your web app has already cached. More specifically, it stores URLs for HTML documents that display stored media. The new API lets you add, list, and remove resources. Browsers can use the information in the index to display a list of offline-capable content. For more information, read [Indexing your offline-capable pages with the Content Indexing API](https://web.dev/content-indexing-api/).  

### Wake Lock API Based on Promises

The [Wake Lock API has been updated with promises](https://www.chromestatus.com/feature/4636879949398016). The Wake Lock API brought a standard, secure, and safe way to prevent some device features such as the screen or CPU cycles from going into power saving state. This update addresses some of the shortcomings of the older API which was limited to screen Wake Lock and didn't address certain security and privacy issues.   

Other Features in this Release
==============================

### App shortcuts

To improve users' productivity and facilitate re-engagement with key tasks, Chrome now supports app shortcuts in Android. They allow web developers to provide quick access to a handful of common actions that users need frequently. For sites that are already Progressive Web Apps, creating shortcuts requires only adding items to the web app manifest. For more information, see [Get things done quickly with app shortcuts](https://web.dev/app-shortcuts).  

### Autoupgrade Image Mixed Content

"Mixed content" is when an HTTPS page loads content such as scripts or images over insecure HTTP. Previously, mixed images were allowed to load, but the lock icon was removed and, as of Chrome 80, replaced with a Not Secure chip. This was confusing and did not sufficiently discourage developers from loading insecure content that threatens the confidentiality and integrity of users' data. Starting in Chrome 84, [mixed image content will be upgraded to https](https://www.chromestatus.com/feature/4926989725073408) and images will be blocked if they fail to load after upgrading. Auto upgrading of mixed audio and video content [is expected in a future release](https://www.chromestatus.com/feature/5557268741357568).  

### Blocking Insecure Downloads from Secure (HTTPS) Contexts

Chrome intends to block insecurely-delivered downloads initiated from secure contexts ("mixed content downloads"). Once downloaded, a malicious file can circumvent any protections Chrome puts in place. Furthermore, Chrome does not and cannot warn users by downgrading security indicators on secure pages that initiate insecure downloads, as it does not reliably know whether an action will initiate an insecure download until the request is made.   
  
User-visible warnings will start in Chrome 84 on desktop with plans to block insecure downloads completely in Chrome 88. Warnings will not appear in Android until Chrome 85. For details, see [Protecting users from insecure downloads in Google Chrome](https://blog.chromium.org/2020/02/protecting-users-from-insecure.html).  

### ReportingObserver on Workers

The ReportingObserver API, added in Chrome 69, provides a JavaScript callback function invoked in response to deprecations and browser interventions. The report can be saved, sent to the server, or or handled using arbitrary JavaScript. This feature is designed to give developers greater insight into the operation of their sites on real-world devices. Starting in Chrome 84, this API is exposed on workers. For more information on the API, see [Know your code health with the ReportingObserver API](https://web.dev/reporting-observer/).  

### Resize Observer Updates

The Resize Observer API was updated to conform to recent specs. ResizeObserverEntry has three new properties, `contentBoxSize`, `borderBoxSize`, and `devicePixelContentBoxSize` to provide more detailed information about the DOM feature being observed. This information is returned in an array of `ResizeObserverSize` objects, which are also new. For information about the API generally, including updates about the features, see `ResizeObserver`: it's like `document.onresize` for elements.  

### revert Keyword

The revert keyword [resets the style of an element](https://www.chromestatus.com/feature/5644990145363968) to the browser default.  

### Unprefixed Appearance CSS Property

[An unprefixed version of `-webkit-appearance`](https://www.chromestatus.com/feature/4715298156445696) is now available in CSS as `appearance`.  

### Unprefixed ruby-position CSS Property

The `ruby-position` property is now supported  
in Chrome. This is an unprefixed version of -webkit-ruby-position, which controls the position of a ruby annotation. This property has three possible values: `over`, `under`, and `inter-character`, but Chrome has only implemented the first two. This change creates feature parity with Firefox.
  

### Web Authenticator API: Cross-origin iframe Support

Adds support for [web authentication calls from cross-origin iframes](https://www.chromestatus.com/feature/5736091539734528) if enabled by a feature policy. This brings Chrome in line with the [Web Authentication Level Two](https://w3c.github.io/webauthn/#sctn-iframe-guidance) specification.  

JavaScript
==========

This version of Chrome incorporates version 8.4 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.  

Private Methods and Accessors
-----------------------------

Keeping state and behavior private to a class lets library authors present a clear, stable interface, while changing their code over time behind the scenes. Private class fields, which [shipped in Chrome 74](https://v8.dev/features/class-fields), added private fields for classes and instances. Now in Chrome 84, [methods and properties can also be private](https://www.chromestatus.com/feature/5700509656678400). With this enhancement, any JavaScript class element can be private.  

Weak references
---------------

The V8 engine now supports weak references to JavaScript objects, which help web developers define cleanup routines that don't keep the related objects alive but are (optionally) executed after the related object is garbage-collected. For more information, see [Weak references and finalizers](https://v8.dev/features/weak-references).  

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).  

@import rules in CSSStyleSheet.replace() Removed
------------------------------------------------

The original spec for constructable stylesheets allowed for calls to:  
  

```
sheet.replace("@import('some.css');")
```

  
[This use case is being removed](https://www.chromestatus.com/feature/4735925877735424). Calls to `replace()` now throw an exception if `@import` rules are found in the replaced content.  

Remove TLS 1.0 and TLS 1.1
--------------------------

TLS (Transport Layer Security) is the protocol which secures HTTPS. It has a long history stretching back to the nearly twenty-year-old TLS 1.0 and its even older predecessor, SSL. Both TLS 1.0 and 1.1 have a number of weaknesses.  

* TLS 1.0 and 1.1 use MD5 and SHA-1, both weak hashes, in the transcript hash for the Finished message.
* TLS 1.0 and 1.1 use MD5 and SHA-1 in the server signature. (Note: this is not the signature in the certificate.)
* TLS 1.0 and 1.1 only support RC4 and CBC ciphers. RC4 is broken and has since been removed. TLS's CBC mode construction is flawed and is vulnerable to attacks.
* TLS 1.0's CBC ciphers additionally construct their initialization vectors incorrectly.
* TLS 1.0 is no longer PCI-DSS compliant.

Supporting TLS 1.2 is a prerequisite to avoiding the above problems. The TLS working group has deprecated TLS 1.0 and 1.1. Chrome has now also deprecated these protocols.