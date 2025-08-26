URL:https://blog.chromium.org/2010/05/security-in-depth-html5s-sandbox.html
# Security in Depth: HTML5’s @sandbox
- **Published**: 2010-05-27T10:05:00.000-07:00
With the [latest release](http://chrome.blogspot.com/2010/05/new-chrome-stable-release-welcome-mac.html) of Google Chrome, Chrome is the first browser to include support for a new HTML5 feature that lets web developers reduce the privileges of parts of their web pages by including a "sandbox" attribute in iframes:  
> <iframe sandbox src="http://attacker.com/untrusted.html"></iframe>

  
When displaying untrusted.html in a sandboxed iframe, the browser renders untrusted.html with reduced privileges (e.g., disabling JavaScript and popups), similar in spirit to how Google Chrome sandboxes its rendering engine.  
  
**Whitelisting**  
  
You can give untrusted.html some of its privileges back by whitelisting the privileges in the value of the sandbox attribute. For example, if you wanted untrusted.html to be able to run scripts and contain forms, you could use the following markup:  
> <iframe sandbox="allow-scripts allow-forms" src="http://attacker.com/untrusted.html"></iframe>

  
Because @sandbox is a white list, the browser still imposes the remainder of the sandbox restrictions on untrusted.html. For example, untrusted.html does not have the privilege to create popup windows or instantiate plug-ins. The [full list of supported directives is listed in the HTML5 specification](http://www.whatwg.org/specs/web-apps/current-work/#attr-iframe-sandbox).  
  
**Legacy browsers**  
  
When using the sandbox attribute, you need to think carefully about how legacy browsers (which do not support @sandbox) will interpret your HTML. The easiest way to use @sandbox is for "defense-in-depth." Instead of relying upon @sandbox as your only line of defense, you can use it as an additional security mitigation in case your first line of defense (such as output encoding) fails. Because legacy browsers ignore attributes they do not understand, you can add @sandbox to existing iframes and improve security for users of newer browsers.  
  
If you want to display untrusted content only in browsers that support @sandbox, you can detect whether the browser supports @sandbox using the follow code:  

```
if ("sandbox" in document.createElement("iframe")) {  
   // This browser supports @sandbox.  We can sandbox untrusted  
content with confidence.  
}
```

  
  
Posted by Adam Barth, Software Engineer