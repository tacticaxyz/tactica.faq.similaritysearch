URL:https://blog.chromium.org/2021/11/chrome-dev-summit-2021-moving-toward.html
# Chrome Dev Summit 2021: Moving toward a more powerful and private web
- **Published**: 2021-11-03T11:00:00.000-07:00
By Paul Kinlan,
Lead for Chrome Developer Relations

The big day is finally here. Today, at Chrome Dev Summit 2021 we shared some of the highlights of what we've been working on — the latest product updates, vision for the web's future and examples of best-in-class web experiences. Over the past year, we've also had a lot of feedback that you want to spend more time learning from and working with the Chrome team and other industry experts. I'm excited to share with you that [we've opened up a lot of spaces for 1:1 office hours, workshops and learning lounges](https://developer.chrome.com/devsummit/schedule/) to give you more opportunity to connect with the Chrome team.

It's been a busy year for us all and with the continued shift of people moving more of their lives online, it has been more important than ever for us to [continue investing in Web Compat](https://web.dev/compat2021-midyear/), and we've been amazed to see the [improvements in compatibility across the board](https://wpt.fyi/compat2021?feature=summary) that is helping to make it easier for you to build sites that work across all browsers for everyone who uses the web.

We've also got a number of important updates to core topics that are important to every developer:

* An update on how we're helping to shift the web towards more privacy-safe technologies and give you more visibility into that process.
* A showcase on how many major companies have bet on the web and brough advanced app-like experiences to anyone who can use a browser.
* An update on Core Web Vitals and some new tools that will make it easier for you to measure your sites.
* A dive into the "New Responsive" with highlights of new tools and capabilities for designers that make it easier than ever to build experiences your users love.

This post is an overview of the latest updates from this year's Chrome Dev Summit keynote.

  

Paving a Path Toward a More Secure Web
--------------------------------------

The [Privacy Sandbox](https://privacysandbox.com/) continues to be a cornerstone of our ongoing efforts to collaboratively build privacy-preserving technologies for a healthy web. Our [development timeline](https://privacysandbox.com/timeline/), which we'll update monthly, shares when developers and advertisers can expect these technologies to be ready for testing and scaled adoption.  
This timeline reflects three developmental phases for Privacy Sandbox proposals:

### 1) Discussion

Dozens of ideas for privacy-preserving technologies have been proposed by Chrome and others, for public discussion in forums such as the [W3C](https://www.w3.org/) and [GitHub](https://github.com/) . For example, more than 100 organizations are helping to refine [FLEDGE](https://developer.chrome.com/docs/privacy-sandbox/fledge/), a proposal for privacy-preserving remarketing.

### 2) Testing

Success at this stage depends on developers engaging in hands-on testing then sharing their learnings publicly. Yahoo! JAPAN's analysis of the [Attribution Reporting API](https://developer.chrome.com/docs/privacy-sandbox/attribution-reporting/) and Criteo's machine learning competition for evaluating privacy concepts are examples we're grateful for.

This kind of feedback is critical to getting solutions right. For instance, we're currently improving [FLoC](https://privacysandbox.com/proposals/floc) — a proposal for anonymized interest groups — with insights from companies such as CafeMedia.

### 3) Scaled Adoption

Some Privacy Sandbox proposals are already live, such as [User-Agent Client Hints](https://web.dev/user-agent-client-hints/) which are meant to replace the User-Agent (UA) string. We'll start to gradually reduce the granularity of information in the UA string in April 2022. We know implementing these changes take time, so companies will have the option to use the UA string as is through March 2023 via an origin trial.

Stepping up In-Browser Experiences
----------------------------------

With [Project Fugu](https://web.dev/fugu-status/), we've been introducing APIs that elevate web apps so they can do anything native apps can. We've also been inspired by brands building more immersive web experiences with [Progressive Web Apps](https://web.dev/progressive-web-apps/) (PWAs) and modern APIs.

Take Adobe, a brand we've been partnering with for more than three years. Photoshop, Creative Cloud Spaces, and Creative Cloud Canvas are now in Public Beta and [available in browsers](https://web.dev/ps-on-the-web/)—with more flagship apps to follow. This means creatives can view work, share feedback, and make basic edits without having to download or launch native apps.

PWAs have given online video and web conferencing platforms an upgrade too. TikTok found a way to reach video lovers across all devices while YouTube Premium gives people the ability to watch videos offline on laptops and hybrid devices.

Meet drastically improved the audio and video quality in their PWA, and Kapwing focused on making it easy for users to edit videos collaboratively, anytime, anywhere. Zoom replaced their Chrome App with a PWA, and saw 16.9 million new users join web meetings, an increase of more than seven million users year over year.

Developers who want to learn more, or get started with Progressive Web Apps can check out our new [Learn PWA](https://web.dev/learn/pwa/) course on web.dev. Three modules were launched today, with many more coming.

Continuously Improving Your Web Experience
------------------------------------------

Measuring site performance is a key part of navigating browsers as they evolve, which is where [Core Web Vitals](https://web.dev/vitals/) come in. Compared to a year ago, 20% more page visits in Chrome and 60% of the total visits in Chrome fully meet the recommended Core Web Vitals thresholds.

Content management systems, website builders, e-commerce platforms, and JavaScript frameworks have helped push the Web Vitals initiative forward. As we shared in our [Core Web Vitals Technology Report](https://datastudio.google.com/reporting/55bc8fad-44c2-4280-aa0b-5f3f0cd3d2be/page/M6ZPC), sites built on many of these platforms are hitting Core Web Vitals out of the park:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiQ0_q90gAmJYGi77SiWEYIbJ4bdMBSsXBJEcMzKCEPMlM9eXrhq5qaUvPFKUKPe68tKR9ocEssLcS9oEoMb1bTYtebSvX2K-uaRZ9OSiu1qW09aKxFwVDO4gGi1cJFod737EmVIQN0KAnQ/w640-h394/copyofchrome-c--jg970ov54vc.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiQ0_q90gAmJYGi77SiWEYIbJ4bdMBSsXBJEcMzKCEPMlM9eXrhq5qaUvPFKUKPe68tKR9ocEssLcS9oEoMb1bTYtebSvX2K-uaRZ9OSiu1qW09aKxFwVDO4gGi1cJFod737EmVIQN0KAnQ/s1424/copyofchrome-c--jg970ov54vc.png)

While this kind of progress is exciting, optimizing for Core Web Vitals can still be challenging. That's why we've been improving our tools to help developers better monitor, measure, and understand site performance. Some of these changes include:

* Updates in [PageSpeed Insights](https://web.dev/whats-new-pagespeed-insights) which make the distinction between "field data" from user experiences and "lab data" from the Lighthouse report more clear.

* Capabilities in [Lighthouse](https://developers.google.com/web/tools/lighthouse) to audit a complete [user flow](https://web.dev/lighthouse-user-flows/) by loading additional pages and simulating scrolls and link clicks.

* Support for user flows, such as a checkout flow, in [DevTools](https://developer.chrome.com/docs/devtools/) with a new [Recorder panel](https://goo.gle/devtools-recorder) for exporting a recorded user journey to Puppeteer script.

We're also experimenting with two new performance metrics: overall input responsiveness and scrolling and animation smoothness. We'd love to get your feedback, so take a spin through at [web.dev/responsiveness](https://web.dev/responsiveness) and [web.dev/smoothness](https://web.dev/smoothness).

Expanding the Toolbox for Digital Interfaces
--------------------------------------------

We've got developers and designers covered with tons of changes coming down the pipeline for UI styling and DevTools, including updates to responsive design. Developers can now customize user experiences in a component-driven architecture model, and we're calling this The New Responsive:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhqx19JX1EmPbxbYruKsSePKJKqfstwtG07VL6G72gbwFpAzLdvetzZfVKhgTF8IaZ73QcYkSVjosyjCwHQfMpgM1-ojQZ5145hAdbbhfGlSdZ538ClrHG33fOwMqfpdCcJOIiRedzy0p-9/w640-h350/copyofchrome-c--q1umlaeb369.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhqx19JX1EmPbxbYruKsSePKJKqfstwtG07VL6G72gbwFpAzLdvetzZfVKhgTF8IaZ73QcYkSVjosyjCwHQfMpgM1-ojQZ5145hAdbbhfGlSdZ538ClrHG33fOwMqfpdCcJOIiRedzy0p-9/s1580/copyofchrome-c--q1umlaeb369.png)

  

With the new container queries spec—available for testing behind a flag in [Chrome Canary](https://www.google.com/chrome/canary/)—developers can access a parent element's width to make styling decisions for its children, nest container queries, and create named queries for easier access and organization.

This is a huge shift for component-based development, so we've been providing new DevTools for debugging, styling, and visualizing CSS layouts. To make creating interfaces even easier, we also launched a collection of [off-the-shelf UI patterns](https://web.dev/patterns/).

Developers who want to learn more can dive into free resources such as [Learn Responsive Design](https://web.dev/learn/design/) on web.dev—a collaboration with Clearleft's Jeremy Keith—and six new modules in our [Learn CSS](https://web.dev/learn/css/) course. There are also a few exciting CSS APIs in their first public working drafts, including:

* **Scroll-timeline** for animating an element as people scroll (available via the experimental web platform features flag in Chrome Canary).

* **Size-adjust property** for typography (available in Chromium and Firefox stable).

* **Accent-color** for giving form controls a theme color (available in Chromium and Firefox stable).

One feature we're really excited to build on is Dark Mode, especially because we found indications that dark themes use 11% less battery power than light themes for OLED screens. Stay tuned for a machine-learning-aided, auto-dark algorithm feature in an upcoming version of Chrome.

Buckling Down for the Road Ahead
--------------------------------

Part of what makes the web so special is that it's an open, decentralized ecosystem. We encourage everyone to make the most of this by getting involved in shaping the web's future in places such as:

* The [Chromium open-source project](https://www.chromium.org/)
* Standards bodies such as the [W3C](https://www.w3.org/) and [WHATWG](https://whatwg.org/)
* [web.dev](https://web.dev/) and our [@ChromiumDev](https://twitter.com/ChromiumDev?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor) Twitter account
* Workshops, group learning lounges, and one-on-one office hours we'll be hosting over the next month

We can't wait to see what the web looks like by next year's summit. Until then, check out our library of learning resources on the [Chrome Dev Summit site](https://developer.chrome.com/devsummit/courses-and-content/) and the [Chrome Developers YouTube channel](https://www.youtube.com/channel/UCnUYZLuoy1rq1aVMwx4aTzw), and sign up for the [web.dev newsletter](https://web.dev/newsletter/).