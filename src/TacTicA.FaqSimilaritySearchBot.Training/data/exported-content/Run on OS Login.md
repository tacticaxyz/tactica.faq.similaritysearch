URL:https://blog.chromium.org/2021/11/run-on-os-login.html
# Run on OS Login
- **Published**: 2021-11-02T09:03:00.003-07:00
Users want frequently used applications such as Email, Chat, and other productivity apps to automatically start when they log in to their devices. Auto-starting these apps at login streamlines the user experience as users don't have to manually start apps after logging into their devices.   
Windows, Mac, and Linux devices allow users to configure native apps to be launched automatically on startup. In Chrome 91, we introduced the Run on OS Login feature. With the launch of this feature, users can now configure desktop web apps to launch automatically when they log-in to the device on Windows, Mac, and Linux devices. *Installed apps will not be permitted to automatically enable themselves to run when the user logs in. A manual user gesture will always be required.*   
To configure apps to run on OS login, open Chrome browser. Navigate to chrome://apps or click the ‘Apps' icon in your bookmark bar (example below).

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhRO8nghsrfQxLQ7PDh-mlBu5_pUYBJGjyPXgviVrHihnO2pwdj4FQZixbS6KY8MZ02_0_YGsLdLUeOySLkb_D7EQh3sZgw-ERoGu9iTwTqTSNOKns5dQUte-PaC3B9xp_bTvC4D94zN1A2/s0/copyofrunonosl--dkwpvkjdw5v.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhRO8nghsrfQxLQ7PDh-mlBu5_pUYBJGjyPXgviVrHihnO2pwdj4FQZixbS6KY8MZ02_0_YGsLdLUeOySLkb_D7EQh3sZgw-ERoGu9iTwTqTSNOKns5dQUte-PaC3B9xp_bTvC4D94zN1A2/s66/copyofrunonosl--dkwpvkjdw5v.png)

To configure an app to start at login, first right click on it. From the context menu, select ‘Start app when you sign in' and you are all set. Next time when you log in to your device, the app will automatically launch on its own. To disable this feature for an app, navigate to chrome://apps. Right click on the app to bring up the context menu and deselect the option, ‘Start app when you sign in'.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjS6rK1xAnqVGJDjAJ_Br7oY8AkNljxKCob4jTuS_6zU1FYbFj6MNlGHGooJvzAkI5jkH7sRqC8wfyOMiRFKZiGAmeMRfprvRDK8wFpxBHnqDGOTJaBGDlvYamHSkvgIEakPgRXY_aV6svF/w640-h484/copyofrunonosl--ukb91y8rh2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjS6rK1xAnqVGJDjAJ_Br7oY8AkNljxKCob4jTuS_6zU1FYbFj6MNlGHGooJvzAkI5jkH7sRqC8wfyOMiRFKZiGAmeMRfprvRDK8wFpxBHnqDGOTJaBGDlvYamHSkvgIEakPgRXY_aV6svF/s1057/copyofrunonosl--ukb91y8rh2.png)

Apps launched through Run on OS Login are launched only after the device is running. ‘Run on OS Login' is a browser only feature and doesn't expose any launch source information to app developers.

We're continuously improving the web platform to provide safe, low friction ways for users to get their day-to-day tasks done. Support for running installed web apps on OS login is a small but significant step to simplifying the startup routine for users that want apps like chat, email, or calendar clients to start as soon as they turn on their computer. As always, we're looking forward to your [feedback](https://forms.gle/JtHPkor6Z5dP87RU7). Your input will help us prioritize next steps!

Posted by Pratyush Sinha 