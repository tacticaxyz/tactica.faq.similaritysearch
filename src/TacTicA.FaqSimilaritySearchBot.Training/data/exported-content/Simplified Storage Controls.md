URL:https://blog.chromium.org/2021/11/simplified-storage-controls.html
# Simplified Storage Controls
- **Published**: 2021-11-18T13:51:00.045-08:00
Posted by Theodore Olsauskas-Warren

At Chrome, we’re always looking for ways to help users better understand and manage privacy on the web. Our most recent change provides more clarity on controlling site storage settings.

Starting today, we will be rolling out this change to M97 Beta, we will be re-configuring our Privacy and Security settings related to data a site can store (e.g. cookies). Users can now delete all data stored by an individual site by navigating to Settings > Privacy and Security > Site Settings > View permissions and data stored across files, where they’ll land on **chrome://settings/content/all**. We will be removing the more granular controls found when navigating to Settings > Privacy and Security > Cookies and other site data > See all cookies and site data at **chrome://settings/siteData** from Settings. This capability remains accessible for developers, the intended audience for this level of granularity, in DevTools.

|  |
| --- |
|  |
| |  | | --- | | OLD: We are removing this page. The controls for web-facing storage are now available at **chrome://settings/content/all** | |  |

|  |
| --- |
|  |
| |  | | --- | | NEW: Here, in **chrome://settings/content/all**, users will be able to delete web-facing storage. | |  |

#### Why the change?

We believe that simplifying the granular controls from Settings creates a clearer experience for users. By providing users the ability to delete individual cookies, they can accidentally change the implementation details of the site and potentially break their experience on that site, which can be difficult to predict. Even more capable users run the risk of compromising some of their privacy protection, by incorrectly assuming the purpose of a cookie.

We see this functionality being primarily used by developers, and therefore remain committed to provide them with the tools they need in DevTools. Developers can visit DevTools to continue to gain access to more technical detail on a per-cookie or per-storage level as needed.

|  |
| --- |
|  |
| Granular cookie controls remain available in DevTools. |

As always, we welcome your feedback as we continue to build a more helpful Chrome. Our next step is working to remove this functionality from Page Info to keep all granular cookie controls in DevTools. If you have any other questions or comments on Storage Controls, please share them with us [here](https://support.google.com/chrome/answer/95315).