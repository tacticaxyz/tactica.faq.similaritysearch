URL:https://blog.chromium.org/2009/08/google-chrome-developer-tools-for.html
# Google Chrome Developer Tools for Eclipse Users
- **Published**: 2009-08-04T15:45:00.000-07:00
We recently [announced](http://blog.chromium.org/2009/06/developer-tools-for-google-chrome.html) the availability of developer tools for Google Chrome. We are now releasing [ChromeDevTools](http://code.google.com/p/chromedevtools/), which enables JavaScript debugging using Eclipse.

You can set breakpoints, inspect variables and evaluate expressions all from within Eclipse. The screenshot shows the debugger in action stopped at a breakpoint.

  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgmxVDmFcKIBokf-hGJlnBym6O1kihZjv5zAUELpmq1ej6e49pp6CNwQ7bIgjERekHBSuGSDQk7Y7M79EiIVfPZiSPX3nrmDm2jzemT41w-cGbbVDj20_OSMO-wlRS0T-rwE5A4gw23ISm0/s400/dcq7s2gz_30dbp6p2gv_b.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgmxVDmFcKIBokf-hGJlnBym6O1kihZjv5zAUELpmq1ej6e49pp6CNwQ7bIgjERekHBSuGSDQk7Y7M79EiIVfPZiSPX3nrmDm2jzemT41w-cGbbVDj20_OSMO-wlRS0T-rwE5A4gw23ISm0/s1600-h/dcq7s2gz_30dbp6p2gv_b.png)

  

The project is fully open sourced on a BSD-license and consists of two components, an SDK and a debugger. The SDK provides a Java API that enables communication with Google Chrome over TCP/IP. The debugger is an Eclipse plugin that uses the SDK and enables you to debug JavaScript running in Google Chrome from the Eclipse IDE.

We hope this project will help web app developers and welcome [feedback](http://code.google.com/p/chromedevtools/issues/list) as well as contributions.

Posted by Alexander Pavlov, Software Engineer 