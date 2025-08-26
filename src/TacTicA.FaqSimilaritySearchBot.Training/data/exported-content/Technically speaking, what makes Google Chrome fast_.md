URL:https://blog.chromium.org/2009/12/technically-speaking-what-makes-google.html
# Technically speaking, what makes Google Chrome fast?
- **Published**: 2009-12-03T11:37:00.000-08:00
Earlier this year, we heard from many of you on [how important speed is](http://googleresearch.blogspot.com/2009/06/speed-matters.html) to your daily activities on the web. We [kicked off](http://googleblog.blogspot.com/2009/06/lets-make-web-faster.html) a series of discussions with the Internet community on ways to [make the web faster](http://code.google.com/speed/): from Internet protocols and best practices in website development, to improvements in the browser itself.

A lot of engineering effort is involved in making sure that a browser continually provides a fast, responsive, and satisfying experience on the web. We're excited to see modern browsers continue to push the envelope in designing and optimizing browser architecture for speed and performance.

We've often been asked what makes Google Chrome so fast -- from its snappy start-up time and fast page-loading, to the ability to run complex web applications quickly. To walk through some of the thought processes and technical decisions involved in making Google Chrome a fast browser, we've put together three technical interviews on DNS pre-resolution, the V8 JavaScript engine, and DOM bindings. In a future post, we'll also cover other important areas like WebKit and UI responsiveness.

  
  
**DNS pre-resolution**  
with Jim Roskind  
  

  
1. What is DNS pre-resolution, and how does it make Google Chrome even faster?
2. Why is DNS pre-resolution difficult to do?
3. Explain in more detail how adaptive pre-resolution works.
4. How else is DNS pre-resolution beneficial? Can it help with browser start-up time?
5. How do we measure and benchmark the benefits of DNS pre-resolution?
6. What's next for DNS pre-resolution?
  

  
  
**V8 JavaScript engine**  
with Mads Ager  
  
  

  
1. What is V8?
2. What are we currently doing to speed up JavaScript performance on V8?
3. How do we achieve big boosts in JavaScript speed, such as the recent 150% improvement since our initial launch?
4. How do we measure V8's performance?

  
  
**DOM bindings and more**  
with Mike Belshe  
  
  

  
1. What are DOM bindings?
2. What are the most recent improvements in DOM bindings, for Google Chrome as well as other browsers?
3. The Google Chrome beta release in August 2009 included improvements in DOM bindings. Tell us more.
4. How do we measure and benchmark improvements in DOM bindings?
5. In general, what are the biggest performance impediments for a browser?
6. What are some of the performance benefits of Google Chrome's multiprocess architecture?
  

  
  
  
Posted by Min Li Chan, Product Marketing Manager