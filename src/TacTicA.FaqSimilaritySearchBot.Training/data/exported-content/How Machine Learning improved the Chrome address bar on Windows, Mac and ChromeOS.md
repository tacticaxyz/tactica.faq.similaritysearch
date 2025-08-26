URL:https://blog.chromium.org/2024/04/how-machine-learning-improved-chrome.html
# How Machine Learning improved the Chrome address bar on Windows, Mac and ChromeOS
- **Published**: 2024-04-29T09:02:00.000-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhClkamg6fdrq2ffTZT2aDWBPizrm58hqPyzbqm9TUgytSPgOfdsVMfvAhEZ84pGE0hSWbDGTJAyOwnBy6QjggaL9HjozOup7Ytwylo54W7TWsgv1Z-1WQuQvYsdCanl5Lbf2u1glY7K7SHREWTdQCHUl8EysyG-MuwAL0PHfXM_CEYHU7PNESVPSPWZatg/s16000/ML_Scoring_Chromium_Blog_Header.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhClkamg6fdrq2ffTZT2aDWBPizrm58hqPyzbqm9TUgytSPgOfdsVMfvAhEZ84pGE0hSWbDGTJAyOwnBy6QjggaL9HjozOup7Ytwylo54W7TWsgv1Z-1WQuQvYsdCanl5Lbf2u1glY7K7SHREWTdQCHUl8EysyG-MuwAL0PHfXM_CEYHU7PNESVPSPWZatg/s2500/ML_Scoring_Chromium_Blog_Header.png)

  

Used billions of times each day, the Chrome address bar (which we call the “[omnibox](https://www.google.com/url?q=https://www.google.com/googlebooks/chrome/small_18.html&sa=D&source=docs&ust=1714007392139474&usg=AOvVaw3CEYSj2EfF_qN9qSllH3s7)”) is a powerful tool to make searching the web easier, whether you’re trying to quickly [find your tabs or bookmarks](https://blog.google/products/chrome/search-your-tabs-bookmarks-and-history-in-the-chrome-address-bar/), return to a web page you [previously visited](https://blog.google/products/chrome/chrome-address-bar-updates/), or [find information](https://blog.google/products/chrome/google-chrome-update-august-2023/).

With the latest release of Chrome (M124), we’re integrating machine learning models to power the Chrome omnibox on desktop, so that web page suggestions are more precise and relevant to you. In the future, these models will also help improve the relevance scoring of search suggestions. Here’s a closer look at some of the important insights that help our team build this integration and where we hope the new model takes us.

### **How we got here**

As the engineering lead for the team responsible for the omnibox, every launch feels special, but this one is truly near and dear to my heart. When I first started working on the Chrome omnibox, I asked around for ideas on how we could make it better for users. The number one answer I heard was, "improve the scoring system." The issue wasn't that the scoring was bad. In fact, the omnibox often feels magical in its ability to surface the URL or query you want! The issue was that it was *inflexible*. A set of hand-built and hand-tuned formulas did the job well, but were difficult to improve or to adapt to new scenarios. As a result, the scoring system went largely untouched for a long time.

For most of that time, an ML-trained scoring model was the obvious path forward. But it took many false starts to finally get here. Our inability to tackle this challenge for so long was due to the difficulty of replacing the core mechanism of a feature used literally billions of times every day. Software engineering projects are sometimes described as "building the plane while flying it." This project felt more like "replacing all the seats in every plane in the world while they're all flying." The scale was enormous and the changes are felt directly by every user.

This ambitious undertaking would not have been possible without the work of such a talented and dedicated team. There were bumps in the road, walls we had to break through, and unanticipated issues that slowed us down, but the team was driven by a sincere belief in the impact of getting this right for our users.

### **A Surprising Insight**

One of the fun things about working with ML systems is that the training considers *all* the data at a scale that would be difficult to impossible for any individual person or team. And that can lead to surprising insights.

The coolest example of this phenomenon on this project was when we looked at the scoring curve of one particular signal: time since last navigation. The expectation with this signal is that the smaller it is (the more recently you've navigated to a particular URL), the bigger the contribution that signal should make towards a higher relevance score.

And that is, in fact, what the model learned. But when we looked closer, we noticed something surprising: when the time since navigation was very low (seconds instead of hours, days or weeks), the model was *decreasing* the relevance score. It turns out that the training data reflected a pattern where users sometimes navigate to a URL that was not what they really wanted and then immediately return to the Chrome omnibox and try again. In that case, the URL they just navigated to is almost certainly *not* what they want, so it should receive a low relevance score during this second attempt.

In retrospect, this is obvious. And if we had not launched ML scoring, we definitely would have added a new rule to the old system to reflect this scenario. But before the training system observed and learned from this pattern, it never occurred to anyone that this might be happening.

### **The Future**

With the new ML models, we believe this will open up many new possibilities to improve the user experience by potentially incorporating new signals, like differentiating between time of the day to improve relevance. We want to explore training specialized versions of the model for particular environments: for example, mobile, enterprise or academic users, or perhaps different locales.

Additionally, we observe that the way users interact with the Chrome omnibox changes over time and we believe the relevance scoring should change with them. With the new scoring system, we can now simply collect fresher signals, re-train, evaluate, and deploy new models periodically over time.

*By Justin Donnelly, Chrome software engineer*