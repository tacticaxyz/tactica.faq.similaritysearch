URL:https://blog.chromium.org/2021/05/chrome-is-faster-in-m91.html
# Chrome is up to 23% faster in M91 and saves over 17 years of CPU time daily
- **Published**: 2021-05-27T11:04:00.005-07:00
*Since the launch of Chrome in 2008, speed has been one of [the 4 core principles](https://www.chromium.org/developers/core-principles) that shape the work we do to deliver a highly performant browser. The V8 JavaScript compiler is a critical part of delivering maximum speed for the JavaScript that’s shipped on practically every web page. In our next post in [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) series, we are excited to share how improvements to the V8 engine are delivering up to 23% faster performance.*

An important component of delivering a fast browser is fast JavaScript execution. In Chrome, that job is done by the V8 engine which executes over 78 years worth of JavaScript code on a daily basis. In M91 Chrome is now up to 23% faster with the launch of a [new Sparkplug compiler](https://v8.dev/blog/sparkplug) and [short builtin calls](https://v8.dev/blog/short-builtin-calls), saving over 17 years of our users' CPU time each day! Sparkplug is a new JavaScript compiler that fills the gap between needing to start executing quickly and optimizing the code for maximum performance. Short builtin calls optimize where in memory we put generated code to avoid indirect jumps when calling functions.  
  
  
  

Sparkplug
---------

The V8 engine has multiple compilers which can make different tradeoffs throughout the various phases of executing JavaScript. Three years ago, we launched a new two-tier compiler system consisting of [Ignition and Turbofan](https://v8.dev/blog/launching-ignition-and-turbofan). Ignition is a bytecode interpreter whose job is to start executing the JavaScript with as little delay as possible. Turbofan is the optimizing compiler that generates high-performance machine code based on information gathered during JavaScript execution; as a result, it starts up more slowly than Ignition’s bytecode compiler. Sparkplug strikes a balance between Ignition and Turbofan in that it does generate native machine code but does not depend on information gathered while executing the JavaScript code. This lets it start executing quickly while still generating relatively fast code. For a complete technical deep dive into what it took to make this new engine, please see our [V8 blog post](https://v8.dev/blog/sparkplug).

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhQMxiLPcuO0vT5RIjl54zQjYDhfkFUu9NhcfGjQBJeOhyphenhyphen8nIq_OZ8FdsPszEOSCY5GrKvcvbfOaGnNsSySOc7yCl4s0IHIB1mgXOey_PzAlZrdokrR2K4CEQ7Jdbo1iE7B9tym-OO8l_DE/w640-h64/image1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhQMxiLPcuO0vT5RIjl54zQjYDhfkFUu9NhcfGjQBJeOhyphenhyphen8nIq_OZ8FdsPszEOSCY5GrKvcvbfOaGnNsSySOc7yCl4s0IHIB1mgXOey_PzAlZrdokrR2K4CEQ7Jdbo1iE7B9tym-OO8l_DE/s600/image1.png)

  

Short builtins
--------------

Short builtins is a mechanism by which the V8 engine optimizes the location in memory of generated code. When V8 generates CPU-specific code from JavaScript, it lays that code out in memory. This generated code will frequently call builtin functions, which are small snippets of code for handling common routines --everything from basic operations like adding two variables, to full-fledged functions in the JavaScript standard library. For some CPUs, calling functions that are further away from your generated code can cause CPU-internal optimizations (such as branch prediction logic) to fail. The fix for this is to copy the builtin functions into the same memory region as the generated code. This change is especially impactful for the new Apple M1 chip. Please see [our V8 blog post](https://v8.dev/blog/short-builtin-calls) to learn more about the impact across platforms of this feature.

Stay turned for many more performance improvements to come!

Posted by Thomas Nattestad, Chrome Product Manager  
  
  
*Data source for all statistics: [Speedometer 2.0](https://browserbench.org/Speedometer2.0/).*