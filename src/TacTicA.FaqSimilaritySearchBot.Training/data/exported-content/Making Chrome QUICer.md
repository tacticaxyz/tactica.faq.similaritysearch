URL:https://blog.chromium.org/2024/12/making-chrome-quicer.html
# Making Chrome QUICer
- **Published**: 2024-12-17T10:09:00.000-08:00
In October 2020, Chrome enabled [HTTP/3 by default](https://blog.chromium.org/2020/10/chrome-is-deploying-http3-and-ietf-quic.html). HTTP/3 ([RFC 9114](https://datatracker.ietf.org/doc/html/rfc9114)) runs over IETF QUIC ([RFC9000](https://datatracker.ietf.org/doc/html/rfc9000)). Default-enabling HTTP/3 in Chrome resulted in improved performance compared not only HTTP/1 and HTTP/2, but also Google QUIC. Benefits included reduced Google search latency and fewer rebuffers for YouTube.

The journey to optimizing performance did not end when HTTP/3 was default enabled. Recent advancements include the implementation of the HTTP/3 ORIGIN frame ([RFC 9412](https://httpwg.org/specs/rfc9412.html)) and Server's Preferred Address ([RFC 9000 Section 9.6](https://datatracker.ietf.org/doc/html/rfc9000#name-servers-preferred-address)). The former enhances connection coalescing, while the latter reduces a connection's round trip time (RTT). Both features have been enabled by default in M131, which was released to Stable on 11/19.

### ORIGIN Frame

When a connection is established for a specific hostname, the server’s certificate typically contains numerous other hostnames for which the server is authoritative. However, a client cannot immediately send requests for those other hostnames on that connection without first performing a DNS lookup for the other hostname and verifying that the IP address of the connection matches the resolved address. This additional DNS resolution introduces latency and significantly reduces the likelihood of connection pooling due to potential IP mismatches. The metrics from Chrome indicate that nearly 20% of HTTP/3 connections would be unnecessary if not for this IP mismatch.

Creating a new connection, even with QUIC 0-RTT, is expensive in terms of latency, memory, and CPU usage. This is because:

* DNS resolution adds latency unless cached locally in Chrome’s DNS cache.
* Both client and server must send multiple packets to complete a QUIC handshake.
* TLS necessitates CPU-intensive asymmetric cryptography on both ends.
* The congestion controller begins in its default state, potentially leading to under or over-sending.
* 0-RTT might fail.
* Non-safe requests aren't sent via 0-RTT.
* More connections consume more memory.

Additionally, features like HTTP priorities ([RFC 9218](https://datatracker.ietf.org/doc/rfc9218/)) are only effective if there are multiple simultaneous responses to send.

The HTTP/3 ORIGIN Frame ([RFC 9412](https://httpwg.org/specs/rfc9412.html)) enables a server to indicate what domains it would like to pool onto a connection. Additionally, once the frame is received, it indicates other domains should not be pooled onto that connection, even if they are in the certificate.

### Server’s Preferred Address

In some cases, the initial server address to which the client connects is not the most efficient route. It might be behind an L4 load balancer, and connecting directly could increase stability. Particularly when using Anycast, it’s possible the server is distant from where traffic enters the network, creating a 3-legged path that increases the round trip time.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhPbECfw3krb6-1DM-wQBsBpPLhcLNGwGVMzEFW_XzUpumvfQzJSvVLJfZ1iwCyowq9QRE2bwl-GsQ8eArforqyyEBadmNN2iwUP59p3Rl428qWPqaJFu2JYe9o7QsuWa20R1s_isnM7efkNIMSetkmnyhFuQOtRt1-7G_e4NNb-BSfXP-DhVB_X5c6QZ0V/s1600/Screenshot%202024-12-17%2012.07.47%20PM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhPbECfw3krb6-1DM-wQBsBpPLhcLNGwGVMzEFW_XzUpumvfQzJSvVLJfZ1iwCyowq9QRE2bwl-GsQ8eArforqyyEBadmNN2iwUP59p3Rl428qWPqaJFu2JYe9o7QsuWa20R1s_isnM7efkNIMSetkmnyhFuQOtRt1-7G_e4NNb-BSfXP-DhVB_X5c6QZ0V/s1600/Screenshot%202024-12-17%2012.07.47%20PM.png)

Once the handshake is confirmed, Server’s Preferred Address allows a server to indicate it would like the client to migrate to a different server IP. Though a QUIC connection is not bound to a single 4-tuple like TCP, this is the only type of migration in RFC9000 where the server can change its address.

So far, only Google’s [Media CDN](https://cloud.google.com/media-cdn/docs/overview) has widely enabled advertising an alternative address, but we expect more servers to adopt it soon. Testing has shown that this migration is successful over 99% of the time in Chrome and reduces average RTT by 40-80%.

Posted by Fan Yang and Ian Swett 