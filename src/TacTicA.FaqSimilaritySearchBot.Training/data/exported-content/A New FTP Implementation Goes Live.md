URL:https://blog.chromium.org/2009/09/new-ftp-implementation-goes-live.html
# A New FTP Implementation Goes Live
- **Published**: 2009-09-03T09:56:00.000-07:00
Starting in the Dev channel release 4.0.203.2, we are using our new FTP implementation by default on Windows. (It was already enabled by default on Linux and Mac.) This switchover is an important milestone in the development of our network stack. We'd like to acknowledge two Chromium contributors who made this possible.

The new FTP implementation was initially written by Ibrar Ahmed single–handedly. It was a long journey for him because he worked on it in his spare time. Ibrar has a master's degree in computer science from International Islamic University. After working as software engineer and associate architect at other companies, he recently started his own tele-medicine company. We thank Ibrar for his contribution to the Chromium network stack!

Paweł Hajdan Jr. started to work on the new FTP code in July as one of his summer intern projects at Google. Paweł added new unit tests, fixed bugs and compatibility issues, and is taking the lead in bringing the new FTP code to production quality.

Finally, we used Mozilla code for parsing and formatting FTP directory listings (ParseFTPList.cpp), which was originally written by Cyrus Patel.

In the near term, the original WinInet-based FTP implementation will still be available as an option on Windows. Specify the --wininet-ftp command-line option to enable it. (The original --new-ftp option is now obsolete and ignored.) During this period we will fix FTP bugs only in the new FTP implementation. When we're happy with the quality of the new FTP code, we will remove the original WinInet-based implementation, finally eliminating our dependency on WinInet.

Please help us achieve that goal by testing FTP with a Dev channel release and filing bug reports. Follow these guidelines when reporting bugs:

* Please don't add a comment like "Here is another URL that doesn't work for me" to a bug. Always open a new bug, and give a link to another bug if you think they are similar.
* Make the steps to reproduce as detailed as possible, and always include the version number of Chrome.
* Check if the problem can be reproduced with --wininet-ftp on Windows and include that information in the bug report.

Posted by Wan-Teh Chang, Software Engineer