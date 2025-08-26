URL:https://blog.chromium.org/2020/02/samesite-cookie-changes-in-february.html
# SameSite Cookie Changes in February 2020: What You Need to Know
- **Published**: 2020-02-03T15:11:00.000-08:00
With the stable release of Chrome 80 this month, Chrome will begin enforcing a new secure-by-default cookie classification system, treating cookies that have no declared SameSite value as  SameSite=Lax cookies. Only cookies set as SameSite=None; Secure will be available in third-party contexts, provided they are being accessed from secure connections.  
  
Chrome first [announced](https://blog.chromium.org/2019/05/improving-privacy-and-security-on-web.html) this change and published [developer guidance](https://web.dev/samesite-cookies-explained/) in May 2019, following up with a [reminder](https://blog.chromium.org/2019/10/developers-get-ready-for-new.html) and additional context in October 2019.  As the rollout approaches, please review the video and information below to make sure you’re ready and know what to expect.  
  
  
  
  
Launch Timing:The stable release of Chrome 80 is scheduled to begin on February 4. Enforcement of the new cookie classification system in Chrome 80 will begin later in February with a small population of users, gradually increasing over time. To get the latest information about the rollout timing and process,  monitor the [SameSite Updates page](https://www.chromium.org/updates/same-site). To see if your browser has been updated, you can visit [this page](https://samesite-sandbox.glitch.me/); if all the rows are green then your browser is applying the new defaults.  
  
  
Developer Tools Console Warnings: The Developer Tools console provides warnings when a page contains cross-site cookies that are missing the required settings.  If you see these warnings while viewing your site in Developer Tools, that could mean cookies which support features on your site are not properly configured. Here is a Developer Tools warning in Chrome 80; earlier versions of Chrome (77+) provide a similar one:  
  

|  |
| --- |
|  |
|  |

An exception is the case where a service issues a pair of redundant cookies: One cookie with the new settings, and one cookie with the legacy settings for incompatible clients. In that case, you may see a warning triggered by the legacy cookie even though the service is working as intended. This approach is described [here](https://web.dev/samesite-cookie-recipes/#handling-incompatible-clients).

  
  
Google Cookies:Some Google services will use the approach described above, issuing a cookie with the new settings and a cookie with legacy settings. For this reason, you might see the Developer Tools console warning for Google cookies even though the Google service is working as intended.  
  
  
Temporary Transition Effects**:** If a cross-site cookie provider updates its cookies immediately before the Chrome 80 release, some known or returning users with Chrome 80 may temporarily appear as unknown or new users until their cookies are refreshed with the new settings. Providers who updated their cookies farther in advance are less likely to notice an impact because their users had a longer window of time to pick up cookies with the new settings.  
  
  
Temporary Mitigation for Sign-On Flows:To help avoid broken user sign-on experiences when cookies are passed between websites and third-party providers during the authentication process, Chrome introduced a temporary mitigation known as “Lax + POST” so that, within a two-minute window, cookies without specified SameSite settings can be available for the type of top-level cross-site POST request typically used in sign-on flows. (This does not change behavior for top-level cross-site GET requests, which will attach “Lax” but not “Strict” SameSite cookies.) This mitigation is described in the [Chromium tracker](https://www.chromestatus.com/feature/5088147346030592) for the new model. If you use or provide third party sign-on services we strongly recommend testing your sign-on flow immediately.  
  
  
Enterprise Policies: Enterprise administrators may need to implement [special policies](https://www.chromium.org/administrators/policy-list-3/cookie-legacy-samesite-policies) to temporarily revert Chrome Browser to legacy behavior if some services such as sign-on or internal applications are not ready for the Chrome 80 changes.  
  
  
Testing and Troubleshooting: To see how a site or service will behave under the new model, we strongly recommend testing in Chrome 76+ with the “SameSite by default cookies” and “Cookies without SameSite must be secure” experimental flags enabled.  (To enable flags to go chrome://flags.)  Since the new model will roll out to Chrome 80 gradually, when testing, you should also enable the flags in Chrome 80 to make sure your browser reflects the new default settings.  
  
  
You can also test whether any unexpected behavior you’re experiencing in Chrome 80 is attributable to the new model by disabling the “SameSite by default cookies” and “Cookies without SameSite must be secure” flags.  If the issue persists with the flags disabled, then the cookie changes are probably not the cause of the issue.  You can find more testing and debugging tips [here](https://www.chromium.org/updates/same-site/test-debug).  
  
More Resources:  
  

* [SameSite Updates](https://www.chromium.org/updates/same-site)
* [SameSite FAQs (Including Lax + POST mitigation)](https://www.chromium.org/updates/same-site/faq)
* [web.dev: SameSite Cookies Explained](https://web.dev/samesite-cookies-explained/)
* [web.dev: SameSite Cookie Recipes](https://web.dev/samesite-cookie-recipes/)
* [Tips for Testing and Debugging](https://www.chromium.org/updates/same-site/test-debug)
* [Known incompatible clients](https://www.chromium.org/updates/same-site/incompatible-clients) and [Handling incompatible clients](https://web.dev/samesite-cookie-recipes/#handling-incompatible-clients)
* [Guidance for enterprise administrators](https://www.chromium.org/administrators/policy-list-3/cookie-legacy-samesite-policies)
* [Guidance for languages, libraries and frameworks](https://github.com/GoogleChromeLabs/samesite-examples)
* [Guidance for AMP publishers](https://blog.amp.dev/2020/01/27/cookie-classification-on-amp/)
* [Post a question on Stack Overflow](https://stackoverflow.com/questions/tagged/samesite)
* [Chromium tracker for Cookies default to SameSite=Lax](https://chromestatus.com/feature/5088147346030592)
* [Chromium tracker for Reject insecure SameSite=None cookies](https://www.chromestatus.com/feature/5633521622188032)

  

Posted by Barb Smith, Chrome and Web Platform Partnerships