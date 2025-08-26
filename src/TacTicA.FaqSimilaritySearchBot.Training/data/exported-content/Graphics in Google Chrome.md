URL:https://blog.chromium.org/2008/10/graphics-in-google-chrome.html
# Graphics in Google Chrome
- **Published**: 2008-10-23T14:23:00.000-07:00
Google Chrome uses a library called Skia, which is also the graphics engine behind Google's Android mobile OS. The two projects share code that implements WebKit's porting API in terms of Skia. Google Chrome also uses Skia to render parts of the user interface such as the toolbar and tab strip. I'm going to talk about some of the history that led us to choose Skia, as well as how our graphics layer works.

WebKit is designed to work on multiple operating systems. It abstracts platform-specific functions into the "port," which an embedder application such as Google Chrome implements specifically for their system. This relatively clean abstraction has helped WebKit to be adopted on a wide variety of devices and systems. One of the parts of the port we had to consider when developing Google Chrome was the graphics layer, which is responsible for rendering text, images, and other graphics to the screen.

Which graphics library?

One question that people often ask is, why not use OpenGL or DirectX for accelerated rendering? First, on Windows, we use a sandbox that prevents us from displaying windows from our renderer processes. The image data must be transferred to the main browser process before it can be drawn to the screen, which limits the possible approaches we can take. If the images needs to be read off the video card only to be copied back to the video card in another process, it is usually not worthwhile using accelerated rendering in the first place.

Second, drawing graphics is actually a very small percentage of the time we spend rendering a page. Most of the time is spent in WebKit computing where things will be placed, what styles to apply to them, and using system routines to draw text. Accelerated 3D graphics would not give us enough overall improvement in speed to balance out the extra work and compatibility problems that we would encounter.

If we aren't going to be using OpenGL or DirectX, what about other graphics libraries? We considered a number of options when we first started work on our Windows port of WebKit:

* [Windows GDI](http://msdn.microsoft.com/en-us/library/ms536795(VS.85).aspx): GDI is the basic, low-level graphics API in Microsoft Windows. It is used to draw buttons, window controls, and dialog boxes for every Windows application, so we know that it's tested and works well. However, it has relatively basic capabilities. Although most web pages can be drawn using only these basic primitives, parts of <canvas> or SVG would need to be implemented separately, either using a different graphics library, or our own custom code.
* [GDI](http://msdn.microsoft.com/en-us/library/ms533798(VS.85).aspx)+: GDI+ is a more advanced graphics API provided on newer versions of Windows. Its API is cleaner and it supports most 2D graphics operations you could think to use. However, we had concerns about GDI+ using device independent metrics, which means that text and letter spacing might look different in Google Chrome than in other Windows applications (which measure and draw text tailored to the screen device). Additionally, at the time we were making the decision, Microsoft was recommending developers use newer graphics APIs in Windows, so we weren't sure how much longer GDI+ would be supported and maintained.
* [Cairo](http://www.cairographics.org/): Cairo is an open-source 2D graphics library. It is successfully used in Firefox 3, and the Windows port of WebKit at that time already had a partially complete graphics implementation for WebKit. Cairo is also cross-platform, a key advantage over GDI and GDI+ when building a cross-platform browser.

We ended up choosing Skia over these options because it is cross-platform (meaning our work wouldn't have to be duplicated when porting to other systems), because there was already a high-quality WebKit port using it created for Android's browser, and because we had in-house expertise. The latter point is critical because we expected to (and did) need additional features added to the graphics library as well as some bugs fixed.

So far, we've been very happy with our choice. Skia has proved to be effective at handling all the graphics operations we've needed, has been fast enough despite being software-only, and we've gotten great support from the Skia team. Thanks!

System-specific features

Android has the advantage of controlling the entire operating system graphics layer. Skia's font layer implements all text rendering for the Android system, so all text looks consistent. However, we wanted to match the host OS's look and feel. This means using native text rendering routines so that, for example, we can get [ClearType](http://www.microsoft.com/typography/whatiscleartype.mspx) on Windows.

To solve this problem, we create a wrapper around Skia's SkDevice (an object representing a low-level drawing surface) which we call PlatformDevice. The object is both a bitmap in main memory that Skia can draw into, and a "Device Independent Bitmap" that the Windows GDI layer can draw into. Lines, images, and patters are all drawn by Skia into this bitmap, while text is drawn directly by Windows. As part of our porting efforts, we are currently working on creating similar abstractions for OS X and Linux.

Posted by Brett Wilson, Software Engineer