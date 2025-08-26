URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\devtools-frontend\src\front_end\models\issues_manager\descriptions\SameSiteWarnCrossDowngradeSet.md
# Migrate entirely to HTTPS to continue allowing cookies to be set by same-site subresources

A cookie is being set by {PLACEHOLDER_origin} origin in {PLACEHOLDER_destination} context.
Because this cookie is being set across schemes on the same site, it will be blocked in a future version of Chrome.
This behavior enhances the `SameSite` attribute’s protection of user data from request forgery by network attackers.

Resolve this issue by migrating your site (as defined by the eTLD+1) entirely to HTTPS.
It is also recommended to mark the cookie with the `Secure` attribute if that is not already the case.
