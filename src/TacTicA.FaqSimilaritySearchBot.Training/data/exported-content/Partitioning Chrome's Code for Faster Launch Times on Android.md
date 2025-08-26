URL:https://blog.chromium.org/2021/11/chrome-android-faster-launch-times-less-memory.html
# Partitioning Chrome's Code for Faster Launch Times on Android
- **Published**: 2021-11-16T09:00:00.048-08:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi_eTPCgvctptMUoaEQFYiazoT2yt8d2c1HP0Kyd8zjU-myIYnMhOQyyyHK7gRHC_beCFhaYt0tXfnAOadUR3G9yZFJT9xX4b0wvZE7ny30MWQonXpD9oVvNccCoecbck3GwBwMIGRHdGlv/w667-h277/image1.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi_eTPCgvctptMUoaEQFYiazoT2yt8d2c1HP0Kyd8zjU-myIYnMhOQyyyHK7gRHC_beCFhaYt0tXfnAOadUR3G9yZFJT9xX4b0wvZE7ny30MWQonXpD9oVvNccCoecbck3GwBwMIGRHdGlv/s1999/image1.jpg)  
  
*Mobile devices are generally more resource constrained than laptops or desktops. Optimizing Chrome’s resource usage is critical to give mobile users a faster Chrome experience. As we’ve added features to Chrome on Android, the amount of Java code packaged in the app has continued to grow. In this [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post we show how our team improved the speed and memory usage of Chrome on Android with Isolated Splits. With these improvements, Chrome on Android now **uses 5-7% less memory, and starts and loads pages even faster than before.***  
  

The Problem
===========

For Android apps (including Chrome on Android), compiled Java code is stored in [.dex files](https://source.android.com/devices/tech/dalvik/dex-format). The user's experience in Chrome on Android is particularly sensitive to increases in .dex size due to its [multi-process architecture](https://developers.google.com/web/updates/2018/09/inside-browser-part1#browser-architecture). On Android, Chrome will generally have 3+ processes running at all times: the browser process, the GPU process, and one or more renderer processes. The vast majority of Chrome’s Java code is used only in the browser process, but the performance and memory cost of loading the code is paid by all processes.

Bundles and Feature Modules
===========================

Ideally, we would load the smallest chunk of Java necessary for a process to run. We can get close to this by using [Android App Bundles](https://developer.android.com/guide/app-bundle) and splitting code into [feature modules](https://developer.android.com/guide/playcore/feature-delivery). Feature modules allow splitting code, resources, and assets into distinct [APKs](https://source.android.com/setup/start/glossary#apk) installed alongside the base APK, either on-demand or during app install.  
  
Now, it seems like we have exactly what we want: a feature module could be created for the browser process code, which could be loaded when needed. However, this is not how Android loads feature modules. By default, all installed feature modules are loaded on startup. For an app with a base module and three feature modules “a”, “b”, and “c”, this gives us an Android [Context](https://developer.android.com/reference/android/content/Context) with a [ClassLoader](https://developer.android.com/reference/java/lang/ClassLoader) that looks something like this:  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg5ToLkPUoIoeIlBiTgDz9VheKZPfx6416hVZybfNRAS56KROGcSi5l9iaLbRSu-hBvVEfrhewznscqVP1oReCvFsDBeeRNvh9ZWMJD2gcr-BvrV2JQ2RuWZ7V-SNb26ZwW0ktUXR3iFN3K/w658-h438/image1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg5ToLkPUoIoeIlBiTgDz9VheKZPfx6416hVZybfNRAS56KROGcSi5l9iaLbRSu-hBvVEfrhewznscqVP1oReCvFsDBeeRNvh9ZWMJD2gcr-BvrV2JQ2RuWZ7V-SNb26ZwW0ktUXR3iFN3K/s1999/image1.png)  
  
  
Having a small minimum set of installed modules that are all immediately loaded at startup is beneficial in some situations. For example, if an app has a large feature that is needed only for a subset of users, the app could avoid installing it entirely for users who don't need it. However, for more commonly used features, having to download a feature at runtime can introduce user friction -- for example, additional latency or challenges if mobile data is unavailable. Ideally we'd be able to have all of our standard modules installed ahead of time, but loaded only when they're actually needed.

Isolated Splits to the Rescue
=============================

A few days of spelunking in the Android source code led us to the [android:isolatedSplits](https://developer.android.com/reference/android/R.attr#isolatedSplits) attribute. If this is set to “true”, each installed split APK will not be loaded during start-up, and instead must be loaded explicitly. This is exactly what we want to allow our processes to use less resources! The ClassLoader illustrated above now looks like this:  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjRY3-zoPoxnBcXGmyM1IkZjFpvI9In9vIuzhGiamzSWOGM-Olt5grMUqpK7DgUpn7LhQBxAxB0DWJ6xwkmQPOzTs5Xard0wtvE_HHoVivRQVYVnf8NZv_eEzJqCTeIbZGBs60-s5t9DH5q/w652-h434/image3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjRY3-zoPoxnBcXGmyM1IkZjFpvI9In9vIuzhGiamzSWOGM-Olt5grMUqpK7DgUpn7LhQBxAxB0DWJ6xwkmQPOzTs5Xard0wtvE_HHoVivRQVYVnf8NZv_eEzJqCTeIbZGBs60-s5t9DH5q/s1999/image3.png)  
  
  
In Chrome’s case, the small amount of code needed in the renderer and GPU processes can be kept in the base module, and the browser code and other expensive features can be split into feature modules to be loaded when needed. Using this method, we were able to reduce the .dex size loaded in child processes by 75% to ~2.5MB, making them start faster and use less memory.  
  
This architecture also enabled optimizations for the browser process. We were able to improve startup time by preloading the majority of the browser process code on a background thread while the Application initializes leading to a 7.6% faster load time. By the time an Activity or other component which needed the browser code was launched, it would already be loaded. By optimizing how features are allocated into feature modules, features can be loaded on-demand which saves the memory and loading cost until the feature is used.

Results
=======

Since [Chrome shipped with isolated splits in M89](https://blog.chromium.org/2021/03/advanced-memory-management-and-more.html) we now have several months of data from the field, and are pleased to share significant improvements in memory usage, startup time, page load speed, and stability for all Chrome on Android users running Android Oreo or later:  

* Median total memory usage improved by 5.2%
* Median renderer process memory usage improved by 7.9%
* Median GPU process memory usage improved by 7.6%
* Median browser process memory usage improved by 1.2%
* 95th percentile startup time improved by 7.6%
* 95th percentile page load speed improved by 2.3%
* Large improvements in both browser crash rate and renderer hang rate

Posted by Clark Duvall, Chrome Software Engineer  
  
*Data source for all statistics: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.*

  