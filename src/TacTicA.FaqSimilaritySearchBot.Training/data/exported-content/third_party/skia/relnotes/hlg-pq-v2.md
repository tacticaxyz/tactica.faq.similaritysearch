URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\skia\relnotes\hlg-pq-v2.md
Change `SkNamedTransferFn::kHLG` and `SkNamedTransferFn::kPQ` to use the
new skcms representations.

This will have the side-effect of changing `SkColorSpace::MakeCICP` to
use the new representations.
