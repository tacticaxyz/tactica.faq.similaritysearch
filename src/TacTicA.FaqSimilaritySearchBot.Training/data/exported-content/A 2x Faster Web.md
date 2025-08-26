URL:https://blog.chromium.org/2009/11/2x-faster-web.html
# A 2x Faster Web
- **Published**: 2009-11-11T22:39:00.000-08:00
Today we'd like to share with the web community information about SPDY, pronounced "SPeeDY", an early-stage research project that is part of our effort to [make the web faster](http://code.google.com/speed). SPDY is at its core an application-layer protocol for transporting content over the web. It is designed specifically for minimizing latency through features such as multiplexed streams, request prioritization and HTTP header compression.

We started working on SPDY while exploring ways to optimize the way browsers and servers communicate. Today, web clients and servers speak HTTP. HTTP is an elegantly simple protocol that emerged as a web standard in 1996 after a series of experiments. HTTP has served the web incredibly well. We want to continue building on the web's tradition of experimentation and optimization, to further support the evolution of websites and browsers. So over the last few months, a few of us here at Google have been experimenting with new ways for web browsers and servers to speak to each other, resulting in a prototype web server and Google Chrome client with SPDY support.

So far we have only tested SPDY in lab conditions. The initial results are very encouraging: when we download the top 25 websites over simulated home network connections, we see a significant improvement in performance - pages loaded up to 55% faster. There is still a lot of work we need to do to evaluate the performance of SPDY in real-world conditions. However, we believe that we have reached the stage where our small team could benefit from the active participation, feedback and assistance of the web community.

For those of you who would like to learn more and hopefully contribute to our experiment, we invite you to review our early stage [documentation](http://dev.chromium.org/spdy), look at our current [code](http://src.chromium.org/viewvc/chrome/trunk/src/net/flip/) and provide feedback through the Chromium [Google Group](http://groups.google.com/group/chromium-discuss/).

Posted by Mike Belshe, Software Engineer and Roberto Peon, Software Engineer   

This post is cross-posted at the [Google Research Blog](http://googleresearch.blogspot.com/2009/11/2x-faster-web.html)