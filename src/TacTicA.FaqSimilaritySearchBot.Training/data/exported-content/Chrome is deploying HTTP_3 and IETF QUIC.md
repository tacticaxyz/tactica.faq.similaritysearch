URL:https://blog.chromium.org/2020/10/chrome-is-deploying-http3-and-ietf-quic.html
# Chrome is deploying HTTP/3 and IETF QUIC
- **Published**: 2020-10-07T09:27:00.000-07:00
QUIC is a new networking transport protocol that combines the features of TCP, TLS, and more. HTTP/3 is the latest version of HTTP, the protocol that carries the vast majority of Web traffic. HTTP/3 only runs over QUIC.  
  
  
QUIC was initially developed by Google and [first announced in 2013](https://blog.chromium.org/2013/06/experimenting-with-quic.html). Since then, the protocol has matured, and is now responsible for carrying over a third of Google traffic. In 2015, Google brought QUIC to the IETF (the standards organization responsible for maintaining the Internet's protocols) and the IETF has been improving QUIC by making many changes to it. At this point, there are now two similar but different protocols: Google QUIC and IETF QUIC. The QUIC team at Google has been involved in the IETF process from the start, but we've been using Google QUIC in Chrome while working on implementing IETF QUIC. We've put tremendous effort into evolving Google QUIC over the last five years to track changes at IETF, and the current latest Google QUIC version (Q050) has many similarities with IETF QUIC. But up until now, the majority of Chrome users didn't communicate with IETF QUIC servers without enabling some command-line options.  
  
  
Today this changes. We've found that IETF QUIC significantly outperforms HTTP over TLS 1.3 over TCP. In particular, Google search latency decreases by over 2%. YouTube rebuffer time decreased by over 9%, while client throughput increased by over 3% on desktop and over 7% on mobile. We're happy to announce that Chrome is rolling out support for IETF QUIC (specifically, draft version h3-29). Today 25% of Chrome Stable users are using h3-29, and we plan on increasing that number over the coming weeks as we continue to monitor performance data. Chrome will actively support both IETF QUIC h3-29 and Google QUIC Q050 to provide servers that support Q050 with time to update to IETF QUIC.  
  
  
Chrome m85 doesn't yet support IETF QUIC 0-RTT, so we expect these performance numbers to look even better once we launch 0-RTT support for IETF QUIC in the coming months.  
  
  
Since the subsequent IETF drafts 30 and 31 do not have compatibility-breaking changes, we currently are not planning to change the over-the-wire identifier. What this means is that while we'll keep tracking changes in the IETF specification, we will be deploying them under the h3-29/0xff00001d name. We therefore recommend that servers keep support for h3-29 until the final RFCs are complete if they wish to interoperate with Chrome. However, if the IETF were to make compatibility-breaking changes in a future draft, Chrome will revisit this decision.  
  
  
The authors would like to thank the entire QUIC team at Google for all their hard work leading up to this announcement. We're incredibly proud of what we've achieved together. We would also like to thank everyone who has contributed to QUIC at the IETF, and all of the former members of the QUIC team at Google, without whom none of this would have been possible.  
  
  
  
  
Posted by

David Schinazi - Chrome QUIC Tech Lead

Fan Yang - Google Front End QUIC Tech Lead

Ian Swett - Web Performance Tech Lead Manager