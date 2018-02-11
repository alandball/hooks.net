using System;
using System.Collections.Generic;

namespace HooksNet.Console
{
    static class FileParser
    {
        public static GitHookContext ProcessFileContent(string fileContent)
        {
            string sectionBreak = "--------";

            var sections = fileContent.Split(sectionBreak);
            var changedFiles = ParseStagedFiles(sections[0]);
            var hookType = ParseHookType(sections[1]);
            var assembly = sections[2].Trim();

            return new GitHookContext(changedFiles, hookType, assembly);
        }

        internal static HookType ParseHookType(string s)
        {
            var trimmed = s.Trim();
            switch (trimmed)
            {
                case "pre-commit":
                    return HookType.PreCommit;
                default:
                    throw new ApplicationException($"Hook type {trimmed} not found");
            }
        }

        internal static List<StagedFile> ParseStagedFiles(string changedFiles)
        {
            var result = new List<StagedFile>();
            var rows = changedFiles.Split("\n");

            foreach (var row in rows)
            {
                var splittedRow = row.Split(null);

                if(splittedRow.Length != 2)
                    continue;

                var type = splittedRow[0];
                var path = splittedRow[1];

                StagedFile file = new StagedFile();
                file.Path = path;

                SetChangeType(type, file);
                result.Add(file);
            }

            return result;
        }

        private static void SetChangeType(string type, StagedFile file)
        {
            switch (type)
            {
                case "A":
                    file.ChangeType = ChangeType.Add;
                    break;
                case "M":
                    file.ChangeType = ChangeType.Modify;
                    break;
                case "D":
                    file.ChangeType = ChangeType.Delete;
                    break;
                case "R":
                    file.ChangeType = ChangeType.Rename;
                    break;
            }
        }
    }


}