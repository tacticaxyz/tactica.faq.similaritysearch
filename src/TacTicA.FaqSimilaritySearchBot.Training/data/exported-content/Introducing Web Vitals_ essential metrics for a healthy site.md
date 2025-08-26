URL:https://blog.chromium.org/2020/05/introducing-web-vitals-essential-metrics.html
# Introducing Web Vitals: essential metrics for a healthy site
- **Published**: 2020-05-05T09:00:00.000-07:00
Optimizing for quality of user experience is key to the long-term success of any site on the web. Through our ongoing engagement and collaboration with millions of web developers and site owners, we’ve developed many helpful metrics and tools across Google to help business owners, marketers, and developers alike identify opportunities to improve user experiences. However, abundance of metrics and tools creates its own set of prioritization, clarity, and consistency challenges for many.

  
  

Today we are introducing a new program, [Web Vitals](https://web.dev/vitals/), an initiative by Google to provide unified guidance for quality signals that, we believe, are essential to delivering a great user experience on the web.

[![](https://lh6.googleusercontent.com/i9iF8GqgQhXkh1MLRlGQjYRxy_WzXNWTOTvBl5b-HCiL8HTgCk-Qh7PINQ1ruv-q5qUiRNhlpzKMybGzO_nYiTVOxIJoFBxBLRMIPCbI4AIcKLmcMhmh08JWQpCtpJq-hltKhiFi)](https://lh6.googleusercontent.com/i9iF8GqgQhXkh1MLRlGQjYRxy_WzXNWTOTvBl5b-HCiL8HTgCk-Qh7PINQ1ruv-q5qUiRNhlpzKMybGzO_nYiTVOxIJoFBxBLRMIPCbI4AIcKLmcMhmh08JWQpCtpJq-hltKhiFi)

Core Web Vitals
---------------

Measuring the quality of user experience has many facets. While some aspects of user experience are site and context specific, there is a common set of signals — "Core Web Vitals" — that is critical to all web experiences. Such [core user experience needs](https://web.dev/user-centric-performance-metrics/#defining-metrics) include loading experience, interactivity, and visual stability of page content, and combined are the foundation of the 2020 Core Web Vitals.

[![](https://lh5.googleusercontent.com/HlrpevA1hZKx35h2SQdwOBdCO4FOC0YOqie9eMTiGDZx5MdSVTxY2VwPwdL58Pi68cuuG0ooeRTs3RJQEfU5woNRpgq1ZLV4SrWkzHIOH4kTnLS32i62Qf7UibEcz2xm8Gb4nT_e)](https://lh5.googleusercontent.com/HlrpevA1hZKx35h2SQdwOBdCO4FOC0YOqie9eMTiGDZx5MdSVTxY2VwPwdL58Pi68cuuG0ooeRTs3RJQEfU5woNRpgq1ZLV4SrWkzHIOH4kTnLS32i62Qf7UibEcz2xm8Gb4nT_e)
  

* [Largest Contentful Paint](https://web.dev/lcp/) measures perceived load speed and marks the point in the page load timeline when the page's main content has likely loaded.
* [First Input Delay](https://web.dev/fid/) measures responsiveness and quantifies the experience users feel when trying to first interact with the page.
* [Cumulative Layout Shift](https://web.dev/cls/) measures visual stability and quantifies the amount of unexpected layout shift of visible page content.

  

All of these metrics capture important user-centric outcomes, are [field measurable](https://developers.google.com/web/fundamentals/performance/speed-tools), and have supporting lab diagnostic metric equivalents and tooling. For example, while Largest Contentful Paint is the topline loading metric, it is also highly dependent on [First Contentful Paint](https://web.dev/fcp/) (FCP) and [Time to First Byte](https://web.dev/time-to-first-byte/) (TTFB), which remain critical to monitor and improve.

### Measuring Core Web Vitals

Our goal is to make Core Web Vitals simple and easy to access and measure for all site owners and developers, both across Google surfaces as well as within their own dashboards and tools.

  

[Chrome UX Report](https://developers.google.com/web/tools/chrome-user-experience-report) enables site owners to quickly assess performance of their site for each Web Vital, as experienced by real-world Chrome users. The BigQuery dataset already surfaces publicly accessible histograms for all of the Core Web Vitals, and we are working on a new REST API that will make accessing both URL and origin level data simple and easy — stay tuned.

  
  

We strongly encourage all site owners to gather their own [real-user measurement analytics](https://web.dev/user-centric-performance-metrics/#in-the-field) for each Core Web Vital. To enable that, a number of browsers, including Google Chrome, support the current Core Web Vitals draft specifications: [Largest Contentful Paint](https://wicg.github.io/largest-contentful-paint/), [Layout Instability](https://wicg.github.io/layout-instability/), and [Event Timing](https://wicg.github.io/event-timing/). To make it easy for developers to measure Core Web Vitals performance for their sites, today we are launching an open-source [web-vitals](https://github.com/GoogleChrome/web-vitals/) JavaScript library, which can be used with any analytics provider that supports custom metrics, or as a reference for how to accurately capture each of the Core Web Vitals for your site’s users.

  
  

// Example of using web-vitals to measure & report CLS, FID, and LCP.

import {getCLS, getFID, getLCP} from 'web-vitals';

  
  

function reportToAnalytics(data) {

const body = JSON.stringify(data);

(navigator.sendBeacon && navigator.sendBeacon('/analytics', body)) ||

fetch('/analytics', {body, method: 'POST', keepalive: true});

}

  
  

getCLS((metric) => reportToAnalytics({cls: metric.value}));

getFID((metric) => reportToAnalytics({fid: metric.value}));

getLCP((metric) => reportToAnalytics({lcp: metric.value}));


  

In our testing and development process we’ve found it valuable to have easy access to the state of each Core Web Vital both in development and as we browse the web. To help developers spot optimization opportunities today we are also releasing a developer preview of the [new Core Web Vitals extension](https://github.com/GoogleChrome/web-vitals-extension/). This extension surfaces a visual indicator in Chrome about the state of each vital as you browse the web and, in the future, will also allow you to view aggregated real-user insights (provided by Chrome UX Report) about the state of each core vital for the current URL and origin.

  
  

Finally, over the coming months we will be updating [Lighthouse](https://developers.google.com/web/tools/lighthouse), [Chrome DevTools](https://developers.google.com/web/tools/chrome-devtools), [PageSpeed Insights](https://developers.google.com/speed/pagespeed/insights/), [Search Console’s Speed Report](https://webmasters.googleblog.com/2019/11/search-console-speed-report.html), and other popular tools to highlight and provide consistent and actionable guidance for improving Core Web Vitals.

Evolving Core Web Vitals
------------------------

While today's Core Web Vitals metrics measure three important aspects of user experience on the web, there are many aspects of user experience that are not yet covered by Core Web Vitals. To improve our understanding of user experience going forward, we expect to update Core Web Vitals on an annual basis and provide regular updates on the future candidates, motivation, and implementation status.

  

Looking ahead towards 2021, we are investing in building better understanding and ability to measure page speed, and other critical user experience characteristics. For example, extending the ability to measure input latency across all interactions, not just the first; new metrics to measure and quantify smoothness; primitives and supporting metrics that will enable delivery of instant and privacy preserving experiences on the web; and more.

  
  

Make sure to follow our [updates on web.dev](https://web.dev/blog/) and [subscribe to our mailing list](http://web.dev/newsletter) for future updates on vitals and all things Web.

  
  
  
  
  

Ilya Grigorik, Web Performance Engineer