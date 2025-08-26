URL:https://source.chromium.org/chromium/chromium/src/+/main:docs\website\site\chromium-os\build\bypassing-tests-on-a-per-project-basis\index.md
---
breadcrumbs:
- - /chromium-os
  - Chromium OS
- - /chromium-os/build
  - Chromium OS Build
page_name: bypassing-tests-on-a-per-project-basis
title: Per-repo and per-directory configuration of CQ and pre-CQ
---

Different chromeos repositories have different testing needs. Using per-repo or
per-directory configuration, it is possible to tailor the behavior of the
[Chromeos Commit Queue](/developers/tree-sheriffs/sheriff-details-chromium-os/commit-queue-overview)
to suit the particular change being tested.

This documentation needs updating for the new Parallel CQ infrastructure. The
older COMMIT-QUEUE.ini files are no longer read by anything. Contact
chromeos-continuous-integration-team (crbug components ChromeOS&gt;Infra&gt;CI)
with any questions.
