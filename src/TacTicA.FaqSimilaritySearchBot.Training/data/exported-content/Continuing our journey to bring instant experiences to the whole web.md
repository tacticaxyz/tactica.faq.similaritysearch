URL:https://blog.chromium.org/2020/12/continuing-our-journey-to-bring-instant.html
# Continuing our journey to bring instant experiences to the whole web
- **Published**: 2020-12-07T13:27:00.003-08:00
Speed has always been a [core tenet](https://blog.chromium.org/2018/09/10-years-of-speed-in-chrome_11.html) of Chrome. We care about speed, not only because it helps our users get things done quicker, but because it also contributes to making the web ecosystem more diverse by lowering the friction of discovering and engaging with more content or new websites. So, what if we could make the web more instant? Building on some of our previous work in this space, we have a new proposal that aims at speeding up navigations by downloading resources ahead of time, i.e. prefetching. The proposal defines the concept of a “private prefetch proxy” through the combination of an end-to-end encrypted CONNECT proxy to hide potentially identifiable information (e.g. user’s IP address), as well as rules governing its usage, and additional measures to ensure that the prefetches can not be personalized to the user. We are eager to work with the community on refining and generalizing the proposal for the benefit of the whole web.  
  

### Our journey toward instant experiences

In Chrome 73, with [Signed HTTP Exchange](https://developers.google.com/web/updates/2019/03/nic73?hl=ar#sxg), we launched the first phase of a long term effort designed to bring instant experiences to the whole web, through improved prefetching and pre-rendering techniques that are privacy and developer friendly. As a quick refresher, Signed HTTP Exchange makes it possible to create “portable” content, i.e. content that other parties can deliver on your behalf with the assurance that it will remain unaltered and properly attributed to your origin. This offers several advantages such as the ability to speed up page loads, increasing the availability of popular or critical content when the origin servers can’t keep up with the demand, and can also help reduce a publisher’s data transfer costs since the bytes are served by a third party.

  
In Chrome 86 for Android, we ran a proof-of-concept experiment to test a different approach that we hope will be a complementary option to Signed HTTP Exchange. While Signed HTTP Exchange can already be used to enable instant experiences, they require some [extra work and setup](https://developers.google.com/web/updates/2018/11/signed-exchanges#trying_out_signed_exchanges) which isn’t yet always [trivial](https://blog.amp.dev/2019/06/17/introducing-cloudflare-amp-real-url/). We are always on the lookout for innovation opportunities, and with this new approach, our goal is to make it easier to achieve instant experiences across the whole web, thereby helping the community better understand the value of such experiences, and consequently motivating further investment in instant techniques or efforts meant to lower the barriers to adoption of such techniques.  
  
The experiment consisted of prefetching the critical resources for a subset of the most likely cross-site navigations in Chrome for Android, and showed an improvement of 40% on the [Largest Contentful Paint](https://web.dev/lcp/) page load time metric, without revealing potentially identifiable information, such as the user’s IP address, and without requiring extra work from developers to start seeing some benefits. Given the successful proof of concept experiment, we feel ready to share more details about the approach and start engaging with the community to iterate on a viable web platform solution. But before we do, let us take you for a walk down memory lane.

![](https://lh5.googleusercontent.com/58u-KeGT2pPgKGZAUuHIGfYlte5FovZd6rcqrgOFGcmRkux6xJQFr12B9La-ZPeDsh1xqzmCR9_lm4Vh7glrVZ3ufHyQjg4lraOPuZ8JW_x6gA2e12uRieAXg89UbNVci8uMDjGMZg)

“Loading a page without prefetching”

### 

### Lessons learned from prefetching and prerendering

Prefetching is a way to speed up page loads by downloading the bits and pieces that make up a web page (e.g. HTML documents, Javascript, Stylesheet, Images, etc.) in anticipation of a user navigating to said webpage. Pre-rendering is taking things a bit further by drawing and running the web page ahead of time, off-screen, so that by the time the user navigates to the web page, it’s ready to go and displays instantly.  
  
Prefetching or pre-rendering web pages is not a brand new idea. In fact, most modern browsers have such features. For instance, Chrome for desktop had a feature called “[Instant Pages](https://chrome.googleblog.com/2011/06/faster-than-fast.html)” from 2011 until 2017 when it was replaced with [NoState Prefetch](https://developers.google.com/web/updates/2018/07/nostate-prefetch). Here are some of the key reasons that made us take a step back with regards to pre-rendering at the time:  

* Pre-rendering was an all or nothing approach where calls to unsupported web features would result in completely abandoning pre-rendering. The intent was to avoid annoyances such as having sounds or permission prompts coming out of nowhere, but in practice, this meant that most websites were not compatible with pre-rendering and that web developers could inadvertently fall outside of the set of pre-rendering compatible web features, and lose all the benefits as a result.
* Not all pages can be safely pre-rendered. For instance, pre-rendering a link to a page that logs you out of your favorite website would be a bad experience. Because it is non trivial to dissociate pages that are consequence-free vs. those that aren’t, this meant that we were only able to safely apply pre-rendering to a narrow subset of links on the web.

These hurdles meant that pre-rendering was only used by, and for, a handful of websites. Even today, with the NoState Prefetch approach, the feature is only [used on 1.4% of all page loads](https://chromestatus.com/metrics/feature/timeline/popularity/918). Given the significant upsides (e.g. 40% faster page loads with prefetching), we believe that the ceiling ought to be much higher. To start, we decided to set our sights on addressing a significant impediment to the use of prefetching, and by extension pre-rendering: preserving privacy while improving page load performance.  
  
  

### Prefetching and privacy

A fundamental challenge with prefetching another website is that it inherently happens before the user has signaled their interest, i.e. by visiting said website. So, if your browser, or favorite websites, were to prefetch links to pages on other websites that you might be interested in, it exposes potentially identifiable information, such as your IP address or cookies, to the servers hosting those websites. This approach to prefetching is problematic because it allows the prefetched websites to learn something new about you, such as your interest in some content or product. In practice, as we have said earlier, this heavily limits the usage of prefetching to a small number of cases where prefetching a page doesn’t reveal new information to its publisher.

![](https://lh3.googleusercontent.com/1OSD6iuUr8UkJtF632XdMgntwq4YBaMOAkGod0cO2EJ7wXLc7bo4MU-rco54bwbdyfiejguht6V3S6yQw_FxboTpjsY7tBoXH0KhqOeJdSm3T1EsC-w8A0W7x1NpOOIwZ2wTSogJHA)

“Naively prefetching websites can result in leaking user’s interest in some content or product”

In essence, the challenge here is to find an approach which upholds the following privacy principle: “None of the parties involved can learn anything new about the user as a result of prefetching a website”. For the experiment, we’ve addressed this challenge by having Chrome use a “private prefetch proxy” which consists of a [CONNECT proxy](https://tools.ietf.org/html/rfc7231#section-4.3.6), a set of rules governing its usage, and additional measures to ensure that the prefetches can not be personalized to the user.  
  

### 

### Private prefetch proxy

At a high level, Chrome gives the name of a website to the CONNECT proxy which then creates a secure communication channel between Chrome and that website. By design, the proxy was operated for and by Google, and was restricted to navigations originating from Google owned surfaces, thereby ensuring that the proxy could only see information that’s already accessible such as the names of the websites prefetched from surfaces that we authored. The end-to-end encrypted communication channel provided by the CONNECT proxy means that the proxy is only able to relay further requests without being able to see the content of the communication. Furthermore, given that the content of the communication is encrypted end-to-end between Chrome and the destination site, it also means that intermediaries can’t see the prefetched domains, nor the content of the prefetched resources. Likewise, since the proxy is relaying the prefetching requests, the destination website only sees the IP address of the proxy, not the user’s IP address. Finally, prefetching was restricted to websites that had no cookies or other local state, thereby preventing the destination site from identifying a user via information previously stored on their device.

![](https://lh5.googleusercontent.com/Yq5cTRhLU41MtCKVE1UKsBCdwEsYpH1Ck6b-sJk7Hn6mGPGGrX1acKN6Lv1eFDT8XJGc713khII7G3s_W4KkhntOiBSjDs9nNWOHXTkTQUkmxB-yDVapKczii3mmNKmlO0obVpdWlg)

“Prefetching websites via a CONNECT proxy prevents leaking user information”

### Rebuilding pre-rendering on a solid foundation

As mentioned in the introduction, our goal is to bring instant experiences to the whole web through prefetching and pre-rendering techniques that are privacy and developer friendly. This proof of concept experiment and the follow-up discussions with the community represent small, but nevertheless important, steps toward that goal. Indeed, any pre-rendering feature is inherently built on top of a prefetching capability, which must abide by the same privacy principles. There are a few more challenges that we’ll need to solve to bring back an improved, privacy and developer friendly, pre-rendering feature. To be clear, we see this successful proof of concept experiment as a positive signal for iterating on a viable web platform solution, so that more websites can both benefit from, and take advantage of the approach outlined in this blog post. We are hopeful that what we’ve learned from past efforts, as well as new learnings we’ve gained thanks to this proof-of-concept experiment, will help foster a fruitful collaborative effort with the rest of the community.

Posted by Michael Buettner (Software Engineer), and Kenji Baheux (Product Manager)