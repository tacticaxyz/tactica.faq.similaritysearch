URL:https://blog.chromium.org/2010/05/desktop-notifications-now-available-to.html
# Desktop Notifications: Now available to extensions in Chrome
- **Published**: 2010-05-28T11:54:00.001-07:00
Many Chrome extensions use [browser actions](http://code.google.com/chrome/extensions/browserAction.html) as a notification area. Notifications can be very valuable to users, but there’s only so much a developer can do with an icon’s worth of pixels.  
  
As it turns out, web sites have a great way to deliver non-modal message like these with the notifications API, which was first introduced in Chrome 4 for Windows.

[![](http://4.bp.blogspot.com/_-MC69KJzn6Y/TAASN-NeKiI/AAAAAAAAAAU/R-h8meZ-mzA/s320/Untitled1.png)](http://4.bp.blogspot.com/_-MC69KJzn6Y/TAASN-NeKiI/AAAAAAAAAAU/R-h8meZ-mzA/s1600/Untitled1.png)  

*The [Gmail Notifier](https://chrome.google.com/extensions/detail/kkmbodalobogbnejmcdghkfimhodifol) extension was an early adopter of notifications.*  
  
As of [Chrome 5](http://chrome.blogspot.com/2010/05/new-chrome-stable-release-welcome-mac.html), we’re happy to announce that notifications are also available to extension developers.  
  
When notifications are used from an extension, there are no permission prompts or infobar warnings. The experience is seamless - it just works.  
  
To learn how to use the notifications API in your extension, review our [documentation](http://code.google.com/chrome/extensions/notifications.html). We’ll be on the lookout for some great examples of desktop notifications to feature on the [Chrome Extensions Gallery](http://chrome.google.com/extensions), so get cracking!  
  
Posted by Aaron Boodman, Software Engineer