URL:https://blog.chromium.org/2020/01/appcache-scope-restricted.html
# AppCache Scope Restricted
- **Published**: 2020-01-21T08:55:00.000-08:00
The Application Cache (AppCache) specification has been [deprecated](https://html.spec.whatwg.org/multipage/offline.html#offline) since December 2016 and in Chrome starting in version 79. In Chrome 70, AppCache was removed from insecure contexts. We plan to remove AppCache in Chrome 82. Prior to AppCache's removal in Chrome 82, we're announcing a security fix that introduces the concept of a manifest scope.   
  
Beginning in Chrome 80 in January, 2020, the scope of the AppCache manifest will be restricted to the path it is served from. Previously, a manifest served from any location within a site's origin could override everything within that origin. For example, a manifest served from `www.example.com/foo/bar/` would previously allow overriding any URLs within `www.example.com`. Now it will only allow overriding URLs beginning with `www.example.com/foo/bar/`, the scope of the manifest.  
  
**Does This Affect My Website?**  
To see if this affects your website, go to `chrome://appcache-internals/` and compare the path of the manifest to the paths under File URL. Note that this change only affects "Intercept" and "Fallback" properties. (See the image below.)  
  
![](https://lh6.googleusercontent.com/NgbVFoX9fm5asS5inCbDdBSPNIzvfi8kQ-4_SG-93_DMXLNLAZNPbaMl8fruKXoQWx-rDYAPKeFuYnFmL0Nt-tcDupbYIbILvW5yk4EokjC9aox-U34Us6PGoTugmSurL8sf5E06)  
You should also test your site using the command line feature flag. To do so:  

1. Launch Chrome 80 using the following command:  
     
   `google-chrome --enable-features="AppCacheManifestScopeChecks"`
2. Open `chrome://appcache-internals/`, find your manifest and remove it.
3. Open your site so a new AppCache instance is created.
4. Open `chrome://appcache-internals`/, verify your manifest appears as expected and parser version is set to 1.
5. Go offline, then access your site so it's served from AppCache. Verify all pages load as expected.

**Mitigations**  
The replacement technology for AppCache is the [Cache API](https://developer.mozilla.org/en-US/docs/Web/API/Cache), which requires a [service worker](https://developers.google.com/web/fundamentals/primers/service-workers/). For a shorter term mitigation, add the following HTTP response header to your manifest responses:  
  
  

```
X-AppCache-Allowed: /
```

  
This header is new in Chrome 80 and will be supported until Chrome 82, which is our announced AppCache removal milestone. Please be aware that AppCache, like all Chrome features, makes use of the disk cache to fetch server responses, so any long-lived disk cache entries for a manifest must be cleared in order to pick up a server `X-AppCache-Allowed` header change.  
Posted by jmedley 