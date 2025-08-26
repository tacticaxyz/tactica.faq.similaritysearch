URL:https://blog.chromium.org/2021/12/faster-chrome-let-the-compiler-do-the-work.html
# Faster Chrome - Let The Compiler do the work
- **Published**: 2021-12-01T10:00:00.002-08:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjTMoYEIdhyB0zEy13cEqUkDosQm9WTI6b2uOlS2-FwwfovfDeub91dbJzjB7sVqp8JvRptqT032o0hywAGouB6SoELn9Zo6z8dRoT2_hWx-qYiTydYtltYbQt_sf2b206JRfIgAEm0xdNV/w578-h240/image1.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjTMoYEIdhyB0zEy13cEqUkDosQm9WTI6b2uOlS2-FwwfovfDeub91dbJzjB7sVqp8JvRptqT032o0hywAGouB6SoELn9Zo6z8dRoT2_hWx-qYiTydYtltYbQt_sf2b206JRfIgAEm0xdNV/s1999/image1.jpg)  
  
*Chrome is fast, but there's always room for improvement. Often, that's achieved by carefully crafting the algorithms that make up Chrome. But there's a lot of Chrome, so why not let computers do at least some part of our work? In this installment of [The Fast And the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious), we'll show you several changes in how we build Chrome to achieve a **25.8% higher score on Speedometer on Windows and a 22.0% increase in browser responsiveness.***  
  

Why speed?
==========

So why do we care about performance benchmarks? It's not a simple "higher numbers is better" chasing of achievements - performance was so important to Chrome that we embedded in our [core principles](https://www.chromium.org/developers/core-principles), the "4Ss" - Speed, Security, Stability, Simplicity. And speed matters because we want a browser that responds quickly. Speed matters so much because we want to build a faster and more responsive browser. And by improving the speed of the browser, there's the additional benefit of maximizing battery use, so you don't have to charge your laptop/devices as often.  
  
  

Speed? Size? Something Else?
============================

Let's look at a typical optimization.

> int foo();
>
> int fiver(int num) {
>
> for(int j = 0; j < 5; j++)
>
> num = num + foo();
>
> return num;
>
> }

The compiler can either compile this as a loop ([smaller](https://godbolt.org/z/ja7d6x7hE)), or turn it into five additions in a row ([faster, but bigger](https://godbolt.org/z/x76PohPz9))  
  
You save the cost of checking the end of the loop and incrementing a variable every time through the loop. But in exchange, you now have many repeated calls to foo(). If foo() is called a lot, that is a lot of space.  
  
And while speed matters a lot, we also care about binary size. (Yes, we see your memes!) And that tradeoff - exchanging speed for memory, and vice versa, holds for a lot of compiler optimizations.  
  
So how do you decide if the cost is worth it? One good way is to optimize for speed in areas that are run often, because your speed wins accumulate each time you run a function. You could just guess at what you inline (your compiler can do this, it's called "a heuristic", it's an educated guess), and then measure speed and code size.  
  
The result: Likely faster. Likely larger. Is that good?  
  
Ask any engineer a question like that, and they will answer “It depends”. So, how do you get an answer?  
  
  

The More You Know… (profiling & PGO)
====================================

The best way to make a decision is with data. We collect data based on what gets run a lot, and what gets run a little. We do that for several different scenarios, because our users do lots of different things with Chrome and want them to be fast.  
  
Our goal is collecting performance data in various scenarios, and using that to guide the compiler. There are 3 steps needed:  

1. Instrument for profiling
2. Run that instrumented executable in various scenarios
3. Use the resulting performance profile to guide the compiler.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj8UX1Gvrp7O9Z9l6q7atdjs1E8XhJ4nWxlLZboPoann09dFmi9NVimkKdN_3nyMCyhOXylL70s2ip_BsgrkIhzseLa7vIK52NVFAdol5SWeASSrfG0NYL6KhugX5C4wXI0gnHx9nBkpm9l/w548-h365/image2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj8UX1Gvrp7O9Z9l6q7atdjs1E8XhJ4nWxlLZboPoann09dFmi9NVimkKdN_3nyMCyhOXylL70s2ip_BsgrkIhzseLa7vIK52NVFAdol5SWeASSrfG0NYL6KhugX5C4wXI0gnHx9nBkpm9l/s1999/image2.png)

  

But we can do more (ThinLTO)
============================

That's a good start, but we can do better. Let's look at inlining - the compiler takes the code of a called function and inserts all of it at the callsite.

> inline int foo() { return 3; };
>
> int fiver\_inline(int num) {
>
> for(int j = 0; j < 5; j++)
>
> num = num + foo();
>
> return num;
>
> }

When the compiler inlines foo(), it turns into

> int fiver\_inline(int num) {
>
> for(int j = 0; j < 5; j++)
>
> num = num + 3;
>
> return num;
>
> }

Not bad - saves us the function call and all the setup that goes with having a function. But the compiler can in fact even do better - because now all the information is in one place. The compiler can apply that knowledge and deduce that fiver\_inline() adds the number three and does so 5 times - and so the entire code is [boiled down to](https://godbolt.org/z/dY1vGPYbj)

> return num + 15;

Which is awesome! But the compiler can only do this if the source code for foo() and the location where it is called are in the same source file - otherwise, the compiler does not know what to inline. (That's the fiver() example). A trivial way around that is to combine all the source files into one giant source file and compile and link that in one go.  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj8BzcLrQhHkvTNWkCVVYvXvGRC_a3s8XQ5WiLaUvbQZ6ipn_dafovEHOsIVPVw-E4BqniRWroaVW-02S38rYaLjyDNbrduQfOUF4tDvQIrdLe4q1-4uF8dbBHVtGc4DWXvSMawVRjAIYNz/w577-h384/image4.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj8BzcLrQhHkvTNWkCVVYvXvGRC_a3s8XQ5WiLaUvbQZ6ipn_dafovEHOsIVPVw-E4BqniRWroaVW-02S38rYaLjyDNbrduQfOUF4tDvQIrdLe4q1-4uF8dbBHVtGc4DWXvSMawVRjAIYNz/s1999/image4.png)  
  
  
There's just one downside - that approach needs to generate all of the machine code for Chrome, all the time. Change one line in one file, compile all of Chrome. And there's a lot of Chrome. It also effectively disables caching build results and so makes remote compilation much less useful. (And we rely a lot on remote compilation & caching so we can quickly build new versions of Chrome.)  
  
So, back to the drawing board. The core insight is that each source file only needs to include a few functions - it doesn't need to see every single other file. All that's needed is "cleverly" mixing the right inline functions into the right source files.   
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiIt3Ouc89cdmpjZsdj3zaVYfBr5fjS3VYwqkW2QORzF3vhll3kDLAdvYIE_vovOWUjDwHr7DXt3UpKLesNGxBD3CszjSbf4xgDRk-AzMgMq7lTrlIIXY6rpgXx9p17Ws5aoMYEWZO5k5p4/w608-h405/image3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiIt3Ouc89cdmpjZsdj3zaVYfBr5fjS3VYwqkW2QORzF3vhll3kDLAdvYIE_vovOWUjDwHr7DXt3UpKLesNGxBD3CszjSbf4xgDRk-AzMgMq7lTrlIIXY6rpgXx9p17Ws5aoMYEWZO5k5p4/s1999/image3.png)  
  
  
Now we're back to compiling individual source files. Distributed/cached compilation works again, small changes don't cause a full rebuild, and since "ThinLTO" does just inline a few functions, and it is relatively little overhead.  
  
Of course, the question of "which functions should ThinLTO inline?" still needs to be answered. And the answer is still "the ones that are small and called a lot". Hey, we know those already - from the profiles we generated for Profile Guided Optimization (PGO). Talk about lucky coincidences!  
  
  

But wait, there's more! (Callgraph Sorting)
===========================================

We've done a lot for inlined function calls. Is there anything we can do to speed up functions that haven't been inlined, too? Turns out there is.   
  
One important factor is that the CPU doesn't fetch data byte by byte, but in chunks. And so, if we could ensure that a chunk of data doesn't just contain the function we need right now, but ideally also the ones that we'll need next, we could ensure that we have to go out and get chunks of data less often.  
  
In other words, we want functions that are called right after the other to live next to each other in memory also ("code locality"). And we already know which functions are called close to each other - because we ran our profiling and stored performance profiles for PGO.  
  
We can then use that information to ensure that the right functions are next to each other when we link.  
  
  
I.e.

> g.c
>
> extern int f1();
>
> extern int f2();
>
> extern int f3();
>
> int g() {
>
> f1();
>
> for(..) {
>
> f3();
>
> }
>
> f1();
>
> f2();
>
> }

could be interpreted as "g() calls f3() a lot - so keep that one really close. f1() is called twice, so… somewhat close. And if we can squeeze in f2, even better". The calling sequence is a "call graph", and so this sorting process is called "call graph sorting".  
  
Just changing the order of functions in memory might not sound like a lot, but it leads to [~3% performance improvement](https://bugs.chromium.org/p/chromium/issues/detail?id=1113282). And to know which functions calls which other ones a lot… yep. You guessed it. Our profiles from the PGO work pay off again.  
  
  

One more thing.
===============

It turns out that the compiler can make even more use of that profile data for PGO. (Not a surprise - once you know where the slow spots are, exactly, you can do a lot to improve!). To make use of that, and enable further improvements, LLVM has something called the "new pass manager". In a nutshell, it's a new way to run optimizations within LLVM, and it helps a lot with PGO. For much more detail, I'd suggest reading the [LLVM blog post](https://blog.llvm.org/posts/2021-03-26-the-new-pass-manager/).   
  
Turning that on leads to another ~3% performance increase, and ~9MB size reduction.

Why Now?
========

Good question. One part of that is that PGO & profiling unlock an entire new set of optimizations, as you've seen above. It makes sense to do that all in one go.   
  
The other reason is our toolchain. We used to have a colorful mix of different technologies for compilers and linkers on different platforms.  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiFfNBpFNKtZU6og2qYYDDCMy-zyUx3BfEM1JtiTghtW28hCZgL8MZ3Hm-lTCyTvM-9rlUTsrKvQjPHvIzLmivvfPyjukj4a72vDkcwP2Dj5kGCwCr1cjQt1Vt79LladQN140itD6tavWMj/w478-h166/9NcAMNnoAe52Ly9.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiFfNBpFNKtZU6og2qYYDDCMy-zyUx3BfEM1JtiTghtW28hCZgL8MZ3Hm-lTCyTvM-9rlUTsrKvQjPHvIzLmivvfPyjukj4a72vDkcwP2Dj5kGCwCr1cjQt1Vt79LladQN140itD6tavWMj/s916/9NcAMNnoAe52Ly9.png)  
  
  
And since this work requires changes to compilers and linkers, that would mean changing the build - and testing it - across 5 compilers and 4 linkers. But, thankfully, we've simplified our toolchain (Simplicity - another one of the 4S's!). To be able to do this, we worked with the LLVM community to make clang a great [Windows compiler](https://blog.llvm.org/2018/03/clang-is-now-used-to-build-chrome-for.html), in addition to partnering with the LLVM community to create new ELF (Linux), COFF (Windows), and Mach-O (macOS, iOS) linkers.  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiif6su4dE04GQyDm7D6oXewenzOOb-2vHpA0asi8HUFB0F1rkXYna3j0tsEX0Z-iGzQoGI5p0Qm4Sk2oPGvgr_zwII8TY9HS6hWK6TxS_0ODeTjvfeOsaZhS6-oJ7ovc94rSRtjz_jMn2H/w476-h167/7kspjpiq3gfYBFE.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiif6su4dE04GQyDm7D6oXewenzOOb-2vHpA0asi8HUFB0F1rkXYna3j0tsEX0Z-iGzQoGI5p0Qm4Sk2oPGvgr_zwII8TY9HS6hWK6TxS_0ODeTjvfeOsaZhS6-oJ7ovc94rSRtjz_jMn2H/s921/7kspjpiq3gfYBFE.png)  
  
  
And suddenly, it's only a single toolchain to fix. (Almost. LTO for lld on MacOS is [being worked on](https://bugs.chromium.org/p/chromium/issues/detail?id=471146)).  
  
Sometimes, the best way to get more speed is not to change the code you wrote, but to change the way you build the software.  
  
Posted by Rachel Blum, Engineering Director, Chrome Desktop

*Data source for all statistics: [Speedometer 2.0](https://browserbench.org/Speedometer2.0/).*

  
  
  
  