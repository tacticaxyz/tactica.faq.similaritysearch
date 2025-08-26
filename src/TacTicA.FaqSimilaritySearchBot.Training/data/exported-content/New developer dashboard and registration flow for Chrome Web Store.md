URL:https://blog.chromium.org/2020/03/new-developer-dashboard-and.html
# New developer dashboard and registration flow for Chrome Web Store
- **Published**: 2020-03-12T09:36:00.000-07:00
Today we’re announcing two significant changes that affect the developer experience when publishing on the [Chrome Web Store](https://chrome.google.com/webstore). The new developer dashboard is now the default experience, and the developer registration flow has changed.  
  

### New dashboard is now the default

We recently launched a new developer dashboard for Chrome Web Store developers to try out. Following a period of feedback and improvement, we’re announcing that this new dashboard is now the preferred dashboard. This dashboard appears by default on the following events:  

* When you click **Settings > Developer Dashboard** on the Chrome Web Store home page.
* When you follow existing bookmarks or links to the [developer dashboard](https://chrome.google.com/webstore/developer/dashboard).
* When you navigate explicitly to chrome.google.com/webstore/developer/dashboard.

You can opt out of the default behavior by clicking **Show more**… in the small dialog at the bottom left-hand corner of the new dashboard, then clicking opt out:  
  

![](https://lh3.googleusercontent.com/9UZMDhURAHMgr2xHAIaQmrsrSAOcfVf3m8Ym9jpONTPx03CsDIOPDQ1M4bmyKK-N7mlT9WGvW5jAkRxbQku2Cs7495snlJ_inVA559yEOj8ck3torEPKeZxCsPYyBNNLsCQB1NBl)

Opting out means that you’ll see the old dashboard in each of the cases listed above. You can always opt in again by clicking the link in the old dashboard’s banner:

  

![](https://lh6.googleusercontent.com/5SJwcGDe0aNqhpGsGmCfXaSGAxFgoRoM6JZWr2RqcOUyfJoQpoxlSNZ1qV4vu1OYMI5qIpPhHaRMZGL2QQtzWuTxQMKHlMqrpUGqFWMiFDCw5GLAGyzW3N1dZrlqJOMcEmzb_u5N)

Opting out is useful for specific use cases that affect a small number of developers. The new dashboard does not yet support the following tasks:

* Transfer items
* Edit or publish a paid item, or add in-app purchases, using Chrome Web Store Payments
* View an item’s public key
* Re-order screenshots
* Preview a new version of your item or promotional tiles
* View revenue stats

For more details and status on these features see the [known issues document](https://docs.google.com/document/d/e/2PACX-1vQi3OH0AE53rgDO1DSSRqLdH0h7790hPKiIHGlayLfhDGyEZWZLmxBQVNuSE4JFR3uj3fjRGY2lOK2J/pub).  
  

### Developer registration fee now required earlier

The Chrome Web Store charges a $5.00 fee to register as a Chrome Web Store developer. This fee was previously required only before publishing an item to the public, but is now required for all Chrome Web Store developers.  
  
Who does this affect?   
  

* Developers who **previously published items to the public** were required to pay the registration fee at that time. These developers do not need to pay the fee again: **no action is required.**
* **New developers** must [register and pay this fee](https://developer.chrome.com/webstore/register) before they can use the Chrome Web Store developer dashboard.
* Previously registered **developers** **who have never published an item to the public** must now pay this fee before they can use the CWS developer dashboard. If you have published to private domain or to trusted testers, but not to the public, you will now need to pay the registration fee. *Note: This will look like a [new developer registration](https://developer.chrome.com/webstore/register) flow, but all that’s required is to pay the fee and complete the flow*.

  
Posted by Shumeng Gu, Chrome Web Store Engineer