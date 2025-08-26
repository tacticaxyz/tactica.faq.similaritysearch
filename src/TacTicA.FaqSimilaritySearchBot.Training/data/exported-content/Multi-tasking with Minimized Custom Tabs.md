URL:https://blog.chromium.org/2024/05/multi-tasking-with-minimized-custom-tabs.html
# Multi-tasking with Minimized Custom Tabs
- **Published**: 2024-05-29T09:08:00.000-07:00
In the latest release of Chrome, we're introducing [Minimized Custom Tabs](https://developer.chrome.com/docs/android/custom-tabs#:~:text=Users%20can%20minimize,Chrome%20122%20Beta.), a feature that allows users to effortlessly transition between native app and web content. With a simple tap on the down button in the Chrome Custom Tabs toolbar, users can minimize a Custom Tab into a compact, floating picture-in-picture window. This seamless integration enables multi-tasking across surfaces, enhancing the in-app web browsing experience. By tapping on the floating window, users can easily maximize the tab, restoring it to its original size.

[![Minimize a Chrome Custom Tab to interact with the background app](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiKB-vt3k1oWC8dnOgKzw3mthZikPMXJnYOwbL01KoivsRt69r98CeEjTv0TeAFjfCHdCx6WoOaoXiDECWg5EHgYoUjxQxQTm9aFaSK-AyUFb6w6EyASeQiM2RVfJgm5mgw6haiQYbspQuOQlcTlYcVFo709bmtC2skBgSA9XZJpvhoPDViNTxOkaDQ6IUD/s16000/Minimixed%20Custom%20Tabs.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiKB-vt3k1oWC8dnOgKzw3mthZikPMXJnYOwbL01KoivsRt69r98CeEjTv0TeAFjfCHdCx6WoOaoXiDECWg5EHgYoUjxQxQTm9aFaSK-AyUFb6w6EyASeQiM2RVfJgm5mgw6haiQYbspQuOQlcTlYcVFo709bmtC2skBgSA9XZJpvhoPDViNTxOkaDQ6IUD/s1228/Minimixed%20Custom%20Tabs.gif)

  

### How to get started

Because this change happens at the browser level, developers who use Chrome Custom Tabs will see this change automatically applied starting with Chrome version M124. End users will see the Minimize icon in the Chrome Custom Tab toolbar.

Please note that this is a change in Chrome, and we hope other browsers will adopt similar functionality.

*Posted by Victor Gallet, Senior Product Manager*