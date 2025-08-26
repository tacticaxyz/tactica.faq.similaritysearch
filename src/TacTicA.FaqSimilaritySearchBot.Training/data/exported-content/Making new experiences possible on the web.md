URL:https://blog.chromium.org/2019/11/making-new-experiences-possible-on-web.html
# Making new experiences possible on the web
- **Published**: 2019-11-11T10:00:00.000-08:00
The web that we know today has come a long way from its [humble beginnings as simple interlinked documents](http://info.cern.ch/hypertext/WWW/TheProject.html); today it powers [a huge number of](http://xkcd.com/934/) rich services and applications.

  

Content consumption is at the heart of the web, however there are many tasks that people need to turn to native applications to accomplish. Our vision is that applications shouldn't require heavyweight downloads or updates. The web should be more than enough for any user experience.

  
  

What Makes the Web Special for Apps

The greatest strength of the web is the incredible ease of access. Content and functionality is immediately available to users without any installs or setup required.  We have all enjoyed this ease of access for shopping, email, banking, connecting with friends, and much more, but there is no reason this ease of access can’t apply to practically any use case. Because of the hardened sandbox and progressive permission model of the web, users don’t have to worry about clicking a link the same way they need to worry about downloading an executable.

The URL and linkability supercharge the distribution and virality of applications and makes collaboration easy. With a web application, users can share a link through any channel and the receiving user can click that string to quickly access the application. Users sharing the link don’t need to worry about whether the receiving user has the application installed or if their OS even supports it; the application is simply there and works everywhere. This ease of sharing and ease of access also dramatically widens the user acquisition funnel.

The web is a truly open platform. You control the availability of your site and no one can block your users from accessing it. The web is also built on open standards and every major renderer is open source. This means you aren’t dependent on any one specific company or OS and as new devices & platforms emerge the web will be supported there as well.



  

Chromium's 3 Piece solution

Today, anyone with a browser can [collaborate on complex designs](http://figma.com/), [create CAD drawings](http://web.autocad.com/), [edit documents](https://www.google.com/docs/about/), [watch endless videos](http://youtube.com/), and [play tons of games](https://poki.com/), but there are still gap compared to what native applications can do. These are tasks like complex editing, creativity tools, and advanced device communication. Chromium is pursuing WebAssembly, Advanced Capabilities, and Progressive Web Apps in order to close them.



  

WebAssembly: Powerful Portability

Developers should be able to performantly bring existing investments in low-level languages like C++ to the web. The need for reliable, high performance for demanding workloads has also been a reason some apps avoid the web. Our answer to both these needs is WebAssembly.

WebAssembly uses a combination of low-level primitives and strong static typing to deliver predictable performance for low-level code, avoiding the [performance cliffs](https://v8.dev/blog/react-cliff) and GC pauses. With additions like [threads](https://developers.google.com/web/updates/2018/10/wasm-threads) and SIMD, applications can make full use of modern, multi-core processors with advanced instruction sets.

  
Because WebAssembly is a compilation target, it allows developers to bring their existing applications and libraries to the web without rewriting in JavaScript. The [Emscripten toolchain](http://emscripten.org/) offers a lot of porting support and has let applications such as AutoCAD & Sketchup come to the web, and the results are amazing. The web's advantages of easy sharing and collaboration, applied to advanced productivity apps, open up whole new ways of working.



  

Advanced Capabilities: Securely granting access to powerful capabilities

For Web Apps to be as useful as native apps, they need to have access to the same device capabilities that native apps enjoy, like file system access, NFC communication, contact picker, geolocation, and [many more](https://goo.gle/fugu-api-tracker).

  

Exposing these capabilities in a user-understandable and safe way is a big challenge, but [one that Chromium is committed to](https://blog.chromium.org/2018/11/our-commitment-to-more-capable-web.html). The web works through a progressive permission model, where each capability is granted as needed through user permission and is as limited in scope as possible. This is in contrast to native apps, which can get full access to your file system, while web apps can only save back to folders and files you have explicitly shared and given write permission for. For capabilities like USB or Bluetooth, we allow the user to choose the specific device they would like to share.

  
  
  

Progressive Web Apps: The native feel with web superpowers

Web apps need to behave like other applications and be in the places users expect them to be in order to earn a central place in our lives. Our answer is Progressive Web Apps (PWAs).

PWAs can be installed and behave like any native app. Once installed they are launched from the same place as other installed apps and open in their own window. We are also working with Microsoft and Chrome OS to provide deeper integration such as appropriate storage management attribution. PWAs can even be listed in the [Microsoft](https://docs.microsoft.com/en-us/microsoft-edge/progressive-web-apps/microsoft-store) and Samsung Galaxy store and can utilize [Trusted Web Activities](https://developers.google.com/web/updates/2019/02/using-twa) to be in the Play store.

  
  
  

**Here’s to an ever advancing web**

The web has come a long way since its original inception. The web is a truly unique platform with properties that benefit users and developers. Through the enabling technologies of WebAssembly, powerful capabilities, and PWAs, developers will be able to create any experience their users need and utilize the web’s amazing properties.

Posted by Thomas Nattestad, Product Manager, Awesome web experiences