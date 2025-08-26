URL:https://blog.chromium.org/2020/04/temporarily-rolling-back-samesite.html
# Temporarily rolling back SameSite Cookie Changes
- **Published**: 2020-04-03T12:00:00.000-07:00
  
UPDATE 5/28: We are going to resume the rollout with the stable release of Chrome M84. [More details](https://blog.chromium.org/2020/05/resuming-samesite-cookie-changes-in-july.html).   
  
With the stable release of [Chrome 80 in February](https://blog.chromium.org/2020/02/samesite-cookie-changes-in-february.html), Chrome began enforcing secure-by-default handling of third-party cookies as part of our [ongoing](https://blog.chromium.org/2020/01/building-more-private-web-path-towards.html) effort to improve privacy and security across the web. We’ve been [gradually](https://www.chromium.org/updates/same-site) rolling out this change since February and have been closely monitoring and evaluating ecosystem impact, including proactively reaching out to individual websites and services to ensure their cookies are labeled correctly.  
  
However in light of the extraordinary global circumstances due to COVID-19, we are temporarily rolling back the enforcement of SameSite cookie labeling, starting today. While most of the web ecosystem was prepared for this change, we want to ensure stability for websites providing essential services including banking, online groceries, government services and healthcare that facilitate our daily life during this time. As we roll back enforcement, organizations, users and sites should see no disruption.  
  
We recognize the efforts of sites and individual developers who prepared for this change and appreciate the feedback from the web ecosystem, which has helped inform this decision. We will provide advance notice on this blog and the [SameSite Updates page](https://www.chromium.org/updates/same-site) when we plan to resume the enforcement, which we’re now aiming for over the summer.  
  
Posted by Justin Schuh - Director, Chrome Engineering