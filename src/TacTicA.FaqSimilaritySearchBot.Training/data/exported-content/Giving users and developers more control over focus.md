URL:https://blog.chromium.org/2020/09/giving-users-and-developers-more.html
# Giving users and developers more control over focus
- **Published**: 2020-09-02T13:54:00.002-07:00
Chrome 86 introduces two new features that improve both the user and developer experience when it comes to working with focus.

  

The :focus-visible pseudo-class is a CSS selector that lets developers opt-in to the same heuristic the browser uses when it's deciding whether to show a default focus indicator. This makes styling focus more predictable.

  

The Quick Focus Highlight is a user preference that causes the currently focused element to display an indicator for two seconds. The Quick Focus Highlight will always display, even if a page has disabled focus styles using CSS. It will also cause all CSS focus styles to match regardless of the input device that is interacting with the page.

  

![An animation of the quick focus highlight showing how it temporarily highlights a link in a line of text and then fades out to not obscure the text content.](https://lh3.googleusercontent.com/wdnRyP2HviHI6UiFh-aCkVzNGzk0NWouNBV5ELT7nT8dXFi1jbnSGPFygFpgjZFU89SI7_rXrgsUrg6OoUMHUsedyduot403v1t1vkZuStYZ-yYroHCUFi0ZXfChKUiFSQUWslJE9w)

What is focus?
--------------

When a user interacts with an element the browser will often show an indicator to signal that the element has "focus". This is sometimes referred to as the "focus ring" because browsers typically put a solid or dashed ring around the focused element.

  

![A button with a default blue focus ring](https://lh3.googleusercontent.com/NbcOQJzyX1gevtpZwLJe7AOzX4ASBEgdbSQGAcIHrO7GwPN_Hv5jvMjeT62VPXjUZuE24BEJXL2khAKa3gOMCea7fZL-rrZUl1uDEkygXusj3As5LjkVpfOoBDFQ-SggZ6l7kUTLtA)

  

The focus ring signals to the user which element will receive keyboard events. If a user is tabbing through a form, the focus ring indicates which text field they can type into, or if they've focused a submit button they will know that pressing Enter or Spacebar will activate that button.

Problems with focus
-------------------

For users who rely on a keyboard or other assistive technology to access the page, the focus ring acts as their mouse pointer - it's how they know what they are interacting with.

  

Unfortunately, many websites hide the focus ring using CSS. Oftentimes they do this because the underlying behavior of focus can be difficult to understand, and styling focus can have surprising consequences.

  

For example, a custom dropdown menu should use the tabindex attribute to make itself keyboard operable. But adding a tabindex to an element causes all browsers to show a focus ring on that element if it is clicked with a mouse. If a developer is surprised to see the focus ring when they click the menu, they might use the following CSS to hide it:

```
.custom-dropdown-menu:focus {
  outline: none;
}
```

  

This "fixes" their issue, insofar as they no longer see the focus ring when they click the menu. However, they have unknowingly broken the experience for users relying on a keyboard to access the page. As mentioned earlier, for users who rely on a keyboard to access the page, the focus ring acts as their mouse pointer. Therefore, CSS that removes the focus ring (without providing an alternative) is akin to hiding the mouse pointer.

  

To improve on this situation, developers need a better way to style focus - one that matches their expectations of how focus should work, and doesn't run the risk of breaking the experience for users. At the same time, users need to have the final say in the experience and should be able to choose when and how they see focus. This is where :focus-visible and the Quick Focus Highlight come in.

:focus-visible
--------------

Whenever you click on an element, browsers use an internal heuristic to determine whether they should display a default focus indicator. This is why in Chrome tabbing to a <button> shows a focus ring, but clicking it with a mouse does not. 

  

When you use :focus to style an element, it tells the browser to ignore its heuristic and to always show your focus style. For some situations this can break the user's expectation and lead to a confusing experience.

  

:focus-visible, on the other hand, will invoke the same heuristic that the browser uses when it's deciding whether to show the default focus indicator. This allows focus styles to feel more intuitive. In Chrome 86 and beyond, this should be all you need to style focus:

  

```
/* Focusing the button with a keyboard will show a dashed black line. */
button:focus-visible {
  outline: 4px dashed black;
}
```

  

By combining :focus-visible with :focus you can take things a step further and provide different focus styles depending on the user's input device. This can be helpful if you want the focus indicator to depend  on the precision of the input device:

  

```
/* Focusing the button with a keyboard will show a dashed black line. */
button:focus-visible {
  outline: 4px dashed black;
}
  
/* Focusing the button with a mouse, touch, or stylus will show a subtle drop shadow. */
button:focus:not(:focus-visible) {
  outline: none;
  box-shadow: 1px 1px 5px rgba(1, 1, 0, .7);
}
```

See the Pen [:focus-visible example](https://codepen.io/robdodson/pen/gOrLjvX) by Rob Dodson
([@robdodson](https://codepen.io/robdodson)) on [CodePen](https://codepen.io).
  

The snippet above says that if the browser would normally show a focus indicator, then it should do so using a 4px dashed black outline. Additionally, the example relies on the existing :focus behavior and says that if an element has focus, but the browser would not normally show a default focus ring, then it should show a drop shadow. 

  

Since the browser doesn't usually show a default focus ring when a user clicks on  a button, the :focus:not(:focus-visible) pattern can be an easy way to specifically target mouse/touch focus.

  

Note that not all browsers set focus in the same way, so the above snippet will work in Chromium based browsers, but may not work in others.

### The :focus-visible heuristic

Understanding the browsers’ heuristics for focus indicators will help you understand when to use :focus-visible. Unfortunately, the heuristic has never been specified, so the behavior is subtly different in every browser. The [:focus-visible specification suggests one possible heuristic](https://www.w3.org/TR/selectors-4/#the-focus-visible-pseudo) based on the behavior browsers currently demonstrate. Here's a quick breakdown:

  

Has the user expressed a preference to always see a focus indicator?

If the user has indicated that they always want to see a focus indicator, then :focus-visible will always match on the focused element, just like :focus does.

  

Does the element require text input?

:focus-visible will always match when an element which requires text input (for example, <input type="text">) is focused.

  

A quick way to know if an element is likely to require text input is to ask yourself "If I were to tap on this element using a mobile device, would I expect to see a virtual keyboard?" If the answer is "yes" then the element will match :focus-visible.

  

What input device is being used?

If the user is using a keyboard to navigate the page, then :focus-visible will match on any interactive element (including any element with tabindex) which becomes focused. If they're using a mouse or touch screen, then it will only match if the focused element requires text input. 

  

Was focus moved programmatically?

If focus is moved programmatically by calling focus(), the newly focused element will only match :focus-visible if the previously focused element matched it as well. 

  

For example, if a user presses a physical key, and the event handler opens a menu and moves focus to the first menu item, :focus-visible will still match and the menu item will have a focus style.

  

Because mouse users may frequently use keyboard shortcuts, Chrome's implementation will bypass "keyboard mode" if a meta key (such as command, control, etc.) is pressed. For example, if a user who was previously using a mouse pressed a keyboard shortcut which shows a settings dialog, :focus-visible would not match on the focused element in the settings dialog.

### Support and polyfill

Currently, :focus-visible is only supported in Chrome 86 and other Chromium-based browsers, though there's [work underway to add support to Firefox](https://bugzilla.mozilla.org/show_bug.cgi?id=1445482). Refer to the [MDN browser compatibility table](https://developer.mozilla.org/en-US/docs/Web/CSS/:focus-visible#Browser_compatibility) to keep track of current support.

  

If you'd like to use :focus-visible today you can do so with the help of the [:focus-visible polyfill](https://github.com/WICG/focus-visible). Once the polyfill is loaded, you can use the .focus-visible class instead of :focus-visible to achieve similar results:

  

```
/* Define mouse/touch focus indicators. */
.js-focus-visible :focus:not(.focus-visible) {
  …
}
  
/* Define keyboard focus indicators. */
.js-focus-visible .focus-visible {
  …
}
```

  

Note that the MDN support table shows Firefox supports a similar selector known as :-moz-focusring which :focus-visible is based on; however the behavior between the two selectors is quite different and it's recommended to use the :focus-visible polyfill if you need cross-browser support.

  
See the Pen [:focus-visible polyfill example](https://codepen.io/robdodson/pen/abNJqpL) by Rob Dodson
([@robdodson](https://codepen.io/robdodson)) on [CodePen](https://codepen.io).

Quick Focus Highlight
---------------------

:focus-visible makes it easier for developers to selectively style focus and avoids pitfalls with the existing :focus selector. While this is a great addition to the developer toolbox, for a subset of users, particularly those with cognitive impairments, it can be helpful to always see a focus indicator, and they may find it distressing when the focus indicator appears less often due to selective styling with :focus-visible.

  

For these users, Chrome 86 adds a setting called Quick Focus Highlight.

  

Quick Focus Highlight temporarily highlights the currently focused element, and causes :focus-visible to always match.

  

To enable Quick Focus Highlight:

  

1. Go to Chrome's settings menu (or type chrome://settings into the address bar).
2. Click Advanced then Accessibility.
3. Enable the toggle switch to Show a quick highlight on the focused object.

  

Once Quick Focus Highlight is enabled, focused elements will show a white-blue outline with a blue glow. (See the image below.). The Highlight uses these alternating colors to ensure that it has proper contrast on any background.

  

![The quick focus highlight on a white, black, and blue background. The rings are visible in all scenarios.](https://lh6.googleusercontent.com/gGOqGbFs4CD-Mib6Vj1sP0yAUVbqIODEm_yroKv4dyxAk-N583DkQ1p9L89Ct_YLw2x6SpM2tBlfN7idW-QP56yPkm5A_DAoTK9yNTw91EtM6dmFIJ6JZyeUeJUKdlPVcDe0VtwClQ)

  

The Highlight is outset from the focused element to avoid interfering with that element's existing focus styles or drop shadows. The Highlight will fade out after two seconds to avoid obscuring page content, such as text.

  

FAQ
---

### User-input can be multi-modal, for example some 2-in-1 laptops support mouse, keyboard, touch, and stylus. How does :focus-visible work with these devices?

Because :focus-visible uses the same heuristic as a default focus indicator, the experience should match what users expect on these platforms when they interact with unstyled HTML elements.

  

In other words, if developers use :focus-visible as their primary means to style focus, then the experience should be more consistent for all users regardless of their input device.

### Does :focus-visible expose sensitive information?

Most of the time, :focus-visible matching only indicates that a user is using the keyboard, or has focused an element which takes text input.

  

:focus-visible could potentially be used to detect that a user has enabled a preference to always show a focus indicator, by tracking mouse and keyboard events and checking matches(":focus-visible") on elements which were focused when the keyboard is not being used. Since the precise details of when :focus-visible should match are left up to the browser's implementation, this would not be a completely reliable method.

### What's the impact on users with low vision or cognitive impairments?

:focus-visible and the Quick Focus Highlight were designed to work together to help these users.

  

:focus-visible aims to address the common anti-pattern of developers removing the focus indicator from all of their controls. Using the browser's focus heuristic helps by creating fewer surprises for developers when the focus ring appears, meaning fewer reasons to use CSS to hide the ring.

  

For some users the browser's default behavior may still be insufficient. They may want to see a focus ring regardless of the type of control they're interacting with, or the input device they're using. That's where the Quick Focus Highlight can help.

  

The Quick Focus Highlight lets users increase the visibility of the focus indicator, and makes it so :focus-visible always matches, regardless of their input device. This combination of effects should make the currently focused element much easier to identify.

  

### Why not have an "alway on" focus indicator?

The Quick Focus Highlight does not currently support an "always on" mode because it's difficult to design a universal focus overlay that does not obscure page content. As a result, the Highlight will fade out after two seconds, and rely on either the browser's default focus indicator, or the page author's :focus and :focus-visible styles.

  

Because the Highlight is a user preference its behavior can be changed in the future if users would prefer that it always stay on.

### Should we also add :focus-visible-within?

There has been discussion around adding :focus-visible-within, but a proposal will require additional use cases. If you feel like you have a good use case for :focus-visible-within [please add it to the discussion issue](https://github.com/WICG/focus-visible/issues/151).

  

We welcome your feedback!
-------------------------

:focus-visible and the Quick Focus Highlight are the product of years of work and feedback from developers in the [:focus-visible WICG repo](https://github.com/WICG/focus-visible) and the standards bodies. We'd like to say thank you to everyone who helped shape these features.

  

Give :focus-visible and the new Highlight a shot, and tell us what you think.

If you've found an issue with the Quick Focus Highlight, attach a screenshot and send it to [our support tracker](https://support.google.com/chrome/answer/95315?co=GENIE.Platform%3DDesktop&hl=en).

If you've found an issue with :focus-visible, use this template to [file a chromium bug](https://bugs.chromium.org/p/chromium/issues/entry?template=Defect+report+from+user&summary=focus-visible&components=Blink%3ECSS).