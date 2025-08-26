URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\selectElementAccessibilityInteractiveContentLegendChild.md
# Interactive element inside of a <legend> element

An interactive element which is not allowed in the content model of the `<legend>` element was found within a `<legend>` element. Interactive elements are not allowed children of a `<legend>` element when used within an `<optgroup>` element. These elements will not consistently be accessible to people navigating by keyboard or using assistive technology.
