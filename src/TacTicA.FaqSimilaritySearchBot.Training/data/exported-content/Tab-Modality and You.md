URL:https://blog.chromium.org/2009/12/tab-modality-and-you.html
# Tab-Modality and You
- **Published**: 2009-12-17T00:00:00.000-08:00
Years ago, I remember watching a webcast of the introduction of the Aqua user interface when Mac OS X Public Beta was first demoed. The part I distinctly remember was realizing the brilliance of sheets. Like many great innovations, they were simple in retrospect and solved a problem you didn't realize you had: the modality problem — the fact that dialog boxes blocked interacting with the whole application even though only one window needed the information that you, as the user, had to provide. I watched in wonder as a save dialog blocked only the one window that needed saving, leaving all the other windows free. Finally, a solution to limit the modality.

Because modality sucks.

Back in 2000, sheets worked well because the smallest unit of user interaction with an application was a window. Soon after, though, things started to change. Web browsers in particular were among the first to start using tabs to put more than one document in a window. This caused a snag. A web page can require modal interaction from the user: picking a file, or supplying a username and password. Yet we don't want to prevent the user from switching to a different tab and continuing to interact with other websites. If the finest-grained modality control we have is per-window, how can we achieve that outcome?

Chromium's current answer comes from combining Cocoa's child window support with sheets to get tab-modal sheets:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEidWzdHjhgogd7Rj88I5vQFI7pd8yhs4HExnLaMGQv9mZN1OQ2VnltFObVxO9AOQt4tFGQ5RMo6J6oqw8UyskywG_bogQ3e-dBVTHSIO6fUlOC0T-LZAYJDsplfI-3QDj_py6ktOVcX-63N/s400/chrome_mac.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEidWzdHjhgogd7Rj88I5vQFI7pd8yhs4HExnLaMGQv9mZN1OQ2VnltFObVxO9AOQt4tFGQ5RMo6J6oqw8UyskywG_bogQ3e-dBVTHSIO6fUlOC0T-LZAYJDsplfI-3QDj_py6ktOVcX-63N/s1600-h/chrome_mac.png)

While this looks like a normal sheet, you can switch between open tabs while the password request is up. You can't, however, interact with the web page.

The implementation, like all of the code used in Chromium, is open source, and can be found in the [Google Toolbox for Mac](http://code.google.com/p/google-toolbox-for-mac/), a collection of reusable components from the Mac developers at Google. The technical details of the GTMWindowSheetController can be found on the [Google Mac blog](http://googlemac.blogspot.com/2009/12/cocoa-and-tab-modality.html). The other thing to note is that right now tab-modal sheets are only used for website authentication. The other sheets we use (for file selection, etc) are currently window-modal; we hope to convert them over soon.

The fate of tab modal sheets, however, isn't certain. A way to enforce tab-modal interaction is certainly needed. But is attaching sheets to the tabs the right way to achieve that goal? At the last WWDC, I talked to some graphic designers who were opposed to the idea. "Reusing sheets in a context that isn't window modality will only confuse the user!" On the other hand, my position is that the concept of modality is the same, and the context is similar enough that users will find that sheets help them understand the modality in which they must interact.

So the story isn't over. Tab-modal sheets are our contribution to the ongoing discussion, an experiment to see what works and what doesn't. Together we can work out the best way to help users interact with their computers.

Posted by Avi Drissman, Software Engineer