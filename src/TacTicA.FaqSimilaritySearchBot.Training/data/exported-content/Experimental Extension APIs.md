URL:https://blog.chromium.org/2010/03/experimental-extension-apis.html
# ​Experimental Extension APIs
- **Published**: 2010-03-01T10:27:00.000-08:00
You might have already noticed this, but we now have some APIs that we’re referring to as [experimental](http://code.google.com/chrome/extensions/trunk/experimental.html). The idea is that we can add new APIs to the platform that may not be ready for prime time. This allows you to play with these APIs and give us feedback before they’re final, which in turn helps us get them out to everybody more quickly.

Our first two experimental APIs — [chrome.experimental.history](http://code.google.com/chrome/extensions/trunk/experimental.history.html) and [chrome.experimental.processes](http://code.google.com/chrome/extensions/trunk/experimental.processes.html) — are available on the dev channel. The history API lets you query and modify the user’s browsing history. When it’s finalized, we’ll also allow you to replace the history page with your own, just like you can [replace the new tab page](http://code.google.com/chrome/extensions/override.html) today. The processes API allows access to information about Google Chrome’s process model, including process IDs and the CPU usage of individual tabs. The processes API is incomplete, but you can see upcoming features in its [design doc](http://dev.chromium.org/developers/design-documents/extensions/processes-api).

These APIs have a few major limitations. First, to use an experimental API you must add a command-line flag when you start Google Chrome (--enable-experimental-extension-apis). Second, you can’t upload extensions that use experimental APIs to the Google Chrome Extensions Gallery. Finally, these APIs will change in incompatible ways, so the code that you write today isn’t guaranteed to work tomorrow.

What this really means is that these APIs are only useful for you to play with. You won’t be able to share extensions that use these APIs with a lot of people. However, we’d really like you to try them out and [give us feedback](http://groups.google.com/a/chromium.org/group/chromium-extensions). Doing so will help us release the APIs more quickly and make sure they do everything you need. Playing with the experimental APIs is also a way for you to get experience with them before most other developers.

We expect to add more experimental APIs over time, so keep an eye out for future announcements.

Posted by Erik Kay, Software Engineer