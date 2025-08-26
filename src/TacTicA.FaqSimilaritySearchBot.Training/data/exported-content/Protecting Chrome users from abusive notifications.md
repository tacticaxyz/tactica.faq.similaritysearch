URL:https://blog.chromium.org/2020/05/protecting-chrome-users-from-abusive.html
# Protecting Chrome users from abusive notifications
- **Published**: 2020-05-28T11:04:00.001-07:00
Notifications on the web help users receive important updates for a wide range of applications including messaging, calendars, email clients, ride sharing, social media and delivery services.

  

Unfortunately, browser notifications can be used to mislead users, phish for private information or promote malware. These abusive patterns fall into two broad categories, “permission request issues" and "notification issues."

  

Permission request issues are requests designed to mislead, trick, or force users into allowing notifications. One example of this is websites that require users to allow notifications in order to gain access to site content or that are preceded by misleading pre-prompts.

  

Notification issues include fake messages that resemble chat messages, warnings, or system dialogs. They also include phishing attacks, an abusive tactic that tries to steal or trick users into sharing personal information, and malware notifications that promote or link to malicious software.

  

To learn more about abusive notifications, you can consult the complete [list](https://support.google.com/webtools/answer/9799829) of abusive notifications identified by the Abusive Notifications Report in Search Console, described below in the ["How do I know if my site has failed the abusive notifications check?"](https://blog.chromium.org/feeds/posts/default?start-index=1&max-results=500#how-do-i-know) section.

  

Starting with Chrome 84, releasing to stable on July 14 2020, sites with abusive permission requests or abusive notifications will be automatically enrolled in [quieter notifications UI](https://blog.chromium.org/2020/01/introducing-quieter-permission-ui-for.html) and notification enrollment prompts will advise users that the site may be trying to trick them.  These changes are described in more detail below.

Why are you doing this?
=======================

Abusive notification prompts are one of the top user complaints we receive about Chrome. A large percentage of notification requests and notifications come from a small number of abusive sites. Protecting users from these sites improves user safety & privacy on the web, and makes for a better browsing experience.

  

Only a small fraction of websites will be affected by this change but we expect the impact on notification volumes will be significant for some users.

Notification UI changes for Chrome 84
=====================================

Abusive notification protection in Chrome 84 will only affect new notification permission requests from abusive sites.  In the future, we may add protections for users who have already accepted notification permissions from abusive sites.

  

![](https://lh6.googleusercontent.com/pM2hu9foX9242Vc4AOuz_ntSYy50F_Lb_61o7-s-cCGT4l8sS08fO40JHdKM-6q0afoRqZmOE1dXwJI5kPNs-kwB_KJPosvLLqklNQN4yren24JCG67MwY926uM4IU7vuqV4JqeU)

Desktop UI for quiet notifications UI on abusive websites. The new UI discourages users from allowing notifications from these websites.

  

![](https://lh6.googleusercontent.com/-V34dzGIXBXQPetND-Q-Ohj5Z8MrrpLvFq1ahdoJriV1sag-g4vhbhPB4_zTknGdNC4iuTxpFlln9jxzHss09BWK-uWE0YREyimv4B_jGOlDkYgiEmERBT5sJ13g65dD2vj-_Hbo)

Mobile UI for quiet notifications on abusive websites.  The new UI discourages users from allowing notifications from these websites.


  

How do I know if my site has failed the abusive notification check?
-------------------------------------------------------------------

The [Abusive Notifications Report](https://www.google.com/webmasters/tools/abusive-notifications-unverified?pli=1) in Search Console informs site owners of abusive notification experiences on their site. The first time a site is found to be in “Failing” status, Search Console will send an email to registered site owners and users in Search Console at least 30 calendar days prior to the start of enforcement. Websites will have the opportunity during this time period to address the issue and re-submit their website for another review.

  

The Search Console help center has additional information on the [Abusive Notifications Report](https://support.google.com/webtools/answer/9798950) and the [abusive notification review process](https://support.google.com/webtools/answer/9799831).

What should I do if my website failed the abusive notification review?
----------------------------------------------------------------------

  

The Search Console help center has a [guide](https://support.google.com/webtools/answer/9799048) for how to fix abusive notifications and request a new review of your website.

Posted by PJ McLachlan, Web Platform PM