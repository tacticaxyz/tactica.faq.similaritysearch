URL:https://blog.chromium.org/2011/02/native-client-getting-ready-for-takeoff.html
# Native Client: Getting Ready for Takeoff
- **Published**: 2011-02-18T10:30:00.000-08:00
Over the last few months we have been hard at work getting [Native Client](http://code.google.com/p/nativeclient/) ready to support the new [Pepper](http://www.chromium.org/nativeclient/getting-started/getting-started-background-and-basics#TOC-Pepper-Plugin-API-PPAPI-) plug-in interface. Native Client is an open source technology that allows you to build web applications that seamlessly and safely execute native compiled code inside the browser. Today, we’ve reached an important milestone in our efforts to make Native Client modules as portable and secure as JavaScript, by making available a first release of the revamped [Native Client SDK](http://code.google.com/chrome/nativeclient/).

The SDK now includes support for a comprehensive set of Pepper interfaces for compute, audio, and 2D Native Client modules. These interfaces are close to being stable, with some important exceptions that are listed in the [release notes](http://code.google.com/chrome/nativeclient/docs/releasenotes.html).

In addition, we’ve focused on improving security. We have enabled auto-update and an outer sandbox. This allowed us to remove the [expiration date](https://groups.google.com/forum/#!msg/native-client-announce/5p_mTo3svhY/x8S4g-6Ax9cJ) and localhost security restrictions we had adopted in previous research-focused releases. Beyond security, we’ve also improved the mechanism for fetching Native Client modules based on the instruction set architecture of the target machine, so developers don’t need to worry about this any more.

We are excited to see Native Client progressively evolve into a developer-ready technology. In the coming months we will be adding APIs for 3D graphics, local file storage, WebSockets, peer-to-peer networking, and more. We’ll also be working on Dynamic Shared Objects (DSOs), a feature that will eventually allow us to provide Application Binary Interface (ABI) stability.

Until the ABI becomes stable, Native Client will remain off by default. However, given the progress we’ve made, you can now sticky-enable Native Client in Chrome 10+ through the about:flags dialog. Otherwise, you can continue using a command line flag to enable Native Client when you want to.

A big goal of this release is to enable developers to start building Native Client modules for Chrome applications. Please watch this blog for updates and use our [discussion group](http://groups.google.com/group/native-client-discuss) for questions, feedback, and to engage with the Native Client community.

Posted by Christian Stefansen, Product Manager