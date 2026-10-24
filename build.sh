#!/bin/bash
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 10.0 --quality preview
export PATH="$HOME/.dotnet:$PATH"
dotnet publish -c Release -o output