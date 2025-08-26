URL:https://blog.chromium.org/2020/05/a-safer-and-more-private-browsing-DoH.html
# A safer and more private browsing experience with Secure DNS
- **Published**: 2020-05-19T09:00:00.000-07:00
  
  
With Chrome 83, we’ve started rolling out Secure DNS, a feature built on top of a secure DNS protocol called DNS-over-HTTPS, which is designed to improve your safety and privacy while browsing the web. More concretely, Chrome will automatically switch to DNS-over-HTTPS if your current DNS provider supports it, and provide manual configuration options for users who wish to use a specific provider. DNS-over-HTTPS introduces a significant change to the Domain Name System (DNS), a system designed more than 35 years ago that is central to how the web works even to this day. It’s the sort of change that requires careful planning and collaboration, which explains why it took us a little more than 2 years, [gathering test data](https://blog.chromium.org/2019/09/experimenting-with-same-provider-dns.html), listening to feedback, and [addressing some misconceptions](https://blog.chromium.org/2019/10/addressing-some-misconceptions-about.html), to arrive at a design that put our users first with reasonable defaults and accessible controls.  
  
  
  

### Unencrypted DNS

  
When you want to access your favorite website, your browser first needs to determine which server is hosting it, a step known as “DNS lookup”. When DNS was first introduced, the internet was in its infancy, and the web did not yet exist. There was no e-commerce, no online banks, and many people did not yet see a strong need for encryption on the web. It took until 1994 for encryption to take-off with the introduction of the HTTPS protocol. Nowadays, the HTTPS protocol is [almost ubiquitous](https://transparencyreport.google.com/https/overview) and provides strong security and privacy guarantees. It helps you browse or transact on the web without fear of having your credit card or personal information stolen by other internet users, even when using a public WiFi connection. Unfortunately, DNS, on the other hand, until recently has remained unencrypted.  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiveHNEzxUpC8DvT_jo7HMnIW9DvhrZmOc6DE9yuKztEjoA_ACJKS0Ite8S_TaI4deR7bABLNc5LX9qBeA_c0CF_kFsvbLiC8Ea1L5SjCyVMQ9QgPRa9T_GkJK7X0f1EitN6-WM9crgeYp0/s640/DoH_illustration_01.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiveHNEzxUpC8DvT_jo7HMnIW9DvhrZmOc6DE9yuKztEjoA_ACJKS0Ite8S_TaI4deR7bABLNc5LX9qBeA_c0CF_kFsvbLiC8Ea1L5SjCyVMQ9QgPRa9T_GkJK7X0f1EitN6-WM9crgeYp0/s1600/DoH_illustration_01.png)

With unencrypted DNS, an attacker connected to the same network can observe other users’ browsing habits.

### 

### 

### Benefits of DNS-over-HTTPS

Chrome’s Secure DNS feature uses DNS-over-HTTPS to encrypt the DNS communication, thereby helping prevent attackers from observing what sites you visit or sending you to phishing websites. As the name suggests, Chrome communicates with the DNS service provider over the HTTPS protocol, the same protocol used for communicating with websites in a safe and secure manner. HTTPS is particularly appealing because it provides the following protections:  

* Authenticity: Chrome can verify that it is communicating with the intended DNS service provider and not a fake service provider that’s controlled by an attacker.
* Integrity: Chrome can verify that the response it got from the DNS service provider hasn’t been tampered with by attackers using the same network, thereby stopping phishing attacks.
* Confidentiality: Chrome can talk to the DNS service provider over an encrypted channel which means that attackers can no longer rely on DNS to observe which websites other users are visiting when sharing the same connection, e.g. public WiFi in a library.

  
  
  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgwE4HM-D1XSZooDcaFHcMZiuXFlyfwAuEBt_RB0pc_ENFJcN3pwoYs2K7OrNwHxQdqnScM6I29JWLO6q39CoZnAnvBdW2KAkry0B8aa5Nx917DUwXe9k5Wnm1vI7XHIjGLRkF0okzfTAz5/s640/DoH_illustration_2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgwE4HM-D1XSZooDcaFHcMZiuXFlyfwAuEBt_RB0pc_ENFJcN3pwoYs2K7OrNwHxQdqnScM6I29JWLO6q39CoZnAnvBdW2KAkry0B8aa5Nx917DUwXe9k5Wnm1vI7XHIjGLRkF0okzfTAz5/s1600/DoH_illustration_2.png)

With DNS-over-HTTPS, an attacker can no longer rely on DNS to observe other users’ browsing habits.

The introduction of DNS-over-HTTPS gives the whole ecosystem a rare opportunity to start from a clean and dependable slate, making it easier to pursue further enhancements relying on DNS as a delivery mechanism. Thus far, the unencrypted nature of DNS has meant that features that extend DNS could randomly fail due to causes such as network equipment that may drop or modify newly introduced DNS fields. As DNS-over-HTTPS grows, it will put this concern aside because it benefits from the aforementioned HTTPS properties and sets a new reliable baseline to build upon.  
  
  

### Responsibly deploying DNS-over-HTTPS

Changing how DNS works is a non-trivial task. In particular, with more than 35 years of history, a lot of additional services and features have been built on top of DNS. For instance, some Internet Service Providers offer family-safe filtering via DNS. So, while we would love to have everyone benefit from Secure DNS immediately, we also know that we have to get there in a way that doesn’t break user expectations. Navigating these goals led us to the “same-provider DNS-over-HTTPS upgrade” approach that we [experimented](https://blog.chromium.org/2019/09/experimenting-with-same-provider-dns.html) with at the end of 2019. The successful experiment gave us confidence about the performance and stability aspects for both Chrome’s Secure DNS and our partners’ DNS-over-HTTPS services. It also highlighted opportunities to improve the auto-upgrade success rate.  
  
Here is how this “same-provider DNS-over-HTTP upgrade” approach works. Chrome maintains a list of DNS providers known to support DNS-over-HTTPS. Chrome uses this list to match the user’s current DNS service provider with that provider’s DNS-over-HTTPS service, if the provider offers one. By keeping the user’s chosen provider, we can preserve any extra services offered by the DNS service provider, such as family-safe filtering, and therefore avoid breaking user expectations. Furthermore, if there’s any hiccup with the DNS-over-HTTPS connection, Chrome will fall back to the regular DNS service of the user’s current provider by default, in order to avoid any disruption, while periodically retrying to secure the DNS communication. Finally, to avoid an issue that otherwise could arise for users running Windows, Chrome will also disable Secure DNS if Windows parental controls are enabled, so that any filtering software that relies on a regular DNS connection can continue to work while we collaborate with the ecosystem on ways for Secure DNS to co-exist with these filtering solutions.  
  
  
If you are an IT administrator, Chrome will disable Secure DNS if it detects a managed environment via the presence of one or more enterprise policies. We’ve also added new DNS-over-HTTPS enterprise policies to allow for a managed configuration of Secure DNS and encourage IT administrators to look into deploying DNS-over-HTTPS for their users.  
  
  
We believe that our approach strikes a good balance between moving security & privacy forward and maintaining user expectations. However, if this default behavior doesn’t suit your needs, head over to Chrome’s settings and search for Secure DNS to configure it to your liking. For instance, you can disable the feature altogether, or configure it in a no-fallback mode by choosing a specific DNS-over-HTTPS service provider among a list of popular options or by specifying a custom provider.  

![](https://lh4.googleusercontent.com/zem6Estu-y7LDKLscD6R_08bBVr1lXNda5PjEWMi7KizMcxCs6NqyaIv0htyS-zOPnSwC1b1084HpbMo3ZsJAHwHuuuVNTl_-fbfcgJX5h-6pJzZ-ipl3gAtXCCEh9_znbg4b6FK)

As ISPs and DNS service providers make progress on their DNS-over-HTTPS services, we expect to support more options in future milestones via [our DNS-over-HTTPS program](https://docs.google.com/document/d/128i2YTV2C7T6Gr3I-81zlQ-_Lprnsp24qzy_20Z1Psw/edit?usp=sharing).   
  
Chrome’s Secure DNS will progressively be made available on Chrome OS, Windows and Mac OS with Android and Linux coming soon.  
  
  
  

### Onwards

  
While these are early days, we are proud of playing a role in the adoption of DNS-over-HTTPS and helping our users benefit from a safer and more private way of browsing the web. At the same time, we also understand how intricate DNS is, which is why we’ve been and will continue to move carefully and transparently. As always, we’re open to feedback and welcome collaboration with stakeholders including ISPs, DNS service providers, and Online Child Safety advocates as we make further progress in securing DNS.  
  
  
Posted by Kenji Baheux, Chrome Product Manager