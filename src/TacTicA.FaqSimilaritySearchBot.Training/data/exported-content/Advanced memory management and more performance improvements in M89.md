URL:https://blog.chromium.org/2021/03/advanced-memory-management-and-more.html
# Advanced memory management and more performance improvements in M89
- **Published**: 2021-03-11T09:27:00.001-08:00
Boosting performance while adding features, functionality, and improving security, requires deep and continuous investment. Today’s post is the first in a series this year that will go into more technical detail about Chrome's ongoing efforts around performance. In this release, we’ve dug deep into the core of Chrome, upgrading how we allocate and discard memory, and even how we build, package, and run Chrome, to make today’s Chrome even faster and more memory efficient.

### Improving memory management

In Chrome M89, we’re seeing significant memory savings on Windows--up to 22% in the browser process, 8% in the renderer, and 3% in the GPU. Even more than that, we’ve improved browser responsiveness by up to 9%. We’ve achieved this by using [PartitionAlloc](https://chromium.googlesource.com/chromium/src/+/master/base/allocator/partition_allocator/PartitionAlloc.md), our own advanced memory allocator, which is optimized for low allocation latency, space efficiency, and security. For some time now, PartitionAlloc has been used extensively within Blink, our renderer codebase. Starting in M89, we’ve upgraded Chrome on Android and 64-bit Windows to use PartitionAlloc everywhere (by intercepting malloc).

In addition to improving how we allocate memory, Chrome is now smarter about using (and discarding) memory. Chrome now reclaims up to 100MiB per tab, which is more than 20% on some popular sites, by discarding memory that the foreground tab is not actively using, such as big images you’ve scrolled off screen. Chrome is also shrinking its memory footprint in background tabs on macOS, something we’ve been doing on other platforms for a while. We’re seeing up to 8% memory savings, which is more than 1GiB in some cases!

Finally, with more data from the field on [tab throttling](https://blog.chromium.org/2020/11/tab-throttling-and-more-performance.html), we’re seeing up to 65% improvement on Apple Energy Impact score for tabs in the background, keeping your Mac cooler and those fans quiet.

### Build, packaging, and runtime improvements

Focusing on Chrome for Android, we have a uniquely challenging job of building a great browser for every single variant of Android device. In this release we’re taking advantage of some packaging and runtime optimizations to deliver better performance in the Chrome that is in your pocket.

Some new Play and Android capabilities allowed us to repackage Chrome on Android, and we’re seeing fewer crashes due to resource exhaustion, a 5% improvement in memory usage, 7.5% faster startup times, and up to 2% faster page loads. [Android App Bundles](https://developer.android.com/guide/app-bundle) allow the Play Store to generate optimized APKs for each user’s device configuration, and allows packaging code and resources in split APKs, which are installed alongside the base APK. And an Android O feature, [isolatedSplits](https://developer.android.com/reference/android/R.attr#isolatedSplits), allows these feature splits to be loaded on demand, reducing Chrome’s overall startup cost.

For those of you who picked up the latest Android devices (Android Q+ and 8GB+ of RAM), we’ve rebuilt Chrome as a 64-bit binary, giving you a more stable Chrome that is up to 8.5% faster to load pages and 28% smoother when it comes to scrolling and input latency.

Finally, we’ve built a way for Chrome on Android to start up 13% faster: Freeze-Dried Tabs. Chrome now saves a lightweight version of your tabs that are similar in size to a screenshot, but support scrolling, zooming, and tapping on links. We use these Freeze-Dried Tabs at startup while the actual tab loads in the background, getting you to your pages faster. See it in action below:

  

Our teams are always working hard to bring you the fastest and most powerful browser on every one of your devices. We’re very excited to bring you these performance improvements and have much more to come, so stay tuned.

Posted by Mark Chang, Chrome Product Manager

*Data source for all statistics: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.*