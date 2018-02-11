using System.Collections.Generic;

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