URL:https://blog.chromium.org/2019/11/moving-towards-faster-web.html
# Moving towards a faster web
- **Published**: 2019-11-11T10:31:00.000-08:00
Speed has been one of Chrome’s core principles since the beginning - we’re constantly working to give users an experience that is instant as they browse the web. That said, we have all visited web pages we thought would load fast, only to be met by an experience that could have been better. We think the web can do better and want to help users understand when a site may load slowly, while rewarding sites delivering fast experiences.

  

In the future, Chrome may identify sites that typically load fast or slow for users with clear badging. This may take a number of forms and we plan to experiment with different options, to determine which provides the most value to our users.

  

Badging is intended to identify when sites are authored in a way that makes them slow generally, looking at historical load latencies. Further along, we may expand this to include identifying when a page is likely to be slow for a user based on their device and network conditions.

  

Our early explorations will look at a number of Chrome surfaces, including the loading screen (splash screen), loading progress bar and context-menu for links. The latter could enable insight into typical site speeds so you’re aware before you navigate.

  

![](https://lh6.googleusercontent.com/qq2pRL2qiXRiFASwvuqnYxHfcXdt69i8aVUhuCGQSeoAyH_kJ6kIT44ExZuY65UXAOMuVDl1j2GifEeRrIg79IUlefdKhyBbdNkcvW_enZ8CBYtRspzkO2kvl1VMowvQJJ-J_Sfd)

  

Our plan to identify sites that are fast or slow will take place in gradual steps, based on increasingly stringent criteria. Our long-term goal is to define badging for high-quality experiences, which may include signals beyond just speed.

  

We are building out speed badging in close collaboration with other teams exploring labelling the quality of experiences at Google. We believe this will ensure that if you are optimizing your site to be fast, your site will not be inconsistently badged from one surface to another.

  

We are being very mindful with our approach to setting the bar for what is considered a good user experience and hope to land on something that is practically achievable by all developers. We will publish updates to this plan as we approach future releases, but don’t wait to optimize your site. A number of resources are available for learning what opportunities are available to improve your site speed.

To evaluate performance, check:

* [PageSpeed Insights](https://developers.google.com/speed/pagespeed/insights/), an online tool that shows speed [field data](https://developers.google.com/web/fundamentals/performance/speed-tools/#field_data) for your site, alongside suggestions for common optimizations to improve it.
* [Lighthouse](https://developers.google.com/web/tools/lighthouse/), [a lab tool](https://developers.google.com/web/fundamentals/performance/speed-tools/#lab_data) providing personalized advice on how to improve your website across performance and other best practices.

To learn about performance best practices, check [web.dev/fast](https://web.dev/fast) - our learning platform with guides and codelabs on how to get your pages loading instantly.

  

We are excited to reward you for your work and give our users more transparency into typical site performance. We hope this effort will encourage more sites on the open web to provide the best possible experiences to all users.

  
  

Posted by Addy Osmani, Ben Greenstein and Bryan McQuade from the Chrome team