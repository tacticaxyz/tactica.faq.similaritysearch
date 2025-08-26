URL:https://blog.chromium.org/2021/12/chrome-windows-performance-improvements-native-window-occlusion.html
# Chrome on Windows performance improvements and the journey of Native Window Occlusion
- **Published**: 2021-12-09T08:30:00.001-08:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjBnFszV3_OSq9fbqxZvxkYPqk82PcWjLOWM2tdQDkbL8DekbaVTQd-Pm-JqGbly7aHbS5sHAC3BlfoJvKdWtQJjTMu7WTuf0LE2v-H0u0uol7muwJIcSI4YdJUVc2bsn5t9I4fEp_ZuTip/w636-h264/image2.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjBnFszV3_OSq9fbqxZvxkYPqk82PcWjLOWM2tdQDkbL8DekbaVTQd-Pm-JqGbly7aHbS5sHAC3BlfoJvKdWtQJjTMu7WTuf0LE2v-H0u0uol7muwJIcSI4YdJUVc2bsn5t9I4fEp_ZuTip/s1999/image2.jpg)

  
  
*Whether you prefer organizing your browser with [tab groups](https://blog.google/products/chrome/manage-tabs-with-google-chrome/), [naming your windows](https://blog.google/products/chrome/more-helpful-chrome-throughout-your-workday/#:~:text=memory%20and%20CPU.-,Name%20your%20windows%C2%A0,-To%20set%20myself), [tab search](https://blog.google/products/chrome/faster-chrome/#:~:text=Tabs%3A%20pin%20%E2%80%98em%2C%20group%20%E2%80%98em%2C%20and%20now%20search%20%E2%80%98em), or another method, you have lots of features that help you get to the tabs you want. In this [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post, we describe how we use what windows are visible to you to optimize Chrome, **leading to 25.8% faster start up and 4.5% fewer crashes.***

Background
==========

For several years, to improve the user experience, Chrome has lowered the priority of background tabs[1]. For example, JavaScript is throttled in background tabs, and these tabs don’t [render](https://www.chromium.org/developers/design-documents/multi-process-architecture) web content. This reduces CPU, GPU and memory usage, which leaves more memory, CPU and GPU for foreground tabs that the user actually sees. However, the logic was limited to tabs that weren't focused in their window, or windows that were minimized or otherwise moved offscreen.  
  
Through experiments, we found that nearly 20% of Chrome windows are completely covered by other windows, i.e., occluded. If these occluded windows were treated like background tabs, our hypothesis was that we would see significant performance benefits. So, around three years ago, we started working on a project to track the occlusion state of each Chrome window in real time, and lower the priority of tabs in occluded windows. We called this project Native Window Occlusion, because we had to know about the location of native, non-Chrome windows on the user’s screen. (The location information is discarded immediately after it is used in the occlusion calculation.)

Calculating Native Window Occlusion
===================================

The Windows OS doesn’t provide a direct way to find out if a window is completely covered by other windows, so Chrome has to figure it out on its own. If we only had to worry about other Chrome windows, this would be simple because we know where Chrome windows are, but we have to consider all the non-Chrome windows a user might have open, and know about anything that happens that might change whether Chrome windows are occluded or not.  
  
There are two main pieces to keeping track of which Chrome windows are occluded. The first is the occlusion calculation, which consists of iterating over the open windows on the desktop, in [z-order](https://en.wikipedia.org/wiki/Z-order) (front to back) and seeing if the windows in front of a Chrome window completely cover it. The second piece is deciding when to do the occlusion calculation.

Calculating Occlusion
=====================

In theory, figuring out which windows are occluded is fairly simple. In practice, however, there are lots of complications, such as [multi-monitor setups](https://docs.microsoft.com/en-us/windows/win32/gdi/multiple-monitor-system-metrics), [virtual desktops](https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ivirtualdesktopmanager), [non-opaque windows](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getlayeredwindowattributes), and even [cloaked windows](https://docs.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute)(!). This needs to be done with great care, because if we decide that a window is occluded when in fact it is visible to the user, then the area where the user expects to see web contents will be white. We also don’t want to block the UI thread while doing the occlusion calculation, because that could reduce the responsiveness of Chrome and degrade the user experience. So, we compute occlusion on a separate thread, as follows:  

1. Ignore minimized windows, since they’re not visible.
2. Mark Chrome windows on a different virtual desktop as occluded.
3. Compute the virtual screen rectangle, which combines the display monitors. This is the unoccluded screen rectangle.
4. Iterate over the open windows on the desktop from front to back, ignoring invisible windows, transparent windows, floating windows (windows with style [WS\_EX\_TOOLBAR](https://docs.microsoft.com/en-us/windows/win32/winmsg/extended-window-styles)), cloaked windows, windows on other virtual desktops, non-rectangular windows[2], etc. Ignoring these kinds of windows may cause some occluded windows to be considered visible (false negatives) but importantly it won’t lead to treating visible windows as occluded (false positives). For each window:

* Subtract the window's area from the unoccluded screen rectangle.
* If the window is a Chrome window, check if its area overlapped with the unoccluded area. If it didn’t, that means the Chrome window is completely covered by previous windows, so it is occluded.

5. Keep iterating until all Chrome windows are captured.
6. At this point, any Chrome window that we haven’t marked occluded is visible, and we’re done computing occlusion. Whew! Now we post a task to the UI thread to update the visibility of the Chrome windows.
7. This is all done without synchronization locks, so the occlusion calculation has minimal effect on the UI thread, e.g., it will not ever block the UI thread and degrade the user experience.

For more detailed implementation information, see the [documentation](https://source.chromium.org/chromium/chromium/src/+/main:docs/windows_native_window_occlusion_tracking.md).

Deciding When to Calculate Occlusion
====================================

We don’t want to continuously calculate occlusion because it would degrade the performance of Chrome, so we need to know when a window might become visible or occluded. Fortunately, Windows lets you track various system events, like windows moving or getting resized/maximized/minimized. The occlusion-calculation thread tells Windows that it wants to track those events, and when notified of an event, it examines the event to decide whether to do a new occlusion calculation. Because we may get several events in a very short time, we don’t calculate occlusion more than once every 16 milliseconds, which corresponds to the time a single frame is displayed, assuming a frame rate of 60 frames per second (fps).  
  
Some of the events we listen for are windows getting activated or deactivated, windows moving or resizing, the user locking or unlocking the screen, turning off the monitor, etc. We don’t want to calculate occlusion more than necessary, but we don’t want to miss an event that causes a window to become visible, because if we do, the user will see a white area where their web contents should be. It’s a delicate balance[3].  
  
The events we listen for are focused on whether a Chrome window is occluded. For example, moving the mouse generates a lot of events, and cursors generate an event for every blink, so we ignore events that aren’t for window objects. We also ignore events for most popup windows, so that tooltips getting shown doesn’t trigger an occlusion calculation.  
  
The occlusion thread tells Windows that it wants to know about various Windows events. The UI thread tells Windows that it wants to know when there are major state changes, e.g., the monitor is powered off, or the user locks the screen.  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiwrZ4rNITxC_LTgirCCPJ-nPrAEMEIz4_LAHTWRI7ZDKj3aFjb-QnnIzihx3W6-GNRkF6nnw1OHxF9bJ8u9b0mzrfA-dahpyY4QrI1LfFeibQXcZLlzrBNkqAW6fChQAEAaHIk1elJTMOj/w607-h404/image1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiwrZ4rNITxC_LTgirCCPJ-nPrAEMEIz4_LAHTWRI7ZDKj3aFjb-QnnIzihx3W6-GNRkF6nnw1OHxF9bJ8u9b0mzrfA-dahpyY4QrI1LfFeibQXcZLlzrBNkqAW6fChQAEAaHIk1elJTMOj/s1999/image1.png)  
   
  

Results
=======

This feature was developed behind an [experiment](https://www.chromium.org/developers/design-documents/experiments) to measure its effect and rolled out to 100% of Chrome Windows users in October 2020 as part of the M86 release. Our metrics show significant performance benefits with the feature turned on:  

* 8.5% to 25.8% faster startup
* 3.1% reduction in GPU memory usage
* 20.4% fewer renderer frames drawn overall
* 4.5% fewer clients experiencing renderer crashes
* 3.0% improvement in [first input delay](https://web.dev/fid/)
* 6.7% improvement in [first contentful paint](https://web.dev/fcp/) and [largest contentful paint](https://web.dev/lcp/)

A reason for the startup and first-contentful-paint improvements is when Chrome restores two or more full-screen windows when starting up, one of the windows is likely to be occluded. Chrome will now skip much of the work for that window, thus saving resources for the more important foreground window.  
  
Posted by David Bienvenu, Chrome Developer  
  
*Data source for all statistics: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.*

*[1] Note that certain tabs are exempt from having their priority lowered, e.g., tabs playing audio or video.*

*[2] Non-rectangular windows complicate the calculations and were thought to be rare, but it turns out non-rectangular windows are common on Windows 7, due to some quirks of the default Windows 7 theme.*

*[3] When this was initially launched, we quickly discovered that Citrix users were getting white windows whenever another user locked their screen, due to Windows sending us session changed notifications for sessions that were not the current session. For the details, look [here](https://bugs.chromium.org/p/chromium/issues/detail?id=1024837).*