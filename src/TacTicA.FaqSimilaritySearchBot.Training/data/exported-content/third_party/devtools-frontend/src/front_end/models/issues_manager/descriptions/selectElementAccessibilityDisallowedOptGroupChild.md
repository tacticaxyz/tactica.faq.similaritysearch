URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\selectElementAccessibilityDisallowedOptGroupChild.md
# Invalid element or text node within <optgroup>

An element which is not allowed in the content model of the `<optgroup>` element was found within an `<optgroup>` element. These elements will not consistently be accessible to people navigating by keyboard or using assistive technology.

If using disallowed elements for layout structure and styling, consider using the allowed `<div>` element instead.

Any text existing within the `<optgroup>` element should either be removed or relocated to a valid element that allows text descendants, e.g., the `<legend>` or `<option>` elements.
