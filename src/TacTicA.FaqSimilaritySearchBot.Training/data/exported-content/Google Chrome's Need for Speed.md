URL:https://blog.chromium.org/2008/09/google-chromes-need-for-speed_02.html
# Google Chrome's Need for Speed
- **Published**: 2008-09-02T10:52:00.000-07:00
Ever since we opened the Google office in Aarhus, Denmark, I've been bombarded with the same question. What kind of virtual machine are you working on? Finally, I'm able to answer.  
It is an open source JavaScript engine and it is fast.  
  
A core part of any web browser is its JavaScript engine. Web applications cannot be responsive and stable without a fast and reliable JavaScript engine. Google Chrome features a new JavaScript engine, V8, that has been designed for performance from the ground up. In particular, we wanted to remove some common bottlenecks that limit the amount and complexity of JavaScript code that can be used in Web applications.  
  
The cornerstones of the V8 design are:  

* Compilation of JavaScript source code directly into native machine code.
* An efficient memory management system resulting in fast object allocation and small garbage collection pauses.
* Introduction of hidden classes and inline caches that speed up property access and function calls.

Virtual machines for object oriented languages have in the past used inline caching to speed up execution. However, this relies on objects with similar structure share the same runtime type.  
By dynamically creating hidden classes for JavaScript objects, V8 can apply optimizations only possible in virtual machines with runtime types.  
  
More design details can be found here: <http://code.google.com/apis/v8/design.html>.  
  
Along with V8 we have released a benchmark suite that reflects the kind of code we want to run fast: well-structured object-based applications with abstraction layers and many property accesses. As Web applications grow, we believe this suite will be representative of how Web developers write JavaScript code.  
  
The V8 benchmark suite consists of five medium sized standalone JavaScript applications: Richards, DeltaBlue, Crypto, RayTrace, and EarleyBoyer. A total more than 11,000 lines of JavaScript code. Web applications often spend considerable time waiting for the network connection, manipulating the DOM, and rendering pages. The V8 benchmark suite only measures pure JavaScript execution. Visit <http://code.google.com/apis/v8/benchmarks.html> to see how to run the suite.  
  
I hope the web community will adopt the code and the ideas we have developed to advance the performance of JavaScript. Raising the performance bar of JavaScript is important for continued innovation of web applications.  
  
V8 is an open source project and we encourage developers to visit <http://code.google.com/p/v8>.  
  
Posted by Lars Bak, Software Engineer 