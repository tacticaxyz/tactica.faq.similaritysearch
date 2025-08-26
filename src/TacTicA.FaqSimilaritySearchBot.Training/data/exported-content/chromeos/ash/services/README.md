URL:https://source.chromium.org/chromium/chromium/src/+/main:chromeos\ash\services\README.md
This directory holds [services](/services) that are:
- ash-chrome running on Chrome OS specific.
- They run in their own utility processes, and cannot call ash code directly.
- Chrome can add a DEP on these services just for the sole purpose of launching them (until ash supports launching its own services).
