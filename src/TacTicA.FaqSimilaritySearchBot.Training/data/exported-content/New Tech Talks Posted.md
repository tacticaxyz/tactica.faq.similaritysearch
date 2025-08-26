URL:https://blog.chromium.org/2009/12/new-tech-talks-posted.html
# New Tech Talks Posted
- **Published**: 2009-12-14T16:22:00.000-08:00
I'm excited to announce four new tech talks on the guts of Chromium have been posted to YouTube! These should be especially useful for developers who work on Chromium whether they're fairly new to the project or have been around the block.

We've done tech talks [before](http://blog.chromium.org/2009/04/chromium-tech-talks.html), but this time we asked Chromium developers what they'd most like to hear about. Once we knew what was most in demand, we found experts on each subject and asked them to make a presentation. The talks were given before a live studio audience of Googlers last Friday with extra attention paid to creating high quality recordings. Now we're excited to make these widely available to all Chromium contributors!

**The WebKit API**

with Darin Fisher

Darin Fisher talks about the recently upstreamed Chromium WebKit API. The API is a critical step in our path to becoming completely integrated into the WebKit project. Like the other WebKit APIs, ours is a veneer which shields developers (including many of our own) from the internal details of WebKit (named WebCore). Darin talks at a high level about the API, dives into some code examples, and talks about the history and future of the API.

**Layout Tests**

with Pam Greene

Layout Tests are the tests we inherit from the WebKit project and are a very important part of the Chromium's testing infrastructure. Pam Greene talks about what they are, how to run them, how to debug problems within them, and even touches on how to write your own. She also covers advanced (but easy to use) tools for rebaselining and tracking flakyness. Any Chromium developer that works on WebKit really should check this out!

**Painting in Chromium**

with Brett Wilson

Because of Chromium's multi-process architecture, painting within Chromium is far from typical. In this talk, Brett Wilson starts from Skia and the WebKit render tree, follows the bits across the process boundaries, and continues all the way to your screen. He also details many of the differences in painting between platforms, how things work in test shell, and interesting corner cases like resizing.

**WebKit's Guts**

with Eric Seidel

A large percentage of Chromium's code (and part of what makes it so fast) is WebKit. In this talk, Eric Seidel gives us a 30,000 foot view of how WebKit actually renders a page. He starts with how resources are loaded, explains how they're parsed into a DOM tree, and then talks about the various trees involved in rendering. In addition, he touches on many other important topics like hit testing (figuring out what you're hovering over and clicking on). This is a must-see for anyone working on the guts of WebKit.

Also note that all the tech talks are posted to the [Chromium developer website](http://dev.chromium.org/developers/tech-talk-videos).

Posted by Jeremy Orlow, Software Engineer