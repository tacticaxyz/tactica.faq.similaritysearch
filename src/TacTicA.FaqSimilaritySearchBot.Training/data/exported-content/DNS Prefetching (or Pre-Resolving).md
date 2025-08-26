URL:https://blog.chromium.org/2008/09/dns-prefetching-or-pre-resolving.html
# DNS Prefetching (or Pre-Resolving)
- **Published**: 2008-09-17T10:28:00.000-07:00
A major goal of Google Chrome was to improve user enjoyment and value in web surfing. Critical to that is increasing the responsiveness of the browser to user input, or reducing user perceived latency. Measurements in the browser have shown that a significant amount of time is traditionally spent waiting for DNS to resolve domain names. To speed up browsing, Google Chrome resolves domain names before the user navigates, typically while the user is viewing a web page. This is done using your computer's normal DNS resolution mechanism; no connection to Google is used. As a result, user navigation time in Google Chrome when first visiting a domain is on average about 250ms faster than traditional browsing, and the occasional but painful 1-second-plus delays are almost never experienced.

How it works, and how much it helps.

First off, DNS Resolution is the translation of a domain name, such as www.google.com, into an IP address, such as 74.125.19.147. A user can't go anywhere on the internet until after the target domain is resolved via DNS.

The histograms at the end of this post show actual resolution times encountered when computers needed to contact their network for DNS resolutions. The data was gathered during our pre-release testing by Google employees who opted-in to contributing their results. As can be seen in that data, the average latency was generally around 250ms, and many resolutions took over 1 second, some even several seconds.

DNS prefetching just resolves domain names before a user tries to navigate, so that there will be no effective user delay due to DNS resolution. The most obvious example where prefetching can help is when a user is looking at a page with many links to various unexplored domains, such as a search results page. Google Chrome automatically scans the content of each rendered page looking for links, extracting the domain name from each link, and resolving each domain to an IP address. All this work is done in parallel with the user's reading of the page, hardly using any CPU power. When a user clicks on any of these pre-resolved names to visit a new domain, they will save an average of over 250ms in their navigation.

If you've been running Google Chrome for a while, be sure to try typing "about:dns" into the address bar to see what savings you've accrued! Humorously, this prefetching feature often goes unnoticed, as users simply avoid the pain of waiting, and tend to think the network is just fast and smooth. To look at it another way, DNS prefetching removes the variance from surfing latency that is induced by DNS resolutions. (Note: If about:dns doesn't show any savings, then you probably are using a proxy, which is resolving DNS on the behalf of your browser.)

There are several other benefits that Google Chrome derives from DNS prefetching. During startup, it pre-resolves domain names, such as the home pages, very early in the startup process. This tends to save about 200-500 ms during application startups. Google Chrome also pre-resolves the host names in URLs suggested by the omnibox while the user is typing, but before they press enter. This feature works independently of the broader omnibox logic, and doesn't utilize any connection to Google. As a result, Google Chrome will generally navigate to a typed URL faster, or reach a user's search provider faster. Depending on the popularity of the target domain, this can save 100-250ms on average, and much more in the worst case.

If you are running Google Chrome, try typing "about:histograms/DNS.PrefetchFoundName" into the address bar to see details of the resolution times currently being encountered on your machine.

The bottom line to all this DNS prefetching is that Google Chrome works overtime, anticipating a user's needs, and making sure they have a very smooth surfing experience. Google Chrome doesn't just render and run Java Script at a remarkable speed, it gets users to their destinations quickly, and generally sidesteps the pitfalls surrounding DNS resolution time.

Of course, the best way to see this DNS prefetching feature work, is to just surf.

Sample of DNS Resolutions Times requiring Network Activity (i.e., over 15ms resolution)

The following is a recent histogram of aggregated DNS resolutions times observed during tests of Google Chrome by Googlers, prior to the product's public release. The samples listed are only those that required network access (i.e., took more than 15 ms). The left column lists the lower range of each bucket.  For example, the first bucket lists samples between 14 and 18ms inclusive. The next three columns show the number of samples in that range, the fraction of samples in the range, and the cumulative fraction of samples at or below that range. For example, in the first bucket, there were 31761 samples in this bucket range, or about 5.10% of all the 6,228,600 samples shown. Looking at the cumulative percentage column (far right), we can see that the median resolution took around 90ms (actually, 52.71% took less than 118ms, but 43.63% took less than 87ms). Reading from the top of the chart, the average DNS resolution time was 271ms, and the standard deviation was 1.130 seconds. The "long tail" may have included users that lost network connectivity, and eventually reconnected, producing extraordinarily long resolution times.

Count: 6,228,600; Sum of times: 1,689,207,135; Mean: 271 ± 1130.67

  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhexvlDry4dzIGdazF6k6cgsZy6qjvdvPjPu6auwhhfNyTe6WXG9BjW-bGHv0Tei6fWXHKXLVZvb09aBmpp03XCJpAj4aOWyIZiWYyhrOmBrU16PMErwlqqBZz61NczyuBHzRBOPlJUbVMX/s400/histogram.PNG)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhexvlDry4dzIGdazF6k6cgsZy6qjvdvPjPu6auwhhfNyTe6WXG9BjW-bGHv0Tei6fWXHKXLVZvb09aBmpp03XCJpAj4aOWyIZiWYyhrOmBrU16PMErwlqqBZz61NczyuBHzRBOPlJUbVMX/s1600-h/histogram.PNG)  
Posted by Jim Roskind, Software Engineer