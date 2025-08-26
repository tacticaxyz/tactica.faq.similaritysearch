URL:https://source.chromium.org/chromium/chromium/src/+/main:net\data\ov_name_constraints\README.md
This directory contains files to support //components/certificate_transparency,
particularly those policies and preferences related to disabling Certificate
Transparency support for OV-constrained certificates.

It exists in //net/data due to its close coupling to the certificate generation
scripts and the existing net_unittests_bundle_data used extensively for
certificate tests.
