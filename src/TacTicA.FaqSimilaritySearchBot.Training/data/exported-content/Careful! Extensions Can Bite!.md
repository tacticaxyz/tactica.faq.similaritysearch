URL:https://blog.chromium.org/2009/07/careful-extensions-can-bite.html
# Careful! Extensions Can Bite!
- **Published**: 2009-07-22T18:23:00.000-07:00
Since we began work on an extensions system for Chromium, we've received a lot of positive feedback. While the system is not yet complete, we've noticed that a lot of you have started creating and installing extensions for daily use. This is really encouraging, and it motivates us to quickly finish things up, to enable extensions by default on all Google Chrome releases.

If you're using extensions now, you should keep in mind that they are powerful software. Extensions integrate with your browser, so they can access and change everything that happens in it. For example, the same technology that enables an extension to periodically check the number of messages in your Gmail inbox could also be used to read all your personal mail and tweet it to your mom! This can happen because of malicious intent or simply because of a bug.

To help protect your experience when using extensions, we recently enabled [auto-update](http://dev.chromium.org/developers/design-documents/extensions/autoupdate) for extensions on the dev channel release. Like Chrome's auto-update mechanism, extensions will be updated using the [Omaha](http://code.google.com/p/omaha/) protocol, giving developers the ability to push out bug fixes and new features rapidly to users of their extensions. This is an important step towards a v1 release of extensions for all users, so we're pretty excited.

In addition, when we turn the extension system on, we plan to offer a gallery with ratings and comments that you can use to judge whether you want to install a particular extension. We will also have processes in place that, combined with reports from users, should help limit the number of malicious extensions that get uploaded and distributed to users. These processes will include removal of extensions that we have reason to believe are malicious. Until these things are in place and the extension system is officially launched, we recommend that you only install extensions that you built yourself.

Posted by Aaron Boodman, Software Engineer