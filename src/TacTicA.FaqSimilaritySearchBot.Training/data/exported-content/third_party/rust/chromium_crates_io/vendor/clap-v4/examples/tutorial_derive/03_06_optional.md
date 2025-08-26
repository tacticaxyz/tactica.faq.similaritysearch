URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\rust\chromium_crates_io\vendor\clap-v4\examples\tutorial_derive\03_06_optional.md
```console
$ 03_06_optional_derive --help
A simple to use, efficient, and full-featured Command Line Argument Parser

Usage: 03_06_optional_derive[EXE] [NAME]

Arguments:
  [NAME]  

Options:
  -h, --help     Print help
  -V, --version  Print version

$ 03_06_optional_derive
name: None

$ 03_06_optional_derive bob
name: Some("bob")

```
