#!/bin/bash
sectionBreak="--------"

tmpfile=$(mktemp)
git diff --name-status --staged >> "$tmpfile"

echo "$sectionBreak" >> "$tmpfile"
echo "{type}"
echo "$sectionBreak" >> "$tmpfile"
echo "{assembly}" >> "$tmpfile"

dotnet "{console}" --file "$tmpfile"