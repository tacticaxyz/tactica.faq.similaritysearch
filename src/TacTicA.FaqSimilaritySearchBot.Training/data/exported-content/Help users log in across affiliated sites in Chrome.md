URL:https://blog.chromium.org/2021/04/help-users-log-in-across-affiliated.html
# Help users log in across affiliated sites in Chrome
- **Published**: 2021-04-22T08:00:00.003-07:00
Chrome can generate a new password, automatically fill saved passwords, sync them and [warn users when passwords are compromised](https://security.googleblog.com/2019/12/better-password-protections-in-chrome.html). This means users do not need to maintain passwords themselves. However, if you employ multiple domains (for example, top-level domains such as https://www.example.com and https://www.example.co.uk) that share the same account management backend, Chrome may not offer to fill passwords across them. This can result in two entries for the same password in different domains, which may get out of sync.

Starting in version 91, Chrome will offer to fill passwords saved to domains associated with [Digital Asset Links](https://digitalassetlinks.org/) (DALs). DALs have been adopted since 2015, which allow you to [link Android apps and websites](https://developers.google.com/digital-asset-links/v1/create-statement). In Chrome 91, when you set up DALs between sites, Chrome can assist users with logging in across those sites. To make a DAL association, developers need to put a JSON file that follows the [DAL syntax](https://developers.google.com/digital-asset-links/v1/statements) at /.well-known/assetlinks.json on both domains.

![](https://lh4.googleusercontent.com/rczHJ4oYJmu669rWIw7QJMfIcNY47dRoYMjkqbPU9pLOqrTTqan2e_rAEMPn-jrKhABbYmLWJWdyZgPO71-i2OEiRamadGeIBOsJs3i9yhekqNlFeLZJP6Ss_IJjDkFjQAkYx_PrBk2IWxFS9qaTPjCQOF_D9ljI8L7kL4Yj0wR14iYo)

To learn more about how to set up a DAL association, [enable Chrome to share login credentials across affiliated sites](https://developer.chrome.com/blog/site-affiliation/).

Posted by Eiji Kitamura, Developer Advocate and Ali Sarraf, Product Manager