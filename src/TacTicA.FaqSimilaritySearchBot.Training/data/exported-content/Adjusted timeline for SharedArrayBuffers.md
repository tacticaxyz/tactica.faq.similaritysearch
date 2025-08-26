URL:https://blog.chromium.org/2021/05/adjusted-timeline-for-sharedarraybuffers.html
# Adjusted timeline for SharedArrayBuffers
- **Published**: 2021-05-10T09:00:00.000-07:00
Back in February, we [announced](https://blog.chromium.org/2021/02/restriction-on-sharedarraybuffers.html) that [cross-origin isolation](https://developer.chrome.com/blog/enabling-shared-array-buffer/#cross-origin-isolation) will be required on all platforms in order to access APIs like SharedArrayBuffer and [performance.measureUserAgentSpecificMemory()](https://web.dev/monitor-total-page-memory-usage/) starting in Chrome 91. Based on your feedback and issues reported, we've decided to adjust the timeline for SharedArrayBuffer usage in none cross-origin isolated sites to be restricted in Chrome 92.

Your feedback is important and we are listening.

Posted by Lutz Vahl, Technical Program Manager