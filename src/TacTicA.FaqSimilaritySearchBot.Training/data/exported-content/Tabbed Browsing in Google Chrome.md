URL:https://blog.chromium.org/2009/01/tabbed-browsing-in-google-chrome.html
# Tabbed Browsing in Google Chrome
- **Published**: 2009-01-06T15:59:00.000-08:00
Tabbed Browsing is a prominent feature of modern browsers. We think it's one of the key elements that makes the browser a window manager for the web. Since we thought of the tab as the "container" element within which all other aspects of the browser lived, we designed the Chrome UI with the tab strip at the very top. But we didn't stop at aesthetic upheaval. As we were designing Google Chrome, we designed our tab strip behavior with an eye to making heavy use efficient. Observing how we were using our existing browsers, we were able to identify some pain points and come up with solutions targeted at fixing them. In this post I'll talk a bit about some of the things we've done.

Ordering

One of the most persistently annoying issues with tabbed browsing was the following situation:

You have a full tab strip and a "hub" page open towards the left of the strip. Perhaps its your RSS reader, or a news site like Google News. You open interesting links in new tabs so you can keep reading through the headlines. The problem is, the new tabs open at the end of the tab strip, beyond many other unrelated tabs that also happen to be open. Sometimes, because of the "many-tab overflow" UIs in existing browsers, the tabs that you are queuing up to read in just a moment may disappear off the end of the strip. In short: finding tabs can sometimes be a challenge.

In addition, when you're done reading one of the articles you opened and close its tab, selection jumps back to the opener. This was one of the [improvements I made](http://weblogs.mozillazine.org/ben/archives/009210.html) to the tab strip in Firefox a couple of years ago, but with some extended use it turns out to not be the best action when there are multiple tabs opened from the same opener. Worse still, when combined with the "overflow" UI I mentioned above, the result was disorienting "bouncing" between the left and right ends of the tabstrip.

What did we do? In Google Chrome, we open tabs opened from links in the background adjacent to their opener tab. This keeps the spatial proximity of related tasks close. So you don't end up with the "bouncing" scenario I just described. We also maintain loose grouping relationships between such related tabs, so that when you are done reading one of several articles opened from a hub page, we shift selection to the next in the group, rather than going back to the hub. We think this makes the news reading use case a lot simpler. We don't persist this group relationship when you switch to an unrelated tab, though, to avoid situations that might lead to unpredictable switching behavior if you move on to a different task.

Cleaning Up

Another common annoyance was related to closing several tabs quickly. In most tab strips, when you close a tab the other tabs expand to fit the space that has just been made available. The upshot of this is that the close boxes of the remaining tabs all move around slightly, which makes it harder to quickly close tabs by clicking in the same spot. Older versions of Firefox solved this by putting the close box in a static position at the end of the tab strip, but [lab research](http://hci.arc.nasa.gov/pages/2007/06/when_two_method.html) showed this approach had usability and discoverability problems for novices not used to tabbed browsing, so the close box was moved into the tab (which now seems to be the standard location for tabbed browsers).

For Chrome, we came up with something a little different. Realizing that maintaining a fixed width for tabs when closing them would keep close buttons aligned under the mouse pointer, we designed a system whereby the tab strip will re-layout when you close a tab to fill the gap left, but not resize the remaining tabs, until you move your mouse away from the tab strip (thus signaling you're done closing tabs).

Open Issues

Based on feedback we've received so far, here are a few areas where our tab strip design needs further improvement:

> Many Tab Overflow
>
> We don't have a complete system for handling many open tabs right now. We let tabs grow infinitely smaller. This ends up looking bad when there are a very large number of tabs open. We chose not to go with an overflow menu or scrolling tab strip like in some other browsers because we think there are other usability problems with those approaches. Specifically, when you implement an overflow solution you generally pick a minimum "readable" width for the tab and overflow tabs when there are too many at that width to fit. The problem is usually that that width seems to be too wide, so there can be unnecessary overflow in conditions where a smaller tab width would have meant all of the tabs would have fit. We also don't really like the drop-down menu approach as it has a spatial disconnect (vertical scanning vs. horizontal tabs) that makes it clumsy to use quickly. In the end, we would like a system that doesn't over-zealously clip tabs out of the tab strip so that people with many tabs can still access their tabs with one click.
>
> Disoriented Anchor Tabs
>
> Opening tabs next to the tab that opened them can mean for some use cases that the behavior of having a few "anchor" tabs positioned at the left edge of the strip is more difficult since tabs opened from them are opened in between. We like the idea of "tab pinning" or "locking" as a solution for this, but haven't invested a lot of time in designing how this might work just yet. There may be some overlap with "startup tabs" in Options.
>
> Restoring Mistakenly Closed Windows
>
> We also don't prompt when you close a window with several tabs. The reason we don't do this is that one of our core design philosophies has been to avoid modal question prompts that interrupt the user when they're trying to get things done (in this case, use a standard window control to close the window). We're aware that the prompt has saved people (including ourselves!) using other browsers from losing tabs, but we have been trying to come up with a more creative system for helping this scenario that doesn't interfere with the window's close button. In recent trunk builds, you'll find that you can re-open a recently closed window from the New Tab Page, and that the "Recently Closed" section of the New Tab Page now spans multiple sessions. This is a good way to "undo" an accidentally closed window, in the same way you can "undo" an accidentally closed tab. To try this out you can get on the [Google Chrome Dev Channel](http://dev.chromium.org/getting-involved/dev-channel/).

In all of these areas we've resisted adding options to control behavior. Keeping our set of options minimal is a good forcing function for us as user interface designers to come up with the right approach, since we never rely on the crutch of making the user decide what we were unable to. Instead, our approach has been to experiment with different behaviors and end up taking the approach that works the best. We are heavy users, and we've designed this user interface for heavy web users, so we hope it scales as well for you as it does for us!

Posted by Ben Goodger, Software Engineer