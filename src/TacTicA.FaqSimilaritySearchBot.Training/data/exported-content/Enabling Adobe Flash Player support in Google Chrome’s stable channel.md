URL:https://blog.chromium.org/2010/06/enabling-adobe-flash-player-support-in.html
# Enabling Adobe Flash Player support in Google Chrome’s stable channel
- **Published**: 2010-06-30T08:00:00.000-07:00
In March, we [announced](http://blog.chromium.org/2010/03/bringing-improved-support-for-adobe.html) that we would be bringing improved support for Adobe Flash Player to Google Chrome. Along with driving the development of a [next generation browser plug-in API](https://wiki.mozilla.org/Plugins:PlatformIndependentNPAPI), this integration will eliminate the need to install Flash Player separately and reduce the [security risk](http://www.techzoom.net/publications/insecurity-iceberg/) of using outdated versions. In the near future, we will extend Chrome’s “[sandbox](http://seclab.stanford.edu/websec/chromium/)” to web pages with Flash content to further protect users from malicious content.  
  
We have been testing the integration in Google Chrome’s dev and beta channels over the last few months in order to ensure a quality experience for all our users. Over the last week, we have enabled the integration by default in the stable channel of Chrome.  
  
Users who do not wish to use the built-in version of Flash Player in Chrome can disable the integration via the chrome://plugins manager. In this case, Chrome will fall back to the system-installed version of Flash Player, if it exists.  
  
  
Posted by Jeff Chang, Product Manager