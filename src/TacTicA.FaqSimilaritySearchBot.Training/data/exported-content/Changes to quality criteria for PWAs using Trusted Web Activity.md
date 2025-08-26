URL:https://blog.chromium.org/2020/06/changes-to-quality-criteria-for-pwas.html
# Changes to quality criteria for PWAs using Trusted Web Activity
- **Published**: 2020-06-25T10:33:00.000-07:00
Trusted Web Activity will delegate some web app errors to native app crashes beginning in Chrome 86

[Trusted Web Activities](https://developers.google.com/web/android/trusted-web-activity) are Chrome's recommended way to integrate fullscreen Progressive Web App content into an Android app. Unlike a WebView, a Trusted Web Activity is an instance of the Chrome browser and implements a complete and evergreen set of web platform APIs thanks to Chrome auto update. Since the release of Trusted Web Activity, we’ve been working on improving the integration of apps built using a Trusted Web Activity into the native ecosystem with features such as automatically generated splash screens and web notification delegation. 

  

In Chrome 86, we’ll take this integration a step further by delegating web application crash events into native equivalents. 

  

Web apps crash, but they crash differently

Web developers are more used to thinking about “errors” rather than crashes. When a user encounters an HTTP error in their web app journey, such as a 404 or a 5xx error, that’s effectively an application crash. Another example of a web app error that could be considered a crash is when the Chrome dino page appears because the user lost their internet connection and the app didn’t have a handler in the ServiceWorker for an offline resource request. This kind of ServiceWorker handling of errors can be used for 404 and 5xx resource loading errors as well. 

  

Crashes in the Android ecosystem

[Android Vitals](https://developer.android.com/topic/performance/vitals) is an initiative by Google to improve the stability and performance of Android devices. The Google Play [Console](https://play.google.com/console/about/) aggregates Android Vitals data and displays it in the Android vitals [dashboard](https://support.google.com/googleplay/android-developer/answer/7385505). Problems in Android Vitals indicate a low quality user experience in the app and can result in bad ratings and poor discoverability on the Play Store.

  

Starting in Chrome 86, Chrome will integrate critical web application crashes into native app crash events and Android Vitals. As this change will cause user facing crashes if these events are unhandled, developers using or planning to use a Trusted Web Activity should review this post carefully.

  

Critical web application crashes that will be delegated in Chrome 86 are: 

  

1. an HTTP 404 or 5xx error in the application
2. failure to return HTTP 200 for an offline network resource request
3. failure to verify digital asset links at application launch

  

In this article we’ll provide more details on the exception conditions, impact on the application behavior and how to avoid these exceptions. 

Why is Chrome making this change?
=================================

Users installing an Android application from the Play Store expect the application to look and feel native. Native applications do not have a 404 or 5xx error page. Native applications are expected to handle internet service interruptions, at a minimum by providing a branded offline indicator. Finally, when digital asset links fail to verify, we cannot verify that the app owner is also the owner of the web content. Previously, this circumstance resulted in a fallback from Trusted web Activity to a CCT view. In practice we’ve found that a CCT fallback does not meet user expectations. Furthermore, the silent fallback bypasses a feedback mechanism (a Play console crash report) that is important for developers to understand what’s going wrong with their application. 

  

By integrating crash events into Android Vitals, Android app developers using Trusted Web Activity can make use of the Android Vitals [dashboard](https://support.google.com/googleplay/android-developer/answer/7385505) to view information about the user experience of their app. This approach also rewards developers building high quality apps, since apps with better scores in Android vitals have better discoverability in the Play store. 

How will this work and what should I do about it?
=================================================

The table below details the web application crash triggers, the corresponding action and recommended mitigations. The Trusted Web Activity crash event will include a log message viewable in the Android Console with details about which trigger caused the exception and the URL at which the exception occurred to facilitate debugging. 

  

|  |  |  |
| --- | --- | --- |
| Exception trigger | Action | Recommended mitigations |
| HTTP 404 or 5xx error code returned on HTTP request for the main document to a trusted origin | Exception raised by the Trusted Web Activity | * Make sure your app doesn’t have 404 or 5xx errors * Use a ServiceWorker and handle 404 or 5xx errors using a ServiceWorker fetch event [fallback response](https://googlechrome.github.io/samples/service-worker/fallback-response/) |
| Failure to return HTTP 200 on an HTTP request for the main document to a trusted origin when offline | * Use a ServiceWorker * Handle offline resource requests using a ServiceWorker [[tutorial](https://developers.google.com/web/fundamentals/codelabs/offline)] |
| Digital assetlinks verification failure    (excludes failures when offline) | * Review the Trusted Web Activity [quick start guide](https://developers.google.com/web/android/trusted-web-activity/quick-start) for how to correctly implement Digital Assetlinks |
| TLS verification failure on a trusted origin | * Ensure your TLS certificate is valid |

  

Handling exceptions with native code
====================================

Exceptions raised by a Trusted Web Activity can also be handled using Android exception handling. However, consider avoiding these exceptions altogether with the mitigations recommended in the table above. 

  

First, the Trusted Web Activity exception will cause Chrome to exit. Even if the  exception is handled, it will still be a janky user experience. 

  

Second, implementing the mitigations in the web app will improve the experience of all users of your PWA in all web browsers. 

Future Android Vitals integrations
==================================

Over time, we will continue to add integrations of important web application events into Android Vitals to make the user experience of web applications more consistent with native applications. 

  

For example, app startup time, battery usage, permission denials or [App Not Responding](https://developer.android.com/topic/performance/vitals/anr) (ANR) events.

A reminder about Trusted Web Activity quality criteria
======================================================

1. Policies. Android apps using Trusted Web Activity must comply with all Play store policies, including for web content in the Trusted Web Activity, including policies for payments in-app purchases and other digital goods.
2. To ensure the quality of experience, content in a Trusted Web Activity must meet PWA installability criteria and load fast at the start URL. Loading speed is measured using [Lighthouse](https://developers.google.com/web/tools/lighthouse/) at the Trusted Web Activity start URL and must achieve a performance score of 80.

  

[Lighthouse](https://developers.google.com/web/tools/lighthouse/) is an open-source, automated tool for auditing performance & progressive web apps and is useful both as a benchmark and to help you build better websites. 

Helping developers build a high quality trusted web activity
============================================================

Since the release of Trusted Web Activity, we’ve created the open source utility library [Bubblewrap](https://github.com/GoogleChromeLabs/bubblewrap), which helps developers build high quality Android applications using their Progressive Web App. The Trusted Web Activity [quick start guide](https://developers.google.com/web/android/trusted-web-activity/quick-start) helps developers new to Trusted Web Activity and Bubblewrap get going fast. 

  

We are continuously improving Bubblewrap, adding tools and scaffolds to make it easy for developers to build high quality Android apps using Trusted Web Activity and to provide build time warnings for common mistakes. 

Posted by PJ McLachlan, Product Manager