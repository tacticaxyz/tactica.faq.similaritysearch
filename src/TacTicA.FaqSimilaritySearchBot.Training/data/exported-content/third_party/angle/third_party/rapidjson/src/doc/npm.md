URL:https://source.chromium.org/chromium/chromium/src/+/main:third_party\angle\third_party\rapidjson\src\doc\npm.md
## NPM

# package.json {#package}

~~~~~~~~~~js
{
  ...
  "dependencies": {
    ...
    "rapidjson": "git@github.com:Tencent/rapidjson.git"
  },
  ...
  "gypfile": true
}
~~~~~~~~~~

# binding.gyp {#binding}

~~~~~~~~~~js
{
  ...
  'targets': [
    {
      ...
      'include_dirs': [
        '<!(node -e \'require("rapidjson")\')'
      ]
    }
  ]
}
~~~~~~~~~~
