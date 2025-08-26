URL:https://blog.chromium.org/2021/04/digging-for-performance-gold.html
# Digging for performance gold: finding hidden performance wins
- **Published**: 2021-04-22T12:15:00.001-07:00
*We are fortunate that so many people choose Chrome as their browser to get things done, which is why we are continually investing in making Chrome more performant. But with software as complex as Chrome, there is a lot of performance left hidden in areas we aren’t actively working on. In our latest post in the [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) series, we investigate how to diagnose, find, and fix performance problems that normally go undetected.*  
  
  
  

The 1%
------

Our metrics show that while Chrome is fast on average, it can be noticeably slow at times. Such user-pain is visible in the 99th percentile of many of our metrics but unreproducible, and thus quite hard to act upon. Deeper analysis in the data shows that the long-tail of performance is not 1% of users on slow machines but rather many users, 1% of the time.  
  
Let’s talk about 1%. 1% is quite large in practice. The core metric we use is “jank” which is a noticeable delay between when the user gives input and when software reacts to it. Chrome measures jank every 30 seconds, so Jank in 1% of samples for a given user means jank once every 50 minutes. To that user, Chrome feels slow at those moments. Now the problem: can we find and fix the root causes of all the ways Chrome can be momentarily slow for our users?  
  

Approach
--------

As engineers, our training in optimization is to focus on improving the algorithmic performance of the components we own. The last 3 years of analyzing the immensely complex codebase of Chrome however have taught us that the real issue is often cross-cutting: multiple unrelated features’ long-tail performance issues, sharing the same systemic root cause(s). Applying local expertise and optimization is likely to miss the global optimum. It is necessary to disregard our initial intuition and assume ignorance, forcing us to dig beyond what is immediately apparent and find the underlying root cause by relentlessly exposing what we don’t know.

Chasing Invisible Bugs
----------------------

How do we find bugs that are unforeseen, unreproducible, unowned, and essentially invisible?  
  
First, define a scenario. For this work, we focus on user-visible Jank, which we [measure in the field](https://chromium.googlesource.com/chromium/src/+/master/tools/metrics/histograms/README.md) as a way to systematically identify moments where Chrome feels slow.  
  
Second, gather high actionability bug reports in the field. For this we rely on Chrome’s [BackgroundTracing](https://source.chromium.org/search?q=BackgroundTracing&ss=chromium) infrastructure to generate what we call Slow Reports. A subset of Canary users who have opted in to sharing anonymized metrics have circular-buffer tracing enabled to examine specific scenarios. If a preconfigured threshold on a metric of interest is hit, the trace buffer is captured, anonymized, and uploaded to Google servers.  
  
Such a bug report might look like this:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhuamYfrtx4rDkQAW9KBorT5zdM8EkMamWGuPsnDU8VW7iJfMzm0j_NozS7ak7z1xQEMuIXFL_6LLMX7VsfkJFlEjwv_9C5Uhyphenhyphen6ywYquTNFb02c6NrXJegyZzka-pPVUJbLPFDoEprW8L6F/w654-h92/image1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhuamYfrtx4rDkQAW9KBorT5zdM8EkMamWGuPsnDU8VW7iJfMzm0j_NozS7ak7z1xQEMuIXFL_6LLMX7VsfkJFlEjwv_9C5Uhyphenhyphen6ywYquTNFb02c6NrXJegyZzka-pPVUJbLPFDoEprW8L6F/s1351/image1.png)

chrome://tracing view of a 2 seconds Jank on AutocompleteController::UpdateResult() on an otherwise healthy machine

  
  
We have a culprit! Let’s optimize AutocompleteController? No! We don’t know why yet: keep assuming ignorance!  
  
By augmenting BackgroundTracing with stack sampling, we were able to find a recurring stack under stalled AutoComplete events:

RegEnumValueW

RegEnumValueWStub

    base::win::RegistryValueIterator::Read()

    gfx::`anonymous namespace\'::CachedFontLinkSettings::GetLinkedFonts

    gfx::internal::LinkedFontsIterator::GetLinkedFonts()

    gfx::internal::LinkedFontsIterator::NextFont(gfx::Font \*)

    gfx::GetFallbackFonts(gfx::Font const &)

    gfx::RenderTextHarfBuzz::ShapeRuns(...)

    gfx::RenderTextHarfBuzz::ItemizeAndShapeText(...)

    gfx::RenderTextHarfBuzz::EnsureLayoutRunList()

    gfx::RenderTextHarfBuzz::EnsureLayout()

    gfx::RenderTextHarfBuzz::GetStringSizeF()

    gfx::RenderTextHarfBuzz::GetStringSize()

    OmniboxTextView::CalculatePreferredSize()

    OmniboxTextView::ReapplyStyling()

    OmniboxTextView::SetText...)

    OmniboxResultView::Invalidate()

    OmniboxResultView::SetMatch(AutocompleteMatch const &)

    OmniboxPopupContentsView::UpdatePopupAppearance()

    OmniboxPopupModel::OnResultChanged()

    OmniboxEditModel::OnCurrentMatchChanged()

    OmniboxController::OnResultChanged(bool)

    AutocompleteController::UpdateResult(bool,bool)

    AutocompleteController::Start(AutocompleteInput const &)

    (...)

Ah ha! Autocomplete is not at fault. Time to optimize GetFallbackFonts()?! But wait… Why is GetFallbackFonts() even called in the first place?  
  
And before we figure that out, how do we know this is the #1 root cause of our overall long-tail performance issue? We’ve only looked at one trace so far after all...

The Measurement Conundrum
-------------------------

The metrics tell us how many users are affected and how bad it is, but they do not highlight the root cause.  
  
Slow Reports tell us what the problem is for a specific user but not how many users are affected. And while we can query our corpus of Slow Report traces, it comes with inherent biases that make it impossible to correlate 1:1 with metrics. For instance, because Chrome only reports the first instance of bad performance per-session and only for users of the Canary/Dev channel, there’s both a startup and a population bias.  
  
This is the measurement conundrum. The more actionability (data) a tool provides, the fewer scenarios it captures and the more bias it incurs. Depth vs. breadth.  
  
Tools that attempt to do both sit somewhere in the middle, where they use aggregation over a large dataset and risk showing aggregate results based on flawed input (e.g. circular buffer tracing having dropped the interesting portion and contributing to a biased aggregate).  
  
  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhJgG5FJ_GzIKmhTioVzKejDcx8y6ohL5lUoHr6LYV9k4LbdVmu4ZebMXleU1TSc2Ri8KQCAxzomAn1ZvHYsiQOB3yuJNNlZH_YZq4I1h4ITZO1Pn2DZIKqk08oTAAu_IGv__P6kPxyH9J_/w542-h334/image4.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhJgG5FJ_GzIKmhTioVzKejDcx8y6ohL5lUoHr6LYV9k4LbdVmu4ZebMXleU1TSc2Ri8KQCAxzomAn1ZvHYsiQOB3yuJNNlZH_YZq4I1h4ITZO1Pn2DZIKqk08oTAAu_IGv__P6kPxyH9J_/s1140/image4.png)

  
  
Thus we scientifically opted for the least engineering-minded option: open a bunch of Slow Report traces manually. This gave us the most actionability over a top-level issue we’d already quantified.  
  
After opening dozens of traces it turned out that a great majority showed variations of the aforementioned fonts issue. While this didn’t give us a precise #users-affected, it was enough for us to believe it was the main cause of user pain seen in the metrics.

Fallback Fonts
--------------

We dug into why GetFallbackFonts() had to be called in the first place. In the example above, the caller is trying to determine the size in pixels of a Unicode string rendered by a given font.  
  
If a substring within it is from a [Unicode Block](https://en.wikipedia.org/wiki/Unicode_block) that can’t be rendered by the given font, GetFallbackFont() is used to request the system recommended fallback font for it. If that fails, GetFallbackFonts() is invoked to try all the [linked fonts](https://docs.microsoft.com/en-us/globalization/input/font-technology) and determine the one that can best render it; that second fallback is much slower.  
  
GetFallbackFont() should never fail, but in practice it’s not that simple. The reliable way to do this on Windows is to query [DirectWrite](https://docs.microsoft.com/en-us/windows/win32/directwrite/introducing-directwrite); however, DirectWrite was added in Windows 7, when Chrome still supported Windows XP. Therefore the GetFallbackFont() logic was forced to stick to a less reliable [heuristic using Uniscribe+GDI](https://chromium.googlesource.com/chromium/src/+/22aed04422b04b2cf04f7b7d61392da4e9a2c85a/ui/gfx/font_fallback_win.cc#303) in order to work on both versions of the OS. Since things worked most of the time, no one noticed that this could have been cleaned up when Chrome later dropped support for Windows XP. With new tooling to investigate long-tail performance, this turned out to be the number one cause of jank (unnecessarily invoking GetFallbackFonts()).  
  
We [fixed](https://chromium-review.googlesource.com/c/chromium/src/+/1663504/) that, reducing the amount of calls to GetFallbackFonts() by 4x.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjoS0pmpqWu93gtMQh1cRD6OcC3F60XoaMDHxOjzg2DVQLrht0IPOwW-ump4C81YHswCaF_NiejtJZo8fCdZGmW3PgANB4m8R-Y9WVJDFjzbuyIB0FiRHYnMVK6bQlBg_K5tfrErbMHmhyb/w660-h258/image3.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjoS0pmpqWu93gtMQh1cRD6OcC3F60XoaMDHxOjzg2DVQLrht0IPOwW-ump4C81YHswCaF_NiejtJZo8fCdZGmW3PgANB4m8R-Y9WVJDFjzbuyIB0FiRHYnMVK6bQlBg_K5tfrErbMHmhyb/s1244/image3.png)

  
  
Still not zero though, and still seeing instances of the aforementioned AutoComplete issue in our Slow Reports. Keep digging. DirectWrite’s GetFallbackFont() failing was unexpected, but since Slow Reports are anonymized, no user-generated strings can be uploaded -- and therefore, finding which codepoints were problematic was tricky. We teamed up with our privacy experts to instrument Unicode Block and Script of text blocks going through [HarfBuzz](https://en.wikipedia.org/wiki/HarfBuzz) so that we could ensure no leakage of [Personally Identifiable Information](https://en.wikipedia.org/wiki/Personal_data).

The Emoji Saga
--------------

With this new recording enabled, the next wave of Slow Reports came back. The vast majority of reports indicated that font fallback was failing when DirectWrite was being asked to find a font for a codepoint (Unicode character) in [Miscellaneous Symbols and Pictographs](https://www.compart.com/en/unicode/block/U+1F300). We wrote a local script trying all codepoints in that Unicode Block and quickly found out which ones could be problematic: U+1F3FB - U+1F3FF are modifiers added in Unicode 8.0 and are meaningful only when paired with another codepoint. For instance, U+1F9D7 (🧗) when paired with U+1F3FF is 🧗🏿. No font can render U+1F3FF on its own, and font fallback would correctly error out after scanning all linked fonts when asked to find one. The bug was in the browser-side Unicode [segmentation](https://unicode.org/reports/tr29/) logic which incorrectly broke down these two [codepoints](https://en.wikipedia.org/wiki/Code_point) and asked DirectWrite to render them separately instead of keeping them as a single grapheme.  
  
But wait, doesn’t Chrome support modern Unicode..?! Indeed, it does, in Blink which renders the web content. But the browser-side logic was not updated to support modern emojis (with modifiers) because it didn’t use to draw emojis at all. It’s only when the browser UI (tab strip, bookmark bar, omnibox, etc.) was modernized to support Unicode circa 2018 that the legacy segmentation logic became an (invisible) problem.  
  
On top of that, the caching logic did not cache on error, so trying to render a modifier on its own caused a massive jank, every time, for users with a lot of fonts installed. Ironically, this cache had been added to amortize the cost of this misunderstood bottleneck when Unicode support was first added to browser UI. Diving deeper into the underlying implementation of our fonts logic, rather than stopping at the layer of the fonts APIs, not only fixed a major performance issue but also resulted in a correctness fix for other [emojis](https://emojipedia.org/emoji/). For instance, 🏳️‍🌈 is encoded as U+1F3F3( 🏳️) + U+1F308 (🌈); before the itemization fix, browser UI would incorrectly render this grapheme as 🏳️🌈.  
  
  
  

And the journey continues...
----------------------------

Our journey keeps going into various components of Chrome but it always follows the same basic playbook: assume ignorance and relentlessly investigate unforeseen, unreproducible, and unowned bugs. And while stack ranking issues is nigh impossible (see: measurement conundrum), fixing the top 5 findings from any given tool and zooming in on the long tail has always addressed the majority of the user pain in practice.  
  
Using this approach, we have reduced user-visible jank by a factor of 10X over the last 2.5 years and improved long-tail performance of many features caught in the cross-fire.   
  
  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEijclE3wC3-F5EWITLOOC4zFxE49mBpRu35jBlA0_nW9f4vl7RrEfg3FFMCTVqPYVnkOlR1cBxGdX_EHNbBsc3UnjdSMmZfKHBXA5FBcf2V3QHskME6o2_cZetVtVkRhlXcgSAK2smXGrff/w642-h347/image5.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEijclE3wC3-F5EWITLOOC4zFxE49mBpRu35jBlA0_nW9f4vl7RrEfg3FFMCTVqPYVnkOlR1cBxGdX_EHNbBsc3UnjdSMmZfKHBXA5FBcf2V3QHskME6o2_cZetVtVkRhlXcgSAK2smXGrff/s905/image5.png)

99th percentile of # of unresponsive 100ms intervals over a 30 seconds sample

Posted by Gabriel Charette 🤸🏼 and Etienne Bergeron 🕵🏻, Chrome Software Engineers  
  
  
  
*Data source for all statistics: [Real-world data](https://www.google.com/chrome/privacy/whitepaper.html#usagestats) anonymously aggregated from Chrome clients.*