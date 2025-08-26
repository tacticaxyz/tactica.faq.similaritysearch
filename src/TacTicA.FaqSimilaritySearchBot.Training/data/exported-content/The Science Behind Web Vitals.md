URL:https://blog.chromium.org/2020/05/the-science-behind-web-vitals.html
# The Science Behind Web Vitals
- **Published**: 2020-05-21T15:43:00.001-07:00
[Web Vitals](https://blog.chromium.org/2020/05/introducing-web-vitals-essential-metrics.html) is an initiative by Google to help business owners, marketers and developers alike identify opportunities to improve user experiences. These signals are guided by extensive work by many researchers in the fields of human–computer interaction (HCI) and user experience (UX). But figuring out the right metrics and thresholds is not as simple as picking up a research paper and finding the answer.

Journeys, not pages
-------------------

Imagine you’re walking through an unfamiliar city to get to an important appointment. You walk through various streets and city centers on your way. But here and there, loose paving stones make you trip, there are slow automatic doors you have to wait for to open, and unexpected construction detours lead you astray. All of these events interrupt your progress, increase stress and distract you from reaching your destination.

People using the web are also on a journey, with each of their actions constituting one step in what would ideally be a continuous flow. And just like in the real world, they can be interrupted by delays, distracted from their tasks and led to make errors. These events, in turn, can lead to reduced satisfaction and abandonment of a site or the whole journey.

In both cases, removing interruptions and obstacles is the key to a smooth journey and a satisfied user.

So what trips users up on the web?

Interruptions due to waiting
----------------------------

The most common type of interruption web users experience is waiting for pages to load. For a developer, a page load is a discrete event and some delay might feel inevitable. However, a page load more often happens in the *middle* of a user's journey, as they learn about recent events in the news, research a new product or add items to a cart for purchase. So from the user's point of view, loading a particular page doesn't represent a natural break: they haven’t yet achieved their goal, which may make them less tolerant of delays.[1](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f1) This means pages need to load fast so the user's journey can flow smoothly.

How fast is fast enough? In a way, that’s the wrong question. There’s no single magic number and there's three main reasons why.

First, the answer depends on the outcome you consider, for instance abandonment, user satisfaction or task performance. Different studies focus on different outcomes and yield different results.

Second, the effect of delays varies hugely depending on a user's personality, past experience and the urgency of their task.[2](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f2) For example, if you were to plot how many users stayed on a site as a function of the delay they experienced, you would not see a clean step from 100% to 0% after X seconds. You would instead see a smooth distribution that might look like this:

[![Chart showing the percent of users remaining decreasing as the delay increases](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgwuJ-ks8MJyZAoGE7E9socTGtBTr4FUM0BEZqvlGSTmn9eMpVvheiE0nm3XUOAGyCfNf5VpnElDLuRGkaTOPtpkLW-i2ZmpPvVhqLhDzUrKrirBU-sgTd09X5qURAHk16O4VN5ElyYQu_2/s1600/users_remaining_delay.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgwuJ-ks8MJyZAoGE7E9socTGtBTr4FUM0BEZqvlGSTmn9eMpVvheiE0nm3XUOAGyCfNf5VpnElDLuRGkaTOPtpkLW-i2ZmpPvVhqLhDzUrKrirBU-sgTd09X5qURAHk16O4VN5ElyYQu_2/s1600/users_remaining_delay.png)

So we must ask: which point on this curve do we aim for? In other words, how much do we invest in speed on the one hand, and how many of our users will we lose on the other?

Finally, the effect of delays varies depending on the context and situation. News sites, shopping sites and travel sites are often part of different kinds of user journeys, and the entire curve above might look different for each of them. Even within a context, site design and user behavior can change over time.

Although this is more difficult than we may have hoped, a distribution of outcomes at different levels of performance still contains useful hints. In particular, the distribution reveals how many users we may lose (or are losing currently) at a given level of performance. In addition, the steepness of the curve at different points can tell you how much return you’ll get for optimising speed by a particular amount. These are important factors in your tradeoff decision, since your time as a designer or engineer is also valuable.

So instead of looking for a single magic number, our goal is to find in the research useful ranges of values and reasonable guidelines. For example:

* One study found that delays decreased satisfaction and intention to return. On unfamiliar sites, 2 seconds of delay was enough to cause most of the drop – familiar sites bottomed out after longer delays. On unfamiliar sites, task performance also suffered, with most of the drop observed with delays of up to 4 seconds.[3](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f3)
* Another study involved navigating a nested menu on a web page. A range of delays, 3 seconds apart, was tested for loading each panel. Satisfaction dropped when increasing the delay from 0 to 3 seconds and again when going from 9 to 12 seconds. Intention to return also dropped with the 12-second delay. A 6-second delay was enough for some participants to remark on the site being slow.[4](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f4)
* One study found that mobile web users didn’t tend to keep their attention on the screen for more than 4–8 seconds at a time.[5](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f5) This would mean that if they avert their attention before your page has loaded, the time they’re looking away further delays how soon they finally see the page. So a 5-second load time might turn into a 10-second effective delay.
* It’s been suggested that the speed of a system’s response should be comparable to the delays humans experience when they interact with one another. This has led to guidance that responses should take about 1–4 seconds.[6](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f6)

The empirical studies are drawn from data with high variability and gradual drop-offs rather than hard thresholds, and the others are based on predictions from theory. But collectively they suggest that it’s worth aiming to keep load times within a couple of seconds.

The [Largest Contentful Paint](https://web.dev/lcp/) (LCP) metric measures when a page-to-page navigation appears complete to a user. We [recommend](https://web.dev/lcp/#what-is-a-good-lcp-score) sites aim to **keep LCP under 2.5 seconds for 75% of their page loads**. This recommendation is further informed by Chrome analysis of the web today and aims to be feasible for enough sites to attain in practice. For more details of that analysis, see [Defining the Core Web Vitals metric thresholds](https://web.dev/defining-core-web-vitals-thresholds/).

Interruptions and errors from instability
-----------------------------------------

Most web pages need to load several elements, and often these load progressively. This can actually be a good thing: if some content appears as early as possible, it may allow a user to start making progress towards their goal without waiting for everything to load.

However, if the position of already-visible elements shifts as others load, this can negatively affect the user’s experience in two ways.

One is that if an element they’re looking at suddenly moves, it will take their eyes at least a couple hundred milliseconds to find its new position.[7](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f7) If it scrolled out of view, it will take much longer. This type of interruption slows the user journey and can be very frustrating.

A more serious consequence is that unexpected layout shifts can lead to errors. If the user is trying to tap an element that then moves, they may end up tapping something else that moved into its original position. This is because the delay from perceiving the shift, deciding to abandon their action and then doing so can make it *impossible* for a human to respond appropriately. This could mean clicking a link or ad or "Buy Now" button unintentionally and significantly disrupting the user's intended journey.

[Cumulative Layout Shift](https://web.dev/cls/) (CLS) measures how frequent and severe unexpected layout shifts are on a page. Fewer shifts mean less chance for interruption and errors. We [recommend](https://web.dev/cls/#what-is-a-good-cls-score) sites **aim for a CLS of less than 0.1 for 75% of page loads**.

Distraction and errors from low responsiveness
----------------------------------------------

While page loads represent the larger transitions in a user’s journey – like entering a building – the small steps also matter.

When you’re walking, you don’t really want to be conscious of the mechanics of walking. Ideally, you actually forget that you’re walking and can focus on other things, like finding your way. But something like having a stone in your shoe will interfere with that concentration.

Likewise, you don’t want users’ experience to suffer from frictions in their moment-to-moment interactions with your site. Here are some research insights relevant to achieving this:

* One study found that a delay in visual feedback from touch screen buttons became perceivable when it was increased from 70ms to 100ms. When it was further increased from 100ms to 150ms, people also rated the quality of the buttons as significantly lower.[8](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f8)
* One experiment showed that in an animation, the illusion that one event caused another started breaking when there was a delay of about 100ms.[9](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f9) It’s been suggested that similarly, the illusion of direct manipulation in user interfaces will break down with delays longer than this.[10](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f10) (This guidance was apparently also informed by an earlier best-guess recommendation that actions should have a visible effect within 100–200ms.[11](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f11))

Just as for LCP, there’s no “magic number”, only markers representing distributions. Some individuals are much more sensitive than others,[12](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f12) and shorter delays may be noticed when haptic or auditory feedback is involved.[13](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#f13)

Aside from changing how the UI feels, delaying something people expect to be near-instantaneous can lead them to make errors. They may repeat an action because they think it didn’t work, and the second action can have an undesirable effect. For example, they may click an “add to cart” button twice and not realise that they’re now buying two items.

The responsiveness related to these experiences is measured by [First Input Delay](https://web.dev/fid/) (FID), and we [recommend](https://web.dev/fid/#what-is-a-good-fid-score) sites aim to **keep FID under 100 milliseconds for 75% of page loads**.

Impact
------

We analyzed millions of page impressions to understand how these metrics and thresholds affect users. We found that when a site meets the above thresholds, **users are 24% less likely to abandon page loads** (by leaving the page before any content has been painted).

We also looked specifically at news and shopping sites, sites whose businesses depend on traffic and task completion, and found similar numbers: **22% less abandonment for news sites** and **24% less abandonment for shopping sites**. There are few interventions that can show this level of improvement for online businesses, and results like these are part of the reason we and our ecosystem partners prioritize the Web Vitals metrics.

Providing a smooth journey for users is one of the most effective ways to grow online traffic and web-based businesses. We hope the Web Vitals metrics and thresholds will provide publishers, developers and business owners with clear and actionable ways to make their sites part of fast, interruption-free journeys for more users.

*Amar Sagoo, Staff Interaction Designer  
Annie Sullivan, Software Engineer  
Vivek Sekhar, Product Manager*

---

1 Miller, R. B. (1968). [Response time in man-computer conversational transactions](https://scholar.google.com/scholar?cluster=15394303020349681856). In *Proceedings of the December 9-11, 1968, fall joint computer conference, part I* (pp. 267–277).
  
2 Shneiderman, B. (1984). [Response Time and Display Rate in Human Performance with Computers](https://scholar.google.com/scholar?cluster=4944929588150003214). *ACM Computing Surveys (CSUR), 16*(3), 265–285.
  
3 Galletta, D. F., Henry, R., McCoy, S. & Polak, P. (2004). [Web Site Delays: How Tolerant are Users?](https://scholar.google.com/scholar?cluster=4485961943262157644) *Journal of the Association for Information Systems, 5*(1), 1.
  
4 Hoxmeier, J. A. & DiCesare, C. (2000). [System Response Time and User Satisfaction: An Experimental Study of Browser-based Applications](https://scholar.google.com/scholar?cluster=9160744741984052948). *AMCIS 2000 Proceedings*, 347.
  
5 Oulasvirta, A., Tamminen, S., Roto, V. & Kuorelahti, J. (2005). [Interaction in 4-Second Bursts: The Fragmented Nature of Attentional Resources in Mobile HCI](https://scholar.google.com/scholar?cluster=4253037783945263059). In *Proceedings of the SIGCHI conference on Human factors in computing systems* (pp. 919–928).
  
6 Card, S. K., Robertson, G. G., & Mackinlay, J. D. (1991). [The information visualizer, an information workspace](https://scholar.google.com/scholar?cluster=12987937771785470939). In *Proceedings of the SIGCHI Conference on Human factors in computing systems* (pp. 181-186).
  
Miller, R. B. (1968). [Response time in man-computer conversational transactions](https://scholar.google.com/scholar?cluster=15394303020349681856). In *Proceedings of the December 9-11, 1968, fall joint computer conference, part I* (pp. 267–277).
  
Nielsen, J. (1993). *[Response Times: The 3 Important Limits](https://www.nngroup.com/articles/response-times-3-important-limits/)*. Nielsen Norman Group.
  
7 Purves D., Augustine G. J., Fitzpatrick D., et al. (2001). [Types of Eye Movements and Their Functions](https://www.ncbi.nlm.nih.gov/books/NBK10991/). *Neuroscience (2nd edition)*.
  
8 Kaaresoja, T., Brewster, S., & Lantz, V. (2014). [Towards the Temporally Perfect Virtual Button: Touch-Feedback Simultaneity and Perceived Quality in Mobile Touchscreen Press Interactions](https://scholar.google.com/scholar?cluster=7171429988845527770). *ACM Transactions on Applied Perception (TAP), 11*(2), 1–25.
  
9 Card, S. K. (Ed.). (2018). *[The psychology of human-computer interaction](https://books.google.com/books?id=iUtaDwAAQBAJ)*. Crc Press.
  
10 Nielsen, J. (1993). *[Response Times: The 3 Important Limits](https://www.nngroup.com/articles/response-times-3-important-limits/)*. Nielsen Norman Group.
  
11 Miller, R. B. (1968). [Response time in man-computer conversational transactions](https://scholar.google.com/scholar?cluster=15394303020349681856). In *Proceedings of the December 9-11, 1968, fall joint computer conference, part I* (pp. 267–277).
  
12 Jota, R., Ng, A., Dietz, P., & Wigdor, D. (2013, April). [How fast is fast enough? a study of the effects of latency in direct-touch pointing tasks](https://scholar.google.com/scholar?cluster=18295113717256728772). *In Proceedings of the sigchi conference on human factors in computing systems* (pp. 2291-2300).
  
13 Kaaresoja, T., Brewster, S., & Lantz, V. (2014). [Towards the Temporally Perfect Virtual Button: Touch-Feedback Simultaneity and Perceived Quality in Mobile Touchscreen Press Interactions](https://scholar.google.com/scholar?cluster=7171429988845527770). *ACM Transactions on Applied Perception (TAP), 11*(2), 1–25.