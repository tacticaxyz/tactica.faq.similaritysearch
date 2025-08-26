URL: https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub
# Safer Usage Of C++

Updated automatically every 5 minutes

Safer Usage Of C++

This document is PUBLIC. Chromium committers can comment on [the original doc](https://www.google.com/url?q=https://docs.google.com/document/d/1eVKfIsPsEVDsBS24ErmuyjNy-9zSBzHgp4Sk6fs6OOI/edit%23\&sa=D\&source=editors\&ust=1756042270367645\&usg=AOvVaw1Axwr5etHZcl_vOJQzJNST). If you want to comment but can’t, ping palmer\@. Thanks for reading!

Google-internal short link: go/safer-cpp

Authors/Editors: adetaylor, palmer

Contributors: ajgo, danakj, davidben, dcheng, dmitrig, enh, jannh, jdoerrie, joenotcharles, kcc, markbrand, mmoroz, mpdenton, pkasting, rsesek, tsepez, awhalley, you!

Last updated: 2021-09-22

Status: Draft-o-rama | Review Frenzy | Gettin’ There | Donetacular


# Introduction

Chrome Security [has been asked to consider](https://www.google.com/url?q=https://docs.google.com/document/d/1JWGI-fkEsdRPpwPtS6x3siNtHX8cWoZeiWD6_y781ag/edit\&sa=D\&source=editors\&ust=1756042270369070\&usg=AOvVaw0qmoZqHzPJq5rqFVpD0eh2) \[Google-internal only, sorry] what it would take to make C++ less dangerous. This document outlines various mechanisms we could use to make it significantly easier to use C++ safely. Some are radical, and adopting them (especially adopting many of them) may result in code that looks quite different from what C++ programmers expect.

Most of the proposed mechanisms are new usage patterns, libraries, and classes, but some call for the use of compiler-specific flags that change the language somewhat. (For example, Chromium already uses -fno-exceptions, and here we propose -ftrapv, -fwrapv, or fsanitize=signed-integer-overflow.)

Some of these mechanisms are already being built in Chromium, with varying degrees of success. (Examples: The UAF-resistant smart pointer [MiraclePtr](https://www.google.com/url?q=http://go/miracleptr\&sa=D\&source=editors\&ust=1756042270370421\&usg=AOvVaw3S9e1PEm6k4sJGIMsFfj4J) is in performance trials, we have expanded the use of Oilpan to PDFium, and the hardening of //base, WTF, and Abseil is substantial and has proven effective.)

Other mechanisms we propose represent significant new directions for C++ and Chromium, and may even require new research and development into open problem areas (e.g. new forms of static analysis).

The C++ language and culture tend to trade off safety in favor of efficiency, and therefore many of these proposed changes are complex, controversial, and not as robust as similar changes might be in another language. Additionally, they might sometimes have micro- or even macro-efficiency effects (time, space, or object code size).


## Prior Work

Safer C++ is a dream that many people share.

There is [the C++ Core Guidelines project](https://www.google.com/url?q=https://isocpp.github.io/CppCoreGuidelines/CppCoreGuidelines\&sa=D\&source=editors\&ust=1756042270372055\&usg=AOvVaw1ViujzG-FVzBYmkk3VRF1Y), and [the Safe C++ Tool](https://www.google.com/url?q=https://github.com/duneroadrunner/scpptool\&sa=D\&source=editors\&ust=1756042270372160\&usg=AOvVaw3abvSnqR3LRqKWV-oo380b) (and [its SaferCPlusPlus library](https://www.google.com/url?q=https://github.com/duneroadrunner/SaferCPlusPlus\&sa=D\&source=editors\&ust=1756042270372259\&usg=AOvVaw0kFJQV9DqqOiYJO9xaHSKq), and [an auto-translation tool](https://www.google.com/url?q=https://github.com/duneroadrunner/SaferCPlusPlus-AutoTranslation2\&sa=D\&source=editors\&ust=1756042270372364\&usg=AOvVaw2pYAGd78ONHev5SZglroNH)).

We don’t propose a new language, but e.g. [CCured](https://www.google.com/url?q=https://web.eecs.umich.edu/~weimerw/p/p232-condit.pdf\&sa=D\&source=editors\&ust=1756042270372615\&usg=AOvVaw1Ona5hTq9b_BDWpm6o7z1Q) and [Cyclone](https://www.google.com/url?q=https://cyclone.thelanguage.org/\&sa=D\&source=editors\&ust=1756042270372722\&usg=AOvVaw0vNOIbbrdtSnK0nb2xKEGV) have been interesting previous efforts to make new flavors of C mostly compatible with existing C.

Also see an analysis of how memory tagging might change the safety situation.


## Background

There are 2 basic types of memory safety: spatial safety and temporal safety. Spatial safety is the guarantee that the program will behave in a defined and safe way if it accesses memory outside valid bounds. Examples include array bounds, struct and union field access, and iterator access.

Temporal safety is the guarantee that the program will behave in a defined and safe way if it accesses memory when that memory is not valid at the time of the access. Examples include use after free (UAF), double-free, use before initialization, and use after move (UAM). Temporal safety violations often look like type confusion. For example, the program mistakenly uses a recently-freed Dog object as if it were a Cat object. (Attackers often build entirely fake objects with vtables that give them control of program execution.)

Of these 2 types of safety, spatial safety is relatively easier to achieve (with changes in Chromium code and/or by boxing a build target in WASM), albeit at some micro-cost to efficiency. (For example, you have to perform the array bounds check, which might cost more than not doing it. This is an entirely empirical question that can only be resolved in the context of a real program, and the results can be surprising.)

Temporal safety is more difficult to achieve and more expensive. Solutions include ubiquitous reference counting (e.g. Objective-C with ARC, Swift), banning shared mutable state and building a borrow-checker into the compiler (e.g. Rust), or fully generic garbage collection (e.g. Go, JavaScript, etc.).

We believe that, given sufficient tolerance for micro-efficiency regressions, we could essentially eliminate spatial unsafety in C++ in first-party code. We could do this (and have started doing so) with a combination of library changes and additions, compiler options, and policies/style rules and presubmit checks (including banned and encouraged classes and constructs). Keep in mind that while possible and usually relatively easily technically, this work is controversial in C++ communities (including Chromium).

We cannot marginalize or eliminate temporal unsafety in C++ without adopting one of the known solutions (such as GC). Micro-efficient and ergonomic temporal safety remains an open problem in software engineering. However, at some (potentially significant) cost to efficiency, we can reduce the prevalence and exploitability of temporal unsafety. [\*Scan is a promising possibility](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/master:base/allocator/partition_allocator/starscan/README.md\&sa=D\&source=editors\&ust=1756042270377368\&usg=AOvVaw2ZdY62kgKj2HNwTmD2kIFK) that we are experimenting with.


## Undefined Behavior

Much of the problems of C/C++ come from undefined behavior (UB) built into the language and library specifications. (Even very recent language additions continue the tradition.) Spatial and temporal unsafety are sub-types of UB; other examples include signed integer overflow. Merely [enumerating all the UB in C++ is an open project](https://www.google.com/url?q=http://www.open-std.org/jtc1/sc22/wg21/docs/papers/2019/p1705r1.html\&sa=D\&source=editors\&ust=1756042270378189\&usg=AOvVaw2J1WYP61LyaYv91_i_kwyC).

[UB can be an opportunity for micro-optimization](https://www.google.com/url?q=https://blog.regehr.org/archives/213\&sa=D\&source=editors\&ust=1756042270378388\&usg=AOvVaw0MR8lVwKPiE0kF0749gcx4), although [attackers see UB as an opportunity for exploitation](https://www.google.com/url?q=http://www.dullien.net/thomas/weird-machines-exploitability.pdf\&sa=D\&source=editors\&ust=1756042270378588\&usg=AOvVaw2Pno8TaqQXH2F-k1RDRBcv).

For software that runs in an unpredictable and even hostile environment like the Internet, there is increasingly broad recognition that [writing reliable and safe software in C/C++ is an extreme uphill battle](https://www.google.com/url?q=https://alexgaynor.net/2020/may/27/science-on-memory-unsafety-and-security/\&sa=D\&source=editors\&ust=1756042270379016\&usg=AOvVaw0v3iBoSClNRopwbbQo-taK) due to the many safety- and ergonomics-relevant forms of UB.


## Purpose Of This Document

Given this background, our goal in this document is to enumerate some likely projects Chromium contributors could, should, and might undertake to reduce the overall exploitable and un-ergonomic UB in Chromium’s usage of C++.

It is not possible to entirely ‘fix’ C++ without fundamentally redefining it. That is not our goal here. Instead, we want to identify and reduce some of the most persistent and impactful types of unsafe UB in Chromium’s usage.


### Prioritization And Motivation

Here’s a guide to the relative importance of each of the solutions discussed in this document. This is pure numbers of bugs, but note that attackers favor different classes of bugs differently:

![](https://lh7-rt.googleusercontent.com/u/0/docsd/ANYlcfDzZWhiPRxTPwXjOlR4KvrjBVim3GAHfIOOf3tMkphv4QT8WyveemynsqtYx_NGOzHBzx6YVlFc_sMgLhxOiKbj2GqUT2pxDIECyeCLf74owosAty-S7twv_ryTApJf27nB9i6JSRatsgvArqPGU7IL3B5maI_SoMNETlp9Tx-gRa_BM_LfvVCgDig0a84ZOxwqTcFdBh4-XK3wVq5bKqJxUrZ0DlO9ReKamLC4D4tJoBVTRjHfE4jDKvf0EEGgjd_by-_MvLmZzkv-SWMrhZogITeBI-SpZhN8X1KtxzIrjTt6lkcTX8LwT7U4htPKCYptOiBwiAvOfge6dXSZmrBJA6omIVCDM_WiFlr_Dv398FbLvoOthzb2f0-o_5BYbr5A3OZN0p_cdAI04nrCf8R4luN0PqFojg0uUiooDKcQtNpCXnYuFOlpMA3JctohbO0NU7DniUdKp55gK-422hdj1lMRSPua4jkANFTKBgt_osjv2xs-MfhLNPLI_NJkwU56A43i6JqzwJ_RlOQ-raMKtOILxGm91Xzo9P-fnBXd5IoOdrG2x7j004H9ZgfHyQDusUd2BixPgYp7VhrWKPqZK47EuAZJzxc92w82Xuq4zC_lz6iGRPhkXsAncH16txWVI1fJpEFAFtp2ZXKA4QHttJZLQrJM5t1b819m2otubSeIfL0yE6mwS2MOSkQjrQfT6KeuweHIWk9ccobrm30yrY7Gtz9mZpj6P-vYeeDGSj-fpWQVFTUAKnsEs7MKwNhJllN7J2HNBlbqY4O82Xaa27HAOD6BVpxf4iVy3RcnVJKedx_e_xrAtxLAlqOAQFnbXECA33giSS1IQ747BFHuPRCn5F6hsY2ce6veFJ8IDj3-uuEw_b0EmLV274wKMn1W7VZCtPN5BymAOfThrdTbvd7Brxj70Psd3wzH47SuhqH4HCmx3NaFttjjNRgT4NSWM4kplOJ6O1-WOg3vJLkbe6bnB2Vfdc7s4XEMI7noIFTg8DWZodQ2bStrEGeIeJA)

([source](https://www.google.com/url?q=https://docs.google.com/presentation/d/1UVSc_0CHCdj0iv0c23uJZ6OQ_fr9TrISrYmcahJAbIo/edit?ts%3D5f31d4f7%23slide%3Did.g8f91eb8516_0_2\&sa=D\&source=editors\&ust=1756042270380653\&usg=AOvVaw12IbJ_W0M2fh465f-s58o8); Google-internal but the results are reproducible from [the public bug tracker](https://www.google.com/url?q=https://bugs.chromium.org/p/chromium/issues/list?colspec%3DID%2520Pri%2520M%2520Stars%2520ReleaseBlock%2520Component%2520Status%2520Owner%2520Summary%2520OS%2520Modified%26x%3Dm%26y%3Dreleaseblock%26cells%3Dids%26q%3DType%253DBug-Security%26can%3D1%26sort%3Dpri\&sa=D\&source=editors\&ust=1756042270380888\&usg=AOvVaw0eTUjrRWxGbHsVQErqhkNs))

The proposals and in-progress work described in the rest of this document are roughly ordered by how much impact they might have on our most significant bug classes.


### Managing Expectations

Note that many of these proposed and in-progress projects are quite large and complex, even changing the semantics of C++. While we think most of them are necessary, we also know that they are not sufficient. That is the nature of the C++ problem.

With that, here they are.


# Remove/Reduce Raw Pointers

Problem: Manual lifetime and ownership management has proven too difficult for even very experienced engineers to reliably do correctly. This results in UAF bugs and also memory leaks.

Solution: Ban the direct use of raw pointers, new, and delete. Instead, require developers to use one of the MiraclePtr implementations, for example. Note: Wrapping pointers in some syntax is beneficial for most approaches (Oilpan, MiraclePtr, \*Scan, et c.), and is valuable on its own.

Current status: [Work in progress](https://www.google.com/url?q=https://docs.google.com/document/d/1pnnOAIz_DMWDI4oIOFoMAqLnf_MZ2GsrJNb_dbQ3ZBg/edit%23\&sa=D\&source=editors\&ust=1756042270383549\&usg=AOvVaw3QuneYIhpnHNrVzbpMP0l4) (as of August 2021) for T\* fields in the browser process. The MiraclePtr project aims to make a smart pointer type that makes UAF unexploitable while not regressing run-time performance too badly.

Costs: Performance (TBD; as of August 2021 we are actively quantifying the impact of several implementations). Deviation from C++ language community norms. Non-Chrome C++ is is much less likely to adopt this approach and hence will not get the temporal safety that MiraclePtr provides (e.g. Google code pulled into Chrome, open source dependencies). Difficulty of diagnosing crashes (only one call stack from MiraclePtr as opposed to three from ASAN: allocate, free, use). If we wish to apply these protections to 3rd-party code, we may need to fork repositories such that their other consumers also use non-standard C++. ([Most UAFs happen in 1st-party code](https://www.google.com/url?q=https://docs.google.com/document/d/1VTJAqsQ004ydSPxPcFirM1ukS8uvmR49ppA4OM_9AQI/edit%23heading%3Dh.bcg0gbbh7czw\&sa=D\&source=editors\&ust=1756042270385511\&usg=AOvVaw2pXnMuUoLI0O24oauF0Ofk).) Instantaneous cost of rewriting lots of code (merge conflicts, etc.).

Benefits: UAF accounts for around [48% of high-severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf) (and climbing). [MiraclePtr plans to address \~50% of those now](https://www.google.com/url?q=https://docs.google.com/document/d/1VTJAqsQ004ydSPxPcFirM1ukS8uvmR49ppA4OM_9AQI/edit%23heading%3Dh.x9snb54sjlu9\&sa=D\&source=editors\&ust=1756042270386293\&usg=AOvVaw0Ye8zm8Sdl9etBNVImdNY2), and might theoretically cover 20% more in the future by banning raw pointers in containers and in local variables and function parameters. (In practice using MiraclePtr in local variables and tight loops might have a prohibitive performance cost.) The proposed implementation, BackupRefPtr, involves the potential runtime cost of atomic reference counting. (It can still be defeated by pointer arithmetic and aliasing.)

See [Pointer Safety Ideas](https://www.google.com/url?q=https://docs.google.com/document/d/1qsPh8Bcrma7S-5fobbCkBkXWaAijXOnorEqvIIGKzc0/edit%23heading%3Dh.j7d3wg2h6goh\&sa=D\&source=editors\&ust=1756042270387440\&usg=AOvVaw0WE5un6GxItWgJE2Jn1-cH) for more information.

However, Project Zero believes that inside renderer processes, the majority of UAFs are not of the kind MiraclePtr fixes. Instead, they are iterator invalidation and other lifetime mishaps.


# Annotate Lifetimes

Problem: C++ lifetimes are unknown to the compiler, and impossible to follow with static analysis.

Solutions: In some cases, we can annotate lifetimes with \[\[clang::lifetimebound]] in order to tell the compiler the lifetime is bound to an object.

The attribute has many limitations, meaning it is not a solution for memory safety, but it can help with some important scenarios. The limitations are:

- There is no way to distinguish between different lifetimes.
- There is no way to annotate a static lifetime.
- The attribute attaches to function parameters and always implicitly refers to the outermost reference-like type; it is not possible to attach it to part of a type (e.g. to the T\* in a const std::vector\<T\*>&).
- The single lifetime is implicitly applied to the outermost reference-like type in the function’s return type (or the value of the constructed object, in the case of a constructor). Again, it is not possible to associate the lifetime with inner reference types in the return value (e.g. the T\* in const std::vector\<T\*>&).
- There is no way to add a lifetime parameter to a struct. This means that parameters can only be attached to the object’s lifetime if they are given to a constructor, not in other setters.

In theory, we should apply this to:

- Any constructor reference parameter that is stored in a field.

* However it misses even trivial examples:

- [https://godbolt.org/z/Ysq41G6vb](https://www.google.com/url?q=https://godbolt.org/z/Ysq41G6vb\&sa=D\&source=editors\&ust=1756042270392146\&usg=AOvVaw3wEOTHpcGh0Rir6RBNZwIF)

* Any constructor pointer parameter that can be held in a const member. (In other words, the pointer is never reassigned.)

- However it misses even trivial examples:

* [https://godbolt.org/z/Ma7P8q8WG](https://www.google.com/url?q=https://godbolt.org/z/Ma7P8q8WG\&sa=D\&source=editors\&ust=1756042270392794\&usg=AOvVaw1yZ7CTC8C0aqIqKkz9VG0G)

- Any class method that returns a reference or pointer to a class member (but not to pointers inside class members, unfortunately).

* However it misses even trivial examples:

- [https://godbolt.org/z/9er4WE6zK](https://www.google.com/url?q=https://godbolt.org/z/9er4WE6zK\&sa=D\&source=editors\&ust=1756042270393411\&usg=AOvVaw0dGiPY5wBngjD4rx_pm_S_)
- [https://godbolt.org/z/GW9j4zrdT](https://www.google.com/url?q=https://godbolt.org/z/GW9j4zrdT\&sa=D\&source=editors\&ust=1756042270393667\&usg=AOvVaw0amIPpDo9urb9S4-KC-Jom)

* Any function that receives references or pointers and returns a reference or pointer back to its input. This includes templated functions that return one of their inputs (such as min/max/clamp).

The only cases this attribute only actually catches at the moment are [invalid use of temporaries](https://www.google.com/url?q=https://reviews.llvm.org/D49922%23inline-440637\&sa=D\&source=editors\&ust=1756042270394550\&usg=AOvVaw21orCA6FlajCvCq9s1xqKz). While this is a valid/important memory safety bug when it happens, it is not representative of the type of bug we see in our UAF security bugs.

- And it does not even catch all temporaries:

* [https://godbolt.org/z/PbnM1TY8n](https://www.google.com/url?q=https://godbolt.org/z/PbnM1TY8n\&sa=D\&source=editors\&ust=1756042270395221\&usg=AOvVaw0e4dVuIFfH2-OezjvBu7Ei)
* [https://godbolt.org/z/aMbaq4W55](https://www.google.com/url?q=https://godbolt.org/z/aMbaq4W55\&sa=D\&source=editors\&ust=1756042270395416\&usg=AOvVaw3628fpwF8vdrAHsMU_j_yB)
* [https://godbolt.org/z/9G77fcE18](https://www.google.com/url?q=https://godbolt.org/z/9G77fcE18\&sa=D\&source=editors\&ust=1756042270395602\&usg=AOvVaw0ROEo-IC1eXAdw3jGP13NR)

- In fact it’s hard to construct an example that it does catch.

Some key potential places to do this are:

- base::span constructor
- base::StringPiece constructor
- base::clamp
- ????
- Reference/pointer-returning methods everywhere — but only if we can show that the attribute actually helps (see above godbolts for counter-examples).

Note that base::span is designed to be able to hold an invalid pointer past the end of the container it’s “pointing” to, and the lifetime analysis can not help with this problem. This is a spatial memory safety problem built into C++. But it could potentially help with using the base::span beyond the lifetime of the object it points to, if the attribute caught more misuses.

Current status: Not started.

Costs: Visually noisy annotations (the Abseil macro is a mouthful) present in the code. We will learn to become familiar with them. But there are many places where the annotation can not be used. The annotation can be written incorrectly, where it is more strict than the object requires, or it may become incorrect over time if an object is changed. For instance, if base::span grew a method to re-assign the pointers.

Since the attribute is defined to generate a warning if a violation can be spotted, it does not actually guarantee violations are caught. And it seems that most are not (see godbolt examples above). This can give a false impression of safety, which may lead to developers trying to rely on the attribute catching their mistakes and actually writing more UAFs.

Furthermore, there is no way to enforce that the annotations are present where they are possible, which would allow new code to be written without them. Code authors that rely on annotations to check their correctness would be left without any checks.

Benefits: Compiler errors when some set of simple lifetime errors are written.


# Implement Automatic Memory Management

Problem: Temporal safety and correctness (UAF, leaks).

Solutions: Reference counting (e.g. [ARC](https://www.google.com/url?q=https://en.wikipedia.org/wiki/Automatic_Reference_Counting\&sa=D\&source=editors\&ust=1756042270401020\&usg=AOvVaw0e8NqHN2PpZSnkvmggEAUP)-like semantics), and/or full GC.

Current status: Oilpan is now a generic reusable library (no longer special to Blink), and [we have adopted it in PDFium](https://www.google.com/url?q=https://bugs.chromium.org/p/pdfium/issues/detail?id%3D1563\&sa=D\&source=editors\&ust=1756042270401558\&usg=AOvVaw3DHWFfcFHXVV4tlMTVXD4-) to resolve many or most of our temporal safety problems in that project. This enabled us to ship XFA Forms support in production, for example! (Currently off by default, due to functionality gaps.)

Costs: Reference counting needs to be atomic, which costs micro-time. Fully generic GC can be expensive.

Benefits: UAFs account for around [48% of high-severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf) (and climbing). This approach is an alternative to the universal application of checked pointer types ([see above](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.c3notccb295u)). Additionally, GC has excellent developer ergonomics.


# Implement Ownership Analysis

Problem: Temporal safety and correctness (UAF, leaks).

Solutions: Enforce at run-time that there is a single ‘owner’ of any object, which can only be changed via std::move. Allow ‘borrows’ with Rust-like rules which prevent multiple mutable references existing at the same time, and ensures objects aren’t accessed beyond their lifetime bounds.

This solution seems a poor fit to C++, but it keeps being proposed so it seems important to discuss it here.

Rust achieves this model through fairly complex [compiler support](https://www.google.com/url?q=https://doc.rust-lang.org/edition-guide/rust-2018/ownership-and-lifetimes/non-lexical-lifetimes.html\&sa=D\&source=editors\&ust=1756042270405062\&usg=AOvVaw1-7QlGxQ8ECcBpaS_MqL5_). The majority of objects therefore incur no runtime cost for this sort of ownership checking; it’s all static. Developers can optionally instead use a runtime version ([RefCell<>](https://www.google.com/url?q=https://doc.rust-lang.org/std/cell/struct.RefCell.html\&sa=D\&source=editors\&ust=1756042270405519\&usg=AOvVaw1yiJhCY7ewpQdOk8W6yZHo)) which does the same checks at runtime. We presume this model would be far too expensive if every object were tracked at runtime, and [we don’t see a way to do static build-time enforcement in C++ without radical compiler and language changes](https://www.google.com/url?q=https://docs.google.com/document/d/1oVTxJ-4VItkcA7rAMylIW74SOmKsnc4aS6bylr1B8ZY/edit?resourcekey%3D0-RNrtKRt8CQ_BgGdGzrDwUA\&sa=D\&source=editors\&ust=1756042270406148\&usg=AOvVaw04COS2BxCl799omuZtyrPx). (Clang has added [lifetime bounds](https://www.google.com/url?q=https://reviews.llvm.org/rL338464\&sa=D\&source=editors\&ust=1756042270406311\&usg=AOvVaw01VacdctkBv5d3tYXNv-vo) for simple cases, [but see above](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.j8svxi9w9c1i)).

Current status: We have [some early experiments at runtime ownership enforcement](https://www.google.com/url?q=https://docs.google.com/document/d/1YnJBXshxxpUkgzgEsuGTvxsFqVq_YFzsueQHxpbDZJU/edit\&sa=D\&source=editors\&ust=1756042270406820\&usg=AOvVaw31UlWZSO8W7J5BUn_IveVg). Compile-time safety is [infeasible](https://www.google.com/url?q=https://docs.google.com/document/d/e/2PACX-1vSt2VB1zQAJ6JDMaIA9PlmEgBxz2K5Tx6w2JqJNeYCy0gU4aoubdTxlENSKNSrQ2TXqPWcuwtXe6PlO/pub\&sa=D\&source=editors\&ust=1756042270407081\&usg=AOvVaw3r3JUV3qQDrqDpUPsg6SSI) without fundamental changes to C++ such as new reference types. There is work for limited safety in [clang warnings that will catch dangling references](https://www.google.com/url?q=https://youtu.be/80BZxujhY38?t%3D1096\&sa=D\&source=editors\&ust=1756042270407436\&usg=AOvVaw0AbYRO0hsAzq8OLkAbfWFn) through control flow analysis, but these will not catch invalid heap pointers by design.

Costs: Runtime costs equivalent to reference counting. Need to distinguish ‘owner\_ptr’ from ‘borrowed\_ptr’.

Benefits: UAFs account for around [48% of high-severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf) (and climbing). This approach is an alternative to the universal application of checked pointer types.


# Use -Wdangling-gsl

Google has had good results with this internally, finding and fixing UAF bugs. There are some false positives, but plenty of true positives.

Current status: Clang defaults to on, and this warning is not disabled in BUILD.gn files, so we seem to be making use of it.


# Define All Standard Library Behaviors

(Where possible.)

Problem: The standard library is riddled with potentially exploitable undefined behavior. This includes lack of bounds checking (e.g. [std::span::operator\[\]](https://www.google.com/url?q=https://en.cppreference.com/w/cpp/container/span/operator_at\&sa=D\&source=editors\&ust=1756042270410268\&usg=AOvVaw0PGEKFwuiGTuDPiKi7ShO6)) and lack of validity checking (e.g. [std::optional::operator\*](https://www.google.com/url?q=https://en.cppreference.com/w/cpp/utility/optional/operator*\&sa=D\&source=editors\&ust=1756042270410494\&usg=AOvVaw25BZi4ALh7gt1ks9ub9FIg)). [std::string\_view’s unfortunate affordance for UAF](https://www.google.com/url?q=https://github.com/isocpp/CppCoreGuidelines/issues/1038\&sa=D\&source=editors\&ust=1756042270410632\&usg=AOvVaw071ZePp7VFjt40e9Stt8cT) is a separate problem, though. This is especially unfortunate in the recent library additions, because unsafe-but-fast options were already available.

Since std is specified to have lots of UB, we cannot easily be and remain certain that implementations we use will be fully hardened or easily hardenable against UB, especially as new features are added. Instead, we should use a std(-like) replacement whose design and implementation we can more effectively influence, such as Abseil. Alternatively, we could dedicate headcount to working with upstream libcxx to ensure a hardened mode is robust and supported.

Solutions: Add a ‘hardened’ mode (selectable at compile time) to standard library implementations that allows us to make the undefined behavior well-defined and safe. This is fairly ‘easy’ for spatial safety; for temporal safety, see above.

Current status: Abseil team have already added a spatial safety hardening mode to Abseil. It perhaps could use a completeness audit, but as of August 2021 it looks pretty good. [We use this mode in Chromium](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/main:third_party/abseil-cpp/absl_hardening_test.cc;l%3D19?q%3Dabsl_harden%26ss%3Dchromium\&sa=D\&source=editors\&ust=1756042270413436\&usg=AOvVaw27wA9JEJya1Yxt8ASNMDFz). A similar hardening mode for LLVM libcxx is in [progress](https://www.google.com/url?q=https://bugs.chromium.org/p/chromium/issues/detail?id%3D923166\&sa=D\&source=editors\&ust=1756042270414375\&usg=AOvVaw2SPM72qs1k6NvdHYiqECVx) ([upstream](https://www.google.com/url?q=https://reviews.llvm.org/D89353\&sa=D\&source=editors\&ust=1756042270414484\&usg=AOvVaw1hqjfqS7qh3PXDFGKXBS2M)). We have also added spatial hardening to //base (but could use a completeness audit). [WTF](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/main:third_party/blink/renderer/platform/wtf/\&sa=D\&source=editors\&ust=1756042270414856\&usg=AOvVaw3WdfJDDq2LzcGvOueUM1hb) also has the same status as //base.

We are also considering a [project to build a standard-like library with no UB](https://www.google.com/url?q=https://github.com/chromium/libboring\&sa=D\&source=editors\&ust=1756042270415337\&usg=AOvVaw1sUaIOS-KOh6cf6hjqT3Dc) \[Google-internal for now, sorry], since there is not much appetite for making //base stand-alone. However, Abseil with hardening may obviate that. But if there is general interest for an open source, std(-like) library that is specified to have no UB, we could dedicate headcount to that.

Costs: Possible micro-cost in run-time due to increased checking.

Benefits: [Spatial unsafety is 16% of high severity security bugs; possibly 17.5%](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf).


## Define Undefined Iterator Behaviors

Problem: In particular, it seems important to mention 2 bug classes involving UB in iterators. Thanks to Sergei and Mark from P0 for raising these points:

for (auto& iter : my\_container) {

  MaybeChangeMyContainer();

}

and

auto iter = my\_container.find(the\_thing);

DCHECK(iter != my\_container.end());

iter->second->Foo();

Mark says:

It seems like the iterator invalidation problem could be solved efficiently.

EITHER by having the container track live iterators and "neuter" any live iterators when an iterator-invalidating operation occurs - it should be rare that such an operation occurs with many live iterators, so this should be fairly inexpensive, and would incur zero overhead on iterator access.

OR using something like a generation tag, which would be checked on iterator access; this would add iterator access overhead so it might be too expensive?

OR more API-breakingly, we could simply CHECK on iterator-invalidating operations when there are live iterators - this would be cheaper but would likely require significant testing and code changes to ensure that on-stack iterators are discarded once they're not being used.

Solution: We have [a CheckedIterator type in //base](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/master:base/containers/checked_iterators.h\&sa=D\&source=editors\&ust=1756042270420230\&usg=AOvVaw1CkA2ke0wWxgRCml3Yzt8h).

Current status: It had been expensive in practice (due to a lack of a supported way in libcxx to express that it can be optimized), but [that is fixed now](https://www.google.com/url?q=https://bugs.chromium.org/p/chromium/issues/detail?id%3D994174%23c15\&sa=D\&source=editors\&ust=1756042270421098\&usg=AOvVaw3ZnBCV0L8upH1__N8J8ZHZ). We should expand its use now that we can do so efficiently. For example, it should be possible to create a well-defined end singleton template that crashes cleanly.

Costs: Hopefully, the run-time overhead is acceptable now.

Benefits: Reduced iterator invalidation UB (including spatial and temporal unsafety).


# Define Integer Semantics

Problem: [C/C++’s integer semantics are bonkers](https://www.google.com/url?q=https://chromium.googlesource.com/chromium/src/%2B/master/docs/security/integer-semantics.md\&sa=D\&source=editors\&ust=1756042270422682\&usg=AOvVaw1T65nO3O2JXe-qmtwojyQ3): the wrapping, overflow, underflow, undefined behavior, implicit casting, and silent truncation behaviors all add up to unsafety and poor ergonomics. As a result, developers have a hard time correctly calculating sizes, indices, and offsets, especially when an attacker can control some of the terms. Arithmetic overflow and underflow often lead to mistakes in memory allocation and access, and from there to exploitable bugs. Other bug classes arise from integer overflow too, such as [reference counts wrapping](https://www.google.com/url?q=https://twitter.com/tehjh/status/1045000957678047232?lang%3Den\&sa=D\&source=editors\&ust=1756042270423712\&usg=AOvVaw1ZaXPsaBtQP_tDDvQUD7kH), or wrapping causing unique IDs to no longer be unique.

Implicit conversion from integer to floating point hides the fact the stored value potentially changes. It’s insidious as within common ranges the value does not change, but if an attacker can control the value of the integer, they can make it large enough to violate the assumption. Then on conversion back to an integer, [the result becomes invalid](https://www.google.com/url?q=http://crbug.com/278141\&sa=D\&source=editors\&ust=1756042270424720\&usg=AOvVaw0CllMVlG81vvf5YW0VYcZi).

Solution 1: Require developers to use the //base/numerics library or something similar. Specify specific types for intentional wrapping, saturating, and trapping (as Rust does). The norm should be that people use reliable arithmetic by default, and leave primitive C arithmetic behind to the greatest extent possible. In particular, we should dedicate some headcount to improving the generality and ergonomics of //base/numerics, and should make it into a stand-alone dependency. (It already is easily separable from //base, but you have to copy and paste.)

Solution 2: We could require compiler options to make signed overflow behave the same as unsigned (i.e. [wrapping](https://www.google.com/url?q=https://clang.llvm.org/docs/ClangCommandLineReference.html\&sa=D\&source=editors\&ust=1756042270426397\&usg=AOvVaw1QQ2uPJxQkOuByRrgYiL9L)). That is, we could standardize on the Java and Go behavior: we could use -fwrapv in debug and production builds. Alternatively, we could use -fwrapv in release builds and -ftrapv in debug builds (like Rust).

Solution 3: Clang also has [sanitizer options](https://www.google.com/url?q=https://clang.llvm.org/docs/UndefinedBehaviorSanitizer.html\&sa=D\&source=editors\&ust=1756042270427299\&usg=AOvVaw3UJldEwwL6k9IYQH9-39K4) — which can be configured to immediately trap, thus requiring no run-time support — to handle division by 0, truncation, implicit casting, and shifting left too far, casting an integer to an invalid enum value.

Android already uses -fsanitize=signed-integer-overflow,unsigned-integer-overflow in large (and growing) parts of the codebase.

enh@ notes: “In combination with fuzzing it works quite well to show you where you need \_\_builtin\_add\_overflow or whatever. Without fuzzing it's a ‘good’ source of work backporting security fixes as/when stuff is found in the field.”

Solution 4: Clang provides a warning on implicit int conversion to float, behind -Wimplicit-int-float-conversion. We should enable this warning.

Current status: //base/numerics is used in many places successfully. We just need to use it more. The API needs some ergonomic improvements.

We do not use either -ftrapv or -fwrapv in any .gn or .gni file. We [have disabled](https://www.google.com/url?q=https://crbug.com/989932\&sa=D\&source=editors\&ust=1756042270429841\&usg=AOvVaw14p1EQTrMsioGVbqHFH39Q) the -Wimplicit-int-float-conversion [warning](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/main:build/config/compiler/BUILD.gn;drc%3Dab531c265c533cba1c2f6d8240cc0bf7679f605a;l%3D1611\&sa=D\&source=editors\&ust=1756042270430265\&usg=AOvVaw3m5BIEq3Qeq29YtHgAtnfp).

[Build profiles that use is\_ubsan sanitize signed int overflow](https://www.google.com/url?q=https://source.chromium.org/search?q%3Dsanitize%253Dsigned-integer-overflow%26sq%3D%26ss%3Dchromium\&sa=D\&source=editors\&ust=1756042270430550\&usg=AOvVaw09M8JHglOybAcRcIC4Itsq), and [with a significant block list](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/master:tools/ubsan/blacklist.txt?q%3Dblacklist.txt%26ss%3Dchromium\&sa=D\&source=editors\&ust=1756042270431048\&usg=AOvVaw2D_P-siuV63fB2VwuP48Iu). It does not seem to be on in production builds of Chrome.

Costs: Training. Migrating code. Some 3rd-party projects (e.g. Skia) resist systemic solutions. Potential for micro-efficiency regression if people use checked arithmetic in tight loops. Potential for binary size increase if we ship UBSan with trapping (which does not require the UBSan runtime support library and produces small, coalescable branch targets on failure).

Assuming overflow behavior is a significant change in C/C++ semantics. (LLVM developers for example try to avoid introducing new semantics with command-line options; but some already exist out of necessity.) If developers come to rely on well-defined integer behavior, code can become buggy if anyone were to turn the option off. (We can, and should in any case, protect against this with tests.) Using explicit types for trapping, wrapping, and saturating avoids that, but doesn’t easily work for 3P dependencies and requires explicit changes to call sites.

Benefits: [Integer overflow represents around 2% of our high severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf), though arguably that’s reduced in importance if we truly manage to prevent buffer overflows (see later). Using -fwrapv may and should be maximally compatible with existing code, and matches most developers’ expectations. Using UBSan with trap-on-failure covers the most problems but may require some carve-outs and may introduce some speed and binary size regressions (an empirical question). Call sites that need explicit checking should continue to use //base/numerics in any case.

There are also logical bugs, such as an expectation that incrementing numbers will remain unique as identifiers, reference counters wrapping, and so on. Again, trapping or sanitizing would catch these. With a Trapping\<T> in //base/numerics, we could statically ensure that.

Having defined behavior and skipping odd optimizations based on undefined integer behavior might also improve ergonomics.


# Set Pointers To Null After Free

Problem: The contents of a region of memory after free are undefined. That is confusing and potentially exploitable.

Solution: kcc@ notes: “Another potential investigation is nullifying pointers after free (by compiler). After delete foo->bar, add foo->bar = nullptr. Obviously, it’ll fix a small portion of cases (guesstimate: 1% – 10%); e.g. it can't handle delete GetBar();. But it’s \~ zero overhead and relatively easy to implement. LLVM patches have been floating around (but IDK the current state).”

This will also help make any GC-based approaches more efficient.

Current status: None.

Costs: kcc@ says \~ zero.

Benefits: Detect 1 – 10% of UAFs. Improved developer ergonomics (modulo aliasing, the contents of a region after free and before it is reused are now defined).


# Define Null Pointer Dereferences

Problem: Null pointer dereferences are UB. This is an issue because developers (reasonably) expect a null pointer dereference to crash the process instead of continuing. However, the compiler can and sometimes will optimize away the null pointer dereference and in some cases elide a check for it, even though continuing execution might result in a much more corrupted state and possibly exploitable behavior.

For example, our smart pointer type WeakPtr was vulnerable to UAFs: if the pointed-to object was destroyed, WeakPtr::get would return a null pointer and the subsequent dereference was supposed to crash the program. However, clang correctly determined that storing a null pointer and immediately dereferencing that pointer was undefined behavior, and therefore removed the store of null pointer entirely. So WeakPtr::get would actually return the stale pointer and the dereference would instead result in a UAF. There has been at least [1 externally-reported high-severity security bug due to this issue](https://www.google.com/url?q=https://bugs.chromium.org/p/chromium/issues/detail?id%3D1133635\&sa=D\&source=editors\&ust=1756042270440352\&usg=AOvVaw0q-IO336FPJyaKOBXvy4Rm) ([fixed with an explicit CHECK](https://www.google.com/url?q=https://chromium.googlesource.com/chromium/src/%2B/0b308a0e37b9d14a335c3b487511b7117c98d74b\&sa=D\&source=editors\&ust=1756042270440571\&usg=AOvVaw2SPKXdOSYqVGvrBwfUt3cL)).

Solution: Clang provides a compiler flag called -fno-delete-null-pointer-checks (named as such for historical reasons) that defines null pointer dereferences. With this flag, dereferences of null are never optimized away.

Current status: [Landed](https://www.google.com/url?q=https://chromium-review.googlesource.com/c/chromium/src/%2B/2481465\&sa=D\&source=editors\&ust=1756042270441391\&usg=AOvVaw06PIHLDRSsmM4DPnMaWtP0).

Cost: 42 kB Android binary size (at minimum) and [some microbenchmark regressions in Blink parsing performance](https://www.google.com/url?q=https://crbug.com/1149340\&sa=D\&source=editors\&ust=1756042270441779\&usg=AOvVaw3QPbXzJoCCtu93PmP4w5uc).

Benefits: With this flag, the compiler behaves the way most developers expect, making it easier to understand the meaning of code.


# Require Coding Patterns To Reduce Lifetime Errors

Benefits: UAFs account for around [48% of high-severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf) (and climbing). Improved coding patterns are not a robust solution, since they’re still subject to human error. But they may eliminate some fraction of the bugs. When combined with a robust solution such as a deterministic MiraclePtr, they may remove some (non-exploitable) crashes.


## Use absl::variant Instead Of enums For State Machines

Problem: enums are often used for state machines. Unfortunately, the enum variant is not the only bit of the state — there are almost always extra fields which pertain to a subset of the states. These things get out of sync, causing object lifetime problems and logic errors.

struct StateMachine {

   enum {

      CONNECTING,

      CONNECTED,

      DISCONNECTING,

   } state;

   // These fields could get out of sync with ‘state’:

   int thing\_relevant\_only\_when\_connected;

   std::string thing\_relevant\_only\_after\_connection;

};

Solution: Use absl::variant, which is a type-safe tagged union. [All data which relates only to one of the states should be associated with that specific variant](https://www.google.com/url?q=https://genbattle.bitbucket.io/blog/2016/10/07/Type-Safe-Unions-in-C-and-Rust/\&sa=D\&source=editors\&ust=1756042270445765\&usg=AOvVaw1xQvkLkAgdKKbTynW5TIXt).

Current status: absl::variant is [newly allowed](https://www.google.com/url?q=https://groups.google.com/a/chromium.org/g/chromium-dev/c/sKVWxxSjVFU/m/MWqjjz9CAwAJ\&sa=D\&source=editors\&ust=1756042270446159\&usg=AOvVaw0upegb7yQ58TVTcWilrxbJ). No attempt has been made to retrofit to existing code.

struct Connecting { int thing; }

struct Connected { std::string thing; }

struct Disconnecting { std::string thing; }

auto state\_machine = absl::variant\<Connecting, Connected, Disconnecting>;

Costs: Awkward syntax (arguable). Difficulty of identifying which enums are used for state machines. (Can we simply ban all enums?)

Benefits: Reduced logic errors and object lifetime errors, currently unquantified.


## Ban std::unique\_ptr::get; Use Shared Pointers

Problem: unique\_ptr encourages the notion that there’s a single owner, yet we see such pointers featuring in use-after-free bugs so this notion is obviously wrong. (unique\_ptr really guarantees a unique deleter, not necessarily a unique owner.)

Solution: Prevent any means of getting a raw pointer out of a unique\_ptr (to the extent possible). Not even a checked pointer: if developers are getting any extra pointers to something within a unique pointer, then it’s not truly uniquely owned, and they should use a shared pointer. (Yes, we really do have to incur the costs of reference counting.) And in most cases where unique\_ptr is used, it might be better to use base::Optional to obtain composition into a single heap cell.

Current status: Opposite of current best practice, where shared pointers are discouraged and unique\_ptr encouraged.

Note that dcheng has a countervailing view: that we instead want clarity of lifetime and the ability to assert ownership more clearly than shared\_ptr/reference counting/GC allows:

What I think we really need is a safe version of raw pointer to make lifetime assertions when we believe an object should have single ownership. There was a previous attempt at this called CheckedPtr (though that kind of conflicts with MiraclePtr's implementation details now)... maybe we should seriously consider it though, as this seems to be a repeated theme.

Costs: We may find lots of objects need reference counting. But we need to do that for safety. Reduced clarity about lifetimes and when an object’s destructor would run. It would also be easier to create reference cycles.

Benefits: Reduced object lifetime errors, currently unquantified. Fewer heap allocations and dereferences if we use composition more often than a pointer.


# Initialize All Memory

Problem: When a program uses variables before they have been initialized, bugs ensue. These can include (possibly exploitable) wild pointer dereferences and information disclosure bugs. Using uninitialized memory may also introduce application-semantic bugs that may or may not be security vulnerabilities.

(Information disclosure bugs can occur when the struct has padding, and the code memcpys a struct and sends the result to another process. The padding may be uninitialized, which is to say, whatever data was there previously — and perhaps that data is sensitive. We have had [bugs like this](https://www.google.com/url?q=https://bugs.chromium.org/p/chromium/issues/detail?id%3D765512\&sa=D\&source=editors\&ust=1756042270453926\&usg=AOvVaw1MxjVbLdwcpWhHbym1kpH6) in the past. Of course, the proper fix for such information disclosure bugs is to properly serialize structs, initializing the whole struct first is a good defense in depth.)

Solutions: In addition to being nice, well-defined behavior (and hence good for developer ergonomics, as Go has shown), initializing all memory (either to 0 or some canary value) eliminates wild pointer and application-semantic bugs arising from the use of uninitialized memory.

Alternatively, we could configure the compiler to reject variable declarations that have no initializer.

Current status: vitalybuka@ has painstakingly [enabled stack auto-initialization](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/master:build/config/compiler/BUILD.gn;drc%3D8127c68a14511ea04c8b0899a67edf8ea26d9747;l%3D2631\&sa=D\&source=editors\&ust=1756042270455800\&usg=AOvVaw1WmoiyLtnooAJ9GtVkmeQM), on [non-Android](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/master:build/config/compiler/BUILD.gn;l%3D135?q%3Dinit_stack_vars%26ss%3Dchromium\&sa=D\&source=editors\&ust=1756042270456032\&usg=AOvVaw1dp_6AgKCN-ZRVmV3steje), with [some carve-outs](https://www.google.com/url?q=https://source.chromium.org/search?q%3Ddefault_init_stack_vars%26sq%3D%26ss%3Dchromium\&sa=D\&source=editors\&ust=1756042270456200\&usg=AOvVaw2fGds4YkxbJpYkT93gsJ2s), and has worked for months to solve performance regressions by excluding hot paths.

enh@ says:

Android R has stack zero initialization for kernel and userspace. We found relatively few places in userspace that we needed to annotate for performance. Folks are looking at heap zero initialization for S. That will probably be harder.

Future work:

- Heap auto-init (currently it is stack-only)
- Try to push for zero-init again
- See if we can switch to \_\_attribute((uninitialized)) instead of build config carve-outs
- Try V8 again?

Costs: Auto-initialization has proven to incur noticeable run-time costs in hot paths. (Vitaly has manually opted those hot paths out of auto-init.)

Assuming auto-init is a significant change in C/C++ semantics. If developers come to rely on auto-init, code can become buggy if anyone were to turn auto-init off. (We can, and should in any case, protect against this with tests.)

Benefits: Uninitialized memory is a small fraction of our high severity security bugs, probably no more than 1.5%. Auto-init reduces the cognitive load (less need to remember all UB), and may enable cleaner code paths iff developers can assume autoinit is always on [if the program continues](https://www.google.com/url?q=https://lists.llvm.org/pipermail/cfe-dev/2020-April/065233.html\&sa=D\&source=editors\&ust=1756042270459380\&usg=AOvVaw0ejBqfvu9Y67IV7jmBV5T5).

Since we do need to turn auto-init off in places, such call sites should be ‘obvious’ and well-documented. (An example of obvious and well-documented: [using \_\_attribute((uninitialized)) or similar](https://www.google.com/url?q=https://source.chromium.org/chromium/chromium/src/%2B/master:sandbox/win/src/sandbox_nt_util.cc;l%3D63?q%3Dtrivial-auto-var-init%26ss%3Dchromium\&sa=D\&source=editors\&ust=1756042270459978\&usg=AOvVaw3AbQMSYsIP1ReblCUx5Ck4) in hot spots rather than special-casing directories in the build.)


# Remove Primitive Arrays

(May be covered under [Remove Raw Pointers](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.c3notccb295u).)

Problem: Primitive C arrays are not bounds-checked, and thus tend to exhibit spatial safety bugs. -fsanitize=bounds only works when the compiler can statically determine the array’s size, which is not always.

Solutions: Require the use of a type like std::array where C-style arrays are currently in use. It may be possible to automatically migrate old code to std::array (similar to how we are automatically migrating code to MiraclePtr). Note that this is only a security win if we also use a std implementation where all undefined behavior is defined; for example, std::array::operator\[] does no bounds checking. (See [Define All Standard Library Behaviors](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.ji6or6kpi3sa).)

Current status: None.

Costs: Micro-efficiency. Training and socialization. May want to write a PRESUBMIT check or (preferably) a clang warning, if that’s possible.

Benefits: [Spatial safety is 16% of high severity security bugs; possibly 17.5%](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf).


# Remove Mutable Shared State

Problem: C++ cannot prevent data races.

Solutions: Implement support in the compiler to enforce this, and a borrow checker.

Current status: None. See [Implement Ownership Analysis](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.og4lsfsjoiy8).

Costs: Unknown. Potentially significant change to developer expectations. If Chromium makes heavy use of shared mutable state in places, that code would need to be significantly refactored.

Benefits: Data races are [known to be \~1% of our high severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf); however they are implicated in lots of bugs that then appear in other categories (e.g. temporal unsafety) so this likely under-represents the scale of the problem.


# Check Type Casts

Problem: Type confusion bugs such as this:

void SomeFunction(Animal\* animal) {

  // NOTE: Dog and Cat are subclasses of Animal.

  DCHECK(IsCat(animal));

  Cat\* cat = static\_cast\<Cat\*>(animal);

  cat->Meow();    // If animal is really a Dog\*, memory unsafety may ensue!

}

can be exploitable, such as by causing memory corruption when code incorrectly treats an object of 1 class as if it were an instance of another.

The static\_cast should be a dynamic\_cast, or otherwise automatically checked — not just in debug builds with DCHECK, but in production builds too. Historically Chrome has avoided dynamic\_cast because the cost of RTTI is too high (e.g. huge object code size). That allows bugs that escape detection during debugging and fuzzing to become vulnerabilities in the wild.

Regarding object code size, davidben@ notes:

Playing around with godbolt, looks like the cost of RTTI is each vtable now also gets a typeinfo with a few quads and a class name. That doesn’t seem like it should be too expensive?

I got an (possibly with the wrong build flags) increase from 171M to 178M in a stripped Linux release build, which is substantial but doesn’t seem huge? Android hit some link error with use\_rtti though I assume that’s fixable.

Assuming it is indeed the type names, maybe we just need a Clang flag to omit them? [std:type\_info::name supposedly doesn’t promise anything](https://www.google.com/url?q=https://en.cppreference.com/w/cpp/types/type_info/name\&sa=D\&source=editors\&ust=1756042270469296\&usg=AOvVaw3JB_kT6oiWXh6ohf6nVrVa), so the empty string should be perfectly compliant...

Solutions: TODO. dcheng@ says:

I’m guessing you’re thinking of the casting helpers that @inferno\@google.com originally added to WebKit. These use a handrolled implementation of RTTI.

I’ve updated these into a more ‘modern’ template-based C++ solution, but since we don’t actually support RTTI at all today, it doesn’t use dynamic\_cast, even in debug mode.

The way it works today:

- Blink classes implement IsX
- There are traits that tell the cast helpers how to use the various IsX methods.
- DynamicTo<> behaves like dynamic\_cast<> and returns nullptr if the type check fails. Used in places where you’d want to do IsA\<X> followed by To\<X>.
- To<> behaves like static\_cast<> but has a DCHECK(IsA\<X>);.

My ideal world would be:

- To<> always does the type check
- DynamicTo<> stays the same.
- UnsafeTo<> skips the type check in official builds when the performance is ‘necessary’.
- \<Something> enforces that we use these helpers for casting rather than static\_cast.

tsepez@ says:

Some years ago, I'd pondered creating subclass\_cast<> (or down\_cast<>) which would be defined as dynamic\_cast if RTTI was enabled, and static\_cast otherwise (to avoid warnings about dynamic cast in non-RTTI builds). I eventually concluded this was a bad idea, on the grounds that you make languages better by removing things from them you shouldn't use rather than adding new things that you should use.

markbrand@ says: “AFAIU clang-cfi supports this, not sure whether RTTI is required.”

kcc@ asks: “Why not [cast-cfi](https://www.google.com/url?q=https://clang.llvm.org/docs/ControlFlowIntegrity.html%23bad-cast-checking\&sa=D\&source=editors\&ust=1756042270474358\&usg=AOvVaw1D-w4c9KGOetvjnsd83ZXr)? Microsoft is doing it.”

Current status: There is now a convention in Blink to handle the “cast to wrong subclass” problem, which used to be more common in Blink. Perhaps it could be adopted more widely.

Costs: We can make it cheaper than RTTI and dynamic\_cast, but there will always be some micro-cost in run-time and possibly some cost to object code size.

Benefits: [Type confusion is 7% of our high severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf), though a fair amount of that is within V8 and wouldn’t be covered by C++ improvements (nor by a new general-purpose programming language). Attackers seem particularly fond of exploiting these bugs disproportionately to their number.


# Make All DCHECKs Into CHECKs

Problem: DCHECKs exist to check some static invariant, but they are sometimes misused to check a dynamic invariant (sometimes on the assumption that we’ll notice the bug dynamically in debug builds). In release builds, execution might sail past the DCHECK and lead to some memory safety problem, or sometimes some logic error. In either case it can be a security bug.

Solutions: Audit for unnecessary DCHECKs (there are some), and then turn many remaining DCHECKs into CHECKs. Some DCHECKs really are checking static invariants, and those should not be converted.

Current status: [Albatross](https://www.google.com/url?q=https://docs.google.com/document/d/1QY4IbbJ8X6G-6-cMheEkP_mT7ZNPCuUJIW2sr_mEiH4/edit\&sa=D\&source=editors\&ust=1756042270478457\&usg=AOvVaw2w_n-C7FcRSoH2Licyw0y_) build. Proposal probabilistically to enable DCHECKs for some fraction of checks on some build.

Costs: An extra branch instruction at runtime. The checking clause on some DCHECKs involves substantial binary bloat and runtime calculation (e.g. comparing trees of opcodes in V8). We would need some way of working around this, where possible.

Benefits: Can address memory safety problems and logic/correctness problems. About 30% of our high severity security bugs are not memory safety problems. [10% of our high severity security bugs are DCHECKs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf) where we’ve determined that there may be security implications when the release build goes past the DCHECK site.


# Back NOTREACHED With CHECK

Problem: NOTREACHED implies that the program has entered an undefined state, and the result will be undefined behaviour. While this crashes in debug builds, it continues on (un)happily for our users.

Solutions: Make NOTREACHED do a CHECK(false) instead of DCHECK(false), or equivalent.

Current status: There is [a plan to make NOTREACHED be \[\[noreturn\]\]](https://www.google.com/url?q=https://bugs.chromium.org/p/chromium/issues/detail?id%3D851128\&sa=D\&source=editors\&ust=1756042270481745\&usg=AOvVaw3inkM--hBW0Ge41VbNDbX6) which includes making it IMMEDIATE\_CRASH.

Costs: More binary size for our users, as these checks are compiled out in release builds today. This should be significantly smaller and safer than converting DCHECK to CHECK globally, as NOTREACHED is used to document undefined behaviour and is less common. It’s likely this would take multiple rounds of attempts to land and stick. Any NOTREACHED that was found happening in production should be removed and converted to handle that case correctly.


# Prevent Use After Move

Problem: C++ allows programmers to move objects, and then use the moved-from storage. (We call this use after move, or UAM.) The state of that storage is undefined and using it is UB.

Solution: Implement a Clang plugin to prevent touching any moved value.

Existing work:

- Clang [MisusedMovedObject check](https://www.google.com/url?q=https://clang.llvm.org/docs/analyzer/checkers.html%23alpha-cplusplus-misusedmovedobject-c\&sa=D\&source=editors\&ust=1756042270484670\&usg=AOvVaw2n5xPWTKAJZUzITx6rP09l)
- [Clang-Tidy bugprone-use-after-move](https://www.google.com/url?q=https://clang.llvm.org/extra/clang-tidy/checks/bugprone-use-after-move.html\&sa=D\&source=editors\&ust=1756042270484940\&usg=AOvVaw1_knFIvkFnj-hV1S6MRm0W) is deployed in google3 [and in Chromium](https://www.google.com/url?q=https://chromium-review.googlesource.com/c/chromium/src/%2B/2383010\&sa=D\&source=editors\&ust=1756042270485148\&usg=AOvVaw0_m_Y5SU1yK3rMjhRMtmGF).

Clang-tidy's check is helpful but not sufficient. It does not see this as a UAM:

auto consumes = \[]\(OnceClosure c) {};

auto moves = \[&]\(OnceClosure& c) { consumes(std::move(c)); };

auto c = BindOnce(\[]\() {});

moves(c);

moves(c); // Use after move.

Chromium currently relies on things like OnceCallback and unique\_ptr being readable (and in a null state) after being moved-from.

Current status: None. [Bug for using an attribute to annotate acceptable uses](https://www.google.com/url?q=https://crbug.com/1198689\&sa=D\&source=editors\&ust=1756042270486753\&usg=AOvVaw3IhsbFl3n_IH9wxWGIPp58).

Costs: Hopefully none?

Benefits: Reduced object lifetime errors.


# Appendix: Explore Solutions For Logic Errors

Chrome Security’s primary concern about C++ is memory safety errors. However, once they’re all fixed, attackers will move to exploit logic errors instead. There are some facilities and idioms provided by other languages which perhaps make such errors less likely. There are perhaps some things we could do to C++ to discourage logic bugs in security-critical areas. These could also potentially serve to reduce temporal unsafety.

Logic errors are around [10% of our high severity security bugs](https://docs.google.com/document/d/e/2PACX-1vRZr-HJcYmf2Y76DhewaiJOhRNpjGHCxliAQTBhFxzv1QTae9o8mhBmDl32CRIuaWZLt5kVeH9e9jXv/pub#h.eoikp3r0cwlf).


## Encourage Type Wrappers For Security Invariants

Problem: C++ makes it awkward to write type wrappers. In another language, you might have (for instance) IpAddress and IpAddressWhichIsNotLoopback (wrapping IpAddress with zero runtime impact except for an initial check). Some APIs would only accept the latter type, providing zero runtime impact. None of this is impossible in C++, it’s just not a common pattern because C++ makes it a bit awkward.

Similarly, it might be useful to have [ranged integers](https://www.google.com/url?q=https://resources.sei.cmu.edu/asset_files/TechnicalNote/2007_004_001_14846.pdf\&sa=D\&source=editors\&ust=1756042270490096\&usg=AOvVaw2EsoaFDmD-p7AqrEA8DOzK).

For example, there are many web platform features that require the caller to be in a secure context. Part of that check is checking that the caller’s origin is one of the secure URL schemes. Right now, we pass in normal GURLs and url::Origins (preferably the latter!), and expect the callee (the feature) to explicitly check.

Instead, we could bake that check into the constructor of a constrained class, e.g.:

class SecureGURL : public GURL {

  // This constructor is intentionally not \`explicit\`:

  SecureGURL(const GURL& gurl) { CHECK(gurl.IsSecureScheme()); ... }

}

 

std::vector\<byte> LoadTrustedResource(const SecureGURL& gurl);

Thus the callee, in this case the hypothetical LoadTrustedResource, can only be called with a GURL that has already passed the check, and does not need to explicitly perform the check.

ellyjones@ notes that we could go further, and  could make SecureGURL not a subclass of GURL, so that nobody can accidentally downcast. It would require us to restate the entire interface of GURL, though.

Solution: Guidance that compile-time type safety can address higher-level logic errors. Look for cases in the codebase where this can help. (Origins, URIs, et c. seem like a likely area, for example.)

Current status: None.

Costs: Should be no runtime cost, in fact the opposite if it means a check can only be performed once or statically, not dynamically or multiple times. It might or might not be hard to identify cases where this sort of pattern makes sense in an existing codebase.

Benefits: If any cases can be identified, may eliminate some logic bugs with no performance penalty (or a micro-improvement, e.g getting rid of a CHECK).


# Appendix: Hardware Support For Detecting Memory Issues

## Memory Tagging

Everything that was old is new again: tagged memory is making a resurgence. (Between that and the prevalence of JavaScript, Lisp really did win after all!) Depending on the specific mechanism, pointers to and/or regions of memory are ‘tagged’, and if code tries to load or store memory without using the right tag, the program faults. This helps us detect bugs and stop exploits with a certain (typically high) probability per instance.

MTE might appear in high-end devices soon, but will take much longer to reach most of the world.

Tagging is not a perfect defense. If an attacker can learn or guess the correct tag — [and they often can](https://www.google.com/url?q=https://googleprojectzero.blogspot.com/2019/02/examining-pointer-authentication-on.html\&sa=D\&source=editors\&ust=1756042270496850\&usg=AOvVaw2qpVDAIC2xaLx6DwOlhuqv) — they can make use of the correct tag during their exploit and hence not trigger the hardware’s alarm. To get the benefit of tagging, we will need to make it hard for attackers to learn tag values, and hard for them to guess. (Such as by, potentially, having the browser throttle navigations to sites that crash their renderers too often. Whether that would actually work, I don’t know.)


## Control Flow Integrity

We are now shipping [support for Intel Control-flow Enforcement Technology (CET) on Windows](https://www.google.com/url?q=https://security.googleblog.com/2021/05/enabling-hardware-enforced-stack.html\&sa=D\&source=editors\&ust=1756042270498100\&usg=AOvVaw208dmleQW-IibKnWUWFzeL).

Deploying this makes it meaningful to ship forward jump Clang CFI/Windows CFG, and we are investigating doing so in 2021. TODO: ENDBRANCH.

We are also going to investigate enabling CET on all OSs, hopefully also in 2021.

TODO: [ARM PAC](https://www.google.com/url?q=https://developer.apple.com/documentation/security/preparing_your_app_to_work_with_pointer_authentication\&sa=D\&source=editors\&ust=1756042270499119\&usg=AOvVaw3iMAR1FusAcv3q3edAOnhY) is shipping today for Apple devices. It would also be good to explore PAC and [BTI](https://www.google.com/url?q=https://developer.arm.com/documentation/ddi0596/2020-12/Base-Instructions/BTI--Branch-Target-Identification-\&sa=D\&source=editors\&ust=1756042270499416\&usg=AOvVaw1SZ9mC7e1Xji0JoaXXpy0-) on other hardware and operating systems.


# Appendix: Bug Types

This document talks about the percentage impact of fixing different types of security bug. Those percentages are based on a manual analysis of each high severity security bug that has impacted the stable channel since the start of 2019. Exact root causes are a little approximate. It’s worth noting that the “temporal safety” sector seems to be growing year-by-year.

![](https://lh7-rt.googleusercontent.com/u/0/docsd/ANYlcfBbLA1rOnB5KKaeYiOLKZF-YiHnP3eGW4382aEjq6axftBI3Rf9OZxVl9QOHA5doTdiyoKvvENe33UM7z7e32q9zp98FPrRhoWJtME6qpjbbu_woh7iMjzgY79xrwm5fut8H6d-6OIlQQSa5QZstl4pijKyBTsAiPlWxeaete50MKAewMnHCHtUr8Bai5q-SsqCe6HPGzLDHXE4NclON_YmfyLQ3kvf-XiWZmxOLfCG2aSBaaKrHwS0xJ4maBV4sxAuP8R5xlr8Ug8uT3-O5zW0ZlA4Bk4M8ke3WpAmKLcGl2L_mfUtp2SW0cnJKBqN4pJGxiRxHHVlh_tOEF6j_EAkmUxrqs1Y4s6fTZp1W6aHsD0xS6hH_sQSi6s3Xzux79RlQTgFDU4p_Bs8hBLM5By92S677tqYvrITo8zca8utLWydSt_4ja5qOG5oUf1axU2KEDBWFDKgpB1QXGeJqAU2lvO2jlAkRu11AYKJ3G_LcrmQgMBHe5uLTLtDE6s_pSqRmAMzZ4QqfUVK_TWCK1SVAtd8kZW_GxsQrUBtjq-VT7aA55U77Xv2yxyS8EYkhDeSnD-ckk6T_ZUCn_ewGSPyx2DNOcPw6qr3bZBTfeVQfx3acQDcaEeuE3GaxRyHIgwgHwT7YEAFikDr5ni9c6TjlByfvdeE3MPV9IFnH0W_y_4MoPAUeZzKHc8_IdeVamZbaeVgE0u0SlE0md-aUkjk98PwXMSod3AAxcFhxrG3L_I7GWTmMfK3GoWhhICsYgn3RndFXy2M4s-86uNKOGXoL4ORFAumntXVaav7jJLmJ4X9BQqPSO3u7w_k1xNX0LDG2-LhPg2MjskgfmU2n-xhlwuYCFiMt_zIqdyk9T5opy6L2_itGnlXx3OvWRvr9PZV_Qq2lNfbkNoZL9MytLs-Pad3w77j5qN_sc7hgfY6ixlHHyQdWGGu0AzKkL9CiFKmNm9YQOVREeZ6rH4yWj-2cpHP1FZpKGBEJBm0YZO5h6ZWrxR_Iq4KtV_YB2jL-Nk)


# Appendix: Remove Null Pointers

Problem: While we don’t consider null pointer dereferences to be a security vulnerability (unless the attacker can control an offset to the pointer, which is rare), they do account for a big fraction of our stability bugs. It can also take the Security Sheriff substantial time to ensure that a given bug really is ‘just’ a stability bug ([example](https://www.google.com/url?q=https://bugs.chromium.org/p/chromium/issues/detail?id%3D1048473\&sa=D\&source=editors\&ust=1756042270501686\&usg=AOvVaw10EyPpMXwKgQmpslmcigQP)).

Removing null pointers may also improve developer ergonomics — people can shed the cognitive and code overhead of checking for null.

Note: ASan explicitly reports a crash as null-deref if the faulty address is within \[0, 4096). Without ASan one needs to look at the value of registers, but people make mistakes sometimes. Reproducing as many crashes as possible on ClusterFuzz would likely reduce the chance of an error.

Solutions: Modify the smart pointer type to require an explicit annotation or constructor flag for pointers which may be null. Check and crash on deference for such pointers. Check on construction for those pointers which shouldn’t be null.

As with integer semantics, it may be possible to get what we want with compiler options. [Several options are available](https://www.google.com/url?q=https://clang.llvm.org/docs/UndefinedBehaviorSanitizer.html\&sa=D\&source=editors\&ust=1756042270503643\&usg=AOvVaw3LhSut79E-skjajEq2ZZae), including -fsanitize=null and -fsanitize=nullability-arg. The nullability-\* options work with Clang’s \_Nonnull annotation.

Current status: None.

Costs: The micro-cost of the check.

Benefits: We should detect stability bugs sooner, and may save time in security bug triage.


# Appendix: Mitigations

This document focuses on language-level approaches to the problem: codifying safer usage patterns for C++ to reduce memory unsafety and UB generally.

Exploit mitigations and enhanced bug-finding techniques can complement such work. Examples include:

- HWASAN
- GWP-ASan
- Memory tagging (e.g. MTE)
- CFI and stack protection
- The classics: W^X/DEP, stack canaries, heap canaries, ASLR


# Appendix: Other Ideas

Others possibly to include:

- Remove base::Unretained — require developers to decide the right ownership model for each object. (WeakPtr is not always a silver bullet because it cannot be used across task sequences/threads.)

* Or, back Unretained with MiraclePtr.

- Mojom improvements to ensure all objects are stored in suitable containers?
- Ban design patterns which tend to cause problems (e.g. singletons intrinsically mean shared and likely mutable state). (There was [an effort to systematically investigate](https://www.google.com/url?q=https://docs.google.com/document/d/1MAuOqSpVaKsjqmw8oPLwwdSywHX9HF4FiPnODHNimmQ/edit\&sa=D\&source=editors\&ust=1756042270507856\&usg=AOvVaw1kHZW3cAtxrS5Z_b3MRrBU).)
- Re-emphasize composition rather than any kind of pointer in the first place. (Can we write a checker to look for objects owned by pointer which could instead simply be owned by value?)
- Replace base::Bind and all code which uses it with a straight-line version instead (promises? Some C++ code generator?), to simplify the ease of writing asynchronous code and make error cases easier to spot.
- Design for fuzzing: encourage patterns in mojo & implementation that make it easier to fuzz formats and object lifetimes from a compromised renderer.
- Design for static analysis: discourage patterns that give static analyzers a hard time.
- [SAL annotations](https://www.google.com/url?q=https://docs.microsoft.com/en-us/cpp/code-quality/using-sal-annotations-to-reduce-c-cpp-code-defects\&sa=D\&source=editors\&ust=1756042270509560\&usg=AOvVaw2Mao3fcutHdRTCOBhGYOtV). Valuable at the OS boundary where annotations are already available. Basically a new language for base:: developers to interface with to take full advantage.
- Compile parts of the code with WebAssembly. (We are investigating this as of August 2021.)
