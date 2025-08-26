URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\selectElementAccessibilityNonPhrasingContentOptionChild.md
# Non-phrasing content used within an <option> element

The `<option>` element allows only non-interactive phrasing content, text, and `<div>` elements as its children. The semantics of non-phrasing content elements do not make sense as children of an `<option>`, and such semantics will largely be ignored by assistive technology since they are inappropriate in this context. Consider removing or changing such elements to one of the allowed phrasing content elements.
