URL:https://blog.chromium.org/2021/06/chrome-92-web-apps-as-file-handlers-new.html
# Chrome 92: Web Apps as File Handlers, New JavaScript Features, and More
- **Published**: 2021-06-03T12:50:00.002-07:00
Unless otherwise noted, changes described below apply to the newest Chrome beta channel release for Android, Chrome OS, Linux, macOS, and Windows. Learn more about the features listed here through the provided links or from the list on [ChromeStatus.com](https://www.chromestatus.com/features#milestone%3D76). Chrome 92 is beta as of June 3, 2021

File Handling API
-----------------

Now that web apps are capable of reading and writing files, the next logical step is to let developers declare web apps as file handlers for files they create and process. The File Handling API allows you to do exactly this. For example, after a text editor PWA has registered itself as a file handler, you can right-click a .txt file in your operating system's file manager and instruct this PWA to (always or just once) open .txt files. This means PWAs are just a (double) click away from the file manager.

[![The Excalidraw context menu.](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjFAVpwZ-UU8jXBzlw8sqU0-uOUBqwJbta3NbRyYGsOBeHhxgbuXVL9Pe657BO-Q_vsVJJYJqeVIqpbG_gO9kRMseAJDU_kY7eJYlwPQd2qr1i9YglFA1TR9j9bgZMi6J3kLPsiUAAXYyee/s16000/excontext.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjFAVpwZ-UU8jXBzlw8sqU0-uOUBqwJbta3NbRyYGsOBeHhxgbuXVL9Pe657BO-Q_vsVJJYJqeVIqpbG_gO9kRMseAJDU_kY7eJYlwPQd2qr1i9YglFA1TR9j9bgZMi6J3kLPsiUAAXYyee/s309/excontext.png)

  

This improves the user experience for PWA use cases, making them more like OS apps than they are already. For example:

* Office applications like text editors, spreadsheet apps, and slideshow creators.
* Graphics editors and drawing tools.
* Video game level editor tools.

File Handling is starting an origin trial in 92 that is expected to run until around the end of August, 2021. For more information on this feature, see [Let web applications be file handlers](https://web.dev/file-handling/). For information about other origin trials in this release, see [Origin Trials](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#Origin-Trials), below.

Origin Trials
-------------

This version of Chrome introduces the origin trials described below. Origin trials allow you to try new features and give feedback on usability, practicality, and effectiveness to the web standards community. To register for any of the origin trials currently supported in Chrome, including the ones described below, visit the [Chrome Origin Trials dashboard](https://developers.chrome.com/origintrials/#/trials/active). To learn more about origin trials in Chrome, visit the [Origin Trials Guide for Web Developers](https://web.dev/origin-trials/). Microsoft Edge runs its own origin trials separate from Chrome. To learn more, see the [Microsoft Edge Origin Trials Developer Console](https://developer.microsoft.com/en-us/microsoft-edge/origin-trials/).

### New Origin Trials

#### Shared Element Transitions

[Shared Element Transitions](https://www.chromestatus.com/feature/5193009714954240) allows a simple set of transitions in both single-page applications (SPAs) and multi-page applications (MPAs). This enhances the visual polish of pages with minimal effort by letting developers select from a set of user-agent provided transition effects. Without this, single-page app transitions are difficult since they require a careful coordination of animations and DOM manipulations to achieve the desired effect. Multi-page app transitions are, for the most part, not possible since each page can only control the contents of its own view. This origin trial is only for SPA use cases.

Other features in this release
------------------------------

### Change in Allowed App Shortcuts

Most Android launchers now allow only three app shortcuts instead of the previously allowed four. A shortcut to the site settings was added to the application icon in the Android launcher, taking one of the available shortcut slots for the app. For more information, see [Get things done quickly with app shortcuts](https://web.dev/app-shortcuts/).

### CSS

#### size-adjust Descriptor for @font-face

[Adds the size-adjust descriptor for `@font-face`](https://www.chromestatus.com/feature/5662073285509120) allowing scaling of glyph sizes for a particular font face without affecting the CSS `font-size` and derived metrics such as em. CSS `font-size` can be seen as a scale factor for a box that the font draws in. Glyph sizes within that box vary between fonts, and size-adjust enables harmonising them across different fonts. That's why it reduces cumulative layout shift by matching up the fallback font and primary web font using this descriptor.

### Imperative Slot Distribution Behavior

[Imperative slotting](https://www.chromestatus.com/feature/4979822998585344) allows node-to-slot assignments without needing the slot attribute in markup. This enables dynamic slotting behavior based on input conditions and types. The feature originally shipped in [Chrome 86](https://chromestatus.com/feature/5711021289242624); in this release some adjustments to the API have been made to ensure interoperability with other browsers.

### JavaScript

This version of Chrome incorporates version 9.2 of the V8 JavaScript engine. It specifically includes the changes listed below. You can find a complete [list of recent features](https://v8.dev/blog) in the V8 release notes.

#### Add dayPeriod option for Intl.DateTimeFormat

A [dayPeriod option](https://www.chromestatus.com/feature/6520669959356416) (part of ECMA402 2021) has been added to the `Intl.DateTimeFormat()` method so the caller can format times such as "7 in the morning", "11 in the morning", "12 noon", "1 in the afternoon", "6 in the evening", "10 at night" (or in Chinese, "清晨7時", "上午11時", "中午12時", "下午1時" ,"下午6時" ,"晚上10時").

This enhances `Intl.DateTimeFormat()` to match what is already possible in C++ and Java by calling ICU and ICU4J. Without this feature, developers need to either format the quarter in the server or ship a set of day period patterns and hour to day period mappings from the server to client to perform such tasks.

#### Relative Indexing Method for Array, String, and TypedArrays

[Adds a new method named `at()`](https://www.chromestatus.com/feature/6123640410079232), to `Array.prototype`, `String.prototype`, and the `TypedArray` prototypes, that permit relative indexing with negative indices. For example:  
  
`let arr = [1,2,3,4];  
arr.at(-1); // Returns 4`

#### Intl BestFitMatcher by Using ICU LocaleMatcher

The ICU LocaleMatcher [now implements the BestFitMatcher](https://www.chromestatus.com/feature/5407573287108608) abstract operation to better match locale data.

#### SharedArrayBuffers on Desktop Platforms Restricted to Cross-Origin Isolated Environments

`SharedArrayBuffers` on desktop platforms are now restricted to cross-origin isolated environments, matching the behavior recently shipped on Android and Firefox. A Cross-origin isolated page is considered a secure environment because it blocks loading cross-origin resources that are not opt-in and communicating with cross-origin windows. Only pages that opt-in to cross-origin isolation will be able to use `SharedArrayBuffers`. Learn more about the upcoming options at [`SharedArrayBuffer` updates in Android Chrome 88 and Desktop Chrome 92](https://developer.chrome.com/blog/enabling-shared-array-buffer/).

### Media Session API: Video conferencing actions

Adds actions to the Media Session API, specifically `"togglemicrophone"`, `"togglecamera"`, and `"hangup"`. This enables developers of video conferencing websites to handle these actions from the browser interface. For example, if the user puts their video call into a picture-in-picture window, the browser could display buttons for mute/unmute, turn-on/turn-off camera, and hanging up. When the user clicks these, the website handles them through the Media Session API. For more information, see the section from [our recent article](https://web.dev/media-session/#video-conferencing-actions), or try [our demo](https://googlechrome.github.io/samples/media-session/video-conferencing.html).

### Tainted Origin Flag applied to Resource Timing

Chrome now [accounts for the tainted origin flag](https://www.chromestatus.com/feature/5665918254317568) when computing whether a fetched resource passes the timing allow origin check. The timing allow origin check is used in resource timing to determine whether the page can receive detailed timing information about a resource used in the page. The tainted origin flag impacts this check in cases where there are multiple redirects that cross origins. In those cases, the header should be '\*'. In other words, it can no longer be a specific origin.

If a resource performs two cross-origin crosses (via redirects), then the developer needs to use `Timing-Allow-Origin: *` for the checks to pass. For example if a page on origin A fetches a resource on origin B, which redirects to a resource on origin C, then the tainted origin flag is set and the final resource needs to have `Timing-Allow-Origin: *` in order to receive detailed timing information."

### URL Protocol Handler Registration for PWAs

Web applications can now register themselves as handlers of custom URL protocols or schemes using their web app manifests. Operating system applications often register themselves as protocol handlers to increase discoverability and usage. Websites can already register to handle schemes via registerProtocolHandler(), it is desirable to have web apps be first-class citizens and be launched directly when a custom-scheme link is invoked.

### Web Bluetooth Manufacturer Data Filter

The Web Bluetooth API can now filter based on manufacturer data such as vendor ID and product ID. Developers have been able to prompt users through a browser picker to select a nearby Bluetooth device that matches their advertised name and services. However it hasn't been possible to filter nearby Bluetooth devices based on advertised manufacturer specific data. Manufacturer data is specified through new properties on options.filters, which is passed to `Bluetooth.requestDevice()`. For more information, see [Communicating with Bluetooth devices over JavaScript](https://web.dev/bluetooth/#manufacturer-data-filter) or try [our demo](https://googlechrome.github.io/samples/web-bluetooth/manufacturer-data-filter.html).

Deprecations and Removals
-------------------------

This version of Chrome introduces the deprecations and removals listed below. Visit ChromeStatus.com for lists of [current deprecations](https://www.chromestatus.com/features#browsers.chrome.status%3A%22Deprecated%22) and [previous removals](https://www.chromestatus.com/features#browsers.chrome.status:%22Removed%22).

### Payment Handlers for Standardized Payment Method Identifiers

This feature, which enabled web-based payment handlers to receive `paymentrequest` events with non-URL, but standardized payment method identifiers, such as `"basic-card"` or `"tokenized-card"`, [has been removed](https://www.chromestatus.com/feature/5407573287108608).