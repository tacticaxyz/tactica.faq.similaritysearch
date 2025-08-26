URL:https://blog.chromium.org/2020/08/helping-people-spot-spoofs-url.html
# Helping people spot the spoofs: a URL experiment
- **Published**: 2020-08-12T10:29:00.001-07:00
On today’s web, URLs remain the primary way users determine the identity and authenticity of a site, yet we know URLs suffer from usability [challenges](https://research.google/pubs/pub48199/). For example: there are myriad ways that attackers can manipulate URLs to confuse users about a website’s identity, which leads to rampant phishing, social engineering, and scams. In one [study](https://research.google/pubs/pub49166/), more than 60% of users were fooled when a misleading brand name appeared in a URL’s path.

  

Different browsers approach this challenge in a number of ways, including showing only the domain by default, or visually highlighting the registrable domain (the “most significant” part of the domain name). In Chrome 86, we’re likewise going to experiment with how URLs are shown in the address bar on desktop platforms (animation below). Our goal is to understand -- through real-world usage -- whether showing URLs this way helps users realize they’re visiting a malicious website, and protects them from phishing and social engineering attacks.

![](https://lh4.googleusercontent.com/19onWpGRt7-kVhtL1k2vPaRCNh0fYDrGxT8bq8sT0rIiAMlAZyW_Ckzjsfv1TD92Yxr5iocJPPh5U3XJI5T9RJsVu44lhW3qwgff8hm13pZ7TgYCnTBlgUwgTQHqH9fGYSCakXoPMg)

An experiment in Chrome 86 shows the domain name by default and full URL on hover

  

Prefer to see the full URL?

If you find yourself in the experimental group, and you’d like to view the full URL for a given site, you’ll have two options. First you can hover over the URL, and it will expand fully. Second, you can right-click on the URL, and choose “Always show full URLs” in the context menu (screenshot below); enabling this setting will show the full URL for all future sites you visit. (Notably: Enterprise-enrolled devices won’t be included in this Chrome 86 experiment.)

  

![](https://lh6.googleusercontent.com/QDXiDdJ-BiNqDlHafhxg3XAUEsQOeHXOe6rm15aEkjp2kC1FIzvZp_yvTGG6tM0yCmYtDy74OYRTrDvfE3TnBtaM-GNwEpUB_FuTLEJLbOyQZjyAra3CbHBbBcB-6PY7DtNq0HQ0vg)  
A setting in the context menu allows you to always show full URLs in the address bar

  

We welcome your feedback!

If you’re not randomly assigned to this Chrome 86 experiment, and you’d like to try it out, please install Chrome Canary or Dev channel, open chrome://flags in Chrome 86, enable the following flags, and re-launch Chrome:

* #omnibox-ui-reveal-steady-state-url-path-query-and-ref-on-hover
* #omnibox-ui-sometimes-elide-to-registrable-domain
* Optionally, #omnibox-ui-hide-steady-state-url-path-query-and-ref-on-interaction to show the full URL on page load until you interact with the page.

Thanks in advance for your thoughts! You can file bugs or feature requests on our [bug tracker](https://bugs.chromium.org/p/chromium/issues/entry?template=Simplified+Domain+Bug).

Posted by Emily Stark, Eric Mill, Shweta Panditrao, Chrome Security Team