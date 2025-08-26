URL:https://blog.chromium.org/2010/01/google-chrome-extension.html
# Google Chrome Extension Internationalization
- **Published**: 2010-01-13T12:03:00.000-08:00
Starting with Google Chrome [developer channel](http://www.chromium.org/getting-involved/dev-channel) release 4.0.288.1 and [beta channel](http://www.chromium.org/getting-involved/dev-channel) release 4.0.249.64 for Windows, an [internationalization (i18n) framework](http://code.google.com/chrome/extensions/i18n.html) for Google Chrome Extensions is available and enabled by default. This framework lets extension developers translate user-visible parts of the extension manifest — such as the name and description, and localize messages using simple JavaScript calls to the [chrome.i18n.getMessage()](http://code.google.com/chrome/extensions/trunk/i18n.html#method-getMessage) method. We've implemented this feature as described in the [design docs for Chromium](http://dev.chromium.org/developers/design-documents/extensions/i18n).

The following screenshots show a browser action's tooltip that has been translated into English, Spanish, Serbian, and Korean.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjXDv_zde2lrdBtp3hm92DpX68Lk2sCjrIc7LS2x7-RbDHuWoLEOJSi_G5sl5Jigc2LB7pdWB9hhI21lt5eCp_TXlqs82wM4uRcwgwBTasVqisG7xLeB8DPD0lVqnxdpaZnflDDvuGehHhR/s400/i18n+screenshot.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjXDv_zde2lrdBtp3hm92DpX68Lk2sCjrIc7LS2x7-RbDHuWoLEOJSi_G5sl5Jigc2LB7pdWB9hhI21lt5eCp_TXlqs82wM4uRcwgwBTasVqisG7xLeB8DPD0lVqnxdpaZnflDDvuGehHhR/s1600-h/i18n+screenshot.png) [![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhhfcj4m4ENSXF4XwWSDpsap-f3LdQkvshayTnMYTLihY1SyAIdI7S-H-qNrvoD-Sgj-T8xB-rNdgcc5cYDpCy9nf-mrKcobu4D2CpbAH3BP08FX_A0WrT2t2td8MzyZvIGAd4ZRHgXjuHo/s400/i18n+2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhhfcj4m4ENSXF4XwWSDpsap-f3LdQkvshayTnMYTLihY1SyAIdI7S-H-qNrvoD-Sgj-T8xB-rNdgcc5cYDpCy9nf-mrKcobu4D2CpbAH3BP08FX_A0WrT2t2td8MzyZvIGAd4ZRHgXjuHo/s1600-h/i18n+2.png) [![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjGWhFC9jtgNfYHRDmBREkyQfhYdrtNoI4Th60b5upzJ0t8yIhqkuTqYmjiMTqoiYAO7Bs0bh-CITuz9YdTh0p9T-C0pONXk7KclAU7hU6g5zGPsptJIVem-k3xHhtQEnctRn-fKoMqCutc/s400/i18n+3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjGWhFC9jtgNfYHRDmBREkyQfhYdrtNoI4Th60b5upzJ0t8yIhqkuTqYmjiMTqoiYAO7Bs0bh-CITuz9YdTh0p9T-C0pONXk7KclAU7hU6g5zGPsptJIVem-k3xHhtQEnctRn-fKoMqCutc/s1600-h/i18n+3.png) [![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgyPC2qH8hL4L7yxJXA67301Q4atsSttIVYwKNMBgrdCrHaGhudcqTjLUqYashAGNxLOfyvJK5sxVdZQJ-DjV0twE7LP6iiNvv9ma3PxZNOF22qTiC9hpRrlXJ8snMonzP9HD1eZfIcQuB-/s400/i18n+4.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgyPC2qH8hL4L7yxJXA67301Q4atsSttIVYwKNMBgrdCrHaGhudcqTjLUqYashAGNxLOfyvJK5sxVdZQJ-DjV0twE7LP6iiNvv9ma3PxZNOF22qTiC9hpRrlXJ8snMonzP9HD1eZfIcQuB-/s1600-h/i18n+4.png)

To localize the extension manifest, extract all user-visible strings into [message catalogs](http://www.chromium.org/developers/design-documents/extensions/i18n#TOC-Message-container), and define the [default locale](http://code.google.com/chrome/extensions/trunk/manifest.html#default_locale).

  

```
{  
"name": "__MSG_name__",  
"description": "__MSG_description__",  
...  
"default_locale": "en",  
...  
}
```

  

To get translated messages in JavaScript code, including extension code and content scripts, invoke one of the following forms of chrome.i18n.getMessage().

  

```
chrome.i18n.getMessage("messagename")  
chrome.i18n.getMessage("messagename", "one parameter")  
chrome.i18n.getMessage("messagename", ["one", "to", "nine", "parameters"])
```

  

For more details, see the [documentation](http://code.google.com/chrome/extensions/i18n.html).

We're more than happy to hear your feedback, not only on our implementation and documentation, but also on the API design. You can reach us at the [chromium-extensions group](http://groups.google.com/group/chromium-extensions).

Posted by Nebojsa Ciric, Software Engineer