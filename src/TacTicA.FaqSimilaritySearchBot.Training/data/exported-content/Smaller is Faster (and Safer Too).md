URL:https://blog.chromium.org/2009/07/smaller-is-faster-and-safer-too.html
# Smaller is Faster (and Safer Too)
- **Published**: 2009-07-15T10:26:00.000-07:00
We have just started using a new compression algorithm called Courgette to make Google Chrome updates small.

We have built Google Chrome to address [multiple factors that affect browser security](http://queue.acm.org/detail.cfm?id=1556050). One of the pillars of our approach is to keep the software up to date, so we push out updates to Google Chrome fairly regularly. On the stable channel these are mainly security bug fixes, but the updates are more adventurous and numerous on developer channel.

It is an anathema to us to push out a whole new 10MB update to give you a ten line security fix. We want smaller updates because it narrows the window of vulnerability. If the update is a tenth of the size, we can push ten times as many per unit of bandwidth. We have enough users that this means more users will be protected earlier. A secondary benefit is that a smaller update will work better for users who don't have great connectivity.

Rather then push put a whole new 10MB update, we send out a diff that takes the previous version of Google Chrome and generates the new version. We tried several binary diff algorithms and have been using [bsdiff](http://www.daemonology.net/bsdiff/) up until now. We are big fans of bsdiff - it is small and worked better than anything else we tried.

But bsdiff was still producing diffs that were bigger than we felt were necessary. So we wrote a new diff algorithm that knows more about the kind of data we are pushing - large files containing compiled executables. Here are the sizes for the recent 190.1->190.4 update on the developer channel:

* **Full update**: 10,385,920 bytes
* **bsdiff update**: 704,512 bytes
* **Courgette update**: 78,848 bytes

The small size in combination with Google Chrome's silent update means we can update as often as necessary to keep users safe.

More information on how Courgette works can be found [here](http://dev.chromium.org/developers/design-documents/software-updates-courgette).

Posted by Stephen Adams, Software Engineer