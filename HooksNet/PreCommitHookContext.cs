using System.Collections.Generic;

namespace HooksNet
{
    public class PreCommitHookContext
    {
        internal PreCommitHookContext(List<StagedFile> stagedFiles)
        {
            StagedFiles = stagedFiles;
        }

        public List<StagedFile> StagedFiles { get; }
    }
}