URL:https://blog.chromium.org/2020/12/chrome-dev-summit-2020-wrap-up.html
# Chrome Dev Summit 2020: Building an open web for our users and developers
- **Published**: 2020-12-09T09:30:00.000-08:00
We all benefit from an open web that is secure, powerful, and fast. Over
the past year, we’ve focused our efforts on strengthening the web in three
areas:

1. Rethinking how we can deliver a safe and secure web
2. Adding the capabilities you need to build powerful, rich, and diverse applications
3. Optimizing for performance, for users and developers alike

This post is a synopsis of the updates we shared during today’s keynote at
Chrome Dev Summit.

Rethinking privacy from the ground up
-------------------------------------

We’ve continued work on the
[Privacy Sandbox](https://www.blog.google/products/chrome/building-a-more-private-web/)
and we are committed to developing an open set of standards that
fundamentally enhance privacy on the web. Together with the web community,
we're building new privacy-preserving alternatives to third-party cookies
or other cross-site tracking mechanisms. With the
[Client Hints API](https://web.dev/user-agent-client-hints/),
we’re reducing the fingerprinting surface of Chrome, and we have two
solutions for you to experiment with via our
[Chrome origin trials](https://blog.chromium.org/2020/10/progress-on-privacy-sandbox-and.html).
The [Click Conversion Measurement API](https://web.dev/conversion-measurement/)
measures ad conversions without using cross-site identifiers, and the
[Trust Token APIs](https://web.dev/trust-tokens/) help convey
trust from one context to another without passive tracking.

![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgo_xNza3D4aLYXhnrwQCsvEFmioInavORPj1HyipYt1NzWWqhBqhIuClX0-b38yQEoNR-nwsaJmT5MKaR84HGv_x_2pPOggqiecOvGp7JMNEtZEoSX2trnOUj4bdSQiFE8jHmiNa4ow7T3/s16000/img1-cropped.jpg)


Available as Origin Trials  
More info at [web.dev/trust-tokens/](https://web.dev/trust-tokens/)

Similarly, the security and privacy of extensions has become of utmost
importance with hundreds of millions of people using over 250,000 items in
the Chrome Web Store. We believe extensions must be trustworthy by default
and it’s why we announced a
[draft proposal for a number of changes to our extension platform](https://blog.chromium.org/2018/10/trustworthy-chrome-extensions-by-default.html).
After incorporating a number of different suggestions from extension
developers, we're ready to launch the stable release of
[Manifest V3](https://blog.chromium.org/2020/12/manifest-v3-now-available-on-m88-beta.html) with the goal of increased security, more control and
privacy for users, and improved performance.

With Manifest V3, remote hosted code is no longer permissible to prevent
malicious extensions that abuse user privacy and security. Additionally,
the new extensions model allows users to withhold sensitive permissions at
install time. Lastly, a new approach to background logic with the
introduction of service workers for background pages and a new declarative
model for extension APIs provides users more consistent performance
guarantees. Manifest V3 is now available to experiment with on Chrome
88 beta, with the Chrome Web Store accepting Manifest V3 extensions
mid-January when Chrome 88 reaches stable.

Bringing powerful capabilities for advanced apps
------------------------------------------------

Great examples are coming to life from developers who are building new
experiences on the web. [Gravit Designer](https://www.designer.io/en/)
makes it easy for users to read and write files with [File System Access APIs](https://web.dev/file-system-access/) and allows the use of specialized fonts
installed locally with the new [Local
Font Access API](https://web.dev/local-fonts/). Adobe has made it easy for users to create stunning
visual stories and beautifully designed content with their
[Spark web app](https://spark.adobe.com/).

![](https://lh4.googleusercontent.com/v_MguUaSG69tyfkZznl92awUPrtyLo9_n5i09iCwhgN50FpyVwe9texU0fznPOKikhZ9HRnejiCUs7e4DZLN1zlI_jLLLmRWvcUa7bvK9cmFMzcEu2urOEhRxNV5W_3GRhas_6z3QlabaUnWNv-Jwt9vON0QYRoy4OMB2Klo6_IzihmW)

Today, we are adding new capabilities for Progress Web Apps (PWAs) to
increase their [discoverability by being listed in the Google Play Store](https://blog.chromium.org/2020/12/pwa-play-billing-support.html). In Chrome 86
we gave you the ability to list your PWA in the Play Store using a
[Trusted Web Activity](https://developers.google.com/web/android/trusted-web-activity).
We’ve now made it possible for you to start accepting payments using the
new [Digital Goods API](https://www.chromestatus.com/feature/5339955595313152) in Chrome 88.

[![](https://storage.googleapis.com/web-dev-assets/chromium-blog/cros-nugget3.jpg)](https://storage.googleapis.com/web-dev-assets/chromium-blog/cros-nugget3.jpg)

Optimizing for performance
--------------------------

Chrome’s performance—speed and usage of resources like power, memory, or
CPU—has always been top of mind so you can deliver the best experience
for all our users.

Earlier this year, we made some key improvements to speed with
[Profile Guided Optimization & Tab throttling](https://blog.chromium.org/2020/08/chrome-just-got-faster-with-profile.html) and today, we announced
a significant reduction of V8’s memory footprint. Apart from making great
strides in memory savings through
[V8 pointer compression](https://v8.dev/blog/pointer-compression),
we’ve eliminated parsing pauses entirely by loading a webpage’s JavaScript
files in parallel, so scripts can be parsed and compiled and ready to
execute as soon as they’re needed by the page.

Since we announced our [Web Vitals initiative](https://web.dev/vitals/),
they are being increasingly used to measure web page performance. Google
Search [announced](https://developers.google.com/search/blog/2020/11/timing-for-page-experience)
new signals to search ranking will include [Core Web Vitals](https://web.dev/vitals/#core-web-vitals) starting in May 2021. In addition to the
[Chrome User Experience Report](https://developers.google.com/web/tools/chrome-user-experience-report),
Search Console’s [Core Web Vitals report](https://support.google.com/webmasters/answer/9205520),
and [many other Google tools](https://web.dev/vitals-tools/),
other providers like
[Cloudflare](https://blog.cloudflare.com/start-measuring-web-vitals-with-browser-insights/)
are surfacing Core Web Vitals as web page performance metrics.

Last summer, we released the
[web-vitals Javascript library](https://github.com/GoogleChrome/web-vitals)
for those sites using Google Analytics. Today we announced the
[Web Vitals Report](http://goo.gle/web-vitals-report), an open
source website and tool that lets you query and visualize your Web Vitals
metrics data in Google Analytics, enabling you to easily compare
performance data across segments.

![](https://lh3.googleusercontent.com/_XAbFN3Q9M174KK02avLKknUTCnFD8nt-k7jc00ktT-CVws9x7wOeICtebXXbjS9eqzsvmbCBgQ6mkdBy9BTMibBNgO7qqGnjTQT884Icn4F_IUS0fLMdrouriTEU5sNIFXR_SYkDYoge7MZl21lscjwThYjBV1LIDNn-I1njTuZ42NP)

Finally, we’ve been listening to your feedback and hearing about your
difficulties in building web interfaces. We’ve been working to improve
the web’s styling capabilities and shipped
[content-visibility](https://web.dev/content-visibility/), a
CSS feature that significantly improves rendering performance. Look for
more updates and tools to improve UI styling, including the announcement of
[Houdini.how](http://Houdini.how), a set of APIs that makes it
easier for you to extend CSS.

A virtual gathering experiment
------------------------------

Chrome Dev Summit has always been about connecting with the community.
Although we weren’t able to convene together in person, the Chrome team
launched a PWA to bring the best parts of a physical conference --
serendipitous conversations, discovering new things, and collecting swag --
to life with [Chrome Dev Summit Adventure](https://developer.chrome.com/devsummit/adventure/).
We can’t wait to hear what you think of this experiment and look forward
to chatting with you in real-time.

[


](https://storage.googleapis.com/web-dev-assets/chromium-blog/cds-a.webm)

Learn more
----------

Become part of the community and join a
[Google Developer Group](https://developers.google.com/community/gdg)
around the world. Check out the full list of
[CDS Extended events](https://developer.chrome.com/devsummit/schedule/#extended)
that brings together regional developer communities to recap the
highlights from Chrome Dev Summit 2020 along with live interactive
sessions.

[Watch the sessions](http://goo.gle/cds20-sessions) any time on
our YouTube channel and for all the latest updates on the web,
[sign up for the web.dev newsletter](https://web.dev/newsletter/).

See you next year!

Posted by Ben Galbraith & Dion Almaer