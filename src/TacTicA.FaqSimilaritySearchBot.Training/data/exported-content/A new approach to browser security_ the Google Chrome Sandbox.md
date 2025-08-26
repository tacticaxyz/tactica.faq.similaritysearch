URL:https://blog.chromium.org/2008/10/new-approach-to-browser-security-google.html
# A new approach to browser security: the Google Chrome Sandbox
- **Published**: 2008-10-02T14:04:00.000-07:00
Building a secure browser is a top priority for the Chromium team; it's why we spend a lot of time and effort keeping our code secure. But as you can imagine, code perfection is something almost impossible to achieve for a project of this size and complexity. To make things worse, a browser spends most of its time handling and executing untrusted and potentially malicious input data. In the event that something goes wrong, the team has developed a sandbox to help thwart any exploit in two of the most popular vectors of attack against browsers: HTML Rendering and JavaScript execution.

In a nutshell, a sandbox is security mechanism used to run an application in a restricted environment. If an attacker is able to exploit the browser in a way that lets him run arbitrary code on the machine, the sandbox would help prevent this code from causing damage to the system. The sandbox would also help prevent this exploit from modifying and even reading your files or any information on the system.

We are very excited to be able to launch Google Chrome with the sandbox enabled on all the platforms we currently support. Even though the sandbox in Google Chrome uses some of the new security features on Windows Vista, it is fully compatible with Windows XP.

What part of chromium is sandboxed?

Google Chrome's [multi process architecture](http://blog.chromium.org/2008/09/multi-process-architecture.html) allows for a lot of flexibility in the way we do security. The entire HTML rendering and JavaScript execution is isolated to its own class of processes; the renderers. These are the ones that live in the sandbox. We expect to work in the near future with the plug-in vendors to securely sandbox them as well.

How does the sandbox work?

The sandbox uses the security features of Windows extensively; it does not reinvent any security model.

To understand how it works, one needs a basic understanding of the Windows security model. With this model all processes have an access token. This access token is like an ID card, it contains information about the owner of the process, the list of groups that it belongs to and a list of privileges. Each process has its own token, and the system uses it to deny or grant access to resources.

These resources are called securable objects. They are securable because they are associated with an access control list, or security descriptor. It contains the security settings of the object. The list of all the users and groups having access to the resource, and what kind of access they have (read, write, execute, etc) can be found there. Files, registry keys, mutexes, pipes, events, semaphores are examples of securable objects.

The access check is the mechanism by which the system determines whether the security descriptor of an object grants the rights requested to an access token. It is performed every time a process tries to acquire a securable object.

The process access token is almost entirely customizable. It's possible to remove privileges and disable some groups. This is exactly what the sandbox does.

Before launching the renderer process we modify its token to remove all privileges and disable all groups. We then convert the token to a restricted token. A restricted token is like a normal token, but the access checks are performed twice, the first time with the normal information in the token, and the second one using a secondary list of groups. Both access checks have to succeed for the resources to be granted to the process. Google Chrome sets the secondary list of groups to contain only one item, the NULL user. Since this user is never given permissions to any objects, all access checks performed with the access token of the renderer process fail, making this process useless to an attacker.

Of course, not all resources on Windows follow this security model. The keyboard, the mouse, the screen and some user objects, like cursors, icons and windows are examples of resources that don't have security descriptors. There is no access check performed when trying to access them. To prevent the renderer from accessing those, the sandbox uses a combination of Job Objects and alternate desktops. A job object is used to apply some restrictions on a group of processes. Some of the restrictions we apply on the renderer process include accessing windows created outside the job, reading or writing to the clipboard, and exiting Windows. We also used an alternate desktop to prevent the renderer from seeing the screen (screen scrapping) or eavesdropping on the keyboard and mouse (key logging). Alternate desktops are commonly used for security. For example, on Windows, the login screen is on another desktop. It ensures that your password can't be stolen by applications running on your normal desktop.

What are the limitations?

As we said earlier, the sandbox itself is not a new security model; it relies on Windows to achieve its security. Therefore, it is impossible for us to prevent against a flaw in the OS security model itself. In addition, some legacy file systems, like FAT32, used on certain computers and USB keys don't support security descriptors. Files on these devices can't be protected by the sandbox. Finally, some third party vendors mistakenly configure files, registry keys and other objects in a way that bypasses the access check, giving everyone on the machine full access on them. Unfortunately, it's impossible for the sandbox to protect most of these misconfigured resources.

To conclude, it is important to mention that this sandbox was designed to be generic. It is not tied to Google Chrome. It can easily be used by any other projects with a compatible multi-process architecture. You can find more information about the sandbox in the [design doc](http://dev.chromium.org/developers/design-documents/sandbox), and we will post here again about the details of our token manipulation and our policy framework to configure the level of security of the sandbox.

We hope you will feel safe browsing the web using Google Chrome, and we are looking forward to your feedback and code contribution!

Posted by Nicolas Sylvain, Software Engineer