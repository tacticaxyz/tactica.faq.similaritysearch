URL:https://blog.chromium.org/2010/08/new-flock-browser-based-on-chromium.html
# New Flock Browser Based On Chromium
- **Published**: 2010-08-24T09:54:00.000-07:00
*Foreword: When we released Google Chrome almost two years ago, we also released the source code under an open-source license. Just as Firefox, WebKit, and other open source projects helped to drive the web forward, we wanted to follow suit and ensure that others could use the code we developed to make their products better. The Chromium codebase provides a complete browser to build on, so that if you want to focus on one particular piece, such as drastically changing the user interface, you can do that without having to worry about how to get amazing performance in the rest of the browser.*

  

*Recently, Flock released a new beta version of their browser built on top of the Chromium codebase. For those of us in the Chromium project, this is extremely exciting and encouraging. We believe that users having a choice between multiple browsers is a great thing, as it spurs innovation and competition, and lets users choose a browser that provides the best experience for them. Flock brings an innovative approach to their "social web browser," and we are glad to welcome them into the Chromium community. As part of that, we wanted to offer the team behind Flock an opportunity to talk about the ideas behind Flock, how Chromium helped them in achieving their goals, and their vision for the future. What follows is a perspective from Clayton Stark, VP Engineering at Flock.*

When Flock began developing its first web browser five years ago, "the social web" was a small, niche market. Today social is the mainstream web, and this evolution in the market drove our development roadmap. With the new Flock browser, our engineering team focused on designing a straightforward and integrated social dashboard that delivers an experience simple enough for a mass audience. This is where the technology behind Chromium came into the picture for Flock. As Chromium emerged, we saw that not only was there significant improvements to performance, but also apparent was a simple and elegant user interface and architecture across all the various systems.

A core goal of new Flock is to keep our users in touch with all of their friends and feeds with a minimum of configuration, and at the same time, make it fun and simple. With all of the users’ feeds and social activity streams flowing into the scrolling sidebar, we knew the performance had to be first-rate, and that techniques we used for earlier versions of Flock were unlikely to perform at scale. With Chromium under the hood, we were able to leverage web workers, and that, combined with the raw horsepower of V8, allowed us to scale the use of the sidebar to manage very large data sets (in the first few weeks after the beta launched we saw a few hundred million activities flowing into Flock’s sidebar). Most importantly, benchmark testing shows us that New Flock with Chromium performs in the top-tier of all browsers available in the market.

Clearly the web is evolving very quickly, and we are seeing more and more people discovering content through their friends. The Flock team is energized by the big developments coming fast in this emerging, interest-graph-enabled web, and we have a roadmap in front of us that we are really excited about. The browsing platform needs to continue to mature at a rapid pace to support the dramatic changes in online user behavior. And, as it does, we already see the performance and power in Chromium that we need to allow us to focus on the innovations we want to bring forward, on top of the platform.

So, I’d like to send out a huge thanks on behalf of the Flock team to all those who have contributed to the Chromium project. Your work has made our project possible, and made new Flock our best release ever.

Clayton Stark, VP Engineering

Flock, Inc.

Posted by Ian Fette, Product Manager