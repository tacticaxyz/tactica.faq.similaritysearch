URL:https://blog.chromium.org/2010/06/fresh-coat-of-chrome.html
# A fresh coat of chrome
- **Published**: 2010-06-25T08:19:00.001-07:00
As part of our continual work on Google Chrome’s user interface, we’ve been trying to streamline the toolbar, make the [Omnibox](http://www.google.com/support/chrome/bin/answer.py?answer=95440) more approachable, and communicate site security information more clearly. Users on our [dev channel](http://www.chromium.org/getting-involved/dev-channel) may have noticed some of these experiments already:  

  
* When you are typing into the Omnibox, an icon to the left will show how your input will be interpreted - such as a magnifying glass for search queries (![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi8NqdOCfobfZN2VRf67wwaRAOYka5fs7xXIvtcryz7vZECtx2pddzOpChcflWxvPjcAG-oDMcTDmXRVtOAbSOzzbufsUzyN31ZL4IpwiUS64nuv_gK7Hyo3Ei9POa9F50Nq5ePR0TjapY/s400/magnifying.png)), and a globe for URLs (![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhBoc8u5VbNrrUB1Yp0zbcbpctO03_F8seSM1UFS2DzCGlMdd9Xob0mJSRv0fskLV6lMM_yDZGT06-bYxr9Or7yHhN29TlSVYPK2eFqub_Nun0yZrzK18VEk5BgYaqfOHGW2u-R3HxzixA/s400/globe.png)). When you’re not typing, the same icon can be dragged to another document to copy the current page’s URL, or clicked to reveal information about the current site.
  
* When on a secure (SSL) site, this icon changes to a lock (![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhzjwWCE4KbAJYMDO_IW035a9uTW_p8vbQrX7u-M-jeb0iK-1R3kaWonMpSwaF44WNQ5PWtakiaLB_OMYIvI8OFaRY2QEl-sydQx5omCbRC6tNsWrniiOcehSYoFKtuczMB_3wsMDt-Cl8/s400/lock.png)) - previously we displayed the lock icon at the end of the Omnibox, but now it’s closer to the URL and in a more obvious place.
  
* We’ve added a clearer presentation of Extended Validation (EV) certificate holder names (![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEipSS64QEcn8cyu-_GNTeNzv89bRs_SLX0Albt7lhyphenhyphenEOnfX9PfnzuBLbA4-Nf-9tiDjkQ3ANqAMGiiF35uLSItwvrjj-Rb2n2-zgcQu3Ya4uf69JHcQq-DDkJfpZGhBj_bgs75CXoZaJZw/s400/EV.png)), which, like the lock, are now at the beginning of the Omnibox.
  
* We’ve changed the colors and icons used with secure sites to make mixed content more obvious, and avoid confusion about ambiguous colors.
  
* In some situations, we’ve stopped displaying “http://” and/or a slash after the hostname. This makes the hostname more prominent and the URL more readable, and provides more visual distinction between regular and SSL websites (which keep their “https://” prefix). We’ve also done a lot of work to make sure that copying and pasting of these URLs continue to work as you would expect.
  
* The bookmark star icon (![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjKTfp2JqRyN9rAg40nOAabSXDyCBHM5gkn_JSZcitHKPFsbnV_8b-T-VhBHU7ZSTJijPiDRKrxvk8x3vfj037x_lxsi1msyXElPstjLsgvshe26I2_rFuRq2tvIi4p78z8wyVDSW9w3I4/s400/star.png)) has joined the other “page actions” at the right-hand side of the Omnibox.
  
* Stop and Reload have been combined, and Go eliminated, to make things simpler and keep all the navigation-related toolbar buttons together.
  

  
Here’s a screenshot of the old interface in the stable channel (5.0), followed by the current interface on the dev channel (6.0):  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhjez66021H1D-GFsZhlCEtUVWHGOsJJoXrnj-W1AXYnJ_VqR-1G-2fgNR9ToWBuTDUM0rUaEUaD5cOXtde6YBtQI_Kzd3b-rNpR_hT4vAdgpZHYRv_9WNHtYPFL7M3snu9XRxNrS_8WZ0/s400/Chrome1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhjez66021H1D-GFsZhlCEtUVWHGOsJJoXrnj-W1AXYnJ_VqR-1G-2fgNR9ToWBuTDUM0rUaEUaD5cOXtde6YBtQI_Kzd3b-rNpR_hT4vAdgpZHYRv_9WNHtYPFL7M3snu9XRxNrS_8WZ0/s1600/Chrome1.png)  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjnYp1u1yy2c5cjICo3By0MDprZc1GoUU5aaRGid8xbHwDtB_u-EfwaFXzWzcDCjFGFqEvgKIifA1llOreL1L-ilvBw2WN-B622Kg7KF6HcLL3fmVTogMsiR0HlxPrgs8dOpIYze1WDN1g/s400/Chrome2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjnYp1u1yy2c5cjICo3By0MDprZc1GoUU5aaRGid8xbHwDtB_u-EfwaFXzWzcDCjFGFqEvgKIifA1llOreL1L-ilvBw2WN-B622Kg7KF6HcLL3fmVTogMsiR0HlxPrgs8dOpIYze1WDN1g/s1600/Chrome2.png)  
  
More experiments are on the way to all platforms, like simplifying our menu structure, and further reducing visual noise in the toolbar:  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgh2XP2FJMSfte_LZRGl89lt4Bx3-u6MUr9fb3JeFRM2IUwETPO6QQPDYr_jildUXQ1MIShKC6Baw0gNM2PbRTsXsJQvqno9lRXb5YFJCnPQ374_Q9s_vPPY0q3Wn9GzfJchvm5LgmMXcw/s400/Chrome3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgh2XP2FJMSfte_LZRGl89lt4Bx3-u6MUr9fb3JeFRM2IUwETPO6QQPDYr_jildUXQ1MIShKC6Baw0gNM2PbRTsXsJQvqno9lRXb5YFJCnPQ374_Q9s_vPPY0q3Wn9GzfJchvm5LgmMXcw/s1600/Chrome3.png)  
  
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjkHEG4QyNlDH78oHI2K6YY6X5zMz22tvuKRCPYEFLXK2ZX9o23lMMINnWKBT0tIBG2oSB20TfCLPfBgcw50FJ4s9m39zWApECt5mMHZVQoUqOh2kv5KJpOHO4HoIOshBgqf-XiYSkDuNg/s400/Chrome4.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjkHEG4QyNlDH78oHI2K6YY6X5zMz22tvuKRCPYEFLXK2ZX9o23lMMINnWKBT0tIBG2oSB20TfCLPfBgcw50FJ4s9m39zWApECt5mMHZVQoUqOh2kv5KJpOHO4HoIOshBgqf-XiYSkDuNg/s1600/Chrome4.png)  
  
In all these cases, we may tweak or even revert experiments before settling on a final solution. We’ve found that living with a new design is more informative than merely discussing it, so thanks to all our dev channel users for your patience and feedback as we test out these changes.  
  
Posted by Nicholas Jitkoff, User Experience Designer