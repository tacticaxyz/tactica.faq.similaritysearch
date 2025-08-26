URL:https://blog.chromium.org/2020/06/improving-chromiums-browser.html
# Improving Chromium's browser compatibility in 2020
- **Published**: 2020-06-18T07:28:00.004-07:00
Last year, MDN ran the [2019 Web Developer Needs Assessment (DNA) survey](https://insights.developer.mozilla.org/). The DNA survey drew responses from over 28,000 developers from around the world, together contributing more than 10,000 hours of insights into what is and isn't working on the web today, and how the web needs to change to meet the needs of the developer community.

  

There were many needs expressed in the [survey results](https://mdn-web-dna.s3-us-west-2.amazonaws.com/MDN-Web-DNA-Report-2019.pdf), but one that stood out clearly was browser compatibility - the manner in which websites look or behave differently on different web browsers. It is clear that it is still painful to develop a website or web app that works reliably across browsers.

|  |
| --- |
|  |
| The div that looks different in every browser' ([credit Martijn Cuppens](https://twitter.com/Martijn_Cuppens/status/1015169981368225793)) - it still reproduces today! |

  

To help focus in on specific developer needs, MDN ran a follow-up survey in March 2020 - the MDN Browser Compatibility Survey. This survey, taken by over 3000 web developers and augmented by post-survey interviews, aimed to uncover the specific pain-points the web developer community is having with browser compatibility. Today I'd like to talk about our takeaways from the results, and what we - Google Chrome - are doing about them.

  

It is important to stress that these are just some early findings from the MDN Browser Compatibility survey and are focused on pain points developers have relating to Chrome.

Flexbox
-------

[Flexbox](https://web.dev/responsive-web-design-basics/#flexbox) is a powerful tool for layout on the web. It offers an ergonomic way to define layouts that will respond gracefully on different sized viewports. But this power isn't much good when it can't be relied on across browsers. Flexbox is one of our top priorities for browser compatibility across the web in 2020, and we've put heavy investment into it already.

  

The Chrome rendering team has been working on a rearchitecture of the Chromium flexbox implementation on top of our modern [LayoutNG layout engine](https://www.chromium.org/blink/layoutng). This work, which we plan to bring to Chrome 84, is expected to fix a number of Flexbox compatibility issues in Chromium.

  

We're also working towards bringing [flex-gap](https://crbug.com/762679) and [fieldset+flex](http://crbug.com/375693) support to Chromium this year. In fact, flex-gap will be available in Chrome 84 - try it out and [let us know](https://twitter.com/ChromiumDev) what you think.

Scrolling
---------

Getting scrolling right in one browser can be tricky. Getting scrolling right across multiple browsers can be painful (for example, it takes [an entire library](https://github.com/willmcpo/body-scroll-lock) to consistently lock body scrolling). We're still digging through the feedback on scrolling compatibility, but a few key areas have stood out so far:

  

* How virtual keyboards affect - or don't affect - viewport units in different browsers. (Note recent work from Microsoft Edge on a [VirtualKeyboard API](https://groups.google.com/a/chromium.org/d/msg/blink-dev/q80uCrMgiTM/nF3mo-7zBAAJ) that may help here.)
* A lack of consistency in input-related events, and the outcome of interacting with them (e.g. what happens when you preventDefault() a touchmove).
* Difficulty controlling how scrolling behaves across browsers (e.g. via scroll anchoring).

  

We plan to start here by investing more in understanding how we can effectively improve scrolling on the web. As part of that, we need to keep hearing from you. [Please continue to tell us about your scrolling compatibility pains](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#summing-up) - especially as they relate to Chrome.

Form controls
-------------

Forms are a very old part of the web, added before even CSS. Form controls were intended to mimic the look and feel of the native platform, but it's clear that they have failed to do so consistently and have also failed to keep up with the needs of modern web development. The compatibility survey turned up two general themes here: stylability and inconsistent behavior across browsers.

  

On styling form controls, the Microsoft Edge and Google Chrome teams recently finished [a year-long project to refresh and update the default form styles in Chromium-based browsers](https://blog.chromium.org/2020/03/updates-to-form-controls-and-focus.html). This much needed refresh modernizes the default look and brings improved accessibility and touch support. However it's clear that without more control over how form controls are styled, they still present a compatibility pain for web developers. We don't have anything to announce here today, but we will be continuing to look at form stylability during 2020.

|  |
| --- |
|  |
| Out with the old, in with the new; some of the form controls refresh that landed in Chrome 83. ([more in the blogpost](https://blog.chromium.org/2020/03/updates-to-form-controls-and-focus.html)). |

  

In terms of behavior, there appears to be a general concern that form control behaviors either aren't well specified or that those specifications aren't consistently followed by browsers. Some concrete examples of inconsistencies across browsers that we heard are support for certain <input> types, autofill behaviors, and content restoration behavior when navigating away from and back to pages that contain forms. Again we have nothing specific to announce yet, but will be looking at this area going forward.

CSS Grid
--------

Like Flexbox, [CSS Grid](https://web.dev/responsive-web-design-basics/#grid) is an important component of modern layout. Looking at the early survey results it seems like the story for CSS Grid support in Chromium is fairly good (we have our friends from [Igalia](https://www.igalia.com/) to thank for that!). There is one clear exception - Chromium still doesn't support [subgrid](https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Grid_Layout/Subgrid).

  

Hopefully it won't be an exception for much longer. It's still early days, but I'm excited to share that a team at Microsoft Edge are working on rearchitecting Chromium's Grid support to use the new LayoutNG engine - and as part of this are intending to add subgrid support! We're excited to see this feature land and want to express our appreciation to our partners at Microsoft, Igalia, and the many other Chromium contributors who have worked on CSS Grid support.

Launching features on the web
-----------------------------

Unlike many platforms, the web has multiple implementations. This has downsides but it is also one of the web's greatest strengths. It vastly widens the diversity of inputs into the web platform, and provides a guarding factor against architectural mistakes that can occur when one blurs a platform (the web) and an implementation (a single browser).

  

In Chrome we strongly believe in moving the web forward, and in shipping new features that bring benefits to users and developers. But it is clear from the MDN Browser Compatibility Survey that some developers have concerns about how this may impact compatibility. We aren't going to stop moving the web forward, but we are planning to be more rigorous in how we approach it and in how we communicate about compatibility.  Look out for more on this soon.

Summing up
----------

When it comes to browser compatibility, there are still too many missing features and edge-case bugs. But it doesn't have to be this way. Things can and will get better, if browser vendors can understand what is causing the most pain, and take action to address the causes. In Chrome we're doing our best to listen, and we're doing our best to address what we're hearing. We hope it helps, and we're looking forward to a more compatible 2021.

For all of the above, **please tell us if we're right or wrong**. [Tweet us](https://twitter.com/ChromiumDev), [file bugs](https://crbug.com) and star the issues that you think we should prioritize, fill in [this form](https://forms.gle/oa1h7xsJPobaodobA), take part in the next web survey you see. Your voice matters to us and is a major factor in determining what work we prioritize.

  

Posted by Stephen McGruer, Software Engineer, Chrome