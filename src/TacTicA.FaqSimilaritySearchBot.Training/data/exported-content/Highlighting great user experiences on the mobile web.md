URL:https://blog.chromium.org/2020/08/highlighting-great-user-experiences-on.html
# Highlighting great user experiences on the mobile web
- **Published**: 2020-08-17T09:00:00.003-07:00
Over the last [decade](https://blog.chromium.org/2018/09/10-years-of-speed-in-chrome_11.html), Chrome and the web development community have worked towards providing users with a fast, responsive and delightful browsing experience. Features like <link rel=preload> and native lazy-loading, to name but a few, are helping pages meet this mark. Historically, Chrome has also successfully encouraged the adoption of best-practices such as HTTPS by distinguishing [secure from insecure browsing](http://blog.google/products/chrome/milestone-chrome-security-marking-http-not-secure/) in Chrome's UI.

  

To help users identify great experiences as they browse, we are excited to announce that Chrome will begin to highlight high quality user experiences on the web, starting with the labelling of fast links via the link context menu on Chrome for Android. This change will be rolling out starting in Chrome 85 Beta.

  

Labelling is based on signals from the [Core Web Vitals](https://blog.chromium.org/2020/05/introducing-web-vitals-essential-metrics.html) metrics that quantify key aspects of users’ experience, as experienced by real-world Chrome users. The Core Web Vitals metrics measure dimensions of web usability such as loading time, responsiveness, and the stability of content as it loads, and define thresholds for these metrics to set a bar for providing a good user experience. 

  

The changes that site owners make to improve on these aspects work towards making the web more delightful for users across all web browsers. Investing in these critical user-centric metrics helps to drive usability improvements for users and helps businesses see increased engagement.

  

Links to pages that have historically met or exceeded all metrics thresholds for the Core Web Vitals will be displayed with a new “Fast page” label. This is shown when a user long-presses a link prior to navigating to a page, and it indicates that most users navigating to it have a particularly good experience.

  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjYU_1fKA2Zg_co29VTabqrO79lMUr05bEB9_1MCpTxivkPysmg9O69Re41-AgPPvrY1_dNtShucD-zgD8AZ7jvKJhNQ7JtkUJHSvG-wotRP2AIJTDnCBPOc3XiGrYspEbRl1qWRDA88ztA/s640/performance-hints-fast-labelling%25402x.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjYU_1fKA2Zg_co29VTabqrO79lMUr05bEB9_1MCpTxivkPysmg9O69Re41-AgPPvrY1_dNtShucD-zgD8AZ7jvKJhNQ7JtkUJHSvG-wotRP2AIJTDnCBPOc3XiGrYspEbRl1qWRDA88ztA/s2048/performance-hints-fast-labelling%25402x.png)

"Fast page" labelling may badge a link as fast if the URL (or URLs like it) have been historically fast for other users. When labelling, historical data from a site’s URLs with similar structure are aggregated together. Historical data is evaluated on a host-by-host basis when the URL data is insufficient to assess speed or is unavailable, for example, when the URL is new or less popular.

  

Our plan is to maintain alignment with Core Web Vitals as they evolve, so that we are always labeling pages that have optimized against the metrics that are most representative of a user's overall experience. As previously [noted](https://web.dev/vitals/#evolving-web-vitals), developers should expect the definitions and thresholds of the Core Web Vitals to be stable, and updates to have prior notice and a predictable, annual cadence.

  

We anticipate that optimizing for the Core Web Vitals may require some investments in improving page quality. To help out, we updated our [developer tools](http://web.dev/vitals-tools) to surface information and recommendations: [Lighthouse](https://developers.google.com/web/tools/lighthouse), [DevTools](https://developers.google.com/web/tools/chrome-devtools), [PageSpeed Insights](https://developers.google.com/speed/pagespeed/insights/), and [Search Console](https://support.google.com/webmasters/answer/9205520) team added a report dedicated to Core Web Vitals too.

  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgXhf2XFjSirOO5Nju2eJNXjrT1VT2dY28-r7lJFcGHexyZHnELum8dFJss_iCWDq7Rsmu8TZ6IN-1aFKM1BQ4ToLtO5F_zhMfV_oHyM4EIfl3LwuvW4wQ_UMYUzFdzK7KkBuAsJ1V-paWU/s640/performance-hints-fast%25402x.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgXhf2XFjSirOO5Nju2eJNXjrT1VT2dY28-r7lJFcGHexyZHnELum8dFJss_iCWDq7Rsmu8TZ6IN-1aFKM1BQ4ToLtO5F_zhMfV_oHyM4EIfl3LwuvW4wQ_UMYUzFdzK7KkBuAsJ1V-paWU/s2048/performance-hints-fast%25402x.png)

  

Labelling is currently being rolled out to Chrome 85 beta, but if you would like to try labelling today, go to chrome://flags and enable “Context menu performance info and remote hint fetching”. **Please note, this flag will only be available on Chrome for Android.** Once fully rolled out, users will see labelling if they have Lite mode or “[Make Searches and Browsing Better](https://support.google.com/chrome/answer/9116376?co=GENIE.Platform%3DAndroid&hl=en)” turned on. Next, navigate to any qualifying page, such as the Wikipedia page for [the Internet](https://en.m.wikipedia.org/wiki/Internet), and long-press on any link. 

  

We believe the web serves a critical role in our lives, and hope that fast labelling proves helpful to users who are on slow or spotty network connections. Over time, we may also experiment with labelling in other parts of Chrome’s UI. Ultimately, our goal is to provide users of the web with a healthy level of transparency into the experience they may have with a page. 

  

Chrome is committed to working with the ecosystem to ensure a thriving web, and the steps we take, such as the ones outlined above, are designed with these goals in mind.

  

By Addy Osmani, Ben Greenstein and Josh Simmons, fast page fans.