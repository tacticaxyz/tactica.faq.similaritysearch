URL:https://blog.chromium.org/2010/06/google-chrome-developer-update-google.html
# Google Chrome Developer Update - Google I/O recap, new APIs
- **Published**: 2010-06-07T18:06:00.000-07:00
**Google I/O recap**

If you missed the [Day 1 keynote](http://code.google.com/events/io/2010/) this year, it was all about the open web. There were some amazing demos from Mugtug, TweetDeck, Adobe, and Sports Illustrated demonstrating the full potential of HTML5. There was a preview of [WebM/VP8](http://webmproject.blogspot.com/2010/05/introducing-webm-open-web-media-project.html), a high-quality, open, and web-optimized video format. We saw the announcement of the [Chrome Web Store](http://code.google.com/chrome/apps/), which later this year will provide a new and exciting channel for developers to distribute their web apps and reach new users. We also launched the [Google Font API](http://code.google.com/apis/webfonts/), which allows you to add high-quality web fonts to any web page. Lastly, there were all of the great [Chrome sessions](http://code.google.com/events/io/2010/sessions.html#Chrome). Videos have been posted on the Google I/O website:

* [Developing with HTML5](http://code.google.com/events/io/2010/sessions/developing-with-html5.html)
* [Developing web apps for the Chrome Web Store](http://code.google.com/events/io/2010/sessions/web-apps-chrome-web-store.html)
* [Beyond JavaScript: programming the web with native code](http://code.google.com/events/io/2010/sessions/native-code-chrome.html)
* [Chrome extensions - how-to](http://code.google.com/events/io/2010/sessions/chrome-extensions.html)
* [Google Chrome's Developer Tools](http://code.google.com/events/io/2010/sessions/chrome-developer-tools.html)
* [Using Google Chrome Frame](http://code.google.com/events/io/2010/sessions/using-chrome-frame.html)
* [HTML5 status update](http://code.google.com/events/io/2010/sessions/html5-status-chrome.html)
* [WebM Open Video Playback in HTML5](http://code.google.com/events/io/2010/sessions/webm-open-video-playback-html5.html)

**What's new for developers in Google Chrome?**

The Google Chrome Dev channel is now up to [6.0.422.0](http://googlechromereleases.blogspot.com/2010/06/dev-channel-update.html). It includes a bunch of new features to think about when developing your apps:

* [Desktop notifications](http://dev.chromium.org/developers/design-documents/desktop-notifications/api-specification) (new since our last developer update)
* [File API](http://www.w3.org/TR/FileAPI/) and [FileReader API](http://dev.w3.org/2006/webapi/FileAPI/#filereader-interface): Drag and drop files from the desktop to the browser!
* [Native Client (NaCl) SDK](http://blog.chromium.org/2010/05/sneak-peek-at-native-client-sdk.html) and [ports](http://code.google.com/p/naclports/): Run with [--enable-nacl](http://code.google.com/p/nativeclient-sdk/wiki/RunningModules).
* [HTML5 sandbox attribute](http://blog.chromium.org/2010/05/security-in-depth-html5s-sandbox.html)
* Integrated Flash Player plugin: Run dev channel with --enable-internal-flash.

In addition to the above, there are new experimental extension APIs:

* [chrome.experimental.cookies](http://code.google.com/chrome/extensions/dev/experimental.cookies.html)
* [chrome.experimental.clipboard](http://code.google.com/chrome/extensions/dev/experimental.clipboard.html)
* [chrome.experimental.omnibox](http://code.google.com/chrome/extensions/dev/experimental.omnibox.html)

You can try out these features by launching a Dev-channel version of Google Chrome with the --enable-experimental-extension-apis flag and adding the ‘experimental’ permission in your [manifest.json](http://code.google.com/chrome/extensions/trunk/manifest.html#permissions) file. Please keep in mind that these features are still under development and are not 100% stable yet.

**Upcoming developer events**

For those of you based in New York, there’s an upcoming Chrome Extensions hackathon in our local office on June 10, 2010. We also have a five day DevFest starting June 28, 2010 in Sydney, Australia. Google Chrome will be featured on Wednesday, June 30. Stay tuned for more details!

For the latest news and upcoming developer events, subscribe to this blog and follow us on Twitter [@ChromiumDev](http://twitter.com/chromiumdev).

Posted by Eric Bidelman, Google Chrome Developer Relations