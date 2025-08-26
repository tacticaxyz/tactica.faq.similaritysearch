URL:https://blog.chromium.org/2021/01/limiting-private-api-availability-in.html
# Limiting Private API availability in Chromium
- **Published**: 2021-01-15T10:00:00.001-08:00
During a recent audit, we discovered that some third-party Chromium based browsers were able to integrate Google features, such as Chrome sync and Click to Call, that are only intended for Google’s use. This meant that a small fraction of users could sign into their Google Account and store their personal Chrome sync data, such as bookmarks, not just with Google Chrome, but also with some third-party Chromium based browsers. We are limiting access to our private Chrome APIs starting on March 15, 2021.

For users who accessed Google features (like Chrome sync) through a third-party Chromium based browser, their data will continue to be available in their Google Account, and data that they have stored locally will continue to be available locally. As always, users can view and manage their data on the [My Google Activity page](https://myactivity.google.com/myactivity?pli=1). They can also download their data from the [Google Takeout page](https://takeout.google.com/?pli=1), and/or delete it [here](https://chrome.google.com/sync).

Guidance for vendors of third-party Chromium based products is available on the [Chromium wiki](https://www.chromium.org/developers/how-tos/api-keys).

Posted by Jochen Eisinger, Engineering Director, Google Chrome