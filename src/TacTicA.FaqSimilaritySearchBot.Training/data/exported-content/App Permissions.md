URL:https://blog.chromium.org/2010/11/app-permissions.html
# App Permissions
- **Published**: 2010-11-18T14:50:00.000-08:00
This is part of a [series](http://blog.chromium.org/2010/10/creating-great-user-interface-for-your.html) of blog posts that provide tips and tricks on how to create better web apps as well as insights behind the technology of the Chrome Web Store - Ed.  
  
Web development sure got fun recently, right? Local storage, notifications, new form controls, geolocation, inline multimedia... the list goes on and on. These new capabilities can help web developers build powerful new features in their apps.   
  
However, many of these new additions to the web platform are not allowed to web pages by default. For example, to protect a user’s privacy, browsers do not allow web pages to use the geolocation API to access a user’s location unless they prompt the user. Browsers show these prompts each time a web page tries to use a potentially invasive or unsafe capability:  
  
[![](http://2.bp.blogspot.com/_-MC69KJzn6Y/TOWwGCsCK7I/AAAAAAAAACM/LZ7pji1N20I/s320/map1.png)](http://2.bp.blogspot.com/_-MC69KJzn6Y/TOWwGCsCK7I/AAAAAAAAACM/LZ7pji1N20I/s1600/map1.png)  
  
But these prompts can be quite annoying, especially when one web page asks for several of them. And some of these privileges are relatively obscure or incomprehensible to the user. As a result they end up being ignored or scare users from allowing a particular functionality. Most people don’t know what a “clipboard” is, so asking them about access to it is not that informative or helpful.  
  
Now in the Chrome Web Store, developers can create “apps” that group together multiple privilege requests for a single site. Apps have a lightweight installation step that displays the privileges the app requests all together. Once an app is installed, it can use the privileges it requested during the installation process without any further nagging.  
  
[![](http://3.bp.blogspot.com/_-MC69KJzn6Y/TOWwkOFX0JI/AAAAAAAAACU/jnQqqWNpvVc/s320/map2.png)](http://3.bp.blogspot.com/_-MC69KJzn6Y/TOWwkOFX0JI/AAAAAAAAACU/jnQqqWNpvVc/s1600/map2.png)  
  
Some privileges are relatively low-risk, so we infer permission to use them from the act of installing the application. An example of this is the notifications API. The only reason it isn’t allowed to normal web sites by default is that it could be used annoyingly. When a user installs an app, we interpret that as a sign of at least some trust, and allow that application to use the Notifications API without additional prompting. If users do not like the notifications that the application generates, they can either disable them in the app’s notification UI or they can simply uninstall the app.  
  
In this first version of apps for the Chrome Web Store, we support permission request declarations for the geolocation, notifications, and unlimited storage privileges. Over time we’ll be adding even more.  
  
To learn more about how to build apps for the Chrome Web Store, visit the developer documentation at [code.google.com/chrome/webstore](http://code.google.com/chrome/webstore).  
  
Posted by Aaron Boodman, Software Engineer 