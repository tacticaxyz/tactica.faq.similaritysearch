URL:https://blog.chromium.org/2010/01/security-in-depth-new-security-features.html
# Security in Depth: New Security Features
- **Published**: 2010-01-26T14:03:00.000-08:00
We've been hard at work adding proactive security features to Google Chrome, and we're particularly excited about five new security features that make it easier for developers to build secure web sites.

**Strict-Transport-Security**

Strict-Transport-Security lets a high-security web site tell the browser that it wants to be contacted over a secure connection only. That means the browser will always use HTTPS to connect to the site and will treat all HTTPS errors as hard stops (instead of prompting the user to "click through" certificate errors). This feature strengthens the browser's defenses against attackers who control the network, such as malicious folks disrupting the wireless network at a coffee shop.

Originally [proposed in a research paper](http://www.adambarth.com/papers/2008/jackson-barth.pdf) in 2008, Strict-Transport-Security is now an [open specification](http://lists.w3.org/Archives/Public/www-archive/2009Dec/att-0048/draft-hodges-strict-transport-sec-06.plain.html). In addition to being in Google Chrome 4, Strict-Transport-Security has also been implemented in [NoScript](http://hackademix.net/2009/09/23/strict-transport-security-in-noscript/), a security add-on for Firefox, and a [native implementation is underway in Firefox](https://bugzilla.mozilla.org/show_bug.cgi?id=495115). A number of high-security web sites have already started to use the feature, including [PayPal](http://www.thesecuritypractice.com/the_security_practice/2009/11/announcing-stricttransportsecurity-support-on-wwwpaypalcom.html). As with all of our security improvements, we hope that every browser will adopt Strict-Transport-Security, making the web, as a whole, more secure.

**Cross-Origin Communication with postMessage**

The [postMessage API](http://www.whatwg.org/specs/web-apps/current-work/multipage/comms.html#posting-messages) is a new HTML5 feature that lets web developers establish a communication channel between frames in different origins. Previously, when you wanted to add a gadget to your web page, you had two options: (1) include the gadget via a script tag, or (2) embed the gadget using an iframe tag. If you used a script tag, you could have a rich interaction with the gadget (e.g., the [Google Maps API](http://code.google.com/apis/maps/)), but you had to trust the gadget author not to inject malicious script into your web page. Alternatively, if you used an iframe tag to embed the gadget (e.g., the [Google Calendar web element](http://www.google.com/webelements/calendar/)), you had strong security properties, but it was difficult to interact with the gadget.

postMessage changes the game. By using postMessage to communicate with the gadget, you get the security advantages of an iframe with all the interactivity of a script tag. What's more, you can use postMessage to [create more secure versions of existing gadgets](http://www.adambarth.com/papers/2009/barth-jackson-li.pdf). postMessage is now available in the latest versions of all the major browsers: Google Chrome, Internet Explorer, Firefox, Safari, and Opera. A number of web sites, including Facebook, are already using postMessage to make their site safer.

**CSRF Protection via Origin Header**

The Origin header is a new HTML5 feature that helps you defend your site against [cross-site request forgery](http://en.wikipedia.org/wiki/Cross-site_request_forgery) (CSRF) attacks. In a CSRF attack, a malicious web site, say attacker.com, instructs the user's browser to send an HTTP request to a target server, say example.com, that confuses the example.com server into performing some action. For example, if example.com is a webmail provider, the CSRF attack might trick example.com into forwarding an email message to the attacker.

The Origin header helps sites defend against CSRF attacks by identifying which web site generated the request. In the above example, example.com can see that the request came from the malicious web site because the Origin header contains the value http://attacker.com. To use the Origin header as a CSRF defense, a site should modify state only in response to requests that either (1) lack an Origin header or (2) have an Origin header with a white-listed value.

The details of the Origin header are still being finalized. We will update the implementation in Google Chrome as the specification evolves based on feedback from Mozilla and from the W3C and IETF communities at large. We welcome your feedback on the [last draft of the specification](http://tools.ietf.org/html/draft-abarth-origin).

**ClickJacking Protection with X-Frame-Options**

First introduced in [Internet Explorer 8](http://blogs.msdn.com/ie/archive/2009/01/27/ie8-security-part-vii-clickjacking-defenses.aspx), X-Frame-Options is a security feature that lets web sites defend themselves against [clickjacking](http://en.wikipedia.org/wiki/Clickjacking) attacks. To defend against clickjacking, a web developer can request that a web page not be loaded inside a frame by including the X-Frame-Options: deny HTTP header. X-Frame-Options is implemented in Google Chrome, Internet Explorer 8, and Safari 4.

**Reflective XSS Protection**

One of the most difficult parts of building a secure web site is protecting against [cross-site scripting](http://en.wikipedia.org/wiki/Cross-site_scripting) (XSS) vulnerabilities. In Google Chrome 4, we've added an experimental feature to help mitigate one form of XSS, reflective XSS. The XSS filter checks whether a script that's about to run on a web page is also present in the request that fetched that web page. If the script is present in the request, that's a strong indication that the web server might have been tricked into reflecting the script.

The XSS filter is similar to those found in [Internet Explorer 8](http://blogs.msdn.com/ie/archive/2008/07/02/ie8-security-part-iv-the-xss-filter.aspx) and [NoScript](http://noscript.net/features#xss). Instead of being layered on top of the browser like those filters, our XSS filter is integrated into [WebKit](http://webkit.org/), which Google Chrome uses to render webpages. Integrating the XSS filter into the rendering engine has two benefits: (1) the filter can catch scripts right before they are executed, making it easier to detect some [tricky attack variations](http://ha.ckers.org/xss.html), and (2) the filter can be used by every WebKit-based browser, including Safari and Epiphany.

We are aware of a few ways to [bypass the filter](https://bugs.webkit.org/buglist.cgi?keywords=XSSAuditor&resolution=---), but, on balance, we think that the filter is providing enough benefit to enable it by default in this release. If you discover a new way to bypass the filter, please [let us know](https://bugs.webkit.org/enter_bug.cgi?product=Security). We're very interested in improving the filter in subsequent releases. We're grateful to the security researchers who have helped us with the filter thus far (especially Eduardo "Sirdarckcat" Vela), and we welcome even more participation.

Posted by Adam Barth, Software Engineer