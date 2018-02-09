using System.Collections.Generic;

namespace HooksNet.Console
{
    public class GitHookContext
    {
        public List<StagedFile> Files { get; }
        public HookType Type { get; }
        public string AssemblyPath { get; }

        public GitHookContext(List<StagedFile> files, HookType type, string assemblyPath)
        {
            Files = files;
            Type = type;
            AssemblyPath = assemblyPath;
        }
    }
}