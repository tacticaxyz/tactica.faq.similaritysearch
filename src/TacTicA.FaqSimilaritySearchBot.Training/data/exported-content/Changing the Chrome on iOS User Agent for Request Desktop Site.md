URL:https://blog.chromium.org/2020/09/changing-chrome-on-ios-user-agent-for.html
# Changing the Chrome on iOS User Agent for Request Desktop Site
- **Published**: 2020-09-14T06:16:00.000-07:00
Chrome on iOS sends two different User-Agent strings, depending on the version of the site being requested by the user.  
  
In M84 and earlier, the User-Agent string sent when the **Request Desktop Site** option was selected matched the string used by Safari Desktop.  
  

```
Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_5) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/11.1.1 Safari/605.1.15
```

  
Starting with M85, the User-Agent string sent with the **Request Desktop Site** option changes to include the CriOS/<MajorVersion> tag.  
  
  

```
Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_5) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/85 Version/11.1.1 Safari/605.1.15
```

  
  
  

This brings the string more in-line with the default User-Agent used to request the Mobile version of the site. The User-Agent string sent in this case remains the same, matching the Mobile Safari user agent, with CriOS/<ChromeRevision> instead of Version/<VersionNum>.  
  
  

```
Mozilla/5.0 (iPhone; CPU iPhone OS 10_3 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) CriOS/56.0.2924.75 Mobile/14E5239e Safari/602.1
```

  
  
  
The goal of this change is to allow developers to tailor the user experiences to account for differences between Chrome and Safari on iOS. This change adds more information to the Desktop User-Agent string, but including the browser name and major version in the User Agent header is still in line with [the goals of Chrome’s User Agent information reduction plans](https://groups.google.com/a/chromium.org/g/blink-dev/c/-2JIRNMWJ7s/m/u-YzXjZ8BAAJ).  
  
  

Posted by Gauthier Ambard, Software Engineer, Chrome on iOS