URL:https://blog.chromium.org/2022/04/chrome-102-window-controls-overlay-host.html
# Chrome 102: Window Controls Overlay, a Host of Finished Origin Trials, PWAs as File Handlers and More
- **Published**: 2022-04-28T11:51:00.005-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 102 is beta as of April 28, 2022. You can [download the latest on Google.com](https://www.blogger.com/blog/post/edit/2471378914199150966/133027011330334491) for desktop or on Google Play Store on Android.

Window Controls Overlay for Installed Desktop Web Apps
======================================================

Window controls overlay extends an app's client area to cover the entire window, including the title bar, and the window control buttons (close, maximize/restore, minimize). The web app developer is responsible for drawing and input handling for the entire window except for the window controls overlay. Developers can use this feature to make their installed desktop web apps look like operating system apps. For more information, see [Customize the window controls overlay of your PWA's title bar](https://web.dev/window-controls-overlay/).

![](https://lh6.googleusercontent.com/JU0Cd19KJlszHgMGTxOpUxBq91tpDSwbKL1B-Q9U_feFiY3RH_KQ0xpC5KssHmkuRJkDs-ML6St5Hocgj3_3BmzAd9jdIBeAhlexRK_9c1y7mtis5tJKT4AP9ILeg68irGKTRuum2RyE--NmU2JfTww)

Completed Origin Trials
=======================

The following features, previously in a Chrome origin trial, are now enabled by default. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

### Capture Handle

A new mechanism allows an application to opt-in to [exposing information to applications that are video-capturing it](https://www.chromestatus.com/feature/4854125411958784). This allows collaboration between capturing and captured applications. For example, a video conference application that's video-capturing a presentation, could expose user-facing controls in the video conference tab for navigating the presentation in the captured tab.

### Network State Partitioning

Network state is [now partitioned by the network partition key](https://chromestatus.com/feature/6713488334389248) (which consists of top frame site and possibly frame site), to protect against cross-site tracking through the use of side channels. "Network State" here includes connections (H1, H2, H3, websocket), the DNS cache, ALPN/H2 support data, TLS/H3 resumption information, Reporting/NEL configuration and uploads, and Expect-CT information. Cross-site tracking is a major privacy concern for users. This is a necessary part of addressing the problem.

### Speculation Rules

[Speculation rules](https://www.chromestatus.com/feature/5740655424831488) provides a flexible syntax for defining what outgoing links are eligible to be prefetched before navigation. It also enables additional enhancements, such as use of a private prefetch proxy, where applicable.

### Subresource loading with Web Bundles

This feature [provides a new approach to loading](https://www.chromestatus.com/feature/5710618575241216) a large number of resources efficiently using a format that allows multiple resources to be bundled, e.g. Web Bundles.

Other Features in this Release
==============================

File Handlers Web App Manifest Member
-------------------------------------

File Handling provides a way for web applications to declare the ability to handle files with given MIME types and extensions. The web application will receive an event when the user intends to open a file with that web application.

To define a PWA as a file handler, add the `file_handlers` member to the Web App Manifest. You can [read about its members in the spec](https://web.dev/file-handling/).

inert Attribute
---------------

The new `inert` attribute lets you mark parts of the DOM tree as inert. When a node is inert:

* Hit-testing must act as if the `pointer-events` CSS property were set to `'none'`.
* Text selection functionality must act as if the `user-select` CSS property were set to `'none'`.
* If it is editable, the node behaves as if it were non-editable.
* The user agent may ignore the node for the purposes of find-in-page.

For more information, see [Introducing inert](https://developer.chrome.com/blog/inert/).

Local Font Access
-----------------

Web applications can now [enumerate local fonts and metadata about each](https://web.dev/local-fonts/). The new API also gives web applications access to table data stored within local fonts, allowing those fonts to be rendered within their applications using custom text stacks.

**Notes:** This feature actually shipped in 103 instead of 102 as originally reported.

Navigation API
--------------

The new [`Navigation` interface](https://github.com/WICG/navigation-api/blob/main/README.md) (accessible on window) lets apps intercept and initiate navigations, and introspect an application's history entries. This provides a more useful alternative to `window.history` and `window.location` specifically aimed at the needs of single-page web applications.

New until-found Value for the hidden Attribute
----------------------------------------------

Chrome adds a new value, `until-found`, for the `hidden` attribute, which makes an element searchable by find-in-page, scroll to text fragment, and fragment navigation. When these search/navigation features want to scroll to something inside a `hidden=until-found` element, the browser removes the hidden attribute from the element and fires the `beforematch` event on it so that the newly revealed content can be scrolled into view. For more information, see [Making collapsed content accessible with hidden=until-found - Chrome Developers](https://developer.chrome.com/blog/hidden-until-found/).

Origin Private File System extension: AccessHandle
--------------------------------------------------

The [Origin Private File System](https://www.chromestatus.com/feature/5702777582911488) (part of the File System Access API) is augmented with a new surface that improves the performance of data access. This new surface differs from existing ones by offering in-place and exclusive write access to a file's content. This change, along with the ability to consistently read unflushed modifications and the availability of a synchronous variant on dedicated workers, significantly improves performance and unblocks new use cases.

Private Network Access Preflight Requests for Subresources
----------------------------------------------------------

A [CORS preflight request is now sent ahead of schedule for private network requests](https://chromestatus.com/feature/5737414355058688) for subresources, requesting explicit permission from the target server. If the preflight fails, a warning is displayed in DevTools but the request proceeds as before. This is not expected to be a breaking change. Websites whose servers ignore or fail the new preflight request will continue to work as before.

A private network request is any request from a public website to a private IP address or localhost, or from a private website (e.g. intranet) to localhost. Sending a preflight request mitigates the risk of cross-site request forgery attacks against private network devices such as routers, which are often not prepared to defend against this threat.

Secure Payment Confirmation API Changes
---------------------------------------

This release contains [three changes](https://www.chromestatus.com/feature/5675682238562304) to the [Secure Payment Confirmation](https://github.com/w3c/secure-payment-confirmation/blob/main/explainer.md) API, specifically to the data passed to the `PaymentMethod()` constructor.

* A new required property, [`data.rpId`](https://w3c.github.io/secure-payment-confirmation/#dom-securepaymentconfirmationrequest-rpid), which should contain the relying party ID. Implementations that don't currently specify this will need to be updated.
* A new optional property, [`data.instrument.iconMustBeShown`](https://w3c.github.io/secure-payment-confirmation/#dom-paymentcredentialinstrument-iconmustbeshown), allows a placeholder icon to be used when the card art icon cannot be downloaded. Setting this field to false allows a payment to proceed when the icon can be downloaded. The default is true.
* A new optional property, [`data.payeeName`](https://w3c.github.io/secure-payment-confirmation/#dom-securepaymentconfirmationrequest-payeename), allows callers to display a natural name for the payee instead of or alongside the existing [`data.payeeOrigin`](https://w3c.github.io/secure-payment-confirmation/#dom-securepaymentconfirmationrequest-payeeorigin).

WebHID exclusionFilters Option in requestDevice()
-------------------------------------------------

The options object passed [`HID.requestDevice()`](https://developer.mozilla.org/en-US/docs/Web/API/HID/requestDevice) [now includes an exclusionFilters property](https://www.chromestatus.com/feature/5194022623641600). (HID is accessed via `navigator.hid`.) This property lets you exclude some devices from the browser picker. You can use it to exclude devices that are known to be malfunctioning. Previously, developers had to test a selected device with custom code, then ask the user to pick another if the selected device did not work. The [exclusionFilters property](https://web.dev/hid/#:~:text=exclusionFilters) (you will need to search for that term in the text) is an array of objects with the same members as the [existing options](https://developer.mozilla.org/en-US/docs/Web/API/HID/requestDevice#parameters).

Here's an example of how to use the requestDevice() options argument. The example first requests access to a device with vendor ID 0xABCD. The device must also have a collection with usage page Consumer (0x000C) and usage ID Consumer Control (0x0001). The device with product ID 0x1234 is malfunctioning.

```
const [device] = await navigator.hid.requestDevice({
 filters: [{ vendorId: 0xabcd, usagePage: 0x000c, usage: 0x0001 }],
 exclusionFilters: [{ vendorId: 0xabcd, productId: 0x1234 }],
});
```

Deprecations, and Removals
==========================

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

Deprecate PaymentRequest.show() without User Activation
-------------------------------------------------------

Sites can [no longer call `PaymentRequest.show()` without a user activation](https://chromestatus.com/feature/5948593429020672). Allowing `PaymentRequest.show()` to be triggered without a user activation could be abused by malicious websites. To protect users, the spec was changed to require user activation. To avoid a broken purchase experience, calls to this method should now be inside a user event such as `click`.

Firefox has not shipped `PaymentRequest` at all, while Safari's implementation already requires user activation for calling `show()`.

Remove SDP Plan B
-----------------

The Session Description Protocol (SDP) used to establish a session in WebRTC has been implemented with two different dialects in Chromium: Unified Plan and Plan B. Plan B is not cross-browser compatible and [is hereby removed](https://www.chromestatus.com/features/5823036655665152).

In this version of Chrome an exception will be thrown when Plan B is used. Developers needing to avoid the exception can participate in a [deprecation trial until May 25, 2022](https://developer.chrome.com/origintrials/#/view_trial/3892235977954951169). If you participated in the previous deprecation trial that ended in December, and want to participate in the current trial, you will need to request a new token.