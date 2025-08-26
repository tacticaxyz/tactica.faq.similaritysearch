URL:https://blog.chromium.org/2009/01/google-chrome-installation-and-updates.html
# Google Chrome Installation and Updates
- **Published**: 2009-01-16T15:17:00.000-08:00
Since our public launch in September, a few Google Chrome users have had some questions about our installation and update process. We tried to answer most of them in our [help center](https://www.google.com/support/chrome/), but since many of you may not have visited the help center, this post attempts to give some background and insight into our current installation and update process.  
  
When we started exploring various options for our installer, we came up with some explicit goals:  

* With new browser exploits showing up on regular basis, keep users free from the burden of checking for security updates.
* Allow users who are not administrators to install Google Chrome.
* Allow updates to happen automatically in the background even when Google Chrome is in use. The next time you open Google Chrome, it can simply start using the latest version.
* Just like the minimal user interface (UI) of Google Chrome, limit or eliminate installer UI as much as possible.
* Updates should be as small as possible. A security fix should be a small, fast download and should not need a full installer.
* Uninstall should be clean and remove changes done by Google Chrome as much as possible.

After looking at existing options we found that none of them would give us all the things we wanted so we decided to write our own installer.  
  
Installation  
We believe Google Chrome installation has been made really simple. Once you run the installer, there are no screens to jump through or confusing choices to make. Installation happens and you get a first run UI window letting you import your data from your existing default browser. Some people (especially those using Windows XP as opposed to Windows Vista) were confused by our choice to install in the user profile directory instead of Program Files. There are several reasons we chose the user profile directory:  

* Anyone can install Google Chrome, not just administrators.
* On Windows Vista there are no 'security prompts' during install. If you are running as a non-elevated Administrator, you can still install Google Chrome without having to enter an administrator's password. However we still need to ask for a password to make Google Chrome the default browser due to how Windows Vista requires browser applications to be registered with it.
* You can choose to install or uninstall Google Chrome without affecting other people who use the same computer.

Updates  
Google Chrome automatically updates itself with the help of Google Update, which is also used by other Google products including [Google Talk](http://www.google.com/talk/labsedition/), [Gears](http://gears.google.com/), and the [Google Earth Plugin](http://code.google.com/apis/earth/). Using Google Update meant we could use an existing service that already takes care of lot of issues around automatic updates:  

* Maintaining different update [channels](http://dev.chromium.org/getting-involved/dev-channel/), each with its own update schedules and Chrome versions.
* Updating software in the background without any annoying dialogs.
* Good proxy support that can handle various proxy configuration to download the installer payload.
* Having only one instance of Google Update manage multiple Google programs installed on the machine.

Using Google Update has allowed us to push incremental changes out relatively quickly — we have released [fourteen updates](http://googleblog.blogspot.com/2008/12/google-chrome-beta.html) in three months between our release and our taking off the beta label.  
  
Un-installation  
During uninstall, Google Chrome deletes all the changes it made to the system, but a few people were surprised when they found all their profile data intact after reinstalling Google Chrome. This is intentional as many people try a sequence of uninstalling and then reinstalling to fix any installation issues, and we didn't want them to lose all of their profile data. If you really want to delete your Google Chrome profile we have [instructions](http://www.google.com/support/chrome/bin/answer.py?hl=en&answer=95319) on how to do so.  
  
Finally, if you made Google Chrome your default browser before uninstalling, we don't know how to undo that. All browsers face this problem: there's no way for one browser to know exactly how another browser registers itself as the default browser. To fix that, you should open your preferred browser, and use its option to set it as the the default browser.  
  
Posted by Rahul Kuchhal, Software Engineer