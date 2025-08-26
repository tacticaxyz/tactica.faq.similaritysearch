URL:https://blog.chromium.org/2021/10/sunsetting-basic-card-payment-method-in.html
# Sunsetting the "basic-card" payment method in the Payment Request API
- **Published**: 2021-10-21T00:59:00.004-07:00
The [Payment Request API](https://www.w3.org/TR/payment-request/) is a [soon-to-be-recommended](https://www.w3.org/blog/news/archives/9269) web standard that aims to make building low-friction and secure payment flows easier for developers. The browser facilitates the flow between a merchant website and "[payment handlers](https://web.dev/web-based-payment-apps-overview/#apis-you-can-use-inside-the-payment-handler-window)". A payment handler can be built-in to the browser, a native app installed on user’s mobile device, or a [Progressive Web App](https://developer.mozilla.org/en-US/docs/Web/Progressive_web_apps). Today, developers can use the Payment Request API to access several payment methods, including “[basic-card](https://www.w3.org/TR/payment-method-basic-card/)” and Google Pay in Chrome on most platforms, Apple Pay in Safari, [Digital Goods API](https://developer.chrome.com/docs/android/trusted-web-activity/receive-payments-play-billing/) on Google Play, and [Secure Payment Confirmation](https://github.com/w3c/secure-payment-confirmation/blob/main/explainer.md) in Chrome.

  

Earlier last year, [we announced](https://blog.chromium.org/2020/01/rethinking-payment-request-for-ios.html) that we will deprecate the "basic-card" payment handler on iOS Chrome, followed by other platforms in the future. The "basic-card" is a payment method that is typically built into the browser to help users easily enter credit card numbers without remembering and typing them. This was designed to make a good transition from a form based credit card payment to an app based tokenized card payment. In order to better pursue the goal of app based payment (and [a few other reasons](https://lists.w3.org/Archives/Public/public-payments-wg/2021Aug/0020.html)), the Web Payments WG [decided to remove it from the specification](https://lists.w3.org/Archives/Public/public-payments-wg/2021Aug/0038.html).

  

Starting from version 96, Chrome will show a warning message in DevTools Console (together with creating a report to Reporting API) when the "basic-card" payment method is used. In version 100, the "basic-card" payment method will be no longer available and [canMakePayment()](https://web.dev/how-payment-request-api-works/#check-whether-the-payment-method-is-available) will return false unless other capable payment methods are specified. This applies to all platforms including Android, macOS, Windows, Linux, and Chrome OS.

  

If you are using the Payment Request API with the "basic-card" payment handler, we suggest removing it as soon as possible and using an alternative payment method such as Google Pay or Samsung Pay.

Posted by Eiji Kitamura, Developer Advocate on the Chrome team