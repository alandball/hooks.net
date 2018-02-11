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

dotnet pack HooksNet /p:NuspecFile=../HooksNet.nuspec -c Release -o ./artifacts
dotnet nuget push ./HooksNet/artifacts/*.nupkg -k $NugetApikey -s https://api.nuget.org/v3/index.json