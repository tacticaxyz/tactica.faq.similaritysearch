URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\skia\modules\canvaskit\fonts\README.md
To generate the files (other than nofonts.cpp) in here:

    python tools/embed_resources.py --name SK_EMBEDDED_FONTS --input ~/Downloads/NotoMono-Regular.ttf --output modules/canvaskit/NotoMono-Regular.ttf.cpp --align 4
