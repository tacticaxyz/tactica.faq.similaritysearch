URL:https://blog.chromium.org/2020/10/progress-on-privacy-sandbox-and.html
# Progress on Privacy Sandbox and building a more private web
- **Published**: 2020-10-06T12:00:00.002-07:00
  
Last year we [announced](https://www.blog.google/products/chrome/building-a-more-private-web/) a new initiative (known as Privacy Sandbox) to develop a set of open standards to fundamentally enhance privacy on the web. With Privacy Sandbox we’ve been exploring privacy-preserving mechanisms with the web community that protect user data and prevent intrusive cross-site tracking. Our aim is to preserve the vitality of the open web by continuing to enable the rich, quality content and services that people expect, but with even stronger guarantees of privacy and safety. Today we’re sharing progress on this long-term initiative and asking for your continued help in increasing the privacy of web browsing.  
  
In January we shared our intent to develop privacy-preserving open-standards that will render third-party cookies obsolete. Since then, [Google](https://www.chromium.org/Home/chromium-privacy/privacy-sandbox) and [others](https://github.com/w3c/web-advertising) have proposed several new APIs to address use cases like fraud protection, ad selection, and conversion measurement without allowing users’ activity to be tracked across websites. Following web community input, some of these solutions are now available for experimental testing via [Chrome origin trials](https://web.dev/origin-trials/):  

* [Click Conversion Measurement API](https://web.dev/conversion-measurement/) opened up for testing in September and aims to enable marketers to know whether an ad click resulted in a conversion (for example, a purchase or a sign-up) on another site, without connecting the identity of the user across both sites.

* [Trust Tokens](https://web.dev/trust-tokens/) opened up for testing in July and is intended to support a number of use cases evaluating a user’s authenticity, including combating fraud.

  
If you integrate APIs into your products and services, you can [register](https://developers.chrome.com/origintrials/#/trials/active) for access to these and other APIs through Chrome origin trials. We encourage ecosystem stakeholders to participate and share their feedback and results. Developing and implementing web standards which change the core architecture of the web is a complex process, so we are taking a long-term, collaborative approach.   
  
  
We’re also continuing our work to make current web technologies more secure and private.   

* [Earlier this year](https://blog.chromium.org/2020/02/samesite-cookie-changes-in-february.html) Chrome started limiting cross-site tracking by treating cookies that don’t include a SameSite label as first-party only, and requiring cookies to be labeled and accessed over HTTPS in order to be available in third-party contexts. With this update — which [Edge](https://docs.microsoft.com/en-us/microsoft-edge/web-platform/site-impacting-changes) and [Firefox](https://hacks.mozilla.org/2020/08/changes-to-samesite-cookie-behavior/) are in the process of adopting — third-party cookies are no longer sent for the 99.9% of registered domains that do not require them, improving privacy and security for the vast majority of sites on the web.

* In [a release](https://chromestatus.com/feature/5096179480133632) early next year, Chrome will also strengthen protection against additional types of network attacks that could hijack the users’ privileged credentials to perform malicious actions on their accounts.

  
We’re also rolling out changes in Chrome to mitigate deceptive and intrusive tracking techniques, such as fingerprinting.  

* In September we [rolled](https://web.dev/referrer-best-practices/) out an update to prevent inadvertent sharing of information such as users' names and access tokens. When users navigate from one site to another we are reducing the information from the originating page’s URL that is sent to the destination site by default.

* Also in September, we extended support of [Secure DNS in Chrome](https://blog.chromium.org/2020/09/a-safer-and-more-private-browsing.html) beyond desktop to Android. [Secure DNS](https://blog.chromium.org/2020/05/a-safer-and-more-private-browsing-DoH.html) is designed to improve user safety and privacy while browsing the web by automatically switching to DNS-over-HTTPS if the user's current provider supports it.

* Coming soon, we’re also closing the ability for a site to observe other sites that a user might have visited through [caching](https://developers.google.com/web/updates/2020/10/http-cache-partitioning) mechanisms.

  
As always, we encourage you to give [feedback](https://github.com/w3c/web-advertising/blob/master/README.md) on the [web standards community](https://www.chromium.org/Home/chromium-privacy/privacy-sandbox) proposals via GitHub and make sure they address your needs. And if they don’t, file issues through GitHub or [email](https://lists.w3.org/Archives/Public/public-web-adv/) the W3C group. If you rely on the web for your business, please ensure your technology vendors engage in this process and that the trade groups who represent your interests are actively engaged.  
  
We are appreciative of the continued engagement as we build a more trustworthy and sustainable web together. We will continue to keep everyone posted on the progress of efforts to increase the privacy of web browsing. 

Posted by Justin Schuh - Director, Chrome Engineering