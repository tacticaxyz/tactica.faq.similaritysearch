URL:https://blog.chromium.org/2009/06/launching-sputnik-into-orbit.html
# Launching Sputnik into Orbit
- **Published**: 2009-06-29T11:09:00.000-07:00
Today we're releasing the [Sputnik](http://code.google.com/p/sputniktests/) JavaScript test suite. Sputnik is a comprehensive set of more than 5000 tests that touch all aspects of the JavaScript language as defined in the [ECMA-262](http://www.ecma-international.org/publications/standards/Ecma-262.htm) standard.

Soon after the [V8](http://code.google.com/apis/v8/) project started we also began work on what would become the Sputnik tests. The goal was to create a test suite based directly on the language spec that checked the behavior of every object, function and individual algorithm in the language. The task was given to a team in Russia – hence the name "Sputnik" – which went about systematically producing tests. As the test suite grew we used it to ensure that V8 conformed to the spec and to detect unexpected changes in our behavior.

Now that the test suite is complete we're happy to be able to release it as an open source project, under the BSD license. We hope Sputnik can be as useful to other implementers of JavaScript as it has been to us, particularly at a time where implementations change rapidly.

The goal is not that all implementations should pass all tests. V8 set out with that intention and we learned the hard way that sometimes you have to be incompatible with the spec to be compatible with the web. Rather, we want Sputnik to be a tool for identifying differences between implementations.

One of the biggest challenges for web developers today is the many incompatibilities between browsers. Finding these differences is the first step towards removing them. In an ideal world web developers would not have to worry about which browser is being used to view their site and users would not have to worry about whether a site supported their browser. We hope the Sputnik tests will make the browser community take another step towards making that a reality.

Posted by Christian Plesner Hansen, Software Engineer