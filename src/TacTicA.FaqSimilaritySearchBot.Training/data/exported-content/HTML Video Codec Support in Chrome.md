URL:https://blog.chromium.org/2011/01/html-video-codec-support-in-chrome.html
# HTML Video Codec Support in Chrome
- **Published**: 2011-01-11T12:02:00.000-08:00
The web’s open and community-driven development model is a key factor in its rapid evolution and ubiquitous adoption. The [WebM Project](http://www.webmproject.org/) was [launched](http://blog.webmproject.org/2010/05/introducing-webm-open-web-media-project.html) last year to bring an open, world-class video codec to the web. Since the launch, we’ve seen first-hand the benefits of an open development model:  

  
* Rapid [performance improvements](http://blog.webmproject.org/2010/10/vp8-codec-sdk-aylesbury-release.html) in the video encoder and decoder thanks to contributions from dozens of developers across the community  
  * Broad [adoption](http://www.webmproject.org/about/supporters/) by browser, tools, and [hardware vendors](http://blog.webmproject.org/2011/01/availability-of-webm-vp8-video-hardware.html)  
    * [Independent](http://blog.webmproject.org/2010/08/ffmpeg-vp8-decoder-implementation.html) (yet compatible) implementations that not only bring additional choice for users, publishers, and developers but also foster healthy competition and innovation

  
We expect even more rapid innovation in the web media platform in the coming year and are focusing our investments in those technologies that are developed and licensed based on open web principles. To that end, we are changing Chrome’s HTML5 <video> support to make it consistent with the codecs already supported by the open Chromium project. Specifically, we are supporting the WebM (VP8) and Theora video codecs, and will consider adding support for other high-quality open codecs in the future. Though H.264 plays an important role in video, as our goal is to enable open innovation, support for the codec will be removed and our resources directed towards completely open codec technologies.  
  
These changes will occur in the next couple months but we are announcing them now to give content publishers and developers using HTML <video> an opportunity to make any necessary changes to their sites.  
  
Posted by Mike Jazayeri, Product Manager