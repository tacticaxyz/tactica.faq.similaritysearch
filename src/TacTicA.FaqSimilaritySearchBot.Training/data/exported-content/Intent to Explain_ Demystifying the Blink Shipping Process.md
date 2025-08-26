URL:https://blog.chromium.org/2019/11/intent-to-explain-demystifying-blink.html
# Intent to Explain: Demystifying the Blink Shipping Process
- **Published**: 2019-11-12T10:30:00.000-08:00
If you’re a standards-curious web developer, you may have wondered how features get added to browsers, or even how the Chrome team decides what they will work on. You probably also have, at least at some point, thought to yourself “I have this urgent problem but I’ll have to work around it for the foreseeable future, because browsers are just too slow to bring in changes”. You may have even added some expletives when no one was around.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

  

If that description sounds accurate, this is the post for you! This post will describe the Blink process, how browser engineers (both inside and outside of Google) use it in order to ship features in Chromium, what considerations are taken when deciding to ship a new feature, as well as some considerations that impact what features get worked on, and how you can play a role in all of this!

Project goals
-------------

The [Chromium project](https://www.chromium.org/) is the open source project on which Chrome is built, and on which other browsers are also based: Samsung Internet, Opera, Brave, Vivaldi, and last (to join the project) but not least, Microsoft Edge. The project enables all those different browsers to share a single implementation of the web platform, and at the same time, keep their unique characteristics and focus.

  

[Blink](https://www.chromium.org/blink) is the rendering engine used by Chromium. It is the part of the project that descends from [WebKit](https://webkit.org/) (the rendering engine Safari uses), and which is mostly (but not exclusively) responsible for the Chromium’s Web Platform implementation. The goal of Chromium and Blink inside it is to continuously improve the web platform as a whole.

  

How does Blink improve the web platform?

* By improving its [predictability](https://www.chromium.org/blink/platform-predictability) through testing and infrastructure, making sure developers have to spend less of their time tackling browser-specific issues and more of their time… well, developing.
* By [removing user hostile features](https://www.chromium.org/blink/removing-features), features that increase the platform’s complexity or make its implementations less secure.
* By [adding platform capabilities](https://www.chromium.org/blink#new-features) that enable web developers to innovate and create web experiences that meet and exceed their users’ expectations and needs.

  

If we want the web to thrive in the long term, we need to make sure that our users consider it safe and pleasant to use, and that it supports all the capabilities developers need in order to easily make their users (and businesses) are happy.

  

Any improvement to the platform needs to take [backwards compatibility](https://docs.google.com/document/d/1RC-pBBvsazYfCNNUSkPqAVpSpNJ96U8trhNkfV0v9fk/edit#heading=h.83o2xr8ayal6) and [cross-browser interoperability](https://docs.google.com/document/d/1romO1kHzpcwTwPsCzrkNWlh0bBXBwHfUsCt98-CNzkY/edit#heading=h.mxgkfxtgzxqs) into account. There’s a lot of web content out there that will never change. The risk of breaking some of it needs to be weighed against the user benefits of shipping that new feature or removing that risky old one. Similarly, in cases where Blink is the first engine to ship a feature or to remove it, we should make sure other browser vendors can follow. We do that by ensuring shipped features designs are widely reviewed, and have specifications and [tests](https://wpt.fyi/) to guide future implementers.

  

The Chromium project is rather large, and is being worked on by many different entities. Therefore it needs to control which features get shipped, while being even-handed in that decision process. We achieve that through a simple process that guides contributors as they evolve the platform to ensure maximum long-term compatibility and interoperability.

### What features get worked on?

Chromium is an open source project that’s being worked on by over 2000 engineers from ~55 different organizations. Of course, Google is responsible for the bulk of Chromium - 92% of commits to the project ([data](https://docs.google.com/spreadsheets/d/1XPpuM-8bokpInY0gWesN3VcAVlofKDh5nSGKy0MYU6s/edit#gid=64465891)) come from Google,  although about 20% of contributors are not Google-affiliated.

![](https://lh3.googleusercontent.com/XTILGQgwOtJSoNWY-X3D7sAKlgP6X1oNUDHfrrVtvTD4w-zYQKRpg-3ulZvE-sRVTcPak7MjbbfMWv-q5tG9pWIv6pVEktuCvIHzIqwnRjBzJc2E9Pexb_RASCVWNJPmtNXoVvr6)![](https://lh5.googleusercontent.com/43j0PbKFw8euVBTWpjJ02OrCtcAo_HvvvZBEoOguPYgzF7qezazjPrR_T9WVue3oIcZIGniTIwli5Muj_sGxm7dLDeoNSUcRsb5ju43Lf2i8kR_U-0GqjtizepnNSQzkTrg9FVDw)

With a project of this magnitude, each of the involved companies and contributors are naturally pushing their own slightly different agenda and priorities. Even within Google’s Chrome team there are multiple ways to prioritize which problems are most urgent to tackle and solve. One area that is consistent, is that we work with the ecosystem and developer partners to understand and address their needs. We do that by creating compatibility dashboards, collaborating with frameworks, and observing development patterns in the wild.

  

The [MDN survey](https://hacks.mozilla.org/2019/07/mdn-web-developer-designer-survey/) is a great example of how the ecosystem can help shape the priorities that a browser vendor has. We’re still in the process of analyzing the results, but it was clear that compatibility is a top priority for developers and we will commit to keep improving on it. We also plan to create more ways to gather structured data on developer needs and hardships.

  

As you can imagine, with all these priorities from different contributors, it's important for us to be clear about how a feature goes from inception to shipping.

[![](https://lh4.googleusercontent.com/zzS6iuWDTM21y3-9rvisM_rraWcABE9PnwM6Ans54hBEsa3YsoEwggjZ_DeNmyRqKcly_jtGCvmE0_rWB9G8rBpLeXKmOmHFBzkuKSHniIhaF0UWy1hghMagdW7-_y8siTE5VNta)](https://developers.google.com/web/chromium-blog/intent-to-infographic.jpg)

  

So, what are the typical phases of creating a new web platform feature and shipping it in Chromium?

  

The very first step before getting started would be to figure out what we need to be working on and which user or developer problems are the most burning ones. That is typically done by talking to partners, looking at current development patterns and consulting with web developers and framework authors to get a better understanding of what the platform can do better to address their and their users’ needs.

Once we know which problem we want to tackle, we can start incubating it!

---

What does “incubating” mean?  

  

Over the years, we found that the best way to design and prototype a new platform feature is through incubation - getting a strong grasp of the use cases a feature is trying to solve as a first step, and then rapidly iterating over the design in a public forum that includes browser engineers and domain experts. Only once we are certain that a feature solves important use-cases and have high confidence that it solves it the right way, we bring that feature to an official track at a Standard Development Organization, such as a W3C Working Group, the WHATWG, or TC39.

  

Not all incubations turn up to be standards though. Some incubations fail and some prototypes never make it out to the hands of users. That is perfectly fine and by design. The web platform cannot afford features that don’t solve real user or developer problems to creep in, and we want to make sure those features never make it to be a permanent part of the platform.

---

  
Step 1 - Initial research  

At this phase, we establish a better understanding of the problem space, by gathering up the specific use-cases we want our future solution to tackle and the constraints under which the solution must operate.

  

At the end of that phase, engineers are expected to publish an [explainer](https://w3ctag.github.io/explainers) that outlines the above, and maybe have a very rough sketch of what a solution may look like. The explainer is published in a relevant public forum (e.g. the [WICG discourse](https://discourse.wicg.io/)) in order to solicit feedback from the web community at large. Such feedback can include missed-out use-cases, further constraints that can impact the design, or simply statements of support for solving the problem.

  

It’s important at this stage to focus on the problem, and not over-index on any one possible solution - and this is one of the places we haven’t always been perfect.

### Step 2 - Design & Prototype

Now that we have better grip of the problems we’re trying to solve and the constraints in which we operate, we can start designing the feature and what it may look like. Ideally, the design team would include browser engineers from interested vendors as well as problem space experts from the web developer or framework developer community.

  

Once we have an initial rough design, it might be a good idea to start building and committing  code (behind a flag and turned off by default) in order to better understand the solution’s feasibility and complexity.

  

That’s when engineers should send out an “Intent to Prototype” email to [blink-dev](https://groups.google.com/a/chromium.org/forum/#!forum/blink-dev) (previously, “Intent to Implement”), in order to notify the relevant code owners that work is underway in that area. Note that such an intent doesn’t mean that the feature is shipping soon, or that it will ship at all for that matter. It just means that this is a problem space that’s being explored, and code is landing to that end.

  

That’s also a good point in time to make sure the feature will get a wider review, by filing for a [TAG review](https://github.com/w3ctag/design-reviews).

### Step 3 - Experiment & iterate

Once code starts to land behind a flag, it’s a good time for interested web developers to start playing around with the solution by turning on the feature flag and testing it out.

Feedback on the initial implementation is critical in order to make sure the eventual design would work well for developers and users alike.

For some features, such experimentation is enough for developers to get a good handle on what’s the solution looks like, and how well it addresses the problem.

  

In other cases, it’s critical to gather data from the field regarding the solution, to see how well it works in broader deployment to fulfill user’s needs, or get a better understanding of its performance characteristics at scale.

#### Step 3.5 - Origin Trial

In those cases, a browser engineer can request an [Origin Trial](https://github.com/GoogleChrome/OriginTrials) (by sending out an Intent to Experiment email), which enables interested developers to test the feature out in broader deployment to users who have not turned on the feature flag. Once an Origin Trial is in place, developers can register for the trial, and enable the feature (in production) for their domains. That enables them to gather data on the user impact of the feature, and report it back to the design team, confirming or refuting their assumptions regarding the solution’s viability.

  

Note that an Origin Trial is a temporary experiment, and there’s a good chance that the feature will significantly change before it will be enabled by default, or even that the effort will be dropped altogether. Developers interested in participating should take that into account, and not rely on the feature being available to their users beyond the scope of the trial.

### Step 4 - ship it!

Once the previous steps were completed with success and the team believes the feature is ready to be turned on by default, that’s when they can submit an Intent to Ship.

  

That’s a part of the process that’s [a bit more strict](https://www.chromium.org/blink#TOC-Policy-for-shipping-and-removing-web-platform-API-features).

  

In order to ship a feature by default, engineers need approval for the feature to ship from 3 API owners.

  

---

What’s an “API owner”?  

[API owners](https://www.chromium.org/blink#TOC-API-Owners) are a set of trusted Chromium engineers, who are responsible for enforcing the Blink process guiding principles. Each feature we’re trying to ship has some user and developer benefits, otherwise we probably wouldn’t be working on it. Shipping new features can introduce interoperability risks, if other browsers don’t follow us. The API owners are tasked with applying our [compatibility](https://docs.google.com/document/d/1RC-pBBvsazYfCNNUSkPqAVpSpNJ96U8trhNkfV0v9fk/edit#heading=h.83o2xr8ayal6) and [interoperability](https://docs.google.com/document/d/1romO1kHzpcwTwPsCzrkNWlh0bBXBwHfUsCt98-CNzkY/edit#heading=h.mxgkfxtgzxqs) principles and help evaluate each shipping feature with regards to its risk/benefit tradeoff. They then provide their approval on “Intent to Ship” threads for new shipping features, if they think the benefits outweigh the risks. Those approvals are provided in the form of “LGTM” (“Looks Good To Me”) replies on intent threads.

  

Note that LGTMs are not required for Intent to Prototype. For an Intent to Experiment, approval from a single API owner is sufficient, as the risk they pose is fairly contained.

  

---

  
As part of the “Intent to Ship” request, chromium engineers need to provide clear signals regarding the risk and benefit tradeoff of the feature.  
  

* The feature needs to have a solid specification and a comprehensive cross-browser test suite in order to minimize interoperability risk.
* Signals from other browser vendors as well as from wide review forums (such as the TAG) are taken into account, alongside signals from the web developer community and partners who are planning to use the feature.
* If the feature went through an Origin Trial, a report outlining the results is also important to better understand the benefits.

  

Note that the fact that an “intent to ship” is sent indicates the team’s estimate of the feature being ready to ship, but it does not necessarily mean that the feature will ship shortly, or at all.

  

Some features take a long time to go through the intent process, in order to prove that the risk they pose is low enough to justify shipping. Others get held up addressing feedback from other vendors or from wide-review forums.

  

In other (rare) cases, features can be rejected by the API owners, and their proponents then need to look for alternative ways to resolve the problem, which won’t hit the same concerns that got their initial intent rejected.

### Removing features

Finally, while adding new feature certainly grabs most people’s attention, an equally important part of the intent process is to deprecate and remove legacy web platform features. In those cases, the main risk is breaking existing content, and the benefits are typically around improving user’s security, privacy and performance. The project’s willingness to take some compatibility risk and remove features is critical to our risk/benefit calculus also when launching features first - if we got it wrong and late feedback causes us to change course, we typically can figure out a path to deprecate those features to get us back on track to interoperability.

Summary
-------

The Chromium’s project goal is to make sure the web platform remains a healthy and successful platform.

For that, we believe the platform needs to make significant progress in the face of shifting developer and user expectations, as well as adapt to the changing market forces and constraints. At the same time, we need that progress to be done in a responsible manner both inside the Chromium project and when it comes to our collaboration with the wider ecosystem.

  

The Blink process’ role is to keep the balance between those different requirements, and to help ensure the web is a thriving platform for generations to come.

  
  
  
  

Posted by Yoav Weiss, Wrangler of processes and Advocate of developers.