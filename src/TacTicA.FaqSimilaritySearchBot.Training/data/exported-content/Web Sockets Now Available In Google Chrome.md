URL:https://blog.chromium.org/2009/12/web-sockets-now-available-in-google.html
# Web Sockets Now Available In Google Chrome
- **Published**: 2009-12-09T10:55:00.000-08:00
Starting in the Google Chrome [developer channel](http://www.chromium.org/getting-involved/dev-channel) release 4.0.249.0, Web Sockets are available and enabled by default. Web Sockets are "TCP for the Web," a next-generation bidirectional communication technology for web applications being standardized in part of [Web Applications 1.0](http://www.whatwg.org/specs/web-apps/current-work/complete.html). We've implemented this feature as described in our design docs for [WebKit](http://docs.google.com/View?docID=dfm7gfvg_0fpjg22gh&revision=_latest) and [Chromium](http://docs.google.com/View?docID=dfm7gfvg_1dm97qxgm&revision=_latest).

The [Web Sockets API](http://dev.w3.org/html5/websockets/) enables web applications to handle bidirectional communications with server-side process in a straightforward way. Developers have been using XMLHttpRequest ("XHR") for such purposes, but XHR makes developing web applications that communicate back and forth to the server unnecessarily complex. XHR is basically asynchronous HTTP, and because you need to use a tricky technique like long-hanging GET for sending data from the server to the browser, simple tasks rapidly become complex. As opposed to XMLHttpRequest, Web Sockets provide a real bidirectional communication channel in your browser. Once you get a Web Socket connection, you can send data from browser to server by calling a send() method, and receive data from server to browser by an onmessage event handler. A simple example is included below.

```
if ("WebSocket" in window) {  
  var ws = new WebSocket("ws://example.com/service");  
  ws.onopen = function() {  
    // Web Socket is connected. You can send data by send() method.  
    ws.send("message to send"); ....  
  };  
  ws.onmessage = function (evt) { var received_msg = evt.data; ... };  
  ws.onclose = function() { // websocket is closed. };  
} else {  
  // the browser doesn't support WebSocket.  
}
```

In addition to the new Web Sockets API, there is also a new protocol (the "[web socket protocol](http://tools.ietf.org/html/draft-hixie-thewebsocketprotocol-55)") that the browser uses to communicate with servers. The protocol is not raw TCP because it needs to provide the browser's "same-origin" security model. It's also not HTTP because web socket traffic differers from HTTP's request-response model. Web socket communications using the new web socket protocol should use less bandwidth because, unlike a series of XHRs and hanging GETs, no headers are exchanged once the single connection has been established. To use this new API and protocol and take advantage of the simpler programming model and more efficient network traffic, you do need a new server implementation to communicate with — but don't worry. We also developed [pywebsocket](http://code.google.com/p/pywebsocket), which can be used as an Apache extension module, or can even be run as standalone server.

You can use Google Chrome and pywebsocket to start implementing Web Socket-enabled web applications now. We're more than happy to hear your feedback not only on our implementation, but also on API and/or protocol design. The protocol has not been completely locked down and is still in discussion in IETF, so we are especially grateful for any early adopter feedback.

Posted by Yuzo Fujishima (藤島 勇造), Fumitoshi Ukai (鵜飼 文敏), and Takeshi Yoshino (吉野 剛史), Software Engineers