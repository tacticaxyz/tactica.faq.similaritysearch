URL:https://blog.chromium.org/2009/06/important-updates-for-extension.html
# Important Updates for Extension Developers
- **Published**: 2009-06-17T17:48:00.000-07:00
We're excited to see many people are experimenting with the upcoming extension features of Chrome in the dev channel. We're getting a lot of great feedback and are working hard to bring extensions to the stable channel as quickly as possible.

First of all, we've set up a new discussion group for extension-related topics. Going forward, [chromium-extensions](http://groups.google.com/group/chromium-extensions) will be your one-stop shop for extension development news, feedback and questions. If you're interested in developing extensions, we invite you to [join us at chromium-extensions](http://groups.google.com/group/chromium-extensions/subscribe).

Second, as part of the latest dev channel release, we've had to make a breaking change to the crx format. This change adds signatures to our package format, which are necessary to enable automatic updates. Unfortunately, this means that any existing extensions will stop working, and will have to be repackaged.

* **If you've developed an extension**, you can learn how to repackage your extensions for Chrome v 3.0.189.0 in the [packaging doc](http://dev.chromium.org/developers/design-documents/extensions/packaging) on our developer site. Note that your extension ID will now be your public key, so you'll have to change any code that uses that.
* **If you're using an extension someone else has developed**, you will have to reinstall it once the developer has repackaged it (as described above). We've already updated our [sample extensions](http://dev.chromium.org/developers/design-documents/extensions/samples).

Even though the whole point of the dev channel is to make our APIs available early while they're still changing, we don't make these changes lightly. Once we push the extension system to the stable channel, breaking changes should be very rare (we'd like to say non-existent, but we don't want to jinx ourselves).

  
Posted by Nick Baum, Product Manager