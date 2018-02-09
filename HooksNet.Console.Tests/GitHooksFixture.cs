using System.Collections.Generic;
using HooksNet.Hooks;

namespace HooksNet.Console.Tests
{
    public class GitHooksFixture : IPreCommitHook
    {

        public void OnPreCommit(PreCommitHookContext context)
        {
            GitHookCalls.PreCommitCalls.Add(context);
        }
    }
}