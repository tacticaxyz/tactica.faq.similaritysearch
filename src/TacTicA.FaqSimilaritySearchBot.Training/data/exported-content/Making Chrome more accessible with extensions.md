URL:https://blog.chromium.org/2010/06/making-chrome-more-accessible-with.html
# Making Chrome more accessible with extensions
- **Published**: 2010-06-30T10:39:00.000-07:00
Personalizing the web to match the needs and abilities of users is a big part of improving overall web accessibility. While we continue to [work hard](http://dev.chromium.org/developers/design-documents/accessibility) on making core Google Chrome more accessible, we're really excited about using browser extensions to improve the accessibility of the web for millions of users.  
  
There are already [some extensions](https://chrome.google.com/extensions/featured/accessibility) among the more than 5,000 in the [gallery](https://chrome.google.com/extensions) that can benefit users with special needs. Some of these extensions use Chrome APIs and content scripts to alter the browser and manipulate the DOM of pages, offering users almost unlimited flexibility for viewing the web. Other extensions choose to implement altenative workflows, instead of adapting existing web page UIs, to give users faster access to content. These extensions benefit not just users of assistive technologies like screen readers but everyone who prefers access modes like keyboard shortcuts and captions.  
  
If you are interested in making your extensions more accessible, we’ve created a new [Accessibility implementation guide](http://code.google.com/chrome/extensions/a11y.html) in the Chrome Extensions [Developer's Guide](http://code.google.com/chrome/extensions/devguide.html) that gives you an overview of accessibility best practices such as keyboard navigation, color contrast and text magnification. We’ve also [open sourced](http://code.google.com/p/google-axs-chrome/) the code behind [ChromeVis](https://chrome.google.com/extensions/detail/halnfobaneppemjnonmmhngbfifnafgd), a new extension for users with low vision, so that you can use some of its code for manipulating text selection and magnification in your own extensions.  
  
  
  
Already the NPR team has implemented some accessibility best practices in their [extension](https://chrome.google.com/extensions/detail/hcamfjcklnmlbokoackecfjidfjafgog). We hope to see more extensions adopting them. From our end, we're sponsoring a [Summer of Code project](http://github.com/ankit/stylebot) to produce an extension that helps users produce custom style sheets and plan to create additional extensions that make navigating the web through Chrome easier.  
  
We've also set up a [Google Moderator topic](http://www.google.com/moderator/#16/e=145cf) where everyone can submit ideas for extensions that improve web accessibility. We hope these ideas will inspire extensions developers who are looking to create something useful for the community.  
  
Stay tuned for future updates about Chrome Extensions and accessibility!  
  
Posted by Rachel Shearer, Software Engineer 