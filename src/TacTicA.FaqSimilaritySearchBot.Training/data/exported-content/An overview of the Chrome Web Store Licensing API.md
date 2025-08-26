URL:https://blog.chromium.org/2010/09/overview-of-chrome-web-store-licensing.html
# An overview of the Chrome Web Store Licensing API
- **Published**: 2010-09-03T12:51:00.000-07:00
We recently released a [developer preview](http://blog.chromium.org/2010/08/get-your-apps-ready-for-chrome-web.html) of the [Chrome Web Store](https://chrome.google.com/webstore), which included new documentation about our upcoming payments and licensing API. With this blog post, we wanted to share a quick overview and some tips about this API so that you can start developing your apps with it.  
  
The Chrome Web Store will offer a built-in payments system that allows you to charge for apps, making it easy for users to pay without leaving the store. If you want to work with this payments system in your apps, you can use the [Chrome Web Store Licensing API](http://code.google.com/chrome/webstore/docs/index.html) to verify whether a given user has paid and should have access to your app. Here’s how the API works:  
  
The Licensing API has two inputs: the app ID and the user ID. The app ID is a unique identifier that’s assigned to each item uploaded to the store. You can see it most easily in the URL of your detail page—for example, .../detail/aihcahmgecmbnbcchbopgniflfhgnkff.  
  
The user ID is the OpenID URL corresponding to the user’s Google Account. You can get the OpenID URL for the current user either by using Google App Engine’s built-in OpenID support or by using a [standard OpenID library](http://code.google.com/chrome/webstore/docs/identify_user.html#resources) and [Google’s OpenID endpoint](http://code.google.com/apis/accounts/docs/OpenID.html#endpoint).  
  
Given the app ID and the user ID, you make Licensing API requests using this URI:  
  
 https://www.googleapis.com/chromewebstore/v1/licenses/<appID>/<userID>  
  
When your app makes an HTTP request to the Licensing API, the app needs to be authenticated. The app is authenticated by matching your Google Account that uploaded the app to the Google Account used to call the API.  
  
There are [a few ways](http://code.google.com/apis/accounts/docs/GettingStarted.html) the app can indicate the Google Account used to make the API call. For the Chrome Web Store Licensing API, we highly recommend the use of [OAuth for Web Applications](http://code.google.com/apis/accounts/docs/OAuth.html). In this approach, OAuth access tokens are used to identify the Google Account calling the API.  
  
You can obtain the necessary token via the [Chrome Developer Dashboard](https://chrome.google.com/extensions/developer/dashboard) by clicking the “AuthToken” link for your app. (This link appears only if your app uses Chrome Web Store Payments.) You’ll need this OAuth token [to sign](http://oauth.net/core/1.0/#signing_process) the HTTP requests to call the Licensing API. The best way to sign your requests is with a [standard OAuth library](http://code.google.com/chrome/webstore/docs/check_for_payment.html#resources).  
  
The OAuth tokens that the Chrome Developer Dashboard provides are limited in scope, which means that they can only be used to make Licensing API calls. They can’t be used to make calls to other authenticated Google APIs or for anything else.  
  
Once you’re ready to make authenticated calls, give the API a try by making your first request. For more information read the [Licensing API docs](http://code.google.com/chrome/webstore/docs/check_for_payment.html), try out the [Getting Started tutorial](http://code.google.com/chrome/webstore/docs/get_started.html), check out the [samples](http://code.google.com/chrome/webstore/docs/samples.html), and watch the video below:  
  
  
  
Note that current version of the Licensing API is a stub, which means that it doesn’t return live data that’s based on purchases just yet. Instead, it returns dummy responses that you can use to verify the various scenarios of your implementation. However the protocol, response format, and URL endpoints of the API are all final, so your implementation shouldn’t need to change before the final launch of the store.  
  
We look forward to receiving your feedback on the current Licensing API implementation at our [developer discussion group](https://groups.google.com/a/chromium.org/group/chromium-apps/).  
  
Posted by Munjal Doshi, Software Engineer 