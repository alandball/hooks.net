using System.Collections.Generic;

namespace HooksNet
{
    public class PreCommitHookContext : GitHookContext<PreCommitHookContext>
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

    public class GitHookContext<TType>
    {
        public void RunCommand()
        {

        }
    }
}