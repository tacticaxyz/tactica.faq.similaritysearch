URL:https://blog.chromium.org/2021/01/better-content-sharing-with-custom-tabs.html
# Better content sharing with Custom Tabs
- **Published**: 2021-01-22T08:00:00.001-08:00
[Custom Tabs](https://developers.google.com/web/android/custom-tabs) is a browser feature, introduced by Chrome, that is now supported by most major browsers on Android. It gives apps more control over their web experience, and makes transitions between native and web content more seamless without having to resort to a WebView. Similar to when using the browser, users frequently want to share the content that is rendered inside the Custom Tabs.  
  
Custom Tabs do not provide a default sharing experience and many apps don’t provide a way for users to share content at all. This results in a poor user experience where users must find the share action from the overflow menu in the browser. This action takes the user outside of the app and opens the link in the browser, resulting in decreased app engagement.  
  
In Chrome 88 we're running an experiment to automatically add a default share action in certain scenarios. For example, where an app has not specified its own [Action Button](https://developers.google.com/web/android/custom-tabs/implementation-guide#configure_a_custom_action_button), we will display one in the top bar. Where a site has specified its own top bar Action Button, a default share action is added to the overflow menu.

![](https://lh4.googleusercontent.com/jv6EmH2XrLFGWAz2018Mp_t7yCND-2uuWBYxgVDUynThnIJDJHTnjnMyUHa8DBhgr0KqI0zqye6ngU-vqVCRrdzGiySAzfL8ycrrHiK0RuIYPYeNcQeX-DBikoolXIaMLhuZIXuUzA)

A default Action Button that shares the URL is added to the top bar when the application doesn’t provide one.

### What do I need to do to enable the new default share action button in?

Nothing! The default Action Button will be automatically added to the application, as long as the application doesn’t set its own. Since this change will happen in the browser, it will be automatically applied to all apps using Custom Tabs.

Please note: this is a change in Chrome’s behavior and we hope other browsers will add similar functionality.  
  
  

### How can I opt-out from the share icon showing in my App?

Starting with androidx.browser version 1.3.0, developers can use the [setShareState()](https://developer.android.com/reference/androidx/browser/customtabs/CustomTabsIntent.Builder#setShareState(int)) method from the CustomTabsIntent.Builder to disable the default share:

  

|  |
| --- |
| val customTabsIntent = CustomTabsIntent.Builder()          .setShareState(CustomTabsIntent.SHARE\_STATE\_OFF)          .build(); |

As part of this change, the addDefaultShareMenuItem() and setDefaultShareMenuItemEnabled() methods from CustomTabsIntent.Builder have been deprecated and developers should use setShareState() instead.

  
  

If your application uses Custom Tabs, we’d like to hear your feedback, and you can reach out to us using this form.

Posted by André Bandarra, Developer Relations Engineer and Chirag Desai, Product Manager