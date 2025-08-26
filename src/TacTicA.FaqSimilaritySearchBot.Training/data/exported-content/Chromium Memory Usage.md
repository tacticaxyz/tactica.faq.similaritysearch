URL:https://blog.chromium.org/2009/08/chromium-memory-usage.html
# Chromium Memory Usage
- **Published**: 2009-08-06T18:35:00.000-07:00
There's been some public discussion lately about memory usage in Google Chrome. We think about our memory usage quite a bit so we're happy to see other people paying attention too. This has been a [topic of discussion before](http://blog.chromium.org/2008/09/google-chrome-memory-usage-good-and-bad.html), but our multiprocess architecture makes measuring memory utilization difficult with the standard set of tools. The crux of the problem is that Chromium goes to great lengths to share memory between processes. However, that shared memory is difficult to account for in the Windows Task Manager. On Windows XP, using the default Task Manager measurement of memory leads to double counting. On Vista, using the default view leads to under counting.

There are a couple of more accurate ways to measure memory utilization in Chromium (or Google Chrome). The easiest is to crack open the task manager that is built into Chromium which tries to account for our memory usage more holistically. If you want even more detail, you can click on "Stats for nerds" which is a link to about:memory.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhAWGoB53QDC5-Znmhe-wen2sWlA9IcR3uOWoiWSisS_bOf2D00c3jB9P4wOYUWyr3vsjwZxjAH2RhvE5XgnGH-1Z5uhPMAmKFt3mOwarkgUzBpJTjnJdnrIVfexHFSk38vT9KEqLHederZ/s400/af62pxtz7r_3gvzt5rfw_b.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhAWGoB53QDC5-Znmhe-wen2sWlA9IcR3uOWoiWSisS_bOf2D00c3jB9P4wOYUWyr3vsjwZxjAH2RhvE5XgnGH-1Z5uhPMAmKFt3mOwarkgUzBpJTjnJdnrIVfexHFSk38vT9KEqLHederZ/s1600-h/af62pxtz7r_3gvzt5rfw_b.jpg)

If you don't fully trust Chromium's task manager or about:memory, the gold standard for measuring memory usage is to look at the system's total commit charge before, during, and after using Chromium. It's a little tricky to get right because you'll need to shut down other services that may kick in while you are running your test. Here's the basic procedure:

1. Shut down any unnecessary services
2. Reboot your computer
3. Using the windows task manager, measure the Total Commit Charge of the system\*
4. Run the application you are seeking to test, in this case, Chromium
5. Measure the Total Commit Charge again
6. Close the application
7. Measure the Total Commit Charge one more time
8. Subtract your first measurement from your second, and you should have the memory used by Chromium
9. To validate your test, make sure that the first and last measurement are nearly identical

\*On XP, Commit Charge shows up on the bottom of the Windows Task Manager. On Vista, look at the Performance tab of the Windows Task Manager and use the "Memory" number.

For more information on memory usage and how to measure it, check out the [Memory Usage Backgrounder](http://www.chromium.org/developers/memory-usage-backgrounder) on chromium.org.

Posted by Brian Rakowski, Product Manager