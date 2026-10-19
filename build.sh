#!/bin/sh
# تثبيت .NET 10
curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 10.0 -InstallDir ./dotnet

# بناء المشروع
./dotnet/dotnet publish -c Release -o output

# طباعة محتويات مجلد الإخراج (للتأكد من وجود الملفات)
echo "--- محتويات مجلد output ---"
ls -R output