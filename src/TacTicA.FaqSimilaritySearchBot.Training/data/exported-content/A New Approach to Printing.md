URL:https://blog.chromium.org/2010/04/new-approach-to-printing.html
# A New Approach to Printing
- **Published**: 2010-04-15T13:42:00.000-07:00
When we [demonstrated Google Chrome OS](http://googleblog.blogspot.com/2009/11/releasing-chromium-os-open-source.html) last Fall, a few folks asked us how it would handle printing. Today we wanted to give developers a little more insight into our approach for printing from Chrome OS and other web-connected platforms.  
  
While the emergence of cloud and mobile computing has provided users with access to information and personal documents from virtually any device, today’s printers still require installing drivers which makes printing impossible from most of these new devices. Developing and maintaining print subsystems for every combination of hardware and operating system-- from desktops to netbooks to mobile devices -- simply isn't feasible.   
  
Since in Google Chrome OS all applications are web apps, we wanted to design a printing experience that would enable web apps to give users the full printing capabilities that native apps have today. Using the one component all major devices and operating systems have in common-- access to the cloud-- today we're introducing some preliminary designs for a project called Google Cloud Print, a service that enables any application (web, desktop, or mobile) on any device to print to any printer.   
  
Rather than rely on the local operating system (or drivers) to print, apps can use Google Cloud Print to submit and manage print jobs. Google Cloud Print will then be responsible for sending the print job to the appropriate printer with the particular options the user selected, and returning the job status to the app.  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjCtJdRvER3vTkAem46D1h9IECqPJDR5-ejgwbhOFX4p5iuDWlNtefgMRN_ktUjBpPUVzzmI7QhH2c6RjUZi7J7mUih_MCyDecZyPB53Dfo5Mx3nC94jQUqTWJCCVetfFIM7Cv7A3P5T-I/s400/Google+Cloud+Print+infographic.gif)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjCtJdRvER3vTkAem46D1h9IECqPJDR5-ejgwbhOFX4p5iuDWlNtefgMRN_ktUjBpPUVzzmI7QhH2c6RjUZi7J7mUih_MCyDecZyPB53Dfo5Mx3nC94jQUqTWJCCVetfFIM7Cv7A3P5T-I/s1600/Google+Cloud+Print+infographic.gif)  
  
Google Cloud Print is still under development, but today we are making [code](http://codereview.chromium.org/1566047/show) and [documentation](http://code.google.com/apis/cloudprint/docs/overview.html) public as part of the open-source Chromium and Chromium OS projects. While we are still in the early days of this project, we want to be as transparent as possible about all aspects of our design and engage the community in identifying the right set of open standards to make cloud-based printing ubiquitous. You can view our design docs and outlines [here](http://code.google.com/apis/cloudprint) and we hope you stay tuned for updates in the coming months.  
  
Posted by Mike Jazayeri, Group Product Manager