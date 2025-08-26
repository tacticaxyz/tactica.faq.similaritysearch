URL:https://blog.chromium.org/2023/11/how-core-web-vitals-saved-users-10000.html
# How Core Web Vitals saved users 10,000 years of waiting for web pages to load
- **Published**: 2023-11-07T09:03:00.001-08:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgmp1qvDcNBZtkhpYpK-Ly3iyOHgmGT9L3c8nQlJFRy6ncMfwdblt0BYX_j3zBBRqSA9wrnKdeth6rOtS325MPGr0CNesGPFa4ZS83FLR0lcxFfKkarvl2OZcOgEb4XloVsDLvr1a3h_5YBQSX4ZdLdx2cuQyUdsbcDp2FYZzjJWGnVdlvEzxxv2asH_yT8/w400-h166/Fast%20Curious_image.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgmp1qvDcNBZtkhpYpK-Ly3iyOHgmGT9L3c8nQlJFRy6ncMfwdblt0BYX_j3zBBRqSA9wrnKdeth6rOtS325MPGr0CNesGPFa4ZS83FLR0lcxFfKkarvl2OZcOgEb4XloVsDLvr1a3h_5YBQSX4ZdLdx2cuQyUdsbcDp2FYZzjJWGnVdlvEzxxv2asH_yT8/s400/Fast%20Curious_image.png)

  
  

Today’s The Fast and the Curious post explores how Core Web Vitals saved Chrome users more than 10,000 Years of waiting for web pages to load in 2023 (across Chrome desktop and Android) by quantifying the experience of sites and identifying opportunities to make improvements.

  
  

In 2020, we introduced [Web Vitals](https://web.dev/vitals/) - essential quality signals for webpages to ensure a better user experience. Since then, there has been a massive leap in web performance made possible by our work on Core Web Vitals (CWV) and its broader impact on the web. Today, over 40% of sites pass all of the CWV metrics, leading to pages that load and respond to interactions more quickly. Here’s a closer look at the journey to help improve the performance for sites and some specific work done in the browser and the ecosystem to enable this achievement. 

  
  

Chrome's Quest for Speed

  

The very essence of the web lies in its ability to provide information and services efficiently and rapidly. This principle is at the heart of Google's business and drives our work on Chrome. However, we noticed an issue with sites over a long time horizon. Even if slow sites improved their performance for a while, it would often decline over time. No matter how fast Google Search might be, the user experience would be subpar if the pages found were slow to load.

  

We could not help these sites improve their performance directly, but we wanted users to have a great experience when they moved from Google Search to the individual sites. To tackle the challenge of improving the user experience while simultaneously providing unified guidance to developers, teams from Search and Chrome collaborated to address the issue of slow web pages.

  
  

Defining the Fast Web 

  

We examined millions of pages to define a public standard for a fast, user-friendly web page (initially published in [The Science Behind Web Vitals](https://blog.chromium.org/2020/05/the-science-behind-web-vitals.html)). We published our specifications and data to the open ecosystem and took note of  the feedback we received. The introduction of CWV metrics such as [LCP](https://web.dev/articles/lcp) (Largest Contentful Paint) was groundbreaking because it allowed us to measure when the user actually sees the content. The ability to measure the actual user experience at scale has been foundational to the improvements that we will discuss in this blog post.

  

Next, we updated Google's search ranking algorithms in August 2021 to consider, among other factors, whether a page met the speed and usability standards established as part of CWV.  Today, it remains [highly recommended](https://developers.google.com/search/docs/appearance/page-experience#core-web-vitals) for site owners to achieve good Core Web Vitals for success with Search and to ensure a great user experience generally.

  
  

Exponential Impact of Small Changes

  

The results we saw after these changes were significant. The average page load in Chrome is now 166 ms faster. That might seem like a minor improvement, but small changes can accumulate to create a substantial impact on the web. 

  

So far in 2023, this project saved users over 10,000 years of waiting for web pages to load and over 1,200 years of waiting for web pages to respond to user input. And the web continues to get faster. We also tracked improvements in how many navigations meet Core Web Vitals (CWV). The current figures stand at 64.45% for mobile (up from 64%) and 68.39% for desktop (up from 67%). The Chrome Data team projects a ~69% pass rate by the end of the year.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhJXlVkkM1NpqQVv72HdG9lqOx0BNVa0zA8ALsBeqZI5ZRB-WQt4MDj3SMPDkwFBQt8J8Y3d6f2TaWpz_9dHjdNUNTTaNIduP5aD-y1_c_c980qRKByLSQDcZ8RVx6v3YwE__etQlQAUwTKaJJKhYQZYpyewk-QBA5apndz0w6jjdPsWhANwHhQxOYXML1r/w640-h360/Screenshot%202023-11-06%20at%209.45.17%E2%80%AFAM.png "Caption: Our savings for LCP translate into 8,000 years saved for users waiting for pages to load on Android and 2,000 years in 2023 so far. On INP, we have saved users 800 years on Android and 450 years on Windows so far in 2023.")](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhJXlVkkM1NpqQVv72HdG9lqOx0BNVa0zA8ALsBeqZI5ZRB-WQt4MDj3SMPDkwFBQt8J8Y3d6f2TaWpz_9dHjdNUNTTaNIduP5aD-y1_c_c980qRKByLSQDcZ8RVx6v3YwE__etQlQAUwTKaJJKhYQZYpyewk-QBA5apndz0w6jjdPsWhANwHhQxOYXML1r/s954/Screenshot%202023-11-06%20at%209.45.17%E2%80%AFAM.png)

*Caption: Our savings for LCP translate into 8,000 years saved for users waiting for pages to load on Android and 2,000 years in 2023 so far. On INP, we have saved users 800 years on Android and 450 years on Windows so far in 2023.*

Next, let’s look at some recent updates from both the Chrome team and the wider developer ecosystem, demonstrating how our joint efforts are speeding up the web.

  
  

Chrome’s Core Web Vitals Achievements

  

We’re proud to highlight numerous ways we’ve optimized performance. 

  

* The [Back/forward cache](https://web.dev/articles/bfcache) (bfcache) is designed to improve browsing experience by enabling instant back and forward navigation. BFCache’s hit rate has improved month-over-month on both Android (3.6%) and Desktop (1.8%).

  

* Another example of a particularly impactful optimization is our PreconnectOnAnchorInteraction feature which connects to origins on pointer-down rather than pointer-up. This fully launched feature led to a 6/10ms (0.4/1%) median LCP improvement on Android/Desktop, and an improvement in cross-origin LCP by ~60ms on both Android and Desktop. The launch also resulted in a 0.08% Content Ad revenue increase, underlining the significant impact of performance optimizations on user engagement and ecosystem health.

  

* We also introduced [prerendering](https://developer.chrome.com/blog/prerender-pages/), which makes pages load instantly by rendering them before the user actually visits. Page loads via typing URLs directly in the omnibox get a 500-700ms (14-25%) median LCP improvement when prerendered, depending on the platform, moving global median LCP across all navigations by 6.4ms. We're currently rolling out prerendering of omnibox-initiated searches.

  

* Chrome has been working hard to keep background tabs out of your way. Implementing [tab throttling for background tabs](https://blog.chromium.org/2020/11/tab-throttling-and-more-performance.html) running at EcoQOS on Windows 11 and Task Role and QoS Adjustments on macOS have led to improvements in Largest Contentful Paint ([LCP](http://web.dev/lcp)) and Interaction to Next Paint ([INP](https://web.dev/articles/inp)).
* The web’s modern ability to run all types of applications also comes with a mandate to manage the workload that this encurs. We have been optimizing Chrome under mutliple active tabs  and are happy to report improvements to scheduling and contention which improve INP by 5% and LCP by 2% in the last 6 months.

  

* We have made targeted improvements to the page loading code in Chrome in 2022. These resulted in LCP improving by 10% on Android, and CWV pass rate improving by 1.5%.

  

* Chrome's renderer has also seen some improvements. The renderer's main thread includes task queues for JavaScript, rendering, and image loading. Some changes that alter the priority of these tasks for optimal CWV include.

+ High priority image loading: Historically, image-loading had the same or lower priority than rendering. However, an experiment showed that between an image load task and a rendering task, choosing the image load task first can prevent layout shift of an intermediate frame that doesn't have the image and also improves LCP. The improvement on Android at the 75th percentile was -6.66% for CLS and -0.82% for LCP, improving the CWV pass rate on Android by +0.24%. A similar experiment that boosted the loading priority to "medium" of the first five images parsed from the HTML (for non-icon-sized images) showed an improvement on Android at the 75th percentile of -6.08% for CLS and -0.53% for LCP. A combined experiment showed the effects of both changes were largely independent.
+ Prioritize compositing after delay: If it has been more than 100ms since the last [compositing](https://developer.chrome.com/blog/inside-browser-part3/#what-is-compositing) task run, elevate the priority of any queued compositing task so that it will preempt normal-priority work. This produced an improvement of -0.27% for CLS on Android and Windows at the 95th percentile.
+ SVG Raster Optimizations: Another SVG drawing optimization improved INP pass rates on desktops by -2.28% for MacOS at the 75th percentile.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiKRmZM0AQmYrx8wvUc0LqtpIwpGOgGPcPGqTeezyXUM0q1WY_TP_AN9UJno42Eutj7xBDlzFUCN0yM_MItJU_hb4fqPl2LCQVR66p6lHoGqRjiEAh1R39eFrSgwZW9uNmIsxWmtl-9SEQyQxb51x_XD1vwLi1JhI3eIa5uCMvxXbRj5WQDrIERvHwGkL-V/w640-h244/video.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiKRmZM0AQmYrx8wvUc0LqtpIwpGOgGPcPGqTeezyXUM0q1WY_TP_AN9UJno42Eutj7xBDlzFUCN0yM_MItJU_hb4fqPl2LCQVR66p6lHoGqRjiEAh1R39eFrSgwZW9uNmIsxWmtl-9SEQyQxb51x_XD1vwLi1JhI3eIa5uCMvxXbRj5WQDrIERvHwGkL-V/s816/video.gif)

  
*Caption: An example of Chrome’s new prioritized loading of the first five images parsed from the HTML. This improved LCP from 3.1s to 2.5s.*

Ecosystem Core Web Vitals Achievements

  

The broader developer ecosystem has also achieved remarkable results by focusing on Core Web Vitals. The most significant achievement was the performance improvement on WordPress - the Content Management System that powers over a third of the web: "[WordPress 6.3](https://make.wordpress.org/core/2023/08/07/wordpress-6-3-performance-improvements/) loads 27% faster for block themes and 18% faster for classic themes, compared to WordPress 6.2, based on the [Largest Contentful Paint (LCP)](https://web.dev/articles/lcp) metric". 

Some parts of the WordPress ecosystem are going even further. Prerendering some links via the [speculation rules API](https://developer.chrome.com/blog/prerender-pages/), [NitroPack](https://nitropack.io/)'s prerendered page loads have seen an 80% LCP improvement and 55% INP improvement compared to those without any speculative loading.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjxjcDZR8KcnwqG2wWjgsZP6vE1uCcUGuNCMCjORJUjoFBe2PBclSgQfNz4S21j4H7d8snA6gQUwewxoSjJEDK76Yt1NAaXjYnvmAYa9HI-P_pn6Ue7hN321LQsiPldKNt1DUz8nwqMX6AXb1GNRlHR_xOLnwfbDjSn6w0EszDNYU0F4miZnva8h-l75z4O/w640-h404/Screenshot%202023-11-06%20at%209.48.00%E2%80%AFAM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjxjcDZR8KcnwqG2wWjgsZP6vE1uCcUGuNCMCjORJUjoFBe2PBclSgQfNz4S21j4H7d8snA6gQUwewxoSjJEDK76Yt1NAaXjYnvmAYa9HI-P_pn6Ue7hN321LQsiPldKNt1DUz8nwqMX6AXb1GNRlHR_xOLnwfbDjSn6w0EszDNYU0F4miZnva8h-l75z4O/s984/Screenshot%202023-11-06%20at%209.48.00%E2%80%AFAM.png)

  

*Caption: The percentage of origins passing all three Core Web Vitals (LCP, FID, CLS) with a "good" experience (Source: [HTTP Archive](https://httparchive.org/reports/chrome-ux-report#cruxPassesCWV))*

The JavaScript framework community has also seen Core Web Vital gains. Over the past few years, [Chrome Aurora](https://developers.chrome.com/aurora) has collaborated with Next.js, Angular, and Nuxt to release performance-focused features like the [next/script component](https://nextjs.org/docs/app/building-your-application/optimizing/scripts), [NgOptimizedImage](https://angular.io/guide/image-directive), and [nuxt/google-fonts](https://google-fonts.nuxtjs.org/). In 2022, Next.js pass rates increased from 20.4% to 27.3%, Angular pass rates increased from 7.6% to 13.2%, and Nuxt pass rates increased from 15.8% to 20.2%. Enterprise partners who tried our features have seen wins in LCP. For example, after switching to NgOptimizedImage, Land's End saw a 40% LCP improvement on mobile in Lighthouse lab tests and a 75% improvement in LCP on desktop. In similar tests, CareerKarma's LCP reduced 24% when switching to next/script's web worker mode.

In the business world, performance optimization has led to remarkable growth. For instance, RedBus improved INP and observed a [7%](https://web.dev/case-studies/redbus-inp) increase in conversion rates. Economic Times improved INP and saw a [42%](https://web.dev/case-studies/economic-times-inp) rise in page views and a 49% reduction in bounce rate. Meesho successfully brought LCP down from 6.9s to 2.5s, resulting in a 16.6% reduction in bounce rate and a 3% increase in conversions.

  

Major web platforms have also seen significant improvements. Amazon has leveraged the bfcache change introduced on Chrome and saw a 22.7 percentage point (pp) improvement in bfcache hit rate with Chrome's latest version (M112). Cricbuzz experienced an even higher increase, with a 31.40 pp improvement.

  
  

Partnering for a Better Web 

  

These performance improvements aren't just statistics – they represent real-world improvements in user experience (and hence [business metrics](https://web.dev/case-studies/terra-prefetching-case-study)) as well as developer experience.

 

Crucially, we have managed to achieve these speed boosts without impacting developer satisfaction, which remains high at 90% overall. Through our developer satisfaction studies, we also found that about half (~51%) of developers are monitoring CWV and are either already optimizing for them or planning to do so. Furthermore, a significant majority (78%) of developers optimizing for CWV report seeing notable improvements in their scores.

  

Our aim is always to create a better web experience for all users, so we're excited to see the web getting faster. But we also understand that maintaining developer satisfaction is crucial to sustaining these improvements. As developers continue to monitor and optimize for CWV, we are optimistic about the future of web performance.

  

On behalf of the Chrome team, we want to thank the developer community for their incredible work. By focusing on Core Web Vitals, we've made the web a significantly faster and more enjoyable place to be. We look forward to continuing this journey together, making the web better for everyone, everywhere.

  

Posted by Addy Osmani, Annie Sullivan and Kouhei Ueno, Software Engineers for Chrome