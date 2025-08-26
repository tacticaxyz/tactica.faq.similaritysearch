URL:https://blog.chromium.org/2009/05/scaling-javascript-to-large-web.html
# Scaling JavaScript to Large Web Applications
- **Published**: 2009-05-21T09:14:00.000-07:00
The V8 JavaScript engine has been designed for scalability. What does scalability mean in the context of JavaScript and why is it important for modern web applications?

Web applications are becoming more complex. With the increased complexity comes more JavaScript code and more objects. An increased number of objects puts additional stress on the memory management system of the JavaScript engine, which has to scale to deal efficiently with object allocation and reclamation. If engines do not scale to handle large object heaps, performance will suffer when running large web applications.

In browsers without a [multi-process architecture](http://blog.chromium.org/2008/09/multi-process-architecture.html), a simple way to see the effect of an increased working set on JavaScript performance is to log in to GMail in one tab and run JavaScript benchmarks in another. The objects from the two tabs are allocated in the same object heap and therefore the benchmarks are run with a working set that includes the GMail objects.

V8's approach to scalability is to use [generational garbage collection](http://en.wikipedia.org/wiki/Generational_garbage_collection). The main observation behind generational garbage collection is that most objects either die very young or are long-lived. There is no need to examine long-lived objects on every garbage collection because they are likely to still be alive. Introducing generations to the garbage collector allows it to only consider newly allocated objects on most garbage collections.

**Splay: A Scalability Benchmark**

To keep track of how well V8 scales to large object heaps, we have added a new benchmark, Splay, to [version 4](http://v8.googlecode.com/svn/data/benchmarks/v4/run.html) of the V8 benchmark suite. The Splay benchmark builds a large [splay tree](http://en.wikipedia.org/wiki/Splay_tree) and modifies it by creating new nodes, adding them to the tree, and removing old ones. The benchmark is based on a JavaScript log processing module used by the V8 profiler and it effectively measures how fast the JavaScript engine can allocate nodes and reclaim unused memory. Because of the way splay trees work, the engine also has to deal with a lot of changes to the large tree.

We have measured the impact of running the Splay benchmark with different splay tree sizes to test how well V8 performs when the working set is increased:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjCytf0G95weRDTnpObwGstubnWJydSbCz4fIpHUI2fmLcnrv-IkNuw9whXdjufiMuJQ8fc6GYtEKIP7EKsgDrp1sDIQGdHgOo_GTJzRaZQNchjwJqQUe78gtFhriKnkWAlctSiCatjLZTx/s320/dcq7s2gz_3hjphqsdh_b.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjCytf0G95weRDTnpObwGstubnWJydSbCz4fIpHUI2fmLcnrv-IkNuw9whXdjufiMuJQ8fc6GYtEKIP7EKsgDrp1sDIQGdHgOo_GTJzRaZQNchjwJqQUe78gtFhriKnkWAlctSiCatjLZTx/s1600-h/dcq7s2gz_3hjphqsdh_b.png)

The graph shows that V8 scales well to large object heaps, and that increasing the working set by more than a factor of 7 leads to a performance drop of less than 17%. Even though 35 MB is more memory than most web applications use today, it is necessary to support such working sets to enable tomorrow's web applications.

Posted by Mads Ager and Kasper Lund, Software Engineers