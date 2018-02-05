#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then  
  rm -R $artifactsFolder
fi

dotnet build
dotnet build -c Release
dotnet test HooksNet.Console.Tests -c Release
dotnet test HooksNet.Tests -c Release

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision)