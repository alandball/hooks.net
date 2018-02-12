using System;
using HooksNet.Hooks;

namespace HooksNet.Console.Tests
{
    public class GitHooksFixture : IPreCommitHook
    {
        public void OnPreCommit(PreCommitHookContext context)
        {
            if(GitHookCalls.FailCall)
                throw new Exception("Failed on purpose");

            GitHookCalls.PreCommitCalls.Add(context);
        }
    }
}