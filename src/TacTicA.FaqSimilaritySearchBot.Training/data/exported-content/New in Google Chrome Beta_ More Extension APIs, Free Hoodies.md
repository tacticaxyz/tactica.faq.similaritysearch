URL:https://blog.chromium.org/2010/08/new-in-google-chrome-beta-more.html
# New in Google Chrome Beta: More Extension APIs, Free Hoodies
- **Published**: 2010-08-23T18:10:00.000-07:00
Since we launched the Google Chrome extension system, one of the most frequent [requests](http://code.google.com/p/chromium/issues/detail?id=32363) we’ve gotten is to add the ability to integrate with the context menu (the menu that pops up when you right-click on a link, image, or web page).

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhTHcU0L46cmkbSphdk2pEA_Tsvf38xl4e7LxbM8LCVjJU_N4WpmX0Ql0cUu-XCkCXQ0IpQouIctgL6ZOHsq5A8kzQrvSAWyCGBwpYS_3tNt4BAhEO8whb_WbOTc-P_3k0biWC7kDlwHAvf/s400/blog1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhTHcU0L46cmkbSphdk2pEA_Tsvf38xl4e7LxbM8LCVjJU_N4WpmX0Ql0cUu-XCkCXQ0IpQouIctgL6ZOHsq5A8kzQrvSAWyCGBwpYS_3tNt4BAhEO8whb_WbOTc-P_3k0biWC7kDlwHAvf/s1600/blog1.png)

Now in Google Chrome Beta, developers can do just that. The new [context menu API](http://code.google.com/chrome/extensions/beta/contextMenus.html) allows extension developers to register menu items for all pages or for a subset of pages. Developers can also register menu items for specific operations, like right-clicking on an image or movie. For example, you could create an extension that makes it easy for users to share interesting images from images.google.com with their friends on Google Buzz.

Some users have lots of extensions installed. To help these users avoid ending up with gigantic unwieldy context menus, Google Chrome automatically groups multiple menu items from the same extension into a sub-menu.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhRN9rNkx7EHk6vccduSd8r4WUG3wSuscBOcIh5cCTCS1MDG4tHo_xcw9WSOqjVW1Fv49NxZHjgX0f3cJ6OIm6DRWyZtuOi4h3OiRjizQs72sPqQtVY7S5k95GlBP1fi_FW2ULoq0nkzyiq/s400/blog2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhRN9rNkx7EHk6vccduSd8r4WUG3wSuscBOcIh5cCTCS1MDG4tHo_xcw9WSOqjVW1Fv49NxZHjgX0f3cJ6OIm6DRWyZtuOi4h3OiRjizQs72sPqQtVY7S5k95GlBP1fi_FW2ULoq0nkzyiq/s1600/blog2.png)

We’d also like to announce two new experimental APIs. These APIs aren’t quite ready for prime-time yet, but we’re really excited about them and couldn’t wait to get your feedback.

* The [omnibox API](http://code.google.com/chrome/extensions/beta/experimental.omnibox.html) allows extension developers to integrate with the browser’s omnibox. With this API, you can build custom search support for your favorite website, keyboard macros to automate tasks, or even a chat client right into the omnibox.
* The [infobars API](http://code.google.com/chrome/extensions/dev/experimental.infobars.html) allows extension developers to display infobars across the top of a tab. These infobars are built using normal HTML, so they can be heavily customized and interactive.

For the complete list of new extension APIs in Google Chrome beta, [see the docs](http://code.google.com/chrome/extensions/beta/whats_new.html). And [let us know](http://spreadsheets.google.com/viewform?formkey=dFE5RGlTNXBxVDBJTjVYa2p1ZnNVaWc6MQ) if you make something cool. If we like it, we’ll send you a free extensions hoodie and may even feature you in the gallery.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEje_xjV156lgvFBp2tMAMiqaIp61a7y8FRT7XCyXKHufCAv0tIDmVqF_WJ80556TFI-Y4ymfaIX2hPeyA_2WWKwHoaQ7DzS5QXrhIuTDDZIqzS6aePhV-ZcYUp78BAJkgBtm1y5-fZyLPbz/s400/blog3.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEje_xjV156lgvFBp2tMAMiqaIp61a7y8FRT7XCyXKHufCAv0tIDmVqF_WJ80556TFI-Y4ymfaIX2hPeyA_2WWKwHoaQ7DzS5QXrhIuTDDZIqzS6aePhV-ZcYUp78BAJkgBtm1y5-fZyLPbz/s1600/blog3.jpg)

We look forward to seeing what you come up with!

Posted by Aaron Boodman, Software Engineer