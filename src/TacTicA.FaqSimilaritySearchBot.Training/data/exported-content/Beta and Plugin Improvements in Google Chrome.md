URL:https://blog.chromium.org/2008/10/beta-and-plugin-improvements-in-google.html
# Beta and Plugin Improvements in Google Chrome
- **Published**: 2008-10-30T17:40:00.000-07:00
After the beta launch in early September, from the first wave of feedback, we realized that a large number of users were facing plugin compatibility issues in Google Chrome. These included Adobe Flash videos not playing, as well as various browser performance issues with Adobe Flash and Adobe PDF document loading. There was even an issue where the browser consumed 100% CPU when users interacted with plugins.

This is exactly the kind of feedback we are expecting from a beta launch. We have invested a lot of effort into automating compatibility testing for large number of web pages but there is nothing like actual user feedback. We are impressed by the user response to the beta and the quality of bug reports filed. Nothing more motivating than a lot of users waiting for your work. :)

One of the big issues was support for PDF Fast WebView, which is the ability for a webserver to byte serve a PDF document. This allows a client to request specific byte ranges in the file while skipping pages that are not needed. This is supported generically by seekable streams specification in NPAPI, which Google Chrome now implements. This should improve performance with large PDF files or any other content served using Fast WebView.

We had a lot of fun fixing other issues too, and here are the stories behind a couple of them.

> YouTube videos stop after six seek attempts:
>
> We received several reports of YouTube videos failing to play. Many reports indicated that this symptom had something to do with using the slider while playing the video. However, we didn't have a reliable scenario to reproduce in this in-house.
>
> Darin Fisher observed that if you move the slider many times, the video stopped playing. Furthermore, he found out that if the slider was moved exactly six times the video would stop playing. This was interesting, because Google Chrome uses a maximum of 6 HTTP connections per host.
>
> A quick check of the 'I/O Status' in about:network revealed that all connections were active. The question then became one of why the existing connections weren't canceled when the slider was moved.
>
> Darin found that the Flash plugin would return an error when we supplied it data while the slider was moved. In this case a browser is supposed to cancel the connection and that's what fixed it.
>
> Google Finance chart dragging:
>
> This report was very interesting, due to the fact that it only occurred on single core machines. Of course, in the end we found out that there wasn't any direct connection between the root cause and single core machines. In Google Chrome plugin windows live in a separate plugin process so a plugin has little or no influence on the browser thread, or so we thought.
>
> After some inspection we found out that when a plugin is receiving mouse input, the browser main thread spins with 100% CPU for sometime. Now, the twist to the story is that since a plugin window is a child of the browser window, thread inputs of the browser and the plugin are attached.
>
> We started looking at the browser message loop more closely. Soon we discovered that MsgWaitForMultipleObjects/PeekMessage APIs behaved strangely when thread inputs are attached. The MsgWaitForMultipleObjects API is typically used to block until an event or a windows message such as an input is available for processing. In this case, we found that it was returning an indication that an input event was available for processing, while PeekMessage indicated no event was available.
>
> This behavior is probably due to the fact that thread inputs are attached and GetQueueStatus, called internally by MsgWaitForMultipleObjects, returned an indication that input is available in the browser thread, while in reality it was intended for the plugin. This caused the MsgWaitForMultipleObjects not do its intended function of waiting, and caused the browser thread to spin.

These are just a few examples of bugfixes we've made to Google Chrome to address performance issues related to plugins. We continue to look closely at the performance of Google Chrome, both as a whole and in relation to interaction with plugins, to make sure that users are getting the best browsing experience that we can deliver.

Posted by Anantanarayanan Iyengar and Amit Joshi, Software Engineers