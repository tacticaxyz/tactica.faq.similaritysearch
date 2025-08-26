URL:https://blog.chromium.org/2009/11/update-for-google-chromes-developer.html
# An Update for Google Chrome's Developer Tools
- **Published**: 2009-11-30T13:56:00.000-08:00
Since we first [introduced](http://blog.chromium.org/2009/06/developer-tools-for-google-chrome.html) Google Chrome's developer tools, we've been busy adding more functionality to them.

First, our tools benefited from [improvements](http://webkit.org/blog/829/web-inspector-updates/) that the WebKit team made to Web Inspector (our developer tools are partially based on Web Inspector). Second, from our end, we recently released the heap profiler and the timeline tab in Google Chrome's Developer Channel.

With the heap profiler you can now take a snapshot of the JavaScript heap at any point in time. A heap snapshot helps you understand memory usage, and by comparing snapshots you can also follow memory usage over time. You will find the heap profiler in the profiles tab along with the sample-based CPU profiler.

The new timeline view gives you a complete overview of where time is spent when loading a web app. All events -- ranging from loading resources over parsing and executing JavaScript to calculating styles and repainting -- are plotted on a timeline.

Besides these product improvements, we've tried to make the Google Chrome Developer tools easier to find and understand by putting together a [mini site](http://www.chromium.org/devtools) with tutorials and videos.

To take our newest release for a spin, get Google Chrome from the [Developer Channel](http://www.chromium.org/getting-involved/dev-channel) and you'll automatically be brought up to date. We welcome your [feedback](http://code.google.com/p/chromium/issues/list?q=label:Area%20label:DevTools) and your contributions to improve developer tools in WebKit and Google Chrome even more.

Posted by Pavel Feldman, Software Engineer and Anders Sandholm, Product Manager 