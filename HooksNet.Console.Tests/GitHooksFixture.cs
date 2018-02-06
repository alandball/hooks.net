using HooksNet.Hooks;

namespace HooksNet.Console.Tests
{
    using System.Collections.Generic;

    public class GitHooksFixture : IPreCommitHook
    {
        public int OnPreCommitCalled { get; set; }

        public void OnPreCommit(List<StagedChange> stagedFiles)
        {
            GitHookCalls.OnPreCommitCalled++;
        }
    }
}