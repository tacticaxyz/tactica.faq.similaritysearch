URL:https://source.chromium.org/chromium/chromium/src/+/main:components\test\data\autofill\ml_model\README.md
Generate the autofill_model_metadata.binarypb via
`gqui from textproto:./autofill_model_metadata.textproto proto ../../../../optimization_guide/proto/autofill_field_classification_model_metadata.proto:optimization_guide.proto.AutofillFieldClassificationModelMetadata --outfile=rawproto:autofill_model_metadata.binarypb`
