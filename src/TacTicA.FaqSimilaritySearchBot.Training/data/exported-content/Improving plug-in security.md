URL:https://blog.chromium.org/2010/06/improving-plug-in-security.html
# Improving plug-in security
- **Published**: 2010-06-28T13:22:00.000-07:00
Bad guys want to install persistent malware on your machine. Once they achieve this, they are free to do a variety of bad things such as steal your banking passwords, abuse your network connection, and rifle through your sensitive files.  
  
Bad guys will install malware via the easiest path available. Traditionally, the easiest attack was to simply get a user to run an untrusted executable. Not all users fall for this. And modern operating systems and e-mail systems make this harder to do and restrict the permissions that the downloads run with -- making it less attractive. Next easiest is to exploit a disclosed vulnerability which is not yet patched by all users. The industry’s response to this is to autoupdate its users with security patches; [browsers including Firefox and Chrome](http://www.techzoom.net/publications/silent-updates/) have demonstrated success at keeping the majority of their user bases current.  
  
More advanced attacks involve finding undisclosed vulnerabilities in the browser. Despite being harder, there has been a lot of user damage due to exploitation of non-public bugs in browsers. Pleasingly, there’s a trend in modern browsers to integrate sandboxing. IE7 on Vista (and newer combinations) plus Google Chrome already have built-in sandboxes of varying strength. This makes many latent browser bugs incapable of persistently installing malware without a lot of additional effort to find a second bug to break out of the sandbox. Again, attackers favor the easiest attack so the increasing robustness of browsers is causing them to look elsewhere for ways to compromise user machines.  
  
This brings us to the present time. We’re seeing a [remarkable swing](http://www.sans.org/top-cyber-security-risks/summary.php) towards attacks that target pieces of browsing infrastructure [such as plug-ins](http://www.theregister.co.uk/2010/03/09/adobe_reader_attacks/). This may be because browsers are taking the lead on auto-update and sandboxing. Since many plug-ins are ubiquitous, they pose the most significant risk to our user base. To better protect Google Chrome users from the threat of plug-in exploits, we have already announced a couple of initiatives:  

* **More powerful plug-in controls**: Google Chrome now has the ability to disable individual plug-ins (about:plugins) or to operate in a “domain whitelist” mode whereby only trusted domains are permitted to load plug-ins (Options->Content Settings->Plug-ins).
* **Autoupdate for Adobe Flash Player**: By including Adobe Flash Player -- the most popular plug-in -- with Google Chrome, we can re-use Google Chrome’s powerful autoupdate strategy and minimize the window of risk for patched vulnerabilities.

There are more ways we are attacking the problem:

* **Integrated, sandboxed PDF viewing**: We have [announced](http://blog.chromium.org/2010/06/bringing-improved-pdf-support-to-google.html) an integrated PDF viewer plug-in running inside Google Chrome’s sandbox. This will make it harder for PDF-based vulnerabilities to result in the persistent installation of malware.
* **Protection from out-of-date plug-ins**: Medium-term, Google Chrome will start refusing to run certain out-of-date plug-ins (and help the user update).
* **Warning before running infrequently used plug-ins**: Some plug-ins are widely installed but typically not required for today’s Internet experience. For most users, any attempt to instantiate such a plug-in is suspicious and Google Chrome will warn on this condition.
* **A next generation plug-in API**: “[Pepper](https://wiki.mozilla.org/NPAPI:Pepper)” makes it easier to sandbox plug-ins.

User safety is of paramount importance to us, including threats to our users caused by plug-ins outside of our direct control. We are working hard to improve the security of the entire browser ecosystem for Google Chrome users.

Posted by Chris Evans, Julien Tinnes, Michal Zalewski; Google Security Team