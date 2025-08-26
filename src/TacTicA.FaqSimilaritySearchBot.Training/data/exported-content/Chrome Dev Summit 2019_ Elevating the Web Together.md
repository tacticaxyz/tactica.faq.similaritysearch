URL:https://blog.chromium.org/2019/11/chrome-dev-summit-2019-elevating-web.html
# Chrome Dev Summit 2019: Elevating the Web Together
- **Published**: 2019-11-11T11:09:00.000-08:00
As the largest open ecosystem in history, the Web is a tremendous utility, with more than 1.5B active websites on the Internet today, serving nearly 4.5B web users across the world. This kind of diversity (geography, device, content, and more) can only be facilitated by the open web platform.

  

Users uniquely experience the Web as one as they navigate from site to site, and thus the responsibility is with all of us to work on delivering quality experiences that reach all.

  

At this year’s [Chrome Developer Summit](https://developer.chrome.com/devsummit/) (CDS), we are focusing on giving developers the capabilities to reach the bar that our users demand. To help further foster the diversity and capability for web developers, we’ve been working closely with the ecosystem to make enhancements to the web platform, improve developer experience, and make meaningful updates to the browser itself.

  

Enhancing the versatility of the Web

  

Our vision is to make loading disappear for all our users. At I/O this year, we previewed [Portals](https://web.dev/hands-on-portals/), which allows developers to create seamless experiences by pre-rendering content and optionally embedding it in the page to change the way users navigate across the web. We’re pleased to see the new style navigation from early partners like [Fandango](https://www.fandango.com/) have been testing on their site already. Portals is available behind the chrome://flags/#enable-portals flag for developers to experiment with.

[![Fandango Portals demo](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhcpDjkPdGCd8h8fb56oKCzo15JUfGBb7quVhh2pBlljjWBavG8If2FrZzAh9bFDunRR1Vnz-CSBkgCqeOzzpi_oHXNwPRj22fEJI60cTSpb9ZKG1fFIWEmpLhM0cVdMvgWV4rPDraQypG2/s400/Dr+Sleep+Portal-2019-11-10+18_52_59+%25281%2529.gif "Fandango Portals demo")](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhcpDjkPdGCd8h8fb56oKCzo15JUfGBb7quVhh2pBlljjWBavG8If2FrZzAh9bFDunRR1Vnz-CSBkgCqeOzzpi_oHXNwPRj22fEJI60cTSpb9ZKG1fFIWEmpLhM0cVdMvgWV4rPDraQypG2/s1600/Dr+Sleep+Portal-2019-11-10+18_52_59+%25281%2529.gif)

At CDS this year, we’re previewing [Web Bundles](https://web.dev/web-bundles/), an infrastructural API that will allow developers to distribute their web content across any format - email, FTP, or even USB, without any compromises. Not only does this unlock delivery of web content at lightning fast speeds, it will also allow for peer-to-peer distribution even when users are offline. In the future, APIs like [Background Periodic Sync](https://developers.google.com/web/updates/2019/08/periodic-background-sync) and Content Indexing will allow developers to proactively cache and surface relevant web content for people even if they’re not on an active internet connection. Web Bundles is now available behind the experimental flag, and the other two are now available as origin trials.

  

Consumption of web content has never been more diverse; while the rise of mobile-first in developing markets has been well documented, we’re now seeing an increase in cross-device computing with the youth across the globe. We’re committed to making the platform powerful enough for developers to create amazing modern experiences that users expect while taking advantage of the frictionless of the web. By focusing our efforts on enabling fully capable web applications, we’ve been working to bring many primitives to the platform, including:

* [SMS Receiver](https://web.dev/sms-receiver-api-announcement/), allowing web apps to retrieve two-factor SMS messages.
* [Contact Picker](https://web.dev/contact-picker/), which will allow people to share web content to their contact lists, bringing social media and communication capabilities to web apps.
* [Native File System API](https://web.dev/native-file-system/), enables web apps to read or save changes directly to files and folders on the user's device. This allows developers to build powerful web apps that interact with files on the user's local device, like IDEs, photo and video editors, text editors, and more.

  

There’s a lot more that we’re working on in this space and we can’t wait to see what you build with these capabilities. You can read all about our latest work in our blog on [supporting new web experiences](https://blog.chromium.org/2019/11/making-new-experiences-possible-on-web.html).

  

  

Enabling developer success no matter the framework or CMS

  

As web developers, we’re on a collective journey providing people their best, unique web experience. This collective responsibility makes accurate, actionable data on the health of the web increasingly important.

  

CDS gives us a checkpoint to see how we are doing and have a discussion on where we go next. We use the [HTTP Archive](https://httparchive.org/) to see how the web is built and the [Chrome User Experience Report](https://developers.google.com/web/tools/chrome-user-experience-report) to see how it is experienced. Over the past year, we’re seeing a positive growth in the percentage of sites with fast [First Contentful Paint](https://web.dev/fcp/) and fast [First Input Delay](https://web.dev/fid/), our core metrics for loading and interactivity.

  

Measuring user experience quality is multi-faceted, today we introduced two new metrics to give developers a holistic view of how their sites are performing. [Largest Contentful Paint](https://web.dev/largest-contentful-paint/) (how quickly users see the most meaningful page content) and [Cumulative Layout Shift](https://web.dev/layout-instability-api/) (how stable a page feels).

  

Now, data is great, but insights that lead to fixes and improvements are better. We often get asked “What do I do with this information?” We’ve collaborated with many experts from the community on [The Web Almanac](http://almanac.httparchive.org/), to give developers a holistic view of the health of the web. We launched over 17 chapters today and we’re excited to continue to identify and share more such insights.

![](https://lh5.googleusercontent.com/gASPoc4MTq2vMscnWsDyVxwiMZ6lrOHBIKkpS7mWybXRPvzTXmMVNKZ-f01jKrfM9FGRVMrxRNv-z-xbDHgL1X1XfAitvPPWPMWlvgHmN5GuXXDa2Whl79WyJEMWQ_FCzJvzIzxV)

  

Developers work incredibly hard to move their performance metrics in the right direction, so we are looking at ways to reward developers for going the extra mile. Today we are sharing some early explorations which [surface speed signals](https://blog.chromium.org/2019/11/moving-towards-faster-web.html) in Chrome’s UI.

![](https://lh6.googleusercontent.com/qXJ8qKuLOmuqMhCEJ5njMMQYhnnGk6LvK_rgIZhKK35GKq_ajI8mwQk5tQUJtPrud0OwNbbBuLcH6ews3XQjGnyYsQpzj_03jwyBHMWWoOJ_pz9yip5-U0NvE4A3CuFKlYzIT1d1)

Frameworks, libraries and CMS’es form a critical part of the developer ecosystem and we’re keen to support them on their journey of creating instant and seamless for their users. Earlier this year we created [Lighthouse Stack Packs](https://developers.google.com/web/updates/2019/01/lighthouse-platform-packs) for WordPress and React to support their developer ecosystems in build fast and reliable sites, and today we’ve increased the coverage include Angular, AMP as well as the ecommerce CMS, Magento, bring more actionable insights to developers irrespective of the tools developers use.

  

We’ve been excited to see that the Framework Fund has supported a [number of meaningful projects](https://opencollective.com/chrome) that make it easier to hit the performance bars by default, and we’re looking forward to seeing more projects being funded this year.

  

Finally, we have launched **Lighthouse CI** to make sure that developers are given insights for each pull request. Developers can quickly hook up Lighthouse CI to their build pipeline to get a rich diff of the changes that they made and the impact it had on the quality of their site.

  

![](https://lh6.googleusercontent.com/5W6WFaviO59NyaFDnR6Dd134LtMejK-1D9bdEhOQuWvuVW9bjk3uLFnq66JNs5qGalMtoamhPrFV2HDdQY9nXi5W0K2A2im1qUo9xPegxQdymVrKWB_lsbjYzd8_EG_13p8qGB9u)

  

Making the browser work for you

  

We believe the web is for everyone, no matter their device type, internet speed or purchasing power.  To help ensure the platform remains accessible to all, we’re investing in performance and memory improvements to the browser, including bringing new features like Image Lazy Loading that is now going to be available to [Chrome Lite users by default](https://blog.chromium.org/2019/10/automatically-lazy-loading-offscreen.html), and [Paint Holding](https://developers.google.com/web/updates/2019/05/paint-holding), shipping soon in Chrome.

  

The web needs to be a safe and trustworthy place for everyone. Furthering our initiatives around HTTPS encryption, we began working with the community to start [blocking all mixed content](https://blog.chromium.org/2019/10/no-more-mixed-messages-about-https.html) - insecure HTTP subresources on HTTPS pages - by default, and also experimenting with [DNS over HTTPS](https://blog.chromium.org/2019/10/addressing-some-misconceptions-about.html), which offers better security and privacy by encrypting the traffic between the browser and DNS provider

  

We are also following up on our I/O promise to make our existing third-party cookie controls more visible. Starting with the Chrome M79 Beta, we’re experimenting with a toggle for controlling third-party cookies on the Incognito New Tab Page. We are also working on redesigning our settings pages to make access to this control easier in regular mode. And finally, apart from continuing to make progress to improve the existing cookies infrastructure, we’re also continuing to develop our [Privacy Sandbox](https://blog.chromium.org/2019/08/potential-uses-for-privacy-sandbox.html), a secure environment for content that also protects user privacy.

  

We want to thank the entire web community for their continued investment in a platform that is so impactful to so many people around the world. We believe it is our collective responsibility to elevate the web experience for every user and in that spirit, **let's celebrate the 'We' in Web.**

  
  

Posted by Dion Almaer, Web Developer Ecosystem