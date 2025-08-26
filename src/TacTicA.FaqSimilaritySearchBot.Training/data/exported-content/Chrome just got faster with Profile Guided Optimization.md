URL:https://blog.chromium.org/2020/08/chrome-just-got-faster-with-profile.html
# Chrome just got faster with Profile Guided Optimization
- **Published**: 2020-08-25T09:01:00.006-07:00
From [the very beginning](https://www.youtube.com/watch?v=nCgQDjiotG0), we built Chrome to be the fastest browser possible. The faster Chrome is, the faster you find the information you want or finish the task you need to do. With M85, users will find a noticeably faster Chrome, thanks to our two latest improvements: **Profile Guided Optimization**, which delivers up to 10% faster page loads; and **Tab Throttling**, which helps reduce the impact of idle background tabs, coming to the Beta channel.

### Profile Guided Optimization

Simplified, Profile Guided Optimization (PGO) is a compiler optimization technique where the most performance-critical parts of the code can run faster. Because PGO uses real usage scenarios that match the workflows of Chrome users around the world, the most common tasks get prioritized and made faster. It is rolling out with Chrome M85 on Mac and Windows.

PGO was [initially introduced in M53](https://blog.chromium.org/2016/10/making-chrome-on-windows-faster-with-pgo.html) for Chrome on Windows using Microsoft Visual C++ (MSVC), our previous build environment. In M85, we are rolling out PGO on Mac and Windows using Clang. Our testing consistently shows pages loading up to 10% faster at the median, and even greater speed improvements when your CPU is tasked with running many tabs or programs.

|  |  |  |  |
| --- | --- | --- | --- |
| Platform | Browser Responsiveness\* | [First Contentful Paint](https://web.dev/fcp/)\*\* | [Speedometer 2.0](https://browserbench.org/Speedometer2.0/) |
| Mac | 3.9% faster | 2.3% faster | 7.7% faster |
| Windows | 7.3% faster | 3.5% faster | 11.4% faster |

### 

### Tab throttling coming to Beta

We know you need a lot of tabs to do your work, and with tab throttling - now rolling out on Beta channel - Chrome will give more resources to the tabs you’re using by taking them back from tabs that have been in the background for a long time. We see improvements not only in loading speed but also battery and memory savings. Watch this space for more on that work when it is broadly available!

Chrome's performance - speed and usage of resources like power, memory, or CPU - has always been top of mind. We have a dedicated engineering team that has been consistently (and quietly) making improvements so Chrome runs faster and smoother on all devices, operating systems, and internet conditions. No matter if you are a heavy tab user on your Windows laptop, or need a lightweight app experience on your Android phone, we are working hard to use your device resources most efficiently.

Posted by Max Christoff, Engineering Director, Chrome

*\*How fast your browser responds to user input (real world data anonymously aggregated from Chrome pre-stable channels)*

*\*\* The time it takes the first text or image to be displayed upon loading a page (real world data anonymously aggregated from Chrome pre-stable channels)*

  