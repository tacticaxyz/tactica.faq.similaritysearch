URL:https://blog.chromium.org/2010/06/bringing-improved-pdf-support-to-google.html
# Bringing improved PDF support to Google Chrome
- **Published**: 2010-06-17T14:28:00.000-07:00
Millions of web users rely on PDF files every day to consume a wide variety of text and media content. To enable this, a number of plug-ins exist today which allow users to open PDF files inside their browsers.  
  
[As we’ve previously mentioned](http://blog.chromium.org/2010/03/bringing-improved-support-for-adobe.html), the traditional browser plug-in model, though powerful, presents challenges in compatibility, performance, and security. To overcome this, we’ve been working with the web community to help define a [next generation browser plug-in API](https://wiki.mozilla.org/NPAPI:Pepper).  
  
We have begun using this API to improve the experience of viewing and interacting with PDF files in Google Chrome. This mirrors [our efforts](http://blog.chromium.org/2010/03/bringing-improved-support-for-adobe.html) to optimize the Adobe Flash Player experience in Chrome.  
  
Today, we are [making available](http://googlechromereleases.blogspot.com/2010/06/dev-channel-update_17.html) an integrated PDF viewing experience in the Chrome developer channel for Windows and Mac, which can be enabled by visiting chrome://plugins. Linux support is on the way, and we will be enabling the integration by default in the developer channel in the coming weeks.  
  
With this effort, we will accomplish the following:  

* PDF files will render as seamlessly as HTML web pages, and basic interactions will be no different than the same interactions with web pages (for example, zooming and searching will work as users expect). PDF rendering quality is still a work in progress, and we will improve it substantially before releasing it to the beta and stable channels.
* To further protect users, PDF functionality will be contained within the security “[sandbox](http://seclab.stanford.edu/websec/chromium/)” Chrome uses for web page rendering.
* Users will automatically receive the latest version of Chrome’s PDF support; they won’t have to worry about manually updating any plug-ins or programs.

Currently, we do not support 100% of the advanced PDF features found in Adobe Reader, such as certain types of embedded media. However, for those users who rely on advanced features, we plan to give them the ability to launch Adobe Reader separately.  
  
We would also like to work with the Adobe Reader team to bring the full PDF feature set to Chrome using the same [next generation browser plug-in API](https://wiki.mozilla.org/NPAPI:Pepper).  
  
We’re excited about the usability and security improvements this will bring to Chrome users, and we’ll continue to keep everyone updated on our efforts through this blog.  
  
Posted by Marc Pawliger, Engineering Director 