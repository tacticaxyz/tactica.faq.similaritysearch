URL:https://blog.chromium.org/2020/10/reducing-abusive-notification-content.html
# Reducing abusive notification content
- **Published**: 2020-10-21T09:33:00.000-07:00
Although notifications on the web are useful for a variety of applications, they can also be misused for phishing, malware or fake messages that imitate system notifications for the purpose of generating user interactions.  

  

In Chrome 86, we’ve expanded on previous efforts [[1](https://blog.chromium.org/2020/01/introducing-quieter-permission-ui-for.html)] [[2](https://blog.chromium.org/2020/05/protecting-chrome-users-from-abusive.html)] to improve the quality of the web notification ecosystem by adding enforcement for websites sending abusive notification content. This includes sites sending messages containing links to malware or that seek to spoof system administrative messages. 

  

When abusive notification content is detected on an origin, Chrome will automatically display the permission requests using a quieter UI, shown below.  

How is this different from previous abusive notification protections?
---------------------------------------------------------------------

Chrome 80 introduced the quiet Notification permission UI. Chrome 84 announced auto-enrolment in quiet notification UI for websites with abusive notification permission requests, such as sites that use deceptive patterns to request notification permission. 

  

The new enforcement in Chrome 86 focuses on notification content and is triggered by sites that have a history of sending messages containing abusive content. This treatment applies to sites that try to trick users into accepting the notification permission for malicious purposes, for example sites that use web notifications to send malware or to mimic system messages to obtain user login credentials.  

What does it look like?
-----------------------

  

![](https://lh4.googleusercontent.com/TQ10szluPdXsKoYIeYe5ljxjVIoJzcCvLybUa3tEA24a6vISYkwiqAz9VymzgyNY_N8tfqHKvxSv9WhrcC-GvDc4uaiCE1T52y3C6xK1K--Lazicm9PSBiGxGVCyjFtDTBJaEOuExA)

Desktop UI for quiet notifications UI on abusive websites. The new UI discourages users from allowing notifications from these websites.  

  
  

![](https://lh4.googleusercontent.com/ZlyxAU84FOdJ_buyRJv4_Hao7YKG217MGd6T3R4TLwyt2-s8AIQ_20LAFraE_75QoEjzd-mbwaUswI_sa3_iotIOp52Z1shXS76jAJQvPMUApOwa9Yby8DI3OEoMiEvM4JntQMrUXA)

Mobile UI for quiet notifications on abusive websites.  The new UI discourages users from allowing notifications from these websites.  

  

This UI exactly matches the UI that was previously announced for Chrome 84. The only difference is in Chrome 86 we will begin blocking notification permission requests when sites have a pattern of sending abusive notification content.  

Why are we doing this?
----------------------

Abusive notification prompts are one of the top user complaints we receive about Chrome. Our goal with these changes is to improve the experience for Chrome users and to reduce the incentive for abusive sites to misuse the web notifications feature.  

How will Chrome detect sites sending abusive notification content?
------------------------------------------------------------------

Google’s automated web crawling service will occasionally subscribe to website push notifications if the push permission is requested. Notifications that are sent to the automated Chrome instances, using Safe Browsing technology, will be evaluated for abusive content, and sites sending abusive notifications will be flagged for enforcement if the issue is unresolved. 

What happens if abusive notifications are detected from my website?
-------------------------------------------------------------------

When a site is found to be in “Failing” status for any type of notification abuse, Search Console will send an email to registered site owners and users in the site's Search Console at least 30 calendar days prior to the start of enforcement. During the 30 day grace period websites can address the issue and request another review.  

  

We recommend concerned site owners and developers review the [Abusive Notifications Report](https://www.google.com/webmasters/tools/abusive-notifications-unverified?pli=1) in Search Console. The Search Console help center has additional information on the [Abusive Notifications Report](https://support.google.com/webtools/answer/9798950) and the [abusive notification review process](https://support.google.com/webtools/answer/9799831).

What should I do if my website failed the abusive notification review?
----------------------------------------------------------------------

The Search Console help center has a [guide](https://support.google.com/webtools/answer/9799048) for how to fix abusive notifications and request another review of your website.  

Are any further abusive notification protections planned?
---------------------------------------------------------

Prior to the release of Chrome’s abusive notifications protections, many users have already unintentionally allowed notifications from websites engaging in abusive activity.  In an upcoming release, Chrome will revert the notification permission status from “granted” to “default” for abusive origins, preventing further notifications unless the user returns to the abusive origin and re-enables notifications.  

  

We’ll be listening for feedback from users and developers about the effectiveness of current enforcements and may make further changes based on that feedback.

Posted by PJ McLachlan, Product Manager