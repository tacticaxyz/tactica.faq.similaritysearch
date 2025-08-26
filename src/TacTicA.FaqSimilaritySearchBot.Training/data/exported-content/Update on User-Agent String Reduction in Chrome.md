URL:https://blog.chromium.org/2021/05/update-on-user-agent-string-reduction.html
# Update on User-Agent String Reduction in Chrome
- **Published**: 2021-05-19T04:00:00.001-07:00
**Updates**

* **September 14, 2021**: [Updated timeline and origin trial announced](https://blog.chromium.org/2021/09/user-agent-reduction-origin-trial-and-dates.html).

A little over a year ago [we announced our plans](https://groups.google.com/a/chromium.org/g/blink-dev/c/-2JIRNMWJ7s/m/yHe4tQNLCgAJ) to reduce the granularity of information available from the [User-Agent string](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent), which is sent by default for every HTTP request. [Shortly after](https://groups.google.com/a/chromium.org/g/blink-dev/c/-2JIRNMWJ7s/m/u-YzXjZ8BAAJ), we made the decision to put this effort on pause so as not to create an additional migration burden on the web ecosystem in the early days of the COVID-19 pandemic. Since then, we’ve spent a lot of time gathering valuable feedback from the ecosystem, [proposing ergonomic improvements](https://groups.google.com/a/chromium.org/g/blink-dev/c/dafizBGwWMw) to the [User-Agent Client Hints API](https://web.dev/user-agent-client-hints/) (UA-CH)—our proposed replacement for content negotiation and detection—as well as [making web compatibility fixes](https://bugs.chromium.org/p/chromium/issues/detail?id=1149575#c2).

UA-CH is now shipping by default in Chrome (since M89). We’ve also started the roll-out of both Client Hints Reliability mechanisms ([Critical-CH](https://chromestatus.com/feature/5727177800679424) & [ACCEPT\_CH](https://chromestatus.com/feature/5555544540577792)) to address use cases where hints are needed on the first request. While we don’t yet have exact dates and milestones to announce for the planned User-Agent string reduction changes, we’re ready to resume our efforts on this front.

That said, we feel it's important to proceed in a way that gives the ecosystem and developers sufficient time to test use cases, provide feedback, and [migrate to UA-CH where appropriate](https://web.dev/migrate-to-ua-ch), which is why *no User-Agent string changes will be coming to the stable channel of Chrome in 2021*. Our intent with this post is to provide transparency into our thinking and roadmap early on so you can plan to adapt accordingly.

What is changing, and how?
--------------------------

We plan to gradually reduce, [in a phased manner](https://www.chromium.org/updates/ua-reduction), the granularity of available information in the User-Agent header field, as well as the navigator.userAgent, navigator.appVersion, and navigator.platform JS APIs.

Once this is complete, you will still be able to reliably get the **browser major version**, **platform name**, and distinguish **between desktop and mobile** (or tablet), solely from the User-Agent string. For more advanced use cases, you should migrate to the [User Agent Client Hints API](https://web.dev/user-agent-client-hints/).

Note: We have no plans to change the User-Agent string on Android WebView or Chrome for iOS at this time, but will make public updates if and when that changes.

Our current high-level plan is as follows:

* Beginning in M92, we plan to start sending deprecation notices for the navigator.userAgent, navigator.appVersion, and navigator.platform getters in the [DevTools Issues tab](https://developer.chrome.com/docs/devtools/issues/).
* In the coming weeks, we will announce an Origin Trial for sites to opt in to receiving the fully reduced User-Agent. We expect to run the Origin Trial for at least 6 months to provide enough time for sites to opt in, test, and provide feedback on the feasibility and compatibility of our desired end state.
* We will evaluate feedback from Origin Trial partners and the community, and based on this feedback proceed to Phases 3 through 7 of our plan (see next section for details), giving the ecosystem adequate time to adapt in between them. Otherwise, depending on feedback we will reconsider the best course of action.
* For sites with complex use cases that require more time for migration, we aim to offer the ability to extend the current User-Agent behavior for at least an additional 6 months (through a "reverse Origin Trial").

Proposed rollout plan
---------------------

We plan to roll out these changes slowly and incrementally in 7 Phases—pending Origin Trial feedback—and plan to publish an update soon on the proposed timing and milestones beyond Phase 1.

### Reduction Preparation

**Phase 1:** Warn about accessing navigator.userAgent, navigator.appVersion, and navigator.platform in DevTools, beginning in M92.

**Phase 2:** Launch an Origin Trial for sites to opt into the final reduced UA string for testing and feedback, for at least 6 months.

### Reduction Rollout

**Phase 3:** Launch a reverse Origin Trial, for instances where a site may need more time for migration, for at least 6 months.

**Phase 4:** Ship reduced Chrome MINOR.BUILD.PATCH version numbers (“0.0.0”). Once rolled-out, the reduced UA string would apply to all page loads on desktop and mobile OSes that do not opt into the reverse Origin Trial.

**Phase 5:** Begin roll-out of reduced Desktop UA string and related JS APIs (navigator.userAgent, navigator.appVersion, navigator.platform). Once rolled-out, the reduced UA string would apply to all page loads on desktop OSes that do not opt into the reverse Origin Trial.

**Phase 6:** Begin roll-out of reduced Android Mobile (and Tablet) UA string and related JS APIs. Once rolled-out, the reduced UA string would apply to all page loads on Android that do not opt into the reverse Origin Trial.

### Reduction Completion

**Phase 7:** reverse Origin Trial ends and all page loads receive the reduced UA string and related JS APIs.

See the companion [Reduced User Agent string updates page](http://chromium.org/updates/ua-reduction) for more details and example User Agent strings at each of these phases.

What do I need to do to get ready as a developer?
-------------------------------------------------

Our plan was designed with backwards compatibility in mind, and while any changes to the User Agent string need to be managed carefully, we expect minimal friction for developers as we roll this out (i.e., existing parsers should continue to operate as expected).

If your site, service, library or application relies on certain bits of information being present in the User Agent string such as **Chrome minor version**, **OS version number**, or **Android device model**, you will need to begin the migration to use the [User Agent Client Hints API](https://web.dev/user-agent-client-hints/) instead.

If you don’t require any of these, then no changes are required and things should continue to operate as they have to date.

Why are we doing this?
----------------------

As noted in the [User Agent Client Hints explainer](https://github.com/WICG/ua-client-hints#explainer-reducing-user-agent-granularity), the User Agent string presents challenges for two reasons. Firstly, it [passively exposes](https://w3c.github.io/fingerprinting-guidance/#passive) quite a lot of information about the browser for every HTTP request that [may be used for fingerprinting](https://www.w3.org/2001/tag/doc/unsanctioned-tracking/#unsanctioned-tracking-tracking-without-user-control). Secondly, it has grown in length and complexity over the years and encourages error-prone string parsing. We believe the [User Agent Client Hints API](https://wicg.github.io/ua-client-hints/) solves both of these problems in a more developer- and user-friendly manner.

What about other browsers?
--------------------------

In some ways Chrome is playing catch up on this front: Safari was the first to [cap the macOS version number](https://bugs.webkit.org/show_bug.cgi?id=216593) in the UA string and [Firefox has followed suit](https://bugzilla.mozilla.org/show_bug.cgi?id=1679929). Firefox has also [capped the Windows version number to 10.](https://bugzilla.mozilla.org/show_bug.cgi?id=1693295)

Learn More
----------

* [Improving user privacy and developer experience with User-Agent Client Hints](https://web.dev/user-agent-client-hints/)
* [Migrate to UA-CH](https://web.dev/migrate-to-ua-ch)

Posted by Mike Taylor and Jade Kessler, Chrome Team