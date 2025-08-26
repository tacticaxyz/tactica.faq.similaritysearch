URL:https://blog.chromium.org/2010/01/encouraging-more-chromium-security.html
# Encouraging More Chromium Security Research
- **Published**: 2010-01-28T13:59:00.000-08:00
In designing Chromium, we've been working hard to make the browser as secure as possible. We've made strong improvements with the [integrated sandboxing](http://seclab.stanford.edu/websec/chromium/chromium-security-architecture.pdf) and our [up-to-date user base](http://www.techzoom.net/publications/silent-updates/). We're always looking to stay on top of the [latest browser security features](http://blog.chromium.org/2010/01/security-in-depth-new-security-features.html). We've also worked closely with the broader security community to get independent scrutiny and to quickly fix bugs that have been reported.

Some of the most interesting security bugs we've fixed have been reported by researchers external to the Chromium project. For example, [this same origin policy bypass from Isaac Dawson](http://code.google.com/p/chromium/issues/detail?id=21338) or [this v8 engine bug found by the Mozilla Security Team](http://code.google.com/p/chromium/issues/detail?id=18639). Thanks to the collaborative efforts of these people and others, Chromium security is stronger and our users are safer.

Today, we are introducing an experimental new incentive for external researchers to participate. We will be rewarding select interesting and original vulnerabilities reported to us by the security research community. For existing contributors to Chromium security — who would likely continue to contribute regardless — this may be seen as a token of our appreciation. In addition, we are hoping that the introduction of this program will encourage new individuals to participate in Chromium security. The more people involved in scrutinizing Chromium's code and behavior, the more secure our millions of users will be.

Such a concept is not new; we'd like to give serious kudos to the [folks at Mozilla](http://www.mozilla.org/security/bug-bounty.html) for their long-running and successful vulnerability reward program.

Any valid security bug filed through the [Chromium bug tracker](http://code.google.com/p/chromium/issues/entry?template=Security%20Bug) (under the template "Security Bug") will qualify for consideration. As this is an experimental program, here are some guidelines in the form of questions and answers:

**Q) What reward might I get?**

A) As per Mozilla, our base reward for eligible bugs is $500. If the panel finds a particular bug particularly severe or particularly clever, we envisage rewards of $1337. The panel may also decide a single report actually constitutes multiple bugs. As a consumer of the Chromium open source project, Google will be sponsoring the rewards.

**Q) What bugs are eligible?**

A) Any security bug may be considered. We will typically focus on [High and Critical impact bugs](http://dev.chromium.org/developers/severity-guidelines), but any clever vulnerability at any severity might get a reward. Obviously, your bug won't be eligible if you worked on the code or review in the area in question.

**Q) How do I find out my bug was eligible?**

A) You will see a provisional comment to that effect in the bug entry once we have triaged the bug.

**Q) What if someone else also found the same bug?**

A) Only the first report of a given issue that we were previously unaware of is eligible. In the event of a duplicate submission, the earliest filed bug report in the [bug tracker](http://bugs.chromium.org/) is considered the first report.

**Q) What about bugs present in Google Chrome but not the Chromium open source project?**

A) Bugs in either build may be eligible. In addition, bugs in plugins that are part of the Chromium project and shipped with Google Chrome by default (e.g. Google Gears) may be eligible. Bugs in third-party plugins and extensions are ineligible.

**Q) Will bugs disclosed publicly without giving Chromium developers an opportunity to fix them first still qualify?**

A) We encourage responsible disclosure. Note that we believe responsible disclosure is a two-way street; it's our job to fix serious bugs within a reasonable time frame.

**Q) Do I still qualify if I disclose the problem publicly once fixed?**

A) Yes, absolutely. We encourage open collaboration. We will also make sure to credit you in the relevant Google Chrome release notes and nominate you for the [Google Security "thank you" section](http://www.google.com/corporate/security.html).

**Q) What about bugs in channels other than Stable?**

A) We are interested in bugs in the Stable, Beta and Dev channels. It's best for everyone to find and fix bugs before they are released to the Stable channel.

**Q) What about bugs in third-party components?**

A) These bugs may be eligible (e.g. WebKit, libxml, image libraries, compression libraries, etc). Bugs will be ineligible if they are part of the base operating system as opposed to part of the Chromium source tree. In the event of bugs in a component shared with other software, we are happy to take care of responsibly notifying other affected parties.

**Q) Who determines whether a given bug is eligible?**

A) The panel includes Adam Barth, Chris Evans, Neel Mehta, SkyLined and Michal Zalewski.

**Q) Can you keep my identity confidential from the rest of the world?**

A) Yes. If selected as the recipient of a reward, and you accept, we will need your contact details in order to pay you. However — at your discretion, we can credit the bug to "anonymous" and leave the bug entry private.

**Q) No doubt you wanted to make some legal points?**

A) Sure. We encourage participation from everyone. However, we are unable to issue rewards to residents of countries where the US has imposed the highest levels of export restriction (e.g. Cuba, Iran, North Korea, Sudan and Syria). We cannot issue rewards to minors, but would be happy to have an adult represent you. This is not a competition, but rather an ongoing reward program. You are responsible for any tax implications depending on your country of residency and citizenship. There may be additional restrictions on your ability to enter depending upon local law.

We look forward very much to issuing our first reward and featuring it on our [releases blog](http://googlechromereleases.blogspot.com/). We're happy to take questions at [security@chromium.org](mailto:security@chromium.org). Alternatively, feel free to leave a comment. We will update this blog post with answers to any popular questions.

Finally, if you're interested in helping out Chromium security on a more permanent basis, [we have open positions](http://www.google.com/support/jobs/bin/answer.py?answer=156185).

Posted by Chris Evans, Google Chrome Security