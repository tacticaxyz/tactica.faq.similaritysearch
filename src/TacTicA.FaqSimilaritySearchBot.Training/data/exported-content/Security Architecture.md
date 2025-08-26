URL:https://blog.chromium.org/2008/09/security-architecture.html
# Security Architecture
- **Published**: 2008-09-10T14:59:00.000-07:00
Chromium helps protect your computer from malware by running some parts of the browser in a sandbox.  The sandbox tries to limit what an attacker can do after exploiting a bug.  In particular, the sandbox aims to prevent malicious web sites from automatically installing software on your computer and from reading confidential files on your hard drive.

The two main modules of Chromium are the browser process and the rendering engine.  The browser process has the same access to your computer that you do, so we try to reduce its attack surface by keeping it as simple as possible.  For example, the browser process does not attempt to understand HTML, JavaScript, or other complex parts of web pages.  The rendering engine does the heavy lifting: laying out web pages and running JavaScript.

To access your hard drive or the network, the rendering engine must go through the browser process, which checks to make sure the request looks legitimate.  In a sense, the browser process acts like a supervisor that double-checks that the rendering engine is acting appropriately.  The sandbox doesn't prevent every kind of attack (for example, it doesn't stop phishing or cross-site scripting), but it should make it harder for attackers to get to your files.

To see how well this architecture might mitigate future attacks, we studied recent vulnerabilities in web browsers.  We found that about 70% of the most serious vulnerabilities (those that let an attacker execute arbitrary code) were in the rendering engine.  Although "number of vulnerabilities" is not an ideal metric for evaluating security, these numbers do suggest that sandboxing the rendering engine is likely to help improve security.

To learn more, check out our [technical report](http://crypto.stanford.edu/websec/chromium/) on Chromium's security architecture.

Posted by Adam Barth, Collin Jackson, and Charlie Reis, Software Engineers