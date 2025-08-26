URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\sqlite\src\ext\repair\test\README.md
To run these tests, first build sqlite3_checker:


>     make sqlite3_checker


Then run the "test.tcl" script using:


>     ./sqlite3_checker --test $path/test.tcl


Optionally add the full pathnames of individual *.test modules
