URL:https://blog.chromium.org/2010/06/in-open-for-rlz.html
# In The Open, For RLZ
- **Published**: 2010-06-02T10:54:00.000-07:00
When we [released](http://chrome.blogspot.com/2010/03/polyglot-google-chrome-beta-with-new.html) a new stable version of Google Chrome last March, we tried to improve the transparency and [privacy](http://www.google.com/chrome/privacy) options of Google Chrome. One area where we’ve seen a lot of interest and questions is the [RLZ](http://code.google.com/p/rlz/) library that is built into Google Chrome. RLZ gives us the ability to accurately measure the success of marketing promotions and distribution partnerships in order to meet our contractual and financial obligations. It assigns non-unique, non-personally identifiable promotion tracking labels to client products; these labels sometimes appear in Google search queries in Google Chrome.

Documenting Google Chrome’s use of promotional tags and tokens was a good start, but we wanted to take this transparency a step further. Our goal was to not only show you exactly how we were sending distribution information, but also what information was included and how it was generated.

Today, we’ve open-sourced the code that generates the RLZ parameter that sometimes appears in Google search queries. We’ve made the RLZ library its own [project](http://code.google.com/p/rlz/) on the Google Code site, since this is the same library that is used in other Google products. This is analogous to how we opened [Omaha](http://code.google.com/p/omaha/), the Google Updater technology, as its own open-source project.

Chromium will also continue to exist as it always has, without any RLZ library included. And, you can still download a Google Chrome with no RLZ behavior at www.google.com/chrome. But now that RLZ is open, Google Chrome distributed through promotional means will include this open-source implementation of RLZ.

It is our hope that we are not only opening up a previously-closed part of Google Chrome and providing better transparency, but that we’re also offering up potentially useful code to others who may use it in their own projects.

We know this is just a small step, but we think that the RLZ project will provide better transparency and value to the community. We want to hear what you think, so please keep the feedback coming!

Posted by Roger Tawa, Software Engineer, and Glenn Wilson, Product Manager