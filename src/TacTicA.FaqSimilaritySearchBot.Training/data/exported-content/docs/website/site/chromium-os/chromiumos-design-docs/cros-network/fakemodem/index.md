URL:https://source.chromium.org/chromium/chromium/src/+/main:docs\website\site\chromium-os\chromiumos-design-docs\cros-network\fakemodem\index.md
---
breadcrumbs:
- - /chromium-os
  - Chromium OS
- - /chromium-os/chromiumos-design-docs
  - Design Documents
- - /chromium-os/chromiumos-design-docs/cros-network
  - 'CrOS network: notes on ChromiumOS networking'
page_name: fakemodem
title: fakemodem (for testing celluar modems with AT command interfaces)
---

*   Gives pre-programmed answers to AT commands. (Regexp patterns match
            the command, and probably can be used in generating the response.)
*   Implemented in
            [fakemodem.c](http://code.google.com/searchframe#wZuuyuB8jKQ/src/third_party/autotest/files/client/deps/fakemodem/src/fakemodem.c).
*   Used by [modemmanager SMS
            autotest](http://code.google.com/searchframe#wZuuyuB8jKQ/src/third_party/autotest/files/client/site_tests/network_ModemManagerSMS/network_ModemManagerSMS.py).
*   Example regexp tables: [Icera SMS signal test
            patterns](http://code.google.com/searchframe#wZuuyuB8jKQ/src/third_party/autotest/files/client/site_tests/network_ModemManagerSMSSignal/src/fake-icera),
            [generic GSM SMS Signal test
            patterns](http://code.google.com/searchframe#wZuuyuB8jKQ/src/third_party/autotest/files/client/site_tests/network_ModemManagerSMSSignal/src/fake-gsm).
