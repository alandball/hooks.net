#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then  
  rm -R $artifactsFolder
fi

dotnet restore
dotnet build -c Release
dotnet test HooksNet.Console.Tests -c Release
dotnet test HooksNet.Tests -c Release

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

dotnet pack HooksNet /p:NuspecFile="..\HooksNet.nuspec" /p:NuspecProperties="version=0.1.$revision" -c Release -o ./artifacts