URL:https://blog.chromium.org/2019/10/automatically-lazy-loading-offscreen.html
# Automatically lazy-loading offscreen images & iframes for Lite mode users
- **Published**: 2019-10-24T09:00:00.000-07:00
In Chrome 76, we introduced [native lazy-loading](https://web.dev/native-lazy-loading) for images and iframes via the `loading` attribute - a developer opt-in. In Chrome 77, Chrome Android users with  [Lite Mode](https://blog.chromium.org/2019/04/data-saver-is-now-lite-mode.html) (Data Saver) enabled will benefit from native lazy-loading of images and iframes [automatically](https://chromestatus.com/feature/4969496953487360).

  

![](https://lh6.googleusercontent.com/i2UfbjUx9E4OFGc6lqmH_qF3RwKw5yKu3VecpcdDM0znXUGFCSmHAx8IHcGi_NXOfCPVny7wmAmgXl1k5i3Nacm7gg4hbe22KFog8f4Yf-g1uJLb_pq6hSC0c_3qL_1EvWwf7ETQ)

  

Lite mode has allowed Chrome to reduce users’ data usage by up to 60 percent, often by compressing the pages users request before downloading them.


  

Web pages commonly have images or embedded content that is out-of-view near the bottom of the page, and users typically don’t scroll all the way down to discover them. Today, devices need to use resources loading this content, which is challenging for users on a limited data-plan or with a spotty network connection.


  

When a user has Lite Mode enabled on Chrome for Android, Chrome will defer the load of below-the-fold images and iframes until the user scrolls near them. This is done without requiring developer action. Automatic lazy-loading helps to reduce network data use and memory use. It may also increase site speed, by prioritizing content visible to the user.


  

In our experiments, native lazy-loading of images and iframes yields a ~10% reduction in bytes downloaded per page at the 75th percentile and an 8% reduction in overall downloaded bytes for the median user. Automatic lazy-loading also led to a 1-2% improvement in First Contentful Paint at the median, a 2% improvement in First Input Delay at the 95th percentile and a 0.7% improvement in median memory reduction per page. We expect increased benefits as we tune the feature.


  

Chrome’s native lazy-loading has different distance thresholds after which deferred content will start loading, based on factors such as the [effective connection type](https://developer.mozilla.org/en-US/docs/Web/API/NetworkInformation/effectiveType). This distance is chosen so that content we’ve deferred almost always completes loading by the time it becomes visible.


  

Any <iframe> or <img> with the `loading` attribute value of `auto` will also be eligible for Lite Mode’s automatic lazy-loading. This includes <picture> elements and CSS background images.


  

It is important to note that automatic lazy-loading of images and iframes is only done if a user has Lite Mode enabled. Lite Mode is most heavily used in areas of the world with poor and expensive connectivity and we believe it is users in these regions that will benefit the most from the feature. Sites wishing to learn what percentage of users have Lite Mode turned on can monitor truthy values from the  [SaveData](https://developer.mozilla.org/en-US/docs/Web/API/NetworkInformation/saveData) JavaScript API in their analytics.

  
  
  

To enable Lite mode, select Settings > Lite mode and toggle the setting to On. We look forward to this feature helping users keep their page loads just a little bit lighter.

  
  

Posted by Addy Osmani, Scott Little and Raj T - lazy Chrome engineers.