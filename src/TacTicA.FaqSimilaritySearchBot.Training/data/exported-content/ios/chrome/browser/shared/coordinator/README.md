URL:https://source.chromium.org/chromium/chromium/src/+/main:ios\chrome\browser\shared\coordinator\README.md
# Shared Coordinator folder

This folder only contains the code shared by the coordinators. It is here
mostly to ease the DEPS rules: the coordinator code can depend on all code
here.

Add code here only if it is likely to be shared by a significant number of
coordinators (for example the main coordinator class, the command
dispatcher...).

