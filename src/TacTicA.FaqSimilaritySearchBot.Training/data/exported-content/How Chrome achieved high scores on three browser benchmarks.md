URL:https://blog.chromium.org/2023/06/how-chrome-achieved-high-scores-on.html
# How Chrome achieved high scores on three browser benchmarks
- **Published**: 2023-06-02T14:55:00.005-07:00
[![Hero image for The Fast and the Curios series](https://blogger.googleusercontent.com/img/a/AVvXsEhq3y37d11y5YKBRI73KZlrz4Re-7pwYAP9H_AzqWxw6N0wLBDMtrSl9RyyTizR4mztTWrLrspPrWEah6t-kXOJ0_7em9C5PxJc25kVPp-ihOvkQMSXVP279nfppZtuNVDcZlCVJIdPHXhvwemJIkopRpxO2aTACieA6XKzOW1EC2kiBBi-JbhDLGENhA=w438-h182)](https://blogger.googleusercontent.com/img/a/AVvXsEhq3y37d11y5YKBRI73KZlrz4Re-7pwYAP9H_AzqWxw6N0wLBDMtrSl9RyyTizR4mztTWrLrspPrWEah6t-kXOJ0_7em9C5PxJc25kVPp-ihOvkQMSXVP279nfppZtuNVDcZlCVJIdPHXhvwemJIkopRpxO2aTACieA6XKzOW1EC2kiBBi-JbhDLGENhA)

  

Since the beginning of Chrome, benchmarks have been a key way by which we drive performance optimizations that benefit users. The most relevant web benchmarks today are [Speedometer](https://browserbench.org/Speedometer2.0/), [MotionMark](https://browserbench.org/MotionMark1.2/), and [Jetstream](https://browserbench.org/JetStream/). Over the last year Chrome has invested in optimizing against these specific benchmarks and has just achieved our highest scores across all three. These gains were achieved through a combination of large projects and small improvements. In today’s [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post, we want to share just some of the ways we drove these improvements in Chrome.

Announcing our brand new mid-tier compiler: Maglev
--------------------------------------------------

We’re bringing a new mid-tier compiler to Chrome. Maglev is a just-in-time compiler that can quickly generate performant machine code for all relevant functions within the first one-hundredth of a second. It reduces overall CPU time to compile code while also saving battery life. Our measurements show Maglev has provided a 7.5 percent improvement on Jetstream and a 5 percent improvement in Speedometer. Maglev will start rolling out in Chrome version 114, which begins release on June 5.

Speedometer
-----------

Speedometer measures the responsiveness of websites by putting various JavaScript UI frameworks through their paces. Just over a year ago we shared details about [how we increased our score](https://blog.chromium.org/2022/03/how-chrome-became-highest-scoring.html) from 100 to over 300 from Chrome version 40 to version 101. Since then, across 13 Chrome releases, we’ve achieved our new highest Speedometer score of 491. In addition to Maglev, the V8 team has achieved this score through both small adjustments, such as optimized function calls, and major, multi-quarter projects. 

![A speedometer visual shows a 491 score for the Speedometer browser benchmark, which measures the responsiveness of websites. This is up from a score of 330 in the past year for Chrome.](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj7YEw5HVXlz6ingSSXlMHTA81Qr1Gn9h5GhQulRDB_bhAAX3iNvXFMG3tQjfEazGLcNbmZFhfjWgr7LbVEve_7ZDoFEFA6_gWn3bBzKLwu_04-uyInWdxxYx1y8vfZGO8StNiHMjoZwchUEXAXSB_bcg0YnCvMB7wziT7VB4a8-2A-izVSqtjijFzw6w/w318-h320/Screenshot%202023-06-02%20at%203.09.07%20PM.png)

Chrome 116.0.5803.2 running on an M2 Macbook Air with Maglev enabled

  

MotionMark
----------

MotionMark is designed to test how much browser graphics systems can render at high frame rates. Chrome’s graphics and rendering teams have tracked over 20 optimizations since the start of the year, and more than half are available today. Together, these optimizations have almost tripled performance. Some highlights include improvements to Canvas performance, profile-guided optimization, GPU task scheduling, and layer compositing. We also created a novel algorithm for dynamic multisample anti-aliasing and out-of-process 2D canvas rasterization for improved parallelism.

![A speedometer visual shows a 4821.30 score for the MotionMark browser benchmark, which tests browser graphics systems. This marks a nearly 3X improvement in the last year for Chrome.](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgfZGLpzRBjS94EVacu6g0-3vUD1M0ZelJBCzHuSkycdka39rckFmI2SXeQVgSrCUqInXwSF5mdgLHVv8wMcVa0pUF71ivHu6uIi7FaASm3PKVrODZbVo4F9fF2pzP9UnxELqXIPIKykx7ZeyX68mdenkoX77LwVpuvCG_pfOryHOjqSg-WWZe2p_TStw/w311-h320/Screenshot%202023-06-02%20at%203.13.54%20PM.png)

Chrome M115.0.5773.4 running on a 13” M2 Macbook Pro

Jetstream
---------

JetStream is a JavaScript and WebAssembly benchmark suite focused on advanced web applications. Many of the updates that we made for Speedometer also drove significant improvements on Jetstream as we optimized the V8 engine. In addition to these enhancements, Maglev drove the biggest gains in this benchmark. 

![A speedometer visual shows a 330.939 score for the Jetstream2 browser benchmark, which focuses on advanced web applications. This improvement is largely driven by Maglev, a new just-in-time compiler in Chrome.](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEii2MYIQ0Btj3SvA7mokzi746Nys8O3Fynw-jMO8C3UG8xa184hzAL4CVTF9Z9Z3Qqxm8M4SpbH24087haPJH6F57lqOy-8FSVsg96gAO7ICB5A7fpJWYI673KUQ7CYDjQRJs7pItbrcdC5jL0uFQoK_HlKaH6_YREynyJB3ir4srCVyiaQNNOZ-Ycisg/w320-h320/Screenshot%202023-06-02%20at%203.11.36%20PM.png)

Chrome 116.0.5803.2 running on an M2 Macbook Air with Maglev enabled

**Looking ahead**

Because we’re optimizing against these benchmarks, it’s essential that these improvements translate to real user benefits, which is why we’re investing, along with other browsers, in creating [the next generation of benchmarks](https://twitter.com/webkit/status/1603435731375992833?lang=en). This has been an ongoing collaboration, and we’re excited to turn our efforts toward this new target in the coming year.

We hope you all enjoy a faster Chrome! 

  

Posted by Thomas Nattestad, Product Manager