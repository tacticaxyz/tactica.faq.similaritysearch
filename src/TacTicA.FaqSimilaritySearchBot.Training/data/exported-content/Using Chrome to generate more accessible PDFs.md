URL:https://blog.chromium.org/2020/07/using-chrome-to-generate-more.html
# Using Chrome to generate more accessible PDFs
- **Published**: 2020-07-29T09:02:00.000-07:00
Starting in Chrome 85 (scheduled to go to stable in late August), Chrome will automatically generate a tagged PDF when you print a web page and choose the "Save as PDF" destination. A tagged PDF is one that contains extra metadata about the structure of a document, including things like headings, lists, tables, paragraphs, and image descriptions. Tagged PDFs are more accessible to users with disabilities, such as blind users who use a screen reader to access PDF files. Tagged PDFs can have other uses too, like making it easier for software that needs to automatically process and extract data from PDFs.

  

We think adding this metadata to PDFs is a perfect fit for Chrome, because that information is already available in well-structured, accessible web pages. We hope this helps make more content exported from Chrome to be accessible to even more users.

  

Organizations that publish content for the general public online often require that all of their PDFs are accessible, either as a matter of policy or to comply with local laws such as [Section 508](https://www.section508.gov/) in the U.S.  Unfortunately, a lot of software programs that are otherwise great for authoring content don't have any support for directly generating a tagged PDF. In these cases, separate remediation software or services are used to make PDFs compliant. By building this into Chrome, we're hoping some organizations that already use HTML as part of their document workflow might be able to take advantage of this new functionality and generate compliant PDFs more easily. This feature also works with [Chrome Headless](https://developers.google.com/web/updates/2017/04/headless-chrome) when you use both the --print-to-pdf and --export-tagged-pdf flags.

  

When we started our journey to make PDFs more accessible, we reached out to the experts - [CommonLook](https://commonlook.com/about/get-started-with-commonlook/?utm_source=google-accessibility-news&utm_medium=other&utm_campaign=google2020), an organization that's been offering PDF accessibility software and services for more than 20 years and which is active in setting PDF standards. We made use of CommonLook's PDF Validator and consulted with them to ensure we were focusing our efforts on the areas that would have the biggest impact.

  

"To improve the accessibility of PDF documents in Chrome, Google reached out to CommonLook because of our expertise in PDF accessibility. At the time, we recognized the potential impact on PDF accessibility due to the massive number of Chrome users around the world. Two years later, we are pleased to announce that significant progress has been made, and now Chrome is rolling out this feature to all users every time they generate a PDF from Chrome. We will continue to support Google as they work to make Chrome more accessible to all their users." - Monir ElRayes, President and CEO, CommonLook

  

This feature is rolling out as an experiment. Use chrome://flags/#export-tagged-pdf if you'd like to try it out before it's enabled automatically for all users.

  

While this is an important milestone, we're not done. Future work includes both improving the quality of generated tagged PDFs, and also improving Chrome's built-in PDF reader to better consume tagged PDFs.

  

Posted by Dominic Mazzoni, technical lead for Chrome accessibility.