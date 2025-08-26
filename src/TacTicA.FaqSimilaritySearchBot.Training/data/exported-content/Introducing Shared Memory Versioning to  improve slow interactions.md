URL:https://blog.chromium.org/2024/06/introducing-shared-memory-versioning-to.html
# Introducing Shared Memory Versioning to  improve slow interactions
- **Published**: 2024-06-03T10:24:00.000-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgULbG_V-g8EZnGGU7HOmjeHhtXqsFS5cXno21FsN1uucnkTMdlq9tL9rOoZW7fx5vqp6_nW3R5Ib4JJZxMr9zD-MVIqLuCyy8N6ZheCW4iYkI7unu2GX7mMG2PVHNkNrykjbgi5PUwurzRSbd89DP6k1hGe7hze6EKVAzo4XKO8b3NfiO4PRsnHNwMKBDa/s16000/Fast%20Curious_image.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgULbG_V-g8EZnGGU7HOmjeHhtXqsFS5cXno21FsN1uucnkTMdlq9tL9rOoZW7fx5vqp6_nW3R5Ib4JJZxMr9zD-MVIqLuCyy8N6ZheCW4iYkI7unu2GX7mMG2PVHNkNrykjbgi5PUwurzRSbd89DP6k1hGe7hze6EKVAzo4XKO8b3NfiO4PRsnHNwMKBDa/s400/Fast%20Curious_image.png)

  

*On the Chrome team, we believe it’s not sufficient to be fast most of the time, we have to be fast all of the time. Today’s The Fast and the Curious post explores how we contributed to Core Web Vitals by surveying the field data of Chrome responding to user interactions across all websites, ultimately improving performance of the web.*

As billions of people turn to the web to get things done every day, the browser becomes more responsible for hosting a multitude of apps at once, resource contention becomes a challenge. The multi-process Chrome browser contends for multiple resources: CPU and memory of course, but also its own queues of work between its internal services (in this article, the network service).

This is why we’ve been focused on identifying and fixing [slow interactions](https://web.dev/articles/inp) from Chrome users’ field data, which is the authoritative source when it comes to real user experiences. We gather this field data by recording anonymized Perfetto traces on Chrome Canary, and report them using a privacy-preserving filter.

When looking at field data of slow interactions, one particular cause caught our attention: recurring synchronous calls to fetch the current site’s cookies from the network service.

Let’s dive into some history.

### **Cookies under an evolving web**

Cookies have been part of the web platform since the very beginning. They are commonly created like this:

```
    document.cookie = "user=Alice;color=blue"
```

And later retrieved like this:

```
    // Assuming a `getCookie` helper method:
    getCookie("user", document.cookie)
```

Its implementation was simple in single-process browsers, which kept the cookie jar in memory.

Over time, browsers became multi-process, and the process hosting the cookie jar became responsible for answering more and more queries. Because the Web Spec requires Javascript to fetch cookies synchronously, however, answering each `document.cookie` query is a blocking operation.

The operation itself is very fast, so this approach was generally fine, but under heavy load scenarios where multiple websites are requesting cookies (and other resources) from the network service, the queue of requests could get backed up.

We discovered through field traces of slow interactions that some websites were triggering inefficient scenarios with cookies being fetched multiple times in a row. We landed additional metrics to measure how often a `GetCookieString()` IPC was redundant (same value returned as last time) across all navigations. We were astonished to discover that **87% of cookie accesses were redundant** and that, in some cases, this could happen hundreds of times per second.

The simple design of `document.cookie` was backfiring as JavaScript on the web was using it like a local value when it was really a remote lookup. Was this a classic computer science case of caching?! Not so fast!

The web spec allows collaborating domains to modify each other’s cookies. Hence, a simple cache per renderer process didn’t work, as it would have prevented writes from propagating between such sites (causing stale cookies and, for example, unsynchronized carts in ecommerce applications).

### A new paradigm: Shared Memory Versioning

We solved this with a new paradigm which we called [Shared Memory Versioning](https://source.chromium.org/chromium/chromium/src/+/main:mojo/public/cpp/base/shared_memory_version.h). The idea is that each value of `document.cookie` is now paired with a monotonically increasing version. Each renderer caches its last read of `document.cookie` alongside that version. The network service hosts the version of each `document.cookie` in shared memory. Renderers can thus tell whether they have the latest version without having to send an inter-process query to the network service.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhl8OJ82Etmnlpmr2nRzeWSmYBk-2yRPAaDSrftFMxYp-hRkb8ZIxYzIMLG09c9iqHB-dD8UrLj3GaXio7rHjOOpLGY6YBmVYQaex21mqaTGFLSHJVMrUywbU13bvgNeVC0PxiT9sV3Wj33H0Rtr0rzOdHCJBzjQe1IGBjC-8uftmM_D5XBL0CoVMUPZMuU/s16000/Fast%20&%20Curious%20In-Line_Reduce%20cookies%20IPC_V2_HighRes.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhl8OJ82Etmnlpmr2nRzeWSmYBk-2yRPAaDSrftFMxYp-hRkb8ZIxYzIMLG09c9iqHB-dD8UrLj3GaXio7rHjOOpLGY6YBmVYQaex21mqaTGFLSHJVMrUywbU13bvgNeVC0PxiT9sV3Wj33H0Rtr0rzOdHCJBzjQe1IGBjC-8uftmM_D5XBL0CoVMUPZMuU/s7748/Fast%20&%20Curious%20In-Line_Reduce%20cookies%20IPC_V2_HighRes.png)

  

This reduced cookie-related inter-process messages by 80% and made `document.cookie` accesses 60% faster 🥳.

### Hypothesis testing

Improving an algorithm is nice, but what we ultimately care about is whether that improvement results in improving slow interactions for users. In other words, we need to test the hypothesis that stalled cookie queries were a significant cause of slow interactions.

To achieve this, we used Chrome’s A/B testing framework to study the effect and determined that it, combined with other improvements to reduce resource contention, improved the slowest interactions by approximately 5% on all platforms. This further resulted in more websites [passing Core Web Vitals](https://httparchive.org/reports/chrome-ux-report?start=2023_11_01&end=latest&view=list#cruxFastInp) 🥳. All of this adds up to a more seamless web for users.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiGnZvKinh7TK5YiwNx1HC6vzv5CCyKPJoRGhfRzZA0MlBLl-8ho5ciLI8WyFka6QcqmcRSWgMIjz-vsfsiLBWu-dYaZ7Df1j5Ow2YRB3PkQ-k7fjxsCcZ2oJpbjYKxK92pELqHWpcXw9PwaVn4wGSzgkIRj7DLMLZAAeEYkd8mYC8F4OOcJFiePTmsQp_G/s16000/Screenshot%202024-05-30%20at%2010.19.00%E2%80%AFAM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiGnZvKinh7TK5YiwNx1HC6vzv5CCyKPJoRGhfRzZA0MlBLl-8ho5ciLI8WyFka6QcqmcRSWgMIjz-vsfsiLBWu-dYaZ7Df1j5Ow2YRB3PkQ-k7fjxsCcZ2oJpbjYKxK92pELqHWpcXw9PwaVn4wGSzgkIRj7DLMLZAAeEYkd8mYC8F4OOcJFiePTmsQp_G/s1176/Screenshot%202024-05-30%20at%2010.19.00%E2%80%AFAM.png)

  

*Timeline of the weighted average of the slowest interactions across the web on Chrome as this was released to 1% (Nov), 50% (Dec), and then all users (Feb).*

Onward to a seamless web!

*By Gabriel Charette, Olivier Li Shing Tat-Dupuis, Carlos Caballero Grolimund, and François Doray, from the Chrome engineering team*