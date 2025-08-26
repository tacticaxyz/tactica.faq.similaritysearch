URL:https://blog.chromium.org/2008/09/chrome-3s-webkit.html
# Chrome <3s WebKit
- **Published**: 2008-09-05T13:38:00.000-07:00
Our recent launch of Google Chrome simply would not have been possible were it not for the awesome [WebKit](http://webkit.org/) rendering engine and the [amazing team](http://www.google.com/search?hl=en&q=cache:http://trac.webkit.org/wiki/WebKit%2520Team&btnG=Search) behind it. We want to take a moment to recognize their excellent work (past and present!) and talk about how we arrived at incorporating WebKit into Google Chrome. By the way, that excellent [web](http://twitter.com/perivision/statuses/907564759) [inspector](http://twitter.com/mayhemchaos/statuses/908095530) [tool](http://twitter.com/JohnB/statuses/907242324) is actually a [component of WebKit](http://webkit.org/blog/108/yet-another-one-more-thing-a-new-web-inspector/) ;-)  
  
At the onset of the project, we knew we didn't want to create yet another rendering engine. After all, web developers already have enough to worry about when it comes to making sure that all users can access their web pages and web applications. Being inside Google, where we develop lots of pages and webapps, we were very familiar with this problem!  
  
Yet, we also knew that we wanted to create a multi-process browser, which meant that our rendering engine needed to be very lightweight as we were going to be running many of them. Furthermore, in order to achieve our sandboxing objectives, the rendering engine needed to be stripped of any access to the local file system and native widget system.  
  
Our final constraint involved our open source ambitions for Google Chrome. We needed a rendering engine that was open source.  
  
WebKit became the obvious solution after talking to fellow engineers working on the Android project. They were already using WebKit (as it is a great option for mobile devices), and they trumpeted its speed, flexibility and simplicity. We routinely heard comments like "It's so easy to hack!" and "It didn't take me long to find my way around the code base."  
  
Our next step was to put together a test app, that allowed us to try WebKit out in a basic multi-process configuration. We were blown away by how fast WebKit could render pages! You can see a simple example of this in our [press conference video](http://www.youtube.com/watch?v=1d1_ool4r7s) (advance to the 38:30 mark). The bottom line: WebKit is a big reason why Chrome feels fast.  
  
We continued tracking the WebKit tip-of-tree during the development of Google Chrome. Now that Chromium.org is live, all of our source code is available there, and we are busily working to contribute our modifications back upstream to WebKit. We are excited about all the cool things coming in WebKit and can't wait to start helping out in a big way.  
  
Thanks again to everyone who worked on WebKit. You guys rock!  
  
Posted by Darin Fisher, Software Engineer  