URL:https://blog.chromium.org/2021/02/restriction-on-sharedarraybuffers.html
# Heads Up: Restriction on SharedArrayBuffers are coming in M91
- **Published**: 2021-02-17T08:00:00.002-08:00
#### *May 10, 2021: Based on last minute feedback received by developers we’re [adjusting the timeline](https://blog.chromium.org/2021/05/adjusted-timeline-for-sharedarraybuffers.html) to restrict SharedArrayBuffers in M92 - not as planned in M91. One of our goals for this migration is a smooth transition, therefore we’ve decided to adjust the timeline of this change and will support the reverse origin trial via tag as well.*

Starting in Chrome 91 (May, 2021), [cross-origin isolation](https://developer.chrome.com/blog/enabling-shared-array-buffer/#cross-origin-isolation) will be required on all platforms in order to access APIs like SharedArrayBuffer and [performance.measureUserAgentSpecificMemory()](https://web.dev/monitor-total-page-memory-usage/). This brings our desktop platforms in line with Android, which shipped this restriction in Chrome 88.

In order to continue using these APIs, ensure that your pages are cross-origin isolated by serving the page with the following headers:

```` ```
Cross-Origin-Embedder-Policy: require-corp  
Cross-Origin-Opener-Policy: same-origin
``` ````

Be aware, once you do this, your page will not be able to load cross-origin content unless the resource explicitly allows it via a [Cross-Origin-Resource-Policy](https://developer.mozilla.org/en-US/docs/Web/HTTP/Cross-Origin_Resource_Policy_(CORP)) header or [CORS](https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS) headers (Access-Control-Allow-\* and so forth).

For more detailed adoption instructions and considerations, take a look at the [web.dev guide to enable cross-origin isolation](https://web.dev/cross-origin-isolation-guide/).

Posted by Lutz Vahl, Technical Program Manager