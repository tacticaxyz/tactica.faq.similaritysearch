URL:https://blog.chromium.org/2020/01/building-more-private-web-path-towards.html
# Building a more private web: A path towards making third party cookies obsolete
- **Published**: 2020-01-14T08:00:00.000-08:00
  
In August, we [announced](https://www.blog.google/products/chrome/building-a-more-private-web/) a new initiative (known as Privacy Sandbox) to develop a set of open standards to fundamentally enhance privacy on the web. Our goal for this open source initiative is to make the web more private and secure for users, while also supporting publishers. Today, we’d like to give you an update on our plans and ask for your help in increasing the privacy of web browsing.  
  
After initial dialogue with the web community, we are confident that with continued iteration and feedback, privacy-preserving and open-standard mechanisms like the Privacy Sandbox can sustain a healthy, ad-supported web in a way that will render third-party cookies obsolete. Once these approaches have addressed the needs of users, publishers, and advertisers, and we have developed the tools to mitigate workarounds, we plan to phase out support for third-party cookies in Chrome. Our intention is to do this within two years. But we cannot get there alone, and that’s why we need the ecosystem to engage on these proposals. We plan to start the first origin trials by the end of this year, starting with conversion measurement and following with personalization.  
   
Users are demanding greater privacy--including transparency, choice and control over how their data is used--and it’s clear the web ecosystem needs to evolve to meet these increasing demands. Some browsers have reacted to these concerns by blocking third-party cookies, but we believe this has unintended consequences that can negatively impact both users and the web ecosystem. By undermining the business model of many ad-supported websites, blunt approaches to cookies encourage the use of opaque techniques such as fingerprinting (an invasive workaround to replace cookies), which can actually reduce user privacy and control. We believe that we as a community can, and must, do better.  
  
Fortunately, we have received positive feedback in forums like the W3C that the mechanisms underlying the Privacy Sandbox represent key use-cases and go in the right direction. This feedback, and related proposals from other standards participants, gives us confidence that solutions in this space can work. And our experience working with the standards community to create alternatives and [phase out Flash](https://www.blog.google/products/chrome/saying-goodbye-flash-chrome/) and [NPAPI](https://blog.chromium.org/2014/11/the-final-countdown-for-npapi.html) has proven that we can come together to solve complex challenges.  
  
We’ll also continue our work to make current web technologies more secure and private. As we previously announced, Chrome will limit insecure cross-site tracking starting in February, by treating cookies that don’t include a SameSite label as first-party only, and require cookies labeled for third-party use to be accessed over HTTPS. This will make third-party cookies more secure and give users more precise browser cookie controls. At the same time, we’re developing techniques to detect and mitigate covert tracking and workarounds by launching new anti-fingerprinting measures to discourage these kinds of deceptive and intrusive techniques, and we hope to launch these measures later this year.  
   
We are working actively across the ecosystem so that browsers, publishers, developers, and advertisers have the opportunity to experiment with these new mechanisms, test whether they work well in various situations, and develop supporting implementations, including ad selection and measurement, denial of service (DoS) prevention, anti-spam/fraud, and federated authentication.  
   
We are looking to build a more trustworthy and sustainable web together, and to do that we need your continued engagement. We encourage you to give [feedback](https://github.com/w3c/web-advertising/blob/master/README.md) on the [web standards community](https://www.w3.org/community/web-adv/) proposals via GitHub and make sure they address your needs. And if they don’t, file issues through GitHub or [email](https://lists.w3.org/Archives/Public/public-web-adv/) the W3C group. If you rely on the web for your business, please ensure your technology vendors engage in this process and share your feedback with the trade groups that represent your interests.  
  
We will continue to keep everyone posted on the progress of efforts to increase the privacy of web browsing.  
  
Posted by Justin Schuh - Director, Chrome Engineering  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  