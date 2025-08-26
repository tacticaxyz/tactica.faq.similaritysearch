URL:https://blog.chromium.org/2010/06/google-chromes-developer-tools-improve.html
# Google Chrome’s Developer Tools Improve Productivity
- **Published**: 2010-06-04T08:37:00.000-07:00
At Google I/O 2010 we [presented](http://code.google.com/events/io/2010/sessions/chrome-developer-tools.html) on Google Chrome’s Developer Tools and enjoyed getting the in-person feedback from developers. We wanted to list some of the new and improved features we presented at I/O that set apart our tools in helping developers become more productive.

* The Scripts panel now allows editing JavaScript without having to reload the page. Just double-click on the line in the function body while debugging and make your changes. We’ll patch the underlying optimized machine code at run-time and continue the execution. [[video](http://www.youtube.com/watch?v=TH7sJbyXHuk#t=20m24s)]
* CPU profiler captures the state of your app at a rate of 1,000 samples per second without modifications to the running optimized machine code. The resulting tree view makes it easy to find out where to focus efforts on speeding up the web app. [[video](http://www.youtube.com/watch?v=TH7sJbyXHuk#t=27m29s)]
* The new Timeline panel provides a simple view of the AJAX application execution. It records everything that happens in the browser from JavaScript execution to styles re-calculations and then visualizes it in a simple waterfall with timing information and traces to the source code. See the demo fragment at [[video](http://www.youtube.com/watch?v=TH7sJbyXHuk#t=29m51s)].
* The improved Heap profiler can take snapshots of the JavaScript heap, visualize and compare them. This makes finding and fighting memory leaks a much easier task. See the demo fragment at [[video](http://www.youtube.com/watch?v=TH7sJbyXHuk#t=36m10s)].

We also [covered](http://webkit.org/blog/1091/more-web-inspector-updates/) a number of general Inspector improvements in the WebKit blog recently. Watch them live in the DevTools panel walk through from the I/O [video](http://www.youtube.com/watch?v=TH7sJbyXHuk#t=08m00s).

We welcome feedback: to submit a bug or feature request please use the Chromium [issue tracker](http://bugs.chromium.org/) and mention DevTools in the summary.

We hope you like the new improved Google Chrome Developer Tools. Note that some of the features above are only available on Google Chrome’s [Dev Channel](http://www.chromium.org/getting-involved/dev-channel) at this moment. For more info please check out the [DevTools](http://www.chromium.org/devtools) site.

Posted by Pavel Feldman, Software Engineer