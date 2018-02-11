#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then  
  rm -R $artifactsFolder
fi

dotnet build HooksNet.sln
dotnet test HooksNet.Console.Tests
dotnet test HooksNet.Tests

revision=${TRAVIS_BUILD_NUMBER:=1}  
revision=$(printf "%04d" $revision)

dotnet pack HooksNet /p:NuspecFile=../HooksNet.nuspec -c Release -o ./artifacts -Version $MAJOR_VERSION_NUMBER.$MINOR_VERSION_NUMBER.$TRAVIS_BUILD_NUMBER
dotnet nuget push ./HooksNet/artifacts/*.nupkg -k $NugetApikey -s https://api.nuget.org/v3/index.json