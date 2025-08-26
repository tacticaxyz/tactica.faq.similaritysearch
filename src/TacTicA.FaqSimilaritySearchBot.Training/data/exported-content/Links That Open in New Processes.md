URL:https://blog.chromium.org/2009/12/links-that-open-in-new-processes.html
# Links That Open in New Processes
- **Published**: 2009-12-04T13:53:00.000-08:00
We've introduced a new way for web developers to take advantage of Google Chrome's [multi-process architecture](http://blog.chromium.org/2008/09/multi-process-architecture.html), as of version 4.0.229.1. Google Chrome already uses separate OS processes to isolate independent tabs from each other in the browser, so that crashes or slowdowns in one tab won't affect the others. Google Chrome even switches a given tab's process if you type a different site's URL into the Omnibox.

In many cases, though, Google Chrome needs to keep pages from related tabs in the same process, since they may access each other's contents using JavaScript code. For example, clicking links that open in a new window will generally cause the new and old pages to share a process.

In practice, web developers may find situations where they would like links to other pages to open in a separate process. As one example, links from messages in your webmail client would be nice to isolate from the webmail client itself. This is easy to achieve now, thanks to [new support in WebKit for HTML5's "noreferrer" link relation](http://webkit.org/blog/907/webkit-nightlies-support-html5-noreferrer-link-relation/).

To cause a link to open in a separate process from your web page, just add rel="noreferrer" and target="\_blank" as attributes to the <a> tag, and then point it at a URL on a different domain name. For example:

<a href="http://www.google.com" rel="noreferrer" target="\_blank">Google</a>

In this case, Google Chrome knows that the page will be opened in a new window, that no referrer information will be passed to the new page, and that the window.opener value will be null in the new page. As a result, the two pages cannot script each other, so Chrome can load them in separate processes. Google Chrome will still keep same-site pages in the same process, to allow them to share caches and minimize overhead.

We hope you find this useful on your own sites!

Posted by Charlie Reis, Software Engineer