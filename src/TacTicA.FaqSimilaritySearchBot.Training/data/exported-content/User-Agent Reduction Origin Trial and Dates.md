URL:https://blog.chromium.org/2021/09/user-agent-reduction-origin-trial-and-dates.html
# User-Agent Reduction Origin Trial and Dates
- **Published**: 2021-09-14T06:26:00.001-07:00
Back in May, we published [an update on our User-Agent string reduction plans](https://blog.chromium.org/2021/05/update-on-user-agent-string-reduction.html) with a promise to publish further details on timing. Now that we have an [origin trial ready for testing](http://developers.chrome.com/blog/user-agent-reduction-origin-trial) the Reduced User-Agent header (and associated JS interfaces) we have estimated timelines to share. What follows is repeated from the original blog post, but contains estimated Chrome versions where these Phases will begin to help you prepare. 

  

The [Chromium schedule dashboard](https://chromiumdash.appspot.com/schedule) will be useful for understanding dates associated with each Chrome version and its progression from Canary into Beta and Stable Release.

  

Note: The usual disclaimers about estimating engineering deadlines apply—unforeseen circumstances may dictate delays. But in the case that we encounter delays, we do not intend to accelerate timelines between Phases.

  

### Proposed Rollout Plan

We plan to roll out these changes slowly and incrementally in 7 Phases—pending origin trial feedback.

  

#### Reduction Preparation

Phase 1: Since Chrome 92 (July 20, 2021)

Call to Action (CTA): Audit your site usage to understand where migration may be necessary.

  

Warn about accessing navigator.userAgent, navigator.appVersion, and navigator.platform in DevTools, beginning in M92.

  

Phase 2: Chrome 95 to Chrome 100

CTA: Enroll in the origin trial for your site, and provide feedback until Chrome 101 is released.

  

Launch an origin trial for sites to opt into the final reduced UA string for testing and feedback, for at least 6 months. 

  

We will evaluate feedback from origin trial partners and the community, and based on this feedback proceed to Phases 3 through 7 of our plan, giving the ecosystem adequate time to adapt in between them. Otherwise, depending on feedback we will reconsider the best course of action.

  

#### Reduction Rollout

Phase 3: Chrome 100

CTA: Enroll in the deprecation trial or Enterprise policy for your site, when needed.

  

Launch deprecation trial and Enterprise policy, for instances where a site may need more time for migration.

  

Phase 4: Chrome 101

CTA: Ensure your site is compatible with the reduced Chrome version number, and [migrate to UA Client Hints](https://web.dev/migrate-to-ua-ch/) if not.

  

Ship reduced Chrome MINOR.BUILD.PATCH version numbers (“0.0.0”). Once rolled-out, the reduced UA string would apply to all page loads on desktop and mobile operating systems for sites that do not opt into the deprecation trial.

  

Phase 5: Chrome 107

CTA: Ensure your site is compatible with the reduced Desktop UA string and related JS APIs, and [migrate to UA Client Hints](https://web.dev/migrate-to-ua-ch/) if not.

  

Begin roll-out of reduced Desktop UA string and related JS APIs (navigator.userAgent, navigator.appVersion, navigator.platform). Once rolled-out, the reduced UA string would apply to all page loads on desktop operating systems for sites that do not opt into the deprecation trial.

  

Phase 6: Chrome 110

CTA: Ensure your site is compatible with the reduced Mobile UA string and related JS APIs, and [migrate to UA Client Hints](https://web.dev/migrate-to-ua-ch/) if not.

  

Begin roll-out of reduced Android Mobile (and Tablet) UA string and related JS APIs. Once rolled-out, the reduced UA string would apply to all page loads on Android that do not opt into the deprecation trial.

  

#### Reduction Completion

Phase 7: Chrome 113

  

Deprecation trial ends and all page loads receive the reduced UA string and related JS APIs.

  

See the companion [Reduced User Agent string updates page](https://www.chromium.org/updates/ua-reduction) for more details and example User Agent strings at each of these phases. We will note any significant delays or changes on this page as well.

Posted by Mike Taylor and Jade Kessler, Chrome Team