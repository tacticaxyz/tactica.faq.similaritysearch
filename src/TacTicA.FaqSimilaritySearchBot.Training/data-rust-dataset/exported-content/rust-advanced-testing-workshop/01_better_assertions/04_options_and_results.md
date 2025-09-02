URL:https://rust-exercises.com/advanced-testing/01_better_assertions\04_options_and_results.html
# `Option` and `Result` matchers

`googletest` comes with a few special matchers for `Option` and `Result` that return good error messages
when something that should be `Some` or `Ok` is actually `None` or `Err`, and vice-versa.
