URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\rust\chromium_crates_io\vendor\clap-v4\examples\tutorial_builder\03_03_positional.md
```console
$ 03_03_positional --help
A simple to use, efficient, and full-featured Command Line Argument Parser

Usage: 03_03_positional[EXE] [name]

Arguments:
  [name]  

Options:
  -h, --help     Print help
  -V, --version  Print version

$ 03_03_positional
name: None

$ 03_03_positional bob
name: Some("bob")

```
