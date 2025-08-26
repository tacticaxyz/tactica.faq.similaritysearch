URL:https://blog.chromium.org/2010/12/break-on-ui-and-network-events-in.html
# Break on UI and network events in Chrome Developer Tools
- **Published**: 2010-12-13T09:11:00.000-08:00
[Chrome Developer Tools](http://code.google.com/chrome/devtools/docs/overview.html)' Scripts panel provides a graphical JavaScript debugger and allows you to set breakpoints in the JavaScript source code. However, setting breakpoints in the source code does not always work well, especially when the application is large and you are not familiar with the entire code base. To better support this use case, we are introducing a new set of breakpoints that allow you to break on UI and network events.  
  
Suppose you need to find the piece of code that modifies a specific node in a document. Right-click on that node in the Elements panel and select the appropriate “Break on...” context menu option and you are all set. The debugger will pause JavaScript execution right before the node gets modified next time.  
  
[![](http://4.bp.blogspot.com/_-MC69KJzn6Y/TQZUsyeYSaI/AAAAAAAAACc/v2WjYLTdFqI/s320/Screen%2Bshot%2B2010-12-13%2Bat%2B9.14.53%2BAM.png)](http://4.bp.blogspot.com/_-MC69KJzn6Y/TQZUsyeYSaI/AAAAAAAAACc/v2WjYLTdFqI/s1600/Screen%2Bshot%2B2010-12-13%2Bat%2B9.14.53%2BAM.png)  
  
To learn more about DOM breakpoints and other new kinds of breakpoints, visit our [Breakpoints Tutorial](http://code.google.com/chrome/devtools/docs/scripts-breakpoints.html) page.  
  
Posted by Pavel Podivilov, Software Engineer 