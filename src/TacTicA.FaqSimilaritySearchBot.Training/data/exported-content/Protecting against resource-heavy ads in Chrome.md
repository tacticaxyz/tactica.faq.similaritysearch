URL:https://blog.chromium.org/2020/05/resource-heavy-ads-in-chrome.html
# Protecting against resource-heavy ads in Chrome
- **Published**: 2020-05-14T09:20:00.000-07:00
Chrome is developed to be fast and responsive without harmful or annoying experiences. Recently, following the [Better Ads Standards](https://www.betterads.org/standards/), we have taken steps to address ads that most people find unacceptable. Prior to that, we also launched a set of protections against [abusive experiences](https://blog.chromium.org/2018/11/further-protections-from-harmful-ad.html) in Chrome.  

We have recently discovered that a fraction of a percent of ads consume a disproportionate share of device resources, such as battery and network data, without the user knowing about it. These ads (such as those that mine cryptocurrency, are poorly programmed, or are unoptimized for network usage) can drain battery life, saturate already strained networks, and cost money.

In order to save our users’ batteries and data plans, and provide them with a good experience on the web, Chrome will limit the resources a display ad can use before the user interacts with the ad. When an ad reaches its limit, the ad's frame will navigate to an error page, informing the user that the ad has used too many resources. Here is an example of an ad that has been unloaded:

![](https://lh5.googleusercontent.com/urkFgM0cxX7_D04eaYtcy5_4tfKorlegizrsFFsjhIfiyyW6BYWcjqENe7_RVAvHlQ4GCEccz19eVCkIf1Jr_z5kq4WKLwr5QM6oV-53kl4QNBLvO4qyQT5nn3JAeNePaywncS2X)

To determine the threshold limits for the unloading, we extensively measured the ads Chrome sees. We targeted the most egregious ads, those that use more CPU or network bandwidth than 99.9% of all detected ads for that resource. Chrome is setting the thresholds to 4MB of network data or 15 seconds of CPU usage in any 30 second period, or 60 seconds of total CPU usage. While only 0.3% of ads exceed this threshold today, they account for 27% of network data used by ads and 28% of all ad CPU usage.

![](https://lh3.googleusercontent.com/2FruoINcpABRGu0WRr7NyQVegnGQxADVJwYCueTT9N8CXvC6mSiZFUDd1bS5uJbSC9Xz4TTIsc78XPjDPmJziycwnYF-kvlh0rZzRQA60UYo8oPi_SVi4g62OrF3x7xpVzsT-Dw5 "Heavy Ads Resource Usage")

The overall percentage of heavy and non-heavy ads and the total resource usage of each

We intend to experiment with this over the next several months, and to launch this intervention on Chrome stable near the end of August. Our intent with this extended rollout is to give appropriate time for ad creators and tool providers to prepare and incorporate these thresholds into their workflows. To help advertisers understand the impact of this intervention on their ads, they can [access reports](https://developers.google.com/web/updates/2020/05/heavy-ad-interventions) to learn which ads Chrome unloaded.

With these changes, Chrome is continuing to help ensure that people have good browsing experiences both on the screen and behind the scenes.

Posted by Marshall Vale, Product Manager, Chrome