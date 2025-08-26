URL:https://blog.chromium.org/2010/03/google-chrome-developer-update.html
# Google Chrome Developer Update - Geolocation and Incognito Extensions
- **Published**: 2010-03-26T18:12:00.000-07:00
**What's New in Google Chrome?**

The Google Chrome Dev channel has been updated to [5.0.356.2](http://googlechromereleases.blogspot.com/2010/03/dev-update-fix-for-tabs-hanging-after.html) for all platforms since our last developer post. It includes a few new goodies for developers:

* [Geolocation API](http://dev.w3.org/geo/api/spec-source.html): Run with the --enable-geolocation flag.
* [Incognito extensions](http://code.google.com/chrome/extensions/trunk/overview.html#incognito)
* Unpacked extensions are now remembered across browser restarts.
* [Favicons for extension pages](http://code.google.com/chrome/extensions/trunk/manifest.html#icons) (define with a 16x16 image in your manifest.json).
* [setPopup()](http://code.google.com/chrome/extensions/dev/browserAction.html#method-setPopup) was added to browserAction and pageAction for dynamically changing which popup to show based on the selected tab.

Please keep in mind that these features are still under development and are not 100% stable yet. In addition to the above, there are a few new experimental features baking in /trunk. You can try them out with the --enable-experimental-extension-apis flag:

* [chrome.experimental.infobars](http://code.google.com/chrome/extensions/trunk/experimental.infobars.html)
* [chrome.experimental.contextMenu](http://code.google.com/chrome/extensions/trunk/experimental.contextMenu.html)

**Samples and Tutorials**

We’ve added a few new sample extensions tutorials to get you started:

* [Sample](http://src.chromium.org/viewvc/chrome/trunk/src/chrome/common/extensions/docs/examples/tutorials/analytics/) and [tutorial](http://code.google.com/chrome/extensions/trunk/tut_analytics.html) to demonstrate using Google Analytics in your extensions
* [Extension](http://src.chromium.org/viewvc/chrome/trunk/src/chrome/common/extensions/docs/examples/extensions/gdocs/) to display, create, and update your Google Documents
* [Tutorial](http://code.google.com/chrome/extensions/trunk/tut_oauth.html) to demonstrate using OAuth in your extensions

Remember to follow us on Twitter: [@ChromiumDev](http://twitter.com/chromiumdev)!

Posted by Eric Bidelman, Developer Advocate