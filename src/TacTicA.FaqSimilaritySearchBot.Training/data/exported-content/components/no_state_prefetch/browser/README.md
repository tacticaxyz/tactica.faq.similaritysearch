URL:https://source.chromium.org/chromium/chromium/src/+/main:components\no_state_prefetch\browser\README.md
This directory contains NoStatePrefetch implementation.

Currently NoStatePrefetch can be triggered by `<link rel="prerender">` and
Speculation Rules with `prefetch_with_subresources`. These features call
`StartPrefetchingFromLinkRelPrerender()` and `AddSameOriginSpeculation()` on
`NoStatePrefetchManager` respectively to start prefetching.
