URL:https://blog.chromium.org/2010/09/web-graphics-past-present-and-future.html
# Web Graphics – Past, Present and Future
- **Published**: 2010-09-09T16:40:00.000-07:00
Recently, we [posted](http://blog.chromium.org/2010/08/chromium-graphics-overhaul.html) about the work we’re doing to re-architect Chromium’s graphics stack and use the GPU to accelerate rendering. As we mentioned last time, this work will help ensure that developers can take full advantage of emerging graphics standards like 3D CSS and WebGL in Chromium. To get more feedback about these cool new features, we’re enabling hardware compositing along with 3D CSS transforms and WebGL on the trunk (coming soon to the dev channel). These new capabilities are major additions to the web platform, so we wanted to take the time to provide some background information and explain how these new capabilities fit into the web.  
  
**SVG and canvas: dynamic 2D**  
  
Until recently, it wasn’t possible to create any dynamic (i.e. non-image) graphics on the web without a plug-in. Starting in 2005, this began to change as browsers began to add Scalable Vector Graphics (SVG) and HTML 2D canvas element support. Both SVG and 2D canvas allow you to compose a 2D image at run time and manipulate it to achieve animation effects, but they vary greatly in their approach to specifying how you draw an image.  
  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj3zbDk5PbCPGB57MzPEExdxmE9-EKJGTytfoXWEidMdtps_gOaR8fKjtSRkdXZAMaXfBMC17x1mrlT_byKGyZ_kmF0MizohSoPj5c7IigFHRCY2wFU6GbvsLYYX5zmyvseqhApZWqXXCE/s200/svg-butterfly.png)](http://www.croczilla.com/bits_and_pieces/svg/samples/butterfly/butterfly.svg)  

[*Mozilla's SVG butterfly*](http://www.croczilla.com/bits_and_pieces/svg/samples/butterfly/butterfly.svg)

> <?xml version="1.0"?>  
> <!DOCTYPE svg PUBLIC  
> "-//W3C//DTD SVG 1.1//EN"  
> "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">  
> <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">  
> <path style="stroke-width:1; fill:rgb(246,127,0); stroke:none" d="M204.33 13..."/>  
> <path style="stroke-width:1; fill:rgb(0,0,0); stroke:none" d="M203.62 139.62..." />  
> <path style="stroke-width:1; fill:rgb(255,246,227); stroke:none"  
> d="M363.73 85.73 C359.27 86.29 355.23 86.73..."/>  
> </svg>  
>   
> \*note: ellipses replace many more points

  
[![](http://www.chromeexperiments.com/detail/breathing-galaxies/img/ahBjaHJvbWV4cGVyaW1lbnRzchgLEg9FeHBlcmltZW50SW1hZ2UYmdfdAQw/large)](http://www.chromeexperiments.com/detail/breathing-galaxies/)

[*Michael Deal’s canvas “Breathing Galaxies”*](http://www.chromeexperiments.com/detail/breathing-galaxies/)

> d = document.getElementById("c");  
> c = d.getContext("2d");  
> ...  
> i = 25;  
> while (i--) {  
> c.beginPath();  
> ...  
> q = (R / r - 1) \* t;  
> // create hypotrochoid from current mouse position, and setup variables (see: http://en.wikipedia.org/wiki/Hypotrochoid)  
> x = (R - r) \* C(t) + D \* C(q) + ...  
> y = (R - r) \* S(t) - D \* S(q) + ...  
> if (a) {  
> // draw once two points are set  
> c.moveTo(a, b);  
> c.lineTo(x, y)  
> }  
> c.strokeStyle = "hsla(" + (U % 360) + ",100%,50%,0.75)";  
> // draw rainbow hypotrochoid  
> c.stroke();  
> ...  
> } \*note: ellipses replace code

  
  
The images above were created with SVG and canvas, but as you can see from the code, they approach graphics in a very different way: SVG allows you to provide markup that describes an image, whereas canvas allows you to describe a set of sequential steps that draw an image in JavaScript. These approaches mean that a developer changes an image that’s already been drawn, such as when animating an image, in different ways. Because the browser keeps a full representation of an SVG image, changing just a parameter in the image is enough to cause the browser to redraw the image correctly. With canvas, on the other hand, the developer must clear the image and specify all the steps to draw it again with the desired changes.  
  
Today, modern browsers, including Firefox, Safari, Opera and Google Chrome support creating 2D graphics with these technologies, and Internet Explorer is adding support for them in the upcoming version 9 release.  
  
**CSS Transforms: easy to use 2D and 3D effects**  
  
Even today, people primarily use apps that don’t strictly require advanced graphics, but eye candy like 3D transforms, transitions and reflections still help improve the experience of everyday tasks. While canvas could be used to create many of these effects, it can’t render them efficiently, and it would be hard to integrate with the other content on the page.  
  
CSS transforms and animations, which first appeared in WebKit in 2007, allow developers to achieve commonly used effects easily by specifying parameters in CSS that are applied to content in the DOM. In 2009, WebKit began adding 3D CSS transforms and effects, which takes flat content on the page and makes it appear as if it were in 3D space.  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjL3XYVlz3PgbnHJPq_UKSURR7ykjK9HZnfz5mXhZ9OfQ0LP9TaM88kYVouYalQ6-CSxiRNATYJLr_H-8MKmAx5UNgi8a2xk556YKylfwImDPLpeLUJdn6KNjt0tAi_WySFQxBWKsY7lr0/s320/safari.png)](http://developer.apple.com/safaridemos/showcase/transitions/)

[*Apple’s Cube Transition demo running in Chromium*](http://developer.apple.com/safaridemos/showcase/transitions/)

> /\* CUBE \*/  
> #transitions #cube {  
> -webkit-transform-style: preserve-3d;  
> width: 600px;  
> height: 400px;  
> position: absolute;  
> }  
> #transitions #cube.active {  
> -webkit-animation-duration: 1s;  
> -webkit-animation-iteration-count: 1;  
> -webkit-animation-name: cubedemo;  
> -webkit-transform: rotateX(-90deg);  
> }  
> #transitions #cube .face {  
> position: absolute;  
> width: 600px;  
> height: 400px;  
> display: block;  
> overflow: hidden;  
> }  
> #transitions #cube .front {  
> -webkit-transform: scale3d(.835,.835,.835) translateZ(200px);  
> }  
> #transitions #cube .back {  
> -webkit-transform: scale3d(.835,.835,.835) rotateY(180deg) translateZ(200px);  
> }  
> #transitions #cube .top {  
> -webkit-transform: scale3d(.835,.835,.835) rotateX(90deg) translateZ(200px);  
> }  
>   
> @-webkit-keyframes cubedemo {  
> 0% {-webkit-transform: rotateX(0); -webkit-animation-timing-function: linear; }  
> 50% {-webkit-transform: rotateX(-92deg);-webkit-animation-timing-function: ease-in; }  
> 70% {-webkit-transform: rotateX(-84deg); -webkit-animation-timing-function: ease-in; }  
> 80% {-webkit-transform: rotateX(-90deg); -webkit-animation-timing-function: ease-in; }  
> 95% {-webkit-transform: rotateX(-88deg); -webkit-animation-timing-function: ease-in; }  
> 100% { -webkit-transform: rotateX(-90deg); }  
> }

  
As you can see from this example, 3D CSS transforms and animations make it easy to add polished 3D effects to your app. Now that we support hardware compositing in Chromium, it’s easy to perform these transforms on the GPU and display it quickly on screen, so we’ve enabled them along with the compositor. Currently, this functionality is only available in Safari and Google Chrome but Firefox is [working on](https://bugzilla.mozilla.org/show_bug.cgi?id=505115) an implementation as well, making it a great option to add impressive effects to your app in the future.  
  
**WebGL: Low-level dynamic 3D**  
  
While 3D CSS makes it easy to display 2D content so that it looks like it’s in a 3D space, it’s not designed for writing true 3D applications like CAD software or modern games. WebGL, on the other hand, provides access to all the functionality of OpenGL ES 2.0 from JavaScript, and is designed with exactly these types of applications in mind.  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiDTKoLiRRBdQMZV8WujQj4GfM1k8Q7up6HCe6rMV00Lq9hjihDnbrgx56uzxiaxazfzu8y2uNBIC4u3sUGeNIQj66x8yc4Pae4AD6cTho7F2e2VmOZRtdQJ4F3fdeUFFvKEwXPMp6q1MI/s320/sphericalharmonics.png)](http://www.spidergl.org/example.php?id=12)

*[SpiderGL Spherical Harmonics](http://www.spidergl.org/example.php?id=12)*

**(link requires a WebGL-enabled browser)**[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhzrlA4KBPpdVoKmtOJrTCB_8kOLwfEqTh3GmWNcU0p37hanbfUOCwb7yjUOorJO4PfR_IxQqS-orLRoD2tAdqQzDlzJanYXv419fDF8ciyCHxhr6hw384NPRrVHXFP5x68kmNbLypqeGg/s320/o3dpool.png)](http://o3d.googlecode.com/svn/trunk/samples_webgl/o3d-webgl-samples/pool.html)

*[Pool game using WebGL implementation of O3D](http://o3d.googlecode.com/svn/trunk/samples_webgl/o3d-webgl-samples/pool.html)*

**(link requires a WebGL-enabled browser)*

*With WebGL you can navigate 3D environments, rotate around objects with volume, add realistic lighting, and render shadows and reflections like those above. Creating a scene like this just wouldn’t be possible in real-time with 3D CSS, let alone a 2D canvas or SVG. To achieve these effects, you need direct access to graphics hardware – which is exactly what WebGL provides.*

  

*With power comes complexity, so there is definitely a learning curve to using WebGL. The good news is that because it’s based on OpenGL ES 2.0, it should be familiar to people with graphics programming experience. A number of JavaScript libraries that make WebGL more accessible are already available, for example, the examples above use two frameworks: [SpiderGL](http://spidergl.org/) and the [WebGL implementation of O3D](http://code.google.com/p/o3d/). As the technology matures, expect to see other tools and libraries emerge to make it even easier to author content. A popular blog in the community, [Learning WebGL](http://learningwebgl.com/blog/) has done a great job of keeping up with the latest libraries, tools and demos and has a substantial archive of WebGL resources.*

  

Mozilla, Apple, Opera and Google are all working on putting the finishing touches on the WebGL spec in a Khronos working group, which is expected to hit v1.0 by the end of the year, but we’ve turned it on by default to get early feedback on Chromium’s implementation.

Thanks for reading to the end, we hope this helps explain the current state of graphics on the Web!

  
  

*Posted by Henry Bridge, Product Manager**