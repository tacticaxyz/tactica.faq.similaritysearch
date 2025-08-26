URL:https://blog.chromium.org/2010/11/compatibility-issues-with-emet.html
# Compatibility Issues With EMET
- **Published**: 2010-11-16T14:55:00.000-08:00
We have discovered compatibility issues between Google Chrome and [Microsoft’s Enhanced Mitigation Experience Toolkit](http://blogs.technet.com/b/srd/archive/2010/09/02/enhanced-mitigation-experience-toolkit-emet-v2-0-0.aspx) (EMET). EMET is used to deploy and configure security mitigation technologies, often for legacy software. However, because Chrome already uses many of the same techniques (and [more](http://www.chromium.org/developers/design-documents/sandbox)), EMET does not provide any additional protection for Chrome. In fact, the current version of EMET interferes with Chrome’s security and prevents Chrome from updating.   
  
We are working closely with Microsoft on a solution to these issues. In the meantime, we advise users and enterprises not to attempt to configure EMET to work with Chrome.  
  
Posted by Ian Fette, Product Manager and Carlos Pizano, Software Engineer