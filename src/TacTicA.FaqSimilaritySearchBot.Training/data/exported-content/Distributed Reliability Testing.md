URL:https://blog.chromium.org/2009/02/distributed-reliability-testing.html
# Distributed Reliability Testing
- **Published**: 2009-02-25T15:41:00.000-08:00
We want Google Chrome to be as stable as possible. No matter what site you browse to or what you do, Chrome should never crash. A system we call "distributed reliability testing" is one of the main tools we use to help turn that goal into reality.

One of the advantages to being associated with Google is that we have access to a lot of information about the Web, and a lot of computers to test on. About once an hour, our distributed test infrastructure takes the very latest version of Google Chrome in development and uses it to automatically load a large number of the pages that Google has seen are most popular around the world. When it's done, it produces a report like this on the [Buildbot waterfall](http://build.chromium.org/buildbot/waterfall/waterfall?builder=Chromium%20Reliability) that all our developers (and anyone else) can see:

Results for top 500 web sites:

success: 499; crashes: 0; crash dumps: 0; timeout: 1

Results for top 500 web sites without sandbox:

success: 463; crashes: 0; crash dumps: 0; timeout: 2

Results for extended list of web sites:

success: 99768; crashes: 3; crash dumps: 3; timeout: 463

Here the final test got through a bit over 100,000 pages before stopping to make way for the next build to be tested. And before each [Dev, Beta, or Stable channel](http://dev.chromium.org/getting-involved/dev-channel) release, we run with a much larger number of URLs.

In addition, we "fuzz-test" the user interface, automatically performing arbitrary sequences of actions (opening a new tab, pressing the spacebar, opening various dialogs, etc. — a total of more than 30 possible actions). These are also run in our distributed testing architecture, so we can exercise thousands of combinations for each new version of Google Chrome in progress. The same report that shows the page-load results above collects these UI test results too:

Results for automated UI test:

success: 64643; crashes: 0; crash dumps: 0; timeout: 0

This sort of large-scale testing is great for finding crashes that happen only rarely, or that only affect pages that developers wouldn't have visited as part of their haphazard manual testing. By catching a problem right away even if it's very rare, it's easier for developers to figure out what change caused the error and fix it before it ever gets close to showing up in Google Chrome itself.

Posted by Pamela Greene and Patrick Johnson, Software Engineers