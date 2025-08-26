URL:https://blog.chromium.org/2023/08/smoothing-out-scrolling-experience-in.html
# Smoothing out the scrolling experience in Chrome on Android
- **Published**: 2023-08-08T09:56:00.015-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhpoMaNCAyCY0wVpANeUERPRp6miTiafH8k4S4AagpE-y8noUhB-GdcmfAlpDxwZBdzjEXQOBAdPiuBAwNbUmVDTj9B9EMQ6Ty_8UI1zv1BpEgdM2BT8JX-Im1KGOE4QgtP9wVV-muo5aPVDWNzpd3RZjoecWQ_VA0Ty3WsEDbFChvDdkhBa-_JJmGpJrco/w400-h166/Fast%20Curious_image.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhpoMaNCAyCY0wVpANeUERPRp6miTiafH8k4S4AagpE-y8noUhB-GdcmfAlpDxwZBdzjEXQOBAdPiuBAwNbUmVDTj9B9EMQ6Ty_8UI1zv1BpEgdM2BT8JX-Im1KGOE4QgtP9wVV-muo5aPVDWNzpd3RZjoecWQ_VA0Ty3WsEDbFChvDdkhBa-_JJmGpJrco/s400/Fast%20Curious_image.png)

  
  

Big performance wins can be found by taking a step back and tweaking what you already have. Today’s [The Fast and the Curious](https://blog.chromium.org/search/label/the%20fast%20and%20the%20curious) post explores how we improved the scrolling experience of Chrome on Android, ultimately reducing slow scrolling jank by 2x. Read on to see how we discovered and evaluated the problem, and how that has helped us design a better browser experience going forward.

  

When measuring the performance of a browser, one might typically think of page load speed or [Web Vitals](https://web.dev/vitals/). On mobile where touch interactions are common we also prioritize your interaction with Chrome to ensure it is always smooth and responsive including on new form factors like foldables. A significant focus of late has been on reducing jank while you scroll.

  

We recently improved the scrolling experience of Chrome on Android by 2x by filtering noise and reducing visual jumps in the content presented on screen. To get this result, we had to take a step back and figure out the problem of why Chrome on Android was lagging behind Chrome on iOS. 

  

As we compared Chrome across platforms, we were hit with a particular observation. iOS Chrome scrolling was smooth and consistent whereas on Android, Chrome’s scrolling didn't follow your finger as closely. However, our metrics were telling us that while janks occurred occasionally, they weren’t as common as our perception when comparing with Chrome on iOS. Thus we had ourselves a mystery which needed some investigation.

  

Investigating input to output rate
==================================

Our metrics flagged that we often received input at an inconsistent rate; but since the input rate was greater than the display’s frame rate, we usually had at least one input event to trigger the production of a frame to display. However, this frame might have consumed fewer or more input events, which could result in inconsistent shifting of content on screen even while scrolling at a fixed speed.

  

This problem of different input rate vs frame rate is a problem that Chrome has had to address before. Internally, we resample input to predict/extrapolate where the finger was at a consistent point relative to the frame we want to produce. This should result in each frame representing a consistent amount of time and should mean smooth scrolling regardless of noise in the input events. The ideal scenario is illustrated in the following diagram where blue dots are real input events, green are resampled input events, and the displayed scroll deltas would fluctuate if you were to use the real input events rather than resampling.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEioehuGvCdB4KM2GHsyak1760cuz8pnEtpNFCF4UMVGg-BOpO0gvzJ6e7zwnBFymB1b5pfgsPTRXyMGZFYw9YDCItmyX5cW_ZyoQqc6O7a-gOT1LgbKh-nGYnPdUh7i4xaUmUv8mgVPQj63erls0RVE2qa-BygRtPx-jJuVuIBrTdfYPve8wnxGWqvdrPNY/s16000/input_sampling_rate.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEioehuGvCdB4KM2GHsyak1760cuz8pnEtpNFCF4UMVGg-BOpO0gvzJ6e7zwnBFymB1b5pfgsPTRXyMGZFYw9YDCItmyX5cW_ZyoQqc6O7a-gOT1LgbKh-nGYnPdUh7i4xaUmUv8mgVPQj63erls0RVE2qa-BygRtPx-jJuVuIBrTdfYPve8wnxGWqvdrPNY/s871/input_sampling_rate.png)

  

Okay so we already do resampling so what's the problem?

  

A tale of woe and reimplementation
==================================

Input resampling inside of Chrome (and Android) were added back in 2019 as 90hz devices emerged and the problem above became more apparent (oscillating between 2 vs 1 input events per frame rather than consistently 2 input events per frame we usually see on 60hz devices). Android implemented multiple resampling algorithms (kalman, linear, etc.) and arrived at the conclusion that linear resampling (drawing a line between two points to figure out velocity and then extrapolate to the given timestamp) was good enough for their use cases. This fixed the problem for most Android apps, but didn't address Chrome.

  

Due to historical reasons and web spec requirements for raw input, Chrome uses unbuffered input and thus as devices started to appear with sampling rates that didn’t fit with input, Chrome had to implement some version of resampling. Below we see that each frame (measuring the time from input to it being displayed) consumes a different amount of input events (2 for the first, 3 for the second, and 1 for the third), if we assume input is consistently arriving and each is exactly 30 pixels of displacement then ideally we should smooth it out to 60 pixels per frame as seen below:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg9UMsfJShkzjJlqDxDl0Fr7pFOI0zIWkhD49X-DT8m-Uca8PB6JhA5TiR6Wz_SuAzaANgo9X9D4gHCTbm8UdXtwcLLmnVmLsBRZwI6yezCEie6bD-kW4_nGBi277ZFoVqeF3Orzj7Ks_--vpAj4RqtTxon_EAhBIaOk-nXIkyH_4NP4AeXuF_W-lO-a2-N/s16000/frame_predictor_timeline.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg9UMsfJShkzjJlqDxDl0Fr7pFOI0zIWkhD49X-DT8m-Uca8PB6JhA5TiR6Wz_SuAzaANgo9X9D4gHCTbm8UdXtwcLLmnVmLsBRZwI6yezCEie6bD-kW4_nGBi277ZFoVqeF3Orzj7Ks_--vpAj4RqtTxon_EAhBIaOk-nXIkyH_4NP4AeXuF_W-lO-a2-N/s659/frame_predictor_timeline.png)

  

However, while we were investigating the original mystery we discovered that reality was very different from the ideal situation pictured above. We found that the actual input movement of the screen was quite spiky and inconsistent (more than we expected) and that our predictor was improving things but not as much as desired. On the left is real finger displacement on a screen (each point is an input event) and on the right the result of our predictor of actual content offset after smoothing out (each point is a frame)

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg3sPk_SBDZbule8elIeQmsz5HIGd21jo6gDBwDKu_YlVp4xR2AUnEqhIM8Mr4zU4jVPTR114kX134l6i2szyuX9fFwMeMincKw7uLiicXeuCankKQjsT8TWx7Wwb0m7O5zHz6RTKqSQ4PrfkGGFtSoxX4Y-jtSuzG3kSefQQ2VZpFddopNE-VoeTgs_1uw/s16000/Screenshot%202023-08-07%20at%2010.22.51%20PM.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg3sPk_SBDZbule8elIeQmsz5HIGd21jo6gDBwDKu_YlVp4xR2AUnEqhIM8Mr4zU4jVPTR114kX134l6i2szyuX9fFwMeMincKw7uLiicXeuCankKQjsT8TWx7Wwb0m7O5zHz6RTKqSQ4PrfkGGFtSoxX4Y-jtSuzG3kSefQQ2VZpFddopNE-VoeTgs_1uw/s1528/Screenshot%202023-08-07%20at%2010.22.51%20PM.png)

  

Frames are being presented consistently on the right, but the rate of displacement spikes between one to another isn’t consistent (-50 to -40 followed by another -52 being especially drastic). Human fingers don’t move this discretely (at frame level precision). Rather they should slide and flex in a gradient, speeding up or slowing down gradually. So we knew we had a problem here. We dug deeper into Chrome’s implementation and found there were some fundamental differences in Chrome’s implementation (which was supposedly a copy of Android’s).

> 1. Android uses the native C++ MotionEvent timestamp (with nanosecond precision), but Chrome uses Java [MotionEvent.getEventTime](https://developer.android.com/reference/android/view/MotionEvent#getEventTime()) & [MotionEvent.getHistoricalEventTime](https://developer.android.com/reference/android/view/MotionEvent#getHistoricalEventTime(int)) (milliseconds precision). Unfortunately, nanosecond precision was not part of the public API. However, rounding of milliseconds can introduce error into our predictor when it  computes velocity between event timestamps.
>
> 2. Android’s implementation takes care when selecting the two input events so resampling is using the most relevant events. Chrome however uses a simple FIFO queue of input events, which can result in weird cases of using future events to predict velocity in the past in rare cases on high refresh rate devices.

We prototyped using Android’s resampling in Chrome, but found it was still not perfect for Chrome’s architecture resulting in some jank. To improve on it, we experimented with different algorithms, using automation to replay the same input over and over again and evaluating the screen displacement curves. After tuning, this landed at the [1€ filter](https://gery.casiez.net/1euro/) implementation that visibly and drastically improved the scrolling experience. With this filter, the screen tracks closely to your finger and websites smoothly scroll, preventing jank caused by inconsistent input events. The improvement is visible in our manual validation, on both top-end and low-end devices ([Here's a redmi 9A video example](https://drive.google.com/file/d/1KqcWNybFP7kCqBz4mx0vlVzQOqU3IJyb/view?usp=sharing)).

  

Going forward!
==============

In Android 14, the [nanosecond](https://developer.android.com/reference/android/view/MotionEvent#getEventTimeNanos()) [API](https://developer.android.com/reference/android/view/MotionEvent#getHistoricalEventTimeNanos(int)) for java MotionEvents will be publicly exposed in the SDK so Chrome (and other apps with unbuffered input) will be able to call it. We also developed new metrics that track the quality of the scroll predictors frame, by creating a test app which introduced pixel level differences between frames (and no other form of jank) and running experiments to see what people would notice. These analysis can be read about [here](https://docs.google.com/document/d/1Y0u0Tq5eUZff75nYUzQVw6JxmbZAW9m64pJidmnGWsY/edit) and will be used going forward for more exciting performance wins and to make this a visible area for tracking against regressions. In the end, after tuning and enabling the [1€ filter](https://gery.casiez.net/1euro/), our metrics show a 2x reduction in visible jank while scrolling slowly! This improvement is going live in [M116](https://chromium-review.googlesource.com/c/chromium/src/+/4518271) as the default, but will be launched all the way back to M110 and brings Chrome on Android on par with Chrome on iOS!

  

The moral of the story is: Sometimes metrics don’t cover all the cases and taking a step back and investigating from the top down and getting the lay of the land can end with a superior scrolling experience for users.

  

Post by: Stephen Nusko, Chrome Software Engineer