URL:https://blog.chromium.org/2010/05/sneak-peek-at-native-client-sdk.html
# A sneak peek at the Native Client SDK
- **Published**: 2010-05-12T08:39:00.001-07:00
Today, we’re happy to make available a developer preview of the Native Client SDK – an important first step in making Native Client more accessible as a tool for developing real web applications.  
  
When we released the research version of Native Client a year ago, we offered a snapshot of our source tree that developers could download and tinker with, but the download was big and cumbersome to use. The Native Client SDK preview, in contrast, includes just the basics you need to get started writing an app in minutes: a GCC-based compiler for creating x86-32 or x86-64 binaries from C or C++ source code, ports of popular open source projects like zlib, Lua, and libjpeg, and a few samples that will help you get you started developing with the [NPAPI Pepper Extensions](https://wiki.mozilla.org/NPAPI:Pepper). Taken together, the SDK lets you write C/C++ code that works seamlessly in Chromium and gives you access to powerful APIs to build your web app.  
  
  
  
To get started with the SDK preview, grab a copy of the download at [code.google.com/p/nativeclient-sdk](http://code.google.com/p/nativeclient-sdk). You’ll also need a [recent build of Chromium](http://code.google.com/p/nativeclient-sdk/wiki/GettingStarted#Getting_the_software) started with the --enable-nacl command-line flag to test the samples and your apps. Because the SDK relies on NPAPI Pepper extensions that are currently only available in Chromium, the SDK won’t work with the Native Client browser plug-ins.  
  
We’ll be updating the SDK rapidly in the next few months, so download a copy, develop some cool apps, [share them](https://groups.google.com/group/native-client-discuss?pli=1) with the community and [send us your feedback](http://code.google.com/p/nativeclient-sdk/wiki/GivingFeedback)! If you build useful libraries in the process, please also consider submitting a patch to the [SDK packages directory](http://code.google.com/p/nativeclient-sdk/source/browse/trunk/src/packages/#packages/scripts) – chances are, what’s been useful to you will be useful to others. Finally, if you’re attending Google I/O, come to our [Beyond JavaScript](http://code.google.com/events/io/2010/sessions/native-code-chrome.html) session, or meet the team at the Developer Sandbox.  
  
Posted by David Springer, Senior Software Engineer