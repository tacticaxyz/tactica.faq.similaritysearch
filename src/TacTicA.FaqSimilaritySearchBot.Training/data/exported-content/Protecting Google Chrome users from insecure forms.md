URL:https://blog.chromium.org/2020/08/protecting-google-chrome-users-from.html
# Protecting Google Chrome users from insecure forms
- **Published**: 2020-08-17T09:56:00.001-07:00
***Update (10/07/2020): Mixed form warnings were originally scheduled for Chrome 86, but will be delayed until Chrome 87.***

Beginning in M86, Chrome will warn users when they try to complete forms on secure (HTTPS) pages that are submitted insecurely. These “mixed forms” (forms on HTTPS sites that do not submit on HTTPS) are a risk to users’ security and privacy. Information submitted on these forms can be visible to eavesdroppers, allowing malicious parties to read or change sensitive form data. 

  

Specifically, Chrome will be making the following changes to communicate the risks associated with mixed form submission:

* Autofill will be disabled on mixed forms.  
  Note: On mixed forms with login and password prompts, Chrome’s password manager will continue to work. Chrome’s  password manager helps users input unique passwords, and it is safer to use unique passwords even on forms that are submitted insecurely, than to reuse passwords.
* When a user begins filling out a mixed form, they will see warning text alerting them that the form is not secure.

        

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg4iX9Z5QfOTCR889kIKHdYOlhZgHu0lkkmJ4qLDgdarhwozlL42TB3Ov88_QMNMzpG_DWEQcWJNTj7yhw809vf0wsrVopEIIw_nBqB0BPqFlAF9I32RyAUufM6gty7ROELh22OnT8PVXnc/s640/Screen+Shot+2020-08-13+at+4.34.37+PM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg4iX9Z5QfOTCR889kIKHdYOlhZgHu0lkkmJ4qLDgdarhwozlL42TB3Ov88_QMNMzpG_DWEQcWJNTj7yhw809vf0wsrVopEIIw_nBqB0BPqFlAF9I32RyAUufM6gty7ROELh22OnT8PVXnc/s1322/Screen+Shot+2020-08-13+at+4.34.37+PM.png)

  

* If a user tries to submit a mixed form, they will see a full page warning alerting them of the potential risk and confirming if they’d like to submit anyway.

          

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj0b1SRu07mf-CJ8SHHAH9ehsTXs3zIpAJqpcAXRsf7JTFTwKSBnkZ7Q4bCGukxyBMgb8zxiXa12cVaeZDixS3GhyphenhyphengAw4hYEhceNO1U8yAlR0JpkSjikJHZSxpwG9X_WHMeixPPgsMmNwzv/s640/Screen+Shot+2020-08-13+at+4.37.25+PM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj0b1SRu07mf-CJ8SHHAH9ehsTXs3zIpAJqpcAXRsf7JTFTwKSBnkZ7Q4bCGukxyBMgb8zxiXa12cVaeZDixS3GhyphenhyphengAw4hYEhceNO1U8yAlR0JpkSjikJHZSxpwG9X_WHMeixPPgsMmNwzv/s1282/Screen+Shot+2020-08-13+at+4.37.25+PM.png)

  

Before M86, mixed forms were only marked by removing the lock icon from the address bar. We saw that users found this experience unclear and it did not effectively communicate the risks associated with submitting data in insecure forms.

  
We encourage developers to [fully migrate forms on their site to HTTPS](https://developers.google.com/web/fundamentals/security/prevent-mixed-content/fixing-mixed-content) to protect their users. Developers with questions are welcome to email us at security-dev@chromium.org.

Posted by Shweta Panditrao, Chrome Security Team