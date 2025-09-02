URL:https://google.github.io/comprehensive-rust/unsafe-deep-dive\foundations\actions-might-not-be.html
---
minutes: 2
---

# ... but actions on them might not be

```rust
fn main() {
    let n: i64 = 12345;
    let safe = &n as *const _;
    println!("{safe:p}");
}
```

<details>

Modify the example to de-reference `safe` without an `unsafe` block.

</details>
