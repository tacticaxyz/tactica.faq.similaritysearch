URL:https://blog.chromium.org/2008/11/putting-it-to-test.html
# Putting It to the Test
- **Published**: 2008-11-07T12:46:00.000-08:00
Historically, testing hasn't gotten much respect in the world of software development.  As the old saying goes, "It compiles! Ship it!" Only a joke — but like most jokes, it hides a grain of truth.

Not so for the Chromium project. Our philosophy is to test everything we possibly can, in as many ways as we can think of.

Test drive: why test?

It's easy to find arguments against testing. Writing tests takes time that developers could be using to write features, and keeping the test hardware and software infrastructure running smoothly isn't trivial.  (I'm one of the people largely responsible for the latter for Chromium, along with Nicolas Sylvain, so I know how time-consuming it can be.)  But in the long run, it's a big win, for at least two reasons.

A well-established set of tests that developers are expected to run before sending changes in makes it a lot easier to avoid causing problems, which lets other developers stay productive rather than chasing down regressions.  And testing submitted changes promptly keeps the code building cleanly and minimizes trouble in the longer term.

But even more importantly, an extensive set of automated tests gives us more confidence that Chromium is reliable, stable, and correct.  We're not afraid to rewrite major portions of the code, because verifying correctness afterward is easier. And we have the flexibility to iterate faster and produce releases more often, because we don't need a 6-month QA cycle before each one.

The test of time: performance testing

We run a lot of different tests. Tests of security. Tests of UI functionality. Tests of startup time, page-load speed, DOM manipulation, memory usage.  Tests for memory errors using Rational Purify. WebKit's suite of layout tests. Hundreds of unit tests to make sure that individual methods are still doing what they should. At last count, we run more than 9100 individual tests, typically 30-40 times every weekday.[1] You can find the [full list](http://dev.chromium.org/developers/testing) in the developer documentation, but I'll talk more about one broad category here: performance testing.

With every change made in the tree, we keep track of Chromium's page-load time, memory usage, startup time, the time to open a new tab or switch to one, and more.  All these data points are available in graphs like this one:

![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhmnK7HXM7hfSxmA61abFoMDTGjG8Hmvf10NOjH6Ka2lBlg9gof6BhN25effx4hNsOZEEXzfLf8QEtMd4nQrrIMDT1fY8NDqb_svlbVNHavU0Pnkf50tmvBwGTJ_lsaFuLML-yqzEqqEuKB/s400/testing_blog_image.png)

Here the top, gold trace shows the startup time on XP for the tip-of-tree build; the green, bottom trace shows the startup time for a reference build so we can discount variation in the test conditions; and the blue, middle trace shows the startup time along a different code path that includes loading gears.dll. The light blue horizontal line is a reference marker. As you can see, whatever changed between the previous build and r3693, it increased the startup time (gold trace) by more than 8%. The developer responsible was able to see that and fix the problem a few builds later.

This graph also shows the usefulness of running a reference build. The spike in startup time that lasted only a single build also shows up in the reference-build time (the green trace). We can assume that it was something temporarily affecting the build machine, rather than a code change. (The problem must have cleared up by the time the Gears startup test ran.)

With so many performance graphs, it can be hard to watch them all, so there's also a [summary page](http://build.chromium.org/buildbot/perf/dashboard/overview.html).

One final note about Chromium's performance graphs: they're written in HTML and JavaScript, and we're looking for someone to make them easier to use.  If you're interested, [grab the code](http://sites.google.com/a/chromium.org/dev/developers/how-tos/getting-the-buildbot-source) and [start hacking](http://dev.chromium.org/developers/contributing-code)!

Test bed: the Chromium buildbot

Nearly all of this testing is controlled by [Chromium's buildbot](http://build.chromium.org/buildbot/waterfall/), which automates the build/test cycle.  Every time a change is submitted, the buildbot master builds the tree, runs the tests on all the different platforms, and displays the results.  For a complete guide to the buildbot and its "waterfall" result page, see the [Tour of the Chromium Buildbot](http://sites.google.com/a/chromium.org/dev/developers/testing/tour-of-the-chromium-buildbot) in the developer docs.

Pro-test

Of course, once you have lots of tests running, the second important aspect of good tree hygiene is to keep them all passing.  But that's a subject for another post.

[1] It's hard to put a single number on it, because certain tests only apply to some parts of the code.  But however you count it, it's a lot of tests.

Posted by Pamela Greene, Software Engineer