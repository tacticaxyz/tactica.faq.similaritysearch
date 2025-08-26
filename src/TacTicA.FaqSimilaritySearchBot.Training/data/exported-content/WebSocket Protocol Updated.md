URL:https://blog.chromium.org/2010/06/websocket-protocol-updated.html
# WebSocket Protocol Updated
- **Published**: 2010-06-02T17:29:00.000-07:00
WebSocket is "TCP for the Web," a next-generation full-duplex communication technology for web applications being standardized as a part of [Web Applications 1.0](http://www.whatwg.org/specs/web-apps/current-work/complete.html). The WebSocket protocol is more efficient than HTTP as used in Ajax, so it is more suitable for real time and dynamic web applications. WebSocket also provides a very simple API that can be used to communicate bidirectionally between the web browser and a server, so it makes it easy to develop such web apps.

We initially implemented WebSocket in WebKit, which has been available in WebKit nightly builds and in Google Chrome. The initial implementation was based on [draft-hixie-thewebsocketprotocol-75](http://tools.ietf.org/html/draft-hixie-thewebsocketprotocol-75). Early adopters were able to start developing web apps using WebSocket on real browsers, and provide feedback about the WebSocket specification.

Based on community feedback, the WebSocket specification has been updated to [draft-ietf-hybi-thewebsocketprotocol-00](http://www.ietf.org/id/draft-ietf-hybi-thewebsocketprotocol-00.txt) (also known as draft-hixie-thewebsocketprotocol-76).

This version relaxes requirements on handshake messages to make it easier to implement with HTTP libraries, and introduces nonce-based challenge-response to protect from cross protocol attacks. These changes make it incompatible with draft-hixie-thewebsocketprotocol-75; a client implementation of -75 can’t talk with a server implementation of -76, and vice versa.

Developers should be aware that starting from WebKit nightly build r59903 and Chrome 6.0.414.0 (r47952), the client will talk to a server using -76 version of the protocol, so it will fail to open WebSocket connections with a WebSocket server based on draft-hixie-thewebsocketprotocol-75. Since -75 version of the protocol is obsoleted and no longer supported in future version of browsers, to support new clients you need to update the server implementation. (Note that Chrome 5 uses -75 version of protocol).

The WebSocket protocol is still actively being changed. Until there is more consensus, we will continue to update our implementation to follow the latest draft of specification, rather than worrying about breaking changes.

We’re more than happy to hear your feedback, and encourage you to file any bugs you find on our [issue tracker](http://bugs.chromium.org/).

Posted by Fumitoshi Ukai (鵜飼文敏), Software Engineer