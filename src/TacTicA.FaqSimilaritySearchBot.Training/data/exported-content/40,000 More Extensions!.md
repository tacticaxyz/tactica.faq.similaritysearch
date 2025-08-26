URL:https://blog.chromium.org/2010/02/40000-more-extensions.html
# 40,000 More Extensions!
- **Published**: 2010-02-01T12:26:00.000-08:00
One thing that got lost in the commotion of the extensions launch is a feature that is near and dear to my heart: Google Chrome 4 now natively supports [Greasemonkey](http://en.wikipedia.org/wiki/Greasemonkey) user scripts. Greasemonkey is a Firefox extension I wrote in 2004 that allows developers to customize web pages using simple JavaScript and it was the inspiration for some important parts of our extension system.

Ever since the beginning of the Chromium project, friends and coworkers have been asking me to add support for user scripts in Google Chrome. I'm happy to report that as of the last [Google Chrome](http://www.google.com/chrome) release, you can install any user script with a single click. So, now you can use [emoticons](http://userscripts.org/scripts/show/67384) on blogger. Or, you can [browse](http://userscripts.org/scripts/show/3400) Google Image Search with a fancy lightbox. In fact, there's over 40,000 scripts on [userscripts.org](http://www.userscripts.org/) alone.

Installation is quick and easy, just like installing an extension. That's because under the covers, the user script is actually converted into an extension. This means that management tasks like disabling and uninstalling work just like they do with extensions.

Note that user scripts are powerful software and have full access to your private data on any web site. So, for example, they could read all your web mail or access your online bank. Be sure to read the comments on any user scripts in order to decide whether you trust the author with this power.

Also keep in mind that some user scripts won't work in Google Chrome yet, because of differences between it and Firefox. Based on some [analysis](http://www.greasespot.net/2009/11/greasemonkey-api-usage.html) that the current maintainers of Greasemonkey did, I expect between 15%-25% of scripts to not work in Google Chrome. If you find such a script, you should consider letting the author know. There may be something he or she can do to easily fix the problem. In the meantime, we'll keep working on [bugs](http://code.google.com/p/chromium/issues/detail?id=18857) on our side to bring our implementation closer to Greasemonkey.

Have fun trying out the thousands of available scripts. And don't worry - If you get bored, there's lots more extensions at Google Chrome's [extension gallery](http://chrome.google.com/extensions).

Posted by Aaron Boodman, Software Engineer