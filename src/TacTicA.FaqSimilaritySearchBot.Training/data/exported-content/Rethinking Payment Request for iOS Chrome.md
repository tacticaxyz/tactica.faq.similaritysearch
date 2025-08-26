URL:https://blog.chromium.org/2020/01/rethinking-payment-request-for-ios.html
# Rethinking Payment Request for iOS Chrome
- **Published**: 2020-01-29T09:04:00.000-08:00
The [Payment Request API](https://www.w3.org/TR/payment-request/) is a web standard to make it easier for web developers to build low-friction and secure payment flows. The browser facilitates the flow between a merchant website and “payment handlers”. A payment handler can be built-in to the browser, a native app installed on the user’s mobile device, or a [Progressive Web App](https://developer.mozilla.org/en-US/docs/Web/Progressive_web_apps). Today, developers can use the Payment Request API to access several payment methods, including “[basic-card](https://www.w3.org/TR/payment-method-basic-card/)” in Chrome on all platforms, Google Pay in Chrome on Android, and Apple Pay in Safari. The Chrome team continues to work with other browser vendors and digital wallet developers to make more payment handlers available with this new standard.

  

Shipping the Payment Request API over the last two years helped us better understand the challenges in building payment flows on the web. We learned that UX is critical for building user trust with a payment app, and new technology such as tokenization has made great strides in protecting users from online fraud by never exposing a user’s credit card number to a website. Unfortunately, Chrome’s built-in payment handler for “basic-card” falls short on both regards. As we considered solutions, we realized that the best way to enable more seamless and secure payments on the web is to enable an interoperable ecosystem, where digital wallets can bring their best experience to the web. This means shifting focus to the [Payment Handler API](https://w3c.github.io/payment-handler), which is an emerging W3C standard that allows 3rd party payment handlers, which can be either native mobile apps or progressive web apps, to integrate with the browser to handle Payment Requests. This enables users to complete one-click payments anywhere on the web using their wallet of choice.

  

This shift in focus means that we will eventually sunset Chrome’s built-in “basic-card” payment handler. We will start by removing “basic-card” support from iOS Chrome, where this feature has the least usage. This change is coming in M81. In its place, we are investigating how to enable native apps on iOS to integrate with Payment Request API in Chrome. The “basic-card” payment method remains a W3C standard and developers can build compatible payment handlers using the Payment Handler API by setting method to “basic-card” when [registering a payment handler](https://developers.google.com/web/fundamentals/payments/payment-apps-developer-guide/web-payment-apps#set_a_payment_instrument) with the browser.

  

This M81 change will deactivate Payment Request API on iOS Chrome because “basic-card” is the only supported payment method and because payment handlers are unavailable due to the lack of Payment Handler API support in WKWebView. If you’re a developer that uses Payment Request API, please make sure you use [feature detection](https://developers.google.com/web/fundamentals/payments/merchant-guide/deep-dive-into-payment-request#feature_detect) and provide a suitable fallback to ensure iOS users continue to have a working alternative. This is also needed to ensure your website works as expected in browsers that don’t yet support Payment Request API.

  

If you are a payment app developer, please check out our tutorials on [how to integrate as a native payment handler on Android](https://developers.google.com/web/fundamentals/payments/payment-apps-developer-guide/android-payment-apps) and [how to integrate as a web-based payment handler via the Payment Handler API](https://developers.google.com/web/fundamentals/payments/payment-apps-developer-guide/web-payment-apps).

If you have feedback on Chrome’s web payments implementations, you can reach us at [paymentrequest@chromium.org](mailto:paymentrequest@chromium.org). If you have feedback on the web payment API specifications, find us at the [W3C Web Payments Working Group](https://www.w3.org/Payments/WG/).

  
Posted by Danyao Wang, Web Payments Engineer