URL:https://blog.chromium.org/2011/02/chromium-to-feature-in-pwn2own-contest.html
# Chromium to Feature in Pwn2Own Contest!
- **Published**: 2011-02-07T10:30:00.000-08:00
We’re excited that the Google Chrome browser will [feature in this year’s Pwn2Own contest](http://dvlabs.tippingpoint.com/blog/2011/02/02/pwn2own-2011). Chrome wasn’t originally going to be included as a target browser in the competition, but Google volunteered to sponsor Chrome’s participation by contributing monetary rewards for Chrome exploits. For the past year we’ve enjoyed [working with the security community](http://blog.chromium.org/2010/01/encouraging-more-chromium-security.html) and [rewarding researchers](http://dev.chromium.org/Home/chromium-security/hall-of-fame) for high quality work through our [Chromium Security Reward program](http://blog.chromium.org/2010/07/celebrating-six-months-of-chromium.html). Sponsoring this contest to discover more bugs was a logical step. We thought we’d answer some frequently asked questions in the form of a Q&A session:

**Q) Is Chrome OS a target?**

A) No, not this year, as Chrome OS is still in beta. Per HP TippingPoint / ZDI guidelines, the actual target will be the latest stable version of the Chrome browser at the time, running on an up-to-date Windows 7 system. A Chrome OS device will, however, be awarded in addition to the prize money.

**Q) Are you betting that Chrome can’t be hacked?**

A) No. We think the Chrome browser has a strong security architecture, and Chrome has fared well in past years at Pwn2Own. But we know that web browsers from all vendors are very large pieces of software that invariably do have some bugs and complex external dependencies. That’s why the Chromium Security Reward program exists, along with our newer [web application reward program](http://googleonlinesecurity.blogspot.com/2010/11/rewarding-web-application-security.html). As a team comprised largely of security researchers, we think it’s important to reward the security community for their work which helps us learn. Naturally, we’ll learn the most from real examples of Chrome exploits.

**Q) How do the rules work?**

A) We worked with ZDI to come up with a rules structure that would reward exploits in code specific to Chromium and in third-party components such as the kernel or device drivers.

Of course, we prefer to pay rewards for bugs in our own code because we learn more and can make fixes directly. On day 1 of the competition, Google will sponsor $20,000 for a working exploit in Chrome, if it uses only Chrome bugs to compromise the browser and escape the sandbox. Days 2 and 3 will also allow for bugs in the kernel, device drivers, system libraries, etc., and the $20,000 prize will be sponsored at $10,000 by Google and $10,000 by ZDI to reflect the occurrence of the exploit partially outside of the Chrome code itself.

Note that ZDI is responsible for the rules and may change them at their own discretion.

**Q) Does this competition impact the Chromium Security Reward program?**

A) [The program still pays up to $3,133.7 per bug](http://blog.chromium.org/2010/07/celebrating-six-months-of-chromium.html). As always, submissions to the program don’t require exploits in order to be rewarded. In addition, we continue to reward classes of bugs (such as cross-origin leaks) that would otherwise not be eligible for prizes at Pwn2Own. We encourage researchers to continue submitting their bugs through the Chromium Security Reward program.

Posted by Chris Evans, Google Chrome Security Team