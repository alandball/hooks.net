using System.Collections.Generic;
using HooksNet.HookContext;

namespace HooksNet
{
    public class PreCommitHookContext : GitHookContext
    {
        internal PreCommitHookContext(List<StagedFile> stagedFiles)
        {
            StagedFiles = stagedFiles;
        }

        public List<StagedFile> StagedFiles { get; }

        public void RestageFiles()
        {

        }
    }
}