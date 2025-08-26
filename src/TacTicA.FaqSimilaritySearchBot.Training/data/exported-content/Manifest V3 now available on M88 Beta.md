URL:https://blog.chromium.org/2020/12/manifest-v3-now-available-on-m88-beta.html
# Manifest V3 now available on M88 Beta
- **Published**: 2020-12-09T09:15:00.003-08:00
With hundreds of millions of people using over 250,000 items in the
Chrome Web Store, extensions have become essential to how many of us
experience the web and get work done online. We believe extensions must
be trustworthy by default, which is why we’ve spent this year
[making extensions safer for everyone](https://blog.google/products/chrome/making-chrome-extensions-more-private-and-secure/).

Today we’re officially announcing the planned rollout of Manifest V3 for
Chrome Extensions, a new version of the extensions platform that makes
extensions more secure, performant, and private-respecting by default.

Security
--------

With the introduction of Manifest V3, we will disallow remotely hosted
code. This mechanism is used as an attack vector by bad actors to
circumvent Google’s malware detection tools and poses a significant
risk to user privacy and security.

The removal of remotely hosted code will also allow us to more thoroughly
and quickly review submissions to the Chrome Web Store. Developers will
then be able to release updates to their users more quickly.

On the extensions team, we believe that a trustworthy Chrome and a
trustworthy extensions experience is not only great for users but is
also essential for developers. In the long run, Manifest V3 will help the
extension ecosystem continue to be a place that people can trust.

Performance
-----------

We know that performance is key to a great user experience, and as we
began work on the third iteration of our extension platform, performance
was a foundational consideration. Two areas where this has manifested
are our approach to background logic and API design.

First, we are introducing
[service workers](https://developers.google.com/web/fundamentals/primers/service-workers)
as a replacement for background pages. Unlike persistent background
pages, which remain active in the background and consume system resources
regardless of whether the extension is actively using them, service
workers are ephemeral. This ephemerality allows Chrome to lower overall
system resource utilization since the browser can start up and tear
down service workers as needed.

Second, we are moving to a more declarative model for extension APIs in
general. In addition to security benefits,
[this provides a more reliable end-user performance guarantee](https://blog.chromium.org/2019/06/web-request-and-declarative-net-request.html)
across the board by eliminating the need for serialization and
inter-process communication. The end result is better overall performance
and improved privacy guarantees for the vast majority of extension
users.

Privacy
-------

To give users greater visibility and control over how extensions use
and share their data, we’re moving to an extensions model that makes
more permissions optional and allows users to withhold sensitive
permissions at install time. Long-term, extension developers should
expect users to opt in or out of permissions at any time.

For extensions that currently require passive access to web activity,
we’re introducing and continuing to iterate on new functionality that
allows developers to deliver these use cases while preserving user
privacy. For example, our new declarativeNetRequest API is designed
to be a privacy-preserving method for extensions to block network
requests without needing access to sensitive data.

The `declarativeNetRequest` API is an example of how Chrome is working to
enable extensions, including ad blockers, to continue delivering their
core functionality without requiring the extension to have access to
potentially sensitive user data. This will allow many of the powerful
extensions in our ecosystem to continue to provide a seamless user
experience while still respecting user privacy.

Availability & Continued Iteration
----------------------------------

When the Manifest V3 draft proposal was initially shared with the
Chromium developer community, we received an abundance of helpful
feedback — thank you! We have been working closely with the developers
of many extensions — including ad blockers, shopping extensions,
productivity enhancements, developer tools, and more — to evolve the
platform.

We've used this feedback to improve the functionality and usability of
the API surfaces associated with Manifest V3. For example, we have added
support to `declarativeNetRequest` for multiple static rulesets, regular
expressions within rules, declarative header modification, and more.

> “We’ve been very pleased with the close collaboration established
> between Google’s Chrome Extensions Team and our own engineering team
> to ensure that ad-blocking extensions will still be available after
> Manifest V3 takes effect."
>   
>   
> — Sofia Lindberg, Tech Lead, eyeo (Adblock Plus)

Even after Manifest V3 launches, expect more functionality and iteration
as we continue to incorporate feedback and add new features to make V3
even more powerful for developers while preserving user privacy. If
you are interested in contributing to the conversation, please comment
and discuss on the
[chromium-extensions Google Group](https://groups.google.com/a/chromium.org/g/chromium-extensions).

Manifest V3 is now available to experiment with on Chrome 88 Beta, with
additional exciting features to follow in upcoming releases. The
Chrome Web Store will start accepting Manifest V3 extensions January, shortly after Chrome 88 reaches stable. While there is not an exact date for
removing support for Manifest V2 extensions, developers can expect the
migration period to last at least a year from when Manifest V3 lands in
the stable channel. We will continue to provide more details about
this timeline in the coming months.

Posted by David Li - Product Manager, Chrome
& Simeon Vincent - Developer Advocate, Chrome