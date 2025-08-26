URL:https://blog.chromium.org/2020/09/a-safer-and-more-private-browsing.html
# A safer and more private browsing experience on Android with Secure DNS
- **Published**: 2020-09-02T09:33:00.003-07:00
With Chrome 85, we are extending support of Secure DNS in Chrome to Android. Secure DNS is a feature we introduced in Chrome 83 on desktop platforms. It’s a feature built on top of a secure DNS protocol called DNS-over-HTTPS (DoH), which is designed to improve your safety and privacy while browsing the web. You can learn more about Secure DNS by reading our [previous blog post](https://blog.chromium.org/2020/05/a-safer-and-more-private-browsing-DoH.html). Just like we did for the launch of DoH on Chrome for desktop platforms, we will progressively roll out DoH on Chrome for Android to ensure the feature’s stability and performance, as well as help DoH providers scale their service accordingly.

Secure DNS in Chrome for Android shares the same design principles as its desktop platform version. Here is a high level overview of how the feature behaves and what options exist:

* Chrome will automatically switch to DNS-over-HTTPS if your current DNS provider is known to support it. This also applies to your current [Android Private DNS (DNS-over-TLS)](https://support.google.com/android/answer/9654714?hl=en) if you have configured one. This approach means that  we can preserve any extra services offered by your DNS service provider, such as family-safe filtering, and therefore avoid breaking user expectations. In this automatic mode, Chrome will also fall back to the regular DNS service of the user’s current provider (including DNS-over-TLS if configured), in order to avoid any disruption, while periodically retrying to secure the DNS communication.
* In case this default behavior isn’t suitable to your needs, Chrome also provides manual configuration options allowing you to use a specific provider without fallback, as well as the ability to completely disable the feature.
* If you are an IT administrator, Chrome will disable Secure DNS if it detects a managed environment via the presence of one or more enterprise policies. We’ve also added new DNS-over-HTTPS enterprise policies to allow for a managed configuration of Secure DNS and encourage IT administrators to look into deploying DNS-over-HTTPS for their users.

  

![](https://lh3.googleusercontent.com/XoshgUB0EXZH1RgPkVsrcU0vXS8w3Rb6QdmuJtnu9Uw8ujoh1yJaXquK1zX5OWcaMYUnz0GC_HBEw8qRHLuHWrmJs6vorP2Qq54LIHBTeAvRVcner6Fagi0cflisCFMO5Ki8BZifIQ)

Secure DNS settings in Chrome for Android

  

While this milestone represents significant progress toward making browsing the web safer and more private, it’s still early days for DNS-over-HTTPS. As such, we remain open to feedback and collaboration with interested parties such as mobile operators and other ISPs, DNS service providers, and Online Child Safety advocates to make further progress in securing DNS.

  

Posted by Kenji Baheux, Chrome Product Manager