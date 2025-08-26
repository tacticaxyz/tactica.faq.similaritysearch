URL:https://blog.chromium.org/2010/03/introducing-angle-project.html
# Introducing the ANGLE Project
- **Published**: 2010-03-18T10:11:00.000-07:00
We're happy to announce a new open source project called Almost Native Graphics Layer Engine, or ANGLE for short. The goal of ANGLE is to layer WebGL's subset of the OpenGL ES 2.0 API over DirectX 9.0c API calls. We're open-sourcing ANGLE under the BSD license as an early work-in-progress, but when complete, it will enable browsers like Google Chrome to run WebGL content on Windows computers without having to rely on OpenGL drivers.

Current browser implementations of WebGL need to be able to issue graphics commands to desktop OpenGL to render content. This requirement isn't a problem on computers running OS X or Linux, where OpenGL is the primary 3D API and therefore enjoys solid support. On Windows, however, most graphics-intensive apps use Microsoft Direct3D APIs instead of OpenGL, so OpenGL drivers are not always available. Unfortunately, this situation means that even if they have powerful graphics hardware, many Windows machines can't render WebGL content because they don't have the necessary OpenGL drivers installed. ANGLE will allow Windows users to run WebGL content without having to find and install new drivers for their system.

Because ANGLE aims to implement most of the OpenGL ES 2.0 API, the project may also be useful for developers who are working on applications for mobile and embedded devices. ANGLE should make it simpler to prototype these applications on Windows, and also gives developers new options for deploying production versions of their code to the desktop.

We hope that other WebGL implementors and others in the graphics community will join us to make ANGLE successful! For more info on ANGLE and to access the code repository, visit the [new project on Google Code](http://code.google.com/p/angleproject) or join our [discussion group](https://groups.google.com/group/angleproject).

Posted by Henry Bridge, Product Manager