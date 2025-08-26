URL:https://blog.chromium.org/2020/02/protecting-users-from-insecure.html
# Protecting users from insecure downloads in Google Chrome
- **Published**: 2020-02-06T10:00:00.002-08:00
*Update (April 6, 2020): Chrome was originally scheduled to start user-visible warnings on mixed downloads in Chrome 82. These warnings, as well as subsequent blocking, will be delayed by two releases. Console warnings on mixed downloads will begin as scheduled in Chrome 81.*  

*User-visible warnings will start in Chrome 84. The text below has been updated to reflect this change. Developers who are otherwise able to do so are encouraged to transition to secure downloads as soon as possible to avoid future disruption.*  
  
Today we’re announcing that Chrome will gradually ensure that secure (HTTPS) pages only download secure files. In a series of steps outlined below, we’ll start blocking "mixed content downloads" (non-HTTPS downloads started on secure pages). This move follows a [plan we announced last year](https://blog.chromium.org/2019/10/no-more-mixed-messages-about-https.html) to start blocking all insecure subresources on secure pages.  
  
Insecurely-downloaded files are a risk to users' security and privacy. For instance, insecurely-downloaded programs can be swapped out for malware by attackers, and eavesdroppers can read users' insecurely-downloaded bank statements. To address these risks, we plan to eventually remove support for insecure downloads in Chrome.  
  
As a first step, we are focusing on insecure downloads started on secure pages. These cases are especially concerning because Chrome currently gives no indication to the user that their privacy and security are at risk.  
  
Starting in Chrome 84 (to be released July 2020), Chrome will gradually start warning on, and later blocking, these mixed content downloads. File types that pose the most risk to users (e.g., executables) will be impacted first, with subsequent releases covering more file types. This gradual rollout is designed to mitigate the worst risks quickly, provide developers an opportunity to update sites, and minimize how many warnings Chrome users have to see.  
  
We plan to roll out restrictions on mixed content downloads on desktop platforms (Windows, macOS, Chrome OS and Linux) first. Our plan for desktop platforms is as follows:  
  
  

![](https://lh6.googleusercontent.com/Z0PJQoO2T08e4tqBSIQQrjX3jg1QPjetQ0TewI2frOMFlnA04rYfVC5jC6-A8cOsWEXJfesz4HZHAtfqcLviJaJabNGa7zm7qyZ7Zzf3m8mlQYMibPBO4GAJMV9egjTr5_9nVW2s9Q)

* In **Chrome 81**(released March 2020) and later:

+ Chrome will print a **console message** warning about all mixed content downloads.

* In **Chrome 84**(released July 2020):

+ Chrome will **warn** on mixed content downloads of executables (e.g. .exe).

* In **Chrome 85** (released August 2020):

+ Chrome will **block** mixed **content executables**.
+ Chrome will **warn** on mixed content **archives** (.zip) and **disk images** (.iso).

* In **Chrome 86** (released October 2020):

+ Chrome will **block** mixed content **executables, archives and disk images.**
+ Chrome will **warn on all other mixed content downloads** except image, audio, video and text formats.

* In **Chrome 87** (released November 2020):

+ Chrome will **warn** on mixed content downloads of **images, audio, video, and text**.
+ Chrome will **block all other mixed content downloads**.

* In **Chrome 88** (released January 2021) and beyond, Chrome will block all mixed content downloads.

![](https://lh3.googleusercontent.com/zrLE0mfbhZ8x5Enxd2M14y5_VXb1QBJanFT4YIrSOUCGdVKP4OQSr2ZXnH5EfthVGyT8sj8N-mGE-xPQKhH25GNfoF_0mCzguWU14VH__u3hRfAf4s8NUKwVIM28t17BQilRM8_4)


  

Example of a potential warning


  
  
Chrome will delay the rollout for Android and iOS users by one release, starting warnings in Chrome 85. Mobile platforms have better native protection against malicious files, and this delay will give developers a head-start towards updating their sites before impacting mobile users.

Developers can prevent users from ever seeing a download warning by ensuring that downloads only use HTTPS. In the current version of Chrome Canary, or in Chrome 81 once released, developers can activate a warning on all mixed content downloads for testing by enabling the "Treat risky downloads over insecure connections as active mixed content" flag at chrome://flags/#treat-unsafe-downloads-as-active-content.

Enterprise and education customers can disable blocking on a per-site basis via the existing InsecureContentAllowedForUrls policy by adding a pattern matching the page requesting the download.

In the future, we expect to further restrict insecure downloads in Chrome. We encourage developers to fully migrate to HTTPS to avoid future restrictions and fully protect their users. Developers with questions are welcome to email us at security-dev@chromium.org.

Posted by Joe DeBlasio, Chrome Security team