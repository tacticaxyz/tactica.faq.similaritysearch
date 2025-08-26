URL:https://blog.chromium.org/2020/03/updates-to-form-controls-and-focus.html
# Updates to Form Controls and Focus
- **Published**: 2020-03-30T13:06:00.000-07:00
HTML form controls provide the backbone for much of the web's interactivity. They're easy for developers to use, have built-in accessibility, and are familiar to our users.
One issue with native form controls, however, is the inconsistency in their styling. Older controls, such as <button> and <select> were styled to match the user's operating system. Form controls that were added to the platform more recently were designed to match whatever style was popular at the time. For Chromium based browsers, this has led to controls that look mismatched and sometimes outdated, which causes developers to spend extra time (and ship extra code) styling around the controls' default appearance.

  

![a meter, progress, and input type range element stacked vertically. Their visual styles are very different.](https://lh5.googleusercontent.com/WEnFtKMTBqxJWbRuhExzHKm8C7u280aSQbMtdV1e2nm4KaSPtTaekWjMerDrNHP4JsWl-onxcMSIv00zhL3UuOK5_W_OI3xkfA0SXUnhewIMZkzMjPOAOXvLEkyrUtAdnUK-kA98)

<meter>, <progress>, and <input type="range"> look like they come from different worlds in Chrome 80 on Windows.


  

To help fix this problem, the teams at Microsoft Edge and Google Chrome spent the last year collaborating to retheme and improve the functionality of the built-in form controls on Chromium browsers. The two teams also worked to make the focused states of form controls and other interactive elements like links easier to perceive.
These changes are available today in Edge on Windows, and may be seen in Chrome 81 as part of experiments. The chrome://flags/#form-controls-refresh enables the changes in Chrome 81 as well. The changes will roll out in Chrome 83 on Windows, macOS, ChromeOS, and Linux. See the updated [release schedule](https://chromereleases.googleblog.com/2020/03/chrome-and-chrome-os-release-updates.html) for Chrome 81 and 83. Updates for Chrome on Android should roll out later this year.
If you want to hear more about what's coming to form controls, take a look at Nicole Sullivan and Greg Whitworth's [talk from CDS 2019](https://www.youtube.com/watch?v=ZFvPLrKZywA).

A Fresh Coat of Paint
---------------------

The two teams wanted to make the controls feel like they were part of a matched set. This meant doing away with gradients and using more of a flat design inspired by current design systems.

As [Nicole Sullivan](https://twitter.com/stubbornella), a member of the Chrome team, describes it:

We were going for beautiful, webby, and neutral. We hope that every design system would see a bit of themselves in the new designs and easily imagine how they might be adapted for their own branding.

Below is a comparison of the form controls as they previously appeared in Chromium and as they appear after the redesign:

![Form controls as they appear in Chrome 80](https://lh4.googleusercontent.com/K1ewrpkir2YdVnGWOSoGGUo5NRxGTebct7g3-u76DvE9X04upPt_1GP8sk3bKLotvsh7FNbtS1pMggL5QKO7MAsKZNApEnLfRImUDQSwH5PWpE7ZKaouT5QZ2vcm0Wu4PHa2ctIz)![Form controls as they appear after the redesign. The styles are much more consistent.](https://lh4.googleusercontent.com/MMAEaD5FMS4LvknauCIfOuI0SmyNkG4zSQzAqaGNA2nEp3nsPwuqu_bfcWUk8apF7COmdmVMJtfJOYSEkn1_B-mH_NC8XCnCM1CX5Id7genfZ3yTR2-Shhyif3c3osfTOERiaZtj)

Left: Prior styling of form controls in Chrome 80.

Right: Controls as they appear after the redesign.

Improved Accessibility and Touch Support
----------------------------------------

In addition to improving the default styling, the two teams also tuned up form controls' accessibility and enhanced touch support.

  

These changes are most notable in a few key areas:

### A More Visible Focus Ring

The focus indicator—sometimes referred to as the "focus ring"—is an important accessibility feature that helps people using a keyboard or switch device to identify which element they're interacting with.

  

Previously, Chromium used a light single color outline to indicate the focused element. However, if the focused element happened to be on a similarly colored background, the ring would be difficult to perceive:

  

![A button on a blue background. The focus indictor on the button is not discernible.](https://lh3.googleusercontent.com/8nPKaOlM6CINrWAmHoI2ZHol17ibkzMPotaKKpHudWL93voHtnwz96DVHjBQ5YmctQXHJ7OhOr-38XZnYiUroJ0pd3IXsEmUEencZU90hJvWvqxptyxyxOHUm70mE6raRPrSbIv_)

The previous focus ring on a similarly colored background.

  

The new focus indicator uses a thick dark ring with a thin white outline, which should improve visibility on both light and dark backgrounds. This is an easy accessibility win that automatically improves the keyboarding experience on a number of sites without developers needing to write any new code.

  

![Black and white double-strokes make the focus ring visible on both light background and dark background](https://lh5.googleusercontent.com/ML05Xzo-iWaJz3ZWz0gO7zCNvJbp8Oueedy04RxWlxKP0FTNFEU8TfEpHC2zDA24khEYRYQQ__E3NlGxsjJuvA7Q-Wd80BwJbSiFYZplk7KjlODF6Fpg1A_YUiFnPqj-qtxMEKNX "Updated HTML focus ring")

The new two-line design for the focus indicator ensures that it's visible on both black and white backgrounds.

  

Note that there are still some scenarios where the focus ring may be hard to perceive—for example, if a black button is on a white background, or if the focus ring is clipped by elements that are positioned closely together.

  

If you run into a scenario where the focus ring is hard to perceive, or if the new focus indicator does not match the design of your site, there are ways to [style focus](https://web.dev/style-focus) including the new [:focus-visible pseudo-class](https://web.dev/style-focus/#use-:focus-visible-to-selectively-show-a-focus-indicator), which provides fine-grained control over when the focus indicator is displayed.

### Increased Tap Target Sizes for Multi-input Displays

Over the past few years we've seen an increase in multi-input devices like 2-in-1 devices, tablets, and touch-enabled laptops. This means that touch becomes an important consideration for desktop. However, many of the existing form controls were not designed with multi-input surfaces in mind. For example, <input type="date"> works great on mobile, but the tap targets are much too small to be usable on a touch-screen laptop.

  

![The input type date  element as it appears in Chrome 80. The element has very small buttons for incrementing and decrementing the date.](https://lh6.googleusercontent.com/CyewsCGzmOacNyPcrfDufFDSBj7LQflKlIj3yzzaWdwhBd24_i7N-vE-NUI_dKYMBcdMCzE3_dTx4vl-v5QQ9BTyKUUlramLpXYC8-YCYgI7Q519HDZr394acj8716AJV24dsRUm)

The previous design for <input type="date"> with small tap targets.

  

To improve functionality on touch screens, the updated controls will now have better flyouts, larger tap targets, and support for swiping and inertia when scrolling:

  

![The redesigned input type date element. It has large buttons and easy to click dates.](https://lh4.googleusercontent.com/G9m2tl2lONCSSYJKlrFQYXdy5dtRG1FHQD3hqn1r-uvoejLYb3ZoU7N8Z4ieoJAPDOrVJ1V0Z9Cpy4eFvMMfiha8oGa0KsuQThwmyvXya_c14Dsx4yjnV_vGRhagyJsTV7_xw1Cq)

The new design for <input type="date"> with much more accessible tap targets

### 

### Improved Color Picker

Previously the <input type="color"> element was not fully keyboard accessible, meaning users relying on a keyboard or switch device couldn't use it. Along with a new appearance, the control is also now fully keyboard accessible and includes additional modifier keys (Control, or Command on Mac). These improvements let users jump by ten color values at a time.

  

![An animation of the redesigned color picker, showing improved keyboard navigation](https://lh4.googleusercontent.com/rgbDqJC74QUF50BN2yCeSz_-vJlXBbhM7F736VKH37zSseCPQaWuOGg1qGhSl8rrbp2FEh2HeXvQoSDTojFvjj4rhwFQalEm0ogmxd0fFe_oTdVrYYnI6eUNXmG1CrKjS2Rc28Bu)

The new <input type="color"> with improved keyboard accessibility.

  

### 

### More Consistent Keyboard Access

Finally, the teams updated the ARIA role mapping of all the controls to match the recommendations in the [HTML Accessibility API Mappings specification](https://www.w3.org/TR/html-aam-1.0/). This should provide a more consistent experience for anyone relying on a keyboard or assistive technology, like a screen reader, to access the page.

How You Can Get Involved
------------------------

While the design refresh is a much needed change, the two teams have also heard from developers that it should be easier to style the built-in form controls and plan to tackle that work next. If you're excited by the idea of improved styling, functionality, and possibly even new high-level components, the folks at Edge and Chrome need your help!

### Test Your Sites

Try out the new form controls and focus indicator in [Edge](https://www.microsoft.com/en-us/edge) and [Chrome Beta](https://www.google.com/chrome/beta/). If the design changes have negatively affected your existing sites or apps, let us know using [this bug template](https://bugs.chromium.org/p/chromium/issues/entry?components=Blink%3EForms&labels=FormControlsRefresh,pri-2,type-bug). Or, if you find a related bug, give it a star! ⭐️ Starring is extremely valuable because it helps platform teams triage and decide what to work on next.

### Tell us What You Want to See

Much of the work on the new form controls was enabled through surveying developers, and interviewing design system and UI framework authors.

  

In an effort to help centralize this feedback and include as many developers as possible in the standards process, the team at Edge have created [open-ui.org](https://open-ui.org/). If you work on a design system, or a UI component set, consider sharing your knowledge on Open UI to help classify and identify gaps in the existing form controls.

Posted by Rob Dodson, Developer Advocate