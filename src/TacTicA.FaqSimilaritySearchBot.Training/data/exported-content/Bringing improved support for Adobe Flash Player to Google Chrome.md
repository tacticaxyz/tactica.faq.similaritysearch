URL:https://blog.chromium.org/2010/03/bringing-improved-support-for-adobe.html
# Bringing improved support for Adobe Flash Player to Google Chrome
- **Published**: 2010-03-30T10:00:00.000-07:00
Adobe Flash Player is the most [widely used](http://www.adobe.com/products/player_census/flashplayer/version_penetration.html) web browser plug-in. It enables a wide range of applications and content on the Internet, from games, to video, to enterprise apps.  
  
The traditional browser plug-in model has enabled tremendous innovation on the web, but it also presents challenges for both plug-ins and browsers. The browser plug-in interface is loosely specified, limited in capability and varies across browsers and operating systems. This can lead to incompatibilities, reduction in performance and some security headaches.  
  
That’s why we are working with Adobe, Mozilla and the broader community to help define the [next generation browser plug-in API](https://wiki.mozilla.org/Plugins:PlatformIndependentNPAPI). This new API aims to address the shortcomings of the current browser plug-in model. There is much to do and we’re eager to get started.  
  
As a first step, we’ve begun collaborating with Adobe to improve the Flash Player experience in Google Chrome. Today, we’re [making available](http://googlechromereleases.blogspot.com/2010/03/dev-channel-update_30.html) an initial integration of Flash Player with Chrome in the developer channel. We plan to bring this functionality to all Chrome users as quickly as we can.  
  
We believe this initiative will help our users in the following ways:  

  
* When users download Chrome, they will also receive the latest version of Adobe Flash Player. There will be no need to install Flash Player separately.
  
* Users will automatically receive updates related to Flash Player using Google Chrome’s auto-update mechanism. This eliminates the need to manually download separate updates and [reduces the security risk](http://www.techzoom.net/publications/insecurity-iceberg/) of using outdated versions.
  
* With Adobe's help, we plan to further protect users by extending Chrome's “[sandbox](http://seclab.stanford.edu/websec/chromium/)” to web pages with Flash content.

  
Improving the traditional browser plug-in model will make it possible for plug-ins to be just as fast, stable, and secure as the browser’s HTML and JavaScript engines. Over time this will enable HTML, Flash, and other plug-ins to be used together more seamlessly in rendering and scripting.  
  
These improvements will encourage innovation in both the HTML and plug-in landscapes, improving the web experience for users and developers alike. To read more about this effort, you can read this [post](http://blogs.adobe.com/flashplayer/2010/03/improved_flash_player_support.html) on the Flash Player blog.  
  
Developers can download the Chrome developer channel version with Flash built in [here](http://dev.chromium.org/getting-involved/dev-channel). To enable the built-in version of Flash, run Chrome with the --enable-internal-flash command line flag.   
  
Posted by Linus Upson, VP, Engineering