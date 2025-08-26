URL:https://blog.chromium.org/2021/07/m92-faster-and-more-efficient-phishing-detection.html
# Faster and more efficient phishing detection in M92
- **Published**: 2021-07-20T09:58:00.006-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiht1qYWkZjrcqV7WYfn9w2MM-ht5UWOThRPnECXqGBlEHTobQhMkcG6Ar2wFig61BbX9jBVO-jW2kkC35lsYkmb4KCEOTz9G9DyxedvS2oMKCYa-DJwTzG0n1yvc7OqM2TS0W93_RXZcBx/w622-h259/image1.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiht1qYWkZjrcqV7WYfn9w2MM-ht5UWOThRPnECXqGBlEHTobQhMkcG6Ar2wFig61BbX9jBVO-jW2kkC35lsYkmb4KCEOTz9G9DyxedvS2oMKCYa-DJwTzG0n1yvc7OqM2TS0W93_RXZcBx/s1999/image1.jpg)

  
*Keeping Chrome users safe as they browse the web is crucially important to Chrome; in fact, security has always been one of our four [core principles](https://www.chromium.org/developers/core-principles). In some cases, security can come at the expense of performance. In our next post in [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) series, we are excited to share how improvements to our phishing detection algorithms keeps users safe online. With these improvements, phishing detection is now **50 times faster and drains less battery**.*  
  

Phishing detection
------------------

Every time you navigate to a new page, Chrome evaluates a collection of signals about the page to see if it matches those of phishing sites. To do that, we compare the color profile of the visited page - that’s the range and frequency of the colors present on the page - with the color profiles of common pages. For example in the image below, we can see that the colors are mostly orange, followed by green and then a touch of purple.   
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgNLgxfdSdZ76iza11mgXXObJFwZmNAU8xWyB3qX3qjlXKhhFiRxlPQYK4B3klwDS6T0_S4B5pIVhL87jFwbZnrZLrQToqy2HbiluWkIGlAqxR5laMNOczLeuIvuCrzm1b4ngE23aMnK2ip/w640-h424/image3.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgNLgxfdSdZ76iza11mgXXObJFwZmNAU8xWyB3qX3qjlXKhhFiRxlPQYK4B3klwDS6T0_S4B5pIVhL87jFwbZnrZLrQToqy2HbiluWkIGlAqxR5laMNOczLeuIvuCrzm1b4ngE23aMnK2ip/s1386/image3.jpg)  
  
  
If the site matches a known phishing site, Chrome warns you to protect your personal information and prevent you from exposing your credentials.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjD4Erh0Y4UBzahU5nq_9FXfr99o9UjecSNoK715K068Qzso8h7Z7MJ2XTWzZQbmH6PU-sPHxtaq-NBHzb9jd3aJGpa_D_xyNxOJByi2lUep_JsBlcxwpi3KnYn8a8VepwZ3grCePGj3kFb/w640-h358/image7.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjD4Erh0Y4UBzahU5nq_9FXfr99o9UjecSNoK715K068Qzso8h7Z7MJ2XTWzZQbmH6PU-sPHxtaq-NBHzb9jd3aJGpa_D_xyNxOJByi2lUep_JsBlcxwpi3KnYn8a8VepwZ3grCePGj3kFb/s909/image7.png)

*What you will see if a phishing attempt is detected*  
  
To preserve your privacy, by default Chrome's [Safe Browsing](https://safebrowsing.google.com/) mode never sends any images outside the browser. While this is great for privacy, it means that your machine has to do all the work to analyze the image.   
  
Image processing can often generate heavy workloads because analyzing the image requires an evaluation of each pixel in what is commonly known as a “pixel loop.” Some modern monitors display upwards of 14 million pixels, so even simple operations on each of those pixels can add up to a lot of CPU use! For phishing detection, the operation that takes place on each pixel is the counting of its basic colors.  
  
Here is what this looks like. The counts are stored in an associative data structure called a hashmap. For each pixel, we extract its RGB color values and store the counts in one of 3 different hashmaps -- one for each color.  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjerJwkAM9BHqmvttfwtCxpdHX_qVga-gY54F_Gq4ZK-P9FG9Ysubq-mX13h-bj63AoOzXW1K2F3axdhl_jl4Fvrz74P3t_VZcefV3LPjkIAtoeZkAwz9aH6uo6GSYMdkCkhdugS0iid0Vo/w640-h426/image2.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjerJwkAM9BHqmvttfwtCxpdHX_qVga-gY54F_Gq4ZK-P9FG9Ysubq-mX13h-bj63AoOzXW1K2F3axdhl_jl4Fvrz74P3t_VZcefV3LPjkIAtoeZkAwz9aH6uo6GSYMdkCkhdugS0iid0Vo/s1386/image2.jpg)  
  
  

Making it more efficient
------------------------

Adding one item to a hashmap is fast, but we have to do this for millions of pixels. We try to avoid reducing the number of pixels to avoid compromising the quality of the analysis. However, the computation itself can be improved.   
  
Our improvements to the pipeline look like this:

* The code now avoids keeping track of RGB channels in three different hashmaps and instead uses only one to index by color. Three times less counting!
* Consecutive pixels are summed before being counted in the hashmap. For a site with a uniform background color, this can reduce the hashmap overhead to almost nothing.

Here is what the counting of the colors looks like now. Notice how there are significantly fewer operations on the hashmap:  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgPSOP7VUQBt-WokwUYZ_GtWrsApjmfw6nn1j6b36wjHPmx5X8jpZg4skkZw9XOmULY3sJc424EtraqIsbq2jkol2x91aSvAvGDd3Ijo_Ank9RmxM-HMh7NuCMUQ0v0MY4yPZ-xcSZTm2Oh/w640-h426/image5.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgPSOP7VUQBt-WokwUYZ_GtWrsApjmfw6nn1j6b36wjHPmx5X8jpZg4skkZw9XOmULY3sJc424EtraqIsbq2jkol2x91aSvAvGDd3Ijo_Ank9RmxM-HMh7NuCMUQ0v0MY4yPZ-xcSZTm2Oh/s1386/image5.jpg)  
  
  

How much faster did this get?
-----------------------------

Starting with M92, Chrome now executes image-based phishing classification up to **50 times faster** at the 50th percentile and **2.5 times faster** at the 99th percentile. On average, users will get their phishing classification results after **100 milliseconds, instead of 1.8 seconds**.  
  
This benefits you in two ways as you use Chrome. First and foremost, using less CPU time to achieve the same work improves general performance. Less CPU time means less battery drain and less time with spinning fans.

Second, getting the results faster means Chrome can warn you earlier. The optimization brought the percentage of requests that took more than 5 seconds to process from 16.25% to less than 1.6%. This speed improvement makes a real difference in security - especially when it comes to stopping you from entering your password in a malicious site!

Overall, these changes achieve a reduction of almost **1.2% of the total CPU** time used by all Chrome renderer processes and utility processes.

At Chrome’s scale, even minor algorithm improvements can result in major energy efficiency gains in aggregate. Here’s to many more centuries of CPU time saved!  
  
Stay tuned for many more performance improvements to come!  
  
Posted by Olivier Li Shing Tat-Dupuis, Chrome Developer  
  
*Data source for all statistics: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.*

  
  