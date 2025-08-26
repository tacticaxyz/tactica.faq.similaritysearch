URL:https://blog.chromium.org/2009/06/plausible-promise.html
# The Plausible Promise
- **Published**: 2009-06-09T11:21:00.000-07:00
With the release of Mac Chrome to the dev-channel, I wanted to talk about open source and expectations. What was the point of releasing at this stage, you might ask? It's clearly not finished. Clearly. It's missing a large number of features, some half implemented, others not at all. Why even bother? Doesn't it just make us look bad?

Open source projects aren't simply about a runnable binary, they're about the community of users, testers, and developers who devote their time and skills to working on a product they believe in. They go hand in hand: there's no binary without the community and there's no community without the binary. At some point in the life-cycle of a project, you have to stop thinking solely about your small band of developers and start growing the larger supporting community that will become your users, testers, localizers, documentation writers, and possibly even new coders.

In "The Cathedral and the Bazaar", Eric Raymond writes:

> "When you start community-building, what you need to be able to present is a plausible promise. Your program doesn't have to work particularly well. It can be crude, buggy, incomplete, and poorly documented. What it must not fail to do is (a) run, and (b) convince potential co-developers that it can be evolved into something really neat in the foreseeable future."

We in the Chromium project feel like our Mac and Linux builds are at this stage, if not beyond it. They run pretty well and demonstrate the fundamental architecture that sets Chromium apart from other browsers. Sure, the bells and whistles aren't all there, but the core functionality of web browsing is. We feel that we've delivered on ESR's "plausible promise" and that it's enough to start attracting those who really want to help make this the best product it can be. We're not done yet, nor is it ready for the average user. It is, however, ready for those who want to live on the bleeding edge and help lend their talents towards completing it.

The community we build today is what will make it a better product down the road, and without that community the product will ultimately suffer. ESR describes testers as "a project's most valuable resource" and my first-hand experience with Camino and Mozilla bear this out. A web browser is a program that accepts an infinite number of inputs and having people who can test webpages the developers wouldn't normally encounter is a tremendous aid. Testing on diverse hardware and software setups is also invaluable as developers tend to only run the latest and greatest (and fastest!). Eventually we might uncover many of these issues on our own, but probably not.

Another pillar of open source, along with releasing early, is releasing often. To that end, the dev channel will automatically receive weekly updates as development continues. You will be able to see the product improving from week to week and help immediately identify when things break. Getting feedback on new features as soon as they are completed helps the developers know if they hit the mark and helps close the feedback loop with the community. The community benefits by being more involved and connected and promoting further transparency in the development process. This wouldn't be possible if we only teased users with releases at widely-spaced intervals when most decisions had been set in stone (end-users who want that can use the beta or release channels).

Right now we need your help, and it doesn't take a PhD in computer science. Read the [bug reporting guidelines for Mac and Linux](http://dev.chromium.org/for-testers/bug-reporting-guidlines-for-the-mac-linux-builds) and get involved.

  
Posted by Mike Pinkerton, Software Engineer