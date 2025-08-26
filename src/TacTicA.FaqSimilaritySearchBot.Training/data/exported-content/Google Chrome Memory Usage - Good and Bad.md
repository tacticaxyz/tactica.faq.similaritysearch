URL:https://blog.chromium.org/2008/09/google-chrome-memory-usage-good-and-bad.html
# Google Chrome Memory Usage - Good and Bad
- **Published**: 2008-09-19T13:34:00.000-07:00
A lot of smart people are doing some serious tire kicking on Google Chrome. Now with several days of testing under their belts, we're seeing many observations about Google Chrome's memory usage. I've just posted a [techie document](http://dev.chromium.org/memory-usage-backgrounder) about memory over on the developer website as an initial brain-dump of our current thinking about memory usage within Google Chrome. This article is a quick summary.

Measuring memory

If you're measuring memory in a multi-process application like Google Chrome, don't forget to take into account shared memory. If you add the size of each process via the Windows XP task manager, you'll be double counting the shared memory for each process. If there are a large number of processes, double-counting can account for 30-40% extra memory size.

To make it easy to summarize multi-process memory usage, Google Chrome provides the "about:memory" page which includes a detailed breakdown of Google Chrome's memory usage and also provides basic comparisons to other browsers that are running.

Multi-process Model Disadvantages

While the multi-process model provides clear robustness and performance benefits, it can also be a setback in terms of using the absolute smallest amount of memory. Since each tab is its own "sandboxed" process, tabs cannot share information easily. Any data structures needed for general rendering of web pages must be replicated to each tab. We've done our best to minimize this, but we have a lot more work to do.

Example: Try opening the browser with 10 different sites in 10 tabs. You will probably notice that Google Chrome uses significantly more memory than single-process browsers do for this case.

Keep in mind that we believe this is a good trade-off. For example; each tab has it's own JavaScript engine. An attack compromising one tab's Javascript engine is much less likely to be able to gain access to another tab (which may contain banking information) due to process separation. Operating systems vendors learned long ago that there are many benefits to not having all applications load into a single process space, despite the fact that multiple processes do incur overhead.

Multi-process advantages

Despite the setback, the multi-process model has advantages too. The primary advantage is the ability to partition memory for particular pages. So, when you close a page (tab), that partition of memory can be completely cleaned up. This is much more difficult to do in a single-process browser.

To demonstrate, lets expand on the example above. Now that you have 10 open tabs in a single process browser and Google Chrome, try closing 9 of them, and check the memory usage. Hopefully, this will demonstrate that Google Chrome is actually able to reclaim more memory than the single process browser generally can. We hope this is indicative of general user behavior, where many sites are visited on a daily basis; but when the user leaves a site, we want to cleanup everything.

You can find even more details in the [design doc](http://www.chromium.org/developers/memory-usage-backgrounder) in our Chromium [developer website](http://dev.chromium.org/).

  
Posted by Mike Belshe, Software Engineer