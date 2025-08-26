URL:https://blog.chromium.org/2025/06/chrome-achieves-highest-score-ever-on.html
# Chrome achieves highest score ever on Speedometer 3.1, saving users millions of hours
- **Published**: 2025-06-05T10:00:00.000-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg7ibRIFh6_fd8s7ZyAA5Itvhk0OXNyAoVEfC_ctfRXwjGWIcRw-HBETVHqY9IFeZKJwkXj0uE2YsV27pJEjrIJkJkZDCK9Xhp38_jwg4inqSv360AChaT2R7my7jigmtLVeL79pawHZY9AX4HA9LyQ22VmOF-eVi2vjMIZdO61356_4AQu_xjWn7_BAyQz/s1600/Fast%20Curious_image.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg7ibRIFh6_fd8s7ZyAA5Itvhk0OXNyAoVEfC_ctfRXwjGWIcRw-HBETVHqY9IFeZKJwkXj0uE2YsV27pJEjrIJkJkZDCK9Xhp38_jwg4inqSv360AChaT2R7my7jigmtLVeL79pawHZY9AX4HA9LyQ22VmOF-eVi2vjMIZdO61356_4AQu_xjWn7_BAyQz/s1600/Fast%20Curious_image.png)

*Update (6/10/2025): This blog was updated to reflect that testing was done using the Speedometer 3.1 benchmark, and resulted in a 22% performance improvement. The previous version incorrectly noted that the performance improvement was 10% and that the benchmark was Speedometer 3.*

Performance has always been one of the core pillars of Chrome and it’s something we’ve never stopped investing in. Publicly available and open benchmarks, which we create in open collaboration with other browsers, are useful tools for tracking our overall progress, understanding new areas of improvement, and validating potential optimizations. In today’s [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post, we’d like to go through Chrome’s recent work that enabled it to achieve the highest score ever on the Speedometer benchmark.

For Speedometer, these optimizations have resulted in a 22% improvement since August 2024. That 22% improvement leads to better browser experiences, higher conversions for businesses, and deeper enjoyment of what the web has to offer. If each Chrome user used Chrome for just 10 minutes a day, these improvements collectively save 116 million hours or roughly 166 lifetimes worth of waiting around for websites to load and do things.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhNBzs94FRWaVl6_LwIzhqoAu5BQUjRUfMIeqPIW6f6hsKFlYw0yHAmXDAHvfOnNFgZc-XtC857Hwk4xAGNM2aYvZC4N7DAUdcWCTQzufE5tTV-pL2FesiTsL91_2aHaF7dCcEMmKjdwxe2rH2HumPUl_ZgAwmXROWUnokDtNiUkxsHaLXYCzptr-dZ7PJK/s1600/Screenshot%202025-06-10%20at%2012.24.01%E2%80%AFPM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhNBzs94FRWaVl6_LwIzhqoAu5BQUjRUfMIeqPIW6f6hsKFlYw0yHAmXDAHvfOnNFgZc-XtC857Hwk4xAGNM2aYvZC4N7DAUdcWCTQzufE5tTV-pL2FesiTsL91_2aHaF7dCcEMmKjdwxe2rH2HumPUl_ZgAwmXROWUnokDtNiUkxsHaLXYCzptr-dZ7PJK/s1600/Screenshot%202025-06-10%20at%2012.24.01%E2%80%AFPM.png)

Speedometer 3.1 score measured on Apple Macbook Pro M4 with MacOS 15

Speedometer is a benchmark created in open collaboration with other browsers and measures web application responsiveness through workloads that cover a large variety of different areas of the Blink rendering engine used in Chrome:

* HTML parsing
* JavaScript and JSON processing
* JavaScript and Document Object Model (DOM) interaction
* DOM manipulations (element insertion and removal)
* Text size computation (font shaping)
* Cascading Style Sheet (CSS) application and layout calculation
* Pixel rendering

In essence, Speedometer tests critical components of the entire rendering pipeline. For a deeper dive into these individual parts, we recommend the presentation [Life of a Script at Chrome University](https://www.youtube.com/watch?v=K2QHdgAKP-s).

Achieving exceptional web performance requires a multifaceted approach, and optimizing for Speedometer is a testament to overall product excellence. Over the past year, our team has focused on refining fundamental rendering paths across the entire stack. Here are some notable optimization examples.

The team heavily optimized memory layouts of many internal data structures across DOM, CSS, layout, and painting components. Blink now avoids a lot of useless churn on system memory by keeping state where it belongs with respect to access patterns, maximizing utilization of CPU caches. Where internal memory was already relying on garbage collection in Oilpan, e.g. DOM, the usage was expanded by converting types from using malloc to Oilpan. This generally speeds up the affected areas as it packs memory nicely in Oilpan’s backend.

Strings in the renderer improved quite a bit over the last year by avoiding costly representations where possible and switching hashing to rapidhash. More generally, lots of data structures were equipped with better hashes, filters, and probing algorithms.

Where rendering becomes inherently expensive, e.g., for computing CSS styles across various elements, caches are now used much more effectively with better hit rates. At the same time we cache fewer things that are not relevant. Another area where rendering becomes expensive is font shaping; the team significantly improved [Apple Advanced Typography](https://en.wikipedia.org/wiki/Apple_Advanced_Typography) font shaping performance which is relevant everywhere text is rendered.

Posted by Thomas Nattestad