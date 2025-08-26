URL:https://blog.chromium.org/2021/04/efficient-and-safe-allocations-everywhere.html
# Efficient And Safe Allocations Everywhere!
- **Published**: 2021-04-12T11:43:00.008-07:00
*In our constant work to improve performance, our engineers sometimes have to seek optimizations in places that most software developers don’t venture. In this post in our series, [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious), a team of senior engineers showed how they approached replacing the system-level memory allocator with an optimized version, yielding significant memory savings -- up to 22% on Windows.*

[PartitionAlloc](https://chromium.googlesource.com/chromium/src/+/master/base/allocator/partition_allocator/PartitionAlloc.md) is Chromium’s memory allocator, designed for lower fragmentation, higher speed, and stronger security and has been used extensively within [Blink](https://www.chromium.org/blink) (Chromium’s rendering engine). [In Chrome 89](https://blog.chromium.org/2021/03/advanced-memory-management-and-more.html) the entire Chromium codebase transitioned to using PartitionAlloc everywhere (by intercepting and replacing malloc() and new) on Windows 64-bit and Android. Data from the field demonstrates up to 22% memory savings, and up to 9% improvement in responsiveness and scroll latency of Chrome.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjyIXzfYbvVhMok6OVmRB_h9hkCdqCW70WSUrhgDM_vgUR7K3BSaREabmnx7oExFOjRQcJiTVA3l_cNS_a-iEIiX9WQbek3R3ExCtx7eSxXk-Wr9s4UY8TuEs8Fz4KEQr1hSXq-C8VevMz-/w542-h132/image3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjyIXzfYbvVhMok6OVmRB_h9hkCdqCW70WSUrhgDM_vgUR7K3BSaREabmnx7oExFOjRQcJiTVA3l_cNS_a-iEIiX9WQbek3R3ExCtx7eSxXk-Wr9s4UY8TuEs8Fz4KEQr1hSXq-C8VevMz-/s605/image3.png)

Here's a closer look at memory usage in the browser process for Windows as the M89 release began rolling out in early March:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhvJyoUiUBgdWxbpcF8JiGTtGdH9uZeGHM6AJfZTOWiDGNLxpykVtH_V4z4dtVO7QruiZe3woldnBNNAgA3DL31m8PPWl3aG19rRMc7qk480xajl6aWP5rq1hEEfwLrIz027jvADCckLsEZ/w524-h256/image2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhvJyoUiUBgdWxbpcF8JiGTtGdH9uZeGHM6AJfZTOWiDGNLxpykVtH_V4z4dtVO7QruiZe3woldnBNNAgA3DL31m8PPWl3aG19rRMc7qk480xajl6aWP5rq1hEEfwLrIz027jvADCckLsEZ/s1458/image2.png)

  

#### 

Background
----------

Chrome is a multi-platform, multi-process, multi-threaded application, serving a wide range of needs, from small embedded [WebViews](https://developer.android.com/reference/android/webkit/WebView) on Android to [spacecraft](https://www.reddit.com/r/spacex/comments/gxb7j1/we_are_the_spacex_software_team_ask_us_anything/ft5zou3?utm_source=share&utm_medium=web2x&context=3). Performance and memory footprint are of critical importance, requiring a tight integration between Chrome and its memory allocator. But heterogeneity across platforms can be prohibitive with each platform having a different implementation such as [tcmalloc](https://github.com/google/tcmalloc) on Linux and Chrome OS, [jemalloc](http://jemalloc.net/) or [scudo](https://source.android.com/devices/tech/debug/scudo) on Android, and [LFH](https://docs.microsoft.com/en-us/windows/win32/memory/low-fragmentation-heap) on Windows.  
  
  
When we started this project, our goals were to: 1) unify memory allocation across platforms, 2) target the lowest memory footprint without compromising security and performance, and 3) tailor the allocator to optimize the performance of Chrome. Thus we made the decision to use Chromium’s cross-platform allocator, to optimize memory usage for client rather than server workloads and to focus on meaningful end user activities, not micro-benchmarks that wouldn’t really matter in real world usage.

Allocator Security
------------------

PartitionAlloc was designed to support multiple independent partitions, i.e. non-overlapping regions of memory. We use these partitions throughout Blink to thwart some forms of type confusion attacks, such as ensuring strings are separated from layout objects. However, this approach only avoids collisions between types that are allocated from different partitions. Furthermore, PartitionAlloc buckets allocations by their sizes, to help avoid type confusion when potentially-colliding objects are of dissimilar size. These techniques work because PartitionAlloc doesn’t re-use address space. Once PartitionAlloc dedicates a region of address space to a certain partition and size bucket, it will always belong to that partition and size bucket.  
  
  
Additionally, PartitionAlloc protects some of its metadata with guard pages (inaccessible ranges) around memory regions. Not all metadata is equal, however: free-list entries are stored within previously allocated regions, and thus surrounded by other allocations. To detect corrupted free-list entries and off-by-one overflows from client code, we encode and shadow them.  
Finally, having our own allocator enables advanced security features like [MiraclePtr](https://source.chromium.org/chromium/chromium/src/+/master:base/memory/checked_ptr.md) and [\*Scan](https://source.chromium.org/chromium/chromium/src/+/master:base/allocator/partition_allocator/starscan/README.md).

Architecture Details
--------------------

Each partition in PartitionAlloc uses a single, central, [slab-based allocator](https://en.wikipedia.org/wiki/Slab_allocation) to conserve memory, with a minimal per-thread cache in front for scaling to multi-threaded workloads. This simplicity also pays performance dividends: we’ve extensively profiled and aggressively trimmed the allocator’s fast path, improving thread-local storage access, locks, reducing cache line fetches, and removing branches.  
  
PartitionAlloc pre-reserves slabs of virtual address space. They are gradually backed by physical memory, as allocation requests arrive. Small and medium-sized allocations are grouped in geometrically-spaced, size-segregated buckets, e.g. [241; 256], [257; 288]. Each slab is split into regions (called “slot spans”) that satisfy allocations (“slots”) from only one particular bucket, thereby increasing cache locality while lowering fragmentation. Conversely, larger allocations don’t go through the bucket logic and are fulfilled using the operating system’s primitives directly (mmap() on [POSIX](https://en.wikipedia.org/wiki/POSIX) systems, and VirtualAlloc() on Windows).  
  
This central allocator is protected by a single per-partition lock. To mitigate the scalability problem arising from contention, we add a small, per-thread cache of small slots in front, yielding a three-tiered architecture:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg_jbCHC4V3KykW49-WANX1Yck4poVIHTpkKuLMlrVie4iQDJtgIKmOVk_wURhCVCsuXAN5jTP4D_kyYLzA7UhOx40Q26eJp1WrwfyL9hqBFHE-SiNBFYXyJS9pfKYrtX_b9lUXig-Zpvie/s0/image1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg_jbCHC4V3KykW49-WANX1Yck4poVIHTpkKuLMlrVie4iQDJtgIKmOVk_wURhCVCsuXAN5jTP4D_kyYLzA7UhOx40Q26eJp1WrwfyL9hqBFHE-SiNBFYXyJS9pfKYrtX_b9lUXig-Zpvie/s276/image1.png)

  
The first layer (Per-thread cache) holds a small amount of slots belonging to smaller and more commonly used buckets. Because these slots are stored per-thread, they can be allocated without a lock and only requiring a faster [thread-local storage](https://en.wikipedia.org/wiki/Thread-local_storage) lookup, improving cache locality in the process. The per-thread cache has been tailored to satisfy the majority of requests by allocating from and releasing memory to the second layer in batches, amortizing lock acquisition, and further improving locality while not trapping excess memory.  
  
The second layer (Slot span free-lists) is invoked upon a per-thread cache miss. For each bucket size, PartitionAlloc knows a slot span with free slots associated with that size, and captures a slot from the free-list of that span. This is still a fast path, but slower than per-thread cache as it requires taking a lock. However, this section is only hit for larger allocations not supported by per-thread cache, or as a batch to fill the per-thread cache.  
  
Finally, if there are no free slots in the bucket, the third layer (Slot span management) either carves out space from a slab for a new slot span, or allocates an entirely new slab from the operating system, which is a slow but very infrequent operation.  
  
The overall performance and space-efficiency of the allocator hinges on the many tradeoffs across its layers such as how much to cache, how many buckets, and memory reclaiming policy. Please refer to [PartitionAlloc](https://chromium.googlesource.com/chromium/src/+/master/base/allocator/partition_allocator/PartitionAlloc.md) to learn more about the design.  
  
All in all, we hope you will enjoy the additional memory savings and performance improvements brought by PartitionAlloc, ensuring a safer, leaner, and faster Chrome for users on Earth and in outer space alike. Stay tuned for further improvements, and support of more platforms coming in the near future.  
  
Posted by Benoît Lizé and Bartek Nowierski, Chrome Software Engineers

*Data source for all statistics: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.  
\*The core metric measures jank -- delay handling user input -- every 30 seconds.*