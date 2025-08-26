URL:https://blog.chromium.org/2010/02/google-chrome-frame-developer-updates.html
# Google Chrome Frame Developer Updates
- **Published**: 2010-02-09T19:03:00.000-08:00
Since Google Chrome Frame [was released in September](http://blog.chromium.org/2009/09/introducing-google-chrome-frame.html) we've published regular updates to improve stability and integration with Internet Explorer. Today's update continues this work but also contains two key changes that developers should be aware of.

First, until now Google Chrome Frame has used the <meta> tag for invocation.

> <meta equiv="X-UA-Compatible" content="chrome=1">

Unfortunately, doing this had a few potential problems, including some challenges for sites which couldn't place the <meta> tag early enough to trigger Google Chrome Frame reliably.

As of today, Google Chrome Frame additionally allows sites to serve an HTTP header for invocation. Use of the <meta> tag is still supported, but sites can take advantage of the new trigger by specifying an equivalent HTTP header:

> X-UA-Compatible: chrome=1

This has the following benefits:

* Sites that detect Google Chrome Frame can serve content with standard MIME types (including application/xhtml+xml), which Microsoft Internet Explorer does not natively support.
* The HTTP header will always be detected, no matter how many other headers are served.
* The HTTP header passes the W3C validator (which the <meta> tag syntax did not).
* HTTP headers can be centrally configured in your web sever for blanket rollout of Google Chrome Frame support. For example, to enable GCF site-wide for browsers that support it, in Apache (with mod\_headers and mod\_setenvif enabled) specify a header directive like:

> <IfModule mod\_setenvif.c>
>
> <IfModule mod\_headers.c>
>
> BrowserMatch chromeframe gcf
>
> Header append X-UA-Compatible "chrome=1" env=gcf
>
> </IfModule>
>
> </IfModule>

Secondly, today's release also **renames the "cf:" protocol to "gcf:" and disables "gcf:" by default**. You can enable it on your local system for testing by adding a REG\_DWORD value named EnableGCFProtocol with a value of 1 to the following registry key: HKCU\Software\Google\ChromeFrame.

This change will help avoid misuse of this development-mode feature and will reduce the number of spurious compatibility issues reported.

Your copy of Google Chrome Frame should be automatically upgraded with these changes. To learn more, ask questions, or get involved, [visit our site](http://code.google.com/chrome/chromeframe/) or join the [Google Chrome Frame discussion group](https://groups.google.com/group/google-chrome-frame).

Posted by Alex Russell, Software Engineer