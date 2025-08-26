URL:https://blog.chromium.org/2009/06/developer-tools-for-google-chrome.html
# Developer Tools for Google Chrome
- **Published**: 2009-06-24T09:44:00.000-07:00
Since the [initial launch](http://googleblog.blogspot.com/2008/09/fresh-take-on-browser.html) of Google Chrome back in September we have had the Elements and Resources tabs of WebKit's [Inspector](http://webkit.org/blog/197/web-inspector-redesign/) available. We are now ready to present Inspector's Scripts and Profiles panels built on top of the V8 engine providing web developers with full-featured Javascript debugger and sample-based profiler in the [dev channel](http://dev.chromium.org/getting-involved/dev-channel) release of Google Chrome. We are also re-introducing the Elements and Resources tabs running out of process for better robustness, security and support for the new debugger and profiler setup.

You can invoke new developer tools by selecting "JavaScript console" from the Developer menu (or using Ctrl+Shift+J). For example, running the statistical profiler on the V8 benchmark suite (below screenshot) will give exact information on the actual code execution as the data is generated straight from running the optimized code from V8.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgIgClUmDMyht6ZVZ5q-tqicyNC5xke023Hh9nRhQxXbqJOqCGK_o6A8YZVZs3y-n3gdb2c9GLdRLUcLGzOkFq8-0reFEqGlV85jaO5tS8TvccolnWWoauE3y-cGwNYlgZdsykePTOUA74b/s400/dcq7s2gz_24c6f7jdhc_b.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgIgClUmDMyht6ZVZ5q-tqicyNC5xke023Hh9nRhQxXbqJOqCGK_o6A8YZVZs3y-n3gdb2c9GLdRLUcLGzOkFq8-0reFEqGlV85jaO5tS8TvccolnWWoauE3y-cGwNYlgZdsykePTOUA74b/s1600-h/dcq7s2gz_24c6f7jdhc_b.png)

As with the rest of Google Chrome, the developer tools are open source and built upon WebKit and in particular WebKit's Inspector. We would love to get feedback - both in terms of bugs reports and feature requests - on the Chromium public [issue tracker](http://code.google.com/p/chromium/issues/list?q=area%3DDevTools). Or even better yet, we would love to get contributions to improving developer tools further in WebKit and Google Chrome.

Posted by Yury Semikhatsky, Software Engineer