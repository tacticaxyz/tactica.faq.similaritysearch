URL:https://blog.chromium.org/2020/11/tab-throttling-and-more-performance.html
# Tab throttling and more performance improvements in Chrome M87
- **Published**: 2020-11-17T10:00:00.003-08:00
Even if you have **a lot** of tabs open, you likely only focus on a small set of them to get a task done. Starting in this release, Chrome is actively managing your computer’s resources to make the tabs you care about fast—while allowing you to keep hundreds of tabs open—so you can pick up where you left off.

In this release, we’re improving how Chrome understands and manages resources with Tab throttling, occlusion tracking and back/forward caching, so you can quickly get to what you need when you need it.

### Tab throttling and Occlusion Tracking

Knowing what tabs you’re using helps Chrome manage your computer’s resources more efficiently to get things done. We’ve made significant improvements by preventing background tabs from waking up your CPU too often, and no longer rendering tabs that you can’t see.

We investigated how background tabs use system resources and found that JavaScript Timers represent >40% of the work in background tabs. Reducing their impact on CPU and power is important to make the browser more efficient. Beginning in M87, we’re [throttling JavaScript timer wake-ups](https://docs.google.com/document/d/11FhKHRcABGS4SWPFGwoL6g0ALMqrFKapCk5ZTKKupEk/view) in background tabs to once per minute. This reduces CPU usage by up to 5x, and extends battery life up to 1.25 hours in our internal testing. We’ve done this without sacrificing the background features that users care about, like playing music and getting notifications.

Next, we’re bringing [Occlusion Tracking](https://docs.google.com/document/d/1Di4DiGwHamIgLYjaOpripOJQinUquUuyxuiim2-WUIs/view)--which was previously added to Chrome OS and Mac--to Windows, which allows Chrome to know which windows and tabs are actually visible to you. With this information, Chrome can optimize resources for the tabs you are using, not the ones you’ve minimized, making Chrome up to 25% faster to start up and 7% faster to load pages, all while using less memory.

These updates will be gradually rolling out in M87 and our next release, M88.

### Back/forward cache

How many times have you visited a website and clicked a link to go to another page, only to realize it's not what you wanted and click the back button? On mobile devices, this happens a lot: 1 in 5 navigations are a back/forward navigation. This is where a back/forward cache shines! It’s a browser optimization which enables instant back and forward navigations. In Chrome 87, our back/forward cache will make 20% of those back/forward navigations instant, with plans to increase this to 50% through further improvements and developer outreach in the near future. Here is how it works:

  

Back/forward cache is one of our long wished-for feature requests in Chrome and now with Chrome 87 we will gradually launch it to Chrome for Android users. Head over to [this technical article](https://web.dev/bfcache/) to learn more about how we added back/forward cache within Chrome's multi-process architecture and if you're a web developer, learn how to make the most of the back/forward cache on your website.

Posted by Mark Chang, Chrome Product Manager

*Data source: Real world data anonymously aggregated from Chrome pre-stable channels.*