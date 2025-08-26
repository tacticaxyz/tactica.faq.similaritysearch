URL:https://blog.chromium.org/2009/09/introducing-google-chrome-frame.html
# Introducing Google Chrome Frame
- **Published**: 2009-09-22T11:21:00.000-07:00
Today, we're releasing an early version of [Google Chrome Frame](http://code.google.com/chrome/chromeframe), an open source plug-in that brings HTML5 and other open web technologies to Internet Explorer.

We're building Google Chrome Frame to help web developers deliver faster, richer applications like [Google Wave](http://googlewavedev.blogspot.com/2009/09/google-wave-in-internet-explorer.html). Recent JavaScript performance improvements and the emergence of HTML5 have enabled web applications to do things that could previously only be done by desktop software. One challenge developers face in using these new technologies is that they are not yet supported by Internet Explorer. Developers can't afford to ignore IE — most people use some version of IE — so they end up spending lots of time implementing work-arounds or limiting the functionality of their apps.

With Google Chrome Frame, developers can now take advantage of the latest open web technologies, even in Internet Explorer. From a faster Javascript engine, to support for current web technologies like HTML5's offline capabilities and <canvas>, to modern CSS/Layout handling, Google Chrome Frame enables these features within IE with no additional coding or testing for different browser versions.

To start using Google Chrome Frame, all developers need to do is to add a [single tag](http://blogs.msdn.com/ie/archive/2008/06/10/introducing-ie-emulateie7.aspx):

<meta http-equiv="X-UA-Compatible" content="chrome=1">

When Google Chrome Frame detects this tag it switches automatically to using Google Chrome's speedy [WebKit-based](http://www.webkit.org/) rendering engine. It's that easy. For users, installing Google Chrome Frame will allow them to seamlessly enjoy modern web apps at blazing speeds, through the familiar interface of the version of IE that they are currently using.

We believe that Google Chrome Frame makes life easier for web developers as well as users. While this is still an early version intended for developers, our team invites you to try out this for your site. You can start by reading our [documentation](http://code.google.com/chrome/chromeframe/developers_guide.html). Please share your feedback in our [discussion group](http://groups.google.com/group/google-chrome-frame) and file any bugs you find through the Chromium [issue tracker](http://code.google.com/p/chromium/issues/list).

  
  
Posted by Amit Joshi, Software Engineer, Alex Russell, Software Engineer and Mike Smith, Product Manager 