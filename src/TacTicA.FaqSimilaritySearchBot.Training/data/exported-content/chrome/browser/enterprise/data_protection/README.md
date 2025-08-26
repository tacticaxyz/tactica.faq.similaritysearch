URL:https://source.chromium.org/chromium/chromium/src/+/main:chrome\browser\enterprise\data_protection\README.md
This directory contains classes and utility functions that use code from
different data protection features and provide abstractions to other
`chrome/` code. If your code only interacts with one data protection feature,
do not use this directory and instead use
`chrome/browser/enterprise/connectors/`, `chrome/browser/enterprise/data_controls/`, etc.
