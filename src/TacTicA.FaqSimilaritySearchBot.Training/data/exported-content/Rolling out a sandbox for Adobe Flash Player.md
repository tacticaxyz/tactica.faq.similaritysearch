URL:https://blog.chromium.org/2010/12/rolling-out-sandbox-for-adobe-flash.html
# Rolling out a sandbox for Adobe Flash Player
- **Published**: 2010-12-01T09:00:00.000-08:00
Since this past [March](http://blog.chromium.org/2010/03/bringing-improved-support-for-adobe.html), we’ve been working closely with Adobe to allow Flash Player to take advantage of new sandboxing technology in Chrome, extending the [work we’ve already done](http://blog.chromium.org/2008/10/new-approach-to-browser-security-google.html) with sandboxing for HTML rendering and JavaScript execution. This week, we’re excited to roll out the initial Flash Player sandbox for our dev channel users on Windows XP, Vista and 7.  
  
This initial Flash Player sandbox is an important milestone in making Chrome even safer. In particular, users of Windows XP will see a major security benefit, as Chrome is currently the only browser on the XP platform that runs Flash Player in a sandbox. This first iteration of Chrome’s Flash Player sandbox for all Windows platforms uses a modified version of Chrome’s existing sandbox technology that protects certain sensitive resources from being accessed by malicious code, while allowing applications to use less sensitive ones. This implementation is a significant first step in further reducing the potential attack surface of the browser and protecting users against common malware.   
  
While we’ve laid a tremendous amount of groundwork in this initial sandbox, there’s still more work to be done. We’re working to improve protection against additional attack vectors, and will be using this initial effort to provide fully sandboxed implementations of the Flash Player on all platforms.   
  
We’ll be posting updates as we continue working with Adobe to add new security improvements to the Flash Player sandbox. For those of you on the dev channel for Windows, you’ll be automatically updated soon, and we look forward to your feedback as you test it out. If you prefer to disable this initial sandbox in your Chrome dev experience, add --disable-flash-sandbox to the command line.  
  
Posted by Justin Schuh and Carlos Pizano, Software Engineers